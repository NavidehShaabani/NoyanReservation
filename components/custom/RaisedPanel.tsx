import type { ReactNode } from "react";
import { cn } from "@/lib/utils";

type RaisedPanelProps = {
  children: ReactNode;
  className?: string;
};
export default function RaisedPanel({ children, className }: RaisedPanelProps) {
  return (
    <div
      className={cn(
        "rounded-[10px] bg-background",
        "shadow-[6px_6px_14px_#c9cabf,-6px_-6px_14px_#ffffff]",
        className,
      )}
    >
      {children}
    </div>
  );
}
