export type BookingType = "class" | "course" | "event";

export type ReservableSpace = {
  id: string;
  name: string;
};
export type BookingRecurrence = {
  frequency: "weekly";
  daysOfWeek: number[];
  until: string;
};
export type ScheduleBooking = {
  id: string;
  title: string;
  type: BookingType;
  spaceId: string;
  start: string;
  end: string;
  color: string;
  recurrence?: BookingRecurrence;
};

export const mockSpaces: ReservableSpace[] = [
  {
    id: "hall-1",
    name: "سالن اصلی",
  },
  {
    id: "hall-2",
    name: "سالن چندمنظوره",
  },
];

export const mockBookings: ScheduleBooking[] = [
  {
    id: "booking-1",
    title: "یوگا",
    type: "class",
    spaceId: "hall-1",
    start: "2026-11-14T10:30:00",
    end: "2026-11-14T11:30:00",
    color: "green",
    recurrence: {
      frequency: "weekly",
      daysOfWeek: [3, 6],
      until: "2026-12-31",
    },
  },
  {
    id: "booking-2",
    title: "زومبا",
    type: "class",
    spaceId: "hall-1",
    start: "2026-11-15T16:00:00",
    end: "2026-11-15T18:00:00",
    color: "orange",
  },
  {
    id: "booking-3",
    title: "دوره رقص",
    type: "course",
    spaceId: "hall-1",
    start: "2026-11-16T17:00:00",
    end: "2026-11-16T18:00:00",
    color: "purple",
  },
  {
    id: "booking-4",
    title: "تولد",
    type: "event",
    spaceId: "hall-2",
    start: "2026-11-17T17:00:00",
    end: "2026-11-17T20:00:00",
    color: "pink",
  },
];

export type BookingOccurrence = {
  id: string;
  bookingId: string;
  title: string;
  type: BookingType;
  spaceId: string;
  start: Date;
  end: Date;
  color: string;
};

export function getBookingOccurrences(
  bookings: ScheduleBooking[],
  rangeStart: Date,
  rangeEnd: Date,
): BookingOccurrence[] {
  const occurrences: BookingOccurrence[] = [];

  for (const booking of bookings) {
    const baseStart = new Date(booking.start);
    const baseEnd = new Date(booking.end);

    if (Number.isNaN(baseStart.getTime()) || Number.isNaN(baseEnd.getTime())) {
      continue;
    }

    const addOccurrence = (start: Date, end: Date) => {
      if (start < rangeEnd && end > rangeStart) {
        occurrences.push({
          id: `${booking.id}-${start.getTime()}`,
          bookingId: booking.id,
          title: booking.title,
          type: booking.type,
          spaceId: booking.spaceId,
          start,
          end,
          color: booking.color,
        });
      }
    };

    if (!booking.recurrence) {
      addOccurrence(baseStart, baseEnd);
      continue;
    }

    const duration = baseEnd.getTime() - baseStart.getTime();
    const until = new Date(`${booking.recurrence.until}T23:59:59`);

    const rangeStartDay = new Date(
      rangeStart.getFullYear(),
      rangeStart.getMonth(),
      rangeStart.getDate(),
    );

    const cursor = new Date(
      Math.max(
        new Date(
          baseStart.getFullYear(),
          baseStart.getMonth(),
          baseStart.getDate(),
        ).getTime(),
        rangeStartDay.getTime(),
      ),
    );

    cursor.setHours(0, 0, 0, 0);

    while (cursor <= rangeEnd && cursor <= until) {
      if (
        cursor >=
          new Date(
            baseStart.getFullYear(),
            baseStart.getMonth(),
            baseStart.getDate(),
          ) &&
        booking.recurrence.daysOfWeek.includes(cursor.getDay())
      ) {
        const start = new Date(cursor);
        start.setHours(
          baseStart.getHours(),
          baseStart.getMinutes(),
          baseStart.getSeconds(),
          baseStart.getMilliseconds(),
        );

        addOccurrence(start, new Date(start.getTime() + duration));
      }

      cursor.setDate(cursor.getDate() + 1);
    }
  }

  return occurrences.sort((a, b) => a.start.getTime() - b.start.getTime());
}
