using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SoulRoommate
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //在用到验证控件之前必须有这一句话才能保证验证控件正常使用
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                //学生邮箱登陆读取cookie的值——如果之前登陆时选择了“记住信息”，第二次登陆时可以免去输入账号和邮箱
                if (Request.Cookies["UserInfo1"] != null)
                {
                    txtUser.Text = Request.Cookies["UserInfo1"]["UserID1"].ToString();
                    txtEmail.Text = Request.Cookies["UserInfo1"]["Email"].ToString();
                    cbRememberEmail.Checked = true;//读取cookie值后，“记住信息”按钮默认被勾选
                }

                //学生密码登陆读取cookie的值——如果之前登陆时选择了“记住账号”，第二次登陆时可以免去输入账号
                if (Request.Cookies["UserInfo2"] != null)
                {
                    txtUser2.Text = Request.Cookies["UserInfo2"]["UserID2"].ToString();
                    cbRememberEmail2.Checked = true;
                }

                //管理端登陆读取cookie的值——如果之前登陆时选择了“记住账号”，第二次登陆时可以免去输入账号
                if (Request.Cookies["UserInfo3"] != null)
                {
                    txtUser3.Text = Request.Cookies["UserInfo3"]["JobNum"].ToString();
                    cbRememberEmail3.Checked = true;
                }
            }
        }
        /// <summary>
        /// 在main1模块中有一个Menu与MultiView1控件，两个控件实现了联动，下方函数设置了具体的联动效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (Menu1.SelectedValue)
            {
                case "1":
                    {
                        MultiView1.ActiveViewIndex = 0;
                        break;
                    }
                case "2":
                    {
                        MultiView1.ActiveViewIndex = 1;
                        break;
                    }

                default:
                    break;
            }
        }
        /// <summary>
        /// 学生端邮箱登陆时点击“发送验证码”按钮发送验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            string iden = txtUser.Text.ToString().Trim();
            string email = txtEmail.Text.ToString().Trim();

            if (UserBLL.IdentityIsAny(iden))//先验证一下数据库中是否存在此用户
            {
                if (UserBLL.EamilIsMatch(iden, email))//验证一下数据库中此用户与输入的邮箱是否是匹配的
                {
                    lbMsgSendCode.Text = EmailServer.SendSMTPEMail(txtEmail.Text.Trim()) == true ? "发送成功！" : "发送失败！";
                }
                else
                {
                    lbMsgEmail.Text = "此邮箱与用户名不匹配!";//数据库中此用户与输入的邮箱不是匹配的，不再发送验证码，直接显示错误信息
                }
            }
            else//数据库中不存在此用户时，不再进行发送验证码的操作，直接显示错误信息
            {
                lbMsgUser.Text = "此用户不存在!";
            }
        }
        /// <summary>
        /// 学生端邮箱登陆时点击“登录”按钮进行登陆验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.ToString().Trim();

            if (string.IsNullOrEmpty(code))//判断邮箱验证码是否为空
            {
                lbMsgCode.Text = "请输入验证码!";
            }
            else
            {
                if (!code.Equals(EmailServer.Code))//判断输入的验证码与发送的验证码是否一致
                {
                    lbMsgCode.Text = "验证码输入有误!";

                }
                else
                {
                    string iden = txtUser.Text.ToString().Trim();
                    string email = txtEmail.Text.ToString().Trim();

                    if (cbRememberEmail.Checked)//当用户勾选“记住”的复选框时，进行if语句内的操作
                    {
                        //创建cookie
                        HttpCookie mycookie1 = new HttpCookie("UserInfo1");
                        mycookie1.Values.Add("UserID1", iden);
                        mycookie1.Values.Add("Email", email);
                        //设置cookie的过期时间
                        mycookie1.Expires = DateTime.Now.AddDays(7);
                        //将cookie写到客户端
                        Response.Cookies.Add(mycookie1);
                    }
                    else//当用户没有勾选复选框时，运行else语句，清除以前的cookie
                    {
                        if (Request.Cookies["UserInfo1"] != null)
                        {
                            //设置cookie立刻过期
                            Response.Cookies["UserInfo1"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                    //再次验证数据库中此用户与输入的邮箱是否是匹配的，防止输入验证码后，用户名和邮箱的输入发生改变
                    if (UserBLL.EamilIsMatch(iden, email))
                    {
                        //验证成功时，创建session
                        Session.Add("User", iden);//Session["User"]存储的是学生信息表中主键信息，是唯一的
                        Response.Redirect("student.aspx");
                    }
                    else
                    {
                        lbMsgLogin.Text = "用户名或邮箱输入错误!";
                    }
                }
            }
        }
        /// <summary>
        /// 学生端密码登陆时，点击“登录”按钮进行登陆验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin2_Click(object sender, EventArgs e)
        {
            string code2 = txtCode2.Text.ToString().Trim();
            //邮箱验证码
            if (string.IsNullOrEmpty(code2))
            {
                lbMsgCode2.Text = "请输入验证码!";
            }
            else
            {
                string iden2 = txtUser2.Text.ToString().Trim();
                string pwd = txtEmail2.Text.ToString().Trim();
                if (UserBLL.IdentityIsAny(iden2))
                {
                    if (UserBLL.PasswordIsMatch(iden2, pwd))
                    {
                        //当用户勾选“记住密码”的复选框时
                        if (cbRememberEmail2.Checked)
                        {
                            //创建cookie
                            HttpCookie mycookie2 = new HttpCookie("UserInfo2");
                            mycookie2.Values.Add("UserID2", iden2);
                            //mycookie2.Values.Add("Pwd2", pwd);
                            //设置cookie的过期时间
                            mycookie2.Expires = DateTime.Now.AddDays(7);
                            //将cookie写到客户端
                            Response.Cookies.Add(mycookie2);
                        }
                        //当用户没有勾选复选框时，则清除以前的cookie
                        else
                        {
                            if (Request.Cookies["UserInfo2"] != null)
                            {
                                //设置cookie立刻过期
                                Response.Cookies["UserInfo2"].Expires = DateTime.Now.AddDays(-1);
                            }
                        }
                        //验证成功时，创建session
                        Session.Add("User", iden2);
                        Response.Redirect("student.aspx");
                    }
                    else
                    {
                        lbMsgEmail2.Text = "密码或用户名有误!";
                    }
                }
                else
                {
                    lbMsgUser2.Text = "此用户不存在!";
                }
            }
        }
        /// <summary>
        /// 管理端密码登陆时，点击“登录”按钮进行登陆验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin3_Click(object sender, EventArgs e)
        {
            string jobNm = txtUser3.Text.ToString().Trim();
            string pwd3 = txtEmail3.Text.ToString().Trim();
            if (UserBLL.JobNumberIsAny(jobNm))
            {
                if (UserBLL.PasswordIsMatchJobNumber(jobNm, pwd3))
                {
                    //当用户勾选“记住密码”的复选框时
                    if (cbRememberEmail3.Checked)
                    {
                        //创建cookie
                        HttpCookie mycookie3 = new HttpCookie("UserInfo3");
                        mycookie3.Values.Add("JobNum", jobNm);
                        mycookie3.Values.Add("Pwd3", pwd3);
                        //设置cookie的过期时间
                        mycookie3.Expires = DateTime.Now.AddDays(7);
                        //将cookie写到客户端
                        Response.Cookies.Add(mycookie3);
                    }
                    //当用户没有勾选复选框时，则清除以前的cookie
                    else
                    {
                        if (Request.Cookies["UserInfo3"] != null)
                        {
                            //设置cookie立刻过期
                            Response.Cookies["UserInfo3"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                    //验证成功时，创建session
                    Session.Add("AdmainJobNum", jobNm);
                    Response.Redirect("manage.aspx");
                }
                else
                {
                    lbMsgEmail3.Text = "密码错误!";
                }
            }
            else
            {
                lbMsgUser3.Text = "此工号不存在!";
            }
        }
    }
}