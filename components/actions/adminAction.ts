"use client";
import { SyntheticEvent } from "react";
// export async function handleVerifyUser(
//   e: SyntheticEvent,
//   userId: number,
//   onSuccess: () => void,
// ) {
//   e.preventDefault();
//   const res = await fetch("/api/admin/users", {
//     method: "POST",
//     headers: { "Content-Type": "applicatin/json" },
//     body: JSON.stringify({ userId, action: "verify" }),
//   });
//   if (res.ok) onSuccess();
// }

export async function handleVerifyUser(e: SyntheticEvent, userId: number) {
  e.preventDefault();
  const res = await fetch("/api/admin/users", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ userId, action: "verify" }),
  });

  if (!res.ok) {
    if (res.status === 401) throw new Error("login_required");
    if (res.status === 403) throw new Error("forbidden");
    throw new Error("verify_failed");
  }

  return res.json(); // ← برگرداندن نتیجه
}

// export async function handleRejectUser(
//   e: SyntheticEvent,
//   userId: number,
//   onSuccess: () => void,
// ) {
//   e.preventDefault();
//   const res = await fetch("/api/admin/users", {
//     method: "POST",
//     headers: { "cotent-Type": "application/json" },
//     body: JSON.stringify({ userId, action: "reject" }),
//   });
//   if (res.ok) onSuccess();
// }

export async function handleRejectUser(e: SyntheticEvent, userId: number) {
  e.preventDefault();
  const res = await fetch("/api/admin/users", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ userId, action: "reject" }),
  });

  if (!res.ok) {
    if (res.status === 401) throw new Error("login_required");
    if (res.status === 403) throw new Error("forbidden");
    throw new Error("reject_failed");
  }

  return res.json();
}

export async function getUnverifiedUsers() {
  const res = await fetch("/api/admin/users");
  if (!res.ok) {
    if (res.status === 401) throw new Error("login_required");
    throw new Error("fetch_failed");
  }
  return res.json();
}
