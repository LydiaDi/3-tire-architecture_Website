using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.IO;

namespace SoulRoommate
{
    public partial class student : System.Web.UI.Page
    {
        //加载页面之前，读取Session["User"] 的值，如果为空返回login页面
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //在用到验证控件之前必须有这一句话才能保证验证控件正常使用
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                string uid = Session["User"].ToString();
                lbUser.Text = UserBLL.ReturnUserName(uid);//页面顶部显示登陆人的姓名

                //mian2“查看结果”部分进行数据绑定
                Bind2();

                //main3模块，对过去已经申请过的所有信息进行显示
                if (MessageBLL.SendMessage(uid))//在数据库中查询此登录用户曾经是否进行过申请
                {
                    //此登录用户曾经是有过申请，将申请记录进行显示
                    this.lvEverApply.DataSource = MessageBLL.EverApply(uid);
                    this.lvEverApply.DataBind();

                    //数据绑定后，根据是否有回复内容，回复状态列相应的显示“已回复”或“未回复”
                    BindMain3();

                }
                else
                {
                    //此登录用户曾经没有进行过申请，将申请记录进行显示，Panel2隐藏，Panel3显示（提示用户并未进行过任何申请）
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                }
                //main3模块中进行申请部分中的“个人信息”部分进行直接显示
                Label13.Text = UserBLL.ReturnUserName(uid);//显示登陆人的姓名
                Label14.Text = uid;//显示登陆人的登陆人的身份证号

                //main5显示学生收到的所有信息部分进行数据绑定
                if (!MessageBLL.AcceptMessage(uid))
                {
                    Panel11.Visible = true;
                    Panel7.Visible = false;
                    lbMsgCount.Visible = false;
                }
                else
                {
                    Bind(MessageBLL.StudentAllReceiveMes(uid));
                }

                //right1模块个人信息部分进行数据绑定
                Bind3(UserBLL.AStudentInfo(uid));

                //right2“修改密码”模块
                string pwd = UserBLL.SelectStudentPassword(uid);//在数据库中查找登陆用户的密码
                if (string.IsNullOrEmpty(pwd))//判断登陆用户的密码是否为空
                {
                    Panel4.Visible = false;
                    Panel5.Visible = true;//登录用户的密码为空，Panel5模块显示，提示用户先设置密码
                }

