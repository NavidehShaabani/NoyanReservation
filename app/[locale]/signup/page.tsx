"use client";
import { useState, type SyntheticEvent } from "react";
import { apiUrl } from "@/lib/api/config";
import { useLocale } from "next-intl";
import { useRouter } from "next/navigation";
import GeoSelector from "@/components/custom/GeoSelector";
import { LoaderCircle } from "lucide-react";
import { useTranslations } from "next-intl";
// import OrganType from "@/components/custom/OrganType";
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
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

import {
  UserRoundPlus,
  ShieldUser,
  BuildingComplex,
  AlertCircleIcon,
} from "lucide-react";
import BuildingType from "@/components/custom/building/BuildingType";
type locale = "fa" | "en";
export default function Signup() {
  const router = useRouter();
  const locale = useLocale() as locale;
  const t_login = useTranslations("login");
  const t = useTranslations("signup");
  const [geoId, setGeoId] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [orgName, setOrgName] = useState("");
  const [submitted, setSubmitted] = useState(false);
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [orgType, setOrgType] = useState(1001);
  const [error, setError] = useState<
    | "usernameRequired"
    | "passwordRequired"
    | "confirmPasswordRequired"
    | "organizationNameRequired"
    | "orgTypeRequired"
    | "geoIdRequired"
    | "passwordAndConfirmAreDifferent"
    | "passwordLength"
    | "usernameLength"
    | "signupFailed"
    | ""
  >("");

  const submit = async (e: SyntheticEvent<HTMLFormElement>) => {
    e.preventDefault();
    setSubmitted(true);
    setError("");

    // Validation
    if (!username.trim()) {
      setError("usernameRequired");
      return;
    }

    if (!password) {
      setError("passwordRequired");
      return;
    }

    if (!confirmPassword) {
      setError("confirmPasswordRequired");
      return;
    }

    if (!orgName.trim()) {
      setError("organizationNameRequired");
      return;
    }

    if (!geoId) {
      setError("geoIdRequired");
      return;
    }

    if (password !== confirmPassword) {
      setError("passwordAndConfirmAreDifferent");
      return;
    }

    if (password.length < 8 || password.length > 100) {
      setError("passwordLength");
      return;
    }

    if (username.length < 3 || username.length > 100) {
      setError("usernameLength");
      return;
    }

    setIsSubmitting(true);

    try {
      const response = await fetch(apiUrl("/api/Signup/password"), {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          username: username.trim(),
          password,
          orgName: orgName.trim(),
          orgType,
          geoId,
        }),
      });

      if (!response.ok) {
        const errorBody = await response.text();
        console.error("Signup API error:", response.status, errorBody);

        setError("signupFailed");
        return;
      }

      console.log("Signup successful");
      // router.push(`/${locale}/login`);
      router.push(`/${locale}/login?registered=true`);
    } catch (error) {
      console.error("Signup request failed:", error);
      setError("signupFailed");
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <BackgroundShell
      className="h-dvh overflow-hidden"
      overlayClassName="flex h-full flex-col overflow-hidden pt-2 "
    >
      <div className="mx-2 flex min-h-0 flex-1 flex-col  md:mx-20">
        <div className="shrink-0">
          <LogoHeader />
        </div>
        <div className="my-2 flex min-h-0 flex-1 flex-col md:mt-4">
          <PageCard contentClassName="gap-y-4 p-4 sm:p-6 md:p-8">
            <form onSubmit={submit} className="flex flex-col gap-y-4">
              <PageHeader
                title={t("title")}
                description={t("description")}
                icon={<UserRoundPlus className="size-5" />}
                className="mb-4 "
              />
              <div className="flex flex-col md:flex-row  gap-4  ">
                <InsetPanel className="p-4 sm:p-5 md:p-6 w-full md:w-2/3 flex flex-col gap-4">
                  <PageHeader
                    title={t("organizationInformation")}
                    icon={<BuildingComplex className="size-5" />}
                    size="sm"
                    className="mb-4"
                  />
                  <FieldGroup className="gap-2">
                    {/* <Field data-invalid={submitted && !username.trim()}> */}
                    <Field>
                      <FieldLabel
                        htmlFor="fieldgroup-orgName"
                        className="text-foreground"
                      >
                        {t("organizationName")}
                      </FieldLabel>
                      <Input
                        id="fieldgroup-orgName"
                        placeholder={t("organizationName")}
                        value={orgName}
                        aria-invalid={submitted && !orgName.trim()}
                        onChange={(e) => {
                          setOrgName(e.target.value);
                        }}
                        className={`    
                        ${
                          submitted && !orgName.trim()
                            ? "border-destructive"
                            : ""
                        }  `}
                      />
                    </Field>
                  </FieldGroup>
                  <BuildingType
                    orgType={orgType}
                    onOrgTypeChange={setOrgType}
                  />
                  {/* <OrganType /> */}
                  <GeoSelector geoId={geoId} onGeoIdChange={setGeoId} />
                </InsetPanel>

                <InsetPanel className=" p-4 sm:p-5 md:p-6 w-full md:w-1/3 flex flex-col justify-start gap-4 ">
                  <PageHeader
                    title={t("accountInformation")}
                    icon={<ShieldUser className="size-5" />}
                    size="sm"
                    className="mb-4 "
                  />

                  <FieldGroup>
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
                        type="text"
                        value={username}
                        aria-invalid={submitted && !username.trim()}
                        onChange={(e) => {
                          setUsername(e.target.value);
                        }}
                        className={`    ${submitted && !username.trim() ? "border-destructive" : ""}  `}
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
                        className={` ${submitted && !password.trim() ? "border-destructive" : ""}
                                
     
                                
                                
                                `}
                      />
                    </Field>
                    {/* <Field orientation="horizontal"> */}

                    <Field>
                      <FieldLabel
                        htmlFor="fieldgroup-confirmPassword"
                        className="text-foreground"
                      >
                        {t("confirmPassword")}
                      </FieldLabel>
                      <Input
                        id="fieldgroup-confirmPassword"
                        placeholder={t("confirmPassword")}
                        type="password"
                        value={confirmPassword}
                        onChange={(e) => setConfirmPassword(e.target.value)}
                        className={`
                             ${submitted && !confirmPassword.trim() ? "border-destructive" : ""}
                                
                                
                                
  
                                
                                
                                `}
                      />
                    </Field>

                    {/* </Field> */}
                  </FieldGroup>

                  {error && (
                    <Alert
                      variant="destructive"
                      className="neumorphic-alert mt-2 md:mt-8 "
                    >
                      <AlertCircleIcon />
                      <AlertTitle>{t("error")}</AlertTitle>
                      <AlertDescription>
                        {t(`errors.${error}`)}
                      </AlertDescription>
                    </Alert>
                  )}
                </InsetPanel>
              </div>
              <Button
                className="primary-action"
                type="submit"
                disabled={isSubmitting}
              >
                {isSubmitting ? (
                  <>
                    <LoaderCircle className="size-4 animate-spin" />
                    {t("submitting")}
                  </>
                ) : (
                  t("save")
                )}
              </Button>{" "}
              <Button
                className="primary-action"
                type="submit"
                disabled={isSubmitting}
              >
                {isSubmitting ? t("submitting") : t("save")}
              </Button>
            </form>
          </PageCard>
        </div>
      </div>
    </BackgroundShell>
  );
}
