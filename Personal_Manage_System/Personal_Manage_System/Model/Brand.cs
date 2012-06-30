using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Brand :BusinessModel
    {

        /**
         * 品牌名字
         * 
         * */
        private string brandName;

        public Brand()
        {
        }
        public Brand(string brandName)
        {
            this.brandName = brandName;
        }


        public string BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }

        public void setBrandName(string brandName)
        {
            this.brandName = brandName;
        }

        public string getBrandName()
        {
            return this.brandName;
        }
    }
}