                //密码部分的数据绑定，先检查是否已经设置了密码
                //Bind5();
            }
        }

        //显示下一部分的问题
        protected void btMain1A_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rblA1.SelectedValue))
            {
                lbMsgA1.Text = "*不可为空！";
            }
            else
            {
                double A1 = Convert.ToDouble(rblA1.SelectedValue);
                lbMsgA1.Visible = false;
                if (string.IsNullOrEmpty(rblA2.SelectedValue))
                {
                    lbMsgA2.Text = "*不可为空！";
                }
                else
                {
                    double A2 = Convert.ToDouble(rblA2.SelectedValue);
                    lbMsgA2.Visible = false;
                    if (string.IsNullOrEmpty(rblA3.SelectedValue))
                    {
                        lbMsgA3.Text = "*不可为空！";
                    }
                    else
                    {
                        double A3 = Convert.ToDouble(rblA3.SelectedValue);
                        lbMsgA3.Visible = false;
                        if (string.IsNullOrEmpty(rblA4.SelectedValue))
                        {
                            lbMsgA4.Text = "*不可为空！";
                        }
                        else
                        {
                            double A4 = Convert.ToDouble(rblA4.SelectedValue);
                            lbMsgA4.Visible = false;
                            if (string.IsNullOrEmpty(rblA5.SelectedValue))
                            {
                                lbMsgA5.Text = "*不可为空！";
                            }
                            else
                            {
                                double A5 = Convert.ToDouble(rblA5.SelectedValue);
                                lbMsgA5.Visible = false;
                                if (string.IsNullOrEmpty(cblA6.SelectedValue))
                                {
                                    lbMsgA6.Text = "*不可为空！";
                                }
                                else
                                {
                                    double A6a = 0;
                                    double j = 0;
                                    for (int i = 0; i < cblA6.Items.Count; i++)
                                    {
                                        if (cblA6.Items[i].Selected)
                                        {
                                            A6a = Convert.ToDouble(cblA6.Items[i].Value) + A6a;
                                            j = j + 1;
                                        }
                                    }
                                    double A6 = A6a / j;
                                    lbMsgA6.Visible = false;
                                    Good PartA1 = new Good()
                                    {
                                        UserID = Session["User"].ToString(),
                                        A1sleepTime = A1,
                                        A2upTime = A2,
                                        A3noonNap = A3,
                                        A4averageTime = A4,
                                        A5sleepQuality = A5,
                                        A6snore = A6
                                    };
                                    bool a = GoodBLL.UpdateA1(PartA1);
                                    plA.Visible = false;
                                    plB.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        //显示下一部分的问题
        protected void btMain1B_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rblB1.SelectedValue))
            {
                lbMsgB1.Text = "*不可为空！";
            }
            else
            {
                double B1 = Convert.ToDouble(rblB1.SelectedValue);
                lbMsgB1.Visible = false;
                if (string.IsNullOrEmpty(rblB2.SelectedValue))
                {
                    lbMsgB2.Text = "*不可为空！";
                }
                else
                {
                    double B2 = Convert.ToDouble(rblB2.SelectedValue);
                    lbMsgB2.Visible = false;
                    if (string.IsNullOrEmpty(cblB3.SelectedValue))
                    {
                        lbMsgB3.Text = "*不可为空！";
                    }
                    else
                    {
                        double B3a = 0;
                        double j = 0;
                        for (int i = 0; i < cblB3.Items.Count; i++)
                        {
                            if (cblB3.Items[i].Selected)
                            {
                                B3a = Convert.ToDouble(cblA6.Items[i].Value) + B3a;
                                j = j + 1;
                            }
                        }
                        double B3 = B3a / j;
                        lbMsgB3.Visible = false;
                        if (string.IsNullOrEmpty(rblB4.SelectedValue))
                        {
                            lbMsgB4.Text = "*不可为空！";
                        }
                        else
                        {
                            double B4 = Convert.ToDouble(rblB4.SelectedValue);
                            lbMsgB4.Visible = false;
                            if (string.IsNullOrEmpty(rblB5.SelectedValue))
                            {
                                lbMsgB5.Text = "*不可为空！";
                            }
                            else
                            {
                                double B5 = Convert.ToDouble(rblB5.SelectedValue);
                                lbMsgB5.Visible = false;
                                Good PartB = new Good()
                                {
                                    UserID = Session["User"].ToString(),
                                    B1fitCold=B1,
                                    B2fitHot=B2,
                                    B3airCon=B3,
                                    B4minTem=B4,
                                    B5maxTem=B5
                                };
                                bool b = GoodBLL.UpdateB(PartB);
                                plB.Visible = false;
                                plC.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        //显示下一部分的问题
        protected void btMain1C_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rblC1.SelectedValue))
            {
                lbMsgC1.Text = "*不可为空！";
            }
            else
            {
                double C1 = Convert.ToDouble(rblC1.SelectedValue);
                lbMsgC1.Visible = false;
                if (string.IsNullOrEmpty(rblC2.SelectedValue))
                {
                    lbMsgC2.Text = "*不可为空！";
                }
                else
                {
                    double C2 = Convert.ToDouble(rblC2.SelectedValue);
                    lbMsgC2.Visible = false;
                    if (string.IsNullOrEmpty(rblC3.SelectedValue))
                    {
                        lbMsgC3.Text = "*不可为空！";
                    }
                    else
                    {
                        
                        double C3 = Convert.ToDouble(rblC3.SelectedValue); ;
                        lbMsgC3.Visible = false;
                        if (string.IsNullOrEmpty(rblC4.SelectedValue))
                        {
                            lbMsgC4.Text = "*不可为空！";
                        }
                        else
                        {
                            double C4 = Convert.ToDouble(rblC4.SelectedValue);
                            lbMsgC4.Visible = false;
                            if (string.IsNullOrEmpty(rblC5.SelectedValue))
                            {
                                lbMsgC5.Text = "*不可为空！";
                            }
                            else
                            {
                                double C5 = Convert.ToDouble(rblC5.SelectedValue);
                                lbMsgC5.Visible = false;
                                Good PartC = new Good()
                                {
                                    UserID = Session["User"].ToString(),
                                    C1shower=C1,
                                    C2cleanDesk=C2,
                                    C3cleanRubbish=C3,
                                    C4makeBed=C4,
                                    C5washCloth=C5
                                };
                                bool C = GoodBLL.UpdateC(PartC);
                                plC.Visible = false;
                                plD.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        //显示下一部分的问题
        protected void btMain1D_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rblD1.SelectedValue))
            {
                lbMsgD1.Text = "*不可为空！";
            }
            else
            {
                double D1 = Convert.ToDouble(rblD1.SelectedValue);
                lbMsgD1.Visible = false;
                if (string.IsNullOrEmpty(rblD2.SelectedValue))
                {
                    lbMsgD2.Text = "*不可为空！";
                }
                else
                {
                    double D2 = Convert.ToDouble(rblD2.SelectedValue);
                    lbMsgD2.Visible = false;
                    if (string.IsNullOrEmpty(rblD3.SelectedValue))
                    {
                        lbMsgD3.Text = "*不可为空！";
                    }
                    else
                    {

                        double D3 = Convert.ToDouble(rblD3.SelectedValue); ;
                        lbMsgD3.Visible = false;
                        if (string.IsNullOrEmpty(rblD4.SelectedValue))
                        {
                            lbMsgD4.Text = "*不可为空！";
                        }
                        else
                        {
                            double D4 = Convert.ToDouble(rblD4.SelectedValue);
                            lbMsgD4.Visible = false;
                            if (string.IsNullOrEmpty(rblD5.SelectedValue))
                            {
                                lbMsgD5.Text = "*不可为空！";
                            }
                            else
                            {
                                double D5 = Convert.ToDouble(rblD5.SelectedValue);
                                lbMsgD5.Visible = false;
                                if (string.IsNullOrEmpty(rblD6.SelectedValue))
                                {
                                    lbMsgD6.Text = "*不可为空！";
                                }
                                else
                                {
                                    double D6 = Convert.ToDouble(rblD6.SelectedValue);
                                    lbMsgD6.Visible = false;
                                    if (string.IsNullOrEmpty(rblD7.SelectedValue))
                                    {
                                        lbMsgD7.Text = "*不可为空！";
                                    }
                                    else
                                    {
                                        double D7 = Convert.ToDouble(rblD7.SelectedValue);
                                        lbMsgD7.Visible = false;
                                        if (string.IsNullOrEmpty(rblD8.SelectedValue))
                                        {
                                            lbMsgD8.Text = "*不可为空！";
                                        }
                                        else
                                        {
                                            double D8 = Convert.ToDouble(rblD8.SelectedValue);
                                            lbMsgD8.Visible = false;
                                            if (string.IsNullOrEmpty(rblD9.SelectedValue))
                                            {
                                                lbMsgD9.Text = "*不可为空！";
                                            }
                                            else
                                            {
                                                double D9 = Convert.ToDouble(rblD9.SelectedValue);
                                                lbMsgD9.Visible = false;
                                                if (string.IsNullOrEmpty(rblD10.SelectedValue))
                                                {
                                                    lbMsgD10.Text = "*不可为空！";
                                                }
                                                else
                                                {
                                                    double D10 = Convert.ToDouble(rblD10.SelectedValue);
                                                    lbMsgD10.Visible = false;
                                                    if (string.IsNullOrEmpty(rblD11.SelectedValue))
                                                    {
                                                        lbMsgD11.Text = "*不可为空！";
                                                    }
                                                    else
                                                    {
                                                        double D11 = Convert.ToDouble(rblD11.SelectedValue);
                                                        lbMsgD11.Visible = false;
                                                        if (string.IsNullOrEmpty(rblD12.SelectedValue))
                                                        {
                                                            lbMsgD12.Text = "*不可为空！";
                                                        }
                                                        else
                                                        {
                                                            double D12 = Convert.ToDouble(rblD12.SelectedValue);
                                                            lbMsgD12.Visible = false;
                                                            Good PartD = new Good()
                                                            {
                                                                UserID = Session["User"].ToString(),
                                                                D1smoke=D1,
                                                                D2game = D2,
                                                                D3volume = D3,
                                                                D4express = D4,
                                                                D5coConsum = D5,
                                                                D6elec = D6,
                                                                D7con = D7,
                                                                D8unCon = D8,
                                                                D9coat = D9,
                                                                D10uWear = D10,
                                                                D11maq = D11,
                                                                D12outSide = D12
                                                            };
                                                            bool D = GoodBLL.UpdateD(PartD);
                                                            plD.Visible = false;
                                                            plE.Visible = true;
                                                        }
                                                    }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                        }
                    }
                }
            }
        }
        //显示下一部分的问题
        protected void btMain1E_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rblE1.SelectedValue))
            {
                lbMsgE1.Text = "*不可为空！";
            }
            else
            {
                double E1 = Convert.ToDouble(rblE1.SelectedValue);
                lbMsgE1.Visible = false;
                if (string.IsNullOrEmpty(cblE2.SelectedValue))
                {
                    lbMsgE2.Text = "*不可为空！";
                }
                else
                {
                    double E2a = 0;
                    double j = 0;
                    for (int i = 0; i < cblE2.Items.Count; i++)
                    {
                        if (cblE2.Items[i].Selected)
                        {
                            E2a = Convert.ToDouble(cblA6.Items[i].Value) + E2a;
                            j = j + 1;
                        }
                    }
                    double E2 = E2a / j;
                    lbMsgE2.Visible = false;
                    Good PartE = new Good()
                    {
                        UserID = Session["User"].ToString(),
                        E1income=E1,
                        E2perConsum = E2
                    };  
                    bool E = GoodBLL.UpdateE(PartE);
                    plE.Visible = false;
                    plF.Visible = true;
                }
            }
        }
        //显示下一部分的问题
        protected void btMain1F_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rblF1.SelectedValue))
            {
                lbMsgF1.Text = "*不可为空！";
            }
            else
            {
                double F1 = Convert.ToDouble(rblF1.SelectedValue);
                lbMsgF1.Visible = false;
                if (string.IsNullOrEmpty(rblF2.SelectedValue))
                {
                    lbMsgF2.Text = "*不可为空！";
                }
                else
                {
                    double F2 = Convert.ToDouble(rblF2.SelectedValue);
                    lbMsgF2.Visible = false;
                    if (string.IsNullOrEmpty(rblF3.SelectedValue))
                    {
                        lbMsgF3.Text = "*不可为空！";
                    }
                    else
                    {

                        double F3 = Convert.ToDouble(rblF3.SelectedValue); ;
                        lbMsgF3.Visible = false;
                        if (string.IsNullOrEmpty(rblF4.SelectedValue))
                        {
                            lbMsgF4.Text = "*不可为空！";
                        }
                        else
                        {
                            double F4 = Convert.ToDouble(rblF4.SelectedValue);
                            lbMsgF4.Visible = false;
                            if (string.IsNullOrEmpty(rblF5.SelectedValue))
                            {
                                lbMsgF5.Text = "*不可为空！";
                            }
                            else
                            {
                                double F5 = Convert.ToDouble(rblF5.SelectedValue);
                                lbMsgF5.Visible = false;
                                if (string.IsNullOrEmpty(rblF6.SelectedValue))
                                {
                                    lbMsgF6.Text = "*不可为空！";
                                }
                                else
                                {
                                    double F6 = Convert.ToDouble(rblF6.SelectedValue);
                                    lbMsgF6.Visible = false;
                                    if (string.IsNullOrEmpty(rblF7.SelectedValue))
                                    {
                                        lbMsgF7.Text = "*不可为空！";
                                    }
                                    else
                                    {
                                        double F7 = Convert.ToDouble(rblF7.SelectedValue);
                                        lbMsgF7.Visible = false;
                                        if (string.IsNullOrEmpty(rblF8.SelectedValue))
                                        {
                                            lbMsgF8.Text = "*不可为空！";
                                        }
                                        else
                                        {
                                            double F8 = Convert.ToDouble(rblF8.SelectedValue);
                                            lbMsgF8.Visible = false;
                                            if (string.IsNullOrEmpty(rblF9.SelectedValue))
                                            {
                                                lbMsgF9.Text = "*不可为空！";
                                            }
                                            else
                                            {
                                                double F9 = Convert.ToDouble(rblF9.SelectedValue);
                                                lbMsgF9.Visible = false;
                                                if (string.IsNullOrEmpty(rblF10.SelectedValue))
                                                {
                                                    lbMsgF10.Text = "*不可为空！";
                                                }
                                                else
                                                {
                                                    double F10 = Convert.ToDouble(rblF10.SelectedValue);
                                                    lbMsgF10.Visible = false;
                                                    if (string.IsNullOrEmpty(rblF11.SelectedValue))
                                                    {
                                                        lbMsgF11.Text = "*不可为空！";
                                                    }
                                                    else
                                                    {
                                                        double F11 = Convert.ToDouble(rblF11.SelectedValue);
                                                        lbMsgF11.Visible = false;
                                                        if (string.IsNullOrEmpty(rblF12.SelectedValue))
                                                        {
                                                            lbMsgF12.Text = "*不可为空！";
                                                        }
                                                        else
                                                        {
                                                            double F12 = Convert.ToDouble(rblF12.SelectedValue);
                                                            lbMsgF12.Visible = false; 
                                                            if (string.IsNullOrEmpty(rblF13.SelectedValue))
                                                            {
                                                                lbMsgF13.Text = "*不可为空！";
                                                            }
                                                            else
                                                            {
                                                                double F13 = Convert.ToDouble(rblF13.SelectedValue);
                                                                lbMsgF13.Visible = false;
                                                                if (string.IsNullOrEmpty(rblF14.SelectedValue))
                                                                {
                                                                    lbMsgF14.Text = "*不可为空！";
                                                                }
                                                                else
                                                                {
                                                                    double F14 = Convert.ToDouble(rblF14.SelectedValue);
                                                                    lbMsgF14.Visible = false;
                                                                    if (string.IsNullOrEmpty(rblF15.SelectedValue))
                                                                    {
                                                                        lbMsgF15.Text = "*不可为空！";
                                                                    }
                                                                    else
                                                                    {
                                                                        double F15 = Convert.ToDouble(rblF15.SelectedValue);
                                                                        lbMsgF15.Visible = false;
                                                                        if (string.IsNullOrEmpty(rblF16.SelectedValue))
                                                                        {
                                                                            lbMsgF16.Text = "*不可为空！";
                                                                        }
                                                                        else
                                                                        {
                                                                            double F16 = Convert.ToDouble(rblF16.SelectedValue);
                                                                            lbMsgF16.Visible = false;
                                                                            Good PartF = new Good()
                                                                            {
                                                                                UserID = Session["User"].ToString(),
                                                                                F1sing=F1,
                                                                                F2musIns = F2,
                                                                                F3dance = F3,
                                                                                F4draw = F4,
                                                                                F5white = F5,
                                                                                F6ball = F6,
                                                                                F7tennis = F7,
                                                                                F8run = F8,
                                                                                F9bodyBuild = F9,
                                                                                F10yoga = F10,
                                                                                F11swim = F11,
                                                                                F12movie = F12,
                                                                                F13live = F13,
                                                                                F14claMusic = F14,
                                                                                F15idol = F15,
                                                                                F16ktv = F16
                                                                            };
                                                                            bool F = GoodBLL.UpdateF(PartF);
                                                                            plF.Visible = false;
                                                                            plG.Visible = true;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //提交G部分填写的信息的问题
        protected void btMain1G_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rblG1.SelectedValue))
            {
                lbMsgG1.Text = "*不可为空！";
            }
            else
            {
                double G1 = Convert.ToDouble(rblG1.SelectedValue);
                lbMsgG1.Visible = false;
                if (string.IsNullOrEmpty(rblG2.SelectedValue))
                {
                    lbMsgG2.Text = "*不可为空！";
                }
                else
                {
                    double G2 = Convert.ToDouble(rblG2.SelectedValue);
                    lbMsgG2.Visible = false;
                    if (string.IsNullOrEmpty(rblG3.SelectedValue))
                    {
                        lbMsgG3.Text = "*不可为空！";
                    }
                    else
                    {

                        double G3 = Convert.ToDouble(rblG3.SelectedValue); ;
                        lbMsgG3.Visible = false;
                        if (string.IsNullOrEmpty(rblG4.SelectedValue))
                        {
                            lbMsgG4.Text = "*不可为空！";
                        }
                        else
                        {
                            double G4 = Convert.ToDouble(rblG4.SelectedValue);
                            lbMsgG4.Visible = false;
                            if (string.IsNullOrEmpty(rblG5.SelectedValue))
                            {
                                lbMsgG5.Text = "*不可为空！";
                            }
                            else
                            {
                                double G5 = Convert.ToDouble(rblG5.SelectedValue);
                                lbMsgG5.Visible = false;
                                if (string.IsNullOrEmpty(rblG6.SelectedValue))
                                {
                                    lbMsgG6.Text = "*不可为空！";
                                }
                                else
                                {
                                    double G6 = Convert.ToDouble(rblG6.SelectedValue);
                                    lbMsgG6.Visible = false;
                                    Good PartG = new Good()
                                    {
                                        UserID = Session["User"].ToString(),
                                        G1sexOrient=G1,
                                        G2noSingle = G2,
                                        G3inDisea = G3,
                                        G4family = G4,
                                        G5parent = G5,
                                        G6interact = G6
                                    };
                                    bool G = GoodBLL.UpdateG(PartG);
                                    if (G)
                                    {
                                        ScriptManager.RegisterStartupScript(UpdatePanel4, UpdatePanel4.GetType(), "", "alert('提交成功！')", true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //显示上一部分的问题
        protected void btLastMain1B_Click(object sender, EventArgs e)
        {
            plB.Visible = false;
            plA.Visible = true;
        }
        protected void btLastMain1C_Click(object sender, EventArgs e)
        {
            plC.Visible = false;
            plB.Visible = true;
        }
        protected void btLastMain1D_Click(object sender, EventArgs e)
        {
            plD.Visible = false;
            plC.Visible = true;
        }
        protected void btLastMain1E_Click(object sender, EventArgs e)
        {
            plE.Visible = false;
            plD.Visible = true;
        }
        protected void btLastMain1F_Click(object sender, EventArgs e)
        {
            plF.Visible = false;
            plE.Visible = true;
        }
        protected void btLastMain1G_Click(object sender, EventArgs e)
        {
            plG.Visible = false;
            plF.Visible = true;
        }
        /// <summary>
        /// mian2“查看结果”部分进行数据绑定
        /// </summary>
        private void Bind2()
        {
            string uid = Session["User"].ToString();
            string sex = UserBLL.SelectStudentSex(uid);//通过uid获取登录用户的性别
            string majorAndClass = UserBLL.SelectStudentClass(uid);//通过uid获取登录用户的专业及班级信息
            int fin = UserBLL.FinishInfo(uid);
            if (fin == 1)
            {
                //将属于特定班级、特定性别的学生的信息进行显示
                //如果sex值为男，在男孩分配的结果的表中查询此男生的室友信息
                if (sex == "男")
                {
                    //在数据库中查询登录用户所属班级的结果信息的state值是否为1（1表示已发布，允许学生进行查看）
                    int state = UserBLL.IssueInfoBoy(majorAndClass);
                    if (state == 1)
                    {
                        //将属于特定班级的所有男学生的信息进行显示
                        DataTable allBoy = AdminBLL.AllResultBoy(majorAndClass);
                        //便历表allBoy
                        for (int i = 0; i < allBoy.Rows.Count; i++)
                        {
                            //当登陆人是床位1时，2、3、4床位都有可能出现没有人的情况，因此需要对2、3、4床位是否有学生进行判断
                            if (uid == allBoy.Rows[i]["One"].ToString())
                            {
                                //判断2床位是否有学生
                                if (allBoy.Rows[i]["Two"].ToString() != "无")
                                {
                                    //如果2床位有学生，通过AdminBLL.SelectStudentName方法找到该学生的姓名并进行显示
                                    Label9.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Two"].ToString());
                                }
                                else//如果2床位没有学生Label9中不显示任何内容
                                {
                                    Label9.Text = "";
                                }
                                if (allBoy.Rows[i]["Three"].ToString() != "无")
                                {
                                    Label10.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Three"].ToString());
                                }
                                else
                                {
                                    Label10.Text = "";
                                }
                                if (allBoy.Rows[i]["Four"].ToString() != "无")
                                {
                                    Label11.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Four"].ToString());
                                }
                                else
                                {
                                    Label11.Text = "";
                                }
                                //读取数据库中该行对应的building值并进行显示
                                Label12.Text = allBoy.Rows[i]["Building"].ToString() + "号楼";

                                //读取数据库中该行对应的room值的百位数（即楼层数）并进行显示
                                int room = Convert.ToInt32(allBoy.Rows[i]["Room"].ToString());
                                Label7.Text = Convert.ToString(room / 100) + "层";

                                //读取数据库中该行对应的room值并进行显示
                                Label8.Text = allBoy.Rows[i]["Room"].ToString();
                            }
                            //当登陆人是床位2时，1床位必定有人，因此只需要对3、4床位是否有学生进行判断
                            if (uid == allBoy.Rows[i]["Two"].ToString())
                            {
                                Label9.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["One"].ToString());

                                if (allBoy.Rows[i]["Three"].ToString() != "无")
                                {
                                    Label10.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Three"].ToString());
                                }
                                else
                                {
                                    Label10.Text = "";
                                }
                                if (allBoy.Rows[i]["Four"].ToString() != "无")
                                {
                                    Label11.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Four"].ToString());
                                }
                                else
                                {
                                    Label11.Text = "";
                                }
                                Label12.Text = allBoy.Rows[i]["Building"].ToString() + "号楼";
                                int room = Convert.ToInt32(allBoy.Rows[i]["Room"].ToString());
                                Label7.Text = Convert.ToString(room / 100) + "层";
                                Label8.Text = allBoy.Rows[i]["Room"].ToString();
                            }
                            //当登陆人是床位3时，1、2床位必定有人，因此只需要对4床位是否有学生进行判断
                            if (uid == allBoy.Rows[i]["Three"].ToString())
                            {
                                Label9.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["One"].ToString());
                                Label10.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Two"].ToString());

                                if (allBoy.Rows[i]["Four"].ToString() != "无")
                                {
                                    Label11.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Four"].ToString());
                                }
                                else
                                {
                                    Label11.Text = "";
                                }
                                Label12.Text = allBoy.Rows[i]["Building"].ToString() + "号楼";
                                int room = Convert.ToInt32(allBoy.Rows[i]["Room"].ToString());
                                Label7.Text = Convert.ToString(room / 100) + "层";
                                Label8.Text = allBoy.Rows[i]["Room"].ToString();
                            }
                            //当登陆人是床位4时，1、2、3床位必定有人，因此不需要对其它床位是否有学生进行判断
                            if (uid == allBoy.Rows[i]["Four"].ToString())
                            {
                                Label9.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["One"].ToString());
                                Label10.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Two"].ToString());
                                Label11.Text = AdminBLL.SelectStudentName(allBoy.Rows[i]["Three"].ToString());

                                Label12.Text = allBoy.Rows[i]["Building"].ToString() + "号楼";
                                int room = Convert.ToInt32(allBoy.Rows[i]["Room"].ToString());
                                Label7.Text = Convert.ToString(room / 100) + "层";
                                Label8.Text = allBoy.Rows[i]["Room"].ToString();
                            }
                        }
                        //如果“楼宇”部分值不为空，说明此学生已经进行分配，需使得Panel1模块显示，Label19与Label20隐藏
                        if (Label12.Text != "")
                        {
                            Panel1.Visible = true;
                            Label19.Visible = false;
                            Label20.Visible = false;
                        }
                        //如果“楼宇”部分值为空，说明此学生还未进行分配，需使得Label19模块显示，Panel1与Label20隐藏
                        else
                        {
                            Panel1.Visible = false;
                            Label19.Visible = true;
                            Label20.Visible = false;
                        }
                    }
                    //登录用户所属班级的分配结果信息的state值是否为0（表示信息还未发布，不允许学生进行查看）
                    else
                    {
                        Panel1.Visible = false;
                        Label19.Visible = false;
                        Label20.Visible = true;
                    }

                }
                //与上面对男孩的室友信息进行显示类似
                //如果sex值为女，在女孩分配的结果的表中查询此女生的室友信息
                if (sex == "女")
                {
                    bool e = UserBLL.IssueInfoGirlAny(majorAndClass);
                    if (e)
                    {
                        int state = UserBLL.IssueInfoGirl(majorAndClass);
                        if (state == 1)
                        {
                            //将属于特定班级的所有女学生的信息进行显示
                            DataTable allGirl = AdminBLL.AllResultGirl(majorAndClass);
                            for (int i = 0; i < allGirl.Rows.Count; i++)
                            {
                                if (uid == allGirl.Rows[i]["One"].ToString())
                                {
                                    if (allGirl.Rows[i]["Two"].ToString() != "无")
                                    {
                                        Label9.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Two"].ToString());
                                    }
                                    else
                                    {
                                        Label9.Text = "";
                                    }
                                    if (allGirl.Rows[i]["Three"].ToString() != "无")
                                    {
                                        Label10.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Three"].ToString());
                                    }
                                    else
                                    {
                                        Label10.Text = "";
                                    }
                                    if (allGirl.Rows[i]["Four"].ToString() != "无")
                                    {
                                        Label11.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Four"].ToString());
                                    }
                                    else
                                    {
                                        Label11.Text = "";
                                    }
                                    Label12.Text = allGirl.Rows[i]["Building"].ToString() + "号楼";
                                    int room = Convert.ToInt32(allGirl.Rows[i]["Room"].ToString());
                                    Label7.Text = Convert.ToString(room / 100) + "层"; 
                                    Label8.Text = allGirl.Rows[i]["Room"].ToString();
                                }
                                if (uid == allGirl.Rows[i]["Two"].ToString())
                                {
                                    Label9.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["One"].ToString());

                                    if (allGirl.Rows[i]["Three"].ToString() != "无")
                                    {
                                        Label10.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Three"].ToString());
                                    }
                                    else
                                    {
                                        Label10.Text = "";
                                    }
                                    if (allGirl.Rows[i]["Four"].ToString() != "无")
                                    {
                                        Label11.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Four"].ToString());
                                    }
                                    else
                                    {
                                        Label11.Text = "";
                                    }
                                    Label12.Text = allGirl.Rows[i]["Building"].ToString() + "号楼";
                                    int room = Convert.ToInt32(allGirl.Rows[i]["Room"].ToString());
                                    Label7.Text = Convert.ToString(room / 100) + "层";
                                    Label8.Text = allGirl.Rows[i]["Room"].ToString();
                                }
                                if (uid == allGirl.Rows[i]["Three"].ToString())
                                {
                                    Label9.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["One"].ToString());
                                    Label10.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Two"].ToString());

                                    if (allGirl.Rows[i]["Four"].ToString() != "无")
                                    {
                                        Label11.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Four"].ToString());
                                    }
                                    else
                                    {
                                        Label11.Text = "";
                                    }
                                    Label12.Text = allGirl.Rows[i]["Building"].ToString() + "号楼";
                                    int room = Convert.ToInt32(allGirl.Rows[i]["Room"].ToString());
                                    Label7.Text = Convert.ToString(room / 100) + "层";
                                    Label8.Text = allGirl.Rows[i]["Room"].ToString();
                                }
                                if (uid == allGirl.Rows[i]["Four"].ToString())
                                {
                                    Label9.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["One"].ToString());
                                    Label10.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Two"].ToString());
                                    Label11.Text = AdminBLL.SelectStudentName(allGirl.Rows[i]["Three"].ToString());

                                    Label12.Text = allGirl.Rows[i]["Building"].ToString() + "号楼";
                                    int room = Convert.ToInt32(allGirl.Rows[i]["Room"].ToString());
                                    Label7.Text = Convert.ToString(room / 100) + "层";
                                    Label8.Text = allGirl.Rows[i]["Room"].ToString();
                                }
                            }
                            if (Label12.Text != "")
                            {
                                Panel1.Visible = true;
                                Label19.Visible = false;
                                Label20.Visible = false;
                            }
                            else
                            {
                                Panel1.Visible = false;
                                Label19.Visible = true;
                                Label20.Visible = false;
                            }
                        }
                        else
                        {
                            Panel1.Visible = false;
                            Label19.Visible = false;
                            Label20.Visible = true;
                        }
                    }

                }
                
            }
            else
            {
                Panel1.Visible = false;
                Label19.Visible = false;
                Label20.Visible = false;
                Label49.Visible = true;
            }

            
        }
        /// <summary>
        /// main3显示学生曾经提交过的信息部分根据是否有回复内容、消息是否已读，回复状态列相应的显示“已回复”或“未回复”、消息状态列相应显示“已读”、“未读”
        /// </summary>
        private void BindMain3()
        {
            foreach (ListViewItem tempItem in lvEverApply.Items)
            {
                string re = (tempItem.FindControl("lbRContent") as LinkButton).Text.ToString();
                if (String.IsNullOrEmpty(re))
                {
                    (tempItem.FindControl("lbRContent") as LinkButton).Text = "未回复";
                }
                else
                {
                    (tempItem.FindControl("lbRContent") as LinkButton).Text = "已回复";
                }

                string read = (tempItem.FindControl("lbRead") as Label).Text.ToString();
                if (String.IsNullOrEmpty(read)|| read=="0")
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
        /// main3模块查看过去提交的信息部分关于是否有回复信息部分的信息绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lvEverApply_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            foreach (ListViewItem tempItem in lvEverApply.Items)
            {
                string re = (tempItem.FindControl("lbRContent") as LinkButton).Text.ToString();
                if (String.IsNullOrEmpty(re))
                {
                    (tempItem.FindControl("lbRContent") as LinkButton).Text = "未回复";
                }
                else
                {
                    (tempItem.FindControl("lbRContent") as LinkButton).Text = "已回复";
                }
            }
        }
        /// <summary>
        /// main3模块中，点击“新建”这个id为clNew的控件时，cNew模块出现，cList模块隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clbNew2_Click(object sender, EventArgs e)
        {
            Panel9.Visible = false;
            Panel10.Visible = true;
            Label5.Text = "新建申请";
        }
        /// <summary>
        /// main3模块中，点击“返回”这个id为clBack的控件时，cNew模块隐藏，cList模块显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clbBack2_Click(object sender, EventArgs e)
        {
            Panel10.Visible = false;
            Panel9.Visible = true;
            Label5.Text = "申请记录";
        }
        /// <summary>
        /// mian3模块的查看回复信息及main5模块lvMes表中所涉及的“查看”、“删除”、“回复”字段绑定的Command事件集合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_GoodDetail(object sender, CommandEventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string UserID = lbtn.CommandArgument;

            //main3模块点击“回复状态”列按钮，如果没有回复显示未回复弹窗，如果已经回复，以弹窗形式显示具体的回复内容
            if (lbtn.CommandName.Equals("SeeReply"))
            {
                if (lbtn.Text.ToString() == "未回复")
                {
                    //Response.Write("<script language='javascript'>alert('没有回复信息！')</script>");
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('没有回复信息！')", true);
                }
                else
                {
                    string content = MessageBLL.SelectReContent(Convert.ToInt32(UserID));
                    //Response.Write("<script language='javascript'>alert('回复内容：  " + content + "')</script>");
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('回复内容：  "+ content + "')", true);
                }
            }

            //main5模块中的事件
            //点击查看按钮以弹窗方式显示信息内容
            if (lbtn.CommandName.Equals("SeeCotent"))
            {
                Message mes = new Message()
                {
                    MID = Convert.ToInt32(UserID),
                    Read = 1
                };
                bool update = MessageBLL.ReadSuccess(mes);

                string content = MessageBLL.SelectContent(Convert.ToInt32(UserID));
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", "alert('" + content + "')", true);
                //Response.Write("<script language='javascript'>alert('" + content + "')</script>");
                
                //Response.Redirect("student.aspx");
                //main5显示学生收到的所有信息部分进行数据绑定
                string uid = Session["User"].ToString();
                Bind(MessageBLL.StudentAllReceiveMes(uid));
            }
            //点击删除字段，表面上删除该信息（在网页端不显示信息，但是数据库中仍有信息记录）
            if (lbtn.CommandName.Equals("Delect"))
            {
                Message mes = new Message()
                {
                    MID = Convert.ToInt32(UserID),
                    Delect = 0
                };
                bool update = MessageBLL.Delect(mes);
                //Response.Write(update);
                //Response.Redirect("student.aspx");
                //main5显示学生收到的所有信息部分进行数据绑定
                string uid = Session["User"].ToString();
                Bind(MessageBLL.StudentAllReceiveMes(uid));
            }
            //点击回复按钮，回复模块Panel8进行显示
            if (lbtn.CommandName.Equals("Reply"))
            {
                if (lbtn.Text.ToString() == "查看回复")
                {
                    string content = MessageBLL.SelectReContent(Convert.ToInt32(UserID));
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", "alert('回复内容：  " + content + "')", true);
                }
                else
                {
                    Session.Add("MID", UserID);
                    Panel7.Visible = false;
                    Panel8.Visible = true;
                }
            }
        }
        /// <summary>
        /// main3部分点击“确定”按钮时提交登陆人的申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                Label16.Text = "*请填写完整";
            }
            else
            {
                if (TextBox1.Text == "")
                {
                    Label16.Text = "*请填写完整";
                }
                else
                {
                    string college = MessageBLL.SelectCollege(Label14.Text.ToString().Trim());//查找登录人所在的学院
                    string jobNumber = MessageBLL.SelectJobNumber(college);//查找该学院的管理员的工号
                    Message apply = new Message()//建立Message实体，用于向Message表中插入信息
                    {
                        Send = Label14.Text.ToString().Trim(),
                        Read = 0,
                        Content = "调换原因：" + TextBox2.Text + "  具体内容：" + TextBox1.Text,
                        Time = DateTime.Now,
                        Type = DropDownList1.Text.Trim(),
                        Accept = jobNumber,
                        Delect = 1
                    };
                    bool a = MessageBLL.InsertUrgeMessage(apply);
                    if (a)//判断插入信息是否成功，插入成功则显示弹窗
                    {
                        //main3显示记录部分数据绑定
                        //将此登录用户申请记录进行显示
                        this.lvEverApply.DataSource = MessageBLL.EverApply(Session["User"].ToString());
                        this.lvEverApply.DataBind();
                        //数据绑定后，根据是否有回复内容，回复状态列相应的显示“已回复”或“未回复”
                        BindMain3();

                        //Response.Write("<script language='javascript'>alert('发送成功！')</script>");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('发送成功！')", true);
                    }
                }
            }

            //提交过申请后main3模块再次进行数据绑定——使得学生返回时即可看到自己的新纪录
            string uid = Session["User"].ToString();
            if (MessageBLL.SendMessage(uid))//在数据库中查询此登录用户曾经是否进行过申请
            {
                //此登录用户曾经是有过申请，将申请记录进行显示
                this.lvEverApply.DataSource = MessageBLL.EverApply(uid);
                this.lvEverApply.DataBind();

                //数据绑定后，根据是否有回复内容，回复状态列相应的显示“已回复”或“未回复”
                BindMain3();

            }
        }
        /// <summary>
        /// main4模块下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnDown_Click1(object sender, EventArgs e)
        {
            // 定义文件路径
            string url = "";
            // 定义文件名
            string fileName = "";

            // 获取文件在服务器的地址
            url = "~/File/天津师范大学2019年新生入学须知(本科).pdf";
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
        /// <summary>
        /// right2部分，当登录用户并没有设置密码时，点击“设置密码”按钮，Panel5隐藏，用于设置密码的Panel6模块显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;
            Panel6.Visible = true;
        }
        private void Bind3(DataTable aStudentInfo)
        {
            ListView1.DataSource = aStudentInfo;
            ListView1.DataBind();
        }
        /// <summary>
        /// main5显示学生收到的所有信息部分进行数据绑定
        /// </summary>
        /// <param name="AllMesReceive"></param>
        private void Bind(DataTable AllMesReceive)
        {
            this.lvMes.DataSource = AllMesReceive;
            this.lvMes.DataBind();

            //如果有未读消息，显示未读消息的个数，否则不显示任何提醒标志
            int count = MessageBLL.AcceptMessageCount(Session["User"].ToString());
            if (count > 0)
            {
                lbMsgCount.Visible = true;
                lbMsgCount.Text = count.ToString();
            }
            else
            {
                lbMsgCount.Visible=false;
            }
            //main5"已读""未读""已回复""未回复"数据绑定
            BindMain5();
        }
        /// <summary>
        ///  main5显示学生曾经提交过的信息部分根据是否有回复内容、消息是否已读，回复状态列相应的显示“已回复”或“未回复”、消息状态列相应显示“已读”、“未读”
        /// </summary>
        private void BindMain5()
        {
            foreach (ListViewItem tempItem in lvMes.Items)
            {
                string re = (tempItem.FindControl("lbReContent") as Label).Text.ToString();
                if (String.IsNullOrEmpty(re))
                {
                    (tempItem.FindControl("lbReContent") as Label).Text = "未回复";
                }
                else
                {
                    (tempItem.FindControl("lbReContent") as Label).Text = "已回复";
                }

                string read = (tempItem.FindControl("lbRead") as Label).Text.ToString();
                if (String.IsNullOrEmpty(read) || read == "0")
                {
                    (tempItem.FindControl("lbRead") as Label).Text = "未读";
                }
                else
                {
                    (tempItem.FindControl("lbRead") as Label).Text = "已读";
                }

                //string re2 = (tempItem.FindControl("lbRContent") as LinkButton).Text.ToString();
                if ((tempItem.FindControl("lbReContent") as Label).Text  == "未回复")
                {
                    (tempItem.FindControl("lbRContent") as LinkButton).Text = "进行回复";
                }
                else
                {
                    (tempItem.FindControl("lbRContent") as LinkButton).Text = "查看回复";
                }
            }
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
                reContent = tbRecontent.Text.ToString().Trim()
            };
            bool update = MessageBLL.AddReplyInfo(mes);
            if (update)
            {
                //Response.Write("<script language='javascript'>alert('回复成功！')</script>");
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", "alert('回复成功！')", true);
            }
        }
        /// <summary>
        /// main5在回复信息模块点击返回按钮，回复信息模块进行隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button12_Click(object sender, EventArgs e)
        {
            Panel8.Visible = false;
            Panel7.Visible = true;
        }
        /// <summary>
        /// right2模块，设置密码模块——发送验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            string iden = Session["User"].ToString();
            string email = txtEmail.Text.Trim();

            if (UserBLL.EamilIsMatch(iden, email))//验证一下数据库中此登录用户与输入的邮箱是否是匹配的
            {
                lbMsgSendCode.Text = EmailServer.SendSMTPEMail(txtEmail.Text.Trim()) == true ? "发送成功！" : "发送失败！";
            }
            else
            {
                lbMsgEmail.Text = "此邮箱与用户名不匹配!";//数据库中此用户与输入的邮箱不是匹配的，不再发送验证码，直接显示错误信息
            }
        }
        /// <summary>
        /// right2模块，设置密码模块——点击“确定”设置密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.ToString().Trim();
            if (string.IsNullOrEmpty(code))
            {
                lbMsgCode.Text = "请输入验证码!";
            }
            else
            {
                if (!code.Equals(EmailServer.Code))
                {
                    lbMsgCode.Text = "验证码输入有误!";
                }
                else
                {
                    if (string.IsNullOrEmpty(tbSetPwd.Text.Trim()))
                    {
                        lbMsgSetPwd.Text = "请输入密码";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(tbSetPwd2.Text.Trim()))
                        {
                            lbMsgSetPwd2.Text = "请输入密码";
                        }
                        else
                        {
                            if (!tbSetPwd.Text.Trim().Equals(tbSetPwd2.Text.Trim()))
                            {
                                lbMsgSetPwd2.Text = "两次密码输入不一致";
                            }
                            else
                            {
                                string uid = Session["User"].ToString();
                                User ad = new User()
                                {
                                    Identity = uid,
                                    Password = tbSetPwd.Text.Trim()
                                };
                                bool success = AdminBLL.UpdateStudentPwd(ad);
                                if (success)
                                {
                                    lbMsgSetPwd2.Text = "设置成功！";
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// right2部分点击修改密码后对密码进行更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button10_Click(object sender, EventArgs e)
        {
            string uid = Session["User"].ToString();
            string oldPwd = AdminBLL.SelectStudentPassword(uid);
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
                            User ad = new User()
                            {
                                Identity = uid,
                                Password = tbNewPwd.Text.ToString().Trim()
                            };
                            bool success = AdminBLL.UpdateStudentPwd(ad);
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
    }
}