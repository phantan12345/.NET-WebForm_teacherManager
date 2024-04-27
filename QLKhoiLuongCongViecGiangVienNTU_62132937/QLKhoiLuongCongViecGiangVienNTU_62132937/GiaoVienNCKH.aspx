<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GiaoVienNCKH.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.GiaoVienNCKH1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN GIÁO VIÊN NGHIÊN C&#7912;U KHOA H&#7884;C</b></td>
            </tr>
          
            <tr>
                <td style="width:40% " class="theten">
                   Giáo viên</td>
                 <td class="dieukhien" align="left">
                     <asp:TextBox ID="txtGiaoVien" runat="server" Width="63%"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                   Mã &#273;&#7873; tài</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtMaDT" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 40%" class="theten">
                  Tên &#273;&#7873; tài</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtTenDT" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 40%" class="theten">
                  C&#7845;p</td>
                <td class="dieukhien" align="left">
                    <asp:DropDownList ID="ddlCapThamGia" Width="70%" Height="25px" runat="server">
                        <asp:ListItem Value="0">---Ch&#7885;n c&#7845;p c&#7911;a &#273;&#7873; tài---</asp:ListItem>
                        <asp:ListItem Value="1">C&#7845;p tr&#432;&#7901;ng</asp:ListItem>
                        <asp:ListItem Value="2">C&#7845;p b&#7897;</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    N&#259;m tham gia</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlNamHoc" runat="server" Height="29px" Width="152px">
                        <asp:ListItem Value="0">--Ch&#7885;n n&#259;m --</asp:ListItem>
                    </asp:DropDownList>
                  <%--  &nbsp;-- &nbsp;<asp:DropDownList ID="ddlNamHoc1" runat="server" Height="29px" Width="110px">
                        <asp:ListItem Value="0">--Ch&#7885;n n&#259;m --</asp:ListItem>
                    </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td style="width: 40%"  class="theten">
                    Ghi chú</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtGhiChu" runat="server" Height="42px" MaxLength="30" 
                        Width="98%" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
                  <tr >
                  <td colspan="2" align="left" style="border:0px; width:100%; height:25px; font-size:15px; text-align:left; color:Red;" >
                  
                   <%--   <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>--%>
                  
                   </td>
           <%-- <td colspan="2" align="left" style="color: red; font-size: 15px; font-weight: bold; border:0px 0px none;width: 100%; height: 25px;">
                <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
            </td>--%>
        </tr>
        <tr>
          <td colspan="2" align="center" class="dongdieukhien" valign="middle">
                <asp:Button ID="btnThem" runat="server" Text="Thêm m&#7899;i" 
                    onclick="btnThem_Click" />&nbsp;
                <asp:Button ID="btnSua" runat="server" Text="S&#7917;a thông tin" 
                    onclick="btnSua_Click" />
                 <asp:Button ID="btnXoa" runat="server" Text="Xóa thông tin" 
                    onclick="btnXoa_Click" />
               <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
           <asp:GridView ID="GrvGVNCKH" runat="server" Width="100%" AllowPaging="True" 
                  AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                  onselectedindexchanging="GrvGVNCKH_SelectedIndexChanging" 
                  onpageindexchanging="GrvGVNCKH_PageIndexChanging" onprerender="GrvGVNCKH_PreRender" 
                  >
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                            <asp:TemplateField HeaderText="Mã &#273;&#7873; tài" SortExpression="MaDeTai" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaDeTai") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaDeTai") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tên giáo viên" SortExpression="TenGV">
                                <ItemTemplate>
                                    <%#Eval("TenGV")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenGV")%>' ID="txtGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Tên &#273;&#7873; tài" SortExpression="TenDeTai">
                                <ItemTemplate>
                                    <%#Eval("TenDeTai")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenDeTai")%>' ID="txtTenDT"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="C&#7845;p" SortExpression="Cap">
                                <ItemTemplate>
                                    <%#Eval("Cap")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("Cap")%>' ID="txtCap"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                        
                             <asp:TemplateField HeaderText="N&#259;m tham gia" SortExpression="NamThamGiaNC">
                                <ItemTemplate>
                                    <%#Eval("NamThamGiaNC")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("NamThamGiaNC")%>' ID="txtNamThamGia"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                                <ItemTemplate>
                                    <%#Eval("GhiChu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiChu")%>' ID="txtGhiChu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                           
                        </Columns>
                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            </asp:Panel>
        <br />
        </td>
        </tr>
      
        </table>
    </center>
</asp:Content>


