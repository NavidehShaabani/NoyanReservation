using System.Data;
using Dapper;
using TowerApi.DataBase;
using TowerApi.Model.Auth;
using TowerApi.Model.User;

namespace TowerApi.Repositories
{

    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AuthRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        //public async Task<List<GetItemOnOfCategoriesViewModel>> ItemOnOffGetCategories(GetCategoryProducts dto)
        //{
        //    using (var connection = _iconnectionFactory.GetConnection)
        //    {
        //        var query = @"[dbo].[Stp_ItemOnOf_GetCategory]";
        //        var param = new DynamicParameters();
        //        param.Add("@pShopId", dto.ShopId);
        //        param.Add("@pTitle", dto.Title);

        //        var result = await connection.QueryAsync<GetItemOnOfCategoriesViewModel>(query, param, commandType: CommandType.StoredProcedure);
        //        return result.ToList();
        //    }
        //}
        public async Task<LoginResult> LoginAsync(LoginRequest user)
        {
            try
            {

                using (var connection = _connectionFactory.CreateConnection())
                {
                    LoginResult result = new LoginResult();

                    var query = "dbo.UserLogin";
                    var param = new DynamicParameters();
                    param.Add("@pUsername", user.Username);
                    param.Add("@pPasswordHash", user.PasswordHash);

                    param.Add("@ResultCode","", DbType.Int32, ParameterDirection.Output);
                    param.Add("@ResultMessage","", DbType.String, ParameterDirection.Output);
                               


                    using (var multi =
                    await connection.QueryMultipleAsync(query, param, commandType: CommandType.StoredProcedure))
                    {
                        // Result Set 1
                        result.User = multi
                            .Read<UserInfo>()
                            .FirstOrDefault();

                        // Result Set 2
                        result.Roles = multi
                            .Read<UserRole>()
                            .ToList();

                        // Result Set 3
                        result.Menus = multi
                            .Read<UserMenu>()
                            .ToList();
                    }


                    result.ResultCode = param.Get<int>("@ResultCode");
                    result.ResultMessage = param.Get<string>("@ResultMessage");
               

                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
