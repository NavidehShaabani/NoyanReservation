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
    console.log("for testttttt", token);
  }, [token]);
  return (
    <AuthContext.Provider
      value={{ token, setToken, user, setUser, activeRole, setActiveRole }}
    >
      {children}
    </AuthContext.Provider>
  );
}
