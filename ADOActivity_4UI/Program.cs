using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOActivity_4DAL;

namespace ADOActivity_4UI
{
    class Program
    {
        static void Main(string[] args)
        {
            act4 obj = new act4();
            obj.StudentInfoDetails();

            int result = obj.updateName(1, "Panda", out int rowaf);
            int result1 = obj.InsertName(4, "Ridhhi", "Finzly", "Pune", out int rowaf);
           


        }
    }
}
