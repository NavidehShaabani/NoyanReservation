export const MessageIcons = {
  SUCCESS: "✔",
  ERROR: "❌",
  WARNING: "⚠️",
  INFO: "ℹ️",
} as const;

export type MessageType = "success" | "error" | "warning" | "info";
