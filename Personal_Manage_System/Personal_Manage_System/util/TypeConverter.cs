using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using util;

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

        public static string incomeLevel2Str(Util.Resource resource, IncomeLevel level)
        {
            switch (level)
            {
                case IncomeLevel.GOOD: return resource.getMsg("good");
                case IncomeLevel.BAD: return resource.getMsg("bad");
                default: return resource.getMsg("good");
            }
        }

        public static string familyLevel2Str(Util.Resource resource, FamilyLevel level)
        {
            switch (level)
            {
                case FamilyLevel.LOW: return resource.getMsg("family_level_low");
                case FamilyLevel.MEDIUM: return resource.getMsg("family_level_medium");
                case FamilyLevel.HIGH: return resource.getMsg("family_level_high");
                default: return resource.getMsg("family_level_medium");
            }
        }

        public static string customerType2Str(Util.Resource resource, CustomerType type) 
        {
            switch (type)
            {
                case CustomerType.AGENT: return resource.getMsg("customer_type_agent");
                case CustomerType.PERSONAL: return resource.getMsg("customer_type_personal");
                case CustomerType.OTHER: return resource.getMsg("customer_type_other");
                default: return resource.getMsg("customer_type_personal");

            }
        }

        public static string customerLevel2Str(Util.Resource resource, CustomerLevel level)
        {
            switch (level)
            {
                case CustomerLevel.LOW: return resource.getMsg("customer_level_low");
                case CustomerLevel.MEDIUM: return resource.getMsg("customer_level_medium");
                case CustomerLevel.HIGH: return resource.getMsg("customer_level_high");
                default: return resource.getMsg("customer_level_medium");

            }
        }

    }
}
