<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="SoulRoommate.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/student.css" />
    <script src="JS/jquery(v3.5.1).min.js"></script>
    <%--    <script src="JS/student.js"></script>--%>
    <script src="JS/student3.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="student-top">
            <div class="student-top-left">
                <asp:Label ID="Label1" runat="server" Text="Student"></asp:Label>
            </div>
            <div class="student-top-middle">
                <div class="b1">
                    <ul id="ul2">
                        <li style="color: black">填写信息</li>
                        <li>查看结果</li>
                        <li>进行申请</li>
                        <li>其它通知</li>
                    </ul>
                </div>
            </div>
            <div class="student-top-right">
                <div class="student-top-right-img">
                    <asp:Image ID="imgEmail" runat="server" Height="35px" ImageUrl="~/Img/icon/email3.PNG" Width="50px" />
                </div>
                <div id="student-top-right-msgCount">
                    <asp:Label ID="lbMsgCount" runat="server" Text="7" BackColor="#60c1d4" ForeColor="White" Visible="False"></asp:Label>
                </div>
                <div class="stduent-top-text">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="lbfix" runat="server" Text="欢迎您，"></asp:Label>
                    <asp:Label ID="lbUser" runat="server" Text="陈银迪" Font-Underline="True"></asp:Label>
                </div>
                <div class="student-top-right-arrow">
                    <asp:Image ID="imgArrow" runat="server" ImageUrl="~/Img/icon/arrow2.PNG" Width="20px" Height="10px" />
                </div>
                <div id="a4">
                    <div class="a5">
                        <ul id="ul1">
                            <li>个人信息</li>
                            <li>修改密码</li>
                            <li>退出</li>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
        <div class="student-content">
            <div id="main1" class="main" style="display: block">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <div class="c1">
                    <asp:Label ID="Label3" runat="server" Text="填写信息" Font-Bold="True"></asp:Label>
                </div>
                <div class="contain2">
                    <asp:Panel ID="plA" runat="server">
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">

                                <asp:Label ID="Label45" runat="server" Text="一、	作息习惯" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>
                        <%--1.1--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label39" runat="server" Text="1.您的平均入睡时间（晚上）"></asp:Label>
                                <asp:RadioButtonList ID="rblA1" runat="server">
                                    <asp:ListItem Value="1">20：30之前</asp:ListItem>
                                    <asp:ListItem Value="2">20：30-21：30</asp:ListItem>
                                    <asp:ListItem Value="3">21：30-22：30</asp:ListItem>
                                    <asp:ListItem Value="4">22：30-23：30</asp:ListItem>
                                    <asp:ListItem Value="5">23：30-00：30</asp:ListItem>
                                    <asp:ListItem Value="6">00：30-1：30</asp:ListItem>
                                    <asp:ListItem Value="7">1：30之后</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgA1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--1.2--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label40" runat="server" Text="2.	您的平均起床时间（白天）"></asp:Label>
                                <asp:RadioButtonList ID="rblA2" runat="server">
                                    <asp:ListItem Value="1">5：30之前</asp:ListItem>
                                    <asp:ListItem Value="2">5：30-6：30</asp:ListItem>
                                    <asp:ListItem Value="3">6：30-7：30</asp:ListItem>
                                    <asp:ListItem Value="4">7：30-8：30</asp:ListItem>
                                    <asp:ListItem Value="5">8：30-9：30</asp:ListItem>
                                    <asp:ListItem Value="6">9：30-10：30</asp:ListItem>
                                    <asp:ListItem Value="7">10：30之后</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgA2" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--1.3--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label41" runat="server" Text="3.	您是否有午睡的习惯？"></asp:Label>
                                <asp:RadioButtonList ID="rblA3" runat="server">
                                    <asp:ListItem Value="1">每天都睡午觉</asp:ListItem>
                                    <asp:ListItem Value="2">不一定</asp:ListItem>
                                    <asp:ListItem Value="3">从来不睡午觉</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgA3" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--1.4--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label42" runat="server" Text="4.	您午睡的平均时长？"></asp:Label>
                                <asp:RadioButtonList ID="rblA4" runat="server">
                                    <asp:ListItem Value="1">无</asp:ListItem>
                                    <asp:ListItem Value="2">小于30分钟</asp:ListItem>
                                    <asp:ListItem Value="3">30-60分钟</asp:ListItem>
                                    <asp:ListItem Value="4">1-2小时</asp:ListItem>
                                    <asp:ListItem Value="5">大于2小时</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgA4" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--1.5--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label43" runat="server" Text="5.	您通常的睡眠质量如何？"></asp:Label>
                                <asp:RadioButtonList ID="rblA5" runat="server">
                                    <asp:ListItem Value="1">很好，雷打不动</asp:ListItem>
                                    <asp:ListItem Value="2">还可以，能接受一点声音和光线</asp:ListItem>
                                    <asp:ListItem Value="3">很轻，不能有声音和光线</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgA5" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--1.6--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label44" runat="server" Text="6.	您是否有打呼噜、磨牙等习惯？"></asp:Label>
                                <asp:CheckBoxList ID="cblA6" runat="server">
                                    <asp:ListItem Value="1">打呼噜</asp:ListItem>
                                    <asp:ListItem Value="2">磨牙</asp:ListItem>
                                    <asp:ListItem Value="3">说梦话</asp:ListItem>
                                    <asp:ListItem Value="4">梦游</asp:ListItem>
                                    <asp:ListItem Value="5">其它</asp:ListItem>
                                    <asp:ListItem Value="6">无</asp:ListItem>
                                </asp:CheckBoxList>
                                <asp:Label ID="lbMsgA6" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Button ID="btMain1A" runat="server" Text="下一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btMain1A_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="plB" runat="server" Visible="False">
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">

                                <asp:Label ID="Label46" runat="server" Text="二、	空调使用习惯" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>

                        <%--2.1--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label47" runat="server" Text="1.	您对寒冷环境的适应程度"></asp:Label>
                                <asp:RadioButtonList ID="rblB1" runat="server">
                                    <asp:ListItem Value="1">极度怕冷</asp:ListItem>
                                    <asp:ListItem Value="2">非常怕冷</asp:ListItem>
                                    <asp:ListItem Value="3">一般怕冷</asp:ListItem>
                                    <asp:ListItem Value="4">不太怕冷</asp:ListItem>
                                    <asp:ListItem Value="5">一点都不怕冷</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgB1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--2.2--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label48" runat="server" Text="2.	您对炎热环境的适应程度"></asp:Label>
                                <asp:RadioButtonList ID="rblB2" runat="server">
                                    <asp:ListItem Value="1">极度怕热</asp:ListItem>
                                    <asp:ListItem Value="2">非常怕热</asp:ListItem>
                                    <asp:ListItem Value="3">一般怕热</asp:ListItem>
                                    <asp:ListItem Value="4">不太怕热</asp:ListItem>
                                    <asp:ListItem Value="5">一点都不怕热</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgB2" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--2.3--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label50" runat="server" Text="3.	您的空调使用情况"></asp:Label>
                                <asp:CheckBoxList ID="cblB3" runat="server">
                                    <asp:ListItem Value="1">夏天很热时会开空调</asp:ListItem>
                                    <asp:ListItem Value="2">冬天很冷时会开空调</asp:ListItem>
                                    <asp:ListItem Value="3">都不会开</asp:ListItem>
                                </asp:CheckBoxList>
                                <asp:Label ID="lbMsgB3" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--2.4--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label51" runat="server" Text="4.	空调制冷模式时，您能接受的最低温度是？"></asp:Label>
                                <asp:RadioButtonList ID="rblB4" runat="server">
                                    <asp:ListItem Value="1">18℃</asp:ListItem>
                                    <asp:ListItem Value="2">19℃</asp:ListItem>
                                    <asp:ListItem Value="3">20℃</asp:ListItem>
                                    <asp:ListItem Value="4">21℃</asp:ListItem>
                                    <asp:ListItem Value="5">22℃</asp:ListItem>
                                    <asp:ListItem Value="6">23℃</asp:ListItem>
                                    <asp:ListItem Value="7">24℃</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgB4" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--2.5--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label53" runat="server" Text="5.	空调制热模式时，您能接受的最高温度是？"></asp:Label>
                                <asp:RadioButtonList ID="rblB5" runat="server">
                                    <asp:ListItem Value="1">24℃</asp:ListItem>
                                    <asp:ListItem Value="2">25℃</asp:ListItem>
                                    <asp:ListItem Value="3">26℃</asp:ListItem>
                                    <asp:ListItem Value="4">27℃</asp:ListItem>
                                    <asp:ListItem Value="5">28℃</asp:ListItem>
                                    <asp:ListItem Value="6">29℃</asp:ListItem>
                                    <asp:ListItem Value="7">30℃</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgB5" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Button ID="btLastMain1B" runat="server" Text="上一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btLastMain1B_Click" />
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="btMain1B" runat="server" Text="下一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btMain1B_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="plC" runat="server" Visible="False">
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label64" runat="server" Text="三、	卫生习惯" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>
                        <%--3.1--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label52" runat="server" Text="1.	您的洗澡频率通常是？"></asp:Label>
                                <asp:RadioButtonList ID="rblC1" runat="server">
                                    <asp:ListItem Value="1">每天</asp:ListItem>
                                    <asp:ListItem Value="2">两天</asp:ListItem>
                                    <asp:ListItem Value="3">三天</asp:ListItem>
                                    <asp:ListItem Value="4">一周</asp:ListItem>
                                    <asp:ListItem Value="5">两周</asp:ListItem>
                                    <asp:ListItem Value="6">两周以上</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgC1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--3.2--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label55" runat="server" Text="2. 您进行“桌面整理”的频率？"></asp:Label>
                                <asp:RadioButtonList ID="rblC2" runat="server">
                                    <asp:ListItem Value="1">从不</asp:ListItem>
                                    <asp:ListItem Value="2">偶尔</asp:ListItem>
                                    <asp:ListItem Value="3">有时会</asp:ListItem>
                                    <asp:ListItem Value="4">常常</asp:ListItem>
                                    <asp:ListItem Value="5">总是</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgC2" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--3.3--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label57" runat="server" Text="3. 您进行“打扫垃圾”的频率？"></asp:Label>
                                <asp:RadioButtonList ID="rblC3" runat="server">
                                    <asp:ListItem Value="1">从不</asp:ListItem>
                                    <asp:ListItem Value="2">偶尔</asp:ListItem>
                                    <asp:ListItem Value="3">有时会</asp:ListItem>
                                    <asp:ListItem Value="4">常常</asp:ListItem>
                                    <asp:ListItem Value="5">总是</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgC3" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--3.4--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label59" runat="server" Text="4. 您进行“收拾床铺”的频率？"></asp:Label>
                                <asp:RadioButtonList ID="rblC4" runat="server">
                                    <asp:ListItem Value="1">从不</asp:ListItem>
                                    <asp:ListItem Value="2">偶尔</asp:ListItem>
                                    <asp:ListItem Value="3">有时会</asp:ListItem>
                                    <asp:ListItem Value="4">常常</asp:ListItem>
                                    <asp:ListItem Value="5">总是</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgC4" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--3.5--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label61" runat="server" Text="5. 您进行“清洗衣物”的频率？"></asp:Label>
                                <asp:RadioButtonList ID="rblC5" runat="server">
                                    <asp:ListItem Value="1">从不</asp:ListItem>
                                    <asp:ListItem Value="2">偶尔</asp:ListItem>
                                    <asp:ListItem Value="3">有时会</asp:ListItem>
                                    <asp:ListItem Value="4">常常</asp:ListItem>
                                    <asp:ListItem Value="5">总是</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgC5" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Button ID="btnLastMain1C" runat="server" Text="上一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btLastMain1C_Click" />
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="btMain1C" runat="server" Text="下一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btMain1C_Click" />

                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="plD" runat="server" Visible="False">
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label65" runat="server" Text="四、	个性化习惯" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>
                        <%--4.1--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label54" runat="server" Text="1.	您是否吸烟？"></asp:Label>
                                <asp:RadioButtonList ID="rblD1" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="2">否</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgD1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--4.2--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label58" runat="server" Text="2.	您是否喜欢开麦（语音）打游戏？"></asp:Label>
                                <asp:RadioButtonList ID="rblD2" runat="server">
                                    <asp:ListItem Value="1">打游戏、开麦</asp:ListItem>
                                    <asp:ListItem Value="2">打游戏、但不开麦</asp:ListItem>
                                    <asp:ListItem Value="3">不打游戏</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgD2" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <%--4.3--%>
                        <div class="manage-main2-step1-1">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label62" runat="server" Text="3.	您是否喜欢手机音量公放（看视频，打电话）？"></asp:Label>
                                <asp:RadioButtonList ID="rblD3" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="2">否</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbMsgD3" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                      <%--4.4--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Lab" runat="server" Text="4. 您能接受帮室友拿快递/外卖吗？"></asp:Label >
                        <asp:RadioButtonList ID = "rblD4" runat="server">
                            <asp:ListItem Value = "1" > 很不愿意 </asp:ListItem >
                            <asp:ListItem Value = "2" > 比较不愿意 </asp:ListItem >
                            <asp:ListItem Value = "3" > 无所谓 </asp:ListItem >
                            <asp:ListItem Value = "4" > 比较愿意 </asp:ListItem >
                            <asp:ListItem Value = "5" > 很愿意 </asp:ListItem >
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgD4" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div >
                        </div >

                        <%--4.5--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Labe48" runat="server" Text="5. 您认为宿舍共同花费应该如何处理？"></asp:Label >
                        <asp:RadioButtonList ID = "rblD5" runat="server">
                        <asp:ListItem Value = "1" > 均摊 AA制 </asp:ListItem >
                        <asp:ListItem Value = "2" > 轮流付 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD5" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--4.6--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Labl48" runat="server" Text="6. 您对于室友使用个人物品的接受程度如贵重电子产品（电脑、单反相机、iPad等）"></asp:Label >
                        <asp:RadioButtonList ID = "rblD6" runat="server">
                        <asp:ListItem Value = "1" > 不能接受 </asp:ListItem >
                        <asp:ListItem Value = "2" > 不太能接受 </asp:ListItem >
                        <asp:ListItem Value = "3" > 一般般 </asp:ListItem >
                        <asp:ListItem Value = "4" > 可以接受 </asp:ListItem >
                        <asp:ListItem Value = "5" > 完全能接受 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD6" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--4.7--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Labe98" runat="server" Text="7. 您对于室友使用个人物品的接受程度如日常消耗品（洗衣液、卫生纸、卫生巾等）"></asp:Label >
                        <asp:RadioButtonList ID = "rblD7" runat="server">
                        <asp:ListItem Value = "1" > 不能接受 </asp:ListItem >
                        <asp:ListItem Value = "2" > 不太能接受 </asp:ListItem >
                        <asp:ListItem Value = "3" > 一般般 </asp:ListItem >
                        <asp:ListItem Value = "4" > 可以接受 </asp:ListItem >
                        <asp:ListItem Value = "5" > 完全能接受 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD7" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--4.8--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Labpe48" runat="server" Text="8. 您对于室友使用个人物品的接受程度如日常非消耗品（梳子、衣架、杯子等）"></asp:Label >
                        <asp:RadioButtonList ID = "rblD8" runat="server">
                        <asp:ListItem Value = "1" > 不能接受 </asp:ListItem >
                        <asp:ListItem Value = "2" > 不太能接受 </asp:ListItem >
                        <asp:ListItem Value = "3" > 一般般 </asp:ListItem >
                        <asp:ListItem Value = "4" > 可以接受 </asp:ListItem >
                        <asp:ListItem Value = "5" > 完全能接受 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD8" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--4.9--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Labep48" runat="server" Text="9. 您对于室友使用个人物品的接受程度如个人外衣（外套、外裤、卫衣等）"></asp:Label >
                        <asp:RadioButtonList ID = "rblD9" runat="server">
                        <asp:ListItem Value = "1" > 不能接受 </asp:ListItem >
                        <asp:ListItem Value = "2" > 不太能接受 </asp:ListItem >
                        <asp:ListItem Value = "3" > 一般般 </asp:ListItem >
                        <asp:ListItem Value = "4" > 可以接受 </asp:ListItem >
                        <asp:ListItem Value = "5" > 完全能接受 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD9" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--4.10--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Lael99" runat="server" Text="10. 您对于室友使用个人物品的接受程度如个人内衣（袜子、背心等）"></asp:Label >
                        <asp:RadioButtonList ID = "rblD10" runat="server">
                        <asp:ListItem Value = "1" > 不能接受 </asp:ListItem >
                        <asp:ListItem Value = "2" > 不太能接受 </asp:ListItem >
                        <asp:ListItem Value = "3" > 一般般 </asp:ListItem >
                        <asp:ListItem Value = "4" > 可以接受 </asp:ListItem >
                        <asp:ListItem Value = "5" > 完全能接受 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD10" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--4.11--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Labe54" runat="server" Text="11. 您对于室友使用个人物品的接受程度如护肤品、化妆品（水乳面霜、口红、粉底液等）"></asp:Label >
                        <asp:RadioButtonList ID = "rblD11" runat="server">
                        <asp:ListItem Value = "1" > 不能接受 </asp:ListItem >
                        <asp:ListItem Value = "2" > 不太能接受 </asp:ListItem >
                        <asp:ListItem Value = "3" > 一般般 </asp:ListItem >
                        <asp:ListItem Value = "4" > 可以接受 </asp:ListItem >
                        <asp:ListItem Value = "5" > 完全能接受 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD11" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--4.12--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Labe68" runat="server" Text="12. 您出门（不在宿舍）的频率"></asp:Label >
                        <asp:RadioButtonList ID = "rblD12" runat="server">
                        <asp:ListItem Value = "1" > 基本不出门 </asp:ListItem >
                        <asp:ListItem Value = "2" > 偶尔出门 </asp:ListItem >
                        <asp:ListItem Value = "3" > 一般 </asp:ListItem >
                        <asp:ListItem Value = "4" > 比较经常出门 </asp:ListItem >
                        <asp:ListItem Value = "5" > 经常出门 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgD12" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div>
                        </div >



                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                        <asp:Button ID="btLastMain1D" runat="server" Text="上一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btLastMain1D_Click" />
                                &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btMain1D" runat="server" Text="下一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btMain1D_Click" />
                                </div>
                            </div>
                    </asp:Panel>
                    
                    <asp:Panel ID="plE" runat="server" Visible="False">
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label66" runat="server" Text="五、	消费倾向" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>

                        <%--5.1--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Label56" runat="server" Text="1. 您每月的可支配收入"></asp:Label >
                        <asp:RadioButtonList ID = "rblE1" runat="server">
                        <asp:ListItem Value = "1" > 低于1000元 </asp:ListItem >
                        <asp:ListItem Value = "2" > 1000元-1500元 </asp:ListItem >
                        <asp:ListItem Value = "3" > 1500 - 2000元 </asp:ListItem >
                        <asp:ListItem Value = "4" > 2000 - 3000元 </asp:ListItem >
                        <asp:ListItem Value = "5" > 高于3000元 </asp:ListItem >
                        </asp:RadioButtonList >
                        <asp:Label ID = "lbMsgE1" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <%--5.2--%>
                        <div class= "manage-main2-step1-1" >
                        <div class= "manage-main2-step1" >
                        <asp:Label ID = "Label60" runat="server" Text="2. 您的日常消费比重(请选择前四项，不分先后向顺序)"></asp:Label >
                        <asp:CheckBoxList ID="cblE2" runat="server">
                        <asp:ListItem Value = "1" > 餐饮美食 </asp:ListItem >
                        <asp:ListItem Value = "2" > 娱乐休闲 </asp:ListItem >
                        <asp:ListItem Value = "3" > 日用百货 </asp:ListItem >
                        <asp:ListItem Value = "4" > 服饰装扮 </asp:ListItem >
                        <asp:ListItem Value = "5" > 教育培训 </asp:ListItem >
                        </asp:CheckBoxList>
                        <asp:Label ID = "lbMsgE2" runat="server" Text="" ForeColor="Red"></asp:Label >
                        </div >
                        </div >

                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                        <asp:Button ID="btLastMain1E" runat="server" Text="上一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btLastMain1E_Click" />
                                &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btMain1E" runat="server" Text="下一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btMain1E_Click" />
                                </div>
                            </div>
                    </asp:Panel>
                    <asp:Panel ID="plF" runat="server" Visible="False">
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label67" runat="server" Text="六、	个人爱好" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>

                <%--6.1--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label63" runat="server" Text="1. 您对声乐演唱与欣赏的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF1" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.2--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label69" runat="server" Text="2. 您对乐器演奏的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF2" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF2" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.3--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label70" runat="server" Text="3. 您对舞蹈表演与欣赏的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF3" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF3" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.4--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label72" runat="server" Text="4. 您对绘画的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF4" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF4" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.5--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label74" runat="server" Text="5. 您对书法的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF5" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF5" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.6--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label76" runat="server" Text="6. 您对足球、篮球、排球的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF6" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF6" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.7--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label78" runat="server" Text="7. 您对乒乓球、羽毛球、网球的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF7" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF7" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.8--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label80" runat="server" Text="8. 您对田径、长跑、短跑的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF8" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF8" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.9--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label82" runat="server" Text="9. 您对撸铁、器械健身的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF9" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF9" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.10--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label84" runat="server" Text="10. 您对瑜伽的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF10" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF10" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <%--6.11--%>
                <div class="manage-main2-step1-1">
                    <div class="manage-main2-step1">
                        <asp:Label ID="Label86" runat="server" Text="11. 您对游泳的喜好程度"></asp:Label>
                        <asp:RadioButtonList ID="rblF11" runat="server">
                            <asp:ListItem Value="1">完全不感兴趣</asp:ListItem>
                            <asp:ListItem Value="2">不太感兴趣</asp:ListItem>
                            <asp:ListItem Value="3">一般般</asp:ListItem>
                            <asp:ListItem Value="4">比较感兴趣</asp:ListItem>
                            <asp:ListItem Value="5">非常感兴趣</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="lbMsgF11" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                        
