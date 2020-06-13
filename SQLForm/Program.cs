using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    /// <summary>
    /// 管理员类
    /// </summary>
    public class AdministratorDemo
    {
        public string Ano;
        public string Akey;
        public string Aname;
        public int Jno;

        public AdministratorDemo(string Ano, string Akey, string Aname,int Jno)
        {
            this.Ano = Ano;
            this.Akey = Akey;
            this.Aname = Aname;
            this.Jno = Jno;
        }
    }
}



