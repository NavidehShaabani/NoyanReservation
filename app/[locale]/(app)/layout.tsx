"use client";
import Header from "@/components/custom/Header";
import AppSidebar from "@/components/custom/AppSidebar";
import { AuthContext } from "@/context/AuthProvider";
import { useContext } from "react";
import { SidebarProvider } from "@/components/ui/sidebar";
export default function AppLayout({ children }: { children: React.ReactNode }) {
  const { activeRole } = useContext(AuthContext);
  console.log("activeRole", activeRole);
  console.log("menus", activeRole?.menus);
  return (
    <div
      className="
        min-h-screen
       bg-contain
    bg-no-repeat
    bg-top
    md:bg-cover
    md:bg-center
      "
      style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
    >
      <div
        className="
          min-h-screen
          bg-white/20
          backdrop-blur-xl
          backdrop-saturate-150
          flex flex-row
        "
      >
        <div className="w-full ">
          <SidebarProvider>
            <AppSidebar />

            <main className="w-full min-h-svh flex flex-col">
              <Header />
              {children}
            </main>
          </SidebarProvider>
        </div>
      </div>
    </div>
  );
}
