using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLForm
{
    public class Database
    {
        /// <summary>
        /// (测试用数据，记得删除)连接数据，包括：Data Source = 服务器名；Initial Catalog = 数据库名；Integrated Security = TRUE(或者：SSPI)
        /// </summary>
        public static string connString = "Data Source=LAPTOP-57U7LQED\\SQLEXPRESS;Initial Catalog=EWDBS;Integrated Security=TRUE";

        /// <summary>
        /// (测试用数据，记得删除)数据库连接对象
        /// </summary>
        public static SqlConnection conn  = new SqlConnection(connString);
        
    }
}
