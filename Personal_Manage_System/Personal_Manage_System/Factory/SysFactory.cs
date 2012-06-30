using System;

using System.Collections.Generic;
using System.Text;
using DB;

namespace Factory
{
    class SysFactory
    {
        public static DBManager getDBManager()
        {
            return DBManager.getInstance();
        }

    }
}
