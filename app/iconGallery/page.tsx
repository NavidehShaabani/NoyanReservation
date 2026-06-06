"use client";
import React, { useState } from "react";
import * as Icons from "react-icons/lu";

// گرفتن همه نام آیکون‌ها با حذف پیشوند 'Lu'
const allNames = Object.keys(Icons)
  .filter((key) => key.startsWith("Lu") && key !== "Lu")
  .map((key) => key.slice(2)); // مثلاً 'LuHome' => 'Home'

export default function FullIconGallery() {
  const [search, setSearch] = useState("");
  const filtered = allNames.filter((name) =>
    name.toLowerCase().includes(search.toLowerCase()),
  );

  return (
    <div style={{ padding: 20 }}>
      <h1>همه آیکون‌های Lucide ({allNames.length} عدد)</h1>
      <input
        type="text"
        placeholder="جستجو..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        style={{ width: "100%", padding: 8, marginBottom: 20 }}
      />
      <div
        style={{
          display: "grid",
          gridTemplateColumns: "repeat(auto-fill, minmax(90px,1fr))",
          gap: 12,
        }}
      >
        {filtered.map((name) => {
          const Icon = (Icons as any)[`Lu${name}`];
          if (!Icon) return null;
          return (
            <div
              key={name}
              onClick={() => navigator.clipboard.writeText(name)}
              style={{
                textAlign: "center",
                padding: 10,
                border: "1px solid #ddd",
                borderRadius: 8,
                cursor: "pointer",
              }}
            >
              <Icon size={28} />
              <div style={{ fontSize: 11, marginTop: 5 }}>{name}</div>
            </div>
          );
        })}
      </div>
    </div>
  );
}
