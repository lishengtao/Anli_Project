using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace util
{
    class TypeConverter
    {
        public static IncomeLevel int2IncomeLevel(int level)
        {
            switch (level)
            {
                case 0: return IncomeLevel.BAD;
                case 1: return IncomeLevel.GOOD;
                default: return IncomeLevel.GOOD;
            }
        }

        public static FamilyLevel int2FamilyLevel(int level)
        {
            switch (level)
            {
                case 1: return FamilyLevel.LOW;
                case 2: return FamilyLevel.MEDIUM;
                case 3: return FamilyLevel.HIGH;
                default: return FamilyLevel.MEDIUM;
            }
        }

        public static CustomerType int2CustomerType(int type)
        {
            switch (type)
            {
                case 1: return CustomerType.AGENT;
                case 2: return CustomerType.PERSONAL;
                case 3: return CustomerType.OTHER;
                default: return CustomerType.PERSONAL;
            }
        }

        public static CustomerLevel int2CustomerLevel(int level)
        {
            switch (level)
            {
                case 1: return CustomerLevel.LOW;
                case 2: return CustomerLevel.MEDIUM;
                case 3: return CustomerLevel.HIGH;
                default: return CustomerLevel.MEDIUM;
            }
        }

    }
}
