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
    partial class CategoryForm : common.MyForm
    {
        

        private Service.IService service = null;

        private Category category = null;

        public void setCategory(Category category)
        {
            this.category = category;
        }

        public Category getCategory()
        {
            return this.category;
        }

        private string flag;

        public void setFlag(string flag)
        {
            this.flag = flag;
        }

        public string getFlag()
        {
            return this.flag;
        }


        public CategoryForm()
        {
            InitializeComponent();
            this.service = new Service.ServiceImpl();
            init();
        }



        public void init()
        {
            List<Brand> brands = this.service.findBrands();
            
            this.brandComboBox.DisplayMember = "BrandName";
            this.brandComboBox.ValueMember = "Id";
            this.brandComboBox.DataSource = brands;

            if (this.category != null)
            {
                this.categoryNameTextBox.Text = this.category.getCategoryName();
                this.netRateTextBox.Text = this.category.getNetRate().ToString();
                this.brandComboBox.SelectedValue = this.category.getBrandId();
            }

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string categoryName = this.categoryNameTextBox.Text;
            string netRate = this.netRateTextBox.Text;
            float netRateValue = -1;

            if (Util.Utils.isNullOrEmpty(netRate))
            {
                netRateValue = float.NaN;
            }
            else
            {
                try
                {
                    netRateValue = float.Parse(netRate);

                    if (!(netRateValue >= 0 && netRateValue <= 1))
                    {
                        MessageBox.Show("净额率应该在0到1之间！");
                        this.netRateTextBox.Focus();
                        return;
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("请输入数字！");
                    this.netRateTextBox.Focus();
                    return;
                }
            }


            int brandId = (int)this.brandComboBox.SelectedValue;



            if (Util.Utils.isNullOrEmpty(categoryName))
            {
                MessageBox.Show("请先填写类别名称！");
                return;
            }
            if(this.flag.Equals("add"))
            {
                if (this.service.isInTable("category", "category_name", categoryName))
                {
                    this.categoryNameTextBox.Focus();
                    MessageBox.Show("此类别已经存在！");
                }
                else
                {
                    this.service.addCategory(new Category(categoryName, netRateValue, brandId));
                    this.DialogResult = DialogResult.OK;
                }
            }
            if(this.flag.Equals("update"))
            {


                this.category.setCategoryName(categoryName);
                this.category.setNetRate(netRateValue);
                this.category.setBrandId(brandId);
                this.service.updateCategory(this.category);

                this.DialogResult = DialogResult.OK;
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
