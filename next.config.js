import createNextIntlPlugin from "next-intl/plugin";

const withNextIntl = createNextIntlPlugin();

const nextConfig = {
  reactStrictMode: true,

  turbopack: {},

  images: {
    unoptimized: true,
  },
};

export default withNextIntl(nextConfig);
