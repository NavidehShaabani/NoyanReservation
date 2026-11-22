"use client";
import { useState, useEffect, useContext, useCallback } from "react";
import { apiUrl } from "@/lib/api/config";
import { useTranslations } from "next-intl";
import { createClientId } from "@/lib/create-client-id";
import InsetPanel from "@/components/custom/InsetPanel";
import { AuthContext } from "@/context/AuthProvider";
// import BuildingType from "@/components/custom/building/BuildingType";
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import GeoSelector from "@/components/custom/GeoSelector";
import SingleBuildingFields from "@/components/custom/building/SingleBuildingFields";
import ResidentialComplexFields from "@/components/custom/building/ResidentialComplexFields";
import { Button } from "@/components/ui/button";
import type { BuildingDraft } from "@/components/custom/building/SingleBuildingFields";
import type { ComplexDraft } from "@/components/custom/building/ResidentialComplexFields";
//import type { ComplexBuildingDraft } from "@/components/custom/building/ResidentialComplexFields";
import PageCard from "@/components/custom/PageCard";
import PageHeader from "@/components/custom/PageHeader";
import { Building2, Pencil, AlertCircleIcon } from "lucide-react";
import ErrorState from "@/components/custom/feedback/ErrorState";

function SkeletonBox({ className = "" }) {
  return <div className={`animate-pulse rounded-md bg-muted ${className}`} />;
}
function BuildingSkeleton() {
  return (
    <div className="mx-2 mb-2 flex flex-1 flex-col gap-4">
      <PageCard contentClassName="gap-4 p-8 md:p-12">
        {/* Page Header */}
        <div className="mb-4 flex items-center gap-3">
          {/* Icon */}
          <SkeletonBox className="size-10 shrink-0 rounded-lg" />

          {/* Title and Description */}
          <div className="flex flex-1 flex-col gap-3">
            <SkeletonBox className="h-6 w-1/3" />
            <SkeletonBox className="h-4 w-1/3" />
          </div>
        </div>

        {/* Geo Selector */}
        <InsetPanel className="p-4 sm:p-6 md:p-10">
          {/* Title and Description */}
          <div className="mb-7 space-y-3">
            <SkeletonBox className="h-6 w-1/3" />
            <SkeletonBox className="h-4 w-2/3" />
          </div>

          {/* Select Fields */}
          <div className="flex flex-col gap-4 sm:flex-row sm:gap-3">
            <div className="flex-1 space-y-2">
              <SkeletonBox className="h-4 w-16" />
              <SkeletonBox className="h-10 w-full" />
            </div>

            <div className="flex-1 space-y-2">
              <SkeletonBox className="h-4 w-16" />
              <SkeletonBox className="h-10 w-full" />
            </div>

            <div className="flex-1 space-y-2">
              <SkeletonBox className="h-4 w-16" />
              <SkeletonBox className="h-10 w-full" />
            </div>
          </div>
        </InsetPanel>

        {/* Building Type */}
        <InsetPanel className="p-10">
          {/* Title and Description */}
          <div className="mb-7 space-y-3">
            <SkeletonBox className="h-6 w-1/3" />
            <SkeletonBox className="h-4 w-2/3" />
          </div>

          {/* Building Type Cards */}
          <div className="grid grid-cols-1 gap-3 md:grid-cols-2 sm:gap-4">
            {/* First Card */}
            <div className="flex min-h-36 overflow-hidden rounded-xl">
              <SkeletonBox className="w-20 shrink-0 self-stretch sm:w-32" />

              <div className="flex flex-1 flex-col justify-center gap-3 p-3">
                <SkeletonBox className="h-5 w-2/3" />
                <SkeletonBox className="h-4 w-full" />
                <SkeletonBox className="h-4 w-4/5" />
              </div>

              <div className="flex items-center justify-center p-2">
                <SkeletonBox className="size-7 rounded-full" />
              </div>
            </div>

            {/* Second Card */}
            <div className="flex min-h-36 overflow-hidden rounded-xl">
              <SkeletonBox className="w-20 shrink-0 self-stretch sm:w-32" />

              <div className="flex flex-1 flex-col justify-center gap-3 p-3">
                <SkeletonBox className="h-5 w-2/3" />
                <SkeletonBox className="h-4 w-full" />
                <SkeletonBox className="h-4 w-4/5" />
              </div>

              <div className="flex items-center justify-center p-2">
                <SkeletonBox className="size-7 rounded-full" />
              </div>
            </div>
          </div>
        </InsetPanel>

        {/* Single Building Fields */}
        <InsetPanel className="p-10">
          {/* Title and Description */}
          <div className="mb-7 space-y-3">
            <SkeletonBox className="h-6 w-1/3" />
            <SkeletonBox className="h-4 w-2/3" />
          </div>

          {/* Building Name */}
          <div className="mb-4 space-y-2">
            <SkeletonBox className="h-4 w-24" />
            <SkeletonBox className="h-10 w-full" />
          </div>

          {/* Address and Description */}
          <div className="flex flex-col gap-4 md:flex-row">
            <div className="flex-1 space-y-2">
              <SkeletonBox className="h-4 w-20" />
              <SkeletonBox className="h-20 w-full" />
            </div>

            <div className="flex-1 space-y-2">
              <SkeletonBox className="h-4 w-20" />
              <SkeletonBox className="h-20 w-full" />
            </div>
          </div>
        </InsetPanel>
      </PageCard>
    </div>
  );
}

