using System.Data;
using Dapper;
using TowerApi.Models.EmployeeAssignments;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.EmployeeAssignments
{

    public class EmployeeAssignmentRepository : IEmployeeAssignmentRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EmployeeAssignmentRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<EmployeeAssignmentItem>> GetAsync(
            EmployeeAssignmentQuery request)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<EmployeeAssignmentItem>(
                "dbo.EmployeeAssignmentsGet",
                new
                {
                    request.EmployeeId,
                    request.OrgId,
                    request.BuildingId,
                    request.IsActive,
                    request.PageNumber,
                    request.PageSize
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<EmployeeAssignmentItem?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EmployeeAssignmentItem>(
                "dbo.EmployeeAssignmentsGetById",
                new { EmployeeAssignmentId = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<(int Code, long? Id)> AddAsync(
            EmployeeAssignmentCreateRequest request, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = CreateResultParameters();

            p.Add("@EmployeeId", request.EmployeeId);
            p.Add("@OrgId", request.OrgId);
            p.Add("@BuildingId", request.BuildingId);
            p.Add("@SpaceId", request.SpaceId);
            p.Add("@StartDate", request.StartDate.Date);
            p.Add("@EndDate", request.EndDate?.Date);
            p.Add("@ShiftName", request.ShiftName);
            p.Add("@EmployeeAssignmentDesc", request.EmployeeAssignmentDesc);
            p.Add("@UserCreater", userId);

            p.Add("@EmployeeAssignmentId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.EmployeeAssignmentsAdd", p,
                commandType: CommandType.StoredProcedure);

            return (
                p.Get<int>("@ResultCode"),
                p.Get<long?>("@EmployeeAssignmentId")
            );
        }

        public async Task<int> EditAsync(
            long id, EmployeeAssignmentUpdateRequest request, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = CreateResultParameters();

            p.Add("@EmployeeAssignmentId", id);
            p.Add("@OrgId", request.OrgId);
            p.Add("@BuildingId", request.BuildingId);
            p.Add("@SpaceId", request.SpaceId);
            p.Add("@StartDate", request.StartDate.Date);
            p.Add("@EndDate", request.EndDate?.Date);
            p.Add("@ShiftName", request.ShiftName);
            p.Add("@EmployeeAssignmentDesc", request.EmployeeAssignmentDesc);
            p.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeeAssignmentsEdit", p,
                commandType: CommandType.StoredProcedure);

            return p.Get<int>("@ResultCode");
        }

        public async Task<int> DeleteAsync(long id, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = CreateResultParameters();

            p.Add("@EmployeeAssignmentId", id);
            p.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeeAssignmentsDel", p,
                commandType: CommandType.StoredProcedure);

            return p.Get<int>("@ResultCode");
        }

        public async Task<int> SetActiveAsync(
            long id, bool isActive, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = CreateResultParameters();

            p.Add("@EmployeeAssignmentId", id);
            p.Add("@IsActive", isActive);
            p.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeeAssignmentsActive", p,
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
