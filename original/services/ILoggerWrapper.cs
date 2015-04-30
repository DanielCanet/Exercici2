using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.services
{
    interface ILoggerWrapper
    {
        bool Error(Exception messageError);
    }
}
