export default function Dashboard() {
  return (
    <div className="bg-[#eef2f3] p-10">
      <div
        className="
    w-64 h-40 rounded-3xl
    bg-[#ecf0f3]
    shadow-[18px_18px_30px_#d1d9e6,-18px_-18px_30px_#fff]
  "
      />

      <br />
      <div
        className="
    w-64 h-40 rounded-3xl
    bg-[#ecf0f3]
    shadow-[inset_18px_18px_30px_#d1d9e6,inset_-18px_-18px_30px_#fff]
  "
      />
      <br />
      <div
        className=" w-64 h-40 
    rounded-3xl
    bg-[#eef1f4]
    shadow-[10px_10px_22px_rgba(163,174,187,0.38),-8px_-8px_20px_rgba(255,255,255,0.9)]
  "
      ></div>

      <br />

      <div
        className=" w-64 h-40 
    rounded-2xl
    bg-[#eef1f4]
    shadow-[inset_6px_6px_14px_rgba(163,174,187,0.28),inset_-6px_-6px_14px_rgba(255,255,255,0.9)]
  "
      ></div>

      <br />

      <div
        className="
    w-64 h-40 rounded-3xl
    bg-[#eef1f4]
    shadow-[inset_8px_8px_18px_rgba(163,174,187,0.25),inset_-8px_-8px_18px_rgba(255,255,255,0.9)]
    p-5
  "
      >
        <div
          className="
      h-full w-full rounded-2xl
      bg-[#eef1f4]
      shadow-[6px_6px_14px_rgba(163,174,187,0.28),-6px_-6px_14px_rgba(255,255,255,0.9)]
    "
        />
      </div>

      <br />

      <div
        className="
    w-72 rounded-3xl
    bg-[#eef1f4]
    p-6
    shadow-[10px_10px_22px_rgba(163,174,187,0.32),-8px_-8px_20px_rgba(255,255,255,0.95)]
  "
      >
        <div className="mb-5 flex items-center justify-between">
          <span className="text-sm text-slate-500">Today's reservations</span>

          <div
            className="
        flex h-10 w-10 items-center justify-center rounded-xl
        bg-[#eef1f4]
        shadow-[4px_4px_9px_rgba(163,174,187,0.28),-4px_-4px_9px_rgba(255,255,255,0.9)]
      "
          >
            📅
          </div>
        </div>

        <div className="text-4xl font-bold text-slate-700">12</div>

        <div className="mt-2 text-sm text-slate-400">3 more than yesterday</div>
      </div>

      <br />

      <div
        className="
  rounded-xl 
  w-64 h-40 
bg-[#eef2f3]
shadow-[6px_6px_16px_rgba(163,177,198,0.24),_-6px_-6px_16px_rgba(255,255,255,0.8)]
"
      ></div>
    </div>
  );
}
