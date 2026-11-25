import { AlertCircle, RefreshCw } from "lucide-react";
import { Button } from "@/components/ui/button";
import PageCard from "@/components/custom/PageCard";

type ErrorStateProps = {
  title: string;
  description: string;
  retryLabel: string;
  onRetry: () => void;
};

export default function ErrorState({
  title,
  description,
  retryLabel,
  onRetry,
}: ErrorStateProps) {
  return (
    <div className="mx-2 mb-2 flex min-h-0 flex-1 items-center justify-center md:ms-0">
      <PageCard contentClassName="items-center gap-4 p-8 text-center md:p-12">
        <div className="flex size-14 items-center justify-center rounded-full bg-destructive/10 text-destructive">
          <AlertCircle className="size-7" />
        </div>

        <div className="space-y-2">
          <h2 className="text-lg font-semibold">{title}</h2>
          <p className="text-sm text-muted-foreground">{description}</p>
        </div>

        <Button onClick={onRetry}>
          <RefreshCw className="me-2 size-4" />
          {retryLabel}
        </Button>
      </PageCard>
    </div>
  );
}
