// import { useTranslations } from "next-intl";

// export default function Header() {
//   const t = useTranslations("header");

//   return (
//     <header
//       className="
//         max-w-6xl
//         mx-auto
//         px-4
//         py-4

//         bg-white/25
//         backdrop-blur-xl
//         backdrop-saturate-150

//         border
//         border-white/40

//         rounded-2xl
//       "
//     >
//       <div className="flex flex-col items-center gap-2 sm:flex-row sm:items-center sm:gap-3">
//         <div
//           className="w-16 h-16 shrink-0 bg-primary"
//           style={{
//             maskImage: "url('/images/NOYAN.svg')",
//             maskRepeat: "no-repeat",
//             maskPosition: "center",
//             maskSize: "contain",
//           }}
//         />

//         <div className="text-sm text-muted-foreground">
//           {t("headerDescription")}
//         </div>
//       </div>
//     </header>
//   );
// }

import { useTranslations } from "next-intl";

export default function Header() {
  const t = useTranslations("header");

  return (
    <header
      className="
      
        px-4
        py-2
        mx-2 md:ms-0

        my-2
       bg-background/30
    backdrop-blur-lg
    backdrop-saturate-150

        border
        border-white/20

        rounded-[10px]
      "
    >
      <div className="flex flex-col items-center gap-2 sm:flex-row sm:items-center sm:gap-3">
        <div
          className="w-16 h-16 shrink-0 bg-primary"
          style={{
            maskImage: "url('/images/NOYAN.svg')",
            maskRepeat: "no-repeat",
            maskPosition: "center",
            maskSize: "contain",
          }}
        />

        <div className="text-sm text-muted-foreground">
          {t("headerDescription")}
        </div>
      </div>
    </header>
  );
}
