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
    public partial class CategoryManageForm : common.MyForm
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




        public CategoryManageForm()
        {
            InitializeComponent();
            this.Text = "类别管理";
            this.service = new Service.ServiceImpl();
            initListView();
        }

        public void initListView()
        {
            this.categoryListView.Items.Clear();
            List<Category> categorys = this.service.findCategorys();

            ListViewItem ls = null;

            foreach (Category category in categorys)
            {
                ls = new ListViewItem(category.Id.ToString());
                ls.SubItems.Add(category.getCategoryName());
                ls.SubItems.Add(category.getNetRate().ToString());
                ls.SubItems.Add(category.getBrandName());
                ls.SubItems.Add(category.getBrandId().ToString());

                this.categoryListView.Items.Add(ls);
            }

        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.setFlag("add");
            if (categoryForm.ShowDialog() == DialogResult.OK)
            {
                initListView();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.categoryListView.FocusedItem;
            if (null != item)
            {
                CategoryForm categoryForm = new CategoryForm();

                Category category = new Category(item.SubItems[1].Text,float.Parse(item.SubItems[2].Text),int.Parse(item.SubItems[4].Text));
                category.Id = Int32.Parse(item.SubItems[0].Text);

                categoryForm.setCategory(category);
                categoryForm.init();

                categoryForm.setFlag("update");

                if (categoryForm.ShowDialog() == DialogResult.OK)
                {
                    initListView();
                }
            }
            else
            {
                MessageBox.Show("请先选择类别！");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
