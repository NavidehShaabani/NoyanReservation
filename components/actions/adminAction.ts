"use client";
import { SyntheticEvent } from "react";

// تابع کمکی برای گرفتن توکن
function getAuthToken() {
  return localStorage.getItem("auth_token");
}

export async function getUnverifiedUsers() {
  const token = getAuthToken();
  const res = await fetch("/api/admin/users", {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
  if (!res.ok) {
    if (res.status === 401) throw new Error("login_required");
    throw new Error("fetch_failed");
  }
  return res.json();
}

export async function handleVerifyUser(e: SyntheticEvent, userId: number) {
  e.preventDefault();
  const token = getAuthToken();
  const res = await fetch("/api/admin/users", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify({ userId, action: "verify" }),
  });
  if (!res.ok) {
    if (res.status === 401) throw new Error("login_required");
    if (res.status === 403) throw new Error("forbidden");
    throw new Error("verify_failed");
  }
  return res.json();
}

export async function handleRejectUser(e: SyntheticEvent, userId: number) {
  e.preventDefault();
  const token = getAuthToken();
  const res = await fetch("/api/admin/users", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify({ userId, action: "reject" }),
  });
  if (!res.ok) {
    if (res.status === 401) throw new Error("login_required");
    if (res.status === 403) throw new Error("forbidden");
    throw new Error("reject_failed");
  }
  return res.json();
}
