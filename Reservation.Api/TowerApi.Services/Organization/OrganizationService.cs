

using TowerApi.Models.Organization;
using TowerApi.Repositories.Organization;

namespace TowerApi.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _repository;

        public OrganizationService(
            IOrganizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(OrganizationQueryRequest request)
        {
            if (request == null)
            {
                return (
                    400,
                    "پارامترهای جستجوی سازمان معتبر نیست.",
                    null);
            }

            return await _repository.GetListAsync(request);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(
                long orgId,
                bool includeDeleted)
        {
            if (orgId <= 0)
            {
                return (
                    400,
                    "شناسه سازمان نامعتبر است.",
                    null);
            }

            return await _repository.GetByIdAsync(
                orgId,
                includeDeleted);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(
                OrganizationCreateRequest request,
                int userId)
        {
            if (request == null)
            {
                return (
                    400,
                    "اطلاعات سازمان ارسال نشده است.",
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
                long orgId,
                OrganizationUpdateRequest request,
                int userId)
        {
            if (orgId <= 0)
            {
                return (
                    400,
                    "شناسه سازمان نامعتبر است.",
                    null);
            }

            if (request == null)
            {
                return (
                    400,
                    "اطلاعات سازمان ارسال نشده است.",
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
                orgId,
                request,
                userId);
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long orgId,
                int userId)
        {
            if (orgId <= 0)
            {
                return (
                    400,
                    "شناسه سازمان نامعتبر است.");
            }

            if (userId <= 0)
            {
                return (
                    401,
                    "کاربر احراز هویت نشده است.");
            }

            return await _repository.DeleteAsync(
                orgId,
                userId);
        }
    }
}
