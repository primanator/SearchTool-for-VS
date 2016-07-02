using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VS
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWork statistic = new FileWork();
            DirectoryInfo main_dir = new DirectoryInfo("D:\\Microsoft Visual Studio 12.0\\");
            statistic.DirProcessing(main_dir);
            for (int i = 0; i < 16; i++)
                Console.WriteLine(statistic.years[i] + ": " + statistic.values[i]);
        }
    }
}
