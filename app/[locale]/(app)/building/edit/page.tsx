"use client";
import { useState, useEffect, useContext } from "react";
import { createClientId } from "@/lib/create-client-id";
import { AuthContext } from "@/context/AuthProvider";
import BuildingType from "@/components/custom/building/BuildingForm";
import GeoSelector from "@/components/custom/GeoSelector";
import SingleBuildingFields from "@/components/custom/building/SingleBuildingFields";
import ResidentialComplexFields from "@/components/custom/building/ResidentialComplexFields";

import type { BuildingDraft } from "@/components/custom/building/SingleBuildingFields";
import type { ComplexDraft } from "@/components/custom/building/ResidentialComplexFields";
import type { ComplexBuildingDraft } from "@/components/custom/building/ResidentialComplexFields";
export default function Building() {
  const { token, isAuthReady, user } = useContext(AuthContext);
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

  return (
    <div
      className="
            mx-2 md:ms-0 mb-2 flex min-h-0 flex-1 flex-col
        "
    >
      <div
        className="
           flex min-h-0 w-full max-w-10xl flex-1 flex-col
  overflow-y-auto page-scrollbar rounded-[10px] bg-background
  p-8 shadow-[16px_16px_32px_rgba(209,207,204,0.55)] md:p-12 gap-y-4
          "
      >
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
      </div>
    </div>
  );
}
