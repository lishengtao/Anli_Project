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
    public partial class BrandManageForm : common.MyForm
    {
        private Service.IService service = null;
        public BrandManageForm()
        {
            InitializeComponent();
            this.Text = this.resource.getMsg("brand_manage");

            this.service = new Service.ServiceImpl();
            initListView();
        }

        public void initListView()
        {
            this.brandListView.Items.Clear();
            List<Brand> brands = this.service.findBrands();

            ListViewItem ls = null;

            foreach (Brand brand in brands)
            {
                ls = new ListViewItem(brand.Id.ToString());
                ls.SubItems.Add(brand.getBrandName());
                this.brandListView.Items.Add(ls);
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            BrandForm brandForm = new BrandForm();
            brandForm.setFlag("add");
            if (brandForm.ShowDialog() == DialogResult.OK)
            {
                initListView();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.brandListView.FocusedItem;
            if (null != item)
            {
                BrandForm brandForm = new BrandForm();

                Model.Brand brand = new Brand(item.SubItems[1].Text);
                brand.Id  = Int32.Parse(item.SubItems[0].Text);

                brandForm.setBrand(brand);
                brandForm.init();

                brandForm.setFlag("update");

                if (brandForm.ShowDialog() == DialogResult.OK)
                {
                    initListView();
                }
            }
            else
            {
                MessageBox.Show("请先选择品牌！");
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.brandListView.FocusedItem;
            if (null != item)
            {
                if((this.service.findIdByColomn("category","brand",int.Parse(item.SubItems[0].Text))) == -1)
                {
                    Brand brand = new Brand(item.SubItems[1].Text);
                    brand.Id = int.Parse(item.SubItems[0].Text);
                    this.service.deleteBusinessModel("brand",brand);
                    initListView();
                }
                else
                    MessageBox.Show("请先删除与其相关的类别和产品！");
            }
            else
            {
                MessageBox.Show("请先选择品牌！");
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
