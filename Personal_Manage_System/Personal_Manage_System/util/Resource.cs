using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Threading;


namespace Util
{
    public class Resource
    {
        private ResourceManager rm;
        private static volatile Resource resource = null;
        private static object syncRoot = new Object();

        public static Resource getResouce()
        {

            if (null == resource)
            {
                lock (syncRoot)
                {
                    if (null == resource)
                        resource = new Resource();
                }
            }
            return resource;

        }


        private Resource()
        {
            rm = new ResourceManager("Personal_Manage_System.Resource.Resource", Assembly.GetExecutingAssembly());
        }

        public System.Drawing.Bitmap GetImage(string strObjectId)
        {
            object obj = rm.GetObject(strObjectId);
            return (System.Drawing.Bitmap)obj;
        }

        public string getMsg(string strId)
        {
            string currentLanguage = "";
            try
            {
                CultureInfo ci = CultureInfo.CurrentCulture;
              
                currentLanguage = rm.GetString(strId, ci);
            }
            catch
            {
                currentLanguage = "Cannot Found:" + strId +
                    " , Please Add it to Resource File.";
            }
            return currentLanguage;

        }

    }
}
