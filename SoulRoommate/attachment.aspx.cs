using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using BLL;
using Model;

namespace SoulRoommate
{
    public partial class attachment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有文件
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
               // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('请您选择Excel文件')", true);
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls")
            {
                Response.Write(FileUpload1.FileName);
                Response.Write("<script>alert('只可以选择Excel文件')</script>");
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('只可以选择Excel文件')", true);
                return;//当选择的不是Excel文件时,返回
            }

            string filename = FileUpload1.FileName;//获取Execle文件名 
            string savePath = Server.MapPath(("~/File/") + filename);//Server.MapPath 服务器上的指定虚拟路径相对应的物理文件路径
                                                                     //savePath ="D:\vsproject\Projects\exceltestweb\exceltestweb\uploadfiles\test.xls"
                                                                     //Response.Write(savePath);
            DataTable ds = new DataTable();
            FileUpload1.SaveAs(savePath);//将文件保存到指定路径

            DataTable dt = GetExcelDatatable(savePath);//读取excel数据
            gvInfo.DataSource = dt;
            gvInfo.DataBind();
            //存入数据库
            //SaveData(dt);
            File.Delete(savePath);//删除文件

            Response.Write("<script>alert('上传文件读取数据成功')</script> ");
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('上传文件读取数据成功')", true);
        }
        /// <summary>
        /// 从excel文件中读取数据
        /// </summary>
        /// <param name="fileUrl">实体文件的存储路径</param>
        /// <returns></returns>
        private static DataTable GetExcelDatatable(string fileUrl)
        {
            //支持.xls和.xlsx，即包括office2010等版本的;HDR=Yes代表第一行是标题，不是数据；
            string cmdText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileUrl + "; Extended Properties=\"Excel 12.0;HDR=Yes\"";
            DataTable dt = null;
            //建立连接
            OleDbConnection conn = new OleDbConnection(cmdText);
            try
            {
                //打开连接
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string strSql = "select * from [Sheet1$]"; //这里指定表明为Sheet1,如果修改过表单的名称，请使用修改后的名称

                //string strSql = "select * from [sr_user]";
                OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 将数据存入数据库
        /// </summary>
        /// <param name="tab"></param>
        protected void SaveData(DataTable tab)
        {
            User us = null;
            Good good = null;
            for (int i = 0; i < tab.Rows.Count; i++)
            {
                us = new User()
                {
                    Identity = (string)tab.Rows[i]["Identity"],
                    Email = (string)tab.Rows[i]["Email"],
                    Name = (string)tab.Rows[i]["Name"],
                    StudentNumber = (string)tab.Rows[i]["StudentNumber"],
                    College = (string)tab.Rows[i]["College"],
                    Major = (string)tab.Rows[i]["Major"],
                    Sex = (string)tab.Rows[i]["Sex"],
                };
                //接着写插入数据的方法即可
                bool a = AdminBLL.InsertNewStudents(us);
                //将学生信息插入到good表中，以使得学生可以填写good相关信息
                good = new Good()
                {
                    UserID = (string)tab.Rows[i]["Identity"],
                    State = 0
                };
                //接着写插入数据的方法即可
                bool b = AdminBLL.InsertNewStudentInGood(good);
            }
        }
    }
}