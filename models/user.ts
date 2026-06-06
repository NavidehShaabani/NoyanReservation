import { query } from "@/lib/db";
import { promises } from "dns";

// نوع داده‌ی کاربر (برای خروجی‌ها)
export type User = {
  id: number;
  phone: string;
  unit_number: string;
  last_name: string;
  is_verified: boolean;
  role: string;
  created_at: Date;
  pass: string;
};

// ایجاد کاربر جدید – برگرداندن کاربر ساخته شده
export async function createUser(
  phone: string,
  unitNumber: string,
  lastName: string,
  hashedPassword: string,
): Promise<User> {
  const result = await query(
    "INSERT INTO users (phone, unit_number, last_name,pass) VALUES ($1, $2, $3,$4) RETURNING *",
    [phone, unitNumber, lastName, hashedPassword],
  );
  return result.rows[0] as User;
}

// پیدا کردن کاربر با شماره تلفن – برگرداندن کاربر یا null
export async function findUserByPhone(phone: string): Promise<User | null> {
  const result = await query("SELECT * FROM users WHERE phone = $1", [phone]);
  return result.rows[0] || null;
}
// // گرفتن همه کاربران تأیید نشده
export async function getUnverifiedUsers(): Promise<User[]> {
  const result = await query(
    "SELECT * FROM users WHERE is_verified=false ORDER BY created_at ASC ",
  );
  return result.rows as User[];
}

export async function verifyUser(userId: number): Promise<User | null> {
  const result = await query(
    "UPDATE users SET is_verified=true WHERE id=$1 RETURNING",
    [userId],
  );
  return result.rows[0] || null;
}

export async function deleteUser(userId: number): Promise<boolean> {
  const result = await query("DELETE FROM users WHERE id = $1", [userId]);
  return (result.rowCount ?? 0) > 0;
}
