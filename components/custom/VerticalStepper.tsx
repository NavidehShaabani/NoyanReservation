import type { ReactNode } from "react";

type Step = {
  title: string;
  description?: string;
  icon?: ReactNode;
  content?: ReactNode;
  action?: ReactNode;
};

type VerticalStepperProps = {
  steps: Step[];
};

export default function VerticalStepper({ steps }: VerticalStepperProps) {
  return (
    <div className="flex flex-col">
      {steps.map((step, index) => (
        <div key={index} className="flex gap-3">
          {/* ستون شماره و خط اتصال */}
          <div className="flex w-8 shrink-0 flex-col items-center">
            <div className="relative z-10 flex size-8 shrink-0 items-center justify-center rounded-full border-2 border-primary bg-background text-sm font-semibold text-primary">
              {index + 1}
            </div>

            {index < steps.length - 1 && (
              <div aria-hidden="true" className="w-0.5 flex-1 bg-primary/50" />
            )}
          </div>

          {/* محتوای مرحله */}
          <div className="min-w-0 flex-1 pb-6">
            <div className="flex flex-col gap-3 sm:flex-row sm:items-center sm:justify-between">
              {/* عنوان و توضیحات */}
              <div className="min-w-0">
                <div className="flex min-h-8 items-center gap-2">
                  {step.icon}
                  <h4 className="text-sm font-semibold">{step.title}</h4>
                </div>

                {step.description && (
                  <p className="mt-1 text-xs leading-6 text-muted-foreground">
                    {step.description}
                  </p>
                )}
              </div>

              {/* دکمه */}
              {step.action && <div className="shrink-0">{step.action}</div>}
            </div>

            {step.content && <div className="mt-1">{step.content}</div>}

            {index < steps.length - 1 && (
              <div className="mt-5 border-b border-border/70" />
            )}
          </div>
        </div>
      ))}
    </div>
  );
}
