"use client";

import { CalendarDays } from "lucide-react";
import { useLocale } from "next-intl";
import { format as formatJalali } from "date-fns-jalali";

import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import { PersianCalendar } from "@/components/ui/persian-calendar";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { cn } from "@/lib/utils";

type DatePickerProps = {
  id: string;
  name: string;
  value: string;
  onChange: (value: string) => void;
  placeholder: string;
};

export default function DatePicker({
  id,
  name,
  value,
  onChange,
  placeholder,
}: DatePickerProps) {
  const locale = useLocale();
  const isPersian = locale === "fa";

  // تبدیل رشته تاریخ به Date
  const selectedDate = value
    ? (() => {
        const [year, month, day] = value.split("-").map(Number);
        return new Date(year, month - 1, day);
      })()
    : undefined;

  // تبدیل Date به رشته YYYY-MM-DD
  const formatValue = (date: Date) => {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const day = String(date.getDate()).padStart(2, "0");

    return `${year}-${month}-${day}`;
  };

  // نمایش تاریخ متناسب با زبان
  const displayDate = selectedDate
    ? isPersian
      ? formatJalali(selectedDate, "d MMMM yyyy")
      : new Intl.DateTimeFormat("en-US", {
          day: "numeric",
          month: "long",
          year: "numeric",
          calendar: "gregory",
        }).format(selectedDate)
    : placeholder;

  const handleSelect = (date?: Date) => {
    if (date) {
      onChange(formatValue(date));
    }
  };

  return (
    <Popover>
      <PopoverTrigger
        className={cn(
          // --- NOYAN: Custom input design ---
          "rounded-[7px] border-none bg-surface neumorphic-field",
          "focus-visible:ring-1 focus-visible:ring-primary/30",
          "flex w-full items-center justify-start px-3 py-2 text-start text-sm",
        )}
      >
        <CalendarDays className="me-2 size-4 text-muted-foreground" />

        <span className={!selectedDate ? "text-muted-foreground" : ""}>
          {displayDate}
        </span>
      </PopoverTrigger>

      <PopoverContent className="w-fit p-0">
        {isPersian ? (
          <PersianCalendar selected={selectedDate} onSelect={handleSelect} />
        ) : (
          <Calendar
            mode="single"
            selected={selectedDate}
            onSelect={handleSelect}
          />
        )}
      </PopoverContent>
    </Popover>
  );
}
