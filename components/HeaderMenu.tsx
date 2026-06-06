"use client";
import Link from "next/link";
import { usePathname } from "next/navigation";
import { Gem } from "lucide-react";
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "@/components/ui/navigation-menu";
export default function HeaderMenu() {
  const pathname = usePathname();
  const LinkClass = (path: string) =>
    `px-4 py-2  rounded-md cursor-pointer text-sm transition-colors ${
      pathname === path
        ? "bg-accent text-accent-foreground"
        : "hover:bg-accent/30"
    }`;
  return (
    <header className=" fixed top-0 left-0 w-full  p-4 border-b border-border bg-background/95 backdrop-blur">
      <div className=" container mx-auto   text-lg flex justify-between items-center">
        <NavigationMenu>
          <NavigationMenuList className="flex-row-reverse">
            {/* لینک ساده */}
            <NavigationMenuItem>
              <Link href="/" className={LinkClass("/")}>
                خانه
              </Link>
            </NavigationMenuItem>

            {/* منوی کشویی محصولات */}
            <NavigationMenuItem>
              <NavigationMenuTrigger className=" hover:bg-accent/30 text-sm">
                محصولات
              </NavigationMenuTrigger>
              <NavigationMenuContent>
                <div className="w-48 p-2 ">
                  <ul className="grid gap-1 text-sm justify-end text-right">
                    <li>
                      <Link
                        href="/products/electronic"
                        className="block p-2 hover:bg-accent/30 rounded-md"
                      >
                        الکترونیک
                      </Link>
                    </li>
                    <li>
                      <Link
                        href="/products/clothing"
                        className="block p-2 hover:bg-accent/30 rounded-md"
                      >
                        پوشاک
                      </Link>
                    </li>
                    <li>
                      <Link
                        href="/products/books"
                        className="block p-2 hover:bg-accent/30 rounded-md"
                      >
                        کتاب‌ها
                      </Link>
                    </li>
                  </ul>
                </div>
              </NavigationMenuContent>
            </NavigationMenuItem>

            {/* لینک ساده دیگر */}
            <NavigationMenuItem>
              <Link href="/blog" className={LinkClass("/blog")}>
                وبلاگ
              </Link>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <Link href="/blog" className={LinkClass("/blog")}>
                وبلاگ
              </Link>
            </NavigationMenuItem>
          </NavigationMenuList>
        </NavigationMenu>

        <Gem size={32} className=" text-primary" />
      </div>
    </header>
  );
}
