import { useState, useEffect } from "react";
import { apiUrl } from "@/lib/api/config";
import InsetPanel from "./InsetPanel";
import { useTranslations, useLocale } from "next-intl";
import {
  Field,
  FieldLabel,
  FieldContent,
  FieldTitle,
  FieldGroup,
} from "../ui/field";
import { RadioGroup, RadioGroupItem } from "../ui/radio-group";
import { cn } from "@/lib/utils";
import { Label } from "@/components/ui/label";
type Organ = {
  LookupValueId: number;
  LookupId: number;
  LookupValueTitleFr: string | null;
  LookupValueTitleEn: string | null;
  SortId: number | null;
};
type locale = "fa" | "en";
export default function OrganType() {
  const locale = useLocale() as locale;
  const t = useTranslations("signup");
  const [organTypeList, setOrganTypeList] = useState<Organ[]>([]);
  const [selectedOrgan, setSelectedOrgan] = useState<Organ | null>(null);
  useEffect(() => {
    async function getOrganType() {
      try {
        const organTypeResponse = await fetch(apiUrl("/api/BaseLookupValues"), {
          method: "GET",
          credentials: "include",
          headers: {},
        });
        if (!organTypeResponse.ok) {
          const errorBody = await organTypeResponse.text();
          throw new Error(
            `Request failed: ${organTypeResponse.status} - ${errorBody}`,
          );
        }
        const organTypeResponseList = await organTypeResponse.json();

        if (!Array.isArray(organTypeResponseList.data)) {
          throw new Error("organType API did not return a list.");
        }

        setOrganTypeList(
          organTypeResponseList.data.filter(
            (item: Organ) => item.LookupId === 10,
          ),
        );
      } catch (error) {}
    }
    getOrganType();
  }, []);
  return (
    <FieldGroup className="my-4">
      <Field>
        <FieldLabel>{t("organizationType")}</FieldLabel>
        <RadioGroup
          value={selectedOrgan ? String(selectedOrgan.LookupValueId) : ""}
          onValueChange={(value) => {
            const selected = organTypeList.find(
              (item) => String(item.LookupValueId) === value,
            );
            setSelectedOrgan(selected ?? null);
          }}
          className="grid grid-cols-2 gap-3"
        >
          {organTypeList.map((orgtype) => (
            <FieldLabel
              key={orgtype.LookupValueId}
              htmlFor={String(orgtype.LookupValueId)}
              aria-disabled={![1001, 1002].includes(orgtype.LookupValueId)}
              className={cn(
                orgtype.LookupValueId === selectedOrgan?.LookupValueId
                  ? "neumorphic-raised"
                  : "neumorphic-field",
                "flex min-h-16 items-center gap-2 rounded-xl p-1",
                "transition-all duration-200",
                ![1001, 1002].includes(orgtype.LookupValueId) &&
                  "pointer-events-none opacity-40",
              )}
            >
              <Field orientation="horizontal">
                <FieldContent>
                  <FieldTitle>
                    {locale === "fa"
                      ? orgtype.LookupValueTitleFr
                      : orgtype.LookupValueTitleEn}
                  </FieldTitle>
                  {/* <FieldDescription>
              </FieldDescription> */}
                </FieldContent>
                <RadioGroupItem
                  value={String(orgtype.LookupValueId)}
                  id={String(orgtype.LookupValueId)}
                  disabled={![1001, 1002].includes(orgtype.LookupValueId)}
                />
              </Field>
            </FieldLabel>
          ))}
        </RadioGroup>
      </Field>
    </FieldGroup>
  );
}
