using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class BusinessModel
    {
        protected int id;

        public BusinessModel()
        {
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
