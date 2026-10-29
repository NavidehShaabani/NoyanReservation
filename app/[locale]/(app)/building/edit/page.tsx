"use client";
import { useState, useEffect, useContext } from "react";
import { useTranslations } from "next-intl";
import { createClientId } from "@/lib/create-client-id";
import { AuthContext } from "@/context/AuthProvider";
import BuildingType from "@/components/custom/building/BuildingForm";
import GeoSelector from "@/components/custom/GeoSelector";
import SingleBuildingFields from "@/components/custom/building/SingleBuildingFields";
import ResidentialComplexFields from "@/components/custom/building/ResidentialComplexFields";
import { Button } from "@/components/ui/button";
import type { BuildingDraft } from "@/components/custom/building/SingleBuildingFields";
import type { ComplexDraft } from "@/components/custom/building/ResidentialComplexFields";
import type { ComplexBuildingDraft } from "@/components/custom/building/ResidentialComplexFields";
import PageCard from "@/components/custom/PageCard";
import PageHeader from "@/components/custom/PageHeader";
import { Building2, Pencil } from "lucide-react";
export default function Building() {
  const { token, isAuthReady, user } = useContext(AuthContext);
  const t_building = useTranslations("building");
  const [orgType, setOrgType] = useState(1001);
  const [geoId, setGeoId] = useState("");
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
        console.log("user in Building:", user);
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
        setGeoId(orgData.geoId);
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

  useEffect(() => {
    console.log("complex updated:", complex);
  }, [complex]);

  const hanleSaveData = async () => {
    try {
      const isEditingOrg = complex.orgId > 0;

      const orgResponse = await fetch(
        isEditingOrg
          ? `http://10.208.8.91:5295/api/Organizations/${complex.orgId}`
          : "http://10.208.8.91:5295/api/Organizations",
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

      const buildingsToSave = orgType === 1001 ? [building] : complex.buildings;

      const buildingsPayload = buildingsToSave.map((item) => ({
        buildingId: item.buildingId ?? 0,
        buildingName: item.buildingName,
        buildingAddress: item.buildingAddress,
        buildingDescription: item.buildingDescription,
        isActive: true,
        orgId: complex.orgId,
      }));

      const buildingsResponse = await fetch(
        "http://10.208.8.91:5295/api/Buildings/BulkSave",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          credentials: "include",
          body: JSON.stringify({
            buildings: buildingsPayload,
          }),
        },
      );
      console.log("Buildings response:", buildingsResponse.status);
      if (!buildingsResponse.ok) {
        const errorBody = await buildingsResponse.text();
        throw new Error(
          `Request failed: ${buildingsResponse.status} - ${errorBody}`,
        );
      }

      const getAfterSaveBuildingsResponse = await fetch(
        `http://10.208.8.91:5295/api/Buildings/by-org/${complex.orgId}`,
        {
          method: "GET",
          credentials: "include",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        },
      );

      if (!getAfterSaveBuildingsResponse.ok) {
        throw new Error(
          `Failed to reload buildings: ${getAfterSaveBuildingsResponse.status}`,
        );
      }

      const getAfterSaveBuildingsData =
        await getAfterSaveBuildingsResponse.json();

      const savedBuildings: ComplexBuildingDraft[] =
        getAfterSaveBuildingsData.data.map((item: BuildingDraft) => ({
          buildingId: item.buildingId,
          buildingName: item.buildingName,
          buildingAddress: item.buildingAddress,
          buildingDescription: item.buildingDescription,
          clientId: createClientId(),
        }));

      setComplex((prev) => ({
        ...prev,
        buildings: savedBuildings,
      }));

      if (orgType === 1001 && savedBuildings.length > 0) {
        setBuilding(savedBuildings[0]);
      }
    } catch (error) {
      console.error("Failed to save organization or buildings:", error);
    }
  };

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
          className="mb-4 "
        />

        <GeoSelector geoId={geoId} onGeoIdChange={setGeoId} />
        <BuildingType orgType={orgType} onOrgTypeChange={setOrgType} />
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
          />
        )}

        <Button className="px-2" onClick={hanleSaveData}>
          {t_building("save")}
        </Button>
      </PageCard>
    </div>
  );
}
