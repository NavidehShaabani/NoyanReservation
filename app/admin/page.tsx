"use client";
import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Button } from "@/components/ui/button";
import { Alert, AlertDescription } from "@/components/ui/alert";
import {
  handleVerifyUser,
  handleRejectUser,
  getUnverifiedUsers,
} from "@/components/actions/adminAction";

type User = {
  id: number;
  phone: string;
  unit_number: string;
  last_name: string;
  created_at: string;
};

export default function AdminPage() {
  const router = useRouter();
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState(true);
  const [message, setMessage] = useState("");

  //   useEffect(() => {
  //     fetch("/api/admin/users")
  //       .then((res) => {
  //         if (res.status === 401 || res.status === 403) router.push("/login");
  //         return res.json();
  //       })
  //       .then((data) => {
  //         setUsers(data);
  //         setLoading(false);
  //       })
  //       .catch(() => setLoading(false));
  //   }, [router]);

  useEffect(() => {
    getUnverifiedUsers()
      .then(setUsers)
      .catch((err) => {
        if (err.message === "login_required") router.push("/login");
        else setMessage("خطا در دریافت اطلاعات");
      })
      .finally(() => setLoading(false)); // ← حتماً loading را خاموش کن
  }, [router]); // ← اضافه کردن router

  const refresh = () => {
    fetch("/api/admin/users")
      .then((res) => res.json())
      .then(setUsers);
  };

  if (loading) return <div className="p-4 text-center">در حال بارگذاری...</div>;

  return (
    <div className="container mx-auto p-4" dir="rtl">
      <Card>
        <CardHeader>
          <CardTitle>مدیریت کاربران - درخواست‌های تأیید</CardTitle>
        </CardHeader>
        <CardContent>
          {message && (
            <Alert className="mb-4">
              <AlertDescription>{message}</AlertDescription>
            </Alert>
          )}
          {users.length === 0 ? (
            <p>همه کاربران تأیید شده‌اند.</p>
          ) : (
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead>شماره تلفن</TableHead>
                  <TableHead>واحد</TableHead>
                  <TableHead>نام خانوادگی</TableHead>
                  <TableHead>تاریخ درخواست</TableHead>
                  <TableHead>عملیات</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {users.map((user) => (
                  <TableRow key={user.id}>
                    <TableCell>{user.phone}</TableCell>
                    <TableCell>{user.unit_number}</TableCell>
                    <TableCell>{user.last_name}</TableCell>
                    <TableCell>
                      {new Date(user.created_at).toLocaleDateString("fa-IR")}
                    </TableCell>
                    <TableCell className="space-x-2 rtl:space-x-reverse">
                      <Button
                        size="sm"
                        // onClick={async (e) => {
                        //   await handleVerifyUser(e, user.id, () => {
                        //     setMessage(`کاربر ${user.last_name} تأیید شد`);
                        //     refresh();
                        //   });
                        // }}

                        onClick={async (e) => {
                          try {
                            await handleVerifyUser(e, user.id);
                            setMessage(`کاربر ${user.last_name} تأیید شد`);
                            refresh();
                          } catch (err: any) {
                            if (err.message === "login_required")
                              router.push("/login");
                            else setMessage("خطا در تأیید کاربر");
                          }
                        }}
                      >
                        تأیید
                      </Button>
                      <Button
                        size="sm"
                        variant="destructive"
                        // onClick={async (e) => {
                        //   await handleRejectUser(e, user.id, () => {
                        //     setMessage(`کاربر ${user.last_name} رد شد`);
                        //     refresh();
                        //   });
                        //  }}
                        onClick={async (e) => {
                          try {
                            await handleRejectUser(e, user.id);
                            setMessage(`کاربر ${user.last_name} رد شد`);
                            refresh();
                          } catch (err: any) {
                            if (err.message === "login_required")
                              router.push("/login");
                            else setMessage("خطا در رد کاربر");
                          }
                        }}
                      >
                        رد
                      </Button>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          )}
        </CardContent>
      </Card>
    </div>
  );
}
