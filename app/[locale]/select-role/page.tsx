"use client";
import { useContext } from "react";
import { AuthContext } from "@/context/AuthProvider";
import { ChevronLeft } from "lucide-react";
export default function SelectRole() {
  const { user, setActiveRole } = useContext(AuthContext);

  return (
    <div className="flex flex-col items-center justify-center gap-2">
      {user?.roles.map((role) => (
        <div
          key={role.roleId}
          className="
        group
        w-[80%] h-40
        rounded-3xl
        p-5
        bg-background

        shadow-[inset_8px_8px_18px_rgba(163,174,187,0.25),inset_-8px_-8px_18px_rgba(255,255,255,0.9)]

        transition-all duration-300 ease-out

        hover:shadow-[inset_10px_10px_22px_rgba(163,174,187,0.38),inset_-10px_-10px_22px_rgba(255,255,255,0.95)]
      "
        >
          <div
            className="
          h-full w-full
          rounded-2xl
          p-3

          flex flex-col
          justify-between
          items-center

          shadow-[6px_6px_14px_rgba(163,174,187,0.28),-6px_-6px_14px_rgba(255,255,255,0.9)]

          transition-all duration-300

          group-hover:shadow-[4px_4px_10px_rgba(163,174,187,0.18),-4px_-4px_10px_rgba(255,255,255,0.95)]
        "
          >
            <span className="text-lg text-foreground">{role.roleName}</span>

            <p className="text-sm text-muted-foreground text-center">
              {role.roleDescription}
            </p>

            <button
              type="button"
              onClick={() => setActiveRole(role)}
              className="
    group/btn
    flex items-center gap-2
    rounded-xl px-4 py-2
    text-sm text-muted-foreground
    transition-all duration-200
    hover:text-foreground
  "
            >
              <span>انتخاب</span>
              <ChevronLeft
                size={18}
                className="transition-transform duration-200 group-hover/btn:-translate-x-1"
              />
            </button>
          </div>
        </div>
      ))}
    </div>
  );
}
