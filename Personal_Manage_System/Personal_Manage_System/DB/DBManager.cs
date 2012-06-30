using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Util;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using Exceptions;

namespace DB
{
    class DBManager
    {
        public static SysConfig cfg = null;

        private static volatile DBManager dbManager = null;
        private static object syncRoot = new Object(); 

        /**
         * 
         * 构造函数，单例
         * 
         * */
        private DBManager()
        {
            cfg = new SysConfig();

            if (!cfg.haveConfigFile)
            {
                //MessageBox.Show("配置文件config.xml不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //return;
                throw new MyException("配置文件config.xml不存在！");
            }
            if(!cfg.readConfig())
            {
                //MessageBox.Show("读取配置文件失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //return;
                throw new MyException("读取配置文件失败！");
            }

        }
        /**
         * 
         * 创建PDA端的数据库,并且初始化数据库。包括出库表，返库表，入库表
         * 
         * */
        public bool createDB()
        {
            try
            {
                if (!System.IO.File.Exists(cfg.LocalDBFile))
                {
                    SqlCeEngine ECsqlEngine = new SqlCeEngine(cfg.LocalConnString);
                    ECsqlEngine.CreateDatabase();
                    ECsqlEngine.Dispose();

                    string outLibrary = @"CREATE TABLE OUT_LIBRARY (epc nvarchar(32) NOT NULL,time datetime,person nvarchar(32), salepointcode nvarchar(50))";
                    string backLibrary = @"CREATE TABLE BACK_LIBRARY (epc nvarchar(32) NOT NULL,time datetime, person nvarchar(32))";
                    string inLibrary = @"CREATE TABLE IN_LIBRARY (epc nvarchar(32) NOT NULL,time datetime, person nvarchar(32))";
                    //string manufacture = @"CREATE TABLE MANUFACTURE (manufacture_code nvarchar(32) NOT NULL,name nvarchar(64),address nvarchar(64),license nvarchar(32))";
                    string classify = @"CREATE TABLE PRODUCT_CLASSIFY (code nvarchar(32) NOT NULL,name nvarchar(64))";
                    string product = @"CREATE TABLE PRODUCT (product_code nvarchar(32) NOT NULL,product_name nvarchar(64),classify nvarchar(64),format nvarchar(64),level nvarchar(64),location nvarchar(64))";
                    string account = @"CREATE TABLE ACCOUNT (name nvarchar(32) NOT NULL,password nvarchar(32))";
                    string salePoint = @"CREATE TABLE SALEPOINT (code nvarchar(50) NOT NULL,name nvarchar(50))";

                    DBAccess dbAccess = new SqlCeDBAccess();
                    dbAccess.excute(outLibrary);
                    dbAccess.excute(backLibrary);
                    dbAccess.excute(inLibrary);
                    //dbAccess.excute(manufacture);
                    dbAccess.excute(classify);
                    dbAccess.excute(product);
                    dbAccess.excute(account);
                    dbAccess.excute(salePoint);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;

        }

        /**
         * 
         * 获取DBManager实例
         * 
         * */
        public static DBManager getInstance()
        {
            if (null == dbManager)
            {
                lock (syncRoot)
                {
                    if (null == dbManager)
                        dbManager = new DBManager();
                } 
            }
            return dbManager;
        }

        /**
         * 
         * 获取数据库连接
         * 
         * */
        public SqlConnection getConnection()
        {
            SqlConnection conn = null;
            try
            {
                string conString = @"Data Source=" + cfg.RemoteIP + ";Initial Catalog=" + cfg.DBName + ";User ID=" + cfg.DBUser + ";Password=" + cfg.DBPwd + ";";
                conn = new SqlConnection(conString);

                conn.Open();

            }catch(Exception e)
            {
                //MessageBox.Show("打开数据库连接失败\n" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw new MyException("打开数据库连接失败\n" + e.Message);
            }
            return conn;
        }

        /**
         * 
         * 获取sqlce数据库连接
         * 
         * */
        public SqlCeConnection getSqlCeConnection()
        {
            SqlCeConnection conn = null;
            try
            {
                string conString = cfg.LocalConnString;
                conn = new SqlCeConnection(conString);
                conn.Open();

            }
            catch (Exception e)
            {
                //MessageBox.Show("打开数据库连接失败\n" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw new MyException("打开数据库连接失败\n" + e.Message);
            }
            return conn;
        }
        /**
         * 
         * 关闭数据库连接
         * 
         * */
        public void closeConn(SqlConnection conn)
        {
            if (null != conn)
            {
                conn.Close();
            }
        }


    }
}
