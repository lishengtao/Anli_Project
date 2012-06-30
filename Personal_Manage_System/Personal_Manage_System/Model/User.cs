using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class User : BusinessModel
    {
        private string name;

        private string password;

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getPassword()
        {
            return this.password;
        }
    }
}
