"use client";
import { useTranslations } from "next-intl";
import {
  Field,
  FieldDescription,
  FieldGroup,
  FieldLabel,
} from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

export default function Login() {
  const t = useTranslations("login");
  const tFooter = useTranslations("footer");
  return (
    <div className=" md:bg-background h-screen flex justify-center items-center">
      <div className="bg-card w-full md:w-[70vw] h-full  md:h-[80vh] rounded-[0px] md:rounded-[5px] flex flex-col md:flex-row overflow-hidden drop-shadow-[0_20px_35px_rgba(0,0,0,0.25)] ">
        <div className="w-full md:w-2/3 h-full bg-card grid grid-rows-10 px-0 md:px-[10%] py-0 md:py-[3%]">
          <div className="row-span-2  bg-background md:bg-card flex justify-center items-center md:justify-start  ">
            <div
              className="w-48 md:w-20 h-20 bg-card md:bg-primary"
              style={{
                maskImage: "url('/images/NOYAN.svg')",
                maskRepeat: "no-repeat",
                maskPosition: "center",
                maskSize: "contain",
              }}
            />
          </div>
          <div
            className="row-span-8 md:row-span-7 flex-row   px-[5%] md:px-0 py-[10%]   bg-[url('/images/main_pic.jpg')]
    bg-contain
    bg-center
    md:bg-none  
    "
          >
            <div
              className="px-[5%] md:px-[0px] pt-[20%] pb-[35%] md:pt-[0px] md:pb-[0px] rounded-[5px] md:rounded-[0px] bg-[rgba(255,255,255,0.15)] md:bg-transparent backdrop-blur-sm md:backdrop-blur-none
            "
            >
              <FieldGroup>
                <Field>
                  <FieldLabel htmlFor="fieldgroup-username">
                    {t("username")}
                  </FieldLabel>
                  <Input
                    id="fieldgroup-username"
                    className=" bg-white/10 border-input md:focus-visible:border-ring
                                md:focus-visible:ring-ring/50 md:bg-transparent"
                  />
                </Field>
                <Field>
                  <FieldLabel htmlFor="fieldgroup-password">
                    {t("password")}
                  </FieldLabel>
                  <Input
                    id="fieldgroup-password"
                    type="password"
                    className=" bg-white/10 border-input md:focus-visible:border-ring
                                md:focus-visible:ring-ring/50 md:bg-transparent"
                  />
                  <FieldDescription></FieldDescription>
                </Field>
                <Field orientation="horizontal">
                  <Button className="w-full " type="submit">
                    {t("submit")}
                  </Button>
                </Field>
              </FieldGroup>
            </div>
            <label className="block md:hidden items-end">
              {" "}
              {tFooter("copyright")}
            </label>
          </div>
          <div className="hidden md:block row-span-1 bg-transparent">
            {tFooter("copyright")}
          </div>
        </div>

        <div
          className="hidden md:block bg-center  w-1/3 bg-cover "
          style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
        ></div>
      </div>
    </div>
  );
}
