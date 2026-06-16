// public/sw.js
const CACHE_NAME = "tower-pwa-v1";
const urlsToCache = ["/", "/manifest.json", "/login", "/register"];

// نصب Service Worker
self.addEventListener("install", (event) => {
  event.waitUntil(
    caches.open(CACHE_NAME).then((cache) => cache.addAll(urlsToCache)),
  );
});

// دریافت درخواست‌ها
self.addEventListener("fetch", (event) => {
  event.respondWith(
    caches
      .match(event.request)
      .then((response) => response || fetch(event.request)),
  );
});
