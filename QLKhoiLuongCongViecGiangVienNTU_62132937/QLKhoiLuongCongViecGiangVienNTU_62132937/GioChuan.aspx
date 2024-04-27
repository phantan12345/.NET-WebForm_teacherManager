<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GioChuan.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.GioChuan1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            border-bottom: 0.01px solid #5f9ae0;
            text-align: right;
            padding: 5px;
            height: 25px;
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
        .style2
        {
            border-left: 0.01px solid #6495ed;
            border-bottom: 0.01px solid #6495ed;
            padding: 1px;
            text-align: left;
            height: 25px;
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
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN GI&#7900; CHU&#7848;N</b></td>
            </tr>
            
            <tr>
                <td class="style1">
                    Mã ch&#7913;c danh</td>
                <td class="style2">
                    <asp:TextBox ID="txtMaChucDanh" runat="server" Width="169px" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="theten">
                    Tên ch&#7913;c danh</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtTenChucDanh" runat="server" Width="96%" Height="23px"></asp:TextBox>
                   
                </td>
            </tr>
          
            <tr>
                <td  class="theten">
                    S&#7889; gi&#7901; chu&#7849;n</td>
                <td class="dieukhien">
                   
                    <asp:TextBox ID="txtSoGioChuan" runat="server" MaxLength="10" Width="169px" Height="23px"></asp:TextBox>
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
               <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
                &nbsp;<asp:Button ID="btnMoi" runat="server" 
                    Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
              <asp:GridView ID="GrvGioChuan" runat="server" AutoGenerateColumns="False" 
                  Width="99%"  AllowPaging="True" AutoGenerateSelectButton="True" 
                  onpageindexchanging="GrvGioChuan_PageIndexChanging" 
                  onselectedindexchanging="GrvGioChuan_SelectedIndexChanging" BackColor="White" 
                  BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                  CellSpacing="1" GridLines="None" 
                 >
               <Columns>
                            <asp:TemplateField HeaderText="Mã ch&#7913;c v&#7909;" SortExpression="MaChucDanh" Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaChucDanh") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaChucDanh") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên ch&#7913;c danh" SortExpression="TenChucDanh">
                                <ItemTemplate>
                                    <%#Eval("TenChucDanh")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenChucDanh")%>' ID="txtTenChucDanh"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
            
                            <asp:TemplateField HeaderText="S&#7889; gi&#7901; chu&#7849;n" SortExpression="SoGioChuan">
                                <ItemTemplate>
                                    <%#Eval("SoGioChuan")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoGioChuan")%>' ID="txtSoGioChuan"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                                <ItemTemplate>
                                    <%#Eval("GhiChu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiChu")%>' ID="txtGhiChu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
            
                            
                           <%-- <asp:CommandField InsertText="" ShowEditButton="True" EditText="S&#7917;a" HeaderText="Ch&#7885;n" />
                            <asp:CommandField HeaderText="Xóa" ShowDeleteButton="true" />--%>
                        </Columns>

                  <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                  <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                  <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                  <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#594B9C" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#33276A" />

              </asp:GridView>
            </asp:Panel>
        <br />
        </td>
        </tr>
      
        </table>
    </center>
</asp:Content>

