"use client";
import { useState, useEffect, useContext, useCallback } from "react";
import { apiUrl } from "@/lib/api/config";
import {
  Building2,
  Pencil,
  MapPin,
  BuildingComplex,
  FileText,
  Layers3,
  CalendarCheck,
  CheckCircle2,
  LockKeyhole,
  ChevronLeft,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Skeleton } from "@/components/ui/skeleton";
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
import ErrorState from "@/components/custom/feedback/ErrorState";
import RaisedPanel from "@/components/custom/RaisedPanel";
import { Badge } from "@/components/ui/badge";
import InsetPanel from "@/components/custom/InsetPanel";
import VerticalStepper from "@/components/custom/VerticalStepper";
function BuildingSkeleton() {
  return (
    <div className="mx-2 mb-2 flex min-h-0 flex-1 flex-col md:ms-0">
      <PageCard contentClassName="gap-y-4 p-8 md:p-12">
        <Card className="flex w-full flex-col gap-2 bg-background pt-0 pb-0 neumorphic-raised">
          <CardHeader className="flex flex-row items-center justify-between gap-3 px-4 py-4 sm:px-6">
            <div className="flex items-center gap-3">
              <Skeleton className="size-11 rounded-xl" />
              <Skeleton className="h-6 w-40" />
            </div>

            <Skeleton className="h-9 w-20 rounded-md" />
          </CardHeader>

          <CardContent className="space-y-6 px-4 pb-5 sm:px-6">
            {/* موقعیت جغرافیایی */}
            <div className="flex flex-col gap-2 sm:flex-row">
              <Skeleton className="h-4 w-32" />
              <Skeleton className="h-4 w-2/3" />
            </div>

            {/* اطلاعات ساختمان */}
            <div className="border-t pt-5">
              <div className="grid gap-5 sm:grid-cols-2">
                <div className="space-y-2">
                  <Skeleton className="h-4 w-24" />
                  <Skeleton className="h-5 w-40" />
                </div>

                <div className="space-y-2">
                  <Skeleton className="h-4 w-24" />
                  <Skeleton className="h-5 w-48" />
                </div>

                <div className="space-y-2 sm:col-span-2">
                  <Skeleton className="h-4 w-28" />
                  <Skeleton className="h-5 w-full" />
                  <Skeleton className="h-5 w-2/3" />
                </div>
              </div>
            </div>
          </CardContent>
        </Card>

        {/* جای احتمالی فهرست ساختمان‌های مجتمع */}
        <Card className="flex w-full flex-col gap-2 bg-background pt-0 pb-0 neumorphic-raised">
          <CardContent className="space-y-3 px-4 py-5 sm:px-6">
            <Skeleton className="h-5 w-44" />
            <Skeleton className="h-24 w-full rounded-[10px]" />
          </CardContent>
        </Card>
      </PageCard>
    </div>
  );
}

