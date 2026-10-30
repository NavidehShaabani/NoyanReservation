import type { ReactNode } from "react";
import { cn } from "@/lib/utils";

type InsetPanelProps = {
  children: ReactNode;
  className?: string;
};

export default function InsetPanel({ children, className }: InsetPanelProps) {
  return (
    <div
      className={cn(
        "rounded-[10px] bg-background",
        "shadow-[inset_5px_5px_11px_#d6d4d1,inset_-5px_-5px_11px_#ffffff]",
        className,
      )}
    >
      {children}
    </div>
  );
}
