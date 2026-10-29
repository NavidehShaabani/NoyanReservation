"use client";
import { useState } from "react";
import { Button } from "@/components/ui/button";
import { useTranslations, useLocale } from "next-intl";
import {
  Card,
  CardAction,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Check } from "lucide-react";
import InsetPanel from "@/components/custom/InsetPanel";
type BuildingFormProps = {
  orgType: number;
  onOrgTypeChange: (value: number) => void;
};

export default function BuildingForm({
  orgType,
  onOrgTypeChange,
}: BuildingFormProps) {
  const t = useTranslations("building");

  return (
    <InsetPanel className="p-10">
      <div className="text-start pb-7">
        <h1 className="text-xl font-medium text-foreground">
          {t("building-type-form-title")}
        </h1>

        <p className="mt-2 text-sm text-muted-foreground">
          {t("building-type-form-desc")}
        </p>
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-3 sm:gap-4">
        <Card
          onClick={() => {
            onOrgTypeChange(1002);
          }}
          className={`
          
                pt-0
                pb-0
                cursor-pointer

                relative
                flex flex-row items-stretch gap-0
                w-full min-w-0 overflow-hidden
                bg-background
                neumorphic-raised
                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]
                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
          ${orgType === 1002 ? "border-[1px] border-primary" : "border-[1px] border-transparent"}  
                min-h-36 

            `}
        >
          {/* <div className="h-40 overflow-hidden rounded-s-xl bg-background sm:h-48 w-28 sm:w-40 shrink-0"> */}
          <div
            className="
          w-20 
          shrink-0 
          self-stretch 
          overflow-hidden 
          rounded-s-xl 
          sm:w-32
          "
          >
            <img
              src="/images/Residential Complex.png"
              alt="Residential complex"
              className="h-full w-full object-cover"
            />
          </div>

          <CardHeader className="min-w-0 flex-1 gap-1 px-3 py-3 sm:px-4">
            <CardTitle>{t("residential-complex")}</CardTitle>
            <CardDescription className="line-clamp-3">
              {t("residential-complex_desc")}
            </CardDescription>
          </CardHeader>
          <CardFooter className="shrink-0 items-center justify-center p-2 rounded-e-[10px]">
            <Check
              className={`size-7  stroke-[3]   ${orgType === 1002 ? "text-green-800" : "text-background"}  `}
            />
          </CardFooter>
        </Card>

        <Card
          onClick={() => {
            onOrgTypeChange(1001);
          }}
          className={`
             

                pt-0
                pb-0
            cursor-pointer

                relative
                flex flex-row items-stretch gap-0
                w-full min-w-0 overflow-hidden
                bg-background
                neumorphic-raised
                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]
                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
                ${orgType === 1001 ? "border-[1px] border-primary" : "border-[1px] border-transparent"}  
                
                min-h-36 

            `}
        >
          {/* <div className="h-40 overflow-hidden rounded-s-xl bg-background sm:h-48 w-28 sm:w-40 shrink-0"> */}
          <div
            className="
          w-20 
          shrink-0 
          self-stretch 
          overflow-hidden 
          rounded-s-xl 
          sm:w-32
          "
          >
            <img
              src="/images/Standalone Building.png"
              alt="Standalone Building"
              className="h-full w-full object-cover "
            />
          </div>

          <CardHeader className="min-w-0 flex-1 gap-1 px-3 py-3 sm:px-4">
            <CardTitle>{t("standalone-building")}</CardTitle>
            <CardDescription className="line-clamp-3">
              {t("standalone-building_desc")}
            </CardDescription>
          </CardHeader>
          <CardFooter className="shrink-0 items-center justify-center p-2 rounded-e-[10px]">
            <Check
              className={`size-7  stroke-[3]   ${orgType === 1001 ? "text-green-800" : "text-background"}  `}
            />
          </CardFooter>
        </Card>
      </div>
    </InsetPanel>
  );
}
