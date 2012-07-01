namespace view
{
    partial class CustomerManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cutomerListView = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.cardNo = new System.Windows.Forms.ColumnHeader();
            this.birthday = new System.Windows.Forms.ColumnHeader();
            this.profession = new System.Windows.Forms.ColumnHeader();
            this.isMarried = new System.Windows.Forms.ColumnHeader();
            this.incomeLevel = new System.Windows.Forms.ColumnHeader();
            this.familyLevel = new System.Windows.Forms.ColumnHeader();
            this.fristContactTime = new System.Windows.Forms.ColumnHeader();
            this.type = new System.Windows.Forms.ColumnHeader();
            this.makeCardTime = new System.Windows.Forms.ColumnHeader();
            this.extendCardTime = new System.Windows.Forms.ColumnHeader();
            this.extendCardNum = new System.Windows.Forms.ColumnHeader();
            this.email = new System.Windows.Forms.ColumnHeader();
            this.level = new System.Windows.Forms.ColumnHeader();
            this.telephone = new System.Windows.Forms.ColumnHeader();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 338);
            this.panel1.TabIndex = 0;
            // 
            // cutomerListView
            // 
            this.cutomerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.cardNo,
            this.birthday,
            this.profession,
            this.isMarried,
            this.incomeLevel,
            this.familyLevel,
            this.fristContactTime,
            this.type,
            this.makeCardTime,
            this.extendCardTime,
            this.extendCardNum,
            this.email,
            this.level,
            this.telephone});
            this.cutomerListView.FullRowSelect = true;
            this.cutomerListView.GridLines = true;
            this.cutomerListView.Location = new System.Drawing.Point(3, 21);
            this.cutomerListView.Name = "cutomerListView";
            this.cutomerListView.ShowGroups = false;
            this.cutomerListView.Size = new System.Drawing.Size(890, 338);
            this.cutomerListView.TabIndex = 0;
            this.cutomerListView.UseCompatibleStateImageBehavior = false;
            this.cutomerListView.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 0;
            // 
            // name
            // 
            this.name.Text = "姓名";
            this.name.Width = 76;
            // 
            // cardNo
            // 
            this.cardNo.DisplayIndex = 3;
            this.cardNo.Text = "安利卡号";
            this.cardNo.Width = 86;
            // 
            // birthday
            // 
            this.birthday.DisplayIndex = 2;
            this.birthday.Text = "出生日期";
            this.birthday.Width = 87;
            // 
            // profession
            // 
            this.profession.Text = "职业";
            this.profession.Width = 85;
            // 
            // isMarried
            // 
            this.isMarried.Text = "婚姻状况";
            this.isMarried.Width = 87;
            // 
            // incomeLevel
            // 
            this.incomeLevel.Text = "经济状况";
            this.incomeLevel.Width = 89;
            // 
            // familyLevel
            // 
            this.familyLevel.Text = "家庭整体状况";
            this.familyLevel.Width = 91;
            // 
            // fristContactTime
            // 
            this.fristContactTime.Text = "首次接触时间";
            this.fristContactTime.Width = 92;
            // 
            // type
            // 
            this.type.Text = "客户类型";
            this.type.Width = 91;
            // 
            // makeCardTime
            // 
            this.makeCardTime.Text = "办卡日期";
            this.makeCardTime.Width = 85;
            // 
            // extendCardTime
            // 
            this.extendCardTime.Text = "续卡日期";
            // 
            // extendCardNum
            // 
            this.extendCardNum.Text = "续卡次数";
            // 
            // email
            // 
            this.email.Text = "电子邮箱";
            // 
            // level
            // 
            this.level.Text = "客户级别";
            // 
            // telephone
            // 
            this.telephone.Text = "联系方式";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(53, 366);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "增加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(199, 366);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "修改";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(345, 366);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(491, 365);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "退出";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // CustomerManageForm
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 474);
            this.Controls.Add(this.cutomerListView);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerManageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客户管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView cutomerListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader cardNo;
        private System.Windows.Forms.ColumnHeader birthday;
        private System.Windows.Forms.ColumnHeader profession;
        private System.Windows.Forms.ColumnHeader isMarried;
        private System.Windows.Forms.ColumnHeader incomeLevel;
        private System.Windows.Forms.ColumnHeader familyLevel;
        private System.Windows.Forms.ColumnHeader fristContactTime;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader makeCardTime;
        private System.Windows.Forms.ColumnHeader extendCardTime;
        private System.Windows.Forms.ColumnHeader extendCardNum;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.ColumnHeader level;
        private System.Windows.Forms.ColumnHeader telephone;
    }
}