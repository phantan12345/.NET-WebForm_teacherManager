<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BoMon.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.BoMon1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN BỘ MÔN</b></td>
            </tr>
            
            <tr>
                <td class="theten">
                    Mã b&#7897; môn</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtMaBoMon" runat="server" Width="169px" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="theten">
                    Tên b&#7897; môn</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtTen" runat="server" Width="96%" Height="23px"></asp:TextBox>
                   
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
            <td colspan="2" align="center" class="dongdieukhien" valign="middle">
                <asp:Button ID="btnThem" runat="server" Text="Thêm m&#7899;i" 
                    onclick="btnThem_Click" />&nbsp;
                <asp:Button ID="btnSua" runat="server" Text="S&#7917;a thông tin" 
                    onclick="btnSua_Click" />

                &nbsp; <asp:Button ID="btnXoa" runat="server" Text="Xóa thông tin" 
                    onclick="btnXoa_Click" />
                &nbsp;<asp:Button ID="btnMoi" runat="server" 
                    Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
              <asp:GridView ID="GrvBoMon" runat="server" AutoGenerateColumns="False" 
                  Width="99%"  AllowPaging="True" AutoGenerateSelectButton="True" 
                  onpageindexchanging="GrvChucVu_PageIndexChanging" 
                  onselectedindexchanging="GrvChucVu_SelectedIndexChanging" BackColor="White" 
                  BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 PageSize="100">
               <Columns>
                            <asp:TemplateField HeaderText="Mã b&#7897; môn" SortExpression="MaBoMon" 
                                Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaBoMon") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaBoMon") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên b&#7897; môn" SortExpression="TenBoMon">
                                <ItemTemplate>
                                    <%#Eval("TenBoMon")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenBoMon")%>' ID="txtTenChucVu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
            
                             <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                                <ItemTemplate>
                                    <%#Eval("GhiChu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiChu")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                  <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                  <HeaderStyle BackColor="#4682b4" Font-Bold="True" ForeColor="#FFFFCC" />
                  <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                  <RowStyle BackColor="White" ForeColor="#330099" />
                  <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                  <SortedAscendingCellStyle BackColor="#FEFCEB" />
                  <SortedAscendingHeaderStyle BackColor="#AF0101" />
                  <SortedDescendingCellStyle BackColor="#F6F0C0" />
                  <SortedDescendingHeaderStyle BackColor="#7E0000" />

              </asp:GridView>
            </asp:Panel>
        <br />
        </td>
        </tr>
      
        </table>
    </center>
</asp:Content>