export default function Building() {
  const { token, isAuthReady, user } = useContext(AuthContext);
  const t_building = useTranslations("building");
  const t_common = useTranslations("common");
  const [orgType, setOrgType] = useState(1001);
  const [geoId, setGeoId] = useState("");
  const [isLoading, setIsLoading] = useState(true);
  const [loadError, setLoadError] = useState<string | null>(null);
  const [error, setError] = useState<string | null>(null);
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
    if (!isAuthReady || !token) return;

    setIsLoading(true);
    setLoadError(null);
    try {
      console.log("user in Building:", user);
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
      setGeoId(orgData.geoId);
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

      const buildings: BuildingDraft[] = buildingResponselist.data.map(
        (item: BuildingDraft) => ({
          buildingId: item.buildingId,
          buildingName: item.buildingName,
          buildingAddress: item.buildingAddress,
          buildingDescription: item.buildingDescription,
          //clientId: createClientId(),
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
      setLoadError(error instanceof Error ? error.message : "UNKNOWN_ERROR");
    } finally {
      setIsLoading(false);
    }
  }, [isAuthReady, token, user?.orgId]);

  useEffect(() => {
    getOrgData();
  }, [getOrgData]);

  useEffect(() => {
    console.log("complex updated:", complex);
  }, [complex]);

  function mapBuildingResponse(data: any): BuildingDraft {
    return {
      buildingId: data.buildingId,
      buildingName: data.buildingName,
      buildingAddress: data.buildingAddress,
      buildingDescription: data.buildingDescription,
      isActive: data.isActive,
      orgId: complex.orgId,
    };
  }

  const AddEditBuilding = async (buildingData: BuildingDraft) => {
    try {
      const addEditResponse = await fetch(
        buildingData.buildingId
          ? apiUrl(`/api/Buildings/${buildingData.buildingId}`)
          : apiUrl(`/api/Buildings`),
        {
          method: buildingData.buildingId ? "PUT" : "POST",
          credentials: "include",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          body: JSON.stringify({
            buildingName: buildingData.buildingName,
            buildingAddress: buildingData.buildingAddress,
            buildingDescription: buildingData.buildingDescription,
            isActive: buildingData.isActive,
            orgId: user?.orgId,
          }),
        },
      );

      if (!addEditResponse.ok) {
        const errorBody = await addEditResponse.text();

        console.error(
          "Add Edit Building Error:",
          addEditResponse.status,
          errorBody,
        );

        setError("AddEditBuildingFailed");
        return null;
      }

      const addEditRet = await addEditResponse.json();

      return mapBuildingResponse(addEditRet.data);
    } catch (error) {
      console.error("Add Edit Building Error:", error);
      setError("AddEditBuildingFailed");
      return null;
    }
  };

  const hanleSaveData = async () => {
    setError(null);

    try {
      const isEditingOrg = complex.orgId > 0;

      const orgResponse = await fetch(
        isEditingOrg
          ? apiUrl(`/api/Organizations/${complex.orgId}`)
          : apiUrl("/api/Organizations"),
        {
          method: isEditingOrg ? "PUT" : "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          credentials: "include",
          body: JSON.stringify({
            orgName: complex.orgName,
            orgDesc: complex.orgDesc,
            orgType,
            isActive: complex.isActive,
            geoId,
          }),
        },
      );

      console.log("Organization response:", orgResponse.status);

      if (!orgResponse.ok) {
        const errorBody = await orgResponse.text();
        throw new Error(`Request failed: ${orgResponse.status} - ${errorBody}`);
      }

      // ذخیره ساختمان فقط برای سازمان تک‌ساختمانی
      if (orgType === 1001) {
        const savedBuilding = await AddEditBuilding(building);

        if (!savedBuilding) {
          throw new Error("AddEditBuildingFailed");
        }

        setBuilding(savedBuilding);
      }
    } catch (error) {
      console.error("Failed to save organization or building:", error);
      setError(
        error instanceof Error ? error.message : "SaveOrganizationFailed",
      );
    }
  };

  const handleSaveBuilding = async (buildingData: BuildingDraft) => {
    setError(null);

    const savedBuilding = await AddEditBuilding(buildingData);

    if (!savedBuilding) {
      throw new Error("AddEditBuildingFailed");
    }

    if (buildingData.buildingId) {
      // ویرایش ساختمان موجود
      setComplex((prev) => ({
        ...prev,
        buildings: prev.buildings.map((item) =>
          item.buildingId === savedBuilding.buildingId ? savedBuilding : item,
        ),
      }));
    } else {
      // اضافه کردن ساختمان جدید
      setComplex((prev) => ({
        ...prev,
        buildings: [...prev.buildings, savedBuilding],
      }));
    }
  };

  const handleDeleteBuilding = async (buildingData: BuildingDraft) => {
    if (!buildingData.buildingId) return;

    setError(null);

    try {
      const response = await fetch(
        apiUrl(`/api/Buildings/${buildingData.buildingId}`),
        {
          method: "DELETE",
          credentials: "include",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        },
      );

      if (!response.ok) {
        const errorBody = await response.text();
        console.error("Delete Building Error:", response.status, errorBody);

        setError("DeleteBuildingFailed");
        throw new Error("DeleteBuildingFailed");
      }

      setComplex((prev) => ({
        ...prev,
        buildings: prev.buildings.filter(
          (item) => item.buildingId !== buildingData.buildingId,
        ),
      }));
    } catch (error) {
      console.error("Delete Building Error:", error);
      setError("DeleteBuildingFailed");
      throw error;
    }
  };

  if (isLoading) {
    return <BuildingSkeleton />;
  }

  if (loadError) {
    return (
      <ErrorState
        title={t_common("error.loadTitle")}
        description={t_common("error.loadDescription")}
        retryLabel={t_common("error.retry")}
        onRetry={() => getOrgData()}
      />
    );
  }

  return (
    <div
      className="
            mx-2 md:ms-0 mb-2 flex min-h-0 flex-1 flex-col
        "
    >
      <PageCard contentClassName="gap-y-4 p-8 md:p-12">
        <PageHeader
          title={
            orgType === 1001
              ? t_building("singleBuildingTypeTitle")
              : t_building("residentialComplexFormTitle")
          }
          description={
            orgType === 1001
              ? t_building("singleBuildingTypeDesc")
              : t_building("residentialComplexFormDesc")
          }
          icon={<Building2 className="size-5" />}
          backHref="/building"
          backLabel={t_building("backToBuildings")}
          className="mb-4 "
        />

        <GeoSelector geoId={geoId} onGeoIdChange={setGeoId} />
        {/* <BuildingType orgType={orgType} onOrgTypeChange={setOrgType} /> */}
        {orgType === 1001 && (
          <SingleBuildingFields
            building={building}
            onBuildingChange={setBuilding}
          />
        )}
        {orgType === 1002 && (
          <ResidentialComplexFields
            complex={complex}
            onComplexChange={setComplex}
            onSaveBuilding={handleSaveBuilding}
            onDeleteBuilding={handleDeleteBuilding}
          />
        )}

        <Button className="px-2" onClick={hanleSaveData}>
          {t_building("save")}
        </Button>

        {error && (
          <Alert
            variant="destructive"
            className="neumorphic-alert mt-2 md:mt-8 "
          >
            <AlertCircleIcon />
            <AlertTitle>{t_building("error")}</AlertTitle>
            <AlertDescription>{t_building(`errors.${error}`)}</AlertDescription>
          </Alert>
        )}
      </PageCard>
    </div>
  );
}
