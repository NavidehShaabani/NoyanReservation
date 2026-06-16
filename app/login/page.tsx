"use client";
import { useState } from "react";
import { useRouter } from "next/navigation";
import { handleLogin } from "@/components/actions/loginAction";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { PasswordInput } from "@/components/custom/password-input";

export default function LoginPage() {
  const router = useRouter();
  const [phone, setPhone] = useState("");
  const [pass, setPass] = useState("");
  const [message, setMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const onSubmit = async (e: React.SyntheticEvent) => {
    e.preventDefault();
    setIsLoading(true);
    setMessage("");

    try {
      const { role } = await handleLogin(e, phone, pass);
      setMessage("✔ ورود موفقیت‌آمیز بود");
      if (role === "admin") {
        setTimeout(() => router.push("/admin"), 1000);
      } else {
        setTimeout(() => router.push("/dashboard"), 1000);
      }
    } catch (err: any) {
      if (err.message === "not_verified") {
        setMessage("❌ حساب کاربری شما هنوز تأیید نشده است");
      } else if (err.message === "unauthorized") {
        setMessage("❌ شماره تلفن یا رمز عبور معتبر نیست");
      } else {
        setMessage("❌ خطا در ورود به سیستم");
      }
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div
      className="flex items-center justify-center min-h-screen bg-gray-100 p-4"
      dir="rtl"
    >
      <Card className="w-full max-w-md">
        <CardHeader>
          <CardTitle className="text-2xl text-center">
            ورود به سامانه برج
          </CardTitle>
        </CardHeader>
        <CardContent>
          <form onSubmit={onSubmit} className="space-y-4">
            <div>
              <label className="block text-sm font-medium mb-1">
                شماره تلفن همراه
              </label>
              <Input
                type="tel"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
                placeholder="مثال: 09123456789"
                required
              />
            </div>
            <div className="space-y-2">
              <label htmlFor="pass">کلمه عبور </label>

              <PasswordInput
                id="pass"
                value={pass}
                onChange={(e) => setPass(e.target.value)}
                placeholder="کلمه عبور را وارد کنید"
                required
                dir="ltr"
              />
            </div>
            <Button type="submit" disabled={isLoading} className="w-full">
              {isLoading ? "در حال ورود..." : "ورود"}
            </Button>
            {message && (
              <p
                className={`text-center text-sm mt-2 ${message.includes("✔") ? "text-green-600" : "text-red-600"}`}
              >
                {message}
              </p>
            )}
          </form>
          <div className="text-center mt-4 text-sm text-gray-600">
            ثبت‌نام نکرده‌اید؟{" "}
            <button
              onClick={() => router.push("/register")}
              className="text-blue-600 hover:underline"
            >
              ثبت‌نام
            </button>
          </div>
        </CardContent>
      </Card>
    </div>
  );
}
