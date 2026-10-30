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
import LogoHeader from "@/components/custom/LogoHeader";
import PageCard from "@/components/custom/PageCard";
import InsetPanel from "@/components/custom/InsetPanel";
import BackgroundShell from "@/components/custom/BackgroundShell";
import PageHeader from "@/components/custom/PageHeader";
import { UserRoundPlus } from "lucide-react";
export default function Signup() {
  const t_login = useTranslations("login");
  const t = useTranslations("signup");
  const [geoId, setGeoId] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [submitted, setSubmitted] = useState(false);
  return (
    <BackgroundShell
      className="h-dvh overflow-hidden"
      overlayClassName="flex h-full flex-col overflow-hidden pt-2 "
    >
      <div className="mx-2 flex min-h-0 flex-1 flex-col md:mx-20">
        <div className="shrink-0">
          <LogoHeader />
        </div>
        <div className="my-2 flex min-h-0 flex-1 flex-col md:mt-4">
          <PageCard contentClassName="gap-y-4 p-8 md:p-12">
            <PageHeader
              title={t("title")}
              description={t("description")}
              icon={<UserRoundPlus className="size-5" />}
              className="mb-4 "
            />

            <div className="flex flex-row justify-between gap-4 ">
              <InsetPanel className="p-4 sm:p-6 md:p-10">
                <FieldGroup className="gap-2">
                  {/* <Field data-invalid={submitted && !username.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-username"
                      className="text-foreground"
                    >
                      {t_login("username")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-username"
                      placeholder={t_login("username")}
                      value={username}
                      aria-invalid={submitted && !username.trim()}
                      onChange={(e) => {
                        setUsername(e.target.value);
                      }}
                      className={`    
                        ${
                          submitted && !username.trim()
                            ? "border-destructive"
                            : ""
                        }  `}
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
              </InsetPanel>
              <InsetPanel className="p-4 sm:p-6 md:p-10">
                <FieldGroup className="gap-2">
                  {/* <Field data-invalid={submitted && !username.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-username"
                      className="text-foreground"
                    >
                      {t_login("username")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-username"
                      placeholder={t_login("username")}
                      value={username}
                      aria-invalid={submitted && !username.trim()}
                      onChange={(e) => {
                        setUsername(e.target.value);
                      }}
                      className={`    ${submitted && !username.trim() ? "border-destructive" : ""} 
                                
 `}
                    />
                  </Field>
                  {/* <Field data-invalid={submitted && !password.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-password"
                      className="text-foreground"
                    >
                      {t_login("password")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-password"
                      placeholder={t_login("password")}
                      type="password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      className={`
                            md:bg-transparent" ${submitted && !password.trim() ? "border-destructive" : ""}
                                
     
                                
                                
                                `}
                    />
                  </Field>
                  {/* <Field orientation="horizontal"> */}

                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-password"
                      className="text-foreground"
                    >
                      {t_login("password")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-password"
                      placeholder={t_login("password")}
                      type="password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      className={`
                            md:bg-transparent" ${submitted && !password.trim() ? "border-destructive" : ""}
                                
                                
                                
  
                                
                                
                                `}
                    />
                  </Field>

                  {/* </Field> */}
                </FieldGroup>
              </InsetPanel>
            </div>

            <GeoSelector geoId={geoId} onGeoIdChange={setGeoId} />
          </PageCard>
        </div>
      </div>
    </BackgroundShell>
  );
}
