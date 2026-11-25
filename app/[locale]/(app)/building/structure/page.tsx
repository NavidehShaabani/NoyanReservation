"use client";
import { useRouter } from "next/navigation";
import PageCard from "@/components/custom/PageCard";
import PageHeader from "@/components/custom/PageHeader";
import { useTranslations, useLocale } from "next-intl";
import {
  Building2,
  Layers,
  Pencil,
  DoorStairwell,
  DoorClosed,
} from "lucide-react";
import VerticalStepper from "@/components/custom/VerticalStepper";
import { Button } from "@/components/ui/button";
import InsetPanel from "@/components/custom/InsetPanel";
type locale = "fa" | "en";
export default function Structure() {
  const router = useRouter();
  const locale = useLocale() as locale;
  const t = useTranslations("buildingStructure");
  const t_setupGuide = useTranslations(
    "buildingStructure.physicalStructureGuide",
  );
  const t_building = useTranslations("building");
  return (
    <div className="mx-2 md:ms-0 mb-2 flex min-h-0 flex-1 flex-col">
      <PageCard contentClassName="gap-y-4 p-8 md:p-12">
        <PageHeader
          title={t("title")}
          description={t("description")}
          icon={<Building2 className="size-5" />}
          backHref="/building"
          backLabel={t_building("backToBuildings")}
          className="mb-4 "
        />

        <InsetPanel className="p-4">
          <VerticalStepper
            steps={[
              {
                title: t_setupGuide("steps.floors.title"),
                description: t_setupGuide("steps.floors.description"),
                icon: <Layers className="size-5 text-primary" />,
                action: (
                  <Button
                    size="sm"
                    variant="outline"
                    onClick={() => router.push(`/${locale}/building/edit`)}
                  >
                    <Pencil className="size-3.5" />
                    {t_setupGuide("actions.manage")}
                  </Button>
                ),
              },
              {
                title: t_setupGuide("steps.staircases.title"),
                description: t_setupGuide("steps.staircases.description"),
                icon: <DoorStairwell className="size-5 text-primary" />,
                action: (
                  <Button
                    size="sm"
                    variant="outline"
                    onClick={() => router.push(`/${locale}/building/edit`)}
                  >
                    <Pencil className="size-3.5" />
                    {t_setupGuide("actions.manage")}
                  </Button>
                ),
              },
              {
                title: t_setupGuide("steps.elevators.title"),
                description: t_setupGuide("steps.elevators.description"),
                icon: (
                  <img
                    src="/images/icons/elevator.svg"
                    alt=""
                    className="h-5 w-5 object-contain"
                  />
                ),
                action: (
                  <Button
                    size="sm"
                    variant="outline"
                    onClick={() => router.push(`/${locale}/building/edit`)}
                  >
                    <Pencil className="size-3.5" />
                    {t_setupGuide("actions.manage")}
                  </Button>
                ),
              },

              {
                title: t_setupGuide("steps.units.title"),
                description: t_setupGuide("steps.units.description"),
                icon: <DoorClosed className="size-5 text-primary" />,
                action: (
                  <Button
                    size="sm"
                    variant="outline"
                    onClick={() => router.push(`/${locale}/building/edit`)}
                  >
                    <Pencil className="size-3.5" />
                    {t_setupGuide("actions.manage")}
                  </Button>
                ),
              },
            ]}
          />
        </InsetPanel>
      </PageCard>
    </div>
  );
}
