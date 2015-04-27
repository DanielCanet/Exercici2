using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace exercici2.original.services
{
    class LoggerWrapper
    {
        public bool Error(Exception messageError)
        {
            try 
            {
                Logger.Error("Problem sending notification email", messageError);
                return true;
            }
            catch(Exception ex)
            {   
                return false;
            }            
        }


    }
}
