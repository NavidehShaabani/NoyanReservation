"use client";

import { useTranslations } from "next-intl";
export default function Home() {
  const t = useTranslations("login");
  return (
    <div className="bg-red-950 min-h-screen flex items-center justify-center p-x-4 sm:p-x-8 ">
      <div
        className="w-full h-screen lg:w-3/5 bg-gradient-to-b from-[#0C6D3F] to-[#16D37B]  backdrop-blur-xl shadow-2xl p-8 sm:p-10 border border-white/30    
       relative   overflow-hidden   "
      >
        <div className="absolute top-0 left-0 w-[30%] aspect-square">
          <div
            className="w-full h-full bg-[#FFFDFD] opacity-10"
            style={{ clipPath: "polygon(0 0, 100% 0, 0 100%)" }}
          ></div>
        </div>
        {/* //////////////////////////////////////// */}

        {/* لوزی - نصفش از راست بیرون زده */}
        <div className="absolute top-1/2 left-0 md:left-1/4    -translate-y-1/2 w-[160%] max-w-[800px] aspect-square">
          {/* خود لوزی با clip-path */}
          <div
            className="w-full h-full bg-white/10 backdrop-blur-xl border border-white/20 shadow-2xl
                              flex items-center justify-end pl-[20%] md:pl-[30%] p-6 sm:p-8 md:p-10"
            style={{ clipPath: "polygon(50% 0%, 100% 50%, 50% 100%, 0% 50%)" }}
          >
            {/* محتوا */}
            <div className="w-[50%] md:w-[70%] max-w-xs sm:max-w-sm md:max-w-md space-y-3 sm:space-y-4 pl-0 sm:p-4  justify-start">
              <h2 className="text-xl sm:text-2xl md:text-3xl font-bold text-white text-center">
                {t("title")}
              </h2>

              <input
                type="text"
                placeholder={t("username")}
                className="w-full px-3 sm:px-4 py-2.5 sm:py-3 bg-white/10 border border-white/20 rounded-xl text-white placeholder-white/60 focus:outline-none focus:ring-2 focus:ring-white/50 text-sm sm:text-base"
              />

              <input
                type="password"
                placeholder={t("password")}
                className="w-full px-3 sm:px-4 py-2.5 sm:py-3 bg-white/10 border border-white/20 rounded-xl text-white placeholder-white/60 focus:outline-none focus:ring-2 focus:ring-white/50 text-sm sm:text-base"
              />

              <button className="w-full py-2.5 sm:py-3 bg-white text-[#0C6D3F] rounded-xl font-semibold hover:shadow-lg transition text-sm sm:text-base">
                {t("submit")}
              </button>
            </div>
          </div>
        </div>

        {/* ///////////////////////////////////////// */}
      </div>
    </div>
  );
}
