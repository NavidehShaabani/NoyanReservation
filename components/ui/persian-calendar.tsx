"use client";

import { DayPicker, faIR, getDateLib } from "@daypicker/persian";

type PersianCalendarProps = {
  selected?: Date;
  onSelect?: (date: Date | undefined) => void;
};

export function PersianCalendar({ selected, onSelect }: PersianCalendarProps) {
  const dateLib = getDateLib({ locale: faIR });
  return (
    <DayPicker
      mode="single"
      selected={selected}
      onSelect={onSelect}
      locale={faIR}
      dateLib={dateLib}
      navLayout="around"
      dir="rtl"
      showOutsideDays
      className="w-fit bg-popover p-3 text-popover-foreground"
      classNames={{
        months: "flex flex-col",
        month: "grid grid-cols-[auto_auto_auto] gap-y-4",

        month_caption:
          "col-start-2 row-start-1 flex h-8 min-w-0 items-center justify-center",

        caption_label: "text-sm font-medium whitespace-nowrap",
        nav: "flex items-center justify-between gap-1",
        button_previous:
          "col-start-1 row-start-1 inline-flex size-8 items-center justify-center rounded-md border border-input bg-background hover:bg-accent hover:text-accent-foreground ",

        button_next:
          "col-start-3 row-start-1 inline-flex size-8 items-center justify-center justify-self-end rounded-md border border-input bg-background hover:bg-accent hover:text-accent-foreground",
        month_grid: "col-span-3 row-start-2 w-full border-collapse",
        weekdays: "flex",
        weekday:
          "flex-1 rounded-md text-center text-xs font-normal text-muted-foreground",
        week: "mt-2 flex w-full",
        day: "flex-1 p-0 text-center",
        day_button:
          "inline-flex size-8 items-center justify-center rounded-md text-sm hover:bg-accent hover:text-accent-foreground focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring",
        selected: "[&>button]:bg-primary [&>button]:text-primary-foreground",
        today: "[&>button]:border [&>button]:border-primary",
        outside: "text-muted-foreground opacity-50",
        disabled: "text-muted-foreground opacity-50",
      }}
    />
  );
}
