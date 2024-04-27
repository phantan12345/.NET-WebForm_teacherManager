<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GiangDay.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.GiangDay1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN GI&#7842;NG D&#7840;Y</b></td>
            </tr>
          
            <tr>
                <td style="width:40% " class="theten">
                   Giáo viên</td>
                <td class="dieukhien">
                    <%-- <asp:DropDownList ID="ddlMaGV" AutoPostBack="true" Width="96%" Height="25px" runat="server">
                        <asp:ListItem Value="0">---Ch&#7885;n giáo viên---</asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:TextBox ID="txtTenGV"  Width="96%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 40%" class="theten">
                    Hình th&#7913;c</td>
                <td class="dieukhien" align="left">
                    <asp:RadioButton ID="optLyThuyet" Text="Lý thuy&#7871;t" runat="server" 
                        GroupName="1" AutoPostBack="true" 
                        oncheckedchanged="optLyThuyet_CheckedChanged"  />&nbsp;
                        <asp:RadioButton 
                        ID="optThucHanh" Text="Th&#7921;c hành"
                        runat="server" GroupName="1" AutoPostBack="True" oncheckedchanged="optThucHanh_CheckedChanged" />&nbsp;<asp:RadioButton 
                        ID="optProject" Text="TTCS/TTCN/Project"
                        runat="server" GroupName="1" AutoPostBack="True" 
                        oncheckedchanged="optProject_CheckedChanged" />&nbsp;<asp:RadioButton 
                        ID="optThucTapXiNghiep" Text="Th&#7921;c t&#7853;p xí nghi&#7879;p"
                        runat="server" GroupName="1" AutoPostBack="True" 
                        oncheckedchanged="optThucTapXiNghiep_CheckedChanged" />&nbsp;<asp:RadioButton 
                        ID="optThucTapSuPham" Text="Th&#7921;c t&#7853;p s&#432; ph&#7841;m"
                        runat="server" GroupName="1" AutoPostBack="True" 
                        oncheckedchanged="optThucTapSuPham_CheckedChanged" />
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    L&#7899;p</td>
                <td class="dieukhien" align="left">
                    <asp:DropDownList ID="ddlDSLop" AutoPostBack="true" Width="50%" Height="25px" 
                        runat="server" onselectedindexchanged="ddlDSLop_SelectedIndexChanged" >
                        <asp:ListItem Value="0">---Ch&#7885;n l&#7899;p---</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                    <asp:Label ID="lblMaLop" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>

              <tr>
                <td style="width: 40%" class="theten">
                    Môn h&#7885;c</td>
                <td class="dieukhien" align="left">
                     <asp:DropDownList ID="ddlMonHoc" AutoPostBack="true" Width="50%" Height="25px" 
                         runat="server" onselectedindexchanged="ddlMonHoc_SelectedIndexChanged">
                        <asp:ListItem Value="0">---Ch&#7885;n môn h&#7885;c---</asp:ListItem> 
                    </asp:DropDownList>
                    <asp:Label ID="lblThongBao1" runat="server" Text="Thông báo" Visible="False" ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>

             <tr>
                <td style="width: 40%" class="theten">
                  S&#7889; sinh viên</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtSoSV" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%"  class="theten">
                    N&#259;m h&#7885;c</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlNamHoc" AutoPostBack="false" runat="server" 
                        Height="27px" Width="163px" 
                        onselectedindexchanged="ddlNamHoc_SelectedIndexChanged">
                        <asp:ListItem Value="0">---Ch&#7885;n n&#259;m h&#7885;c---</asp:ListItem>
                    </asp:DropDownList>
                  <%--  &nbsp;-&nbsp; <asp:DropDownList ID="ddlNamHoc1" runat="server" Height="23px" Width="127px">
                        <asp:ListItem Value="0">---Ch&#7885;n n&#259;m h&#7885;c---</asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:Label ID="lblNamHoc" runat="server" Visible="false" Text="Label"></asp:Label>
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
                  <td colspan="2" align="left" style="border:0px; width:100%; height:5px; font-size:15px; text-align:left; color:Red;" >
                      <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
                   </td>
        </tr>
        <tr>
          <td colspan="2" align="center" class="dongdieukhien" valign="middle">
                <asp:Button ID="btnThem" runat="server" Text="Thêm m&#7899;i" 
                    onclick="btnThem_Click" />&nbsp;
               <%-- <asp:Button ID="btnSua" runat="server" Text="S&#7917;a thông tin" Height="25px" 
                    onclick="btnSua_Click" />
--%>
                &nbsp; <asp:Button ID="btnXoa" runat="server" Text="Xóa thông tin" 
                    onclick="btnXoa_Click" />
                <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
              <asp:GridView ID="GrvHDNCKH" runat="server" Width="100%" AllowPaging="True"
                  AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                  OnSelectedIndexChanging="GrvHDNCKH_SelectedIndexChanging" PageSize="100">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                            <asp:TemplateField HeaderText="Mã giáo viên" SortExpression="MaGV" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tên giáo viên" SortExpression="TenGV">
                                <ItemTemplate>
                                    <%#Eval("TenGV")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenGV")%>' ID="txtGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Mã l&#7899;p" SortExpression="MaLop" Visible="False">
                              <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaLop") %>' ID="lblMa1"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaLop") %>' ID="lblMa1"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="L&#7899;p d&#7841;y" SortExpression="TenLop">
                             <ItemTemplate>
                                    <%#Eval("TenLop")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTenLop" runat="server" Text='<%#Bind("TenLop")%>'></asp:TextBox>
                                 </EditItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="Mã môn" SortExpression="MaMon" 
                                Visible="false">
                                   <ItemTemplate>
                                       <asp:Label ID="lblMa2" runat="server" Text='<%#Bind("MaMon") %>'  ></asp:Label>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:Label ID="lblMa2" runat="server" Text='<%#Bind("MaMon") %>' ></asp:Label>
                                   </EditItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="Môn h&#7885;c" SortExpression="TenMon">
                                <ItemTemplate>
                                    <%#Eval("TenMon")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTenMon" runat="server" Text='<%#Bind("TenMon")%>'></asp:TextBox>
                                   </EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="N&#259;m h&#7885;c" SortExpression="NamHoc">
                                 <ItemTemplate>
                                     <%#Eval("NamHoc")%>
                                 </ItemTemplate>
                                  <EditItemTemplate>
                                    <asp:TextBox ID="txtNamHoc" runat="server" Text='<%#Bind("NamHoc")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                                <ItemTemplate>
                                    <%#Eval("TenMon")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGhiChu" runat="server" Text='<%#Bind("GhiChu")%>'></asp:TextBox>
                                </EditItemTemplate>
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
