import { FieldGroup, FieldLabel, Field } from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { useTranslations } from "next-intl";
import InsetPanel from "@/components/custom/InsetPanel";
export type BuildingDraft = {
  buildingId: number | null;
  buildingName: string;
  buildingAddress: string;
  buildingDescription: string;
  isActive: boolean;
  orgId: number;
};
type buildingProps = {
  building: BuildingDraft;
  onBuildingChange: (value: BuildingDraft) => void;
};

export default function SingleBuildingFields({
  building,
  onBuildingChange,
}: buildingProps) {
  const t = useTranslations("building");
  return (
    <InsetPanel className="p-10">
      <div className="text-start pb-7">
        <h1 className="text-xl font-medium text-foreground">
          {t("singleBuildingTypeTitle")}
        </h1>

        <p className="mt-2 text-sm text-muted-foreground">
          {t("singleBuildingTypeDesc")}
        </p>
      </div>

      <FieldGroup className="gap-2">
        <Field className="">
          <FieldLabel
            htmlFor="fieldgroup-buildingName"
            className="text-foreground"
          >
            {t("buildingName")}
          </FieldLabel>
          <Input
            id="fieldgroup-buildingName"
            placeholder={t("buildingNamePlaceholder")}
            value={building.buildingName}
            //   aria-invalid={submitted && !buildingName.trim()}
            onChange={(e) => {
              onBuildingChange({ ...building, buildingName: e.target.value });
            }}
            //   className={`    ${submitted && !buildingName.trim() ? "border-destructive" : ""}
          />
        </Field>

        <div className="flex flex-col md:flex-row gap-4">
          <Field>
            <FieldLabel
              htmlFor="fieldgroup-buildingAddress"
              className="text-foreground"
            >
              {t("buildingAddress")}
            </FieldLabel>
            <Textarea
              id="buildingAddress"
              value={building.buildingAddress}
              onChange={(e) => {
                onBuildingChange({
                  ...building,
                  buildingAddress: e.target.value,
                });
              }}
              placeholder={t("buildingAddressPlaceholder")}
              rows={2}
              className={`
                        
              border-none
              rounded-[7px]  
              bg-surface
             neumorphic-field
              focus-visible:ring-1
              focus-visible:ring-primary/30 
              resize-none 
                                `}
            />
          </Field>

          <Field>
            <FieldLabel
              htmlFor="fieldgroup-buildingDescription"
              className="text-foreground"
            >
              {t("buildingDescription")}
            </FieldLabel>

            <Textarea
              id="buildingDescription"
              value={building.buildingDescription}
              onChange={(e) => {
                onBuildingChange({
                  ...building,
                  buildingDescription: e.target.value,
                });
              }}
              placeholder={t("buildingDescriptionPlaceholder")}
              rows={2}
              className={`
                        
              border-none
              rounded-[7px]  
              bg-surface
              neumorphic-field
              focus-visible:ring-1
              focus-visible:ring-primary/30 
              resize-none 
                                `}
            />
          </Field>
        </div>
      </FieldGroup>
    </InsetPanel>
  );
}
