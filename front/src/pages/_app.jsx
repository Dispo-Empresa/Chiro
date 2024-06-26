import { useRouter } from "next/router";
import { useLayoutEffect } from "react";
import NextNProgress from "nextjs-progressbar";

import { getCookie } from "@/data/cookies";
import cookiesKeys from "@/data/keys";

export default function App({ Component, pageProps }) {
  const router = useRouter();

  useLayoutEffect(() => {
    const isAuth = getCookie(cookiesKeys.token) != undefined;
    if (!isAuth) {
      router.push("/auth");
    }
  }, []);

  return (
    <>
      <NextNProgress />
      <Component {...pageProps} />
    </>
  );
}
