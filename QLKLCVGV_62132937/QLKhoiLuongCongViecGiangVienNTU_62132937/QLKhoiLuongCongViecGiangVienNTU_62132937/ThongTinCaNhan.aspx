<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.ThongTinCaNhan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .theten
        {
            border-bottom: 0.01px solid #5f9ae0;
            text-align: right;
            padding: 5px;
            width: 349px;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0px;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: 0px;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N TR&#7882; H&#7878; TH&#7888;NG -&gt;&nbsp;THÔNG TIN CÁ NHÂN </b>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblThongtin" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="theten">
                    Tên &#273;&#259;ng nh&#7853;p
                </td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtTenDN" ReadOnly="true" runat="server" Width="311px" MaxLength="100"></asp:TextBox>
                    <%--<br />--%>
                   <%-- <asp:Label ID="lblmaTV" runat="server" Text=""></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <td class="theten">
                    H&#7885; tên
                </td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtHoten" runat="server" Width="311px" MaxLength="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="theten">
                    Ngày sinh
                </td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtNgaysinh" runat="server" MaxLength="50" Width="311px"></asp:TextBox>
                    <%--<cc1:CalendarExtender ID="cldNgaySinh" runat="server" Enabled="true" Format="MM/dd/yyyy"
                        TargetControlID="txtNgaySinh">
                    </cc1:CalendarExtender>--%>
                </td>
            </tr>
            <tr>
                <td class="theten">
                    Gi&#7899;i tính
                </td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtGioiTinh" runat="server" MaxLength="50" Width="311px"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td class="theten">
                    Ch&#7913;ng minh th&#432; nhân dân
                </td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtCMND" runat="server" MaxLength="50" Width="311px"></asp:TextBox>
                  
                </td>
            </tr>

           <%--  <tr>
                <td class="theten">
                   &#7842;nh &#273;&#7841;i di&#7879;n
                </td>
                <td>
                 <asp:Image ID="imgAnhDaiDien"  runat="server" />
                </td>
            </tr>--%>
             <tr>
                <td class="theten">
                    Bộ môn
                </td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtBoMon" runat="server" Width="311px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="theten">
                    Trình &#273;&#7897; h&#7885;c v&#7845;n
                </td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtTDHVan" runat="server" Width="311px"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="theten">
                    Ch&#7913;c danh</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtChucDanh" runat="server" Width="311px"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="theten">
                    N&#259;m vào làm</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtNamVaoLam" runat="server" Width="311px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="theten">
                    Email
                </td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtEmail" runat="server" Width="311px"></asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td class="theten">
                    &#272;&#7883;a ch&#7881;
                </td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtDiaChi" runat="server" Width="671px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td class="theten">
                    Ghi chú</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtGhiChu" runat="server" Height="42px" MaxLength="30" 
                        Width="98%" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
          
         
       
             <tr>
            <td colspan="2"  class="dongdieukhien" align="center">
            
                <asp:Button ID="btnCapNhat" runat="server" 
                    Text="C&#7853;p nh&#7853;t thông tin" onclick="btnCapNhat_Click" />
                &nbsp;&nbsp;
                    <%--<asp:Button ID="btHuy" runat="server" Text="H&#7911;y" 
                    Width="133px" Font-Bold="true"> </asp:Button >--%>
            </td>
        </tr>
        </table>
    </center>
</asp:Content>

