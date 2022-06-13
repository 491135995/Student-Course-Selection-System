using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace 学生选课系统
{
    class DAO
    {
        public SqlConnection Connection()
        {
            string str = "Data Source=DESKTOP-15D4G3F;Initial catalog=学生选课管理系统;Integrated Security=True";
            SqlConnection sc = new SqlConnection(str);
            sc.Open();//打开数据连接
            return sc;
        }
        public SqlCommand Command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql,Connection());
            return cmd;
        }
        //用于delete updata insert，返回受影响的行数
        public int Execute(string sql)
        {
            return Command(sql).ExecuteNonQuery();
        }
        //用于select，返回SqldataReader对象，包含select到的数据
        public SqlDataReader read(string sql)
        {
            return Command(sql).ExecuteReader();
        }
    }
}
