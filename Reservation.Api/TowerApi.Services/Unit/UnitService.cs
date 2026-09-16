using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Unit;
using TowerApi.Repositories.Unit;

namespace TowerApi.Services.Unit
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _repository;

        public UnitService(
            IUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(
                UnitQueryRequest request)
        {
            if (request == null)
            {
                return (
                    400,
                    "پارامترهای جستجوی واحد معتبر نیست.",
                    null);
            }

            return await _repository.GetListAsync(request);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(
                long unitId,
                bool includeDeleted)
        {
            if (unitId <= 0)
            {
                return (
                    400,
                    "شناسه واحد نامعتبر است.",
                    null);
            }

            return await _repository.GetByIdAsync(
                unitId,
                includeDeleted);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(
                UnitCreateRequest request,
                int userId)
        {
            if (request == null)
            {
                return (
                    400,
                    "اطلاعات واحد ارسال نشده است.",
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
                long unitId,
                UnitUpdateRequest request,
                int userId)
        {
            if (unitId <= 0)
            {
                return (
                    400,
                    "شناسه واحد نامعتبر است.",
                    null);
            }

            if (request == null)
            {
                return (
                    400,
                    "اطلاعات واحد ارسال نشده است.",
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
                unitId,
                request,
                userId);
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long unitId,
                int userId)
        {
            if (unitId <= 0)
            {
                return (
                    400,
                    "شناسه واحد نامعتبر است.");
            }

            if (userId <= 0)
            {
                return (
                    401,
                    "کاربر احراز هویت نشده است.");
            }

            return await _repository.DeleteAsync(
                unitId,
                userId);
        }
    }
}
