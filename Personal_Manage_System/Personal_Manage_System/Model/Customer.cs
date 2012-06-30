using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Customer : BusinessModel
    {
        public Customer() { }

        public Customer(string name) { this.name = name; }

        public string name { get; set; }

        public string cardNo { get; set; }

        public DateTime birthday { get; set; }

        public string profession { get; set; }

        public bool isMarried { get; set; }

        public IncomeLevel incomeLevel { get; set; }

        public FamilyLevel familyLevel { get; set; }

        public CustomerType type { get; set; }

        public CustomerLevel level { get; set; }

        public string telephone { get; set; }

        public string email { get; set; }

        public DateTime firstContactTime { get; set; }

        public DateTime makeCardTime { get; set; }

        public DateTime extendCardTime { get; set; }

        public int extendCardNum { get; set; }

    }
}
