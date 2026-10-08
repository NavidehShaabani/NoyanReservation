import { useContext } from "react";
import { AuthContext } from "@/context/AuthProvider";
import { useLocale } from "next-intl";
import {
  Sidebar,
  SidebarContent,
  SidebarGroup,
  SidebarGroupContent,
  SidebarMenu,
  SidebarMenuItem,
  SidebarMenuButton,
  SidebarHeader,
  useSidebar,
} from "../ui/sidebar";
import {
  LayoutDashboard,
  Users,
  StickyNote,
  type LucideIcon,
} from "lucide-react";

type locale = "fa" | "en";
function iconSelector(iconSub: string | null): LucideIcon {
  switch (iconSub) {
    case "dashboard":
      return LayoutDashboard;
    case "users":
      return Users;
    default:
      return StickyNote;
  }
}
export default function AppSidebar() {
  const { user } = useContext(AuthContext);
  const activeRole = user?.roles.find(
    (role) => role.roleId === user.activeRoleId,
  );
  const locale = useLocale() as locale;
  const { setOpenMobile } = useSidebar();
  console.log("map list", activeRole);
  return (
    <>
      <Sidebar side={locale === "fa" ? "right" : "left"} variant="floating">
        <SidebarHeader className="md:hidden border-b">
          <div className="flex items-center justify-between">
            <div className="flex items-center gap-3">
              <div
                className="w-10 h-10 shrink-0 bg-primary"
                style={{
                  maskImage: "url('/images/NOYAN.svg')",
                  maskRepeat: "no-repeat",
                  maskPosition: "center",
                  maskSize: "contain",
                }}
              />

              <span className="text-sm font-medium">Noyan Reservation</span>
            </div>

            <button
              type="button"
              onClick={() => setOpenMobile(false)}
              className="text-3xl "
            >
              ×
            </button>
          </div>
        </SidebarHeader>
        <SidebarContent>
          <SidebarGroup>
            <SidebarGroupContent>
              <SidebarMenu>
                {activeRole?.menus.map((menu) => {
                  const Icon = iconSelector(menu.icon);
                  return (
                    <SidebarMenuItem key={menu.menuId}>
                      <SidebarMenuButton>
                        <Icon />
                        {menu.name[locale]}
                      </SidebarMenuButton>
                    </SidebarMenuItem>
                  );
                })}
              </SidebarMenu>
            </SidebarGroupContent>
          </SidebarGroup>
        </SidebarContent>
      </Sidebar>
    </>
  );
}
