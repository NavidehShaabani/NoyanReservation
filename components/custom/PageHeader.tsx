import type { ReactNode } from "react";
import { cn } from "@/lib/utils";

type PageHeaderProps = {
  title: string;
  description?: string;
  icon?: ReactNode;
  className?: string;
  size?: "default" | "sm";
};

export default function PageHeader({
  title,
  description,
  icon,
  className,
  size = "default",
}: PageHeaderProps) {
  const isSmall = size === "sm";

  return (
    <div
      className={cn(
        "flex items-center",
        isSmall ? "gap-2" : "gap-3",
        className,
      )}
    >
      {icon && (
        <div
          className={cn(
            "shrink-0 flex items-center justify-center rounded-xl bg-primary/10 text-primary",
            isSmall ? "size-9" : "size-11",
          )}
        >
          {icon}
        </div>
      )}

      <div className="min-w-0">
        <h1
          className={cn(
            "font-semibold text-foreground",
            isSmall ? "text-lg" : "text-2xl",
          )}
        >
          {title}
        </h1>

        {description && (
          <p
            className={cn(
              "mt-1 text-muted-foreground",
              isSmall ? "text-xs" : "text-sm",
            )}
          >
            {description}
          </p>
        )}
      </div>
    </div>
  );
}
