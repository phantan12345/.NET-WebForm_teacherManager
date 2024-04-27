<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoaiMon.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.LoaiMon1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
        <table cellpadding="0" cellspacing="0" style="width:100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN LO&#7840;I MÔN</b></td>
            </tr>
            
            <tr>
                <td  class="theten">
                    Mã lo&#7841;i môn</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtMaLoai" runat="server" Width="169px" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
               <td  class="theten">
                    Tên lo&#7841;i môn</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtTenLoai" runat="server" Width="96%" Height="23px"></asp:TextBox>
                   
                </td>
            </tr>
          
          
                        <tr>
               <td  class="theten">
                    Ghi chú</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtGhiChu" runat="server" Height="42px" MaxLength="30" 
                        Width="98%" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
          
                  <tr >
                  <td colspan="2" align="left" style="border:0px; width:100%; height:25px; font-size:15px; text-align:left; color:Red;" >
                  
                      <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
                  
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

                &nbsp; <asp:Button ID="btnXoa" runat="server" Text="Xóa thông tin" 
                    onclick="btnXoa_Click" />
               <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
            &nbsp;&nbsp;<asp:Button ID="btnMoi" runat="server" 
                    Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
              <asp:GridView ID="GrvLoaiMon" runat="server" AutoGenerateColumns="False" 
                  Width="99%"  AllowPaging="True" AutoGenerateSelectButton="True" 
                  onselectedindexchanging="GrvLoaiMon_SelectedIndexChanging" 
                  onpageindexchanging="GrvLoaiMon_PageIndexChanging" BackColor="White" 
                  BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                  CellSpacing="1" GridLines="None" 
                
                 >
                  <Columns>
                      <asp:TemplateField HeaderText="Mã lo&#7841;i môn" SortExpression="MaLoai" 
                          Visible="true">
                          <ItemTemplate>
                              <asp:Label ID="lblMa" runat="server" Text='<%#Bind("MaLoai") %>'></asp:Label>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:Label ID="lblMa" runat="server" Text='<%#Bind("MaLoai") %>'></asp:Label>
                          </EditItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Tên lo&#7841;i môn" SortExpression="TenLoai">
                          <ItemTemplate>
                              <%#Eval("TenLoai")%>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:TextBox ID="txtTenLoai" runat="server" Text='<%#Bind("TenLoai")%>'></asp:TextBox>
                          </EditItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                          <ItemTemplate>
                              <%#Eval("GhiChu")%>
                          </ItemTemplate>
                          <EditItemTemplate>
                              <asp:TextBox ID="txtGhiChu" runat="server" Text='<%#Bind("GhiChu")%>'></asp:TextBox>
                          </EditItemTemplate>
                      </asp:TemplateField>
                      <%--  <asp:CommandField InsertText="" ShowEditButton="True" EditText="S&#7917;a" HeaderText="Ch&#7885;n" />
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

