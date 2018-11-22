using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IInputOutput
    {

        bool Write<T>(T objectToWrite);
        T Read<T>();

    }
}
