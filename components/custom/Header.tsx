import { useTranslations } from "next-intl";
import { SidebarTrigger } from "@/components/ui/sidebar";
import UserMenu from "./UserMenu";
export default function Header() {
  const t = useTranslations("header");

  return (
    <header
      className="
      
        px-4
        py-2
        mx-2 md:ms-0

        my-2
       bg-background/30
    backdrop-blur-lg
    backdrop-saturate-150

        border
        border-white/20

        rounded-[10px]
      "
    >
      <div className="flex items-center justify-between">
        <div className="flex items-center gap-1">
          <div
            className="w-20 md:w-10 h-10 bg-primary  mb-2"
            style={{
              maskImage: "url('/images/NOYAN-logot.svg')",
              maskRepeat: "no-repeat",
              maskPosition: "center",
              maskSize: "contain",
            }}
          />
          <div
            className="w-16 h-16 shrink-0 bg-primary"
            style={{
              maskImage: "url('/images/NOYAN.svg')",
              maskRepeat: "no-repeat",
              maskPosition: "center",
              maskSize: "contain",
            }}
          />

          <div className="text-sm text-muted-foreground ms-3">
            {t("headerDescription")}
          </div>
        </div>

        <div className="md:hidden">
          <SidebarTrigger />
        </div>
        <div>
          <UserMenu />
        </div>
      </div>
    </header>
  );
}
