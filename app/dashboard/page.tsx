"use client";
import { handleLogout } from "@/components/actions/logoutAction";
import { useRouter } from "next/navigation";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
export default function dashboardPage() {
  const router = useRouter();
  return (
    <div
      className="flex items-center justify-center min-h-screen bg-gray-100 p-4"
      dir="rtl"
    >
      <Card className="w-full max-w-md">
        <CardHeader>
          <CardTitle className="text-2xl font-bold text-center">
            داشبورد
          </CardTitle>
          <CardDescription className="text-center text-gray-500"></CardDescription>
        </CardHeader>
        <CardContent>
          <form onSubmit={(e) => handleLogout(e, router)} className="space-y-4">
            <Button type="submit" className="w-full">
              خروج از سیستم
            </Button>
          </form>
        </CardContent>
        <CardFooter className="flex justify-center"></CardFooter>
      </Card>
    </div>
  );
}
