using TowerApi.Models.User;

namespace TowerApi.Services
{
    public static class PermissionHelper
    {
        public static PermissionInfo GetPermissionInfo(byte level)
        {
            return level switch
            {
                1 => new PermissionInfo
                {
                    Code = 1,
                    Fa = "بدون دسترسی",
                    En = "No Access",
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false
                },

                2 => new PermissionInfo
                {
                    Code = 2,
                    Fa = "خواندن",
                    En = "Read",
                    CanRead = true,
                    CanWrite = false,
                    CanDelete = false
                },

                3 => new PermissionInfo
                {
                    Code = 3,
                    Fa = "نوشتن",
                    En = "Write",
                    CanRead = true,
                    CanWrite = true,
                    CanDelete = false
                },

                4 => new PermissionInfo
                {
                    Code = 4,
                    Fa = "دسترسی کامل",
                    En = "Full Access",
                    CanRead = true,
                    CanWrite = true,
                    CanDelete = true
                },

                _ => new PermissionInfo
                {
                    Code = 1,
                    Fa = "بدون دسترسی",
                    En = "No Access",
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false
                }
            };
        }
    }
}
