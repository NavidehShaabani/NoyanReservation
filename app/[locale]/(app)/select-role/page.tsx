"use client";
import { useContext } from "react";
import { useLocale } from "next-intl";
import { AuthContext, localizedText } from "@/context/AuthProvider";
import { useRouter } from "next/navigation";
import { useTranslations } from "next-intl";
export default function SelectRole() {
  const { user, setActiveRole } = useContext(AuthContext);
  const locale = useLocale() as keyof localizedText;
  const router = useRouter();
  const t = useTranslations("select-role");
  return (
    <div className="   md:bg-backgroundlogin  flex justify-center items-center">
      <div
        className="   bg-card
  w-full
   max-w-4xl
 md:min-h-[70vh]
md:mt-8
md:mb-10
  rounded-[0px] md:rounded-[10px]
  flex flex-col items-center gap-4 py-8
shadow-[7px_7px_17px_#e4e3df,-7px_-7px_17px_#f8f5f1]
       
        "
      >
        <h1 className="sm:text-xl text-lg font-medium text-foreground ">
          {t("pageTitle")}
        </h1>

        {user?.roles.map((role) => (
          <div
            key={role.roleId}
            className="
        
        w-[90%] md:w-[75%] 
       h-36 md:h-32
        rounded-3xl
        p-5
     
        bg-background

        shadow-[inset_8px_8px_18px_rgba(163,174,187,0.25),inset_-8px_-8px_18px_rgba(255,255,255,0.9)]

        transition-all duration-300 ease-out

        hover:shadow-[inset_10px_10px_22px_rgba(163,174,187,0.38),inset_-10px_-10px_22px_rgba(255,255,255,0.95)]
      "
          >
            <button
              type="button"
              className="
          h-full w-full
          rounded-2xl
          p-3

          flex flex-col
          justify-between
          items-center
        
          shadow-[6px_6px_14px_rgba(163,174,187,0.28),-6px_-6px_14px_rgba(255,255,255,0.9)]

          transition-all duration-300

         hover:shadow-[4px_4px_10px_rgba(163,174,187,0.18),-4px_-4px_10px_rgba(255,255,255,0.95)]
         
          active:shadow-[inset_4px_4px_8px_rgba(163,174,187,0.22),inset_-4px_-4px_8px_rgba(255,255,255,0.8)]

        "
              onClick={() => {
                setActiveRole(role);
                router.push(`/${locale}/dashboard`);
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
      </div>
    </div>
  );
}
