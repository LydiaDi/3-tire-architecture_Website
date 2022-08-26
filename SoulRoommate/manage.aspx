<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="SoulRoommate.manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/manage.css" />
    <script src="JS/jquery(v3.5.1).min.js"></script>
    <script src="JS/manage2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="student-top">
            <div class="student-top-left">
                <asp:Label ID="Label1" runat="server" Text="Admin"></asp:Label>
            </div>
            <div class="student-top-middle">
                <div class="b1">
                    <ul id="ul2">
                        <li style="color: black">查看信息</li>
                        <li>分配结果</li>
                        <li>房间分配</li>
                        <li>发布结果</li>
                    </ul>
                </div>
            </div>
            <div class="student-top-right">
                <div class="student-top-right-img">
                    <asp:Image ID="imgEmail" runat="server" Height="35px" ImageUrl="~/Img/icon/email3.PNG" Width="50px" />
                </div>
                <div id="student-top-right-msgCount">
                    <asp:Label ID="lbMsgCount" runat="server" Text="7" BackColor="#60c1d4" ForeColor="White"></asp:Label>
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
              <%--  <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                <div class="c1">
                    <asp:Label ID="Label3" runat="server" Text="查看信息" Font-Bold="True"></asp:Label>
                </div>
                <div class="contain2">
                    <asp:Panel ID="Panel1" runat="server">
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpInfo" runat="server" Text="上传信息" Height="38px" Width="120px" Font-Size="Large" OnClick="btnUpInfo_Click" />
                        <br />
                        <div class="mange-main1-ul1">
                            <ul class="">
                                <li style="width: 140px;">学院</li>
                                <li style="width: 130px;">专业</li>
                                <li style="width: 70px;">性别</li>
                                <li style="width: 120px;">姓名</li>
                                <li style="width: 230px;">身份证号</li>
                                <li style="width: 230px;">邮箱</li>
                            </ul>
                        </div>
                        <div class="manage-main1ShowInfo-ul2">
                            <asp:ListView ID="lvStudentInfo" runat="server">
                                <ItemTemplate>
                                    <div class="cb">
                                        <ul>
                                            <li style="width: 140px;">
                                                <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("College") %>'></asp:Label>
                                            </li>
                                            <li style="width: 130px;">
                                                <asp:Label ID="lbMajor" runat="server" Text='<%#Eval("Major") %>'></asp:Label></li>
                                            <li style="width: 70px;">
                                                <asp:Label ID="lbSex" runat="server" Text='<%#Eval("Sex") %>'></asp:Label></li>
                                            <li style="width: 120px;">
                                                <asp:LinkButton ID="lbtnDetail" runat="server" OnCommand="lbtn_GoodDetail" CommandName="GoodDetail" CommandArgument='<%#Eval("Identity") %>' Text='<%#Eval("Name") %>'></asp:LinkButton>
                                            </li>
                                            <li style="width: 230px;">
                                                <asp:Label ID="lbIdentity" runat="server" Text='<%#Eval("Identity") %>'></asp:Label></li>
                                            <li style="width: 230px;">
                                                <asp:Label ID="lbEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></li>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="plUpInfo" runat="server" Visible="False">
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnUpInfoBack" runat="server" Text="返回" Height="38px" Width="120px" Font-Size="Large" OnClick="btnUpInfoBack_Click" />
                        <br />
                        <div class="manage-main1Up-step1-1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label53" runat="server" Text="提示："></asp:Label><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label54" runat="server" Text="请先下载文件，然后按照下载文件的格式输入数据后在进行上传！"></asp:Label>
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="Label57" runat="server" Text="上传文件注意事项："></asp:Label>
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="Label58" runat="server" Text="①请不要修改Excel表中的表单名称，保持其为'Sheet1'）"></asp:Label>
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="Label59" runat="server" Text="②excel表中至少有一条以上的数据（否则第二行会被视为空行进行填充，从而在插入数据时出错）"></asp:Label>
                             
                            <div class="manage-main1Up-step1">
                                <asp:Label ID="Label55" runat="server" Text="下载文件："></asp:Label><br />
                                <asp:Button ID="btnDown" runat="server" Text="下载标准文件" Height="33px" Width="120px" Font-Size="Large" OnClick="btnDown_Click" /><br /><br />

                                <asp:Label ID="Label56" runat="server" Text="上传文件："></asp:Label><br />
                                <asp:FileUpload ID="ExcelFileUpload" runat="server" Height="33px" Width="120px" Font-Size="Large" /><br />
                                <asp:Button ID="UploadBtn" runat="server" Text="确定上传" OnClick="UploadBtn_Click" Height="33px" Width="90px" Font-Size="Large" />

                            </div>

                        </div>
                        <div class="manage-main1Grid-step1-1">
                            <asp:GridView ID="gvInfo" runat="server"></asp:GridView>
                        </div>

                    </asp:Panel>

                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                        <%-- 1--%>
                        <div>
                            <asp:Button ID="Button5" runat="server" Text="返回" OnClick="Button5_Click" />
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class="manage-main1-ul1">


                            <ul class="">
                                <li style="width: 120px;">姓名</li>
                                <li style="width: 40px;">性别</li>
                                <li style="width: 130px;">A1sleepTime </li>
                                <li style="width: 130px;">A2upTime </li>
                                <li style="width: 130px;">A3noonNap </li>
                                <li style="width: 140px;">A4averageTime </li>
                                <li style="width: 140px;">A5sleepQuality </li>
                                <li style="width: 130px;">A6snore </li>
                                <li style="width: 130px;">B1fitCold </li>
                                <li style="width: 130px;">B2fitHot </li>

                            </ul>
                        </div>
                        <div class="manage-main1-ul2">
                            <asp:ListView ID="lvStudentGoodDetail" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <ul>
                                            <li style="width: 120px;">
                                                <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                            </li>
                                            <li style="width: 40px;">
                                                <asp:Label ID="lbMajor" runat="server" Text='<%#Eval("Sex") %>'></asp:Label></li>
                                            <li style="width: 130px;">
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("A1sleepTime") %>'></asp:Label></li>
                                            <li style="width: 130px;">
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("A2upTime") %>'></asp:Label></li>
                                            <li style="width: 130px;">
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("A3noonNap") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("A4averageTime") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("A5sleepQuality") %>'></asp:Label></li>
                                            <li style="width: 130px;">
                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("A6snore") %>'></asp:Label></li>
                                            <li style="width: 130px;">
                                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("B1fitCold") %>'></asp:Label></li>
                                            <li style="width: 130px;">

                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("B2fitHot") %>'></asp:Label></li>
                                        </ul>

                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                        </div>
                        <%-- 2--%>
                        <div class="manage-main1-ul1">
                            <ul class="">
                                <li style="width: 190px;">B3airCon </li>
                                <li style="width: 140px;">B4minTem </li>
                                <li style="width: 140px;">B5maxTem </li>
                                <li style="width: 140px;">C1shower </li>
                                <li style="width: 140px;">C2cleanDesk </li>
                                <li style="width: 140px;">C3cleanRubbish </li>
                                <li style="width: 140px;">C4makeBed </li>
                                <li style="width: 140px;">C5washCloth </li>


                            </ul>
                        </div>
                        <div class="manage-main1-ul2">
                            <asp:ListView ID="ListView2" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <ul>
                                            <li style="width: 190px;">
                                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("B3airCon") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("B4minTem") %>'></asp:Label></li>

                                            <li style="width: 140px;">
                                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("B5maxTem") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("C1shower") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("C2cleanDesk") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("C3cleanRubbish") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label15" runat="server" Text='<%#Eval("C4makeBed") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label16" runat="server" Text='<%#Eval("C5washCloth") %>'></asp:Label></li>

                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <%-- 3--%>
                        <div class="manage-main1-ul1">
                            <ul class="">
                                <li style="width: 190px;">D1smoke </li>
                                <li style="width: 140px;">D2game </li>
                                <li style="width: 140px;">D3volume </li>
                                <li style="width: 140px;">D4express </li>
                                <li style="width: 140px;">D5coConsum </li>
                                <li style="width: 140px;">D6elec </li>
                                <li style="width: 140px;">D7con </li>
                                <li style="width: 140px;">D8unCon </li>



                            </ul>
                        </div>
                        <div class="manage-main1-ul2">
                            <asp:ListView ID="ListView3" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <ul>
                                            <li style="width: 190px;">
                                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("D1smoke") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("D2game") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label19" runat="server" Text='<%#Eval("D3volume") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label20" runat="server" Text='<%#Eval("D4express") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label21" runat="server" Text='<%#Eval("D5coConsum") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label22" runat="server" Text='<%#Eval("D6elec") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label23" runat="server" Text='<%#Eval("D7con") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label24" runat="server" Text='<%#Eval("D8unCon") %>'></asp:Label></li>


                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <%--4--%>
                        <div class="manage-main1-ul1">
                            <ul class="">
                                <li style="width: 190px;">D9coat </li>
                                <li style="width: 140px;">D10uWear </li>
                                <li style="width: 140px;">D11maq </li>
                                <li style="width: 140px;">D12outSide </li>
                                <li style="width: 140px;">E1income </li>
                                <li style="width: 140px;">E2perConsum </li>
                                <li style="width: 140px;">F1sing </li>
                                <li style="width: 140px;">F2musIns </li>




                            </ul>
                        </div>
                        <div class="manage-main1-ul2">
                            <asp:ListView ID="ListView4" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <ul>
                                            <li style="width: 190px;">
                                                <asp:Label ID="Label25" runat="server" Text='<%#Eval("D9coat") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label26" runat="server" Text='<%#Eval("D10uWear") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label27" runat="server" Text='<%#Eval("D11maq") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label28" runat="server" Text='<%#Eval("D12outSide") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label29" runat="server" Text='<%#Eval("E1income") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label30" runat="server" Text='<%#Eval("E2perConsum") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label31" runat="server" Text='<%#Eval("F1sing") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label32" runat="server" Text='<%#Eval("F2musIns") %>'></asp:Label></li>

                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <%--5--%>
                        <div class="manage-main1-ul1">
                            <ul class="">
                                <li style="width: 190px;">F3dance </li>
                                <li style="width: 140px;">F4draw </li>
                                <li style="width: 140px;">F5white </li>
                                <li style="width: 140px;">F6ball </li>
                                <li style="width: 140px;">F7tennis </li>
                                <li style="width: 140px;">F8run </li>
                                <li style="width: 140px;">F9bodyBuild </li>
                                <li style="width: 140px;">F10yoga </li>

                            </ul>
                        </div>
                        <div class="manage-main1-ul2">
                            <asp:ListView ID="ListView5" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <ul>
                                            <li style="width: 190px;">
                                                <asp:Label ID="Label33" runat="server" Text='<%#Eval("F3dance") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label34" runat="server" Text='<%#Eval("F4draw") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label35" runat="server" Text='<%#Eval("F5white") %>'></asp:Label></li>

                                            <li style="width: 140px;">
                                                <asp:Label ID="Label36" runat="server" Text='<%#Eval("F6ball") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label37" runat="server" Text='<%#Eval("F7tennis") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label38" runat="server" Text='<%#Eval("F8run") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label39" runat="server" Text='<%#Eval("F9bodyBuild") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label40" runat="server" Text='<%#Eval("F10yoga") %>'></asp:Label></li>


                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <%--6--%>
                        <div class="manage-main1-ul1">
                            <ul class="">

                                <li style="width: 190px;">F11swim </li>
                                <li style="width: 140px;">F12movie </li>
                                <li style="width: 140px;">F13live </li>
                                <li style="width: 140px;">F14claMusic </li>
                                <li style="width: 140px;">F15idol </li>
                                <li style="width: 140px;">F16ktv </li>
                                <li style="width: 140px;">G1sexOrient </li>
                                <li style="width: 140px;">G2noSingle </li>



                            </ul>
                        </div>
                        <div class="manage-main1-ul2">
                            <asp:ListView ID="ListView6" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <ul>
                                            <li style="width: 190px;">
                                                <asp:Label ID="Label41" runat="server" Text='<%#Eval("F11swim") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label42" runat="server" Text='<%#Eval("F12movie") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label43" runat="server" Text='<%#Eval("F13live") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label44" runat="server" Text='<%#Eval("F14claMusic") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label45" runat="server" Text='<%#Eval("F15idol") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label46" runat="server" Text='<%#Eval("F16ktv") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label47" runat="server" Text='<%#Eval("G1sexOrient") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label48" runat="server" Text='<%#Eval("G2noSingle") %>'></asp:Label></li>

                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>

                        <%--7--%>
                        <div class="manage-main1-ul1">
                            <ul class="">

                                <li style="width: 190px;">G3inDisea </li>
                                <li style="width: 140px;">G4family </li>
                                <li style="width: 140px;">G5parent </li>
                                <li style="width: 140px;">G6interact </li>


                            </ul>
                        </div>
                        <div class="main1-ul2">
                            <asp:ListView ID="ListView7" runat="server">
                                <ItemTemplate>
                                    <div class="">
                                        <ul>
                                            <li style="width: 190px;">
                                                <asp:Label ID="Label49" runat="server" Text='<%#Eval("G3inDisea") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label50" runat="server" Text='<%#Eval("G4family") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label51" runat="server" Text='<%#Eval("G5parent") %>'></asp:Label></li>
                                            <li style="width: 140px;">
                                                <asp:Label ID="Label52" runat="server" Text='<%#Eval("G6interact") %>'></asp:Label></li>

                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </asp:Panel>
                </div>
                        <%--</ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="UploadBtn" />
                        <asp:PostBackTrigger ControlID="btnDown" />
                </Triggers>
                </asp:UpdatePanel>--%>

            </div>

            <div id="main2" class="main" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label4" runat="server" Text="分配结果" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain2">
                            <asp:Panel ID="plManageMain2" runat="server">
                                <div class="main2-a">
                                    <div class="manage-main2-step1-1">
                                        <div class="manage-main2-step1">
                                            <div class="main2-a1">

                                                <asp:Label ID="Label7" runat="server" Text="一、选择要进行分配的班级"></asp:Label>


                                            </div>
                                            <br />
                                            <div>
                                                <%--<asp:CheckBoxList ID="cbClass" runat="server" OnSelectedIndexChanged="cbClass_SelectedIndexChanged"></asp:CheckBoxList>--%>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="信管1808" ValidationGroup="a" Visible="False" />
                                                <asp:CheckBox ID="CheckBox2" runat="server" Text="信管1807" ValidationGroup="a" Visible="False" />
                                                <asp:CheckBox ID="CheckBox3" runat="server" Text="营销1801" ValidationGroup="a" Visible="False" />
                                                <asp:Panel ID="Panel5" runat="server">
                                                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="b" Text="信管1808" AutoPostBack="True" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="b" Text="信管1807" AutoPostBack="True" />
                                                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="b" Text="营销1801" AutoPostBack="True" />
                                                </asp:Panel>
                                            </div>
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="确认信息" OnClick="Button1_Click" Height="38px" Width="120px" Font-Size="Large" />
                                            <br />
                                            <asp:Label ID="Label11" runat="server" Text=""></asp:Label><br />
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnStep2" runat="server">
                                        <div class="manage-main2-step2-1">
                                            <div class="manage-main2-step2">
                                                <div class="main2-a1">
                                                    <asp:Label ID="Label8" runat="server" Text="二、查询信息是否完整"></asp:Label>
                                                </div>
                                                <%--查询已选班级信息填写情况--%><br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" Text="点击查询" OnClick="Button2_Click" Enabled="False" Height="38px" Width="120px" Font-Size="Large" />
                                                <br /><br />
                                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
                                                <asp:Label ID="lbMsgAssignAgain" runat="server" Text=""></asp:Label><br /><br />
                                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnAssignAgain" runat="server" Text="是" OnClick="btnAssignAgain_Click" Visible="False" Height="38px" Width="60px" Font-Size="Large"/>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnNotAssignAgain" runat="server" Text="否" OnClick="btnNotAssignAgain_Click" Visible="False" Height="38px" Width="60px" Font-Size="Large"/>
                                            </div>
                                        </div>
                                    </asp:Panel>

                                    <asp:Panel ID="pnStep3" runat="server">
                                        <div class="manage-main2-step3-1">
                                            <div class="manage-main2-step3">
                                                <div class="main2-a1">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label10" runat="server" Text="三、进行分配"></asp:Label><br />
                                                    <br />
                                                    <asp:Label ID="Label14" runat="server" Text="男生："></asp:Label>
                                                    <asp:Button ID="Button4" runat="server" Text="分配前准备工作" OnClick="Button4_Click" Enabled="False" Height="38px" Width="160px" Font-Size="Large" />
                                                    &nbsp; 
                                        <asp:Button ID="Button3" runat="server" Text="进行分配" OnClick="Button3_Click" Enabled="False" Height="38px" Width="120px" Font-Size="Large" />

                                                    <br />
                                                    <asp:Label ID="Label22" runat="server" Text="女生："></asp:Label>
                                                    <asp:Button ID="Button6" runat="server" Text="分配前准备工作" OnClick="Button6_Click" Enabled="False" Height="38px" Width="160px" Font-Size="Large" />
                                                    &nbsp;
                                        <asp:Button ID="Button7" runat="server" Text="进行分配" OnClick="Button7_Click" Enabled="False" Height="38px" Width="120px" Font-Size="Large" />

                                                </div>

                                            </div>

                                        </div>
                                        <div class="manage-main2Boy-step3-1">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField DataField="one" HeaderText="1号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="two" HeaderText="2号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="three" HeaderText="3号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="four" HeaderText="4号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="manage-main2Boy-step3-1">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField DataField="one" HeaderText="1号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="two" HeaderText="2号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="three" HeaderText="3号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="four" HeaderText="4号床">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </asp:Panel>
                            </asp:Panel>
                            <asp:Panel ID="Panel3" runat="server" Visible="False">
                                <div class="manage-main2-ul1">
                                    <ul class="">

                                        <li style="width: 80px;">班级</li>
                                        <li style="width: 120px;">姓名</li>
                                        <li style="width: 40px;">性别</li>
                                    </ul>
                                </div>
                                <div class="manage-main2-ul2">
                                    <asp:ListView ID="lvNotWrite1" runat="server">
                                        <ItemTemplate>
                                            <div class="">
                                                <ul>
                                                    <li style="width: 80px;">
                                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("Major") %>'></asp:Label></li>
                                                    <li style="width: 120px;">
                                                        <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                    </li>
                                                    <li style="width: 40px;">
                                                        <asp:Label ID="lbMajor" runat="server" Text='<%#Eval("Sex") %>'></asp:Label></li>
                                                    <li style="width: 120px;">
                                                        <asp:LinkButton ID="lbSendUrge" runat="server" OnCommand="lbtn_GoodDetail" CommandName="SendUrge" CommandArgument='<%#Eval("Identity") %>' Text="催促填写"></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                                <asp:Button ID="Button17" runat="server" Text="返回" OnClick="Button17_Click" />
                            </asp:Panel>
                        </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

            <div id="main3" class="main" style="display: none">

                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label5" runat="server" Text="房间分配" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <div class="c3">
                                <br />
                                <br />
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="30px" Width="140px" Font-Size="Large" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                    <asp:ListItem>信管1808</asp:ListItem>
                                    <asp:ListItem>信管1807</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Height="30px" Width="60px" Font-Size="Large" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList><br />
                                <br />
                                <%--<asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="one" HeaderText="1号床" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name1" HeaderText="姓名" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="two" HeaderText="2号床" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name2" HeaderText="姓名" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="three" HeaderText="3号床" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name3" HeaderText="姓名" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="four" HeaderText="4号床" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name4" HeaderText="姓名" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="楼宇">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("building") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="寝室号">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("room") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="state" HeaderText="状态" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                    </Columns>
                                </asp:GridView>--%>

                                <div class="manage-main3-ul1">
                                    <ul class="">
                                        <li style="width: 155px;">1号床</li>
                                        <li style="width: 89px;">姓名</li>
                                        <li style="width: 155px;">2号床</li>
                                        <li style="width: 89px;">姓名</li>
                                        <li style="width: 155px;">3号床</li>
                                        <li style="width: 89px;">姓名</li>
                                        <li style="width: 155px;">4号床</li>
                                        <li style="width: 89px;">姓名</li>
                                        <li style="width: 80px;">楼宇</li>
                                        <li style="width: 80px;">寝室号</li>
                                        <li style="width: 70px;">状态</li>
                                    </ul>
                                </div>

                                <div class="manage-main3-ul2">
                                    <asp:ListView ID="ListView1" runat="server">
                                        <ItemTemplate>
                                            <ul>
                                                <li style="width: 155px;">
                                                    <asp:Label ID="lbOneID" runat="server" Text='<%#Eval("one") %>'></asp:Label></li>
                                                <li style="width: 89px;">
                                                    <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("name1") %>'></asp:Label>
                                                </li>
                                                <li style="width: 155px;">
                                                    <asp:Label ID="lbMajor" runat="server" Text='<%#Eval("two") %>'></asp:Label></li>
                                                <li style="width: 89px;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("name2") %>'></asp:Label></li>
                                                <li style="width: 155px;">
                                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("three") %>'></asp:Label></li>
                                                <li style="width: 89px;">
                                                    <asp:Label ID="Label16" runat="server" Text='<%#Eval("name3") %>'></asp:Label></li>
                                                <li style="width: 155px;">
                                                    <asp:Label ID="Label17" runat="server" Text='<%#Eval("four") %>'></asp:Label></li>
                                                <li style="width: 89px;">
                                                    <asp:Label ID="Label18" runat="server" Text='<%#Eval("name4") %>'></asp:Label></li>

                                                <li style="width: 80px;">
                                                    <asp:TextBox ID="tbBuilding" runat="server" Text='<%#Eval("building") %>' Width="70px"></asp:TextBox></li>

                                                <li style="width: 80px;">
                                                    <asp:TextBox ID="tbRoom" runat="server" Text='<%#Eval("room") %>' Width="70px"></asp:TextBox></li>

                                                <li style="width: 70px;">
                                                    <asp:Label ID="Label31" runat="server" Text='<%#Eval("state") %>'></asp:Label></li>
                                            </ul>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                                <br />
                                <br />
                                <asp:Button ID="Button14" runat="server" Text="确认信息" OnClick="Button14_Click" Height="38px" Width="120px" Font-Size="Large" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

            <div id="main4" class="main" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label6" runat="server" Text="发布结果" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <%--<div class="c2">
                                <div class="main4-notice">
                                    <asp:Image ID="Image1" runat="server" Height="220px" Width="220px" ImageUrl="~/Img/schoolNotice/1.PNG" />
                                    <div class="main4-text">
                                        <asp:Label ID="Label12" runat="server" Text="活动开始时间："></asp:Label>
                                        <asp:Label ID="Label17" runat="server" Text="2021-06-08 12：00：00"></asp:Label><br />
                                        <asp:Label ID="Label16" runat="server" Text="活动结束时间："></asp:Label>
                                        <asp:Label ID="Label18" runat="server" Text="2021-06-10 12：00：00"></asp:Label>
                                    </div>
                                </div>
                                <div class="main4-notice"></div>
                                <div class="main4-notice"></div>
                                <div class="main4-notice"></div>
                                <div class="main4-notice"></div>
                            </div>--%>

                            <div class="c3">
                                <br />
                                <br />
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="30px" Width="120px" Font-Size="Large">
                                    <asp:ListItem>信管1808</asp:ListItem>
                                    <asp:ListItem>信管1807</asp:ListItem>
                                </asp:DropDownList><br />
                                <br />
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="one" HeaderText="1号床">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name1" HeaderText="姓名">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="two" HeaderText="2号床">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name2" HeaderText="姓名">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="three" HeaderText="3号床">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name3" HeaderText="姓名">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="four" HeaderText="4号床">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name4" HeaderText="姓名">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="building" HeaderText="楼宇">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="room" HeaderText="寝室号">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="state" HeaderText="状态">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:BoundField>

                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                                <asp:Button ID="Button8" runat="server" Text="发布" OnClick="Button8_Click" Height="38px" Width="60px" Font-Size="Large" />
                                <asp:Button ID="Button9" runat="server" Text="撤销发布" OnClick="Button9_Click" Height="38px" Width="120px" Font-Size="Large" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="main5" class="main" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label15" runat="server" Text="收件箱" Font-Bold="True"></asp:Label>
                        </div>

                        <div class="contain2">

                            <asp:Panel ID="Panel4" runat="server">
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button13" runat="server" Text="新建" OnClick="Button13_Click" Height="38px" Width="60px" Font-Size="Large" />
                                <br />
                                <br />
                                <div class="main1-ul1">
                                    <ul class="">
                                        <li style="width: 120px;">发送人</li>
                                        <li style="width: 130px;">所在班级</li>
                                        <li style="width: 200px;">发送时间</li>
                                        <li style="width: 80px;">状态</li>
                                        <li style="width: 180px;">回复内容</li>
                                    </ul>
                                </div>
                                <div class="main1-ul2">
                                    <asp:ListView ID="lvMes" runat="server">

                                        <ItemTemplate>
                                            <div class="cb">
                                                <ul>
                                                    <li style="width: 120px;">
                                                        <asp:Label ID="lbCollege" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                    </li>
                                                    <li style="width: 130px;">
                                                        <asp:Label ID="lbMajor" runat="server" Text='<%#Eval("Major") %>'></asp:Label></li>
                                                    <li style="width: 200px; text-align: left;">
                                                        <asp:Label ID="lbClass" runat="server" Text='<%#Eval("Time") %>'></asp:Label></li>
                                                    <li style="width: 80px;">
                                                        <asp:Label ID="lbRead" runat="server" Text='<%#Eval("Read") %>'></asp:Label></li>
                                                    <li style="width: 180px;">
                                                        <asp:Label ID="Label26" runat="server" Text='<%#Eval("reContent") %>'></asp:Label></li>
                                                    <li style="width: 80px;">
                                                        <asp:LinkButton ID="lbSendUrge" runat="server" OnCommand="lbtn_GoodDetail" CommandName="SeeCotent" CommandArgument='<%#Eval("MID") %>' Text="查看"></asp:LinkButton>
                                                    </li>
                                                    <li style="width: 80px;">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="lbtn_GoodDetail" CommandName="Delect" CommandArgument='<%#Eval("MID") %>' Text="删除"></asp:LinkButton>

                                                    </li>
                                                    <li style="width: 80px;">
                                                        <asp:LinkButton ID="LinkButton2" runat="server" OnCommand="lbtn_GoodDetail" CommandName="Reply" CommandArgument='<%#Eval("MID") %>' Text="回复"></asp:LinkButton>

                                                    </li>
                                                </ul>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>

                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel7" runat="server" Visible="False">
                                <div id="cNew">
                                    <br />
                                    <br />
                                    <br />
                                    <table style="border-collapse: collapse; border: none; margin-left: 15px;">
                                        <tr>
                                            <td style="height: 75px; text-align: right;">发送人：
                                            </td>
                                            <td>
                                                <div class="cOne">
                                                    <asp:Label ID="Label27" runat="server" Text="管理员"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 75px; text-align: right;">信息类型：
                                            </td>
                                            <td>
                                                <div class="cOne">
                                                    <asp:Label ID="Label28" runat="server" Text="管理员通知"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 75px; text-align: right;">收信人ID：
                                            </td>
                                            <td>
                                                <div class="main-tbox">
                                                    <asp:TextBox ID="TextBox6" runat="server" Font-Size="Large"></asp:TextBox>
                                                    <asp:Label ID="Label29" runat="server" Text=""></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 75px; text-align: right;">具体内容：
                                            </td>
                                            <td>
                                                <div class="main-tbox">
                                                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="Large"></asp:TextBox>
                                                    <asp:Label ID="Label30" runat="server" Text=""></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button16" runat="server" Text="发送" OnClick="Button16_Click" Height="38px" Width="60px" Font-Size="Large" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button15" runat="server" Text="返回" OnClick="Button15_Click" Height="38px" Width="60px" Font-Size="Large" />
                                </div>

                            </asp:Panel>

                            <asp:Panel ID="Panel6" runat="server" Visible="False">
                                <div class="main5-send">
                                    <br />
                                    <br />
                                    <asp:TextBox ID="TextBox5" runat="server" Height="240px" Width="400px" Font-Size="Large" TextMode="MultiLine"></asp:TextBox>
                                    <asp:Button ID="Button11" runat="server" Text="确认发送" OnClick="Button11_Click" Height="38px" Width="120px" Font-Size="Large" /><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button12" runat="server" Text="返回" OnClick="Button12_Click" Height="38px" Width="60px" Font-Size="Large" />
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
                            <asp:Label ID="Label19" runat="server" Text="个人信息" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <div class="c2">
                                <div class="d2">
                                    <div class="right1-content">
                                        <br />
                                        <br />
                                        <asp:Label ID="lbName1" runat="server" Text="姓名："></asp:Label>
                                        <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label><br />
                                        <br />

                                        <asp:Label ID="lbJobNumber1" runat="server" Text="工号："></asp:Label>
                                        <asp:Label ID="lbJobNumber" runat="server" Text="Label"></asp:Label><br />
                                        <br />

                                        <asp:Label ID="lbIdentity1" runat="server" Text="身份证号："></asp:Label>
                                        <asp:Label ID="lbIdentity" runat="server" Text="Label"></asp:Label><br />
                                        <br />

                                        <asp:Label ID="lbCollege1" runat="server" Text="学院："></asp:Label>
                                        <asp:Label ID="lbCollege" runat="server" Text="Label"></asp:Label><br />
                                        <br />

                                        <asp:Label ID="lbType1" runat="server" Text="管理员类型："></asp:Label>
                                        <asp:Label ID="lbType" runat="server" Text="Label"></asp:Label><br />
                                        <br />

                                        <asp:Label ID="lbPhone1" runat="server" Text="联系方式："></asp:Label>
                                        <asp:Label ID="lbPhone" runat="server" Text="Label"></asp:Label><br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

            <div id="right2" class="right" style="display: none">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="c1">
                            <asp:Label ID="Label20" runat="server" Text="修改密码" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="contain">
                            <div class="right2-set">
                                <br />
                                <br />
                                <asp:Label ID="Label23" runat="server" Text="原密码：" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="tbOldPwd" runat="server" Font-Size="Larger"></asp:TextBox><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbMsgOldPwd" runat="server" Text="" ForeColor="Red"></asp:Label><br />

                                <asp:Label ID="Label24" runat="server" Text="新密码：" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="tbNewPwd" runat="server" Font-Size="Larger"></asp:TextBox><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbMsgNewPwd" runat="server" Text="" ForeColor="Red"></asp:Label><br />

                                <asp:Label ID="Label25" runat="server" Text="确认密码：" Font-Size="Larger"></asp:Label>
                                <asp:TextBox ID="tbNewPwd2" runat="server" Font-Size="Larger"></asp:TextBox><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbMsgNewPwd2" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                                <br />
                                <asp:Button ID="Button10" runat="server" Text="确定" OnClick="Button10_Click" />
                                <asp:Label ID="lbMsgUpdatePwd" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

            <div id="right3" class="right" style="display: none">
                <div class="c1">
                    <asp:Label ID="Label21" runat="server" Text="退出" Font-Bold="True"></asp:Label>
                </div>
                <div class="contain">
                    <div class="c2">
                        <div></div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
