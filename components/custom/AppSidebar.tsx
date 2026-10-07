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
  const { activeRole } = useContext(AuthContext);
  const locale = useLocale() as locale;
  console.log("map list", activeRole);
  return (
    <>
      <Sidebar side={locale === "fa" ? "right" : "left"} variant="floating">
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
