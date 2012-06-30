using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Category : BusinessModel
    {

        private string categoryName;

        private float netRate;

        private string brandName;

        private int brandId;

        public Category()
        {
        }

        public Category(string categoryName, float netRate, string brandName)
        {
            this.categoryName = categoryName;
            this.netRate = netRate;
            this.brandName = brandName;

        }
        public Category(string categoryName, float netRate, int brandId)
        {
            this.categoryName = categoryName;
            this.netRate = netRate;
            this.brandId = brandId;

        }

        public void setCategoryName(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public string getCategoryName()
        {
            return this.categoryName;
        }

        public void setNetRate(float netRate)
        {
            this.netRate = netRate;
        }

        public float getNetRate()
        {
            return this.netRate;
        }

        public void setBrandName(string brandName)
        {
            this.brandName = brandName;
        }

        public string getBrandName()
        {
            return this.brandName;
        }

        public void setBrandId(int brandId)
        {
            this.brandId = brandId;
        }

        public int getBrandId()
        {
            return this.brandId;
        }


    }
}
