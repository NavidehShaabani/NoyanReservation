//tower prog

import { Pool } from "pg";

const pool = new Pool({
  connectionString: process.env.DATABASE_URL,
});

export const query = (
  text: string,
  params?: (string | number | boolean | null)[],
) => pool.query(text, params);

// export async function query(text: string, params?: any[]) {
//   const res = await pool.query(text, params);
//   return res;
// }
