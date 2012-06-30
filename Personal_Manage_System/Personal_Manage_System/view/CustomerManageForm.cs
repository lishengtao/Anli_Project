using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Service;

namespace view
{
    public partial class CustomerManageForm : common.MyForm
    {
        private ICustomerService service = null;
        public CustomerManageForm()
        {
            InitializeComponent();
            this.Text = this.resource.getMsg("client_manage");

            this.service = new CustomerServiceImpl();
            initListView();
        }

        public void initListView()
        {
            this.cutomerListView.Items.Clear();
            List<Customer> customers = this.service.findCustomers();

            ListViewItem ls = null;

            foreach (Customer customer in customers)
            {
                ls = new ListViewItem(customer.Id.ToString());
                //ls.SubItems.Add(brand.getBrandName());
                this.cutomerListView.Items.Add(ls);
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
            ListViewItem item = this.cutomerListView.FocusedItem;
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
            ListViewItem item = this.cutomerListView.FocusedItem;
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