<%--6.12--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label71" runat="server" Text="12.您对看电影、电视剧、综艺节目的喜好程度"></asp:Label>
<asp:RadioButtonList ID="rblF12" runat="server">
 <asp:ListItem Value="1">非常感兴趣</asp:ListItem>
 <asp:ListItem Value="2">比较感兴趣</asp:ListItem>
 <asp:ListItem Value="3">一般般</asp:ListItem>
  <asp:ListItem Value="4">不太感兴趣</asp:ListItem>
 <asp:ListItem Value="5">完全不感兴趣</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgF12" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>



<%--6.13--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label73" runat="server" Text="13.您对听现场嘻哈音乐、摇滚乐的喜好程度"></asp:Label>
<asp:RadioButtonList ID="rblF13" runat="server">
 <asp:ListItem Value="1">非常感兴趣</asp:ListItem>
 <asp:ListItem Value="2">比较感兴趣</asp:ListItem>
 <asp:ListItem Value="3">一般般</asp:ListItem>
  <asp:ListItem Value="4">不太感兴趣</asp:ListItem>
 <asp:ListItem Value="5">完全不感兴趣</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgF13" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>

<%--6.14--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label75" runat="server" Text="14.您对欣赏古典乐的喜好程度"></asp:Label>
<asp:RadioButtonList ID="rblF14" runat="server">
 <asp:ListItem Value="1">非常感兴趣</asp:ListItem>
 <asp:ListItem Value="2">比较感兴趣</asp:ListItem>
 <asp:ListItem Value="3">一般般</asp:ListItem>
  <asp:ListItem Value="4">不太感兴趣</asp:ListItem>
 <asp:ListItem Value="5">完全不感兴趣</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgF14" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>


