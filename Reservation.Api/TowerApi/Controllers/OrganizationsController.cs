using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TowerApi.Models.Organization;
using TowerApi.Repositories.Organization;
using TowerApi.Services;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationsRepository _repository;
        private readonly ICurrentUser _currentUser;

        public OrganizationsController(IOrganizationsRepository repository, ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }


        // =========================================================
        // GET: api/organizations
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] OrganizationQueryRequest request)
        {
            try
            {
                var result =
                    await _repository.GetAsync(
                        null,
                        request);

                return CreateResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,
                        code = 500,
                        message =
                            "خطایی در دریافت لیست سازمان‌ها رخ داد."
                    });
            }
        }


        // =========================================================
        // GET: api/organizations/{orgId}
        // =========================================================

        [HttpGet("{orgId:long}")]
        public async Task<IActionResult> GetById(
            long orgId)
        {
            try
            {
                var request =
                    new OrganizationQueryRequest
                    {
                        IncludeDeleted = false
                    };

                var result =
                    await _repository.GetAsync(
                        orgId,
                        request);

                return CreateResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,
                        code = 500,
                        message =
                            "خطایی در دریافت اطلاعات سازمان رخ داد."
                    });
            }
        }


        // =========================================================
        // POST: api/organizations
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] OrganizationCreateRequest request)
        {
            try
            {
                // استخراج UserId از JWT
                var userId = _currentUser.UserId;

                if (!userId.HasValue)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        code = 401,
                        message =
                            "شناسه کاربر از توکن احراز هویت قابل تشخیص نیست."
                    });
                }

                // چون Stored Procedure فیلد UserCreater را INT می‌گیرد
                if (userId.Value > int.MaxValue)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        code = 401,
                        message =
                            "شناسه کاربر معتبر نیست."
                    });
                }

                var result =
                    await _repository.AddAsync(
                        request,
                        (int)userId.Value);

                return CreateResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,
                        code = 500,
                        message =
                            "خطایی در ثبت سازمان رخ داد."
                    });
            }
        }


        // =========================================================
        // PUT: api/organizations/{orgId}
        // =========================================================

        [HttpPut("{orgId:long}")]
        public async Task<IActionResult> Update(
            long orgId,
            [FromBody] OrganizationUpdateRequest request)
        {
            try
            {
                if (orgId <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        code = 400,
                        message =
                            "کد سازمان معتبر نیست."
                    });
                }

                // استخراج UserId از JWT
                var userId = _currentUser.UserId;

                if (!userId.HasValue)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        code = 401,
                        message =
                            "شناسه کاربر از توکن احراز هویت قابل تشخیص نیست."
                    });
                }

                if (userId.Value > int.MaxValue)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        code = 401,
                        message =
                            "شناسه کاربر معتبر نیست."
                    });
                }

                var result =
                    await _repository.EditAsync(
                        orgId,
                        request,
                        (int)userId.Value);

                return CreateResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,
                        code = 500,
                        message =
                            "خطایی در ویرایش سازمان رخ داد."
                    });
            }
        }


        // =========================================================
        // DELETE: api/organizations/{orgId}
        // =========================================================

        [HttpDelete("{orgId:long}")]
        public async Task<IActionResult> Delete(
            long orgId)
        {
            try
            {
                if (orgId <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        code = 400,
                        message =
                            "کد سازمان معتبر نیست."
                    });
                }

                // استخراج UserId از JWT
                var userId = _currentUser.UserId;

                if (!userId.HasValue)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        code = 401,
                        message =
                            "شناسه کاربر از توکن احراز هویت قابل تشخیص نیست."
                    });
                }

                if (userId.Value > int.MaxValue)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        code = 401,
                        message =
                            "شناسه کاربر معتبر نیست."
                    });
                }

                var result =
                    await _repository.DeleteAsync(
                        orgId,
                        (int)userId.Value);

                return CreateResponse(result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,
                        code = 500,
                        message =
                            "خطایی در حذف سازمان رخ داد."
                    });
            }
        }


        // =========================================================
        // JWT USER ID
        // =========================================================

        //private long? GetCurrentUserId()
        //{
        //    var userIdClaim =
        //        User.FindFirst(
        //            ClaimTypes.NameIdentifier);

        //    if (userIdClaim == null)
        //        return null;

        //    if (!long.TryParse(
        //            userIdClaim.Value,
        //            out var userId))
        //    {
        //        return null;
        //    }

        //    if (userId <= 0)
        //        return null;

        //    return userId;
        //}


        // =========================================================
        // RESPONSE MAPPING
        // =========================================================

        private IActionResult CreateResponse(
            OrganizationResult result)
        {
            return result.ResultCode switch
            {
                200 => Ok(new
                {
                    success = true,
                    code = 200,
                    message = result.ResultMessage,
                    data = result.Organization,
                    items = result.Organizations
                }),

                400 => BadRequest(new
                {
                    success = false,
                    code = 400,
                    message = result.ResultMessage
                }),

                404 => NotFound(new
                {
                    success = false,
                    code = 404,
                    message = result.ResultMessage
                }),

                409 => Conflict(new
                {
                    success = false,
                    code = 409,
                    message = result.ResultMessage
                }),

                _ => StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,
                        code = result.ResultCode,
                        message =
                            result.ResultMessage
                    })
            };
        }
    }
}
