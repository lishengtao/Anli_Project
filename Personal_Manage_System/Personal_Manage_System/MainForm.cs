using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace Personal_Manage_System
{
    public partial class MainForm : common.MyForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.Text = this.resource.getMsg("sys_name");


            this.menuItem1.Text = this.resource.getMsg("product_manage");
            this.menuItem11.Text = this.resource.getMsg("type_manage");
            this.menuItem12.Text = this.resource.getMsg("product_manage");
            this.menuItem13.Text = this.resource.getMsg("brand_manage");

            this.menuItem2.Text = this.resource.getMsg("inventory_manage");
            this.menuItem21.Text = this.resource.getMsg("input_product");
            this.menuItem22.Text = this.resource.getMsg("output_product");

            this.menuItem3.Text = this.resource.getMsg("client_manage");
            this.menuItem31.Text = this.resource.getMsg("client_manage");

            this.menuItem4.Text = this.resource.getMsg("analysis");
            this.menuItem41.Text = this.resource.getMsg("analysis");

            this.menuItem5.Text = this.resource.getMsg("sys_manage");
            this.menuItem51.Text = this.resource.getMsg("sys_manage");

            this.menuItem6.Text = this.resource.getMsg("about");

        }


        private void menuItem13_Click(object sender, EventArgs e)
        {

            new view.BrandManageForm().ShowDialog();

            
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            new view.CategoryManageForm().ShowDialog();
        }

        private void menuItem31_Click(object sender, EventArgs e)
        {
            new view.CustomerManageForm().ShowDialog();
        }
    }
}
