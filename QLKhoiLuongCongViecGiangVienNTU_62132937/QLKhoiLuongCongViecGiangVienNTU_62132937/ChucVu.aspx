<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChucVu.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.ChucVu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN CH&#7912;C V&#7908;</b></td>
            </tr>
            
            <tr>
                <td class="theten">
                    Mã ch&#7913;c v&#7909;</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtMaChucVu" runat="server" Width="169px" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="theten">
                    Tên ch&#7913;c v&#7909;</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtTenChucVu" runat="server" Width="96%" Height="23px"></asp:TextBox>
                   
                </td>
            </tr>
          
            <tr>
                <td  class="theten">
                    Ph&#7847;n tr&#259;m &#273;&#432;&#7907;c gi&#7843;m</td>
                <td class="dieukhien">
                   
                    <asp:TextBox ID="txtPhanTramGiam" runat="server" MaxLength="10" Width="169px" Height="23px"></asp:TextBox>
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
              <asp:GridView ID="GrvChucVu" runat="server" AutoGenerateColumns="False" 
                  Width="99%"  AllowPaging="True" AutoGenerateSelectButton="True" 
                  onpageindexchanging="GrvChucVu_PageIndexChanging" 
                  onselectedindexchanging="GrvChucVu_SelectedIndexChanging" BackColor="White" 
                  BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 PageSize="100">
               <Columns>
                            <asp:TemplateField HeaderText="Mã ch&#7913;c v&#7909;" SortExpression="MaChucVu" Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaChucVu") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaChucVu") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên ch&#7913;c v&#7909;" SortExpression="TenChucVu">
                                <ItemTemplate>
                                    <%#Eval("TenChucVu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenChucVu")%>' ID="txtTenChucVu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
            
                            <asp:TemplateField HeaderText="Ph&#7847;n tr&#259;m &#273;&#432;&#7907;c gi&#7843;m" SortExpression="PhanTramDuocGiam">
                                <ItemTemplate>
                                    <%#Eval("PhanTramDuocGiam")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("PhanTramDuocGiam")%>' ID="txtPhanTramDuocGiam"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                                <ItemTemplate>
                                    <%#Eval("GhiChu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiChu")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
            
                            
                          <%--  <asp:CommandField InsertText="" ShowEditButton="True" EditText="S&#7917;a" HeaderText="Ch&#7885;n" />
                            <asp:CommandField HeaderText="Xóa" ShowDeleteButton="true" />--%>
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

