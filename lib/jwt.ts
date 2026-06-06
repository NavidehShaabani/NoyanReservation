import { SignJWT, jwtVerify } from "jose";

// ساخت کلید مخفی (همان راز برای امضای توکن)
const secret = new TextEncoder().encode(
  process.env.JWT_SECRET || "my-secret-key",
);

// تابع ساخت توکن
export async function createToken(userId: number, phone: string, role: string) {
  const token = await new SignJWT({ userId, phone, role })
    .setProtectedHeader({ alg: "HS256" })
    .setExpirationTime("7d")
    .sign(secret);
  return token;
}

// تابع بررسی توکن
export async function verifyToken(token: string) {
  try {
    const { payload } = await jwtVerify(token, secret);
    return payload;
  } catch (error) {
    return null;
  }
}
