using System.Data;
using Dapper;
using TowerApi.Models.Employees;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EmployeeRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<EmployeeItem>> GetAsync(EmployeeQuery request)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<EmployeeItem>(
                "dbo.EmployeesGet",
                new
                {
                    request.Search,
                    request.OrgId,
                    request.EmployeeTypeId,
                    request.IsActive,
                    request.PageNumber,
                    request.PageSize
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<EmployeeDetails?> GetByIdAsync(long employeeId)
        {
            using var connection = _connectionFactory.CreateConnection();

            using var result = await connection.QueryMultipleAsync(
                "dbo.EmployeesGetById",
                new { EmployeeId = employeeId },
                commandType: CommandType.StoredProcedure);

            var employee = await result.ReadFirstOrDefaultAsync<EmployeeDetails>();

            if (employee == null)
                return null;

            employee.Assignments =
                (await result.ReadAsync<EmployeeAssignmentSummary>()).ToList();

            return employee;
        }

        public async Task<(int Code, EmployeeCreateResult? Data)> AddAsync(
            EmployeeCreateRequest request, string? passwordHash, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@Username", request.Username);
            p.Add("@PasswordHash", passwordHash);
            p.Add("@Email", request.Email);
            p.Add("@Mobile", request.Mobile);
            p.Add("@FirstName", request.FirstName);
            p.Add("@LastName", request.LastName);
            p.Add("@NationalId", request.NationalId);
            p.Add("@Gender", request.Gender);
            p.Add("@BirthDate", request.BirthDate);
            p.Add("@AvatarUrl", request.AvatarUrl);
            p.Add("@PhoneVerified", request.PhoneVerified);
            p.Add("@UserIsActive", request.UserIsActive);

            p.Add("@OrgId", request.OrgId);
            p.Add("@EmployeeTypeId", request.EmployeeTypeId);
            p.Add("@EmploymentType", request.EmploymentType);
            p.Add("@HireDate", request.HireDate);
            p.Add("@EndDate", request.EndDate);
            p.Add("@BaseSalary", request.BaseSalary);
            p.Add("@HourlyRate", request.HourlyRate);
            p.Add("@BankName", request.BankName);
            p.Add("@BankCardNumber", request.BankCardNumber);
            p.Add("@BankAccountNumber", request.BankAccountNumber);
            p.Add("@ShebaNumber", request.ShebaNumber);
            p.Add("@EmployeeIsActive", request.EmployeeIsActive);
            p.Add("@EmployeesDesc", request.EmployeesDesc);
            p.Add("@UserCreater", userId);

            p.Add("@NewUserId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);
            p.Add("@NewEmployeeId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);
            p.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            p.Add("@ResultMessage", dbType: DbType.String, size: 500,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.EmployeesAdd", p,
                commandType: CommandType.StoredProcedure);

            var code = p.Get<int>("@ResultCode");

            EmployeeCreateResult? data = code == 200
                ? new EmployeeCreateResult
                {
                    UserId = p.Get<long?>("@NewUserId"),
                    EmployeeId = p.Get<long?>("@NewEmployeeId")
                }
                : null;

            return (code, data);
        }

        public async Task<int> EditAsync(
            long employeeId, EmployeeUpdateRequest request, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();
            var p = CreateResultParameters();

            p.Add("@EmployeeId", employeeId);
            p.Add("@OrgId", request.OrgId);
            p.Add("@EmployeeTypeId", request.EmployeeTypeId);
            p.Add("@EmploymentType", request.EmploymentType);
            p.Add("@HireDate", request.HireDate);
            p.Add("@EndDate", request.EndDate);
            p.Add("@BaseSalary", request.BaseSalary);
            p.Add("@HourlyRate", request.HourlyRate);
            p.Add("@BankName", request.BankName);
            p.Add("@BankCardNumber", request.BankCardNumber);
            p.Add("@BankAccountNumber", request.BankAccountNumber);
            p.Add("@ShebaNumber", request.ShebaNumber);
            p.Add("@EmployeesDesc", request.EmployeesDesc);
            p.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeesEdit", p,
                commandType: CommandType.StoredProcedure);

            return p.Get<int>("@ResultCode");
        }

        public async Task<int> DeleteAsync(long employeeId, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();
            var p = CreateResultParameters();

            p.Add("@EmployeeId", employeeId);
            p.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeesDel", p,
                commandType: CommandType.StoredProcedure);

            return p.Get<int>("@ResultCode");
        }

        public async Task<int> SetActiveAsync(
            long employeeId, bool isActive, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();
            var p = CreateResultParameters();

            p.Add("@EmployeeId", employeeId);
            p.Add("@IsActive", isActive);
            p.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeesActive", p,
                commandType: CommandType.StoredProcedure);

            return p.Get<int>("@ResultCode");
        }

        private static DynamicParameters CreateResultParameters()
        {
            var p = new DynamicParameters();

            p.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            p.Add("@ResultMessage", dbType: DbType.String, size: 500,
                direction: ParameterDirection.Output);

            return p;
        }
    }
}
