import type { ReactNode } from "react";
import { cn } from "@/lib/utils";

type PageCardProps = {
  children: ReactNode;
  className?: string;
  contentClassName?: string;
};

export default function PageCard({
  children,
  className,
  contentClassName,
}: PageCardProps) {
  return (
    <div
      className={cn(
        "flex min-h-0 w-full max-w-10xl flex-1 flex-col",
        "overflow-hidden rounded-[10px] bg-background",
        "shadow-[16px_16px_32px_rgba(209,207,204,0.55)]",
        className,
      )}
    >
      <div
        className={cn(
          "flex min-h-0 flex-1 flex-col",
          "overflow-y-auto overscroll-contain page-scrollbar",
          contentClassName,
        )}
      >
        {children}
      </div>
    </div>
  );
}
