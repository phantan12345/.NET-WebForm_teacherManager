<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThongTinMonHoc.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.ThongTinMonHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN MÔN H&#7884;C</b></td>
            </tr>
           <%  
            //   <tr>
            //    <td colspan="2">
            //        <asp:Label ID="lblThongtin" runat="server" Font-Bold="true"></asp:Label>
            //    </td>
            //</tr>
            %>
             <tr>
                <td style="width: 40% " class="theten">
                    H&#7879; &#273;ào t&#7841;o</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlHeDaoTao" AutoPostBack="true" Width="43%" Height="30px" 
                        runat="server" onselectedindexchanged="ddlHeDaoTao_SelectedIndexChanged">
                        <asp:ListItem Value="0" Selected="True">---Ch&#7885;n h&#7879; &#273;ào t&#7841;o---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblMahedt" runat="server" Text="Mahedt" Visible="false"></asp:Label>
                   </td>
            </tr>
             <tr>
                <td style="width: 40% " class="theten">
                    Lo&#7841;i môn </td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlLoaiMon" AutoPostBack="true" Width="43%" Height="30px" 
                        runat="server" onselectedindexchanged="ddlLoaiMon_SelectedIndexChanged">
                        <asp:ListItem Value="0" Selected="True">---Ch&#7885;n lo&#7841;i môn h&#7885;c---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblMaLM" runat="server" Text="MaLM" Visible="false"></asp:Label>
</td>
            </tr>
            <tr>
                <td style="width: 40% " class="theten">
                    Mã môn h&#7885;c</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtMaMon" runat="server" Width="43%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    Tên môn h&#7885;c</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtTenMon" runat="server" Width="99%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                  </td>
            </tr>
            <tr>
                <td style="width: 40%"  class="theten">
                    S&#7889; ti&#7871;t (Tu&#7847;n &#272;VTTSP)</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtSoTiet" Width="169px" runat="server"></asp:TextBox>
                </td>
            </tr>
           
      
            <tr>
                <td style="width: 40%" class="theten">
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
                &nbsp;<asp:Button ID="btnMoi" runat="server" 
                    Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" />
                &nbsp;&nbsp; Thông tin &nbsp;<asp:TextBox ID="txtMa" runat="server" Width="150px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnTim" runat="server" Text="Tìm" 
                    onclick="btnTim_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
            <asp:GridView ID="GrvMonHoc" runat="server" Width="100%" AllowPaging="True" 
                  AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                  onpageindexchanging="GrvMonHoc_PageIndexChanging" 
                  onselectedindexchanging="GrvMonHoc_SelectedIndexChanging" 
                  BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                  CellPadding="3" CellSpacing="1" GridLines="None" PageSize="100" >
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <Columns>
                            <asp:TemplateField HeaderText="Mã môn"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaMon") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaMon") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên môn h&#7885;c">
                                <ItemTemplate>
                                    <%#Eval("TenMon")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenMon")%>' ID="txtTenMH"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Lo&#7841;i môn" SortExpression="TenLoai">
                                <ItemTemplate>
                                    <%#Eval("TenLoai")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenLoai")%>' ID="txtSoTiet"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="S&#7889; ti&#7871;t " >
                                <ItemTemplate>
                                    <%#Eval("SoTiet")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoTiet")%>' ID="txtSoTiet"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                         
                            <asp:TemplateField HeaderText="H&#7879; &#273;ào t&#7841;o " SortExpression="TenHeDT">
                                <ItemTemplate>
                                    <%#Eval("TenHeDT")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenHeDT")%>' ID="TenHeDT"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Ghi chú" >
                                <ItemTemplate>
                                    <%#Eval("GhiChu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiChu")%>' ID="txtGhiChu"></asp:TextBox>
                                    </EditItemTemplate>
                            </asp:TemplateField>
                         <%--   <asp:CommandField InsertText="" ShowEditButton="True" EditText="S&#7917;a" HeaderText="Ch&#7885;n" />
                            <asp:CommandField HeaderText="Xóa" ShowDeleteButton="true" />--%>
                        </Columns>
                         <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" 
                    HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" 
                    ForeColor="White" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
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

