import type { ReactNode } from "react";
import { cn } from "@/lib/utils";

type BackgroundShellProps = {
  children: ReactNode;
  className?: string;
  overlayClassName?: string;
};

export default function BackgroundShell({
  children,
  className,
  overlayClassName,
}: BackgroundShellProps) {
  return (
    <div
      className={cn(
        "bg-contain bg-no-repeat bg-top md:bg-cover md:bg-center",
        className,
      )}
      style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
    >
      <div
        className={cn(
          "bg-white/20 backdrop-blur-xl backdrop-saturate-150",
          overlayClassName,
        )}
      >
        {children}
      </div>
    </div>
  );
}
