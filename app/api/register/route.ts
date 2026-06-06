import { NextRequest, NextResponse } from "next/server";
import { createUser, findUserByPhone } from "@/models/user";

export async function POST(req: NextRequest) {
  try {
    const { phone, unitNumber, lastName } = await req.json();

    //اعنبار سنجی
    if (!phone || !unitNumber || !lastName) {
      return NextResponse.json(
        { success: false, message: "خطا تمام فیلدها الزامی هستند" },
        { status: 400 },
      );
    }

    //تکراری نبودن
    const existing = await findUserByPhone(phone);
    if (existing) {
      return NextResponse.json(
        { success: false, message: "خطا : این شماره قبلاً ثبت شده " },
        { status: 400 },
      );
    }

    const newUser = await createUser(phone, unitNumber, lastName);
    return NextResponse.json({
      success: true,
      message: "درخواست ثبت شد. منتظر تأیید مدیر باشید.",
      userId: newUser.id,
    });
  } catch (error) {
    console.error("detail error", error);
    return NextResponse.json(
      { success: false, message: "خطای داخلی سرور" },
      { status: 500 },
    );
  }
}
