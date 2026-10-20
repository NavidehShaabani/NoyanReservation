using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Building;
using TowerApi.Repositories.Building;

namespace TowerApi.Services.Building
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _repository;

        public BuildingService(
            IBuildingRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(
                BuildingQueryRequest request)
        {
            if (request == null)
            {
                return (
                    400,
                    "پارامترهای جستجوی ساختمان معتبر نیست.",
                    null);
            }

            return await _repository.GetListAsync(request);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(
                long buildingId,
                bool includeDeleted)
        {
            if (buildingId <= 0)
            {
                return (
                    400,
                    "شناسه ساختمان نامعتبر است.",
                    null);
            }

            return await _repository.GetByIdAsync(
                buildingId,
                includeDeleted);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(
                BuildingCreateRequest request,
                int userId)
        {
            if (request == null)
            {
                return (
                    400,
                    "اطلاعات ساختمان ارسال نشده است.",
                    null);
            }

            if (userId <= 0)
            {
                return (
                    401,
                    "کاربر احراز هویت نشده است.",
                    null);
            }

            return await _repository.AddAsync(
                request,
                userId);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            EditAsync(
                long buildingId,
                BuildingUpdateRequest request,
                int userId)
        {
            if (buildingId <= 0)
            {
                return (
                    400,
                    "شناسه ساختمان نامعتبر است.",
                    null);
            }

            if (request == null)
            {
                return (
                    400,
                    "اطلاعات ساختمان ارسال نشده است.",
                    null);
            }

            if (userId <= 0)
            {
                return (
                    401,
                    "کاربر احراز هویت نشده است.",
                    null);
            }

            return await _repository.EditAsync(
                buildingId,
                request,
                userId);
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long buildingId,
                int userId)
        {
            if (buildingId <= 0)
            {
                return (
                    400,
                    "شناسه ساختمان نامعتبر است.");
            }

            if (userId <= 0)
            {
                return (
                    401,
                    "کاربر احراز هویت نشده است.");
            }

            return await _repository.DeleteAsync(
                buildingId,
                userId);
        }
        public async Task<BuildingBulkServiceResult<object>>
           BulkSaveAsync(
               BuildingBulkSaveRequest request,
               long currentUserId)
        {
            var result = await _repository.BulkSaveAsync(
                request.Buildings,
                currentUserId);

            return new BuildingBulkServiceResult<object>
            {
                Code = result.ResultCode,
                MessageKey = result.ResultCode switch
                {
                    200 => "Buildings.BulkSaveSuccessfully",
                    400 => "Buildings.InvalidData",
                    404 => "Buildings.ReferenceNotFound",
                    409 => "Buildings.Conflict",
                    _ => "Common.SystemError"
                },
                Data = null
            };
        }

        public async Task<
            BuildingBulkServiceResult<List<BuildingByOrgResponse>>>
            GetByOrgIdAsync(long orgId)
        {
            var result = await _repository.GetByOrgIdAsync(orgId);

            return new BuildingBulkServiceResult<
                List<BuildingByOrgResponse>>
            {
                Code = result.ResultCode,
                MessageKey = result.ResultCode switch
                {
                    200 => "Buildings.GetByOrgIdSuccessfully",
                    400 => "Buildings.InvalidOrgId",
                    404 => "Buildings.OrganizationNotFound",
                    _ => "Common.SystemError"
                },
                Data = result.ResultCode == 200
                    ? result.Data
                    : null
            };
        }
    }
}
