using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Windows.Forms;

namespace Virtual_librarian.Input_Output
{
    class CopyFiles
    {
        string fromDirectory;
        string toDirectory;
        public CopyFiles()
        {

        }
        [DllImport("kernel32.dll",
             EntryPoint = "GetStdHandle",
             SetLastError = true,
             CharSet = CharSet.Auto,
             CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;
        public void CopyFilesFromToDirectory(string from, string to)
        {
            fromDirectory = from;
            toDirectory = to;
            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(fromDirectory);
            System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(toDirectory);
            IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            Input_Output.FileCompare myFileCompare = new Input_Output.FileCompare();

            var queryList1Only = (from file in list1 select file).Except(list2, myFileCompare);

            FileInfo[] files = dir1.GetFiles();


            foreach (FileInfo file in files)
            {
                bool exists = true;
                string temppath = Path.Combine(toDirectory, file.Name);

                foreach (var v in queryList1Only)
                {
                    if (file.Name == v.Name)
                    {

                        file.CopyTo(temppath);
                    }

                }

               
            }
        }
    }
}
