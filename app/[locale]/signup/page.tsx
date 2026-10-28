"use client";
import { useState, useEffect, useContext } from "react";
import GeoSelector from "@/components/custom/GeoSelector";
import { useTranslations } from "next-intl";
import {
  Field,
  FieldDescription,
  FieldContent,
  FieldTitle,
  FieldError,
  FieldGroup,
  FieldLabel,
} from "@/components/ui/field";
import { RadioGroup, RadioGroupItem } from "@/components/ui/radio-group";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

export default function Signup() {
  const t = useTranslations("login");
  const t_header = useTranslations("header");
  const [geoId, setGeoId] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [submitted, setSubmitted] = useState(false);
  return (
    <div
      className="h-dvh overflow-hidden bg-contain bg-no-repeat bg-top md:bg-cover md:bg-center"
      style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
    >
      <div className="flex h-full overflow-hidden bg-white/20 backdrop-blur-xl backdrop-saturate-150">
        <div
          className="
            m-2 md:m-10 md:mx-20  flex min-h-0 flex-1 flex-col
        "
        >
          <div
            className="
           flex min-h-0 w-full max-w-10xl flex-1 flex-col
  overflow-y-auto page-scrollbar rounded-[10px] bg-background
  p-8 shadow-[16px_16px_32px_rgba(209,207,204,0.55)] md:p-12 gap-y-4
   
          "
          >
            <div
              className="w-16 h-16 shrink-0 bg-primary"
              style={{
                maskImage: "url('/images/NOYAN.svg')",
                maskRepeat: "no-repeat",
                maskPosition: "center",
                maskSize: "contain",
              }}
            />
            <div className="text-sm text-muted-foreground mb-4">
              {t_header("headerDescription")}
            </div>

            <div className="flex flex-row justify-between gap-4 ">
              <div
                className="   rounded-[10px]
            bg-background
              shadow-[inset_5px_5px_11px_#d6d4d1,inset_-5px_-5px_11px_#ffffff] p-4 sm:p-6 md:p-10"
              >
                <FieldGroup className="gap-2">
                  {/* <Field data-invalid={submitted && !username.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-username"
                      className="text-foreground"
                    >
                      {t("username")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-username"
                      placeholder={t("username")}
                      value={username}
                      aria-invalid={submitted && !username.trim()}
                      onChange={(e) => {
                        setUsername(e.target.value);
                      }}
                      className={`    ${submitted && !username.trim() ? "border-destructive" : ""} 
                                


                                
       border-none
      rounded-[7px]  
    bg-surface
   shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
 
   focus-visible:ring-1
   focus-visible:ring-primary/30  


                                `}
                    />
                  </Field>
                </FieldGroup>

                <RadioGroup defaultValue="plus" className="max-w-sm">
                  <FieldLabel htmlFor="plus-plan">
                    <Field orientation="horizontal">
                      <FieldContent>
                        <FieldTitle>Plus</FieldTitle>
                        <FieldDescription>
                          For individuals and small teams.
                        </FieldDescription>
                      </FieldContent>
                      <RadioGroupItem value="plus" id="plus-plan" />
                    </Field>
                  </FieldLabel>
                  <FieldLabel htmlFor="pro-plan">
                    <Field orientation="horizontal">
                      <FieldContent>
                        <FieldTitle>Pro</FieldTitle>
                        <FieldDescription>
                          For growing businesses.
                        </FieldDescription>
                      </FieldContent>
                      <RadioGroupItem value="pro" id="pro-plan" />
                    </Field>
                  </FieldLabel>
                  <FieldLabel htmlFor="enterprise-plan">
                    <Field orientation="horizontal">
                      <FieldContent>
                        <FieldTitle>Enterprise</FieldTitle>
                        <FieldDescription>
                          For large teams and enterprises.
                        </FieldDescription>
                      </FieldContent>
                      <RadioGroupItem value="enterprise" id="enterprise-plan" />
                    </Field>
                  </FieldLabel>
                </RadioGroup>
              </div>
              <div
                className=" flex-1   rounded-[10px]
            bg-background
              shadow-[inset_5px_5px_11px_#d6d4d1,inset_-5px_-5px_11px_#ffffff] p-4 sm:p-6 md:p-10"
              >
                <FieldGroup className="gap-2">
                  {/* <Field data-invalid={submitted && !username.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-username"
                      className="text-foreground"
                    >
                      {t("username")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-username"
                      placeholder={t("username")}
                      value={username}
                      aria-invalid={submitted && !username.trim()}
                      onChange={(e) => {
                        setUsername(e.target.value);
                      }}
                      className={`    ${submitted && !username.trim() ? "border-destructive" : ""} 
                                


                                
       border-none
      rounded-[7px]  
    bg-surface
   shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
 
   focus-visible:ring-1
   focus-visible:ring-primary/30  


                                `}
                    />
                  </Field>
                  {/* <Field data-invalid={submitted && !password.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-password"
                      className="text-foreground"
                    >
                      {t("password")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-password"
                      placeholder={t("password")}
                      type="password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      className={`
                            md:bg-transparent" ${submitted && !password.trim() ? "border-destructive" : ""}
                                
                                
                                
       border-none
      rounded-[7px]  
    bg-surface
   shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
   focus-visible:ring-1
   focus-visible:ring-primary/30       
                                
                                
                                `}
                    />
                  </Field>
                  {/* <Field orientation="horizontal"> */}

                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-password"
                      className="text-foreground"
                    >
                      {t("password")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-password"
                      placeholder={t("password")}
                      type="password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      className={`
                            md:bg-transparent" ${submitted && !password.trim() ? "border-destructive" : ""}
                                
                                
                                
       border-none
      rounded-[7px]  
    bg-surface
   shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
   focus-visible:ring-1
   focus-visible:ring-primary/30       
                                
                                
                                `}
                    />
                  </Field>

                  {/* </Field> */}
                </FieldGroup>
              </div>
            </div>

            <GeoSelector geoId={geoId} onGeoIdChange={setGeoId} />
          </div>
        </div>
      </div>
    </div>
  );
}
