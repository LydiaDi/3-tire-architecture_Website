using SqlSugar;
using System.Configuration;

namespace DAL
{
    /// <summary>
    /// 配置sqlsugar
    /// </summary>
    public class SqlSugarBase
    {
        //获取配置数据库信息
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
        //创建sqlsugar对象
        public static SqlSugarClient DB
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.SystemTable,
                IsShardSameThread = true
            });
        }
    }
}