export type CurrentGeoInfo = {
  geoId: string;
  geoPathFa: string | null;
  geoPathEn: string | null;
};
type locale = "fa" | "en";
export default function Building() {
  const router = useRouter();
  const t_geo = useTranslations("geo");
  const t_common = useTranslations("common");
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const t_building = useTranslations("building");
  const t_setupGuide = useTranslations("building.setupGuide");
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

  // async function getOrgData() {
  const getOrgData = useCallback(async () => {
    if (!isAuthReady || !token || !user?.orgId) return;

    setIsLoading(true);
    setError(null);
    try {
      const orgId: number = user?.orgId ?? 0;
      const orgResponse = await fetch(
        apiUrl(`/api/Organizations?orgId=${orgId}`),
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
      const orgData = orgResponselist.data?.[0];
      if (!orgData) {
        throw new Error("ORGANIZATION_NOT_FOUND");
      }
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
        apiUrl(`/api/Buildings/by-org/${orgId}`),
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
      console.error("Failed to load building data:", error);
      setError(error instanceof Error ? error.message : "UNKNOWN_ERROR");
    } finally {
      setIsLoading(false);
    }
  }, [isAuthReady, token, user?.orgId]);

  useEffect(() => {
    getOrgData();
  }, [getOrgData]);

  async function getCurrentGeoInfo(geoId: string) {
    const currentGeoResponse = await fetch(apiUrl(`/api/Geo/${geoId}`), {
      method: "GET",
      credentials: "include",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    if (!currentGeoResponse.ok) {
      throw new Error(`Request failed: ${currentGeoResponse.status}`);
    }
    const result = await currentGeoResponse.json();
    //return result.data;
    setCurrentGeo(result.data);
  }
  if (isLoading) {
    return <BuildingSkeleton />;
  }

  if (error) {
    return (
      <ErrorState
        title={t_common("error.loadTitle")}
        description={t_common("error.loadDescription")}
        retryLabel={t_common("error.retry")}
        onRetry={() => getOrgData()}
      />
    );
  }

  const hasBuildings =
    orgType === 1001
      ? building.buildingId != null
      : complex.buildings.length > 0;

  return (
    <div
      className="
            mx-2 md:ms-0 mb-2 flex min-h-0 flex-1 flex-col
        "
    >
      <PageCard contentClassName="gap-y-3 p-4 sm:p-6 md:p-8">
        <PageHeader
          title={
            orgType === 1001
              ? t_building("building-info-title")
              : t_building("complex-info-title")
          }
          icon={
            orgType === 1001 ? (
              <Building2 className="size-5" />
            ) : (
              <BuildingComplex className="size-5" />
            )
          }
          className="mb-4 "
        />
        <RaisedPanel className="relative p-5 sm:p-6">
          <div className="flex flex-col gap-3">
            {/* عنوان و هویت مجموعه */}
            <div className="flex items-center gap-4">
              {/* <div
                className="
    flex size-14 shrink-0 items-center justify-center
    rounded-2xl bg-background
    
  "
              >
                {orgType === 1001 ? (
                  <Building2
                    className="size-9 text-primary"
                    strokeWidth={1.5}
                  />
                ) : (
                  <BuildingComplex
                    className="size-9 text-primary"
                    strokeWidth={1.5}
                  />
                )}
              </div> */}

              <div className="min-w-0 space-y-2">
                <h2 className="text-lg font-bold tracking-tight sm:text-2xl">
                  {orgType === 1001
                    ? building.buildingName || "—"
                    : complex.orgName || "—"}
                </h2>

                <div className="flex flex-wrap items-center gap-x-3 gap-y-1 text-xs text-muted-foreground">
                  <span>
                    {orgType === 1001
                      ? t_building("standalone-building")
                      : t_building("residential-complex")}
                  </span>

                  <span className="size-1 rounded-full bg-muted-foreground/50" />

                  <span className="flex items-center gap-1">
                    <MapPin className="size-3.5" />
                    {locale === "fa"
                      ? currentGeo?.geoPathFa || currentGeo?.geoPathEn || "—"
                      : currentGeo?.geoPathEn || "—"}
                  </span>
                </div>
              </div>
            </div>

            {/* نام ساختمان‌های مجتمع */}
            {orgType === 1002 && complex.buildings.length > 0 && (
              <div className="flex flex-wrap items-center gap-2 border-t border-border/60 pt-3">
                <span className="flex items-center gap-1.5 text-xs text-muted-foreground">
                  <Building2 className="size-4" />
                  {t_building("residentialComplexBuildingListTitle")}
                </span>

                <div className="flex flex-wrap gap-2">
                  {complex.buildings.map((item) => (
                    <Badge
                      className="bg-[hsl(var(--brand-accent))] "
                      key={item.clientId}
                      // className="rounded-md bg-background px-3 py-1.5 text-sm font-medium shadow-sm"
                    >
                      {item.buildingName || "—"}
                    </Badge>
                  ))}
                </div>
              </div>
            )}

            {/* توضیحات */}
            <div className="border-t border-border/60 pt-3">
              <p className="mb-1 text-xs text-muted-foreground">
                {orgType === 1001
                  ? t_building("buildingDescription")
                  : t_building("residentialComplexDescription")}
              </p>

              <p className="whitespace-pre-wrap break-words text-sm leading-7">
                {orgType === 1001
                  ? building.buildingDescription || "—"
                  : complex.orgDesc || "—"}
              </p>
            </div>
          </div>
        </RaisedPanel>

        <Card className="neumorphic-raised">
          <CardContent className="space-y-4 p-5 sm:p-6">
            {/* عنوان راهنما */}
            <div className="mb-5 space-y-1">
              <h3 className="text-base font-semibold">
                {t_building("setupGuide.title")}
              </h3>
              <p className="text-sm leading-6 text-muted-foreground">
                {t_building("setupGuide.description")}
              </p>
            </div>

            <InsetPanel className="p-4">
              <VerticalStepper
                steps={[
                  {
                    title: t_setupGuide("steps.basicInfo.title"),
                    description: t_setupGuide("steps.basicInfo.description"),
                    icon: <FileText className="size-5 text-primary" />,
                    content: (
                      <div className="flex flex-wrap items-center justify-end ">
                        <Button
                          size="sm"
                          variant="outline"
                          onClick={() =>
                            router.push(`/${locale}/building/edit`)
                          }
                        >
                          <Pencil className="size-3.5" />
                          {t_setupGuide("actions.manage")}
                        </Button>
                      </div>
                    ),
                  },
                  {
                    title: t_setupGuide("steps.physicalStructure.title"),
                    description: t_setupGuide(
                      "steps.physicalStructure.description",
                    ),
                    icon: <Layers3 className="size-5 text-primary" />,
                    content: (
                      <div className="flex flex-wrap items-center justify-end ">
                        <Button
                          size="sm"
                          variant="outline"
                          onClick={() =>
                            router.push(`/${locale}/building/edit`)
                          }
                        >
                          <Pencil className="size-3.5" />
                          {t_setupGuide("actions.manage")}
                        </Button>
                      </div>
                    ),
                  },
                  {
                    title: t_setupGuide("steps.reservableSpaces.title"),
                    description: t_setupGuide(
                      "steps.reservableSpaces.description",
                    ),
                    icon: <CalendarCheck className="size-5 text-primary" />,
                    content: (
                      <div className="flex flex-wrap items-center justify-end ">
                        <Button
                          size="sm"
                          variant="outline"
                          onClick={() =>
                            router.push(`/${locale}/building/edit`)
                          }
                        >
                          <Pencil className="size-3.5" />
                          {t_setupGuide("actions.manage")}
                        </Button>
                      </div>
                    ),
                  },
                ]}
              />
            </InsetPanel>
          </CardContent>
        </Card>

        {/* /////////////////////////////////////////////////// */}
      </PageCard>
    </div>
  );
}
