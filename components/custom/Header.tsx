import { useTranslations } from "next-intl";

export default function Header() {
  const t = useTranslations("header");

  return (
    <header className="max-w-6xl mx-auto px-4 py-4">
      <div className="flex flex-col items-center gap-2 sm:flex-row sm:items-center sm:gap-3">
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
