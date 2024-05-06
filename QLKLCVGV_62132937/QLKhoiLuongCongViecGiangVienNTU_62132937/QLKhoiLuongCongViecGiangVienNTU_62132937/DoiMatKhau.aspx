<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.DoiMatKhau" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
        <link href="CSS/adminstyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 31px;
            background-color: #5f9ae0;
            font-size: 16px;
            font-weight: bold;
        }
        td
        {
            border: 0px;
        }
        .style2
        {
            width: 370px;
        }
        .style3
        {
            margin-left: 0px;
        }
        .style4
        {
            height: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
    <table cellpadding="0" cellspacing="0" border="1px" class="style2">
                <tr>
                    <td colspan="2" class="style1" align="center">
                       Đổi mật khẩu
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="style4">
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; line-height: 28px; width: 40%;">
                        Tên đăng nhập
                    </td>
                    <td align="left" style="line-height: 28px; padding-left: 3px;">
                        <asp:TextBox ID="txtUserName" runat="server" Width="96%" ReadOnly="true" CssClass="style3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; line-height: 28px">
                        Mật khẩu
                        cũ</td>
                    <td align="left" style="line-height: 28px; padding-left: 3px;">
                        <asp:TextBox ID="txtPasswordcu" runat="server" Width="96%" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="left" style="padding-left: 10px; line-height: 28px">
                        Mật khẩu
                        mới
                    </td>
                    <td align="left" style="line-height: 28px; padding-left: 3px;">
                        <asp:TextBox ID="txtpassmoi" runat="server" Width="96%" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; line-height: 28px">
                        Nhập lại mật khẩu mới</td>
                    <td align="left" style="line-height: 28px; padding-left: 3px;">
                        <asp:TextBox ID="txtnhappassmoi" runat="server" Width="96%" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 38px" colspan="2" align="left"  >
                        <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span>
                        <asp:Button ID="btDoiMK" runat="server" Text="Đổi mật khẩu" 
                            onclick="btDoiMK_Click"  />
                        <%--<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span>--%>
                       
                        <asp:Label ID="lblThongbao" runat="server" Text="" CssClass="LabelThongbao"></asp:Label>
                    </td>
            
                </tr>
               <%-- <tr>
                    </td><td align="center" style="padding-left: 10px; line-height: 28px" colspan="2">
                        <asp:Label ID="lblthongbao" runat="server" Font-Bold="true" Font-Size="12" ForeColor="Red" ></asp:Label>
                        <asp:HyperLink ID="hplQuenMK" runat="server" NavigateUrl="#href=abc">Quên 
                    mật khẩu?</asp:HyperLink>
                    </td>
                </tr>--%>
            </table>
    </center>
    </div>
    </form>
</body>
</html>
