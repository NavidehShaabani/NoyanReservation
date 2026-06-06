//با localstorage
import { NextRequest, NextResponse } from "next/server";
import { findUserByPhone } from "@/models/user";
import { createToken } from "@/lib/jwt";

export async function POST(req: NextRequest) {
  try {
    const { phone } = await req.json();

    if (!phone) {
      return NextResponse.json(
        { success: false, message: "شماره تلفن الزامی است" },
        { status: 400 },
      );
    }

    const user = await findUserByPhone(phone);

    if (!user) {
      return NextResponse.json(
        { success: false, message: "کاربری با این شماره یافت نشد" },
        { status: 404 },
      );
    }

    if (!user.is_verified) {
      return NextResponse.json(
        { success: false, message: "حساب کاربری شما هنوز تأیید نشده است" },
        { status: 403 },
      );
    }

    // ساخت توکن JWT
    const token = await createToken(user.id, user.phone, user.role);

    // فقط توکن را برگردان (هیچ کوکی)
    return NextResponse.json({
      success: true,
      message: "ورود موفقیت‌آمیز بود",
      token,
      role: user.role,
    });
  } catch (error) {
    console.error(error);
    return NextResponse.json(
      { success: false, message: "خطای داخلی سرور" },
      { status: 500 },
    );
  }
}

//با کوکی

// import { NextRequest, NextResponse } from "next/server";
// import { findUserByPhone } from "@/models/user";
// import { createToken } from "@/lib/jwt";

// export async function POST(req: NextRequest) {
//   try {
//     const { phone } = await req.json();

//     if (!phone) {
//       return NextResponse.json(
//         { success: false, message: "شماره تلفن الزامی است" },
//         { status: 400 },
//       );
//     }

//     const user = await findUserByPhone(phone);

//     if (!user) {
//       return NextResponse.json(
//         { success: false, message: "کاربری با این شماره یافت نشد" },
//         { status: 404 },
//       );
//     }

//     if (!user.is_verified) {
//       return NextResponse.json(
//         { success: false, message: "حساب کاربری شما هنوز تأیید نشده است" },
//         { status: 403 },
//       );
//     }

//     // ساخت توکن JWT
//     const token = await createToken(user.id, user.phone, user.role);

//     // ذخیره توکن در کوکی httpOnly (برای مرحله فعلی)
//     const response = NextResponse.json({
//       success: true,
//       message: "ورود موفقیت‌آمیز بود",
//       role: user.role,
//     });

//     response.cookies.set("auth_token", token, {
//       httpOnly: true,
//       secure: process.env.NODE_ENV === "production",
//       maxAge: 7 * 24 * 60 * 60, // 7 روز
//       path: "/",
//       sameSite: "lax",
//     });

//     return response;
//   } catch (error) {
//     console.error(error);
//     return NextResponse.json(
//       { success: false, message: "خطای داخلی سرور" },
//       { status: 500 },
//     );
//   }
// }
