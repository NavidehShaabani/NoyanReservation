"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import { handleRegisterSubmit } from "@/components/actions/registerAction";

// shadcn/ui components
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

export default function RegisterPage() {
  const router = useRouter();
  const [phone, setPhone] = useState("");
  const [unitNumber, setUnitNumber] = useState("");
  const [lastName, setLastName] = useState("");
  const [message, setMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  return (
    <div
      className="flex items-center justify-center min-h-screen bg-gray-100 p-4"
      dir="rtl"
    >
      <Card className="w-full max-w-md">
        <CardHeader>
          <CardTitle className="text-2xl font-bold text-center">
            ثبت‌نام در سامانه برج
          </CardTitle>
          <CardDescription className="text-center text-gray-500">
            لطفاً اطلاعات خود را وارد کنید
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form
            onSubmit={(e) =>
              handleRegisterSubmit(
                e,
                phone,
                unitNumber,
                lastName,
                setMessage,
                setIsLoading,
                router,
              )
            }
            className="space-y-4"
          >
            <div className="space-y-2">
              <label htmlFor="phone">شماره تلفن همراه</label>
              <Input
                id="phone"
                type="tel"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
                placeholder="مثال: 09123456789"
                required
                dir="ltr" // برای نمایش بهتر اعداد
              />
            </div>
            <div className="space-y-2">
              <label htmlFor="unitNumber">شماره واحد</label>
              <Input
                id="unitNumber"
                type="text"
                value={unitNumber}
                onChange={(e) => setUnitNumber(e.target.value)}
                placeholder="مثال: ۱۲۳"
                required
              />
            </div>
            <div className="space-y-2">
              <label htmlFor="lastName">نام خانوادگی</label>
              <Input
                id="lastName"
                type="text"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
                placeholder="نام خانوادگی خود را وارد کنید"
                required
              />
            </div>
            <Button type="submit" disabled={isLoading} className="w-full">
              {isLoading ? "در حال ثبت‌نام..." : "ثبت‌نام"}
            </Button>
            {message && (
              <p
                className={`text-center text-sm mt-2 ${message.includes("خطا") ? "text-red-600" : "text-green-600"}`}
              >
                {message}
              </p>
            )}
          </form>
        </CardContent>
        <CardFooter className="flex justify-center">
          <div className="text-sm text-gray-600">
            قبلاً ثبت‌نام کرده‌اید؟{" "}
            <Button
              variant="link"
              className="p-0 h-auto text-blue-600 hover:underline"
              onClick={() => router.push("/login")}
            >
              وارد شوید
            </Button>
          </div>
        </CardFooter>
      </Card>
    </div>
  );
}
