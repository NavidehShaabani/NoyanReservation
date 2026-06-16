"use client";
import { SyntheticEvent } from "react";

export async function handleLogin(
  e: SyntheticEvent,
  phone: string,
  pass: string,
) {
  e.preventDefault();

  const res = await fetch("/api/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ phone, pass }),
  });

  const data = await res.json();

  if (!res.ok) {
    if (res.status === 401) throw new Error("unauthorized");
    if (res.status === 403) throw new Error("not_verified");
    throw new Error(data.message || "login_failed");
  }

  // ذخیره توکن در localStorage
  localStorage.setItem("auth_token", data.token);

  return { role: data.role };
}
