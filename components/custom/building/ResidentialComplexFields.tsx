import { FieldGroup, FieldLabel, Field } from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { useTranslations } from "next-intl";
export default function ResidentialComplexFields() {
  const t = useTranslations("building");
  return (
    <div
      className="   rounded-[10px]
            bg-background
              shadow-[inset_5px_5px_11px_#d6d4d1,inset_-5px_-5px_11px_#ffffff] p-10"
    >
      <div className="text-start pb-7">
        <h1 className="text-xl font-medium text-foreground">
          {t("residentialComplexFormTitle")}
        </h1>

        <p className="mt-2 text-sm text-muted-foreground">
          {t("residentialComplexFormDesc")}
        </p>
      </div>

      <FieldGroup className="gap-2">
        <Field className="">
          <FieldLabel
            htmlFor="fieldgroup-residentialComplexName"
            className="text-foreground"
          >
            {t("residentialComplexName")}
          </FieldLabel>
          <Input
            id="fieldgroup-residentialComplexName"
            placeholder={t("residentialComplexNamePlaceholder")}
            //   value={residentialComplexName}
            //   aria-invalid={submitted && !residentialComplexName.trim()}
            // onChange={(e) => {
            // setResidentialComplexName(e.target.value);
            // }}
            //   className={`    ${submitted && !residentialComplexName.trim() ? "border-destructive" : ""}

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

        <Field>
          <FieldLabel
            htmlFor="fieldgroup-residentialComplexDescription"
            className="text-foreground"
          >
            {t("residentialComplexDescription")}
          </FieldLabel>

          <Textarea
            id="residentialComplexDescription"
            placeholder={t("residentialComplexDescriptionPlaceholder")}
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
      </FieldGroup>
    </div>
  );
}
