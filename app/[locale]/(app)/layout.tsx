// "use client";
// import Header from "@/components/custom/Header";
// import AppSidebar from "@/components/custom/AppSidebar";
// import { AuthContext } from "@/context/AuthProvider";
// import { useContext } from "react";
// import { SidebarProvider } from "@/components/ui/sidebar";
// export default function AppLayout({ children }: { children: React.ReactNode }) {
//   return (
//     <div
//       className="
//         min-h-screen
//        bg-contain
//     bg-no-repeat
//     bg-top
//     md:bg-cover
//     md:bg-center
//       "
//       style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
//     >
//       <div
//         className="
//           min-h-screen
//           bg-white/20
//           backdrop-blur-xl
//           backdrop-saturate-150
//           flex flex-row
//         "
//       >
//         <div className="w-full ">
//           <SidebarProvider>
//             <AppSidebar />

//             <main className="w-full min-h-svh flex flex-col">
//               <Header />
//               {children}
//             </main>
//           </SidebarProvider>
//         </div>
//       </div>
//     </div>
//   );
// }

"use client";
import Header from "@/components/custom/Header";
import AppSidebar from "@/components/custom/AppSidebar";
import { AuthContext } from "@/context/AuthProvider";
import { useContext } from "react";
import { SidebarProvider } from "@/components/ui/sidebar";
import BackgroundShell from "@/components/custom/BackgroundShell";
export default function AppLayout({ children }: { children: React.ReactNode }) {
  return (
    <BackgroundShell
      className="h-dvh overflow-hidden"
      overlayClassName="flex h-full overflow-hidden"
    >
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
    </BackgroundShell>
  );

  // return (
  //   <div
  //     className="h-dvh overflow-hidden bg-contain bg-no-repeat bg-top md:bg-cover md:bg-center"
  //     style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
  //   >
  //     <div className="flex h-full overflow-hidden bg-white/20 backdrop-blur-xl backdrop-saturate-150">
  //       <div className="flex min-h-0 w-full">
  //         <SidebarProvider className="h-full min-h-0">
  //           <AppSidebar />

  //           <main className="flex h-full min-h-0 min-w-0 flex-1 flex-col overflow-hidden">
  //             <div className="shrink-0">
  //               <Header />
  //             </div>

  //             <div className="flex min-h-0 flex-1 flex-col">{children}</div>
  //           </main>
  //         </SidebarProvider>
  //       </div>
  //     </div>
  //   </div>
  // );
}
