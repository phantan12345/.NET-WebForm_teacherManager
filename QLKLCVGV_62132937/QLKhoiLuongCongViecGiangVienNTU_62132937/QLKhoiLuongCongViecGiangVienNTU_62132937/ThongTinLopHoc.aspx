<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThongTinLopHoc.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.ThongTinLopHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN L&#7898;P H&#7884;C</b></td>
            </tr>
           <%  
            //   <tr>
            //    <td colspan="2">
            //        <asp:Label ID="lblThongtin" runat="server" Font-Bold="true"></asp:Label>
            //    </td>
            //</tr>
            %>
              <tr>
                <td  class="theten">
                    Ch&#7885;n hình th&#7913;c l&#7899;p</td>
                <td class="dieukhien">
                    <asp:CheckBox ID="ckLyThuyet" runat="server" Text="Lý thuy&#7871;t" ValidationGroup="HinhThucLop"
                        AutoPostBack="true" oncheckedchanged="ckLyThuyet_CheckedChanged" /> &nbsp;
                     <asp:CheckBox ID="ckThucHanh" runat="server" Text="Th&#7921;c hành"  ValidationGroup="HinhThucLop"
                        AutoPostBack="true" oncheckedchanged="ckThucHanh_CheckedChanged" />
                </td>
            </tr>

              <tr>
                <td  class="theten">
                    <asp:Label ID="lblChonLopLT" runat="server" Text="Ch&#7885;n l&#7899;p lý thuy&#7871;t"></asp:Label>
                  </td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlChonLopLT" runat="server" Height="23px" Width="201px" 
                        AppendDataBoundItems="true" AutoPostBack="true" 
                        onselectedindexchanged="ddlChonLopLT_SelectedIndexChanged">
                        <asp:ListItem Value="0" Selected="True">---Ch&#7885;n l&#7899;p lý thuy&#7871;t---</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td  class="theten">
                    Mã l&#7899;p     <td class="dieukhien">
                    <asp:TextBox ID="txtMaLop" runat="server" Width="26%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="theten">
                    H&#7879; &#273;ào t&#7841;o</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlHeDT" runat="server" Height="23px" Width="201px" 
                        AppendDataBoundItems="true" AutoPostBack="true"
                        onselectedindexchanged="ddlHeDT_SelectedIndexChanged">
                        <asp:ListItem Value="0" Selected="True">---Ch&#7885;n h&#7879; &#273;ào t&#7841;o---</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;<asp:Label ID="lblMahdt" runat="server" Text="lblMahdt" Visible="false"></asp:Label>
                </td>
            </tr>
              <tr>
                <td  class="theten">
                    Hình th&#7913;c &#273;ào t&#7841;o</td>
                <td class="dieukhien" align="left">
                    <asp:DropDownList ID="ddlHTDT" runat="server" Height="23px" Width="201px" 
                        style="margin-bottom: 0px" AppendDataBoundItems="true" AutoPostBack="true"
                     >
                        <asp:ListItem Value="0" Selected="True" >---Ch&#7885;n hình th&#7913;c &#273;ào t&#7841;o---</asp:ListItem>
                         <asp:ListItem Value="1" >Niên ch&#7871;</asp:ListItem>
                          <asp:ListItem Value="2" >Tín ch&#7881;</asp:ListItem>
                    </asp:DropDownList>
                   <%-- <asp:Label ID="lblMahtdt" runat="server" Text="lblhtdt" Visible="true"></asp:Label>--%>
                </td>
            </tr>
          
            <tr>
                <td class="theten">
                    Tên l&#7899;p</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtTenLop" runat="server" MaxLength="50" Width="26%" 
                        Height="23px"></asp:TextBox>
                   
                </td>
            </tr>
          
            <tr>
                <td class="theten">
                    S&#297; s&#7889;</td>
                <td class="dieukhien">
                   
                    <asp:TextBox ID="txtSiSo" runat="server" MaxLength="10" Height="23px" 
                        Width="26%"></asp:TextBox>
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
          
                  <tr >
                  <td colspan="2" align="left" style="border:0px; width:100%; height:25px; font-size:15px; text-align:left; color:Red;" >
                  
                     <%-- <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>--%>
                  
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
                    onclick="btnSua_Click"  />

                &nbsp; <asp:Button ID="btnXoa" runat="server" Text="Xóa thông tin" 
                    onclick="btnXoa_Click" />
               <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
                &nbsp;<asp:Button ID="btnMoi" runat="server" 
                    Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" />
            &nbsp;&nbsp;
                Mã l&#7899;p: &nbsp;<asp:TextBox ID="txtMa" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnTim" runat="server" Text="Tìm" onclick="btnTim_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
            <asp:GridView ID="GrvLop" runat="server" Width="100%" AllowPaging="True" 
                  AutoGenerateColumns="false" BackColor="White" BorderColor="White" 
                  BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
                  GridLines="None" AutoGenerateSelectButton="True" 
                  onpageindexchanging="GrvLop_PageIndexChanging" 
                  onselectedindexchanging="GrvLop_SelectedIndexChanging" PageSize="100" 
                  >
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <Columns>
                            <asp:TemplateField HeaderText="Mã l&#7899;p" SortExpression="MaLop" Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaLop") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaLop") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên l&#7899;p" SortExpression="TenLop">
                                <ItemTemplate>
                                    <%#Eval("TenLop")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenLop")%>' ID="txtTenLop"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="S&#297; s&#7889;" SortExpression="SiSo">
                                <ItemTemplate>
                                    <%#Eval("SiSo")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SiSo")%>' ID="txtSiSo"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Mã h&#7879; &#273;ào t&#7841;o" SortExpression="MaHeDT" Visible="false">
                                <ItemTemplate>
                                    <%#Eval("MaHeDT")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("MaHeDT")%>' ID="txtMaHeDT"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="H&#7879; &#273;ào t&#7841;o" SortExpression="TenHeDT" Visible="true">
                                <ItemTemplate>
                                    <%#Eval("TenHeDT")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenHeDT")%>' ID="txtHeDaoTao"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Hình th&#7913;c &#273;ào t&#7841;o" SortExpression="HinhThucDT">
                                <ItemTemplate>
                                    <%#Eval("HinhThucDT")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("HinhThucDT")%>' ID="txtHTDT"></asp:TextBox></EditItemTemplate>
                                   <%-- <asp:Label runat="server" Text='<%#Bind("FormTraining")%>' ID=""></asp:Label></EditItemTemplate>--%>
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
                         <%--<FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <PagerSettings Visible="true" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" 
                    HorizontalAlign="Right" />--%>
                     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
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
