using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCreateSupportClass
{
    static class DirectoryCheck
    {
        public static bool Create(string DirectoryPath)
        {
            try
            {
                if (!Directory.Exists(DirectoryPath) && Directory.Exists(Path.GetDirectoryName(DirectoryPath)))
                {

                    Directory.CreateDirectory(DirectoryPath);

                }
                else if (!Directory.Exists(DirectoryPath) && !Directory.Exists(Path.GetDirectoryName(DirectoryPath)))
                {
                    Create(Path.GetDirectoryName(DirectoryPath));
                    Directory.CreateDirectory(DirectoryPath);

                }
            }
            catch
            {

                return false;
            }

            return true;
        }

    }

}
