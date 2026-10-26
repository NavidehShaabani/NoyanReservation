"use client";

import { useState } from "react";
import { ChevronLeft, ChevronRight, CalendarDays } from "lucide-react";

import { mockSpaces } from "@/data/schedule-mock";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

import { useLocale, useTranslations } from "next-intl";

import { addDays, startOfWeek, endOfWeek, format } from "date-fns-jalali";

import { format as formatJalali } from "date-fns-jalali";
type CalendarView = "week" | "month" | "list";

export default function SchedulePage() {
  const t = useTranslations("schedule");
  const locale = useLocale();
  const isPersian = locale === "fa";

  const [currentDate, setCurrentDate] = useState(() => new Date());

  const weekStart = startOfWeek(currentDate, {
    weekStartsOn: isPersian ? 6 : 0,
  });

  const weekEnd = endOfWeek(currentDate, {
    weekStartsOn: isPersian ? 6 : 0,
  });

  const formatDate = (date: Date) =>
    isPersian
      ? formatJalali(date, "d MMMM", { locale: undefined })
      : format(date, "MMM d");

  const dateRange = t("dateRange", {
    start: formatDate(weekStart),
    end: formatDate(weekEnd),
  });
  const [selectedSpace, setSelectedSpace] = useState("all");
  const [view, setView] = useState<CalendarView>("week");

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
            <div className="flex items-center gap-2">
              <Button
                variant="outline"
                size="icon"
                aria-label={t("previous")}
                onClick={() => setCurrentDate((date) => addDays(date, -7))}
              >
                <ChevronLeft className="size-4" />
              </Button>

              <Button
                variant="outline"
                size="sm"
                onClick={() => setCurrentDate(new Date())}
              >
                {t("today")}
              </Button>

              <Button
                variant="outline"
                size="icon"
                aria-label={t("next")}
                onClick={() => setCurrentDate((date) => addDays(date, 7))}
              >
                <ChevronRight className="size-4" />
              </Button>
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

            <div className="text-sm font-medium" aria-live="polite">
              {dateRange}
            </div>
          </div>
        </div>

        {/* Temporary placeholder */}
        <div className="flex min-h-64 flex-1 items-center justify-center rounded-xl border border-dashed border-border text-sm text-muted-foreground">
          {view === "week"
            ? t("weekView")
            : view === "month"
              ? t("monthView")
              : t("listView")}
          {" — "}
          {selectedSpace === "all"
            ? t("allSpaces")
            : mockSpaces.find((space) => space.id === selectedSpace)?.name}
        </div>
      </div>
    </div>
  );
}
