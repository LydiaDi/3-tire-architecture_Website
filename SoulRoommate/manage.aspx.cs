using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
using System.IO;
using System.Data.OleDb;

namespace SoulRoommate
{
    public partial class manage : System.Web.UI.Page
    {
        //加载页面之前，读取Session["AdmainJobNum"] 的值，如果为空返回login页面
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["AdmainJobNum"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uid = Session["AdmainJobNum"].ToString();//记得用session存储
                lbUser.Text = AdminBLL.SelectName(uid);

                //main1模块显示全部学生信息、main5显示所有管理员收到的所有信息进行数据绑定
                Bind(AdminBLL.AllStudentInfo(), MessageBLL.AdminAllReceiveMes(uid));
                

                //mind3部分“进行寝室信息填写”的数据绑定
                Bind5();

                //main4模块的数据绑定
                Bind3();

                //right1模块个人信息部分数据绑定
                Bind4();
            }
        }

        /// <summary>
        /// main1上传excel表部分点击返回，进入main1主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpInfoBack_Click(object sender, EventArgs e)
        {
            plUpInfo.Visible = false;
            Panel1.Visible = true;
            Label3.Text = "查看信息";

            string uid = Session["AdmainJobNum"].ToString();
            //main1模块显示全部学生信息、main5显示所有管理员收到的所有信息进行数据绑定
            Bind(AdminBLL.AllStudentInfo(), MessageBLL.AdminAllReceiveMes(uid));
        }
        /// <summary>
        /// 下载标准文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDown_Click(object sender, EventArgs e)
        {
            // 定义文件路径
            string url = "";
            // 定义文件名
            string fileName = "";

            // 获取文件在服务器的地址
            url = "~/File/sr_user.xls";
            //Response.Write(e.CommandArgument.ToString());


            // 取得地址中的文件名

            #region 取得地址中的文件名
            // 判断传输地址是否为空
            if (url == "")
            {
                // 提示“该文件暂不提供下载”
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script defer>alert('该文件暂不提供下载！');</script>");
                return;
            }

            // 判断获取的是否为地址，而非文件名
            if (url.IndexOf("\\") > -1)
            {
                // 获取文件名
                fileName = url.Substring(url.LastIndexOf("\\") + 1);//获取文件名

            }
            else
            {
                // url为文件名时，直接获取文件名
                fileName = url;
            }
            #endregion

            //Response.Write(fileName);

            // 流方式下载文件 
            #region 流方式下载文件

            try
            {
                // 定义服务器路径
                string urlServer = Server.MapPath(url);

                // 以字符流的方式下载文件
                FileStream fileStream = new FileStream(urlServer, FileMode.Open);
                byte[] bytes = new byte[(int)fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                Response.ContentType = "application/octet-stream";

                // 通知浏览器下载而不是打开
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            {

            }
            
            #endregion
        }
        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (ExcelFileUpload.HasFile == false)//HasFile用来检查FileUpload是否有文件
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                //ScriptManager.RegisterStartupScript(UpdatePanel5, UpdatePanel5.GetType(), "", "alert('请您选择Excel文件')", true);
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(ExcelFileUpload.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls")
            {
                Response.Write(ExcelFileUpload.FileName);
                Response.Write("<script>alert('只可以选择Excel文件')</script>");
                //ScriptManager.RegisterStartupScript(UpdatePanel5, UpdatePanel5.GetType(), "", "alert('只可以选择Excel文件')", true);
                return;//当选择的不是Excel文件时,返回
            }

            string filename = ExcelFileUpload.FileName;//获取Execle文件名 
            string savePath = Server.MapPath(("~/File/") + filename);//Server.MapPath 服务器上的指定虚拟路径相对应的物理文件路径
                                                                     //savePath ="D:\vsproject\Projects\exceltestweb\exceltestweb\uploadfiles\test.xls"
                                                                     //Response.Write(savePath);
            DataTable ds = new DataTable();
            ExcelFileUpload.SaveAs(savePath);//将文件保存到指定路径

            DataTable dt = GetExcelDatatable(savePath);//读取excel数据
            gvInfo.DataSource = dt;
            gvInfo.DataBind();
            //存入数据库
            SaveData(dt);
            File.Delete(savePath);//删除文件

            Response.Write("<script>alert('上传文件读取数据成功！')</script> ");
            //ScriptManager.RegisterStartupScript(UpdatePanel5, UpdatePanel5.GetType(), "", "alert('上传文件读取数据成功')", true);
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
                    State=0
                };
                //接着写插入数据的方法即可
                bool b = AdminBLL.InsertNewStudentInGood(good);
            }
        }
        /// <summary>
        /// main1数据绑定
        /// </summary>
        /// <param name="AllStudentInfo"></param>
        /// <param name="AllMesReceive"></param>
        private void Bind(DataTable AllStudentInfo, DataTable AllMesReceive)
        {
            //main1模块显示全部学生基本信息ListView进行数据绑定
            this.lvStudentInfo.DataSource = AllStudentInfo;
            this.lvStudentInfo.DataBind();

            //main5显示所有管理员收到的所有信息进行数据绑定
            this.lvMes.DataSource = AllMesReceive;
            this.lvMes.DataBind();

            //如果有未读消息，显示未读消息的个数，否则不显示任何提醒标志
            int count = MessageBLL.ReceiveMesCount(Session["AdmainJobNum"].ToString());
            if (count > 0)
            {
                lbMsgCount.Text = count.ToString();
            }
            else
            {
                lbMsgCount.Visible = false;
            }

            Main5Bind();
        }
        /// <summary>
        /// 与具体的字段绑定的Command事件集合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_GoodDetail(object sender, CommandEventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string UserID = lbtn.CommandArgument;

            //查看某一学生的具体GoodDetail的填写情况
            if (lbtn.CommandName.Equals("GoodDetail"))
            {
                if (AdminBLL.GoodDetailIsAny(UserID))
                {
                    Bind2(AdminBLL.StudentGoodDetail(UserID), AdminBLL.StudentGoodDetail2(UserID), AdminBLL.StudentGoodDetail3(UserID), AdminBLL.StudentGoodDetail4(UserID), AdminBLL.StudentGoodDetail5(UserID), AdminBLL.StudentGoodDetail6(UserID), AdminBLL.StudentGoodDetail7(UserID));//main1某一学生的具体GoodDetail的填写情况数据绑定
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('此学生尚未填写！')</script>");
                    //ScriptManager.RegisterStartupScript(UpdatePanel5, UpdatePanel5.GetType(), "", "alert('此学生尚未填写！')", true);

                }

            }
            if (lbtn.CommandName.Equals("SendUrge"))
            {
                Message urge = new Message()
                {
                    Accept = UserID,
                    Read = 0,
                    Content = "请尽快填写信息",
                    Time = DateTime.Now,
                    //Send = Session["ADMIN"].ToString();
                    Send = "111"
                };
                bool a = MessageBLL.InsertUrgeMessage(urge);
                if (a) {
                    //Response.Write("<script language='javascript'>alert('发送成功！')</script>"); 
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", "alert('发送成功！')", true);

                }
            }

