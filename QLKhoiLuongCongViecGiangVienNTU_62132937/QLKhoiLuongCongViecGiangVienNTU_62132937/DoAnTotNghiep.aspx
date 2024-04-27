<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DoAnTotNghiep.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.DoAnTotNghiep1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN &#272;&#7890; ÁN T&#7888;T NGHI&#7878;P</b></td>
            </tr>
          
            <tr>
                <td style="width:40% " class="theten">
                   Giáo viên</td>
                <td class="dieukhien">
                    <%-- <asp:DropDownList ID="ddlMaGV" AutoPostBack="true" Width="96%" Height="25px" runat="server">
                        <asp:ListItem Value="0">---Ch&#7885;n giáo viên---</asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:TextBox ID="txtTenGV" Enabled="false" Width="32%" runat="server"></asp:TextBox>
                    <asp:Label ID="lblMabang" runat="server" Visible="false" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 40%"  class="theten">
                    L&#7899;p</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlLop" runat="server" Height="27px" Width="186px">
                        <asp:ListItem Value="0">---Ch&#7885;n l&#7899;p---</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    S&#7889; l&#432;&#7907;ng &#273;&#7873; tài</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    S&#7889; &#273;&#7891; án ph&#7843;n bi&#7879;n</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtSoDoPhanBien" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 40%"  class="theten">
                    S&#7889; bu&#7893;i ch&#7845;m &#273;&#7891; án</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtSoBuoi" runat="server"></asp:TextBox> 
                </td>
            </tr>
              <tr>
                <td style="width: 40%"  class="theten">
                    N&#259;m h&#7885;c</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlNamHoc" runat="server" Height="27px" Width="157px" 
                       >
                        <asp:ListItem Value="0">---Ch&#7885;n n&#259;m h&#7885;c---</asp:ListItem>
                    </asp:DropDownList>
                   <%-- &nbsp;-&nbsp; <asp:DropDownList ID="ddlNamHoc1" runat="server" Height="23px" Width="127px">
                        <asp:ListItem Value="0">---Ch&#7885;n n&#259;m h&#7885;c---</asp:ListItem>
                    </asp:DropDownList>--%>
                   
                </td>
            </tr>
             <tr>
                <td style="width: 40%"  class="theten">
                   Ghí chú</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtGhichu" runat="server" Height="45px" TextMode="MultiLine" 
                        Width="355px"></asp:TextBox>   
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
                     &nbsp; 
                <asp:Button ID="btRefresh" runat="server" Text="Làm m&#7899;i" onclick="btRefresh_Click" 
                    />
                <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
           <asp:GridView ID="grvDoAn" runat="server" Width="100%" AllowPaging="True" 
                  AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                  onpageindexchanging="grvDoAn_PageIndexChanging" 
                  onselectedindexchanging="grvDoAn_SelectedIndexChanging">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                             <asp:TemplateField HeaderText="Mã " SortExpression="Ma" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("Ma") %>' ID="lblMa2"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("Ma") %>' ID="lblMa2"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã giáo viên" SortExpression="MaGV" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mã l&#7899;p" SortExpression="MaLop" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaLop") %>' ID="lblMa1"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaLop") %>' ID="lblMa1"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tên giáo viên" SortExpression="TenGV">
                                <ItemTemplate>
                                    <%#Eval("GiaoVien.TenGV")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GiaoVien.TenGV")%>' ID="txtGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="L&#7899;p" SortExpression="TenLop">
                                <ItemTemplate>
                                    <%#Eval("Lop.TenLop")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("Lop.TenLop")%>' ID="txtGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="S&#7889; &#273;&#7873; tài" SortExpression="SoDeTai">
                                <ItemTemplate>
                                    <%#Eval("SoDeTai")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoDeTai")%>' ID="txtGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="S&#7889; &#273;&#7891; án ph&#7843;n bi&#7879;n" SortExpression="SoDoAnPBien">
                                <ItemTemplate>
                                    <%#Eval("SoDoAnPBien")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoDoAnPBien")%>' ID="txtTenLop"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                               

                             <asp:TemplateField HeaderText="S&#7889; bu&#7893;i ch&#7845;m bài" SortExpression="SoBuoiChamBai">
                                <ItemTemplate>
                                    <%#Eval("SoBuoiChamBai")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoBuoiChamBai")%>' ID="txtSoBuoiChamBai"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="N&#259;m h&#7885;c" SortExpression="NamHoc">
                                <ItemTemplate>
                                    <%#Eval("NamHoc")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("NamHoc")%>' ID="txtGhiChu"></asp:TextBox></EditItemTemplate>
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
