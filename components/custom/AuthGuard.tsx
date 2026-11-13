"use client";

import { useContext, useEffect } from "react";
import { useRouter } from "next/navigation";
import { useLocale } from "next-intl";
import { AuthContext } from "@/context/AuthProvider";
import { useTranslations } from "next-intl";

import Image from "next/image";

export default function AuthGuard({ children }: { children: React.ReactNode }) {
  const { token, user, isAuthReady } = useContext(AuthContext);
  const t = useTranslations("auth");
  const router = useRouter();
  const locale = useLocale();

  const isAuthenticated = !!token && !!user;

  useEffect(() => {
    if (isAuthReady && !isAuthenticated) {
      router.replace(`/${locale}/login`);
    }
  }, [isAuthReady, isAuthenticated, router, locale]);

  if (!isAuthReady) {
    return (
      <div className="flex min-h-0 flex-1 flex-col items-center justify-center gap-3">
        <div className="relative flex size-20 items-center justify-center">
          {/* حلقه چرخان */}
          <div className="absolute inset-0 animate-spin rounded-full border-[3px] border-primary/15 border-t-primary" />

          {/* لوگوی NOYAN */}
          <Image
            src="/images/NOYAN.svg"
            alt="NOYAN"
            width={44}
            height={44}
            priority
            className="object-contain"
          />
        </div>

        <p className="text-sm font-semibold tracking-wider text-primary">
          NOYAN
        </p>

        <p className="text-xs text-muted-foreground">{t("waiting")}</p>
      </div>
    );
  }

  if (!isAuthenticated) {
    return null;
  }

  return <>{children}</>;
}
