using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Tools.Exceptions
{
    internal class TooOldException : Exception
    {
        public TooOldException() : base("Not possible to be over 135 years!")
        {
        }
    }
}
