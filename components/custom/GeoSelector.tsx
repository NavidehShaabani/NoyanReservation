"use client";
import { useState, useEffect, useContext } from "react";
import { FieldGroup, FieldLabel, Field } from "../ui/field";
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from "../ui/select";
import { useTranslations } from "next-intl";
import { AuthContext } from "@/context/AuthProvider";
import { useLocale } from "next-intl";

type GeoItem = {
  geoId: string;
  geoNameFa: string | null;
  geoNameEn: string | null;
  pL1: string | null;
  pL2: string | null;
  geoType: number;
};
type Locale = "fa" | "en";

export type GeoSelection = {
  geoId: string;
  pL1: string | null;
  pL2: string | null;
  geoType: number;
};
type geoProps = {
  geo: GeoSelection | null;
  onGeoChange: (value: GeoSelection) => void;
};
export default function Geo({ geo, onGeoChange }: geoProps) {
  const { token, isAuthReady } = useContext(AuthContext);
  const [countryId, setCountryId] = useState("");
  const [regionId, setRegionId] = useState("");
  const [cityId, setCityId] = useState("");
  const t = useTranslations("geo");
  const locale = useLocale() as Locale;
  const [countryList, setCountryList] = useState<GeoItem[]>([]);
  const [regionList, setRegionList] = useState<GeoItem[]>([]);
  const [cityList, setCityList] = useState<GeoItem[]>([]);

  useEffect(() => {
    async function getCountry() {
      if (!isAuthReady || !token) return;
      try {
        const countryResponse = await fetch(
          "http://10.208.8.91:5295/api/Geo/children?GeoType=1",
          {
            method: "GET",
            credentials: "include",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          },
        );

        if (!countryResponse.ok) {
          throw new Error(`Request failed: ${countryResponse.status}`);
        }
        const countryResponselist = await countryResponse.json();
        setCountryList(countryResponselist.data);
        if (locale === "fa") {
          setCountryId("01");

          handleCountryChange("01");
        }
      } catch (error) {
        console.error("Failed to load countries:", error);
      }
    }

    getCountry();
  }, [isAuthReady, token]);

  async function getRegionList(value: string) {
    try {
      const regionResponse = await fetch(
        `http://10.208.8.91:5295/api/Geo/children?GeoType=2&ParentGeoId=${encodeURIComponent(value)}`,
        {
          method: "GET",
          credentials: "include",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        },
      );
      if (!regionResponse.ok) {
        const errorBody = await regionResponse.text();
        throw new Error(
          `Request failed: ${regionResponse.status} - ${errorBody}`,
        );
      }
      const regionResponseList = await regionResponse.json();

      if (!Array.isArray(regionResponseList.data)) {
        throw new Error("Geo API did not return a region list.");
      }

      setRegionList(regionResponseList.data);
    } catch (error) {
      console.error("Failed to load regions:", error);
      setRegionList([]);
    }
  }

  const handleCountryChange = (value: string) => {
    setCountryId(value);
    setRegionId("");
    setCityId("");
    setRegionList([]);
    getRegionList(value);
  };

  async function getCityList(value: string) {
    try {
      const cityResponse = await fetch(
        `http://10.208.8.91:5295/api/Geo/children?GeoType=3&ParentGeoId=${encodeURIComponent(value)}`,
        {
          method: "GET",
          credentials: "include",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        },
      );

      if (!cityResponse.ok) {
        const errorBody = await cityResponse.text();
        throw new Error(
          `Request failed: ${cityResponse.status} - ${errorBody}`,
        );
      }
      const cityResponseList = await cityResponse.json();

      if (!Array.isArray(cityResponseList.data)) {
        throw new Error("Geo API did not return a city list.");
      }

      setCityList(cityResponseList.data);
      console.log("city list ", cityResponseList.data);
    } catch (error) {
      console.error("Failed to load cites:", error);
      setCityList([]);
    }
  }

  const handleRegionChange = (value: string) => {
    setRegionId(value);
    setCityId("");
    setCityList([]);
    getCityList(value);
  };
  const handleCityChange = (value: string) => {
    setCityId(value);

    const selectedCity = cityList.find((city) => city.geoId === value);
    if (!selectedCity) return;
    onGeoChange({
      geoId: selectedCity.geoId,
      pL1: selectedCity.pL1,
      pL2: selectedCity.pL2,
      geoType: selectedCity.geoType,
    });
  };
  return (
    <div
      className="   rounded-[10px]
            bg-background
              shadow-[inset_5px_5px_11px_#d6d4d1,inset_-5px_-5px_11px_#ffffff] p-4 sm:p-6 md:p-10"
    >
      <div className="text-start pb-7">
        <h1 className="text-xl font-medium text-foreground">
          {t("geoFormTitle")}
        </h1>

        <p className="mt-2 text-sm text-muted-foreground">
          {t("geoFormDescription")}
        </p>
      </div>

      <div className="">
        <FieldGroup className="flex flex-col sm:flex-row gap-4 sm:gap-3">
          <Field>
            <FieldLabel htmlFor="fieldGroup_country">
              {t("countrySelectLabel")}
            </FieldLabel>
            <Select
              value={countryId}
              onValueChange={handleCountryChange}
              disabled={locale === "fa"}
            >
              <SelectTrigger
                id="fieldGroup_country"
                className={`
                        
              border-none
              rounded-[7px]  
              bg-surface
              shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
              focus-visible:ring-1
              focus-visible:ring-primary/30  
                                `}
              >
                <SelectValue placeholder={t("countrySelectPlaceholder")} />
              </SelectTrigger>
              <SelectContent>
                {countryList.map((country) => (
                  <SelectItem key={country.geoId} value={country.geoId}>
                    {locale === "fa" ? country.geoNameFa : country.geoNameEn}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </Field>

          <Field>
            <FieldLabel htmlFor="fieldGroup_region">
              {t("regionSelectLabel")}
            </FieldLabel>
            <Select
              value={regionId}
              onValueChange={handleRegionChange}
              disabled={!countryId}
            >
              <SelectTrigger
                id="fieldGroup_region"
                className={`   
              border-none
              rounded-[7px]  
              bg-surface
              shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
              focus-visible:ring-1
              focus-visible:ring-primary/30  
                                `}
              >
                <SelectValue placeholder={t("regionSelectPlaceholder")} />
              </SelectTrigger>
              <SelectContent>
                {regionList.map((region) => (
                  <SelectItem key={region.geoId} value={region.geoId}>
                    {locale === "fa" ? region.geoNameFa : region.geoNameEn}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </Field>

          <Field>
            <FieldLabel htmlFor="fieldGroup_city">
              {t("citySelectLabel")}
            </FieldLabel>
            <Select
              value={cityId}
              onValueChange={handleCityChange}
              disabled={!regionId}
            >
              <SelectTrigger
                id="fieldGroup_city"
                className={`
                        
              border-none
              rounded-[7px]  
              bg-surface
              shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
              focus-visible:ring-1
              focus-visible:ring-primary/30  
                                `}
              >
                <SelectValue placeholder={t("citySelectPlaceholder")} />
              </SelectTrigger>
              <SelectContent>
                {cityList.map((city) => (
                  <SelectItem key={city.geoId} value={city.geoId}>
                    {locale === "fa" ? city.geoNameFa : city.geoNameEn}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </Field>
        </FieldGroup>
      </div>
    </div>
  );
}
