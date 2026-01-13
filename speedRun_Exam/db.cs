using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedRun_Exam
{
    internal class db
    {
        static string pcName = Environment.MachineName;
        public static string conString = $"Data Source={pcName}\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True";
    }
}
