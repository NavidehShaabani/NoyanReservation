import { useState, useEffect, useContext } from "react";
import {
  DropdownMenu,
  DropdownMenuItem,
  DropdownMenuContent,
  DropdownMenuTrigger,
  DropdownMenuGroup,
  DropdownMenuSeparator,
} from "../ui/dropdown-menu";
import { Button } from "../ui/button";
import { CircleUserRound, UserRound, LogOut, KeyRound } from "lucide-react";
import { useRouter } from "next/navigation";
import { useLocale } from "next-intl";
import { AuthContext } from "@/context/AuthProvider";
import { apiUrl } from "@/lib/api/config";

type locale = "fa" | "en";
export default function UserMenu() {
  const router = useRouter();
  const locale = useLocale() as locale;
  const { token } = useContext(AuthContext);
  const logout = async () => {
    try {
      const response = await fetch(apiUrl("/api/Auth/logout"), {
        method: "POST",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
      });
      if (!response.ok) {
        const errorBody = await response.text();
        console.error("Logout API error:", response.status, errorBody);
        return;
      }

      router.push(`/${locale}/login`);
    } catch (error) {
      console.error("Failed to logout:", error);
    }
  };
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="ghost" size="icon" className="rounded-full">
          <CircleUserRound className="size-8 text-[hsl(var(--primary))]" />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        <DropdownMenuGroup>
          <DropdownMenuItem
            onClick={() => {
              router.push(`/${locale}/profile`);
            }}
          >
            <UserRound />
            پروفایل
          </DropdownMenuItem>
          <DropdownMenuItem>
            <KeyRound />
            تغییر رمز عبور
          </DropdownMenuItem>
        </DropdownMenuGroup>
        <DropdownMenuSeparator />
        <DropdownMenuItem
          className="text-[hsl(var(--destructive))]"
          onClick={logout}
        >
          <LogOut className="text-[hsl(var(--destructive))]" />
          خروج از سیستم
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
