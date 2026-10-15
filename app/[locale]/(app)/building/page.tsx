"use client";
import { useState } from "react";
import BuildingForm from "@/components/custom/building/BuildingForm";
import Geo from "@/components/custom/GeoSelector";
import SingleBuildingFields from "@/components/custom/building/SingleBuildingFields";
import ResidentialComplexFields from "@/components/custom/building/ResidentialComplexFields";
import type { GeoSelection } from "@/components/custom/GeoSelector";
export default function Building() {
  const [orgType, setOrgType] = useState("1");
  // const [geoId, setGeoId] = useState("");
  const [geo, setGeo] = useState<GeoSelection | null>(null);
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
  p-8 shadow-[16px_16px_32px_rgba(209,207,204,0.55)] md:p-12
          "
      >
        <Geo geo={geo} onGeoChange={setGeo} />
        <BuildingForm orgType={orgType} onOrgTypeChange={setOrgType} />
        {orgType === "1" && <SingleBuildingFields />}
        {orgType === "2" && <ResidentialComplexFields />}
      </div>
    </div>
  );
}
