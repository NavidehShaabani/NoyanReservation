export default async function Dashboard() {
  return (
    <div
      className="
           mx-2 md:ms-0
          mb-2
          flex
          flex-1 
          items-center
        "
    >
      <div
        className="
            w-full
            h-full  
            max-w-10xl
            rounded-[10px]
            bg-background
            shadow-[16px_16px_32px_rgba(209,207,204,0.55)]
            p-8 md:p-12
            flex
            flex-col
            gap-10
          "
      >
        {/* Header */}
        <div className="text-center">
          <h1 className="text-2xl font-medium text-foreground">Dashboard</h1>

          <p className="mt-2 text-sm text-muted-foreground">
            Manage your reservations and facilities
          </p>
        </div>

        {/* Cards */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {/* Card 1 */}
          <div
            className="
                min-h-44
                rounded-[28px]
                bg-background
                p-6

                neumorphic-raised

                flex
                flex-col
                justify-between

                transition-all
                duration-200

                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
              "
          >
            <span className="text-sm text-muted-foreground">Reservations</span>

            <span className="text-4xl font-medium text-primary">2313</span>

            <span className="text-xs text-muted-foreground">
              Total reservations
            </span>
          </div>

          {/* Card 2 */}
          <div
            className="
                min-h-44
                rounded-[28px]
                bg-background
                p-6

               neumorphic-raised

                flex
                flex-col
                justify-between

                transition-all
                duration-200

                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
              "
          >
            <span className="text-sm text-muted-foreground">Facilities</span>

            <span className="text-4xl font-medium text-primary">12</span>

            <span className="text-xs text-muted-foreground">
              Available facilities
            </span>
          </div>

          {/* Card 3 */}
          <div
            className="
                min-h-44
                rounded-[28px]
                bg-background
                p-6

                neumorphic-raised

                flex
                flex-col
                justify-between

                transition-all
                duration-200

                hover:shadow-[8px_8px_16px_#d1cfcc,-8px_-8px_16px_#ffffff]

                active:shadow-[inset_8px_8px_16px_#d1cfcc,inset_-8px_-8px_16px_#ffffff]
              "
          >
            <span className="text-sm text-muted-foreground">Users</span>

            <span className="text-4xl font-medium text-primary">48</span>

            <span className="text-xs text-muted-foreground">
              Registered users
            </span>
          </div>
        </div>
      </div>
    </div>
  );
}
