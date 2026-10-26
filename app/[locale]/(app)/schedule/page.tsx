"use client";

import { useState } from "react";
import { ChevronLeft, ChevronRight, CalendarDays } from "lucide-react";

import {
  mockSpaces,
  mockBookings,
  getBookingOccurrences,
} from "@/data/schedule-mock";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

import { useLocale, useTranslations } from "next-intl";

// import {  format } from "date-fns-jalali";

import {
  addDays,
  startOfWeek,
  endOfWeek,
  format as formatJalali,
} from "date-fns-jalali";
type CalendarView = "week" | "month" | "list";

export default function SchedulePage() {
  const t = useTranslations("schedule");
  const locale = useLocale();
  const isPersian = locale === "fa";

  const [currentDate, setCurrentDate] = useState(() => new Date());
  const [selectedSpace, setSelectedSpace] = useState("all");
  const [view, setView] = useState<CalendarView>("week");
  const handleDateChange = (date: Date) => {
    setCurrentDate(date);
  };
  const weekStart = startOfWeek(currentDate, {
    weekStartsOn: isPersian ? 6 : 0,
  });

  const weekEnd = endOfWeek(currentDate, {
    weekStartsOn: isPersian ? 6 : 0,
  });
  const weekDays = Array.from({ length: 7 }, (_, index) =>
    addDays(weekStart, index),
  );

  const weekBookings = getBookingOccurrences(
    mockBookings,
    weekStart,
    addDays(weekEnd, 1),
  ).filter(
    (booking) => selectedSpace === "all" || booking.spaceId === selectedSpace,
  );

  const getBookingsForDay = (day: Date) =>
    weekBookings.filter(
      (booking) =>
        booking.start.getFullYear() === day.getFullYear() &&
        booking.start.getMonth() === day.getMonth() &&
        booking.start.getDate() === day.getDate(),
    );

  const formatDate = (date: Date) => {
    if (isPersian) {
      return formatJalali(date, "d MMMM");
    }

    return new Intl.DateTimeFormat("en-US", {
      day: "numeric",
      month: "long",
      calendar: "gregory",
    }).format(date);
  };

  const getDayName = (date: Date) => {
    const dayKeys = ["sun", "mon", "tue", "wed", "thu", "fri", "sat"] as const;

    return t(`days.${dayKeys[date.getDay()]}`);
  };

  const dateRange = t("dateRange", {
    start: formatDate(weekStart),
    end: formatDate(weekEnd),
  });

  return (
    <div className="mx-2 mb-2 flex min-h-0 flex-1 flex-col md:ms-0">
      <div className="flex min-h-0 w-full max-w-10xl flex-1 flex-col gap-y-5 overflow-y-auto page-scrollbar rounded-[10px] bg-background p-5 shadow-[16px_16px_32px_rgba(209,207,204,0.55)] md:p-8">
        {/* Page heading */}
        <div className="flex items-center gap-3">
          <div className="flex size-11 items-center justify-center rounded-xl bg-primary/10 text-primary">
            <CalendarDays className="size-5" />
          </div>

          <div>
            <h1 className="text-2xl font-semibold">{t("title")}</h1>
            <p className="mt-1 text-sm text-muted-foreground">
              {t("description")}
            </p>
          </div>
        </div>

        {/* Calendar toolbar */}
        <div className="flex flex-col gap-4 rounded-xl border border-border/60 bg-background/70 p-4">
          <div className="flex flex-wrap items-center justify-between gap-3">
            <div className="flex flex-wrap items-center gap-3">
              <div className="flex items-center gap-2">
                <Button
                  variant="outline"
                  size="icon"
                  aria-label={t("previous")}
                  onClick={() =>
                    setCurrentDate((date) =>
                      view === "month"
                        ? new Date(
                            date.getFullYear(),
                            date.getMonth() - 1,
                            date.getDate(),
                          )
                        : addDays(date, -7),
                    )
                  }
                >
                  {isPersian ? (
                    <ChevronRight className="size-4" />
                  ) : (
                    <ChevronLeft className="size-4" />
                  )}
                </Button>

                <Button
                  variant="outline"
                  size="sm"
                  onClick={() => handleDateChange(new Date())}
                >
                  {t("today")}
                </Button>

                <Button
                  variant="outline"
                  size="icon"
                  aria-label={t("next")}
                  onClick={() =>
                    setCurrentDate((date) =>
                      view === "month"
                        ? new Date(
                            date.getFullYear(),
                            date.getMonth() + 1,
                            date.getDate(),
                          )
                        : addDays(date, 7),
                    )
                  }
                >
                  {isPersian ? (
                    <ChevronLeft className="size-4" />
                  ) : (
                    <ChevronRight className="size-4" />
                  )}
                </Button>
              </div>

              <div
                className="whitespace-nowrap text-sm font-medium"
                aria-live="polite"
              >
                {dateRange}
              </div>
            </div>
            <div className="flex flex-wrap items-center gap-1 rounded-lg bg-muted/60 p-1">
              {(["week", "month", "list"] as const).map((item) => (
                <Button
                  key={item}
                  variant={view === item ? "default" : "ghost"}
                  size="sm"
                  onClick={() => setView(item)}
                >
                  {t(
                    item === "week"
                      ? "weekView"
                      : item === "month"
                        ? "monthView"
                        : "listView",
                  )}
                </Button>
              ))}
            </div>
          </div>

          <div className="flex flex-col gap-2 sm:max-w-xs">
            <label className="text-sm font-medium">{t("spaceFilter")}</label>

            <Select value={selectedSpace} onValueChange={setSelectedSpace}>
              <SelectTrigger className="w-full">
                <SelectValue />
              </SelectTrigger>

              <SelectContent>
                <SelectItem value="all">{t("allSpaces")}</SelectItem>
                {mockSpaces.map((space) => (
                  <SelectItem key={space.id} value={space.id}>
                    {space.name}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>
        </div>

        {/* Temporary placeholder */}
        <div className="grid grid-cols-7 gap-2">
          {weekDays.map((day) => (
            <div
              key={day.toISOString()}
              className="min-w-0 rounded-lg border border-border/60 bg-background/60 p-2 text-center"
            >
              <div className="text-sm text-muted-foreground">
                {getDayName(day)}
              </div>

              <div className="mt-1 font-semibold">{formatDate(day)}</div>
              <div className="mt-3 space-y-2 text-start">
                {getBookingsForDay(day).map((booking) => (
                  <div
                    key={booking.id}
                    className="rounded-md border border-border/60 bg-muted/50 p-2 text-xs"
                  >
                    <div className="font-medium">{booking.title}</div>

                    <div className="mt-1 text-muted-foreground">
                      {booking.start.toLocaleTimeString(
                        isPersian ? "fa-IR" : "en-US",
                        {
                          hour: "2-digit",
                          minute: "2-digit",
                          hour12: false,
                        },
                      )}
                      {" – "}
                      {booking.end.toLocaleTimeString(
                        isPersian ? "fa-IR" : "en-US",
                        {
                          hour: "2-digit",
                          minute: "2-digit",
                          hour12: false,
                        },
                      )}
                    </div>
                  </div>
                ))}
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