            if (lbtn.CommandName.Equals("SeeCotent"))
            {
                string content = MessageBLL.SelectContent(Convert.ToInt32(UserID));
                //Response.Write("<script language='javascript'>alert('" + content + "')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('" + content + "')", true);

                Message mes = new Message()
                {
                    MID = Convert.ToInt32(UserID),
                    Read = 1
                };
                bool update = MessageBLL.ReadSuccess(mes);
                //Response.Redirect("manage.aspx");
                //main1模块显示全部学生信息、main5显示所有管理员收到的所有信息进行数据绑定
                Bind(AdminBLL.AllStudentInfo(), MessageBLL.AdminAllReceiveMes(Session["AdmainJobNum"].ToString()));
            }
            if (lbtn.CommandName.Equals("Delect"))
            {
                Message mes = new Message()
                {
                    MID = Convert.ToInt32(UserID),
                    Delect = 0
                };
                bool update = MessageBLL.Delect(mes);
                //main1模块显示全部学生信息、main5显示所有管理员收到的所有信息进行数据绑定
                Bind(AdminBLL.AllStudentInfo(), MessageBLL.AdminAllReceiveMes(Session["AdmainJobNum"].ToString()));
                if (update)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('删除成功！')", true);
                }
            }
            //点击回复按钮，回复模块Panel6进行显示
            if (lbtn.CommandName.Equals("Reply"))
            {
                Session.Add("MID", UserID);
                Panel4.Visible = false;
                Panel6.Visible = true;
            }
        }
        /// <summary>
        /// main1模块某一学生的具体GoodDetail的填写情况的数据绑定
        /// </summary>
        /// <param name="StudentGoodDetail"></param>
        private void Bind2(DataTable StudentGoodDetail, DataTable StudentGoodDetail2, DataTable StudentGoodDetail3, DataTable StudentGoodDetail4, DataTable StudentGoodDetail5, DataTable StudentGoodDetail6, DataTable StudentGoodDetail7)
        {
            this.lvStudentGoodDetail.DataSource = StudentGoodDetail;
            this.lvStudentGoodDetail.DataBind();

            this.ListView2.DataSource = StudentGoodDetail2;
            this.ListView2.DataBind();

            this.ListView3.DataSource = StudentGoodDetail3;
            this.ListView3.DataBind();

            this.ListView4.DataSource = StudentGoodDetail4;
            this.ListView4.DataBind();

            this.ListView5.DataSource = StudentGoodDetail5;
            this.ListView5.DataBind();

            this.ListView6.DataSource = StudentGoodDetail6;
            this.ListView6.DataBind();

            this.ListView7.DataSource = StudentGoodDetail7;
            this.ListView7.DataBind();
        }
        /// <summary>
        /// main1模块在显示学生的具体GoodDetail的填写情况部分点击返回按钮，此部分被隐藏，main1主体部分（所有学生基本信息）显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
        }
        /// <summary>
        /// main2模块第一步——对班级进行选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked) { Label11.Text = "您选择的班级是" + RadioButton1.Text; Session.Add("Select", RadioButton1.Text); Panel5.Enabled = false; }
            if (RadioButton2.Checked) { Label11.Text = "您选择的班级是" + RadioButton2.Text; Session.Add("Select", RadioButton2.Text); Panel5.Enabled = false; }
            if (RadioButton3.Checked) { Label11.Text = "您选择的班级是" + RadioButton3.Text; Session.Add("Select", RadioButton3.Text); Panel5.Enabled = false; }
            if (Panel5.Enabled)
            {
                Label11.Text = "请选择一个班级！";
            }
            else
            {
                Button2.Enabled = true;
            }
        }
        /// <summary>
        /// 查询所选择的班级是否全部已经填写了GoodDetail表中的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        protected void Button2_Click(object sender, EventArgs e)
        {
            //查找在第一步中所选择的班级是否存在没有填写GoodDetail表中的信息的学生
            bool exist = AdminBLL.NotWriteGoodIsAny(Session["Select"].ToString());
            if (exist)
            {
                DataTable n1 = AdminBLL.NotWriteGood(Session["Select"].ToString());
                //查找出没有填写GoodDetail表中的信息的学生，并将这些学生的信息进行绑定
                this.lvNotWrite1.DataSource = n1;
                this.lvNotWrite1.DataBind();
                Panel3.Visible = true;
                plManageMain2.Visible = false;
                Panel5.Enabled = true;
            }
            else
            {
                bool assignBoy= AdminBLL.AssignFinishBoy(Session["Select"].ToString());
                if (assignBoy)
                {
                    Button2.Enabled = false;
                    lbMsgAssignAgain.Text = "此班级已经进行了分配，是否要再次进行行分配？";
                    btnAssignAgain.Visible = true;
                    btnNotAssignAgain.Visible = true;
                }
                else
                {
                    Label13.Text = "此班级学生均完成了信息的填写！";
                    Button2.Enabled = false;
                    Button4.Enabled = true;
                }
            }
        }
        /// <summary>
        /// main2模块在显示没有填写学生信息的学生部分中点击返回按钮，此部分被隐藏，main2主体部分显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button17_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            plManageMain2.Visible = true;
        }
        /// <summary>
        /// 男生进行分配前准备工作——将数据库中sr_good表中需要进行分配的班级的男生的信息复制到sr_good_copy表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            string a = Session["Select"].ToString();
            DataTable dt = new DataTable();
            dt = AdminBLL.InCommonClassAndSex(a, "男");
            foreach (DataRow drow in dt.Rows)
            {
                GoodCopy g = new GoodCopy()
                {
                    UserID = drow["UserID"].ToString(),
                    A1sleepTime = Convert.ToDouble(drow["A1sleepTime"]),
                    A2upTime = Convert.ToDouble(drow["A2upTime"]),
                    A3noonNap = Convert.ToDouble(drow["A3noonNap"]),
                    A4averageTime = Convert.ToDouble(drow["A4averageTime"]),
                    A5sleepQuality = Convert.ToDouble(drow["A5sleepQuality"]),
                    A6snore = Convert.ToDouble(drow["A6snore"]),
                    B1fitCold = Convert.ToDouble(drow["B1fitCold"]),
                    B2fitHot = Convert.ToDouble(drow["B2fitHot"]),
                    B3airCon = Convert.ToDouble(drow["B3airCon"]),
                    B4minTem = Convert.ToDouble(drow["B4minTem"]),
                    B5maxTem = Convert.ToDouble(drow["B5maxTem"]),
                    C1shower = Convert.ToDouble(drow["C1shower"]),
                    C2cleanDesk = Convert.ToDouble(drow["C2cleanDesk"]),
                    C3cleanRubbish = Convert.ToDouble(drow["C3cleanRubbish"]),
                    C4makeBed = Convert.ToDouble(drow["C4makeBed"]),
                    C5washCloth = Convert.ToDouble(drow["C5washCloth"]),
                    D1smoke = Convert.ToDouble(drow["D1smoke"]),
                    D2game = Convert.ToDouble(drow["D2game"]),
                    D3volume = Convert.ToDouble(drow["D3volume"]),
                    D4express = Convert.ToDouble(drow["D4express"]),
                    D5coConsum = Convert.ToDouble(drow["D5coConsum"]),
                    D6elec = Convert.ToDouble(drow["D6elec"]),
                    D7con = Convert.ToDouble(drow["D7con"]),
                    D8unCon = Convert.ToDouble(drow["D8unCon"]),
                    D9coat = Convert.ToDouble(drow["D9coat"]),
                    D10uWear = Convert.ToDouble(drow["D10uWear"]),
                    D11maq = Convert.ToDouble(drow["D11maq"]),
                    D12outSide = Convert.ToDouble(drow["D12outSide"]),
                    E1income = Convert.ToDouble(drow["E1income"]),
                    E2perConsum = Convert.ToDouble(drow["E2perConsum"]),
                    F1sing = Convert.ToDouble(drow["F1sing"]),
                    F2musIns = Convert.ToDouble(drow["F2musIns"]),
                    F3dance = Convert.ToDouble(drow["F3dance"]),
                    F4draw = Convert.ToDouble(drow["F4draw"]),
                    F5white = Convert.ToDouble(drow["F5white"]),
                    F6ball = Convert.ToDouble(drow["F6ball"]),
                    F7tennis = Convert.ToDouble(drow["F7tennis"]),
                    F8run = Convert.ToDouble(drow["F8run"]),
                    F9bodyBuild = Convert.ToDouble(drow["F9bodyBuild"]),
                    F10yoga = Convert.ToDouble(drow["F10yoga"]),
                    F11swim = Convert.ToDouble(drow["F11swim"]),
                    F12movie = Convert.ToDouble(drow["F12movie"]),
                    F13live = Convert.ToDouble(drow["F13live"]),
                    F14claMusic = Convert.ToDouble(drow["F14claMusic"]),
                    F15idol = Convert.ToDouble(drow["F15idol"]),
                    F16ktv = Convert.ToDouble(drow["F16ktv"]),
                    G1sexOrient = Convert.ToDouble(drow["G1sexOrient"]),
                    G2noSingle = Convert.ToDouble(drow["G2noSingle"]),
                    G3inDisea = Convert.ToDouble(drow["G3inDisea"]),
                    G4family = Convert.ToDouble(drow["G4family"]),
                    G5parent = Convert.ToDouble(drow["G5parent"]),
                    G6interact = Convert.ToDouble(drow["G6interact"]),
                    State = 1
                };
                bool success = AdminBLL.InsertNewGood(g);
            }
            Button4.Enabled = false;
            Button3.Enabled = true;//只有进行分配前准备工作完成后，下一个按钮才允许被点击！
        }
        /// <summary>
        /// ▲▲▲男生开始分配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            //自己建立一个表——以one、two、three、four为表头的表assign
            DataTable assign = new DataTable();

            assign.Columns.Add(new DataColumn("one", typeof(string)));
            assign.Columns.Add(new DataColumn("two", typeof(string)));
            assign.Columns.Add(new DataColumn("three", typeof(string)));
            assign.Columns.Add(new DataColumn("four", typeof(string)));

            //将数据库中被选择班级的所有男生查询出来
            DataTable info = AdminBLL.InCommonClassAndSex2(Session["Select"].ToString(), "男");
            List<string> iden = null;//必须有这句话，否则会报“iden未引用到实例”的错误
            iden = new List<string>();
            //便历表info，并将所有的id值存在List<string> iden中
            foreach (DataRow drow in info.Rows)
            {
                iden.Add(drow["UserID"].ToString());
            }
            //便历iden这个列表
            foreach (string i in iden)
            {
                //判断该学生是否已经进行了分配
                bool exist = AdminBLL.ExistByUID(i);//在GoodCopy表中查询是否存在该uid记录
                bool otherExist = AdminBLL.PeopleGoodIsExist(i);////在GoodCopy表中查询是否存在uid之外的记录
                //对仅剩一个学生的情况进行处理
                if (exist == true && otherExist == false)
                {
                    //把仅剩的一个学生的Userid信息加到assign
                    DataRow newrow = assign.NewRow();
                    newrow["one"] = i;
                    newrow["two"] = "无";
                    newrow["three"] = "无";
                    newrow["four"] = "无";
                    assign.Rows.Add(newrow);
                    bool de = AdminBLL.DelectAGood(i);//在GoodCopy表中删除已经分配好的学生的记录行
                    ResultBoy b = new ResultBoy()
                    {
                        One = i,
                        Two = "无",
                        Three = "无",
                        Four = "无",
                        Class = Session["Select"].ToString(),
                        State = 0
                    };
                    bool b_success = AdminBLL.InsertResultBoy(b);//将这一条记录插入到reaultBoy表中
                }
                if (exist == true && otherExist == true)
                {
                    DataTable dt = new DataTable();
                    dt = AdminBLL.AllInfo(i, 4);//▲▲▲第一个参数是某一个学生的id值，第二个参数是指找出的与第一个传入的参数id为i的学生的最相近的前几个人的个数
                    if (dt.Rows.Count < 4)
                    {
                        //因为前面对仅剩一个学生的情况已经进行了单独处理，所以其实count==1的情况应当是不存在的，又因为没有什么影响，所以这里不再进行删除
                        if (dt.Rows.Count == 1)
                        {
                            //把分配好的学生Userid信息加到assign
                            DataRow newrow = assign.NewRow();
                            newrow["one"] = dt.Rows[0]["UserID"];
                            newrow["two"] = "无";
                            newrow["three"] = "无";
                            newrow["four"] = "无";
                            assign.Rows.Add(newrow);//将这一条记录添加到assign表中
                            bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());//在GoodCopy表中删除已经分配好的学生的记录行
                            ResultBoy b = new ResultBoy()
                            {
                                One = dt.Rows[0]["UserID"].ToString(),
                                Two = "无",
                                Three = "无",
                                Four = "无",
                                Class = Session["Select"].ToString(),
                                State = 0
                            };
                            bool b_success = AdminBLL.InsertResultBoy(b);
                        }
                        if (dt.Rows.Count == 2)
                        {
                            //把分配好的学生Userid信息加到assign
                            DataRow newrow = assign.NewRow();
                            newrow["one"] = dt.Rows[0]["UserID"];
                            newrow["two"] = dt.Rows[1]["UserID"];
                            newrow["three"] = "无";
                            newrow["four"] = "无";
                            assign.Rows.Add(newrow);
                            bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());
                            bool de1 = AdminBLL.DelectAGood(dt.Rows[1]["UserID"].ToString());
                            ResultBoy b = new ResultBoy()
                            {
                                One = dt.Rows[0]["UserID"].ToString(),
                                Two = dt.Rows[1]["UserID"].ToString(),
                                Three = "无",
                                Four = "无",
                                Class = Session["Select"].ToString(),
                                State = 0
                            };
                            bool b_success = AdminBLL.InsertResultBoy(b);
                        }
                        if (dt.Rows.Count == 3)
                        {
                            //把分配好的学生Userid信息加到assign
                            DataRow newrow = assign.NewRow();
                            newrow["one"] = dt.Rows[0]["UserID"];
                            newrow["two"] = dt.Rows[1]["UserID"];
                            newrow["three"] = dt.Rows[2]["UserID"];
                            newrow["four"] = "无";
                            assign.Rows.Add(newrow);
                            bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());
                            bool de1 = AdminBLL.DelectAGood(dt.Rows[1]["UserID"].ToString());
                            bool de2 = AdminBLL.DelectAGood(dt.Rows[2]["UserID"].ToString());
                            ResultBoy b = new ResultBoy()
                            {
                                One = dt.Rows[0]["UserID"].ToString(),
                                Two = dt.Rows[1]["UserID"].ToString(),
                                Three = dt.Rows[2]["UserID"].ToString(),
                                Four = "无",
                                Class = Session["Select"].ToString(),
                                State = 0
                            };
                            bool b_success = AdminBLL.InsertResultBoy(b);
                        }
                    }
                    else
                    {
                        //把分配好的学生Userid信息加到assign
                        DataRow newrow = assign.NewRow();
                        newrow["one"] = dt.Rows[0]["UserID"];
                        newrow["two"] = dt.Rows[1]["UserID"];
                        newrow["three"] = dt.Rows[2]["UserID"];
                        newrow["four"] = dt.Rows[3]["UserID"];
                        assign.Rows.Add(newrow);
                        bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());
                        bool de1 = AdminBLL.DelectAGood(dt.Rows[1]["UserID"].ToString());
                        bool de2 = AdminBLL.DelectAGood(dt.Rows[2]["UserID"].ToString());
                        bool de3 = AdminBLL.DelectAGood(dt.Rows[3]["UserID"].ToString());
                        ResultBoy b = new ResultBoy()
                        {
                            One = dt.Rows[0]["UserID"].ToString(),
                            Two = dt.Rows[1]["UserID"].ToString(),
                            Three = dt.Rows[2]["UserID"].ToString(),
                            Four = dt.Rows[3]["UserID"].ToString(),
                            Class = Session["Select"].ToString(),
                            State = 0
                        };
                        bool b_success = AdminBLL.InsertResultBoy(b);
                    }
                }
            }
            GridView1.DataSource = assign;//将GirdView进行数据绑定，最后简易的显示分配的结果
            GridView1.DataBind();

            //mind3部分“进行寝室信息填写”的数据绑定
            Bind5();
            //main4模块的数据绑定
            Bind3();

            Button3.Enabled = false;
            Button6.Enabled = true;//男生分配完毕后可以进行女生的分配——相关按钮可以进行点击
        }
        /// <summary>
        /// 女生分配前准备工作——具体的实现过程与对男生进行分配类似，代码注释不再详写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button6_Click(object sender, EventArgs e)
        {
            string a = Session["Select"].ToString();
            DataTable dt = new DataTable();
            dt = AdminBLL.InCommonClassAndSex(a, "女");
            foreach (DataRow drow in dt.Rows)
            {
                GoodCopy g = new GoodCopy()
                {
                    UserID = drow["UserID"].ToString(),
                    A1sleepTime = Convert.ToDouble(drow["A1sleepTime"]),
                    A2upTime = Convert.ToDouble(drow["A2upTime"]),
                    A3noonNap = Convert.ToDouble(drow["A3noonNap"]),
                    A4averageTime = Convert.ToDouble(drow["A4averageTime"]),
                    A5sleepQuality = Convert.ToDouble(drow["A5sleepQuality"]),
                    A6snore = Convert.ToDouble(drow["A6snore"]),
                    B1fitCold = Convert.ToDouble(drow["B1fitCold"]),
                    B2fitHot = Convert.ToDouble(drow["B2fitHot"]),
                    B3airCon = Convert.ToDouble(drow["B3airCon"]),
                    B4minTem = Convert.ToDouble(drow["B4minTem"]),
                    B5maxTem = Convert.ToDouble(drow["B5maxTem"]),
                    C1shower = Convert.ToDouble(drow["C1shower"]),
                    C2cleanDesk = Convert.ToDouble(drow["C2cleanDesk"]),
                    C3cleanRubbish = Convert.ToDouble(drow["C3cleanRubbish"]),
                    C4makeBed = Convert.ToDouble(drow["C4makeBed"]),
                    C5washCloth = Convert.ToDouble(drow["C5washCloth"]),
                    D1smoke = Convert.ToDouble(drow["D1smoke"]),
                    D2game = Convert.ToDouble(drow["D2game"]),
                    D3volume = Convert.ToDouble(drow["D3volume"]),
                    D4express = Convert.ToDouble(drow["D4express"]),
                    D5coConsum = Convert.ToDouble(drow["D5coConsum"]),
                    D6elec = Convert.ToDouble(drow["D6elec"]),
                    D7con = Convert.ToDouble(drow["D7con"]),
                    D8unCon = Convert.ToDouble(drow["D8unCon"]),
                    D9coat = Convert.ToDouble(drow["D9coat"]),
                    D10uWear = Convert.ToDouble(drow["D10uWear"]),
                    D11maq = Convert.ToDouble(drow["D11maq"]),
                    D12outSide = Convert.ToDouble(drow["D12outSide"]),
                    E1income = Convert.ToDouble(drow["E1income"]),
                    E2perConsum = Convert.ToDouble(drow["E2perConsum"]),
                    F1sing = Convert.ToDouble(drow["F1sing"]),
                    F2musIns = Convert.ToDouble(drow["F2musIns"]),
                    F3dance = Convert.ToDouble(drow["F3dance"]),
                    F4draw = Convert.ToDouble(drow["F4draw"]),
                    F5white = Convert.ToDouble(drow["F5white"]),
                    F6ball = Convert.ToDouble(drow["F6ball"]),
                    F7tennis = Convert.ToDouble(drow["F7tennis"]),
                    F8run = Convert.ToDouble(drow["F8run"]),
                    F9bodyBuild = Convert.ToDouble(drow["F9bodyBuild"]),
                    F10yoga = Convert.ToDouble(drow["F10yoga"]),
                    F11swim = Convert.ToDouble(drow["F11swim"]),
                    F12movie = Convert.ToDouble(drow["F12movie"]),
                    F13live = Convert.ToDouble(drow["F13live"]),
                    F14claMusic = Convert.ToDouble(drow["F14claMusic"]),
                    F15idol = Convert.ToDouble(drow["F15idol"]),
                    F16ktv = Convert.ToDouble(drow["F16ktv"]),
                    G1sexOrient = Convert.ToDouble(drow["G1sexOrient"]),
                    G2noSingle = Convert.ToDouble(drow["G2noSingle"]),
                    G3inDisea = Convert.ToDouble(drow["G3inDisea"]),
                    G4family = Convert.ToDouble(drow["G4family"]),
                    G5parent = Convert.ToDouble(drow["G5parent"]),
                    G6interact = Convert.ToDouble(drow["G6interact"]),
                    State = 1
                };
                bool success = AdminBLL.InsertNewGood(g);
            }
            Button6.Enabled = false;
            Button7.Enabled = true;
        }
        /// <summary>
        /// ▲▲▲女生开始分配——具体的实现过程与对男生进行分配类似，代码注释不再详写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button7_Click(object sender, EventArgs e)
        {
            DataTable assign = new DataTable();

            assign.Columns.Add(new DataColumn("one", typeof(string)));
            assign.Columns.Add(new DataColumn("two", typeof(string)));
            assign.Columns.Add(new DataColumn("three", typeof(string)));
            assign.Columns.Add(new DataColumn("four", typeof(string)));

            DataTable info = AdminBLL.InCommonClassAndSex2(Session["Select"].ToString(), "女");
            List<string> iden = null;//必须有这句话，否则会报“iden未引用到实例”的错误
            iden = new List<string>();
            foreach (DataRow drow in info.Rows)
            {
                iden.Add(drow["UserID"].ToString());
            }

            foreach (string i in iden)
            {
                //判断该学生是否已经进行了分配
                bool exist = AdminBLL.ExistByUID(i);
                bool otherExist = AdminBLL.PeopleGoodIsExist(i);
                //对仅剩一个学生的情况进行处理
                if (exist == true && otherExist == false)
                {
                    //把仅剩的一个学生的Userid信息加到assign
                    DataRow newrow = assign.NewRow();
                    newrow["one"] = i;
                    newrow["two"] = "无";
                    newrow["three"] = "无";
                    newrow["four"] = "无";
                    assign.Rows.Add(newrow);
                    bool de = AdminBLL.DelectAGood(i);
                    ResultGirl b = new ResultGirl()
                    {
                        One = i,
                        Two = "无",
                        Three = "无",
                        Four = "无",
                        Class = Session["Select"].ToString(),
                        State = 0
                    };
                    bool b_success = AdminBLL.InsertResultGirl(b);
                }
                if (exist == true && otherExist == true)
                {
                    DataTable dt = new DataTable();
                    dt = AdminBLL.AllInfo(i, 4);
                    if (dt.Rows.Count < 4)
                    {
                        if (dt.Rows.Count == 1)
                        {
                            //把分配好的学生Userid信息加到assign
                            DataRow newrow = assign.NewRow();
                            newrow["one"] = dt.Rows[0]["UserID"];
                            newrow["two"] = "无";
                            newrow["three"] = "无";
                            newrow["four"] = "无";
                            assign.Rows.Add(newrow);
                            bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());
                            ResultGirl b = new ResultGirl()
                            {
                                One = dt.Rows[0]["UserID"].ToString(),
                                Two = "无",
                                Three = "无",
                                Four = "无",
                                Class = Session["Select"].ToString(),
                                State = 0
                            };
                            bool b_success = AdminBLL.InsertResultGirl(b);
                        }
                        if (dt.Rows.Count == 2)
                        {
                            //把分配好的学生Userid信息加到assign
                            DataRow newrow = assign.NewRow();
                            newrow["one"] = dt.Rows[0]["UserID"];
                            newrow["two"] = dt.Rows[1]["UserID"];
                            newrow["three"] = "无";
                            newrow["four"] = "无";
                            assign.Rows.Add(newrow);
                            bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());
                            bool de1 = AdminBLL.DelectAGood(dt.Rows[1]["UserID"].ToString());
                            ResultGirl b = new ResultGirl()
                            {
                                One = dt.Rows[0]["UserID"].ToString(),
                                Two = dt.Rows[1]["UserID"].ToString(),
                                Three = "无",
                                Four = "无",
                                Class = Session["Select"].ToString(),
                                State = 0
                            };
                            bool b_success = AdminBLL.InsertResultGirl(b);
                        }
                        if (dt.Rows.Count == 3)
                        {
                            //把分配好的学生Userid信息加到assign
                            DataRow newrow = assign.NewRow();
                            newrow["one"] = dt.Rows[0]["UserID"];
                            newrow["two"] = dt.Rows[1]["UserID"];
                            newrow["three"] = dt.Rows[2]["UserID"];
                            newrow["four"] = "无";
                            assign.Rows.Add(newrow);
                            bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());
                            bool de1 = AdminBLL.DelectAGood(dt.Rows[1]["UserID"].ToString());
                            bool de2 = AdminBLL.DelectAGood(dt.Rows[2]["UserID"].ToString());
                            ResultGirl b = new ResultGirl()
                            {
                                One = dt.Rows[0]["UserID"].ToString(),
                                Two = dt.Rows[1]["UserID"].ToString(),
                                Three = dt.Rows[2]["UserID"].ToString(),
                                Four = "无",
                                Class = Session["Select"].ToString(),
                                State = 0
                            };
                            bool b_success = AdminBLL.InsertResultGirl(b);
                        }
                    }
                    else
                    {
                        //把分配好的学生Userid信息加到assign
                        DataRow newrow = assign.NewRow();
                        newrow["one"] = dt.Rows[0]["UserID"];
                        newrow["two"] = dt.Rows[1]["UserID"];
                        newrow["three"] = dt.Rows[2]["UserID"];
                        newrow["four"] = dt.Rows[3]["UserID"];
                        assign.Rows.Add(newrow);
                        bool de = AdminBLL.DelectAGood(dt.Rows[0]["UserID"].ToString());
                        bool de1 = AdminBLL.DelectAGood(dt.Rows[1]["UserID"].ToString());
                        bool de2 = AdminBLL.DelectAGood(dt.Rows[2]["UserID"].ToString());
                        bool de3 = AdminBLL.DelectAGood(dt.Rows[3]["UserID"].ToString());
                        ResultGirl b = new ResultGirl()
                        {
                            One = dt.Rows[0]["UserID"].ToString(),
                            Two = dt.Rows[1]["UserID"].ToString(),
                            Three = dt.Rows[2]["UserID"].ToString(),
                            Four = dt.Rows[3]["UserID"].ToString(),
                            Class = Session["Select"].ToString(),
                            State = 0
                        };
                        bool b_success = AdminBLL.InsertResultGirl(b);
                    }
                }
            }
            GridView2.DataSource = assign;
            GridView2.DataBind();

            //mind3部分“进行寝室信息填写”的数据绑定
            Bind5();
            //main4模块的数据绑定
            Bind3();

            Button7.Enabled = false;
            Panel5.Enabled = true;
        }

        /// <summary>
        /// 当下拉列表DropDownList2变化时，main3模块重新进行数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind5();
        }
        /// <summary>
        /// 当下拉列表DropDownList3变化时，main3模块重新进行数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind5();
        }
        /// <summary>
        /// 根据下拉列表DropDownList2、DropDownList3的选择对main3模块进行数据绑定
        /// </summary>
        private void Bind5()
        {
            DataTable assign = new DataTable();
            //创建一个表头为下面11个字段的表
            assign.Columns.Add(new DataColumn("one", typeof(string)));
            assign.Columns.Add(new DataColumn("name1", typeof(string)));
            assign.Columns.Add(new DataColumn("two", typeof(string)));
            assign.Columns.Add(new DataColumn("name2", typeof(string)));
            assign.Columns.Add(new DataColumn("three", typeof(string)));
            assign.Columns.Add(new DataColumn("name3", typeof(string)));
            assign.Columns.Add(new DataColumn("four", typeof(string)));
            assign.Columns.Add(new DataColumn("name4", typeof(string)));
            assign.Columns.Add(new DataColumn("building", typeof(int)));
            assign.Columns.Add(new DataColumn("room", typeof(int)));
            assign.Columns.Add(new DataColumn("state", typeof(string)));

            string majorAndClass = DropDownList2.SelectedValue;
            string sex = DropDownList3.SelectedValue;
            //将属于特定班级、特定性别（男）的学生的信息进行显示
            if (sex == "男")
            {
                //将属于特定班级的所有男学生的信息进行显示
                DataTable allBoy = AdminBLL.AllResultBoy(majorAndClass);
                for (int i = 0; i < allBoy.Rows.Count; i++)
                {
                    DataRow dr = assign.NewRow();//创建与assign表有相同架构的新行
                    //便历表allBoy时，床位1一定有人，不需要进行判断，但是2、3、4床位都有可能出现没有人的情况，因此需要对2、3、4床位是否有学生进行判断
                    dr["one"] = allBoy.Rows[i]["One"];
                    dr["name1"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["One"].ToString());
                    if (allBoy.Rows[i]["Two"].ToString() == "无")
                    {
                        dr["two"] = "无";
                        dr["name2"] = "无";
                    }
                    else
                    {
                        dr["two"] = allBoy.Rows[i]["Two"];
                        dr["name2"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["Two"].ToString());
                    }
                    if (allBoy.Rows[i]["Three"].ToString() == "无")
                    {
                        dr["Three"] = "无";
                        dr["name3"] = "无";
                    }
                    else
                    {
                        dr["three"] = allBoy.Rows[i]["Three"];
                        dr["name3"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["Three"].ToString());
                    }
                    if (allBoy.Rows[i]["Four"].ToString() == "无")
                    {
                        dr["four"] = "无";
                        dr["name4"] = "无";
                    }
                    else
                    {
                        dr["four"] = allBoy.Rows[i]["Four"];
                        dr["name4"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["Four"].ToString());
                    }

                    dr["building"] = allBoy.Rows[i]["Building"];
                    dr["room"] = allBoy.Rows[i]["Room"];

                    //查询被便利的数据行的state的值
                    if (Convert.ToInt32(allBoy.Rows[i]["State"]) == 1)
                    {
                        dr["state"] = "已发布";//state的值为1，gridview中相应的数据行的state字段显示“未发布”
                    }
                    else
                    {
                        dr["state"] = "未发布";//state的值为0，gridview中相应的数据行的state字段显示“已发布”
                    }

                    assign.Rows.Add(dr);//将dr这一行已经赋好值的数据行添加到assign表中
                }
                //GridView4.DataSource = assign;//通过数据绑定将数据显示出来
                //GridView4.DataBind();
                this.ListView1.DataSource = assign;
                this.ListView1.DataBind();
            }
            //将属于特定班级、特定性别（女）的学生的信息进行显示——与上面对男生的分配结果进行显示的代码类似，这里不再进行详细注释
            if (sex == "女")
            {
                //将属于特定班级的所有女学生的信息进行显示
                DataTable allGirl = AdminBLL.AllResultGirl(majorAndClass);
                for (int i = 0; i < allGirl.Rows.Count; i++)
                {
                    DataRow dr = assign.NewRow();
                    dr["one"] = allGirl.Rows[i]["One"];
                    dr["name1"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["One"].ToString());

                    if (allGirl.Rows[i]["Two"].ToString() == "无")
                    {
                        dr["two"] = "无";
                        dr["name2"] = "无";
                    }
                    else
                    {
                        dr["two"] = allGirl.Rows[i]["Two"];
                        dr["name2"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["Two"].ToString());
                    }

                    if (allGirl.Rows[i]["Three"].ToString() == "无")
                    {
                        dr["Three"] = "无";
                        dr["name3"] = "无";
                    }
                    else
                    {
                        dr["three"] = allGirl.Rows[i]["Three"];
                        dr["name3"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["Three"].ToString());
                    }

                    if (allGirl.Rows[i]["Four"].ToString() == "无")
                    {
                        dr["four"] = "无";
                        dr["name4"] = "无";
                    }
                    else
                    {
                        dr["four"] = allGirl.Rows[i]["Four"];
                        dr["name4"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["Four"].ToString());
                    }

                    dr["building"] = allGirl.Rows[i]["Building"];
                    dr["room"] = allGirl.Rows[i]["Room"];

                    if (Convert.ToInt32(allGirl.Rows[i]["State"].ToString()) == 1)
                    {
                        dr["state"] = "已发布";
                    }
                    else
                    {
                        dr["state"] = "未发布";
                    }
                    assign.Rows.Add(dr);
                }
                //GridView4.DataSource = assign;
                //GridView4.DataBind();
                this.ListView1.DataSource = assign;
                this.ListView1.DataBind();
            }
        }
        /// <summary>
        /// ！！！未实现——main3模块，获取textBox控件中填写的内容，并将填写的内容存入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button14_Click(object sender, EventArgs e)
        //{
        //    string sex = DropDownList3.SelectedValue;
        //    if (sex == "男")
        //    {
        //        for (int i = 0; i < GridView4.Rows.Count; i++)
        //        {
        //            //TextBox a = this.GridView3.Rows[i].Cells[8].FindControl("TextBox1") as TextBox;
        //            //int building = Convert.ToInt32(a.Text.ToString().Trim());

        //            //TextBox b = this.GridView3.Rows[i].Cells[9].FindControl("TextBox2") as TextBox;
        //            //int room = Convert.ToInt32(b.Text.ToString().Trim());

        //            string c = this.GridView3.Rows[i].Cells[0].Text.ToString();

        //            string a = this.GridView3.Rows[i].Cells[8].Text.ToString();
        //            int building = Convert.ToInt32(a);

        //            //var b = (TextBox)this.GridView3.Rows[i].FindControl("TextBox2");
        //            //int room = Convert.ToInt32(b.Text.Trim());

        //            string b = this.GridView3.Rows[i].Cells[9].Text.ToString();
        //            int room = Convert.ToInt32(b);

        //            int id = AdminBLL.SelectResultID(c);
        //            ResultBoy boy = new ResultBoy()
        //            {
        //                RID = id,
        //                Building = building,
        //                Room = room
        //            };
        //            bool b_success = AdminBLL.UpdateRoomInfo(boy);
        //            if (b_success)
        //            {
        //                //mind3部分“进行寝室信息填写”的数据绑定
        //                Bind5();
        //                //main4模块的数据绑定
        //                Bind3();

        //                ScriptManager.RegisterStartupScript(UpdatePanel3, UpdatePanel3.GetType(), "", "alert('修改成功！')", true);
        //            }
        //        }
        //    }
        //    if (sex == "女")
        //    {
        //        for (int i = 0; i < GridView4.Rows.Count; i++)
        //        {
        //            TextBox a = this.GridView3.Rows[i].Cells[8].FindControl("TextBox1") as TextBox;
        //            int building = Convert.ToInt32(a.Text.ToString().Trim());

        //            TextBox b = this.GridView3.Rows[i].Cells[9].FindControl("TextBox2") as TextBox;
        //            int room = Convert.ToInt32(b.Text.ToString().Trim());

        //            string c = this.GridView3.Rows[i].Cells[0].Text.ToString();

        //            int id = AdminBLL.SelectResultID(c);
        //            ResultGirl girl = new ResultGirl()
        //            {
        //                RID = id,
        //                Building = building,
        //                Room = room
        //            };
        //            bool b_success = AdminBLL.UpdateRoomInfoGirl(girl);
        //            if (b_success)
        //            {
        //                //mind3部分“进行寝室信息填写”的数据绑定
        //                Bind5();
        //                //main4模块的数据绑定
        //                Bind3();

        //                ScriptManager.RegisterStartupScript(UpdatePanel3, UpdatePanel3.GetType(), "", "alert('修改成功！')", true);
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 已实现——main3模块，获取textBox控件中填写的内容，并将填写的内容存入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button14_Click(object sender, EventArgs e)
        {
            string sex = DropDownList3.SelectedValue;
            if (sex == "男")
            {
                foreach (ListViewItem tempItem in ListView1.Items)
                {
                    var a = (TextBox)tempItem.FindControl("tbBuilding");
                    int building = Convert.ToInt32(a.Text.Trim());

                    var b = (TextBox)tempItem.FindControl("tbRoom");
                    int room = Convert.ToInt32(b.Text.Trim());

                    var c = (Label)tempItem.FindControl("lbOneID");
                    string uid = c.Text.ToString();

                    int id = AdminBLL.SelectResultID(uid);
                    ResultBoy boy = new ResultBoy()
                    {
                        RID = id,
                        Building = building,
                        Room = room
                    };
                    bool b_success = AdminBLL.UpdateRoomInfo(boy);
                    //if (b_success)
                    //{
                    //    //mind3部分“进行寝室信息填写”的数据绑定
                    //    Bind5();
                    //    //main4模块的数据绑定
                    //    Bind3();

                    //    ScriptManager.RegisterStartupScript(UpdatePanel3, UpdatePanel3.GetType(), "", "alert('修改成功！')", true);
                    //}
                }
            }

            if (sex == "女")
            {
                foreach (ListViewItem tempItem in ListView1.Items)
                {
                    var a = (TextBox)tempItem.FindControl("tbBuilding");
                    int building = Convert.ToInt32(a.Text.Trim());

                    var b = (TextBox)tempItem.FindControl("tbRoom");
                    int room = Convert.ToInt32(b.Text.Trim());

                    var c = (Label)tempItem.FindControl("lbOneID");
                    string uid = c.Text.ToString();

                    int id = AdminBLL.SelectResultIDGirl(uid);
                    ResultGirl girl = new ResultGirl()
                    {
                        RID = id,
                        Building = building,
                        Room = room
                    };
                    bool b_success = AdminBLL.UpdateRoomInfoGirl(girl);
                    //if (b_success)
                    //{
                    //    //mind3部分“进行寝室信息填写”的数据绑定
                    //    Bind5();
                    //    //main4模块的数据绑定
                    //    Bind3();

                    //    ScriptManager.RegisterStartupScript(UpdatePanel3, UpdatePanel3.GetType(), "", "alert('修改成功！')", true);
                    //}
                }
            }
            ScriptManager.RegisterStartupScript(UpdatePanel3, UpdatePanel3.GetType(), "", "alert('修改成功！')", true);
            //mind3部分“进行寝室信息填写”的数据绑定
            Bind5();
            //main4模块的数据绑定
            Bind3();
        }
        /// <summary>
        /// 当下拉列表DropDownList1变化时，main4模块重新进行数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind3();
        }
        /// <summary>
        /// 根据下拉列表DropDownList1的选择对main4模块进行数据绑定
        /// </summary>
        private void Bind3()
        {
            DataTable assign = new DataTable();

            assign.Columns.Add(new DataColumn("one", typeof(string)));
            assign.Columns.Add(new DataColumn("name1", typeof(string)));
            assign.Columns.Add(new DataColumn("two", typeof(string)));
            assign.Columns.Add(new DataColumn("name2", typeof(string)));
            assign.Columns.Add(new DataColumn("three", typeof(string)));
            assign.Columns.Add(new DataColumn("name3", typeof(string)));
            assign.Columns.Add(new DataColumn("four", typeof(string)));
            assign.Columns.Add(new DataColumn("name4", typeof(string)));
            assign.Columns.Add(new DataColumn("building", typeof(int)));
            assign.Columns.Add(new DataColumn("room", typeof(int)));
            assign.Columns.Add(new DataColumn("state", typeof(string)));

            string majorAndClass = DropDownList1.SelectedValue;
            //将属于特定班级的所有男学生的信息进行显示
            DataTable allBoy = AdminBLL.AllResultBoy(majorAndClass);
            for (int i = 0; i < allBoy.Rows.Count; i++)
            {
                DataRow dr = assign.NewRow();
                dr["one"] = allBoy.Rows[i]["One"];
                dr["name1"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["One"].ToString());
                if (allBoy.Rows[i]["Two"].ToString() == "无")
                {
                    dr["two"] = "无";
                    dr["name2"] = "无";
                }
                else
                {
                    dr["two"] = allBoy.Rows[i]["Two"];
                    dr["name2"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["Two"].ToString());
                }

                if (allBoy.Rows[i]["Three"].ToString() == "无")
                {
                    dr["Three"] = "无";
                    dr["name3"] = "无";
                }
                else
                {
                    dr["three"] = allBoy.Rows[i]["Three"];
                    dr["name3"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["Three"].ToString());
                }

                if (allBoy.Rows[i]["Four"].ToString() == "无")
                {
                    dr["four"] = "无";
                    dr["name4"] = "无";
                }
                else
                {
                    dr["four"] = allBoy.Rows[i]["Four"];
                    dr["name4"] = AdminBLL.SelectStudentName(allBoy.Rows[i]["Four"].ToString());
                }

                dr["building"] = allBoy.Rows[i]["Building"];
                dr["room"] = allBoy.Rows[i]["Room"];

                if (Convert.ToInt32(allBoy.Rows[i]["State"]) == 1)
                {
                    dr["state"] = "已发布";
                }
                else
                {
                    dr["state"] = "未发布";
                }

                assign.Rows.Add(dr);
            }

            //将属于特定班级的所有女学生的信息进行显示
            DataTable allGirl = AdminBLL.AllResultGirl(majorAndClass);
            for (int i = 0; i < allGirl.Rows.Count; i++)
            {
                DataRow dr = assign.NewRow();
                dr["one"] = allGirl.Rows[i]["One"];
                dr["name1"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["One"].ToString());

                if (allGirl.Rows[i]["Two"].ToString() == "无")
                {
                    dr["two"] = "无";
                    dr["name2"] = "无";
                }
                else
                {
                    dr["two"] = allGirl.Rows[i]["Two"];
                    dr["name2"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["Two"].ToString());
                }

                if (allGirl.Rows[i]["Three"].ToString() == "无")
                {
                    dr["Three"] = "无";
                    dr["name3"] = "无";
                }
                else
                {
                    dr["three"] = allGirl.Rows[i]["Three"];
                    dr["name3"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["Three"].ToString());
                }

                if (allGirl.Rows[i]["Four"].ToString() == "无")
                {
                    dr["four"] = "无";
                    dr["name4"] = "无";
                }
                else
                {
                    dr["four"] = allGirl.Rows[i]["Four"];
                    dr["name4"] = AdminBLL.SelectStudentName(allGirl.Rows[i]["Four"].ToString());
                }

                dr["building"] = allGirl.Rows[i]["Building"];
                dr["room"] = allGirl.Rows[i]["Room"];

                if (Convert.ToInt32(allGirl.Rows[i]["State"].ToString()) == 1)
                {
                    dr["state"] = "已发布";
                }
                else
                {
                    dr["state"] = "未发布";
                }
                assign.Rows.Add(dr);
            }

            GridView3.DataSource = assign;
            GridView3.DataBind();
        }
        /// <summary>
        /// 将属于特定班级的所有学生（男和女）的分配结果进行数发布（即相关学生登录后可以直接看到分配结果）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button8_Click(object sender, EventArgs e)
        {
            string majorAndClass = DropDownList1.SelectedValue;

            //将属于特定班级的所有男学生的信息进行发布
            DataTable allBoy = AdminBLL.AllResultBoy(majorAndClass);
            for (int i = 0; i < allBoy.Rows.Count; i++)
            {
                int id = AdminBLL.SelectResultID(allBoy.Rows[i]["One"].ToString());
                ResultBoy b = new ResultBoy()
                {
                    RID = id,
                    State = 1
                };
                bool b_success = AdminBLL.IssueResult(b);
            }

            //将属于特定班级的所有女学生的信息进行发布
            DataTable allGirl = AdminBLL.AllResultGirl(majorAndClass);
            for (int i = 0; i < allGirl.Rows.Count; i++)
            {
                int id = AdminBLL.SelectResultIDGirl(allGirl.Rows[i]["One"].ToString());
                ResultGirl b = new ResultGirl()
                {
                    RID = id,
                    State = 1
                };
                bool b_success = AdminBLL.IssueResultGirl(b);
            }
            Bind3();
        }
        /// <summary>
        /// 将属于特定班级的所有学生（男和女）的分配结果撤销数发布（即虽然已经分配好了，但是相关学生登录后可以不可以看到分配结果）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button9_Click(object sender, EventArgs e)
        {
            string majorAndClass = DropDownList1.SelectedValue;

            //将属于特定班级的所有男学生的信息进行撤销发布
            DataTable allBoy = AdminBLL.AllResultBoy(majorAndClass);
            for (int i = 0; i < allBoy.Rows.Count; i++)
            {
                int id = AdminBLL.SelectResultID(allBoy.Rows[i]["One"].ToString());
                ResultBoy b = new ResultBoy()
                {
                    RID = id,
                    State = 0
                };
                bool b_success = AdminBLL.IssueResult(b);
            }

            //将属于特定班级的所有女学生的信息进行撤销发布
            DataTable allGirl = AdminBLL.AllResultGirl(majorAndClass);
            for (int i = 0; i < allGirl.Rows.Count; i++)
            {
                int id = AdminBLL.SelectResultIDGirl(allGirl.Rows[i]["One"].ToString());
                ResultGirl b = new ResultGirl()
                {
                    RID = id,
                    State = 0
                };
                bool b_success = AdminBLL.IssueResultGirl(b);
            }
            Bind3();
        }
        /// <summary>
        /// main5显示学生曾经提交过的信息部分根据消息是否已读，消息状态列相应显示“已读”、“未读”
        /// </summary>
        private void Main5Bind()
        {
            foreach (ListViewItem tempItem in lvMes.Items)
            {
                string read = (tempItem.FindControl("lbRead") as Label).Text.ToString();
                if (String.IsNullOrEmpty(read) || read == "0")
                {
                    (tempItem.FindControl("lbRead") as Label).Text = "未读";
                }
                else
                {
                    (tempItem.FindControl("lbRead") as Label).Text = "已读";
                }
            }
        }
        /// <summary>
        /// main5点击新建，发送信息模块进行显示，已收到信息模块进行隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button13_Click(object sender, EventArgs e)
        {
            Panel7.Visible = true;
            Panel4.Visible = false;
        }
        /// <summary>
        /// main5在发送信息模块点击返回按钮，发送信息模块进行隐藏，已收到信息模块进行显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button15_Click(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            Panel7.Visible = false;
        }
        /// <summary>
        /// main5在发送信息模块点击发送按钮，对输入是否为空等内容进行验证，验证满足条件后可以向任何学生发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button16_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox6.Text))
            {
                Label29.Text = "不可为空！";
            }
            else
            {
                string iden = TextBox6.Text.ToString().Trim();
                bool exist = UserBLL.IdentityIsAny(iden);
                if (!exist)
                {
                    Label29.Text = "此学生ID不存在！";
                }
                else
                {
                    if (string.IsNullOrEmpty(TextBox1.Text.Trim()))
                    {
                        Label30.Text = "内容不可为空！";
                    }
                    else
                    {
                        Message mes = new Message()
                        {
                            Accept = iden,
                            Read = 0,
                            Content = TextBox1.Text.Trim(),
                            Time = DateTime.Now,
                            Send = Session["AdmainJobNum"].ToString(),
                            Delect = 1
                        };
                        bool a = MessageBLL.InsertNewMessage(mes);
                        if (a)
                        {
                            Response.Write("<script language='javascript'>alert('发送成功！')</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('发送失败！')</script>");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// main5在回复信息模块点击返回按钮，回复信息模块进行隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button12_Click(object sender, EventArgs e)
        {
            Panel6.Visible = false;
            Panel4.Visible = true;
        }
        /// <summary>
        /// main5在回复信息模块点击发送按钮，直接给相应的数据库中的信息记录行中的reContent（回复信息）字段进行更新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button11_Click(object sender, EventArgs e)
        {
            Message mes = new Message()
            {
                MID = Convert.ToInt32(Session["MID"]),
                reContent = TextBox5.Text.ToString().Trim()
            };
            bool update = MessageBLL.AddReplyInfo(mes);
            //main1模块显示全部学生信息、main5显示所有管理员收到的所有信息进行数据绑定
            Bind(AdminBLL.AllStudentInfo(), MessageBLL.AdminAllReceiveMes(Session["AdmainJobNum"].ToString()));
            //Panel4.Visible = true;
            //Panel6.Visible = false;
            if (update)
            {
                //Response.Write("<script language='javascript'>alert('回复成功！')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('回复成功！')", true);
            }
        }
        /// <summary>
        /// right1模块个人信息部分数据绑定
        /// </summary>
        protected void Bind4()
        {
            string uid = Session["AdmainJobNum"].ToString();
            lbName.Text = AdminBLL.SelectName(uid);
            lbJobNumber.Text = uid;
            lbIdentity.Text = AdminBLL.SelectIdentity(uid);
            lbCollege.Text = AdminBLL.SelectCollege(uid);
            int a = AdminBLL.SelectType(uid);
            if (a == 1) { lbType.Text = "校级管理员"; }
            else { lbType.Text = "院级管理员"; }
            lbPhone.Text = AdminBLL.SelectPhone(uid);
        }
        /// <summary>
        /// right2模块点击“确定”按钮更新密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button10_Click(object sender, EventArgs e)
        {
            string uid = Session["AdmainJobNum"].ToString();
            string oldPwd = AdminBLL.SelectPassword(uid);
            if (oldPwd == tbOldPwd.Text.ToString())
            {
                if (string.IsNullOrEmpty(tbNewPwd.Text.ToString().Trim()))
                {
                    lbMsgNewPwd.Text = "不可为空！";

                }
                else
                {
                    if (string.IsNullOrEmpty(tbNewPwd2.Text.ToString().Trim()))
                    {
                        lbMsgNewPwd2.Text = "不可为空！";
                    }
                    else
                    {
                        if (tbNewPwd.Text.ToString().Trim() == tbNewPwd2.Text.ToString().Trim())
                        {
                            Model.Admin ad = new Model.Admin()
                            {
                                JobNumber = uid,
                                Password = tbNewPwd.Text.ToString().Trim()
                            };
                            bool success = AdminBLL.UpdatePwd(ad);
                            if (success)
                            {
                                lbMsgUpdatePwd.Text = "修改成功！";
                            }
                        }
                        else
                        {
                            lbMsgNewPwd2.Text = "两次密码填写不一致！";
                        }
                    }
                }

            }
            else
            {
                lbMsgOldPwd.Text = "原密码填写错误！";
            }
        }
        /// <summary>
        /// main1模块点击上传学生信息按钮，进入上传excel表部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpInfo_Click(object sender, EventArgs e)
        {
            plUpInfo.Visible = true;
            Panel1.Visible = false;
            Label3.Text = "上传信息";
        }
        /// <summary>
        /// 再次进行分配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAssignAgain_Click(object sender, EventArgs e)
        {
            bool boy = AdminBLL.DelectBoyResult(Session["Select"].ToString());
            bool girl = AdminBLL.DelectGirlResult(Session["Select"].ToString());
            if (boy || girl)
            {
                btnAssignAgain.Enabled = false;
                btnNotAssignAgain.Enabled = false;
                Button4.Enabled = true;
            }
        }
        /// <summary>
        /// 不再进行分配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNotAssignAgain_Click(object sender, EventArgs e)
        {
            lbMsgAssignAgain.Text = "";
            btnAssignAgain.Visible = false;
            btnNotAssignAgain.Visible = false;
            Panel5.Enabled = true;
            Button1.Enabled = true;
        }
    }
}