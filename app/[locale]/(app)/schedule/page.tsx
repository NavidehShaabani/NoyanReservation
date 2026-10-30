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

import {
  addMonths as addJalaliMonths,
  addDays,
  startOfWeek,
  endOfWeek,
  startOfMonth as startOfJalaliMonth,
  endOfMonth as endOfJalaliMonth,
  format as formatJalali,
} from "date-fns-jalali";

import {
  addMonths as addGregorianMonths,
  startOfMonth as startOfGregorianMonth,
  endOfMonth as endOfGregorianMonth,
} from "date-fns";

import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { Calendar } from "@/components/ui/calendar";
import { PersianCalendar } from "@/components/ui/persian-calendar";
import PageCard from "@/components/custom/PageCard";
import PageHeader from "@/components/custom/PageHeader";
type CalendarView = "week" | "month" | "list";

function changeDate(
  date: Date,
  view: CalendarView,
  direction: -1 | 1,
  isPersian: boolean,
): Date {
  if (view !== "week") {
    return isPersian
      ? addJalaliMonths(date, direction)
      : addGregorianMonths(date, direction);
  }

  return addDays(date, direction * 7);
}

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

  const monthStart = isPersian
    ? startOfJalaliMonth(currentDate)
    : startOfGregorianMonth(currentDate);

  const monthEnd = isPersian
    ? endOfJalaliMonth(currentDate)
    : endOfGregorianMonth(currentDate);

  const monthGridStart = startOfWeek(monthStart, {
    weekStartsOn: isPersian ? 6 : 0,
  });

  const monthGridEnd = endOfWeek(monthEnd, {
    weekStartsOn: isPersian ? 6 : 0,
  });

  const monthDays: Date[] = [];

  for (let day = monthGridStart; day <= monthGridEnd; day = addDays(day, 1)) {
    monthDays.push(day);
  }

  const isMonthBasedView = view !== "week";

  const visibleBookings = getBookingOccurrences(
    mockBookings,
    isMonthBasedView ? monthGridStart : weekStart,
    addDays(isMonthBasedView ? monthGridEnd : weekEnd, 1),
  ).filter(
    (booking) => selectedSpace === "all" || booking.spaceId === selectedSpace,
  );

  const displayedDays = view === "month" ? monthDays : weekDays;
  const isOutsideCurrentMonth = (day: Date) => {
    if (isPersian) {
      return (
        formatJalali(day, "yyyy-MM") !== formatJalali(currentDate, "yyyy-MM")
      );
    }

    return (
      day.getMonth() !== currentDate.getMonth() ||
      day.getFullYear() !== currentDate.getFullYear()
    );
  };
  const getBookingsForDay = (day: Date) =>
    visibleBookings.filter(
      (booking) =>
        booking.start.getFullYear() === day.getFullYear() &&
        booking.start.getMonth() === day.getMonth() &&
        booking.start.getDate() === day.getDate(),
    );

  const formatDate = (date: Date) => {
    if (isPersian) {
      return formatJalali(date, "d MMMM yyyy");
    }

    return new Intl.DateTimeFormat("en-US", {
      day: "numeric",
      month: "long",
      year: "numeric",
      calendar: "gregory",
    }).format(date);
  };

  const getDayName = (date: Date) => {
    const dayKeys = ["sun", "mon", "tue", "wed", "thu", "fri", "sat"] as const;

    return t(`days.${dayKeys[date.getDay()]}`);
  };

  const dateRange = t("dateRange", {
    start: formatDate(isMonthBasedView ? monthStart : weekStart),
    end: formatDate(isMonthBasedView ? monthEnd : weekEnd),
  });

  return (
    <div className="mx-2 mb-2 flex min-h-0 flex-1 flex-col md:ms-0">
      <PageCard contentClassName="gap-y-5 p-5 md:p-8">
        {/* Page heading */}
        <PageHeader
          title={t("title")}
          description={t("description")}
          icon={<CalendarDays className="size-5" />}
        />

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
                      changeDate(date, view, -1, isPersian),
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
                      changeDate(date, view, 1, isPersian),
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

              <div className="flex items-center gap-2">
                <div
                  className="whitespace-nowrap text-sm font-medium"
                  aria-live="polite"
                >
                  {dateRange}
                </div>

                <Popover>
                  <PopoverTrigger
                    className="inline-flex size-9 items-center justify-center rounded-md border border-input bg-background hover:bg-accent hover:text-accent-foreground"
                    aria-label={t("selectDate")}
                    title={t("selectDate")}
                  >
                    <CalendarDays className="size-4" />
                  </PopoverTrigger>

                  <PopoverContent className="w-fit p-0">
                    {isPersian ? (
                      <PersianCalendar
                        selected={currentDate}
                        onSelect={(date) => {
                          if (date) handleDateChange(date);
                        }}
                      />
                    ) : (
                      <Calendar
                        mode="single"
                        selected={currentDate}
                        onSelect={(date) => {
                          if (date) handleDateChange(date);
                        }}
                      />
                    )}
                  </PopoverContent>
                </Popover>
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

        {/* Calendar content */}
        {view === "week" ? (
          <>
            {/* Mobile: vertical day list */}
            <div className="flex flex-col gap-3 md:hidden">
              {weekDays.map((day) => {
                const dayBookings = getBookingsForDay(day);

                return (
                  <section
                    key={day.toISOString()}
                    className="min-w-0 overflow-hidden rounded-xl border border-border/60 bg-background/60"
                  >
                    <div className="flex items-center justify-between gap-3 border-b border-border/60 bg-muted/30 px-4 py-3">
                      <h3 className="font-semibold">{getDayName(day)}</h3>
                      <span className="text-sm text-muted-foreground">
                        {isPersian
                          ? formatJalali(day, "d MMMM")
                          : formatDate(day).replace(/, \d{4}$/, "")}
                      </span>
                    </div>

                    <div className="flex flex-col gap-2 p-3">
                      {dayBookings.length > 0 ? (
                        dayBookings.map((booking) => (
                          <div
                            key={booking.id}
                            className="flex min-w-0 items-start gap-3 rounded-lg border border-border/60 bg-background p-3"
                          >
                            <div className="w-24 shrink-0 text-center text-sm tabular-nums">
                              <div className="font-semibold">
                                {booking.start.toLocaleTimeString(
                                  isPersian ? "fa-IR" : "en-US",
                                  {
                                    hour: "2-digit",
                                    minute: "2-digit",
                                    hour12: false,
                                  },
                                )}
                              </div>
                              <div className="mt-1 text-muted-foreground">
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

                            <div className="min-w-0 flex-1 border-s border-border/60 px-3">
                              <div className="break-words font-medium">
                                {booking.title}
                              </div>
                            </div>
                          </div>
                        ))
                      ) : (
                        <p className="px-1 py-2 text-sm text-muted-foreground">
                          {t("noBookings")}
                        </p>
                      )}
                    </div>
                  </section>
                );
              })}
            </div>

            {/* Desktop: seven-column calendar */}
            <div className="hidden grid-cols-7 gap-2 md:grid">
              {weekDays.map((day) => (
                <div
                  key={day.toISOString()}
                  className="min-w-0 overflow-hidden rounded-lg border border-border/60 bg-background/60 p-1 sm:p-2"
                >
                  <div className="min-w-0 text-center">
                    <div className="truncate text-xs font-medium text-muted-foreground sm:text-sm">
                      {getDayName(day)}
                    </div>

                    <div className="mt-1 text-sm font-semibold sm:text-base">
                      {isPersian ? formatJalali(day, "d MMMM") : day.getDate()}
                    </div>
                  </div>

                  <div className="mt-3 space-y-2 text-start">
                    {getBookingsForDay(day).map((booking) => (
                      <div
                        key={booking.id}
                        className="min-w-0 rounded-md border border-border/60 bg-muted/50 p-1 text-xs sm:p-2"
                      >
                        <div className="break-words font-medium">
                          {booking.title}
                        </div>

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
          </>
        ) : view === "month" ? (
          <div className="flex flex-col gap-2">
            {/* Weekday headers */}
            <div className="grid grid-cols-7 gap-2">
              {weekDays.map((day) => (
                <div
                  key={day.toISOString()}
                  className="min-w-0 overflow-hidden rounded-md p-0.5 text-center text-[10px] font-medium text-muted-foreground sm:rounded-lg sm:p-2 sm:text-sm"
                >
                  {getDayName(day)}
                </div>
              ))}
            </div>
            {/* Month days */}
            <div className="grid grid-cols-7 gap-2">
              {monthDays.map((day) => (
                <div
                  key={day.toISOString()}
                  className={`min-w-0 min-h-16 sm:min-h-24 rounded-md sm:rounded-lg border border-border/60 p-1 sm:p-2 ${
                    isOutsideCurrentMonth(day)
                      ? "bg-muted/30 text-muted-foreground opacity-60"
                      : "bg-background/60"
                  }`}
                >
                  <div className="text-sm font-semibold">
                    {isPersian ? formatJalali(day, "d") : day.getDate()}
                  </div>

                  <div className="mt-2 space-y-1">
                    {getBookingsForDay(day).map((booking) => (
                      <div
                        key={booking.id}
                        className="min-w-0 rounded-md border border-border/60 bg-muted/50 p-0.5 text-[10px] sm:p-1 sm:text-xs"
                        title={`${booking.title} — ${booking.start.toLocaleTimeString(
                          isPersian ? "fa-IR" : "en-US",
                          { hour: "2-digit", minute: "2-digit", hour12: false },
                        )}`}
                      >
                        <div className="truncate font-medium" dir="auto">
                          {booking.title}
                        </div>

                        <div className="hidden sm:block text-muted-foreground">
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
        ) : (
          <div className="flex flex-col gap-4">
            {monthDays.map((day) => {
              const dayBookings = getBookingsForDay(day).sort(
                (a, b) => a.start.getTime() - b.start.getTime(),
              );

              if (dayBookings.length === 0) return null;

              return (
                <section
                  key={day.toISOString()}
                  className="min-w-0 overflow-hidden rounded-xl border border-border/60 bg-background/60"
                >
                  {/* Day heading */}
                  <div className="flex flex-wrap items-center justify-between gap-2 border-b border-border/60 bg-muted/30 px-4 py-3">
                    <h3 className="font-semibold">{getDayName(day)}</h3>

                    <span className="text-sm text-muted-foreground">
                      {formatDate(day)}
                    </span>
                  </div>

                  {/* Bookings */}
                  <div className="flex flex-col gap-2 p-3">
                    {dayBookings.map((booking) => {
                      const spaceName = mockSpaces.find(
                        (space) => space.id === booking.spaceId,
                      )?.name;

                      return (
                        <div
                          key={booking.id}
                          className="flex min-w-0 items-center gap-3 rounded-lg border border-border/60 bg-background p-3"
                        >
                          {/* Booking time */}
                          <div className="w-20 shrink-0 text-center text-sm tabular-nums">
                            <div className="font-semibold">
                              {booking.start.toLocaleTimeString(
                                isPersian ? "fa-IR" : "en-US",
                                {
                                  hour: "2-digit",
                                  minute: "2-digit",
                                  hour12: false,
                                },
                              )}
                            </div>

                            <div className="mt-1 text-muted-foreground">
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

                          {/* Booking details */}
                          <div className="min-w-0 flex-1 border-s border-border/60 px-3">
                            <div className="break-words font-medium">
                              {booking.title}
                            </div>

                            {spaceName && (
                              <div className="mt-1 text-sm text-muted-foreground">
                                {spaceName}
                              </div>
                            )}
                          </div>
                        </div>
                      );
                    })}
                  </div>
                </section>
              );
            })}

            {visibleBookings.length === 0 && (
              <p className="rounded-lg border border-dashed border-border p-8 text-center text-muted-foreground">
                {t("noBookings")}
              </p>
            )}
          </div>
        )}
      </PageCard>
    </div>
  );
}
