"use client";

import { FaGoogle, FaFacebook } from "react-icons/fa";

export default function Home() {
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
                ورود
              </h2>

              <input
                type="text"
                placeholder="نام کاربری"
                className="w-full px-3 sm:px-4 py-2.5 sm:py-3 bg-white/10 border border-white/20 rounded-xl text-white placeholder-white/60 focus:outline-none focus:ring-2 focus:ring-white/50 text-sm sm:text-base"
              />

              <input
                type="password"
                placeholder="رمز عبور"
                className="w-full px-3 sm:px-4 py-2.5 sm:py-3 bg-white/10 border border-white/20 rounded-xl text-white placeholder-white/60 focus:outline-none focus:ring-2 focus:ring-white/50 text-sm sm:text-base"
              />

              <button className="w-full py-2.5 sm:py-3 bg-white text-[#0C6D3F] rounded-xl font-semibold hover:shadow-lg transition text-sm sm:text-base">
                ورود
              </button>
            </div>
          </div>
        </div>

        {/* ///////////////////////////////////////// */}
      </div>
    </div>
  );
}

// import { Button } from "@/components/ui/button";
// import {
//   Card,
//   CardContent,
//   CardDescription,
//   CardFooter,
//   CardHeader,
//   CardTitle,
// } from "@/components/ui/card";
// import {
//   Dialog,
//   DialogContent,
//   DialogDescription,
//   DialogHeader,
//   DialogTitle,
//   DialogTrigger,
// } from "@/components/ui/dialog";
// import {
//   DropdownMenu,
//   DropdownMenuContent,
//   DropdownMenuItem,
//   DropdownMenuLabel,
//   DropdownMenuSeparator,
//   DropdownMenuTrigger,
// } from "@/components/ui/dropdown-menu";
// import { Input } from "@/components/ui/input";
// import {
//   Sheet,
//   SheetContent,
//   SheetDescription,
//   SheetHeader,
//   SheetTitle,
//   SheetTrigger,
// } from "@/components/ui/sheet";
// export default function Home() {
//   return (
//     <main className="flex min-h-screen flex-col items-center justify-center p-24 gap-4">
//       {/* دکمه پیش‌فرض shadcn */}
//       <Button>دکمه معمولی</Button>

//       {/* دکمه با واریانت‌های مختلف */}
//       <Button variant="destructive">حذف</Button>
//       <Button variant="outline">مرور</Button>
//       <Button variant="ghost">بی صدا</Button>
//       <Button variant="link">لینک</Button>

//       {/* دکمه با سایزهای مختلف */}
//       <Button size="lg">بزرگ</Button>
//       <Button size="sm">کوچک</Button>
//       {/* <Card className="w-[350px] "> */}
//       <Card className="w-[350px] shadow-md rounded-xl border border-border bg-card text-card-foreground">
//         <CardHeader>
//           <CardTitle>عنوان کارت</CardTitle>
//           <CardDescription>توضیحات این کارت</CardDescription>
//         </CardHeader>
//         <CardContent>متن اصلی کارت شما اینجاست.</CardContent>
//         <CardFooter>متن پاورقی</CardFooter>
//       </Card>
//       <div className="flex justify-center items-center min-h-screen p-8">
//         <Card className="w-[400px] shadow-lg rounded-2xl border border-gray-200 dark:border-gray-800 bg-card text-card-foreground">
//           <CardHeader className="pb-2">
//             <CardTitle>کارت شاد cn</CardTitle>
//           </CardHeader>
//           <CardContent className="space-y-2">
//             <p>این یک کارت با استایل‌های پیشرفته‌تر است.</p>
//             <p>سایه، حاشیه گرد، و فاصله مناسب دارد.</p>
//           </CardContent>
//         </Card>
//       </div>
//       <Card className="bg-primary text-primary-foreground border-2 border-red-500">
//         <CardHeader>
//           <CardTitle>تست رنگ</CardTitle>
//           <CardDescription>
//             اگر این متن سفید روی پس‌زمینه آبی است، یعنی متغیرها کار می‌کنند
//           </CardDescription>
//         </CardHeader>
//       </Card>

