using System.Data;
namespace TowerApi.DataBase
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }

}



