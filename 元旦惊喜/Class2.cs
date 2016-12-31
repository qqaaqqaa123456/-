using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace 元旦惊喜
{
    class Class2 {
        public void Test(string text)
        {
            //先打开两个类库文件
            SqlConnection con = new SqlConnection();
            // con.ConnectionString = "server=505-03;database=ttt;user=sa;pwd=123";
            con.ConnectionString = @"Data Source=DESKTOP-JIB1A9B\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con.Open();
            /*
            SqlDataAdapter 对象。 用于填充DataSet （数据集）。
            SqlDataReader 对象。 从数据库中读取流..
            后面要做增删改查还需要用到 DataSet 对象。
            */
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = string.Format(@"CREATE TABLE [dbo].[Table]
(
    [test] TEXT NULL DEFAULT '{0}'
)",text);
            SqlDataReader dr = com.ExecuteReader();//执行SQL语句
            dr.Close();//关闭执行
            con.Close();//关闭数据库   
        }
 }
}