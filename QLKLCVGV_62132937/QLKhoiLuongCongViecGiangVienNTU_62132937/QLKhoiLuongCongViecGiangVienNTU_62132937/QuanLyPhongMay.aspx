<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuanLyPhongMay.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.QuanLyPhongMay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;QU&#7842;N LÝ PHÒNG MÁY</b></td>
            </tr>
            <tr>
                <td style="width:40% " class="theten">
                   Mã qu&#7843;n lý</td>
                <td class="dieukhien">
                     <asp:TextBox ID="txtMa" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:40% " class="theten">
                   Giáo viên</td>
                <td class="dieukhien">
                     <asp:TextBox ID="txtGV" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    S&#7889; phòng máy qu&#7843;n lý</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtSoLuongPM" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%"  class="theten">
                    N&#259;m h&#7885;c</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlNamHoc" runat="server" Height="27px" Width="157px">
                        <asp:ListItem Value="0">---Ch&#7885;n n&#259;m h&#7885;c---</asp:ListItem>
                    </asp:DropDownList>
                  <%--  &nbsp;-&nbsp; <asp:DropDownList ID="ddlNamHoc1" runat="server" Height="16px" Width="127px">
                        <asp:ListItem Value="0">---Ch&#7885;n n&#259;m h&#7885;c---</asp:ListItem>
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
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
           <asp:GridView ID="GrvQLPM" runat="server" Width="100%" AllowPaging="True" 
                  AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                  onselectedindexchanging="GrvQLPM_SelectedIndexChanging" 
                  onpageindexchanging="GrvQLPM_PageIndexChanging"  
                  >
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                           
                            <asp:TemplateField HeaderText="Mã qu&#7843;n lý" SortExpression="MaQL">
                            <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaQL") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaQL") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                           
                           <%-- <asp:TemplateField HeaderText="Mã giáo viên" SortExpression="MaGV" 
                                Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="txtMaGV"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="txtMaGV"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Giáo viên" SortExpression="TenGV">
                                <ItemTemplate>
                                    <%#Eval("TenGV")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenGV")%>' ID="txtTenGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="S&#7889; l&#432;&#7907;ng phòng máy qu&#7843;n lý" SortExpression="SoLuongPM">
                                <ItemTemplate>
                                    <%#Eval("SoLuongPM")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoLuongPM")%>' ID="txtTenPM"></asp:TextBox>
                                    </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="N&#259;m h&#7885;c" SortExpression="NamHoc">
                                <ItemTemplate>
                                    <%#Eval("NamHoc")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("NamHoc")%>' ID="txtTenPM"></asp:TextBox></EditItemTemplate>
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

