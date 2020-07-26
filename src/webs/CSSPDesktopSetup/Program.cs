using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bonjour");
        }

        private void CreateDirectories()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\cssp\\";

            DirectoryInfo di = new DirectoryInfo(appDataPath);

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
}