<%--6.15--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label77" runat="server" Text="15.您对追星打榜的喜好程度"></asp:Label>
<asp:RadioButtonList ID="rblF15" runat="server">
 <asp:ListItem Value="1">非常感兴趣</asp:ListItem>
 <asp:ListItem Value="2">比较感兴趣</asp:ListItem>
 <asp:ListItem Value="3">一般般</asp:ListItem>
  <asp:ListItem Value="4">不太感兴趣</asp:ListItem>
 <asp:ListItem Value="5">完全不感兴趣</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgF15" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>

<%--6.16--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label79" runat="server" Text="16.您对去KTV唱歌的喜好程度"></asp:Label>
<asp:RadioButtonList ID="rblF16" runat="server">
 <asp:ListItem Value="1">非常感兴趣</asp:ListItem>
 <asp:ListItem Value="2">比较感兴趣</asp:ListItem>
 <asp:ListItem Value="3">一般般</asp:ListItem>
  <asp:ListItem Value="4">不太感兴趣</asp:ListItem>
 <asp:ListItem Value="5">完全不感兴趣</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgF16" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>


                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                        <asp:Button ID="btLastMain1F" runat="server" Text="上一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btLastMain1F_Click" />
                                &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btMain1F" runat="server" Text="下一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btMain1F_Click" />
                                </div>
                            </div>
                    </asp:Panel>
                    <asp:Panel ID="plG" runat="server" Visible="False">
                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                                <asp:Label ID="Label68" runat="server" Text="七、	个性化习惯" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>

                        <%--7.1--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label81" runat="server" Text="1.您的性取向是？"></asp:Label>