//       <Dialog>
//         <DialogTrigger asChild>
//           <Button>باز کردن</Button>
//         </DialogTrigger>
//         <DialogContent>
//           <DialogHeader>
//             <DialogTitle>عنوان دیالوگ</DialogTitle>
//             <DialogDescription>توضیحات (اختیاری).</DialogDescription>
//           </DialogHeader>
//           <div>محتوای اصلی داخل دیالوگ.</div>
//         </DialogContent>
//       </Dialog>
//       <Dialog>
//         <DialogTrigger asChild>
//           <Button>باز کردن</Button>
//         </DialogTrigger>
//         <DialogContent className="sm:max-w-md shadow-xl border-t-4 border-primary">
//           <DialogHeader>
//             <DialogTitle>تأیید عملیات</DialogTitle>
//             <DialogDescription>
//               آیا از حذف این آیتم مطمئن هستید؟
//             </DialogDescription>
//           </DialogHeader>
//           <div className="flex justify-end gap-2 pt-4">
//             <Button variant="outline">انصراف</Button>
//             <Button variant="destructive">حذف</Button>
//           </div>
//         </DialogContent>
//       </Dialog>
//       <DropdownMenu>
//         <DropdownMenuTrigger asChild>
//           <Button>باز کردن منو</Button>
//         </DropdownMenuTrigger>
//         <DropdownMenuContent className="w-56">
//           <DropdownMenuLabel>اکانت من</DropdownMenuLabel>
//           <DropdownMenuSeparator />
//           <DropdownMenuItem>پروفایل</DropdownMenuItem>
//           <DropdownMenuItem>تنظیمات</DropdownMenuItem>
//           <DropdownMenuItem>خروج</DropdownMenuItem>
//         </DropdownMenuContent>
//       </DropdownMenu>

//       <Input type="email" placeholder="ایمیل خود را وارد کنید" />
//       <Input disabled placeholder="غیر فعال" />

//       <Sheet>
//         <SheetTrigger asChild>
//           <Button>باز کردن شیت</Button>
//         </SheetTrigger>
//         {/* <SheetContent side="right">
//           <SheetHeader>
//             <SheetTitle>عنوان شیت</SheetTitle>
//             <SheetDescription>توضیحات در صورت نیاز.</SheetDescription>
//           </SheetHeader>
//           <div>محتوای داخل شیت.</div>
//         </SheetContent> */}

//         <SheetContent className="[&_.absolute.right-4]:!left-4 [&_.absolute.right-4]:!right-auto">
//           <SheetHeader className="pr-8">
//             {" "}
//             {/* فاصله از راست برای عنوان */}
//             <SheetTitle>عنوان شیت</SheetTitle>
//             <SheetDescription>توضیحات</SheetDescription>
//           </SheetHeader>
//           {/* محتوا */}
//         </SheetContent>
//       </Sheet>
//     </main>
//   );
// }

// // import Image from "next/image";
// // // import { Button } from "@/components/ui/button";
// // // import { Card, CardContent, CardFooter } from "@/components/ui/card";

