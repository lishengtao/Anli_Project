using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Model;

namespace view
{
    partial class BrandForm : common.MyForm
    {
        private Service.IService service = null;
        

        private string flag;

        public void setFlag(string flag)
        {
            this.flag = flag;
        }

        public string getFlag()
        {
            return this.flag;
        }

        private Brand brand = null;

        public void setBrand(Brand brand)
        {
            this.brand = brand;
        }

        public Brand getBrand()
        {
            return this.brand;
        }

        public BrandForm()
        {
            InitializeComponent();
            this.service = new Service.ServiceImpl();
            init();
        }


        public void init()
        {
            if(this.brand != null)
                this.brandNameTextBox.Text = this.brand.getBrandName();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string brandName = this.brandNameTextBox.Text;

            if (Util.Utils.isNullOrEmpty(brandName))
            {
                MessageBox.Show("请先填写标签名称！");
            }
            else
            {
                if (this.flag.Equals("add"))
                {
                    if (this.service.isInTable("brand", "brand_name", brandName))
                    {
                        this.brandNameTextBox.Focus();
                        MessageBox.Show("此品牌已经存在！");
                    }
                    else
                    {
                        this.service.addBrand(new Brand(brandName));
                        this.DialogResult = DialogResult.OK;
                    }
                }
                if (this.flag.Equals("update"))
                {
                    if (brandName.Equals(this.brand.getBrandName()))
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("请更新品牌名字！");
                    }else
                    {
                        if (this.service.isInTable("brand", "brand_name", brandName))
                        {
                            this.brandNameTextBox.Focus();
                            MessageBox.Show("此品牌已经存在！");
                        }
                        else
                        {
                            this.brand.setBrandName(brandName);
                            this.service.updateBrand(this.brand);
                            this.DialogResult = DialogResult.OK;
                        }
                    }

                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
