"use client";
import Header from "@/components/custom/Header";
import AppSidebar from "@/components/custom/AppSidebar";
import AuthGuard from "@/components/custom/AuthGuard";
import { SidebarProvider } from "@/components/ui/sidebar";
import BackgroundShell from "@/components/custom/BackgroundShell";
export default function AppLayout({ children }: { children: React.ReactNode }) {
  return (
    <BackgroundShell
      className="h-dvh overflow-hidden"
      overlayClassName="flex h-full overflow-hidden"
    >
      <AuthGuard>
        <div className="flex min-h-0 w-full">
          <SidebarProvider className="h-full min-h-0">
            <AppSidebar />

            <main className="flex h-full min-h-0 min-w-0 flex-1 flex-col overflow-hidden">
              <div className="shrink-0">
                <Header />
              </div>

              <div className="flex min-h-0 flex-1 flex-col">{children}</div>
            </main>
          </SidebarProvider>
        </div>
      </AuthGuard>
    </BackgroundShell>
  );
}
