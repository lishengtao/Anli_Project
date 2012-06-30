using System;

using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    class MyException : Exception
    {
        public MyException(string msg) : base(msg)
        {
        }
    }
}
