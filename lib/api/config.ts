export const API_BASE_URL = process.env.NEXT_PUBLIC_API_BASE_URL!;

export function apiUrl(endpoint: string) {
  return `${API_BASE_URL}${endpoint.startsWith("/") ? endpoint : `/${endpoint}`}`;
}
