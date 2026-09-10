using System.Data;

namespace TowerApi.Repositories.DataBase
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }

}



