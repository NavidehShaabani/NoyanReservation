import type { Metadata, Viewport } from "next";
import localFont from "next/font/local";
import "./../globals.css";

import { cn } from "@/lib/utils";
import PWARegister from "@/components/PWARegister";

import { NextIntlClientProvider } from "next-intl";
import { getMessages } from "next-intl/server";

import { notFound } from "next/navigation";
import { routing } from "@/i18n/routing";
const vazirmatn = localFont({ src: "../../fonts/Vazirmatn-Regular.woff2" });
type Props = {
  children: React.ReactNode;
  params: Promise<{ locale: string }>;
};

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const { locale } = await params;

  const title = locale === "en" ? "Noyan" : "نویان";
  const description =
    locale === "en" ? "Noyan reservation system" : "سیستم رزرواسیون نویان";

  return {
    title,
    description,
    manifest: "/manifest.json",

    appleWebApp: {
      capable: true,
      statusBarStyle: "black-translucent",
      title,
    },

    icons: {
      apple: "/icons/icon-192x192.png",
    },
  };
}

export const viewport: Viewport = {
  themeColor: "#3b82f6",
  width: "device-width",
  initialScale: 1,
  maximumScale: 1,
  userScalable: false,
};

export default async function LocaleLayout({ children, params }: Props) {
  const { locale } = await params;

  if (!routing.locales.includes(locale as "fa" | "en")) {
    notFound();
  }

  const messages = await getMessages();

  const direction = locale === "fa" ? "rtl" : "ltr";

  return (
    <html lang={locale} dir={direction}>
      <body
        className={cn(
          "min-h-screen bg-background text-foreground",
          vazirmatn.className,
        )}
      >
        <NextIntlClientProvider locale={locale} messages={messages}>
          {children}
        </NextIntlClientProvider>

        <PWARegister />
      </body>
    </html>
  );
}
