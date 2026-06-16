import { NextRequest, NextResponse } from "next/server";
import { getUnverifiedUsers, verifyUser, deleteUser } from "@/models/user";
import { verifyToken } from "@/lib/jwt";

// تابع کمکی برای استخراج توکن از هدر
function getTokenFromHeader(req: NextRequest): string | null {
  const authHeader = req.headers.get("authorization");
  if (!authHeader || !authHeader.startsWith("Bearer ")) return null;
  return authHeader.split(" ")[1];
}

export async function GET(req: NextRequest) {
  const token = getTokenFromHeader(req);
  if (!token) {
    return NextResponse.json({ error: "Unauthorized" }, { status: 401 });
  }

  const payload = await verifyToken(token);
  if (!payload || payload.role !== "admin") {
    return NextResponse.json({ error: "Forbidden" }, { status: 403 });
  }

  const users = await getUnverifiedUsers();
  return NextResponse.json(users);
}

export async function POST(req: NextRequest) {
  const token = getTokenFromHeader(req);
  if (!token) {
    return NextResponse.json({ error: "Unauthorized" }, { status: 401 });
  }

  const payload = await verifyToken(token);
  if (!payload || payload.role !== "admin") {
    return NextResponse.json({ error: "Forbidden" }, { status: 403 });
  }

  const { userId, action } = await req.json();
  if (action === "verify") {
    const user = await verifyUser(userId);
    return NextResponse.json({ success: true, user });
  } else if (action === "reject") {
    await deleteUser(userId);
    return NextResponse.json({ success: true });
  }
  return NextResponse.json({ error: "Invalid action" }, { status: 400 });
}

// import { NextRequest, NextResponse } from "next/server";
// import { getUnverifiedUsers, verifyUser, deleteUser } from "@/models/user";
// import { verifyToken } from "@/lib/jwt";
// import { cookies } from "next/headers";
// //import { error } from "console";

// export async function GET(req: NextRequest) {
//   try {
//     const cookieStore = await cookies();
//     const token = cookieStore.get("auth_token")?.value;
//     if (!token)
//       return NextResponse.json({ error: "Unauthorized" }, { status: 401 });

//     const payload = await verifyToken(token);
//     if (!payload || payload.role !== "admin") {
//       return NextResponse.json({ error: "Forbidden" }, { status: 403 });
//     }

//     const users = await getUnverifiedUsers();
//     return NextResponse.json(users);
//   } catch (error) {
//     return NextResponse.json(
//       { success: false, message: "خطا در بارگزاری اطلاعات" },
//       {},
//     );
//   }
// }

// export async function POST(req: NextRequest) {
//   const cookieStore = await cookies();
//   const token = cookieStore.get("auth_token")?.value;
//   if (!token)
//     return NextResponse.json({ error: "Unauthorized" }, { status: 403 });

//   const payLoad = await verifyToken(token);
//   if (!payLoad || payLoad.role !== "admin") {
//     return NextResponse.json({ error: "Forbidden" }, { status: 403 });
//   }
//   const { userId, action } = await req.json();
//   if (action == "verify") {
//     const user = await verifyUser(userId);
//     return NextResponse.json({ success: true, user });
//   } else if (action == "reject") {
//     const ret = await deleteUser(userId);
//     if (ret) {
//       return NextResponse.json({ success: true });
//     } else {
//       return NextResponse.json({ error: "nut rejected" }, { status: 400 });
//     }
//   }
//   return NextResponse.json({ error: "Invalid action" }, { status: 400 });
// }
