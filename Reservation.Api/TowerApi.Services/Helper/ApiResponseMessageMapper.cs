using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Services.Helper
{
    public static class ApiResponseMessageMapper
    {
        public static string GetMessageKey(int resultCode)
        {
            return resultCode switch
            {
                400 => "Common.InvalidRequest",
                401 => "Common.Unauthorized",
                403 => "Common.Forbidden",
                404 => "Common.NotFound",
                409 => "Common.Conflict",
                410 => "Common.Gone",
                429 => "Common.TooManyRequests",
                _ => "Common.SystemError"
            };
        }

        public static int GetHttpStatusCode(int resultCode)
        {
            return resultCode switch
            {
                200 => StatusCodes.Status200OK,
                400 => StatusCodes.Status400BadRequest,
                401 => StatusCodes.Status401Unauthorized,
                403 => StatusCodes.Status403Forbidden,
                404 => StatusCodes.Status404NotFound,
                409 => StatusCodes.Status409Conflict,
                410 => StatusCodes.Status410Gone,
                429 => StatusCodes.Status429TooManyRequests,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
