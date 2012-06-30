using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace common
{
    public class MyControl : UserControl
    {
        //设置输入法
        [DllImport("coredll.dll")]
        public static extern bool SipShowIM(int dwFlag);
        //声音
        [DllImport("CoreDll.dll")]
        public static extern void MessageBeep(int code); 


        protected Util.Resource resource;

        public MyControl()
        {
            resource = Util.Resource.getResouce();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Name = "MyControl";
            this.ResumeLayout(false);

        }

    }
}
