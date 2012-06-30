using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Util
{
    class SysConfig
    {
        /// <summary>
        /// 远程数据库服务器地址
        /// </summary>
        private string m_RemoteIP;
        /// <summary>
        /// 远程SQLIIS代理虚拟目录
        /// </summary>
        private string m_InternetDir;
        /// <summary>
        /// 远程数据库名称
        /// </summary>
        private string m_DBName;
        /// <summary>
        /// 远程数据库登录密码
        /// </summary>
        private string m_DBPwd;
        /// <summary>
        /// 远程数据库登录用户名
        /// </summary>
        private string m_DBUser;
        /// <summary>
        /// 应用程序本地路径
        /// </summary>
        private static string LocalFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        /// <summary>
        /// 本地配置文件路径及名称
        /// </summary>
        private string LocalConfigFilePath = LocalFilePath + "\\config.xml";

        /// <summary>
        /// 本地连接字符串
        /// </summary>
        public string LocalConnString
        {
            get
            {
                return "Data Source = " + LocalFilePath + "\\" + m_DBName +".sdf";
            }
        }

        /// <summary>
        /// SQL RDA服务地址字符串
        /// </summary>
        public string InternetUrl
        {
            get
            {
                return @"http://" + m_RemoteIP + "/" + m_InternetDir + "/sqlcesa30.dll";
            }
        }

        /// <summary>
        /// 远程数据库名称
        /// </summary>
        public string DBName
        {
            get
            {
                return m_DBName;
            }
            set
            {
                m_DBName = value;
            }
        }

        /// <summary>
        /// 远程数据库登录帐号
        /// </summary>
        public string DBUser
        {
            get
            {
                return m_DBUser;
            }
            set
            {
                m_DBUser = value;
            }
        }

        /// <summary>
        /// 远程数据库登录密码
        /// </summary>
        public string DBPwd
        {
            get
            {
                return m_DBPwd;
            }
            set
            {
                m_DBPwd = value;
            }
        }

        /// <summary>
        /// 是否存在配置文件
        /// </summary>
        public bool haveConfigFile
        {
            get
            {
                if (File.Exists(LocalConfigFilePath))
                    return true;

                else
                    return false;
            }
        }

        /// <summary>
        /// 数据库文件是否存在
        /// </summary>
        public bool haveDatabase
        {
            get
            {
                if (!File.Exists(LocalDBFile))
                    return false;

                else
                    return true;
            }

        }

        /// <summary>
        /// 远程服务器地址
        /// </summary>
        public string RemoteIP
        {
            get
            {
                return m_RemoteIP;
            }
            set
            {
                m_RemoteIP = value;
            }
        }

        /// <summary>
        /// 本地数据库文件路径及名称
        /// </summary>
        public String LocalDBFile
        {
            get
            {
                return LocalFilePath + "\\" + m_DBName + ".sdf";
            }

        }

        /// <summary>
        /// IIS虚拟服务名称
        /// </summary>
        public string InternetDir
        {
            get
            {
                return m_InternetDir;
            }
            set
            {
                m_InternetDir = value;
            }
        }


        /// <summary>
        /// 读取和保存配置文件所使用的方法
        /// </summary>
        private bool SetConfig(bool isGet)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(LocalConfigFilePath);
            if (xmlDoc == null)
            {
                return false;
            }

            XmlNode firstNode = xmlDoc.SelectSingleNode("RemoteServerConfig");
            if (firstNode == null)
            {
                return false;
            }
            XmlElement firstElement = (XmlElement)firstNode;
            XmlNodeList secondNodeList = firstElement.GetElementsByTagName("rdaConfig");

            if (secondNodeList == null)
            {
                return false;
            }

            foreach (XmlNode node in secondNodeList)
            {
                foreach (XmlNode ipNode in node)
                {
                    XmlElement el = (XmlElement)ipNode;
                    if (el.Name == "RemoteIP")
                    {
                        if (isGet)
                        {
                            m_RemoteIP = el.InnerText;
                        }
                        else
                        {
                            el.InnerText = m_RemoteIP;
                        }
                    }
                    else if (el.Name == "InternetDir")
                    {
                        if (isGet)
                        {
                            m_InternetDir = el.InnerText;
                        }
                        else
                        {
                            el.InnerText = m_InternetDir;
                        }
                    }
                    else if (el.Name == "DBName")
                    {
                        if (isGet)
                        {
                            m_DBName = el.InnerText;
                        }
                        else
                        {
                            el.InnerText = m_DBName;
                        }
                    }
                    else if (el.Name == "DBUser")
                    {
                        if (isGet)
                        {
                            m_DBUser = el.InnerText;
                        }
                        else
                        {
                            el.InnerText = m_DBUser;
                        }
                    }
                    else if (el.Name == "DBPwd")
                    {
                        if (isGet)
                        {
                            m_DBPwd = el.InnerText;
                        }
                        else
                        {
                            el.InnerText = m_DBPwd;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }




            //保存更改
            try
            {
                if (!isGet)
                {
                    xmlDoc.Save(LocalConfigFilePath);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        public bool saveConfig()
        {
            if (!File.Exists(LocalConfigFilePath))
            {
                return false;
            }
            return SetConfig(false);
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public bool readConfig()
        {
            if (!File.Exists(LocalConfigFilePath))
            {
                return false;
            }
            return SetConfig(true);
        }
    }
}
