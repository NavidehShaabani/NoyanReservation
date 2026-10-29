"use client";
import { useState, useEffect, useContext } from "react";
import { Building2, Pencil } from "lucide-react";
import { Button } from "@/components/ui/button";
import { createClientId } from "@/lib/create-client-id";
import { AuthContext } from "@/context/AuthProvider";
import { useTranslations } from "next-intl";
import type { BuildingDraft } from "@/components/custom/building/SingleBuildingFields";
import type { ComplexDraft } from "@/components/custom/building/ResidentialComplexFields";
import type { ComplexBuildingDraft } from "@/components/custom/building/ResidentialComplexFields";
import { useLocale } from "next-intl";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { useRouter } from "next/navigation";
import PageCard from "@/components/custom/PageCard";
import PageHeader from "@/components/custom/PageHeader";
export type CurrentGeoInfo = {
  geoId: string;
  geoPathFa: string | null;
  geoPathEn: string | null;
};
type locale = "fa" | "en";
export default function Building() {
  const router = useRouter();
  const t_geo = useTranslations("geo");
  const t_building = useTranslations("building");
  const locale = useLocale() as locale;
  const { token, isAuthReady, user } = useContext(AuthContext);
  const [orgType, setOrgType] = useState(1001);
  const [currentGeo, setCurrentGeo] = useState<CurrentGeoInfo | null>(null);
  const [building, setBuilding] = useState<BuildingDraft>({
    buildingId: null,
    buildingName: "",
    buildingAddress: "",
    buildingDescription: "",
    isActive: true,
    orgId: 0,
  });
  const [complex, setComplex] = useState<ComplexDraft>({
    orgName: "",
    orgDesc: "",
    orgId: 0,
    orgType: 1001,
    isActive: true,
    buildings: [],
  });
  useEffect(() => {
    async function getOrgData() {
      if (!isAuthReady || !token) return;
      try {
        const orgId: number = user?.orgId ?? 0;
        const orgResponse = await fetch(
          `http://10.208.8.91:5295/api/Organizations?orgId=${orgId}`,
          {
            method: "GET",
            credentials: "include",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          },
        );

        if (!orgResponse.ok) {
          throw new Error(`Request failed: ${orgResponse.status}`);
        }
        const orgResponselist = await orgResponse.json();
        const orgData = orgResponselist.data[0];

        setComplex((prev) => ({
          ...prev,
          orgId: orgData.orgId,
          orgName: orgData.orgName,
          orgDesc: orgData.orgDesc,
          orgType: orgData.orgType,
          isActive: orgData.isActive,
        }));
        setOrgType(orgData.orgType);
        await getCurrentGeoInfo(orgData.geoId);
        const buildingResponse = await fetch(
          `http://10.208.8.91:5295/api/Buildings/by-org/${orgId}`,
          {
            method: "GET",
            credentials: "include",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          },
        );
        if (!buildingResponse.ok) {
          throw new Error(`Request failed: ${buildingResponse.status}`);
        }
        const buildingResponselist = await buildingResponse.json();

        const buildings: ComplexBuildingDraft[] = buildingResponselist.data.map(
          (item: BuildingDraft) => ({
            buildingId: item.buildingId,
            buildingName: item.buildingName,
            buildingAddress: item.buildingAddress,
            buildingDescription: item.buildingDescription,
            clientId: createClientId(),
          }),
        );

        setComplex((prev) => ({
          ...prev,
          buildings,
        }));

        if (orgData.orgType === 1001 && buildings.length > 0) {
          setBuilding(buildings[0]);
        }
      } catch (error) {
        console.error("Failed to load buildings:", error);
      }
    }
    getOrgData();
  }, [isAuthReady, token]);

  async function getCurrentGeoInfo(geoId: string) {
    const currentGeoResponse = await fetch(
      `http://10.208.8.91:5295/api/Geo/${geoId}`,
      {
        method: "GET",
        credentials: "include",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      },
    );
    if (!currentGeoResponse.ok) {
      throw new Error(`Request failed: ${currentGeoResponse.status}`);
    }
    const result = await currentGeoResponse.json();
    //return result.data;
    setCurrentGeo(result.data);
  }

  return (
    <div
      className="
            mx-2 md:ms-0 mb-2 flex min-h-0 flex-1 flex-col
        "
    >
      <PageCard contentClassName="gap-y-4 p-8 md:p-12">
        <Card
          className=" flex w-full min-w-0 shrink-0 flex-col gap-2 bg-background pt-0 pb-0 
        neumorphic-raised"
        >
          <CardHeader className="flex flex-row items-center justify-between gap-3 px-4 py-4 sm:px-6">
            {/* <div className="flex min-w-0 items-center gap-3">
              <div className="flex size-10 shrink-0 items-center justify-center rounded-xl bg-primary/10 text-primary">
                <Building2 className="size-5" />
              </div>

              <div className="min-w-0">
                <CardTitle className="text-base sm:text-lg break-words">
                  {orgType === 1001
                    ? t_building("building-info-title")
                    : t_building("complex-info-title")}
                </CardTitle>
              </div>
            </div> */}

            <PageHeader
              title={
                orgType === 1001
                  ? t_building("building-info-title")
                  : t_building("complex-info-title")
              }
              icon={<Building2 className="size-5" />}
              className="mb-4 "
            />

            <Button
              onClick={() => router.push(`/${locale}/building/edit`)}
              size="sm"
              className="inline-flex h-9 items-center justify-center gap-2 px-2"
            >
              <Pencil className="size-3.5 shrink-0" />
              <span className="leading-none">{t_building("edit")}</span>
            </Button>
          </CardHeader>
          <CardContent className="space-y-6 px-4 pb-5 sm:px-6">
            {/* موقعیت مکانی و نوع سازمان */}
            <div className="flex flex-col  text-sm text-muted-foreground sm:flex-row sm:gap-2">
              <p>
                {orgType === 1001
                  ? t_building("standalone-building")
                  : t_building("residential-complex")}
              </p>
              .
              <p className="break-words ">
                {locale === "fa"
                  ? currentGeo?.geoPathFa || currentGeo?.geoPathEn || "—"
                  : currentGeo?.geoPathEn || "—"}
              </p>
            </div>

            {/* اطلاعات ساختمان مستقل */}
            {orgType === 1001 && (
              <div className="border-t pt-5">
                <dl className="grid gap-5 sm:grid-cols-2">
                  <div className="min-w-0 space-y-1">
                    <p className="text-sm text-muted-foreground">
                      {t_building("buildingName")}
                    </p>
                    <p className="break-words font-medium">
                      {building.buildingName || "—"}
                    </p>
                  </div>

                  <div className="min-w-0 space-y-1">
                    <p className="text-sm text-muted-foreground">
                      {t_building("buildingAddress")}
                    </p>
                    <p className="break-words font-medium">
                      {building.buildingAddress || "—"}
                    </p>
                  </div>

                  <div className="min-w-0 space-y-1 sm:col-span-2">
                    <p className="text-sm text-muted-foreground">
                      {t_building("buildingDescription")}
                    </p>
                    <p className="break-words whitespace-pre-wrap">
                      {building.buildingDescription || "—"}
                    </p>
                  </div>
                </dl>
              </div>
            )}

            {/* اطلاعات مجتمع */}
            {orgType === 1002 && (
              <div className="border-t pt-5">
                <div className="space-y-2">
                  <h2 className="text-lg font-semibold">
                    {complex.orgName || "—"}
                  </h2>

                  <p className="whitespace-pre-wrap break-words text-sm text-muted-foreground">
                    {complex.orgDesc || "—"}
                  </p>
                </div>
              </div>
            )}
          </CardContent>
        </Card>

        {orgType === 1002 && (
          <Card
            className=" flex w-full min-w-0 shrink-0 flex-col gap-2 bg-background pt-0 pb-0 
          neumorphic-raised"
          >
            <CardContent className="space-y-6 px-4 py-5 sm:px-6">
              <div className="space-y-3">
                <div className="flex items-center justify-between gap-3">
                  <h3 className="font-medium">
                    {t_building("residentialComplexBuildingListTitle")}
                  </h3>
                  <span className="text-sm text-muted-foreground">
                    {t_building("residentialComplexBuildingCount")} :{" "}
                    {complex.buildings.length}
                  </span>
                </div>

                <div className="space-y-3">
                  {complex.buildings.map((item) => (
                    <div
                      key={item.clientId}
                      className="  rounded-[10px] bg-background p-4
  neumorphic-list-item "
                    >
                      <dl className="grid gap-4 sm:grid-cols-2">
                        <div className="min-w-0 space-y-1">
                          <p className="text-sm text-muted-foreground">
                            {t_building("buildingName")}
                          </p>
                          <p className="break-words font-medium">
                            {item.buildingName || "—"}
                          </p>
                        </div>

                        <div className="min-w-0 space-y-1">
                          <p className="text-sm text-muted-foreground">
                            {t_building("buildingAddress")}
                          </p>
                          <p className="break-words">
                            {item.buildingAddress || "—"}
                          </p>
                        </div>

                        <div className="min-w-0 space-y-1 sm:col-span-2">
                          <p className="text-sm text-muted-foreground">
                            {t_building("buildingDescription")}
                          </p>
                          <p className="break-words whitespace-pre-wrap">
                            {item.buildingDescription || "—"}
                          </p>
                        </div>
                      </dl>
                    </div>
                  ))}
                </div>
              </div>
            </CardContent>
          </Card>
        )}
      </PageCard>
    </div>
  );
}
