<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SoulRoommate.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>天津师范大学住宿管理系统</title>
    <link rel="stylesheet" type="text/css" href="CSS/index.css" />
    <script src="JS/jquery(v3.5.1).min.js"></script>
    <script src="JS/index.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="index-top">
            <asp:Label ID="Label1" runat="server" Text="SR"></asp:Label>
        </div>
        <div class="index-middle">
            <asp:Label ID="Label2" runat="server" Text="SOUL "></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="   ROOMMATE"></asp:Label>
        </div>
        <div class="index-main">
            <div class="login">
                <div class="contain">
                    <div class="c">
                        <ul id="ul1" style="color: #939391;">
                            <li style="color: black; border-bottom: 5px solid #60C1D4;">学生端</li>
                            <li>工作端</li>
                        </ul>
                    </div>
                    <div class="d">
                        <div id="main1" class="main" style="display: block">
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View1" runat="server">
                                    <div class="txtBox">
                                        <asp:Image ID="ImgUser" runat="server" ImageUrl="~/Img/icon/name.png" />
                                        <asp:TextBox ID="txtUser" runat="server" placeholder="身份证号" autocomplete="off"></asp:TextBox>
                                    </div>

                                    <div class="txtBox4">
                                        <asp:Label ID="lbMsgUser" runat="server" Text=""></asp:Label>
                                        <%--身份证号不为空验证控件--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不可为空!" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUser"></asp:RequiredFieldValidator>
                                        <%--身份证号--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="输入有误" ControlToValidate="txtUser" ValidationExpression="^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="txtBox cb">
                                        <asp:Image ID="ImgEmail" runat="server" ImageUrl="~/Img/icon/email.png" />
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="邮箱" autocomplete="off"></asp:TextBox>
                                    </div>

                                    <div class="txtBox4">
                                        <asp:Label ID="lbMsgEmail" runat="server" Text=""></asp:Label>
                                        <%--邮箱不为空验证控件--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="不可为空!" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                        <%--邮箱--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="输入有误" ControlToValidate="txtEmail" ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>

                                    </div>

                                    <div class="txtBox2 cb">

                                        <asp:Image ID="ImgCode" runat="server" ImageUrl="~/Img/icon/code.png" />
                                        <asp:TextBox ID="txtCode" runat="server" placeholder="验证码" autocomplete="off"></asp:TextBox>


                                    </div>

                                    <div class="sendCode">
                                        <asp:Button ID="btnSendCode" runat="server" Text="发送验证码" OnClick="btnSendCode_Click" />
                                    </div>


                                    <div class="txtBox4 cb" style="margin-left: -190px;">
                                        <asp:Label ID="lbMsgSendCode" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lbMsgCode" runat="server" Text=""></asp:Label>
                                    </div>

                                    <div class="txtBox3 cb">
                                        <div class="rememberEmail">
                                            <asp:CheckBox ID="cbRememberEmail" runat="server" /><span>记住信息</span>
                                        </div>
                                    </div>

                                    <div class="txtBox3 cb">
                                        <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
                                    </div>
                                    <div class="txtBox5">
                                        <asp:Label ID="lbMsgLogin" runat="server" Text="" ForeColor="#ED461B"></asp:Label>
                                    </div>
                                </asp:View>

                                <asp:View ID="View2" runat="server">
                                    <div class="txtBox">
                                        <asp:Image ID="ImgUser2" runat="server" ImageUrl="~/Img/icon/name.png" />
                                        <asp:TextBox ID="txtUser2" runat="server" placeholder="身份证号" autocomplete="off"></asp:TextBox>
                                    </div>

                                    <div class="txtBox4">
                                        <asp:Label ID="lbMsgUser2" runat="server" Text=""></asp:Label>
                                        <%--身份证号不为空验证控件--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="不可为空!" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUser2"></asp:RequiredFieldValidator>
                                        <%--身份证号--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="输入有误" ControlToValidate="txtUser2" ValidationExpression="^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="txtBox cb">
                                        <asp:Image ID="ImgEmail2" runat="server" ImageUrl="~/Img/icon/password.png" />
                                        <asp:TextBox ID="txtEmail2" runat="server" placeholder="密码" autocomplete="off" TextMode="Password"></asp:TextBox>
                                    </div>

                                    <div class="txtBox4">
                                        <asp:Label ID="lbMsgEmail2" runat="server" Text=""></asp:Label>
                                        <%--密码不为空验证控件--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="不可为空!" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail2"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="txtBox2 cb">
                                        <asp:Image ID="ImgCode2" runat="server" ImageUrl="~/Img/icon/code.png" />
                                        <asp:TextBox ID="txtCode2" runat="server" placeholder="验证码" autocomplete="off"></asp:TextBox>
                                    </div>

                                    <div class="sendCode2">
                                        <div class="newBoxPanel cb">
                                            <div id="code"></div>
                                            <asp:Label ID="lbVeriCode" runat="server" Visible="False"></asp:Label>
                                            <%--<img alt="看不清？换一张" title="看不清？换一张" src="Common/VeriCode.aspx" style="cursor:pointer" onclick="this.src=this.src+'?r='+Math.random()" />--%>
                                        </div>
                                    </div>

                                    <div class="txtBox4 cb">
                                        <asp:Label ID="lbMsgCode2" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lbMsgSendCode2" runat="server" Text=""></asp:Label>
                                    </div>

                                    <div class="txtBox3 cb">
                                        <div class="rememberEmail">
                                            <asp:CheckBox ID="cbRememberEmail2" runat="server" /><span>记住账号</span>
                                        </div>
                                    </div>

                                    <div class="txtBox3 cb">
                                        <asp:Button ID="btnLogin2" OnClientClick="return checkoutCode()" runat="server" Text="登录" OnClick="btnLogin2_Click" />
                                    </div>

                                    <div class="txtBox5">
                                        <asp:Label ID="lbMsgLogin2" runat="server" Text="" ForeColor="#ED461B"></asp:Label>
                                    </div>
                                </asp:View>
                            </asp:MultiView>

                            <div class="selectLoginWay">
                                <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
                                    <Items>
                                        <asp:MenuItem Text="邮箱登录" Value="1" Selected="True"></asp:MenuItem>
                                        <asp:MenuItem Text="密码登录" Value="2"></asp:MenuItem>
                                    </Items>
                                    <LevelMenuItemStyles>
                                        <asp:MenuItemStyle BorderStyle="None" Font-Size="Larger" Font-Underline="False" ForeColor="#939391" Height="30px" Width="120px" />
                                    </LevelMenuItemStyles>
                                    <StaticSelectedStyle Font-Size="Larger" ForeColor="Black" Height="30px" Width="120px" />
                                </asp:Menu>
                            </div>

                            <div class="txtBox7 cb">
                                <div class="error">
                                    <asp:HyperLink ID="hlError" runat="server" Visible="False">无法登录？</asp:HyperLink>
                                </div>
                            </div>
                        </div>

                        <div id="main2" class="main" style="display: none">
                            <div class="txtBox">
                                <asp:Image ID="ImgUser3" runat="server" ImageUrl="~/Img/icon/name.png" />
                                <asp:TextBox ID="txtUser3" runat="server" placeholder="工号" autocomplete="off"></asp:TextBox>
                            </div>

                            <div class="txtBox4">
                                <asp:Label ID="lbMsgUser3" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="txtBox cb">
                                <asp:Image ID="ImgEmail3" runat="server" ImageUrl="~/Img/icon/password.png" />
                                <asp:TextBox ID="txtEmail3" runat="server" placeholder="密码" autocomplete="off" TextMode="Password"></asp:TextBox>
                            </div>

                            <div class="txtBox4">
                                <asp:Label ID="lbMsgEmail3" runat="server" Text=""></asp:Label>
                                <%--密码不为空验证控件--%>
                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="不可为空!" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail3"></asp:RequiredFieldValidator>
                                --%>
                            </div>

                            <div class="txtBox2 cb">
                                <asp:Image ID="ImgCode3" runat="server" ImageUrl="~/Img/icon/code.png" />
                                <asp:TextBox ID="txtCode3" runat="server" placeholder="验证码" autocomplete="off"></asp:TextBox>
                            </div>

                            <div class="sendCode2">
                                <div class="newBoxPanel cb">
                                    <div id="code3"></div>
                                    <asp:Label ID="lbVeriCode3" runat="server" Visible="False"></asp:Label>
                                </div>
                            </div>

                            <div class="txtBox4 cb">
                                <asp:Label ID="lbMsgCode3" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbMsgSendCode3" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="txtBox3 cb">
                                <div class="rememberEmail">
                                    <asp:CheckBox ID="cbRememberEmail3" runat="server" /><span>记住账号</span>
                                </div>
                            </div>

                            <div class="txtBox3 cb">
                                <asp:Button ID="btnLogin3" runat="server" Text="登录" OnClientClick="return checkoutCode3()" OnClick="btnLogin3_Click" />
                            </div>

                            <div class="txtBox5">
                                <asp:Label ID="lbMsgLogin3" runat="server" Text="" ForeColor="#ED461B"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
