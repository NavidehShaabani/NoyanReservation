import { FieldGroup, FieldLabel, Field } from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { useTranslations } from "next-intl";
export default function SingleBuildingFields() {
  const t = useTranslations("building");
  return (
    <div
      className="   rounded-[10px]
            bg-background
              shadow-[inset_5px_5px_11px_#d6d4d1,inset_-5px_-5px_11px_#ffffff] p-10"
    >
      <div className="text-start pb-7">
        <h1 className="text-xl font-medium text-foreground">
          {t("singleBuildingFormTitle")}
        </h1>

        <p className="mt-2 text-sm text-muted-foreground">
          {t("singleBuildingFormDesc")}
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
            //   value={buildingName}
            //   aria-invalid={submitted && !buildingName.trim()}
            // onChange={(e) => {
            // setbuildingName(e.target.value);
            // }}
            //   className={`    ${submitted && !buildingName.trim() ? "border-destructive" : ""}

            className={`
                        
              border-none
              rounded-[7px]  
              bg-surface
              shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
              focus-visible:ring-1
              focus-visible:ring-primary/30  
                                `}
          />
        </Field>

        <div className="flex flex-row gap-4">
          <Field>
            <FieldLabel
              htmlFor="fieldgroup-buildingAddress"
              className="text-foreground"
            >
              {t("buildingAddress")}
            </FieldLabel>
            <Textarea
              id="buildingAddress"
              placeholder={t("buildingAddressPlaceholder")}
              rows={2}
              className={`
                        
              border-none
              rounded-[7px]  
              bg-surface
              shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
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
              placeholder={t("buildingDescriptionPlaceholder")}
              rows={2}
              className={`
                        
              border-none
              rounded-[7px]  
              bg-surface
              shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
              focus-visible:ring-1
              focus-visible:ring-primary/30 
              resize-none 
                                `}
            />
          </Field>
        </div>
      </FieldGroup>
    </div>
  );
}
