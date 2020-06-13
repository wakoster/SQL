using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLForm
{
    class SQL
    {
        /// <summary>
        /// 按产品号搜索库存表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <returns>返回信息</returns>
        static public List<REPERTORYInformation> SelsctREPERTORYByPno(SqlConnection conn, string Pno)
        {
            string sql = "SELECT * FROM REPERTORY WHERE Pno = '" + Pno + "' ORDER BY Pnum DESC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<REPERTORYInformation> newList = new List<REPERTORYInformation>();
            while (reader.Read())
            {
                newList.Add(new REPERTORYInformation(reader[0].ToString(), reader[1].ToString(), Convert.ToInt32(reader[2])));
            }
            reader.Close();
            return newList;
        }

        /// <summary>
        /// 按仓库号搜索库存表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">仓库号</param>
        /// <returns>返回信息</returns>
        static public List<REPERTORYInformation> SelsctREPERTORYByWno(SqlConnection conn, string Wno)
        {
            string sql = "SELECT * FROM REPERTORY WHERE Wno = '" + Wno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<REPERTORYInformation> newList = new List<REPERTORYInformation>();
            while (reader.Read())
            {
                newList.Add(new REPERTORYInformation(reader[0].ToString(), reader[1].ToString(), Convert.ToInt32(reader[2])));
            }
            reader.Close();
            return newList;
        }

        /// <summary>
        /// 按产品号搜索损坏表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <returns>返回信息</returns>
        static public List<REPERTORYInformation> SelsctDAMAGEByPno(SqlConnection conn, string Pno)
        {
            string sql = "SELECT * FROM DAMAGE WHERE Pno = '" + Pno + "' ORDER BY Pnum ASC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<REPERTORYInformation> newList = new List<REPERTORYInformation>();
            while (reader.Read())
            {
                newList.Add(new REPERTORYInformation(reader[0].ToString(), reader[1].ToString(), Convert.ToInt32(reader[2])));
            }
            reader.Close();
            return newList;
        }

        /// <summary>
        /// 按仓库号搜索损坏表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">仓库号</param>
        /// <returns>返回信息</returns>
        static public List<REPERTORYInformation> SelsctDAMAGEByWno(SqlConnection conn, string Wno)
        {
            string sql = "SELECT * FROM DAMAGE WHERE Wno = '" + Wno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<REPERTORYInformation> newList = new List<REPERTORYInformation>();
            while (reader.Read())
            {
                newList.Add(new REPERTORYInformation(reader[0].ToString(), reader[1].ToString(), Convert.ToInt32(reader[2])));
            }
            reader.Close();
            return newList;
        }

        /// <summary>
        /// 插入信息表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <param name="Wno">仓库号</param>
        /// <param name="Onature">操作类型</param>
        /// <param name="Onum">数量</param>
        /// <param name="Ano">管理员编号</param>
        static public void RecordedInformationIntoOpreation(SqlConnection conn, string Pno, string Wno, string Onature, int Onum, string Ano)
        {
            string Ono = MakeOno(conn);
            string sql = "INSERT INTO Opreation VALUES('" + Ono + "','" + Pno + "','" + Wno + "','" + Onature + "'," + Onum + ",getdate(), '" + Ano + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }

        /// <summary>
        /// 产品出库(自动检索所有仓库进行出库）
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <param name="Wno">仓库号</param>
        /// <param name="number">数量</param>
        /// <param name="Ano">操作管理员编号</param>
        /// <returns>是否可以出库(即可出库产品数量是否足够)</returns>
        static public bool ProductOutbound(SqlConnection conn, string Pno, string Wno, int number, string Ano)
        {
            string sql = "SELECT * FROM REPERTORY WHERE Pno = '" + Pno + "' and Wno = '" + Wno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int num = 0;
            while (reader.Read())
            {
                num = Convert.ToInt32(reader[2]);
            }
            reader.Close();
            if (number > num)
            {
                return false;
            }
            else if (number == num)
            {
                DeleteREPERTORYInformation(conn, Pno, Wno);
                RecordedInformationIntoOpreation(conn, Pno, Wno, "出", number, Ano);
                return true;
            }
            else
            {
                ModificationREPERTORY(conn, Pno, Wno, num - number);
                RecordedInformationIntoOpreation(conn, Pno, Wno, "出", number, Ano);
                return true;
            }
        }

        /// <summary>
        /// 修改库存表信息
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <param name="Wno">仓库号</param>
        /// <param name="number">数量</param>
        static public void ModificationREPERTORY(SqlConnection conn, string Pno, string Wno, int number)
        {
            string sql = "UPDATE REPERTORY set Pnum = " + number + "WHERE Pno = '" + Pno + "' and Wno = '" + Wno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }

        /// <summary>
        /// 删除库存表中信息
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <param name="Wno">仓库号</param>
        static public void DeleteREPERTORYInformation(SqlConnection conn, string Pno, string Wno)
        {
            string sql = "DELETE FROM REPERTORY WHERE Pno = '" + Pno + "' and Wno = '" + Wno + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }

        /// <summary>
        /// 自动生成单号
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <returns>单号</returns>
        static public string MakeOno(SqlConnection conn)
        {
            string sql = "SELECT Count(*) FROM  Opreation";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string s = "A";
            int number = 0;
            while (reader.Read())
            {
                number = Convert.ToInt32(reader[0]);
            }
            reader.Close();
            int count = 0;
            int digit = number + 1;
            while (digit != 0)
            {
                digit /= 10;
                count++;
            }
            for (int i = 19; i > count; i--)
                s += "0";
            s += (number + 1);
            Console.Write(s);
            return s;
        }

        /// <summary>
        /// 按仓库号搜索仓库表
        /// </summary>
        static public List<string> SelectFromWarhouse(SqlConnection conn, string Wno)
        {
            conn.Open();
            string sqlsentence = "SELECT * FROM Wno WHERE Wno = '" + Wno + "' ";
            SqlCommand cmd = new SqlCommand(sqlsentence, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("仓库号为空");
            }
            List<string> Wlist = new List<string>();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Wlist.Add(reader[i].ToString());
                }
            }
            reader.Close();
            conn.Close();
            return Wlist;
        }

        /// <summary>
        /// 按仓库号搜索仓库现容量
        /// </summary>
        /// <returns>返回信息</returns>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <returns>返回信息</returns>
        static int KUCUNronglaing(SqlConnection conn, string Wno)
        {
            try
            {
                string sql = "SELECT Wnow FROM warhouse WHERE Wno = '" + Wno + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();
                int num = 0;
                while (read.Read())
                {
                    num = Convert.ToInt32(read[1]);
                }
                return num;
            }
            finally
            {
                if (conn != null) //判断con不为空
                { conn.Close(); }
            }

        }

        /// <summary>
        /// 按仓库号搜索仓库表
        /// </summary>
        static int cangkuronglaing(SqlConnection conn, string Wno)
        {
            try
            {
                string sql = "SELECT Wsize FROM Warhouse WHERE Wno = '" + Wno + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();
                int num = 0;
                while (read.Read())
                {
                    num = Convert.ToInt32(read[2]);
                }
                return num;
            }
            finally
            {
                if (conn != null) //判断con不为空
                { conn.Close(); }
            }

        }

        /// <summary>
        /// 按仓库号搜索损坏表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <returns>返回信息</returns>
        static int SUNHUAIshuliang(SqlConnection conn, string Wno)
        {
            try
            {
                string sql = "SELECT SUM(number) FROM KUCUN WHERE Wno = '" + Wno + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();
                int num = 0;
                while (read.Read())
                {
                    num = Convert.ToInt32(read[1]);
                }
                return num;
            }
            finally
            {
                if (conn != null) //判断con不为空
                { conn.Close(); }
            }

        }

        /// <summary>
        /// 产品入库
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <param name="number">数量</param>
        /// <returns>是否可以入库</returns>
        static public bool INPUT(SqlConnection conn, string Ono, string Pno, string Wno, int number)
        {

            string sql = "SELECT number FROM DINGDAN WHERE Ono = '" + Ono + "'";
            int a = cangkuronglaing(conn, Wno);//Wsize
            int b = SUNHUAIshuliang(conn, Wno);//sumnumber
            int c = KUCUNronglaing(conn, Wno);//Wnow
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int num;
            while (reader.Read())
            {
                num = Convert.ToInt32(reader[number]);
                if (a < b + c + num)
                    return false;
                else if (b + c + num <= a)
                {
                    string sq = "UPDATE KUCUN set Pnum = " + number + "WHERE Pno = '" + Pno + "' and Wno = '" + Wno + "' " +
                        "UPDATE Warhouse set Wnow = " + number + "WHERE Wno = '" + Wno + "' ";
                    SqlCommand cm = new SqlCommand(sql, conn);
                    SqlDataReader read = cmd.ExecuteReader();
                    read.Close();
                }
            }
            reader.Close();
            return false;
        }

        /// <summary>
        /// 按产品号查询产品信息
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <returns>包含查询结果的list</returns>
        static public List<string> SelectFromProductWherePno(SqlConnection conn, string Pno)  //根据产品号查询产品信息
        {
            conn.Open();
            string sqlsentence = "SELECT * FROM Product WHERE Pno = '" + Pno + "' ";
            SqlCommand cmd = new SqlCommand(sqlsentence, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("无此条记录");
            }
            List<string> mylist = new List<string>();

            while (reader.Read())//判断数据表中是否含有数据  
            {
                for (int i = 0; i < reader.FieldCount; i++)//将查询结果传给list
                {
                    mylist.Add(reader[i].ToString());
                }

            }
            reader.Close();
            conn.Close();

            return mylist;
        }

        /// <summary>
        /// 按产品名查询产品信息
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pname">产品名</param>
        /// <returns>包含查询结果的list</returns>
        static public List<string> SelectFromProductWherePname(SqlConnection conn, string Pname)  //根据产品名查询产品信息
        {
            conn.Open();
            string sqlsentence = "SELECT * FROM Product WHERE Pname = '" + Pname + "'";
            SqlCommand cmd = new SqlCommand(sqlsentence, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("无此条记录");
            }
            List<string> mylist = new List<string>();
            while (reader.Read())//判断数据表中是否含有数据  
            {
                for (int i = 0; i < reader.FieldCount; i++)//将查询结果传给list
                {
                    mylist.Add(reader[i].ToString());
                }

            }
            reader.Close();
            conn.Close();

            return mylist;
        }
        
        /// <summary>
        /// 增加损坏记录
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="Pno">产品号</param>
        /// <param name="Wno">仓库号</param>
        /// <param name="Bnum">损坏数量</param>
        static public void AddDAMAGE(SqlConnection conn, string Pno, string Wno, string Bnum)  //增加损坏记录
        {
            conn.Open();
            string sqlsentence = "SELECT * FROM DAMAGE WHERE Pno = '" + Pno + "' and Wno = '" + Wno + "'";
            SqlCommand cmd = new SqlCommand(sqlsentence, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)//是否已存在此产品损坏记录
            {
                sqlsentence = "INSERT INTO DAMAGE VALUES('" + Pno + "','" + Wno + "','" + Bnum + "')";//插入新纪录
            }
            else
            {
                sqlsentence = "UPDATE DAMAGE SET Bnum = Bnum + " + Bnum + "WHERE Pno = '" + Pno + "' and Wno = '" + Wno + "'";//修改旧纪录
            }
            reader.Close();
            cmd = new SqlCommand(sqlsentence, conn);
            cmd.ExecuteNonQuery();


            sqlsentence = "UPDATE REPERTORY SET Pnum = Pnum - " + Bnum + "WHERE Pno = '" + Pno + "' and Wno = '" + Wno + "'";//修改库存表
            cmd = new SqlCommand(sqlsentence, conn);
            cmd.ExecuteNonQuery();

            reader.Close();
            conn.Close();
        }

        /// <summary>
        /// 插入管理员表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmd"></param>
        /// <param name="Ano">管理员编号</param>
        /// <param name="Akey">管理员密码</param>
        /// <param name="Jno">管理员权限编号</param>
        static void InsertAdministrator(SqlConnection conn, SqlCommand cmd, string Ano, string Akey, string Jno)
        {
            String Adm;
            Adm = "INSERT INTO Administrator VALUES('" + Ano + "','" + Akey + "','" + Jno + "');";
            cmd.CommandText = Adm;
            cmd.ExecuteNonQuery();
        }
        
        /// <summary>
        /// 更新管理员表
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmd"></param>
        /// <param name="Ano">管理员编号</param>
        /// <param name="Akey">管理员密码</param>
        /// <param name="Jno">管理员权限编号</param>
        static void UpdateAdministrator(SqlConnection conn, SqlCommand cmd, string Ano, string Akey, string Jno)
        {
            String Adm;
            Adm = "UPDATE Administrator SET Ano= '" + Ano + "'," + "Akey='" + Akey + "'," + "Jno='" + Jno + "';";
            cmd.CommandText = Adm;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 按管理员编号删除管理员信息
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmd"></param>
        /// <param name="Ano">管理员编号</param>
        static void DeleteAdministratorByAno(SqlConnection conn, SqlCommand cmd, string Ano)
        {
            String Adm;
            Adm = "DELETE FROM Administrator WHERE Ano ='" + Ano + "'";
            cmd.CommandText = Adm;
            cmd.ExecuteNonQuery();
        }
        
        /// <summary>
        /// 按管理员编号搜索管理员信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmd"></param>
        /// <param name="Ano"></param>
        /// <param name="Akey"></param>
        /// <param name="Jno"></param>
        static List<AdministratorInformation> SelectOnAdministratorByAno(SqlConnection conn, SqlCommand cmd, string Ano)
        {
            String Adm;
            Adm = "SELECT Ano,Jno FROM Administrator WHERE Ano= '" + Ano + " '";
            cmd = new SqlCommand(Adm, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<AdministratorInformation> newList = new List<AdministratorInformation>();
            while (reader.Read())
            {
                newList.Add(new AdministratorInformation(reader[0].ToString(), reader[1].ToString()));
            }
            reader.Close();
            // Console.WriteLine(newList);
            return newList;
        }
    }
}

    /// <summary>
    /// 存放库存表和损坏表信息类
    /// </summary>
    public class REPERTORYInformation
    {
        /// <summary>
        /// 产品号
        /// </summary>
        public string Pno;
        /// <summary>
        /// 仓库号
        /// </summary>
        public string Wno;
        /// <summary>
        /// 数量
        /// </summary>
        public int number;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Pno">产品号</param>
        /// <param name="Wno">仓库号</param>
        /// <param name="number">数量</param>
        public REPERTORYInformation(string Pno, string Wno, int number)
        {
            this.Pno = Pno;
            this.Wno = Wno;
            this.number = number;
        }
    }

    /// <summary>
    /// 仓库表
    /// </summary>
    public class Warhouse
    {
        /// <summary>
        /// 仓库号
        /// </summary>
        public string Wno;
        /// <summary>
        /// 现容量
        /// </summary>
        public int Wnow;
        /// <summary>
        /// 总容量
        /// </summary>
        public int Wsize;
        public void KUCUN(string Wno, int Wsize, int Wnow)
        {
            this.Wno = Wno;
            this.Wsize = Wsize;
            this.Wnow = Wnow;
        }
    }

    /// <summary>
    /// 库存表
    /// </summary>
    public class KUCUN
    {
        /// <summary>
        /// 仓库号
        /// </summary>
        public string Wno;
        /// <summary>
        /// 数量
        /// </summary>
        public int Pnum;
        /// <summary>
        /// 产品号
        /// </summary>
        public string Pno;
        public KUCUN(string Wno, int Pnum, string Pno)
        {
            this.Wno = Wno;
            this.Pno = Pno;
            this.Pnum = Pnum;
        }
    }

    /// <summary>
    /// 损坏表
    /// </summary>
    public class SUNHUAI
    {
        /// <summary>
        /// 仓库号
        /// </summary>
        public string Wno;
        /// <summary>
        /// 数量
        /// </summary>
        public int number;
        /// <summary>
        /// c产品号
        /// </summary>
        public string Pno;
        public SUNHUAI(string Wno, string Pno, int number)
        {
            this.Wno = Wno;
            this.Pno = Pno;
            this.number = number;
        }


    }

    /// <summary>
    /// 订单表
    /// </summary>
    public class DINGDAN
    {
        /// <summary>
        /// 仓库号
        /// </summary>
        public string Wno;
        /// <summary>
        /// 数量
        /// </summary>
        int number;
        /// <summary>
        /// c产品号
        /// </summary>
        public string Pno;
        /// <summary>
        /// 单号
        /// </summary>
        public string Ono;
        public DINGDAN(string Wno, string Pno, int number, string Ono)
        {
            this.Wno = Wno;
            this.Pno = Pno;
            this.Ono = Ono;
            this.number = number;
        }
    }

    /// <summary>
    /// 管理员表
    /// </summary>
    public class AdministratorInformation
    {
        public string Ano;
        public string Jno;
        public AdministratorInformation(string Ano, string Jno)
        {
            this.Ano = Ano;
            this.Jno = Jno;
        }
    }
