"use client";
import { useContext, useState } from "react";
import { useLocale } from "next-intl";
import { AuthContext, localizedText } from "@/context/AuthProvider";
import { useRouter } from "next/navigation";
import { useTranslations } from "next-intl";
import LogoHeader from "@/components/custom/LogoHeader";
import BackgroundShell from "@/components/custom/BackgroundShell";
import PageCard from "@/components/custom/PageCard";
import { UsersRound } from "lucide-react";
import PageHeader from "@/components/custom/PageHeader";
export default function SelectRole() {
  const { user, token, setToken, setUser } = useContext(AuthContext);
  const locale = useLocale() as keyof localizedText;
  const router = useRouter();
  const t = useTranslations("select-role");
  const [isSelecting, setIsSelecting] = useState(false);
  const [error, setError] = useState("");
  const selectRole = async (roleId: number) => {
    if (isSelecting) return;
    setError("");
    setIsSelecting(true);

    try {
      const response = await fetch(
        "http://10.208.8.91:5295/api/Auth/SelectRole",
        {
          method: "POST",
          credentials: "include",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          body: JSON.stringify({
            roleId,
          }),
        },
      );
      if (!response.ok) {
        setError(t("selecroletError"));
        return;
      }
      const data = await response.json();
      setToken(data.accessToken);
      const activeRoleId = data.activeRoleId;
      if (user) {
        setUser({ ...user, activeRoleId });
      }

      router.push(`/${locale}/dashboard`);
    } catch (error) {
      console.error("Failed to select role:", error);
      setError(t("selectRoleError2"));
    } finally {
      setIsSelecting(false);
    }
  };
  return (
    <BackgroundShell
      className="h-dvh overflow-hidden"
      overlayClassName="flex h-full flex-col overflow-hidden pt-2 "
    >
      <div className="mx-2 flex min-h-0 flex-1 flex-col md:mx-40">
        <div className="shrink-0">
          <LogoHeader />
        </div>
        <div className="my-2 flex min-h-0 flex-1 flex-col md:mt-4">
          <PageCard contentClassName="gap-y-4 p-4 md:px-12">
            <PageHeader
              title={t("pageTitle")}
              description={t("pageTitleDesc")}
              icon={<UsersRound className="size-5" />}
              className="mb-4 "
            />

            {user?.roles.map((role) => (
              <div
                key={role.roleId}
                className="
  w-full
  rounded-3xl
  p-3 sm:p-4
  bg-background
  shadow-[inset_5px_5px_12px_rgba(163,174,187,0.22),inset_-5px_-5px_12px_rgba(255,255,255,0.65)]
  transition-shadow duration-200
"
              >
                <button
                  type="button"
                  disabled={isSelecting}
                  className="
  flex min-h-24 w-full flex-col items-center justify-center gap-2
  rounded-2xl
  p-4
  text-center
  shadow-[3px_3px_8px_rgba(163,174,187,0.24),-3px_-3px_8px_rgba(255,255,255,0.65)]
  transition-[box-shadow,background-color] duration-200
  hover:shadow-[5px_5px_12px_rgba(163,174,187,0.34),-5px_-5px_12px_rgba(255,255,255,0.85)]
  active:shadow-[inset_3px_3px_6px_rgba(163,174,187,0.22),inset_-3px_-3px_6px_rgba(255,255,255,0.55)]
  focus-visible:outline-none
  focus-visible:ring-2
  focus-visible:ring-ring
  focus-visible:ring-offset-2
  disabled:cursor-not-allowed
disabled:opacity-50

  hover:bg-secondary/90
 



"
                  onClick={async () => {
                    await selectRole(role.roleId);
                  }}
                >
                  <span className="text-lg text-foreground">
                    {role.roleName[locale]}
                  </span>

                  <p className="text-sm text-muted-foreground text-center">
                    {role.roleDescription[locale]}
                  </p>
                </button>
              </div>
            ))}
          </PageCard>
        </div>
      </div>
    </BackgroundShell>
  );
}
