using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Util;
using System.Runtime.InteropServices;

namespace common
{
  
    public class MyForm : Form
    {
        private Panel mainPanel;
        protected Util.Resource resource;


        public MyForm()
        {
            resource = Util.Resource.getResouce();
        }

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(292, 266);
            this.mainPanel.TabIndex = 0;
            // 
            // MyForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.mainPanel);
            this.Name = "MyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }


    }
}
