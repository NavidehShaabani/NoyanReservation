import type { ReactNode } from "react";
import Link from "next/link";
import { ArrowLeft } from "lucide-react";
import { cn } from "@/lib/utils";

type PageHeaderProps = {
  title: string;
  description?: string;
  icon?: ReactNode;
  className?: string;
  size?: "default" | "sm";
  backHref?: string;
  backLabel?: string;
};

export default function PageHeader({
  title,
  description,
  icon,
  className,
  size = "default",
  backHref,
  backLabel = "بازگشت",
}: PageHeaderProps) {
  const isSmall = size === "sm";

  return (
    <div className={cn("flex items-center justify-between gap-4", className)}>
      {/* عنوان و آیکون */}
      <div
        className={cn("flex min-w-0 items-center", isSmall ? "gap-2" : "gap-3")}
      >
        {icon && (
          <div
            className={cn(
              "flex shrink-0 items-center justify-center rounded-xl bg-primary/10 text-primary",
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

      {/* لینک بازگشت - اختیاری */}
      {backHref && (
        <Link
          href={backHref}
          className="flex shrink-0 items-center gap-1.5 text-sm text-muted-foreground transition-colors hover:text-primary"
        >
          <ArrowLeft className="size-4 rtl:rotate-180" />
          <span>{backLabel}</span>
        </Link>
      )}
    </div>
  );
}
