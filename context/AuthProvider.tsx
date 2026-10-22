"use client";

import { createContext, useState, useEffect } from "react";

export type localizedText = {
  en: string | null;
  fa: string | null;
};
type Permission = {
  code: number;
  fa: string;
  en: string;
  canRead: boolean;
  canWrite: boolean;
  canDelete: boolean;
};
type Menu = {
  menuId: number;
  roleId: number;
  parentId: number | null;
  name: localizedText;
  menuUrl: string | null;
  icon: string | null;
  sortOrder: number;
  isPermission: boolean;
  permission: Permission;
  children: Menu[];
};
type Role = {
  roleId: number;
  roleCode: string;
  roleName: localizedText;
  roleDescription: localizedText;
  menus: Menu[];
};
type User = {
  userId: number;
  username: string;
  fullName: string | null;
  firstName: string | null;
  lastName: string | null;
  email: string | null;
  mobile: string | null;
  roles: Role[];
  activeRoleId: number | null;
  sessionId: string;
  orgId: number;
};
type AuthContextType = {
  token: string | null;
  setToken: React.Dispatch<React.SetStateAction<string | null>>;
  user: User | null;
  setUser: React.Dispatch<React.SetStateAction<User | null>>;
  isAuthReady: boolean;
};

export const AuthContext = createContext<AuthContextType>({
  token: null,
  setToken: () => {},
  user: null,
  setUser: () => {},
  isAuthReady: false,
});

export default function AuthProvider({
  children,
}: {
  children: React.ReactNode;
}) {
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<User | null>(null);
  const [isAuthReady, setIsAuthReady] = useState(false);

  useEffect(() => {
    async function callRefresh() {
      try {
        const refreshResponse = await fetch(
          "http://10.208.8.91:5295/api/Auth/refresh",
          {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            credentials: "include",
            body: "",
          },
        );

        if (!refreshResponse.ok) {
          return;
        }

        const refreshData = await refreshResponse.json();
        const accessToken = refreshData.accessToken;
        const userInfoResponse = await fetch(
          "http://10.208.8.91:5295/api/Auth/GetUserInfo",
          {
            method: "GET",
            headers: {
              Authorization: `Bearer ${accessToken}`,
            },
          },
        );
        if (!userInfoResponse.ok) {
          return;
        }

        const userInfoData = await userInfoResponse.json();
        console.log("userInfoData:", userInfoData);
        console.log("userInfoData.user:", userInfoData.user);
        setToken(accessToken);
        setUser(userInfoData.user);
      } catch (error) {
        console.error("Failed to initialize authentication:", error);
      } finally {
        setIsAuthReady(true);
      }
    }
    callRefresh();

    // console.log("for testttttt", token);
  }, []);
  return (
    <AuthContext.Provider
      value={{ token, setToken, user, setUser, isAuthReady }}
    >
      {children}
    </AuthContext.Provider>
  );
}
