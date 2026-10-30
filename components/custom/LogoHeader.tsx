"use client";

import { useTranslations } from "next-intl";

export default function LogoHeader() {
  const t = useTranslations("header");

  return (
    <header
      className="
        w-full
        px-4
        py-2
        bg-background/30
        backdrop-blur-lg
        backdrop-saturate-150
        border
        border-white/20
        rounded-[10px]
      "
    >
      <div className="flex items-center gap-3">
        <div
          className="w-16 h-16 shrink-0 bg-primary"
          style={{
            maskImage: "url('/images/NOYAN.svg')",
            maskRepeat: "no-repeat",
            maskPosition: "center",
            maskSize: "contain",
          }}
        />

        <div className="text-sm text-muted-foreground">
          {t("headerDescription")}
        </div>
      </div>
    </header>
  );
}
