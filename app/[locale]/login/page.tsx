"use client";
import { useState, type SyntheticEvent, useContext } from "react";
import { useTranslations, useLocale } from "next-intl";
import {
  Field,
  FieldDescription,
  FieldError,
  FieldGroup,
  FieldLabel,
} from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { AlertCircleIcon } from "lucide-react";
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import { AuthContext } from "@/context/AuthProvider";
import { useRouter } from "next/navigation";
export default function Login() {
  const t = useTranslations("login");
  const tFooter = useTranslations("footer");
  const locale = useLocale();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState<
    "usernameRequired" | "passwordRequired" | "bothRequired" | ""
  >("");
  const [submitted, setSubmitted] = useState(false);
  const router = useRouter();
  const { setToken, setUser, setActiveRole } = useContext(AuthContext);

  const submit = async (e: SyntheticEvent<HTMLFormElement>) => {
    e.preventDefault();
    setSubmitted(true);

    if (!username && !password) {
      setError("bothRequired");
      return;
    } else if (!username) {
      setError("usernameRequired");
      return;
    } else if (!password) {
      setError("passwordRequired");
      return;
    } else {
      setError("");
    }

    try {
      console.log("LOGIN START");
      const response = await fetch("http://10.208.8.91:5295/api/Auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          username,
          password,
        }),
      });
      console.log("STATUS:", response.status);
      if (!response.ok) {
        // setError("invalidCredentials");
        return;
      }

      const data = await response.json();
      setToken(data.accessToken);
      setUser(data.user);
      console.log("Login response:", data);
      if (data.user.roles.length > 1) {
        router.push(`/${locale}/select-role`);
      } else {
        setActiveRole(data.user.roles[0]);
        router.push(`/${locale}/dashboard`);
      }
    } catch (error) {
      console.error("Login error:", error);
    }
  };
  return (
    <form onSubmit={submit}>
      <div className="   md:bg-backgroundlogin h-screen flex justify-center items-center">
        <div
          className="bg-card w-full md:w-[70vw] h-full  md:h-[80vh] rounded-[0px] md:rounded-[10px] flex flex-col md:flex-row overflow-hidden 
        
        
  shadow-[20px_20px_43px_#b3b3b3,-20px_-20px_43px_#f2f2f2]
        
        "
        >
          <div className="w-full md:w-2/3 h-full bg-card grid grid-rows-11 px-0 md:px-[10%] py-0 md:py-[1%]">
            <div className="row-span-2  bg-backgroundlogin md:bg-card flex justify-center items-center md:justify-start  ">
              <div
                className="w-48 md:w-20 h-20 bg-primary"
                style={{
                  maskImage: "url('/images/NOYAN.svg')",
                  maskRepeat: "no-repeat",
                  maskPosition: "center",
                  maskSize: "contain",
                }}
              />
            </div>
            <div
              className="
            
    login-mobile-bg
    row-span-9 md:row-span-7
    flex-row
   
    px-[5%] md:px-0
    py-[10vh]
     md:py-[5%]
  "
            >
              <div
                className="
  px-[5%]
  md:px-0
pt-[10vh]
pb-[10vh]
  md:pt-0
  md:pb-0

  rounded-[10px]
  md:rounded-none

  bg-[#ebe9e5]
  backdrop-blur-xl

  md:bg-transparent
  md:backdrop-blur-none
"
              >
                <FieldGroup className="gap-2">
                  {/* <Field data-invalid={submitted && !username.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-username"
                      className="text-foreground"
                    >
                      {t("username")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-username"
                      placeholder={t("username")}
                      value={username}
                      aria-invalid={submitted && !username.trim()}
                      onChange={(e) => {
                        setUsername(e.target.value);
                      }}
                      className={`    ${submitted && !username.trim() ? "border-destructive" : ""} 
                                


                                
       border-none
      rounded-[7px]  
    bg-surface
   shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
 
   focus-visible:ring-1
   focus-visible:ring-primary/30  


                                `}
                    />
                  </Field>
                  {/* <Field data-invalid={submitted && !password.trim()}> */}
                  <Field>
                    <FieldLabel
                      htmlFor="fieldgroup-password"
                      className="text-foreground"
                    >
                      {t("password")}
                    </FieldLabel>
                    <Input
                      id="fieldgroup-password"
                      placeholder={t("password")}
                      type="password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      className={`
                            md:bg-transparent" ${submitted && !password.trim() ? "border-destructive" : ""}
                                
                                
                                
       border-none
      rounded-[7px]  
    bg-surface
   shadow-[inset_5px_5px_6px_#e4e2df,inset_-5px_-5px_6px_#ffffff] 
   focus-visible:ring-1
   focus-visible:ring-primary/30       
                                
                                
                                `}
                    />
                  </Field>
                  {/* <Field orientation="horizontal"> */}
                  <div className="min-h-4">
                    {/* فضای معادل error برای Button */}
                  </div>
                  <Button
                    className="
    w-full
    rounded-[7px]

    bg-surface
    text-[hsl(90_10%_20%)]

    shadow-[5px_5px_10px_#d3d1ce,-5px_-5px_10px_#ffffff]

    hover:bg-surface
    hover:text-foreground
    hover:shadow-[6px_6px_12px_#d0cecb,-6px_-6px_12px_#ffffff]

    active:bg-surface
    active:text-foreground
    active:shadow-[inset_4px_4px_8px_#d3d1ce,inset_-4px_-4px_8px_#ffffff]

    transition-all
    duration-150
  "
                    type="submit"
                  >
                    {t("submit")}
                  </Button>
                  {/* </Field> */}
                </FieldGroup>
                <div className="mt-3  min-h-0">
                  {error && (
                    <Alert
                      variant="destructive"
                      className="w-full 
                    
                   
      
        rounded-[7px]
        border-none
        bg-surface
        text-destructive
        shadow-[inset_3px_3px_5px_#e4e2df,inset_-3px_-3px_5px_#ffffff]
      
                    
                    "
                    >
                      <AlertCircleIcon />
                      <AlertTitle>{t("error")}</AlertTitle>
                      <AlertDescription>
                        {t(`errors.${error}`)}
                      </AlertDescription>
                    </Alert>
                  )}
                </div>
              </div>
              <label className="block md:hidden items-end ">
                {tFooter("copyright")}
              </label>
            </div>
            {/* <div className="hidden md:block row-span-1 bg-transparent">
              {tFooter("copyright")}
            </div> */}
          </div>

          <div
            className="hidden md:block bg-center  w-1/3 bg-cover "
            style={{ backgroundImage: "url('/images/main_pic.jpg')" }}
          ></div>
        </div>
        <div className="hidden md:block absolute bottom-2 text-center w-full">
          {tFooter("copyright")}
        </div>
      </div>
    </form>
  );
}
