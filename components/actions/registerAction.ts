// components/actions/registerAction.ts
"use client";
import { SyntheticEvent } from "react";
export async function handleRegisterSubmit(
  e: SyntheticEvent<HTMLFormElement>, // any, //React.FormEvent<HTMLFormElement>,
  phone: string,
  unitNumber: string,
  lastName: string,
  setMessage: (msg: string) => void,
  setIsLoading: (loading: boolean) => void,
  router: any,
) {
  e.preventDefault();
  setIsLoading(true);
  setMessage("");

  try {
    const res = await fetch("/api/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ phone, unitNumber, lastName }),
    });

    const data = await res.json();

    if (res.ok && data.success) {
      setMessage(data.message);
      setTimeout(() => router.push("/login"), 2000);
    } else {
      setMessage(data.message || "خطایی رخ داد");
    }
  } catch (error) {
    setMessage(" خطای شبکه یا سرور");
  } finally {
    setIsLoading(false);
  }
}
