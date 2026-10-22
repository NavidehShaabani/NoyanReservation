import { useState } from "react";
import { FieldGroup, FieldLabel, Field } from "@/components/ui/field";
import { createClientId } from "@/lib/create-client-id";
import { Plus } from "lucide-react";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { Separator } from "@/components/ui/separator";
import { useTranslations } from "next-intl";
import { Building, Pencil, Trash } from "lucide-react";
import SingleBuildingFields from "./SingleBuildingFields";
import { Button } from "@/components/ui/button";
import {
  Sheet,
  SheetClose,
  SheetContent,
  SheetDescription,
  SheetFooter,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from "@/components/ui/sheet";
import {
  Card,
  CardAction,
  CardDescription,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
} from "@/components/ui/alert-dialog";
import type { BuildingDraft } from "./SingleBuildingFields";
export type ComplexBuildingDraft = BuildingDraft & {
  clientId: string;
};
export type ComplexDraft = {
  orgName: string;
  orgDesc: string;
  orgId: number;
  orgType: number;
  isActive: boolean;
  buildings: ComplexBuildingDraft[];
};
type ComplexProps = {
  complex: ComplexDraft;
  onComplexChange: (value: ComplexDraft) => void;
};

export default function ResidentialComplexFields({
  complex,
  onComplexChange,
}: ComplexProps) {
  const t = useTranslations("building");

  const [isSheetOpen, setIsSheetOpen] = useState(false);

  const [selectedBuilding, setSelectedBuilding] =
    useState<ComplexBuildingDraft | null>(null);
  const [editingBuilding, setEditingBuilding] =
    useState<ComplexBuildingDraft | null>(null);
  const [buildingToDelete, setBuildingToDelete] =
    useState<ComplexBuildingDraft | null>(null);

  function handleAddEditBuilding() {
    if (editingBuilding === null) return;

    if (selectedBuilding === null) {
      onComplexChange({
        ...complex,
        buildings: [...complex.buildings, editingBuilding],
      });
    } else {
      onComplexChange({
        ...complex,
        buildings: complex.buildings.map((building) =>
          building.clientId === editingBuilding.clientId
            ? editingBuilding
            : building,
        ),
      });
    }

    setIsSheetOpen(false);
    setSelectedBuilding(null);
    setEditingBuilding(null);
  }
  function handleConfirmDelete() {
    if (!buildingToDelete) return;

    onComplexChange({
      ...complex,
      buildings: complex.buildings.filter(
        (building) => building.clientId !== buildingToDelete.clientId,
      ),
    });

    setBuildingToDelete(null);
  }
  const handleBuildingChange = (updatedBuilding: BuildingDraft) => {
    setEditingBuilding((prev) => {
      if (!prev) return null;

      return {
        ...updatedBuilding,
        clientId: prev.clientId,
      };
    });
  };

  return (
    <div
      className="   rounded-[10px]
            bg-background
              shadow-[inset_5px_5px_11px_#d6d4d1,inset_-5px_-5px_11px_#ffffff] p-10   "
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
            value={complex.orgName}
            onChange={(e) => {
              onComplexChange({ ...complex, orgName: e.target.value });
            }}
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
            value={complex.orgDesc}
            onChange={(e) => {
              onComplexChange({ ...complex, orgDesc: e.target.value });
            }}
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

      <Card
        className={`
          
                pt-0
                pb-0
                mt-5

                relative//

                flex flex-col 
                items-stretch //
                gap-2
                w-full min-w-0 
                overflow-hidden

                bg-background
                shadow-[12px_12px_24px_#d1cfcc,-12px_-12px_24px_#ffffff]
                min-h-36 

            `}
      >
        <CardHeader className="min-w-0 flex-1 gap-1 px-3 py-3 sm:px-4">
          <CardTitle>{t("residentialComplexBuildingListTitle")}</CardTitle>
          <CardDescription className="line-clamp-3">
            {t("residentialComplexBuildingListDesc")}
          </CardDescription>
          <CardAction>
            <Button
              type="button"
              variant="default"
              onClick={() => {
                setSelectedBuilding(null);
                setEditingBuilding({
                  clientId: createClientId(),
                  buildingId: null,
                  buildingName: "",
                  buildingAddress: "",
                  buildingDescription: "",
                  isActive: true,
                  orgId: 0,
                });
                setIsSheetOpen(true);
              }}
            >
              <Plus data-icon="inline-start" />{" "}
              {t("residentialComplexNewBuildingButton")}
            </Button>
          </CardAction>
        </CardHeader>
        <CardContent className="flex flex-col">
          {complex.buildings.map((building, index) => (
            <div key={building.clientId}>
              <div className="flex items-center gap-3 py-3">
                <Building className="size-5 shrink-0" />

                <div className="min-w-0 flex-1">
                  <p className="font-medium">{building.buildingName}</p>
                  <p className="text-sm text-muted-foreground">
                    {building.buildingDescription}
                  </p>
                </div>

                <Button
                  type="button"
                  variant="ghost"
                  size="icon"
                  aria-label={`Edit ${building.buildingName}`}
                  onClick={() => {
                    setSelectedBuilding(building);
                    setEditingBuilding({ ...building });
                    setIsSheetOpen(true);
                  }}
                >
                  <Pencil className="size-4" />
                </Button>

                <Button
                  type="button"
                  variant="ghost"
                  size="icon"
                  aria-label={`Delete ${building.buildingName}`}
                  onClick={() => setBuildingToDelete(building)}
                >
                  <Trash className="size-4 text-destructive" />
                </Button>
              </div>

              {index < complex.buildings.length - 1 && <Separator />}
            </div>
          ))}
        </CardContent>
      </Card>

      <Sheet open={isSheetOpen} onOpenChange={setIsSheetOpen}>
        <SheetContent
          side="right"
          className="w-full overflow-y-auto sm:max-w-lg px-2 md:px-4"
        >
          <SheetHeader>
            <SheetTitle>{t("singleBuildingTypeTitle")}</SheetTitle>

            <SheetDescription>
              {selectedBuilding?.buildingName
                ? `${selectedBuilding.buildingName} — ${t("singleBuildingTypeDesc")}`
                : t("singleBuildingTypeDesc")}
            </SheetDescription>
          </SheetHeader>
          {editingBuilding && (
            <SingleBuildingFields
              building={editingBuilding}
              onBuildingChange={handleBuildingChange}
            />
          )}
          <Button type="button" onClick={handleAddEditBuilding}>
            {t("residentialComplexSaveBuildingButton")}
          </Button>
        </SheetContent>
      </Sheet>

      <AlertDialog
        open={buildingToDelete !== null}
        onOpenChange={(open) => {
          if (!open) setBuildingToDelete(null);
        }}
      >
        <AlertDialogContent>
          <AlertDialogHeader>
            <AlertDialogTitle>
              {t("residentialComplexDelBuildingTitle")}
            </AlertDialogTitle>

            <AlertDialogDescription>
              {t("residentialComplexDelBuildingdesc1")}«
              {buildingToDelete?.buildingName}»{" "}
              {t("residentialComplexDelBuildingdesc2")}
            </AlertDialogDescription>
          </AlertDialogHeader>

          <AlertDialogFooter>
            <AlertDialogCancel>
              {t("residentialComplexCancelButton")}
            </AlertDialogCancel>

            <AlertDialogAction
              onClick={handleConfirmDelete}
              className="bg-destructive text-white hover:bg-destructive/90"
            >
              {t("residentialComplexDelBuildingButton")}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
}
