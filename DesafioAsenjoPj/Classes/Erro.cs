using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAsenjoPj.Classes
{
    internal class Erro
    {
        private static bool erro = false;
        private static string msg = "";

        public static void setErro(bool e) { erro = e; }
        public static bool getErro() { return erro; }
        public static void setMsg(string m) { erro = true; msg = m; }
        public static string getMsg() { return msg; }
    }
}
