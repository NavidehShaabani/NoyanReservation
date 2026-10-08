// // export default function Dashboard() {
// //   return (
// //     <div
// //       className="
// //         min-h-screen
// //         flex
// //         justify-center
// //         items-center
// //         p-4 md:p-8
// //         bg-cover
// //         bg-center
// //       "
// //       style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
// //     >
// //       <div
// //         className="
// //           w-full
// //           max-w-6xl
// //           min-h-[70vh]

// //           rounded-2xl

// //           bg-white/45
// //           backdrop-blur-xl

// //           border border-white/40

// //           shadow-[0_8px_30px_rgba(0,0,0,0.12)]

// //           p-6 md:p-10

// //           flex
// //           flex-col
// //           gap-8
// //         "
// //       >
// //         <div>
// //           <h1 className="text-2xl font-medium text-foreground">Dashboard</h1>

// //           <p className="mt-2 text-sm text-muted-foreground">
// //             Manage your reservations and facilities
// //           </p>
// //         </div>

// //         <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
// //           <div
// //             className="
// //               min-h-40
// //               rounded-2xl

// //               bg-background/70

// //               p-6

// //               shadow-[5px_5px_12px_rgba(163,174,187,0.18),-5px_-5px_12px_rgba(255,255,255,0.75)]

// //               transition-all duration-200

// //               hover:-translate-y-1
// //               hover:shadow-[6px_8px_16px_rgba(163,174,187,0.22),-5px_-5px_14px_rgba(255,255,255,0.8)]
// //             "
// //           >
// //             <div className="flex flex-col justify-between h-full">
// //               <span className="text-sm text-muted-foreground">
// //                 Reservations
// //               </span>

// //               <span className="text-3xl font-medium text-primary">2313</span>

// //               <span className="text-xs text-muted-foreground">
// //                 Total reservations
// //               </span>
// //             </div>
// //           </div>
// //         </div>
// //       </div>
// //     </div>
// //   );
// // }

// export default function Dashboard() {
//   return (
//     <div className="min-h-screen bg-background flex items-center justify-center p-6">
//       <div
//         className="
//           w-full
//           max-w-6xl
//           min-h-[70vh]

//           rounded-[32px]

//           bg-background

//           shadow-[20px_20px_40px_#d1cfcc,-20px_-20px_40px_#ffffff]

//           p-8 md:p-12

//           flex
//           flex-col
//           gap-10
//         "
//       >
//         <div className="text-center">
//           <h1 className="text-2xl font-medium text-foreground">Dashboard</h1>

//           <p className="mt-2 text-sm text-muted-foreground">
//             Manage your reservations and facilities
//           </p>
//         </div>

//         <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
//           <div
//             className="
//               min-h-44

//               rounded-[28px]

//               bg-background

//               p-6

//               shadow-[12px_12px_24px_#d1cfcc,-12px_-12px_24px_#ffffff]

//               flex
//               flex-col
//               justify-between

//               transition-all
//               duration-200

//               hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

//               active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
//             "
//           >
//             <span className="text-sm text-muted-foreground">Reservations</span>

//             <span className="text-4xl font-medium text-primary">2313</span>

//             <span className="text-xs text-muted-foreground">
//               Total reservations
//             </span>
//           </div>

//           <div
//             className="
//               min-h-44
//               rounded-[28px]
//               bg-background
//               p-6

//               shadow-[12px_12px_24px_#d1cfcc,-12px_-12px_24px_#ffffff]

//               flex
//               flex-col
//               justify-between

//               transition-all
//               duration-200

//               hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

//               active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
//             "
//           >
//             <span className="text-sm text-muted-foreground">Facilities</span>

//             <span className="text-4xl font-medium text-primary">12</span>

//             <span className="text-xs text-muted-foreground">
//               Available facilities
//             </span>
//           </div>

//           <div
//             className="
//               min-h-44
//               rounded-[28px]
//               bg-background
//               p-6

//               shadow-[12px_12px_24px_#d1cfcc,-12px_-12px_24px_#ffffff]

//               flex
//               flex-col
//               justify-between

//               transition-all
//               duration-200

//               hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

//               active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
//             "
//           >
//             <span className="text-sm text-muted-foreground">Users</span>

//             <span className="text-4xl font-medium text-primary">48</span>

//             <span className="text-xs text-muted-foreground">
//               Registered users
//             </span>
//           </div>
//         </div>
//       </div>
//     </div>
//   );
// }

export default async function Dashboard() {
  return (
    <div
      className="
           mx-2 md:ms-0
          mb-2
          flex
          flex-1
        
          items-center
        
        "
    >
      <div
        className="
            w-full
            h-full  
            max-w-6xl
          

            rounded-[10px]
            bg-background

            shadow-[16px_16px_32px_rgba(209,207,204,0.55)]
            p-8 md:p-12

            flex
            flex-col
            gap-10
          "
      >
        {/* Header */}
        <div className="text-center">
          <h1 className="text-2xl font-medium text-foreground">Dashboard</h1>

          <p className="mt-2 text-sm text-muted-foreground">
            Manage your reservations and facilities
          </p>
        </div>

        {/* Cards */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {/* Card 1 */}
          <div
            className="
                min-h-44
                rounded-[28px]
                bg-background
                p-6

                shadow-[12px_12px_24px_#d1cfcc,-12px_-12px_24px_#ffffff]

                flex
                flex-col
                justify-between

                transition-all
                duration-200

                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
              "
          >
            <span className="text-sm text-muted-foreground">Reservations</span>

            <span className="text-4xl font-medium text-primary">2313</span>

            <span className="text-xs text-muted-foreground">
              Total reservations
            </span>
          </div>

          {/* Card 2 */}
          <div
            className="
                min-h-44
                rounded-[28px]
                bg-background
                p-6

                shadow-[12px_12px_24px_#d1cfcc,-12px_-12px_24px_#ffffff]

                flex
                flex-col
                justify-between

                transition-all
                duration-200

                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
              "
          >
            <span className="text-sm text-muted-foreground">Facilities</span>

            <span className="text-4xl font-medium text-primary">12</span>

            <span className="text-xs text-muted-foreground">
              Available facilities
            </span>
          </div>

          {/* Card 3 */}
          <div
            className="
                min-h-44
                rounded-[28px]
                bg-background
                p-6

                shadow-[12px_12px_24px_#d1cfcc,-12px_-12px_24px_#ffffff]

                flex
                flex-col
                justify-between

                transition-all
                duration-200

                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
              "
          >
            <span className="text-sm text-muted-foreground">Users</span>

            <span className="text-4xl font-medium text-primary">48</span>

            <span className="text-xs text-muted-foreground">
              Registered users
            </span>
          </div>
        </div>
      </div>
    </div>
  );
}