// // export default function Home() {
// //   return (
// //     <div className="space-y-2  ">
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //       <div className="flex flex-row justify-evenly items-center gap-x-10 gap-y-5 flex-wrap basis-1  h-80">
// //         <div>
// //           <Image
// //             className="object-cover"
// //             alt="main pic"
// //             src="/main.jpg"
// //             width={200}
// //             height={200}
// //           ></Image>
// //         </div>
// //         <div>
// //           <Image
// //             className="object-cover"
// //             alt="main pic"
// //             src="/main.jpg"
// //             width={200}
// //             height={200}
// //           ></Image>
// //         </div>
// //         <div>
// //           <Image
// //             className="object-cover"
// //             alt="main pic"
// //             src="/main.jpg"
// //             width={200}
// //             height={200}
// //           ></Image>
// //         </div>
// //       </div>
// //       <div className="text-base text-pink-400 text font-bold text-right">
// //         this is a test
// //       </div>
// //       <div className="text-base text-pink-400 text font-light text-center tracking-wider border-2 p-4 mx-4 fixed ">
// //         this is a test
// //         <br />
// //         این یک تست است
// //       </div>
// //       <div className="text-xs z-1">this is a test</div>
// //       <div className="text-sm z-2">this is a test</div>
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //       <div className="text-xs">this is a test</div>
// //       <div className="text-sm">this is a test</div>
// //     </div>
// //     // <div className="flex min-h-screen items-center justify-center bg-zinc-50 font-sans dark:bg-black">
// //     //   <main className="flex min-h-screen w-full max-w-3xl flex-col items-center justify-between py-32 px-16 bg-white dark:bg-black sm:items-start">
// //     //     <Image
// //     //       className="dark:invert"
// //     //       src="/next.svg"
// //     //       alt="Next.js logo"
// //     //       width={100}
// //     //       height={20}
// //     //       priority
// //     //     />
// //     //     <div className="flex flex-col items-center gap-6 text-center sm:items-start sm:text-left">
// //     //       <h1 className="max-w-xs text-3xl font-semibold leading-10 tracking-tight text-black dark:text-zinc-50">
// //     //         To get started, edit the page.tsx file.
// //     //       </h1>
// //     //       <p className="max-w-md text-lg leading-8 text-zinc-600 dark:text-zinc-400">
// //     //         Looking for a starting point or more instructions? Head over to{" "}
// //     //         <a
// //     //           href="https://vercel.com/templates?framework=next.js&utm_source=create-next-app&utm_medium=appdir-template-tw&utm_campaign=create-next-app"
// //     //           className="font-medium text-zinc-950 dark:text-zinc-50"
// //     //         >
// //     //           Templates
// //     //         </a>{" "}
// //     //         or the{" "}
// //     //         <a
// //     //           href="https://nextjs.org/learn?utm_source=create-next-app&utm_medium=appdir-template-tw&utm_campaign=create-next-app"
// //     //           className="font-medium text-zinc-950 dark:text-zinc-50"
// //     //         >
// //     //           Learning
// //     //         </a>{" "}
// //     //         center.
// //     //       </p>
// //     //     </div>
// //     //     <div className="flex flex-col gap-4 text-base font-medium sm:flex-row">
// //     //       <a
// //     //         className="flex h-12 w-full items-center justify-center gap-2 rounded-full bg-foreground px-5 text-background transition-colors hover:bg-[#383838] dark:hover:bg-[#ccc] md:w-[158px]"
// //     //         href="https://vercel.com/new?utm_source=create-next-app&utm_medium=appdir-template-tw&utm_campaign=create-next-app"
// //     //         target="_blank"
// //     //         rel="noopener noreferrer"
// //     //       >
// //     //         <Image
// //     //           className="dark:invert"
// //     //           src="/vercel.svg"
// //     //           alt="Vercel logomark"
// //     //           width={16}
// //     //           height={16}
// //     //         />
// //     //         Deploy Now
// //     //       </a>
// //     //       <a
// //     //         className="flex h-12 w-full items-center justify-center rounded-full border border-solid border-black/[.08] px-5 transition-colors hover:border-transparent hover:bg-black/[.04] dark:border-white/[.145] dark:hover:bg-[#1a1a1a] md:w-[158px]"
// //     //         href="https://nextjs.org/docs?utm_source=create-next-app&utm_medium=appdir-template-tw&utm_campaign=create-next-app"
// //     //         target="_blank"
// //     //         rel="noopener noreferrer"
// //     //       >
// //     //         Documentation
// //     //       </a>
// //     //     </div>
// //     //     <div>
// //     //     </div>
// //     //   </main>
// //     // </div>
// //   );
// // }