<asp:RadioButtonList ID="rblG1" runat="server">
 <asp:ListItem Value="1">同性恋</asp:ListItem>
 <asp:ListItem Value="2">双性恋</asp:ListItem>
 <asp:ListItem Value="3">异性恋</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgG1" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>


<%--7.2--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label83" runat="server" Text="2.您是否有男/女朋友"></asp:Label>
<asp:RadioButtonList ID="rblG2" runat="server">
 <asp:ListItem Value="1">是</asp:ListItem>
 <asp:ListItem Value="2">否</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgG2" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>


<%--7.3--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label85" runat="server" Text="3.您是否曾患过传染病（包括已治愈）？ "></asp:Label>
<asp:RadioButtonList ID="rblG3" runat="server">
 <asp:ListItem Value="1">是</asp:ListItem>
 <asp:ListItem Value="2">否</asp:ListItem>
 </asp:RadioButtonList>
 <asp:Label ID="lbMsgG3" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>

<%--7.4--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label87" runat="server" Text="4.您的家庭种类 "></asp:Label>
<asp:RadioButtonList ID="rblG4" runat="server">
 <asp:ListItem Value="1">原生家庭</asp:ListItem>
 <asp:ListItem Value="2">离异家庭（父母离异）</asp:ListItem>
<asp:ListItem Value="3">单亲家庭（一方亲属逝世）</asp:ListItem>
 <asp:ListItem Value="4">重组家庭</asp:ListItem>

 </asp:RadioButtonList>
 <asp:Label ID="lbMsgG4" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>


