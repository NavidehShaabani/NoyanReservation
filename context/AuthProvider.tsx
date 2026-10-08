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
};
type AuthContextType = {
  token: string | null;
  setToken: React.Dispatch<React.SetStateAction<string | null>>;
  user: User | null;
  setUser: React.Dispatch<React.SetStateAction<User | null>>;
  activeRole: Role | null;
  setActiveRole: React.Dispatch<React.SetStateAction<Role | null>>;
};

export const AuthContext = createContext<AuthContextType>({
  token: null,
  setToken: () => {},
  user: null,
  setUser: () => {},
  activeRole: null,
  setActiveRole: () => {},
});

export default function AuthProvider({
  children,
}: {
  children: React.ReactNode;
}) {
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<User | null>(null);
  const [activeRole, setActiveRole] = useState<Role | null>(null);
  useEffect(() => {
    async function callRefresh() {
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
      const reloadUserInfoResponse = await fetch(
        "http://10.208.8.91:5295/api/Auth/ReloadUserInfo",
        {
          method: "GET",
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        },
      );
      if (!reloadUserInfoResponse.ok) {
        return;
      }

      const userInfoData = await reloadUserInfoResponse.json();

      setToken(accessToken);
      setUser(userInfoData.user);
    }
    callRefresh();

    // console.log("for testttttt", token);
  }, []);
  return (
    <AuthContext.Provider
      value={{ token, setToken, user, setUser, activeRole, setActiveRole }}
    >
      {children}
    </AuthContext.Provider>
  );
}
