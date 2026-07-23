const nextConfig = {
  reactStrictMode: true,
  turbopack: {},

  //output: "export", // ← این خط باعث میشه خروجی استاتیک بگیریم برای تنظیمات Netlify
  images: {
    unoptimized: true, // برای Netlify لازمه
  },
};

module.exports = nextConfig;