<%--7.5--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label88" runat="server" Text="5.您认为您父母（监护人）的教养方式 "></asp:Label>
<asp:RadioButtonList ID="rblG5" runat="server">
 <asp:ListItem Value="1">权威型</asp:ListItem>
 <asp:ListItem Value="2">专制型</asp:ListItem>
<asp:ListItem Value="3">溺爱型</asp:ListItem>
 <asp:ListItem Value="4">忽视型</asp:ListItem>

 </asp:RadioButtonList>
 <asp:Label ID="lbMsgG5" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>

<%--7.6--%>
 <div class="manage-main2-step1-1">
 <div class="manage-main2-step1">
 <asp:Label ID="Label89" runat="server" Text="6.您与人交往的能力 "></asp:Label>
<asp:RadioButtonList ID="rblG6" runat="server">
 <asp:ListItem Value="1">十分擅长</asp:ListItem>
 <asp:ListItem Value="2">比较擅长</asp:ListItem>
<asp:ListItem Value="3">一般擅长</asp:ListItem>
 <asp:ListItem Value="4">不太擅长</asp:ListItem>
 <asp:ListItem Value="5">很不擅长</asp:ListItem>

 </asp:RadioButtonList>
 <asp:Label ID="lbMsgG6" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>


                        <div class="manage-main2-step1-1-title">
                            <div class="manage-main2-step1">
                        <asp:Button ID="btLastMain1G" runat="server" Text="上一部分" Height="38px" Width="120px" Font-Size="Large" OnClick="btLastMain1G_Click" />
                          &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btMain1G" runat="server" Text="确定" Height="38px" Width="120px" Font-Size="Large" OnClick="btMain1G_Click" />
                                </div>
                            </div>
                    </asp:Panel>

                </div>
                         </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="main2" class="main" style="display: none">
                <div class="c1">
                    <asp:Label ID="Label4" runat="server" Text="分配结果" Font-Bold="True"></asp:Label>
                </div>
                <div class="contain">
                    <div class="c2">
                        <div class="d2">
                            <asp:Panel ID="Panel1" runat="server" Visible="False">
                                <table style="border-collapse: collapse; border: none; margin-left: 15px;">
                                    <tr>
                                        <td style="height: 75px; text-align: right;">楼宇：
                                        </td>
                                        <td>
                                            <div class="d1">
                                                <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 75px; text-align: right;">楼层：
                                        </td>
                                        <td>
                                            <div class="d1">
                                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 75px; text-align: right;">寝号：
                                        </td>
                                        <td>
                                            <div class="d1">
                                                <asp:Label ID="Label8" runat="server" Text="605"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 75px; text-align: right;">室友：
                                        </td>
                                        <td>
                                            <div class="d1">
                                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label><br />
                                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label><br />
                                                <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>
                            <asp:Label ID="Label19" runat="server" Text="还未进行分配，请等待！" Visible="False"></asp:Label>
                            <asp:Label ID="Label20" runat="server" Text="还未发布，请等待！"></asp:Label>
                            <asp:Label ID="Label49" runat="server" Text="您还没有填写信息，请尽快填写！" Visible="False"></asp:Label>

                        </div>
                    </div>
                </div>
            </div>

            <div id="main3" class="main" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label5" runat="server" Text="申请记录" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <div class="c3">
                                <asp:Panel ID="Panel9" runat="server">
                                    <div id="cList" style="display: block">
                                        <div class="cButton">
                                            <asp:Button ID="clbNew2" runat="server" Text="新建" OnClick="clbNew2_Click" />
                                        </div>

                                        <asp:Panel ID="Panel2" runat="server">
                                            <div class="main1-ul1">
                                                <ul class="">
                                                    <li style="width: 120px;">学院</li>
                                                    <li style="width: 120px;">班级</li>
                                                    <li style="width: 120px;">姓名</li>
                                                    <li style="width: 120px;">学号</li>
                                                    <li style="width: 90px;">性别</li>
                                                    <li style="width: 220px;">申请时间</li>
                                                    <li style="width: 100px;">申请类型</li>
                                                    <li style="width: 120px;">信息状态</li>
                                                    <li style="width: 120px;">回复状态</li>
                                                </ul>
                                            </div>
                                            <div class="main1-ul2">
                                                <asp:ListView ID="lvEverApply" runat="server" OnItemDataBound="lvEverApply_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="cb">
                                                            <ul>
                                                                <li style="width: 120px;">
                                                                    <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("College") %>'></asp:Label>
                                                                </li>
                                                                <li style="width: 120px;">
                                                                    <asp:Label ID="lbMajor" runat="server" Text='<%#Eval("Major") %>'></asp:Label></li>
                                                                <li style="width: 120px;">
                                                                    <asp:Label ID="lbSex" runat="server" Text='<%#Eval("Name") %>'></asp:Label></li>
                                                                <li style="width: 120px;">
                                                                    <asp:Label ID="Label34" runat="server" Text='<%#Eval("StudentNumber") %>'></asp:Label></li>
                                                                <li style="width: 90px;">
                                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Sex") %>'></asp:Label>
                                                                </li>
                                                                <li style="width: 220px;">
                                                                    <asp:Label ID="Label18" runat="server" Text='<%#Eval("Time") %>'></asp:Label>
                                                                </li>

                                                                <li style="width: 100px;">
                                                                    <asp:Label ID="lbIdentity" runat="server" Text='<%#Eval("Type") %>'></asp:Label></li>
                                                                <li style="width: 120px;">
                                                                    <asp:Label ID="lbRead" runat="server" Text='<%#Eval("Read") %>'></asp:Label></li>
                                                                <li style="width: 120px;">
                                                                    <asp:LinkButton ID="lbRContent" runat="server" OnCommand="lbtn_GoodDetail" CommandName="SeeReply" CommandArgument='<%#Eval("MID") %>' Text='<%#Eval("reContent") %>'></asp:LinkButton>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                        <div class="cb"></div>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                        </asp:Panel>

                                        <asp:Panel ID="Panel3" runat="server" Visible="False">
                                            <div class="d2">
                                                <br />
                                                <br />
                                                <asp:Label ID="Label21" runat="server" Text="尚未发送过任何信息！" Font-Size="Large"></asp:Label>
                                            </div>
                                        </asp:Panel>

                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel10" runat="server" Visible="False">
                                    <div id="cNew">

                                        <table style="border-collapse: collapse; border: none; margin-left: 15px;">
                                            <tr>
                                                <td style="height: 75px; text-align: right;">姓名：
                                                </td>
                                                <td>
                                                    <div class="cOne">
                                                        <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 75px; text-align: right;">身份证号：
                                                </td>
                                                <td>
                                                    <div class="cOne">
                                                        <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 75px; text-align: right;">调换原因：
                                                </td>
                                                <td>
                                                    <div class="main-tbox">
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                        <asp:Label ID="Label16" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 75px; text-align: right;">申请类型：
                                                </td>
                                                <td>
                                                    <div class="main-tbox">
                                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                                            <asp:ListItem>床位调换</asp:ListItem>
                                                            <asp:ListItem>楼层调换</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 75px; text-align: right;">具体内容：
                                                </td>
                                                <td>
                                                    <div class="main-tbox">
                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                        <asp:Label ID="Label17" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>

                                        <div class="cButton2">
                                            <asp:Button ID="clbBack2" runat="server" Text="返回" OnClick="clbBack2_Click" />
                                        </div>
                                        <asp:Button ID="btnConfirm" runat="server" Text="确定" OnClick="btnConfirm_Click" />

                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="main4" class="main" style="display: none">
                <div class="c1">
                    <asp:Label ID="Label6" runat="server" Text="其它通知" Font-Bold="True"></asp:Label>
                </div>
                <div class="contain">
                    <div class="c2">
                        <div class="manage-main4-step1-1">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/FileImg/a.jpg" Width="770px" Height="150px" />
                            <div class="main4-down">
                                <asp:Button ID="btnDown" runat="server" Text="点击下载" Height="38px" Width="120px" Font-Size="Large" OnClick="btnDown_Click1" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="main5" class="main" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label15" runat="server" Text="收件箱" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <asp:Panel ID="Panel7" runat="server">
                                <div class="main5-ul1">
                                    <ul class="">
                                        <li style="width: 120px;">发送人</li>
                                        <li style="width: 200px;">发送时间</li>
                                        <li style="width: 80px;">状态</li>
                                    </ul>
                                </div>
                                <div class="main5-ul2">
                                    <asp:ListView ID="lvMes" runat="server">

                                        <ItemTemplate>
                                            <div class="cb">
                                                <ul>
                                                    <li style="width: 120px;">
                                                        <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("College") %>'></asp:Label>
                                                    </li>
                                                    <li style="width: 200px; text-align: left;">
                                                        <asp:Label ID="lbClass" runat="server" Text='<%#Eval("Time") %>'></asp:Label></li>
                                                    <li style="width: 80px;">
                                                        <asp:Label ID="lbRead" runat="server" Text='<%#Eval("Read") %>'></asp:Label></li>
                                                    <li style="width: 80px;">
                                                        <asp:Label ID="lbReContent" runat="server" Text='<%#Eval("reContent") %>'></asp:Label></li>
                                                    <li style="width: 80px;">
                                                        <asp:LinkButton ID="lbSendUrge" runat="server" OnCommand="lbtn_GoodDetail" CommandName="SeeCotent" CommandArgument='<%#Eval("MID") %>' Text="查看"></asp:LinkButton>
                                                    </li>
                                                    <li style="width: 80px;">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="lbtn_GoodDetail" CommandName="Delect" CommandArgument='<%#Eval("MID") %>' Text="删除"></asp:LinkButton>

                                                    </li>
                                                    <li style="width: 80px;">
                                                        <asp:LinkButton ID="lbRContent" runat="server" OnCommand="lbtn_GoodDetail" CommandName="Reply" CommandArgument='<%#Eval("MID") %>' Text="回复"></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel8" runat="server" Visible="False" Font-Size="Larger">
                                <div class="main5-send">
                                    <br />
                                    <br />
                                    <asp:TextBox ID="tbRecontent" runat="server" Height="240px" Width="400px" Font-Size="Larger" TextMode="MultiLine"></asp:TextBox>
                                    <asp:Button ID="Button11" runat="server" Text="确认发送" OnClick="Button11_Click" />
                                    <asp:Button ID="Button12" runat="server" Text="返回" OnClick="Button12_Click" />
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel11" runat="server" Visible="False">
                                <div class="d2">
                                    <br />
                                    <br />
                                    <asp:Label ID="Label38" runat="server" Text="尚未收到任何信息！" Font-Size="Large"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="right1" class="right" style="display: none">


                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label22" runat="server" Text="个人信息" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <div class="c2">
                                <div class="d2">
                                    <div class="right1-content">
                                        <asp:ListView ID="ListView1" runat="server">
                                            <ItemTemplate>
                                                <br />
                                                <asp:Label ID="lbName1" runat="server" Text="姓名："></asp:Label>
                                                <asp:Label ID="lbName" runat="server" Text='<%#Eval("Name") %>'></asp:Label><br />
                                                <br />

                                                <asp:Label ID="lbType1" runat="server" Text="性别："></asp:Label>
                                                <asp:Label ID="lbType" runat="server" Text='<%#Eval("Sex") %>'></asp:Label><br />
                                                <br />

                                                <asp:Label ID="lbIdentity1" runat="server" Text="身份证号："></asp:Label>
                                                <asp:Label ID="lbIdentity" runat="server" Text='<%#Eval("Identity") %>'></asp:Label><br />
                                                <br />

                                                <asp:Label ID="Label30" runat="server" Text="邮箱："></asp:Label>
                                                <asp:Label ID="Label31" runat="server" Text='<%#Eval("Email") %>'></asp:Label><br />
                                                <br />

                                                <asp:Label ID="Label28" runat="server" Text="学号："></asp:Label>
                                                <asp:Label ID="Label29" runat="server" Text='<%#Eval("StudentNumber") %>'></asp:Label><br />
                                                <br />

                                                <asp:Label ID="lbCollege1" runat="server" Text="学院："></asp:Label>
                                                <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("College") %>'></asp:Label><br />
                                                <br />

                                                <asp:Label ID="lbJobNumber1" runat="server" Text="班级："></asp:Label>
                                                <asp:Label ID="lbJobNumber" runat="server" Text='<%#Eval("Major") %>'></asp:Label><br />
                                                <br />


                                                <asp:Label ID="lbPhone1" runat="server" Text="联系方式："></asp:Label>
                                                <asp:Label ID="lbPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label><br />
                                                <br />



                                            </ItemTemplate>
                                        </asp:ListView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

            <div id="right2" class="right" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label23" runat="server" Text="修改密码" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <asp:Panel ID="Panel4" runat="server">
                                <div class="right2-set">
                                    <br />
                                    <asp:Label ID="Label24" runat="server" Text="原密码："></asp:Label>&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="tbOldPwd" runat="server"></asp:TextBox><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lbMsgOldPwd" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                                    <br />

                                    <asp:Label ID="Label25" runat="server" Text="新密码："></asp:Label>&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="tbNewPwd" runat="server"></asp:TextBox><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lbMsgNewPwd" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                                    <br />

                                    <asp:Label ID="Label26" runat="server" Text="确认密码："></asp:Label>
                                    <asp:TextBox ID="tbNewPwd2" runat="server"></asp:TextBox><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lbMsgNewPwd2" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                                    <br />

                                    <asp:Button ID="Button10" runat="server" Text="确定" OnClick="Button10_Click" />
                                    <asp:Label ID="lbMsgUpdatePwd" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel5" runat="server" Visible="False">
                                <div class="d2">
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label32" runat="server" Text="您还未设置密码!"></asp:Label><br />
                                    <br />
                                    <asp:Button ID="Button1" runat="server" Text="设置密码" OnClick="Button1_Click" />
                                </div>
                            </asp:Panel>


                            <asp:Panel ID="Panel6" runat="server" Visible="False">
                                <div class="right2-exchage">
                                    <br />
                                    <asp:Label ID="Label36" runat="server" Text="邮箱："></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="" autocomplete="off"></asp:TextBox><br />
                                    <%--对邮箱输入格式进行限制--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="输入有误" ControlToValidate="txtEmail" ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:Label ID="lbMsgEmail" runat="server" Text=""></asp:Label><br />
                                    <br />

                                    <asp:Label ID="Label37" runat="server" Text="验证码："></asp:Label>&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtCode" runat="server" autocomplete="off"></asp:TextBox>
                                    <asp:Button ID="btnSendCode" runat="server" Text="发送验证码" OnClick="btnSendCode_Click" />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lbMsgCode" runat="server" Text="" ForeColor="Red"></asp:Label>




                                    <asp:Label ID="lbMsgSendCode" runat="server" Text=""></asp:Label><br />
                                    <br />


                                    <asp:Label ID="Label33" runat="server" Text="密码："></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="tbSetPwd" runat="server"></asp:TextBox><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbMsgSetPwd" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                                    <br />

                                    <asp:Label ID="Label35" runat="server" Text="确认密码："></asp:Label>
                                    <asp:TextBox ID="tbSetPwd2" runat="server"></asp:TextBox><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbMsgSetPwd2" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                                    <br />

                                    <asp:Button ID="Button2" runat="server" Text="确认" OnClick="Button2_Click" />
                                </div>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="right3" class="right" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label27" runat="server" Text="退出" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <div class="c2">
                                <div></div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
