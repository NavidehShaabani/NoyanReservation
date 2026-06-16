"use client";
import { SyntheticEvent } from "react";

export async function handleLogout(e: SyntheticEvent, router: any) {
  e.preventDefault();
  localStorage.removeItem("auth_token");
  router.push("/login");
}
