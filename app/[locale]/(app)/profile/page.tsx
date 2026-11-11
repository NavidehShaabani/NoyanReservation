"use client";
import PageCard from "@/components/custom/PageCard";
import PageHeader from "@/components/custom/PageHeader";
import InsetPanel from "@/components/custom/InsetPanel";
import DatePicker from "@/components/custom/DatePicker";
import { UserRound } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { FieldGroup, Field, FieldLabel } from "@/components/ui/field";

import { useTranslations } from "next-intl";
import { useState } from "react";
import type { ChangeEvent, FormEvent } from "react";

type ProfileFormData = {
  firstName: string;
  lastName: string;
  email: string;
  nationalId: string;
  gender: number | "";
  birthDate: string;
  avatarUrl: string;
  fatherName: string;
  birthPlace: string;
  landlinePhone: string;
  userPostalCode: string;
  userAddress: string;
  emergencyContactName: string;
  emergencyContactMobile: string;
  emergencyContactRelation: string;
  profileNotes: string;
  unitId: number | "";
  relationshipType: number | "";
  startDate: string;
  endDate: string;
  residencyNotes: string;
};

export default function Profile() {
  const t = useTranslations("profile");

  const [profile, setProfile] = useState<ProfileFormData>({
    firstName: "",
    lastName: "",
    email: "",
    nationalId: "",
    gender: "",
    birthDate: "",
    avatarUrl: "",
    fatherName: "",
    birthPlace: "",
    landlinePhone: "",
    userPostalCode: "",
    userAddress: "",
    emergencyContactName: "",
    emergencyContactMobile: "",
    emergencyContactRelation: "",
    profileNotes: "",
    unitId: "",
    relationshipType: "",
    startDate: "",
    endDate: "",
    residencyNotes: "",
  });

  const [submitted, setSubmitted] = useState(false);

  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;

    setProfile((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setSubmitted(true);

    if (!profile.firstName.trim() || !profile.lastName.trim()) {
      return;
    }

    // TODO: ارسال اطلاعات به API
    console.log(profile);
  };

  return (
    <div className="mx-2 mb-2 flex min-h-0 flex-1 flex-col md:ms-0">
      <PageCard contentClassName="gap-y-4 p-8 md:p-12">
        <PageHeader
          title={t("title")}
          description={t("description")}
          icon={<UserRound className="size-5" />}
          className="mb-4"
        />

        <form onSubmit={handleSubmit} className="flex flex-col gap-5">
          {/* بخش اول: اطلاعات شخصی */}
          <InsetPanel className="p-4 sm:p-5 md:p-6">
            <div className="mb-5">
              <h3 className="font-semibold">{t("personalInfo")}</h3>
            </div>

            <FieldGroup className="grid grid-cols-1 gap-x-6 gap-y-4 md:grid-cols-2">
              <Field className="gap-1">
                <FieldLabel htmlFor="firstName">{t("firstName")}</FieldLabel>
                <Input
                  id="firstName"
                  name="firstName"
                  placeholder={t("firstName")}
                  value={profile.firstName}
                  onChange={handleChange}
                  aria-invalid={submitted && !profile.firstName.trim()}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="lastName">{t("lastName")}</FieldLabel>
                <Input
                  id="lastName"
                  name="lastName"
                  placeholder={t("lastName")}
                  value={profile.lastName}
                  onChange={handleChange}
                  aria-invalid={submitted && !profile.lastName.trim()}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="nationalId">{t("nationalId")}</FieldLabel>
                <Input
                  id="nationalId"
                  name="nationalId"
                  placeholder={t("nationalId")}
                  value={profile.nationalId}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="fatherName">{t("fatherName")}</FieldLabel>
                <Input
                  id="fatherName"
                  name="fatherName"
                  placeholder={t("fatherName")}
                  value={profile.fatherName}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="gender">{t("gender")}</FieldLabel>
                <Input
                  id="gender"
                  name="gender"
                  type="number"
                  value={profile.gender}
                  onChange={handleChange}
                />
              </Field>

              {/* <Field className="gap-1">
                <FieldLabel htmlFor="birthDate">{t("birthDate")}</FieldLabel>
                <Input
                  id="birthDate"
                  name="birthDate"
                  type="date"
                  value={profile.birthDate}
                  onChange={handleChange}
                />
              </Field> */}

              <Field className="gap-1">
                <FieldLabel htmlFor="birthDate">{t("birthDate")}</FieldLabel>

                <DatePicker
                  id="birthDate"
                  name="birthDate"
                  value={profile.birthDate}
                  onChange={(value) =>
                    setProfile((prev) => ({
                      ...prev,
                      birthDate: value,
                    }))
                  }
                  placeholder={t("birthDate")}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="birthPlace">{t("birthPlace")}</FieldLabel>
                <Input
                  id="birthPlace"
                  name="birthPlace"
                  placeholder={t("birthPlace")}
                  value={profile.birthPlace}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="profileNotes">
                  {t("profileNotes")}
                </FieldLabel>
                <Textarea
                  id="profileNotes"
                  name="profileNotes"
                  placeholder={t("profileNotes")}
                  value={profile.profileNotes}
                  onChange={handleChange}
                />
              </Field>
            </FieldGroup>
          </InsetPanel>

          {/* بخش دوم: اطلاعات تماس و تماس اضطراری */}
          <InsetPanel className="p-4 sm:p-5 md:p-6">
            <div className="mb-5">
              <h3 className="font-semibold">{t("contactInfo")}</h3>
            </div>

            <FieldGroup className="grid grid-cols-1 gap-x-6 gap-y-4 md:grid-cols-2">
              <Field className="gap-1">
                <FieldLabel htmlFor="email">{t("email")}</FieldLabel>
                <Input
                  id="email"
                  name="email"
                  type="email"
                  placeholder={t("email")}
                  value={profile.email}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="landlinePhone">
                  {t("landlinePhone")}
                </FieldLabel>
                <Input
                  id="landlinePhone"
                  name="landlinePhone"
                  type="tel"
                  placeholder={t("landlinePhone")}
                  value={profile.landlinePhone}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="userPostalCode">
                  {t("userPostalCode")}
                </FieldLabel>
                <Input
                  id="userPostalCode"
                  name="userPostalCode"
                  placeholder={t("userPostalCode")}
                  value={profile.userPostalCode}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1 md:col-span-2">
                <FieldLabel htmlFor="userAddress">
                  {t("userAddress")}
                </FieldLabel>
                <Textarea
                  id="userAddress"
                  name="userAddress"
                  placeholder={t("userAddress")}
                  value={profile.userAddress}
                  onChange={handleChange}
                />
              </Field>
            </FieldGroup>

            <div className="mb-5 mt-7">
              <h4 className="font-medium">{t("emergencyContact")}</h4>
            </div>

            <FieldGroup className="grid grid-cols-1 gap-x-6 gap-y-4 md:grid-cols-2">
              <Field className="gap-1">
                <FieldLabel htmlFor="emergencyContactName">
                  {t("emergencyContactName")}
                </FieldLabel>
                <Input
                  id="emergencyContactName"
                  name="emergencyContactName"
                  placeholder={t("emergencyContactName")}
                  value={profile.emergencyContactName}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="emergencyContactMobile">
                  {t("emergencyContactMobile")}
                </FieldLabel>
                <Input
                  id="emergencyContactMobile"
                  name="emergencyContactMobile"
                  type="tel"
                  placeholder={t("emergencyContactMobile")}
                  value={profile.emergencyContactMobile}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="emergencyContactRelation">
                  {t("emergencyContactRelation")}
                </FieldLabel>
                <Input
                  id="emergencyContactRelation"
                  name="emergencyContactRelation"
                  placeholder={t("emergencyContactRelation")}
                  value={profile.emergencyContactRelation}
                  onChange={handleChange}
                />
              </Field>
            </FieldGroup>
          </InsetPanel>

          {/* بخش سوم: اطلاعات سکونت */}
          <InsetPanel className="p-4 sm:p-5 md:p-6">
            <div className="mb-5">
              <h3 className="font-semibold">{t("residencyInfo")}</h3>
            </div>

            <FieldGroup className="grid grid-cols-1 gap-x-6 gap-y-4 md:grid-cols-2">
              <Field className="gap-1">
                <FieldLabel htmlFor="unitId">{t("unitId")}</FieldLabel>
                <Input
                  id="unitId"
                  name="unitId"
                  type="number"
                  value={profile.unitId}
                  onChange={handleChange}
                />
              </Field>

              <Field className="gap-1">
                <FieldLabel htmlFor="relationshipType">
                  {t("relationshipType")}
                </FieldLabel>
                <Input
                  id="relationshipType"
                  name="relationshipType"
                  type="number"
                  value={profile.relationshipType}
                  onChange={handleChange}
                />
              </Field>

              {/* <Field className="gap-1">
                <FieldLabel htmlFor="startDate">{t("startDate")}</FieldLabel>
                <Input
                  id="startDate"
                  name="startDate"
                  type="date"
                  value={profile.startDate}
                  onChange={handleChange}
                />
              </Field> */}

              <Field className="gap-1">
                <FieldLabel htmlFor="startDate">{t("startDate")}</FieldLabel>

                <DatePicker
                  id="startDate"
                  name="startDate"
                  value={profile.startDate}
                  onChange={(value) =>
                    setProfile((prev) => ({
                      ...prev,
                      startDate: value,
                    }))
                  }
                  placeholder={t("startDate")}
                />
              </Field>

              {/* <Field className="gap-1">
                <FieldLabel htmlFor="endDate">{t("endDate")}</FieldLabel>
                <Input
                  id="endDate"
                  name="endDate"
                  type="date"
                  value={profile.endDate}
                  onChange={handleChange}
                />
              </Field> */}

              <Field className="gap-1">
                <FieldLabel htmlFor="endDate">{t("endDate")}</FieldLabel>

                <DatePicker
                  id="endDate"
                  name="endDate"
                  value={profile.endDate}
                  onChange={(value) =>
                    setProfile((prev) => ({
                      ...prev,
                      endDate: value,
                    }))
                  }
                  placeholder={t("endDate")}
                />
              </Field>

              <Field className="gap-1 md:col-span-2">
                <FieldLabel htmlFor="residencyNotes">
                  {t("residencyNotes")}
                </FieldLabel>
                <Textarea
                  id="residencyNotes"
                  name="residencyNotes"
                  placeholder={t("residencyNotes")}
                  value={profile.residencyNotes}
                  onChange={handleChange}
                />
              </Field>
            </FieldGroup>
          </InsetPanel>

          <div className="flex justify-end">
            <Button className="primary-action" type="submit">
              {t("submit")}
            </Button>
          </div>
        </form>
      </PageCard>
    </div>
  );
}
