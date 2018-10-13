using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Virtual_librarian.Input_Output
{
    class CopyFiles
    {
        string fromDirectory;
        string toDirectory;
        public CopyFiles()
        {

        }
        public void CopyFilesFromToDirectory(string from,string to)
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
                    if(temppath == v.FullName)
                    {
                        exists = false;
                    }
                }
                if (exists == false)
                {
                    file.CopyTo(temppath);
                }
            }
        }
    }
}
