using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace FilesFunctions
{
    public class DIDBReaderWriter : IInputOutput
    {
        public T Read<T>()
        {
            throw new NotImplementedException();
        }

        public bool Write<T>(T objectToWrite)
        {
            throw new NotImplementedException();
        }
    }

    public class DIReaderWriter : IInputOutput
    {
        private string Path;

        public DIReaderWriter(string Path)
        {
            this.Path = Path;
        }

        public T Read<T>()
        {
            return FileIO.FileRead<T>(Path);
        }

        public bool Write<T>(T objectToWrite)
        {
            return FileIO.FileWrite(Path, objectToWrite);
        }
    }
}
