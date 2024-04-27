<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TaoTaiKhoan.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.TaoTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ TÀI KHO&#7842;N -&gt;&nbsp;T&#7840;O TÀI KHO&#7842;N</b></td>
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
                    Ch&#7885;n giáo viên</td>
                <td class="dieukhien">
                    &nbsp;
                     <asp:DropDownList ID="ddlMaGV" runat="server" AppendDataBoundItems="True" 
                        AutoPostBack="true" Height="22px" 
                       Width="173px" onselectedindexchanged="ddlMaGV_SelectedIndexChanged">
                         <asp:ListItem Selected="True" Value="0">---Ch&#7885;n thành viên---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblMaGV" runat="server" Text="lblMagv" Visible="false"></asp:Label>
                </td>
            </tr>

              <tr>
                <td  class="theten">
                    Tên d&#259;ng nh&#7853;p</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtUsename" runat="server" Width="255px" ></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td  class="theten">
                    M&#7853;t kh&#7849;u     <td class="dieukhien">
                    <asp:TextBox ID="txtMatKhau" runat="server" Width="255px" MaxLength="200" TextMode="Password"
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="theten">
                    Quy&#7873;n</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlChonQuyen" runat="server" Height="23px" Width="201px" 
                        AppendDataBoundItems="true"
                     >
                        <asp:ListItem Value="0" Selected="True">---Ch&#7885;n quy&#7873;n---</asp:ListItem>
                        <asp:ListItem Value="1">Giáo viên</asp:ListItem>
                        <asp:ListItem Value="2">Giáo v&#7909;</asp:ListItem>
                    </asp:DropDownList>
               <%-- &nbsp;<asp:Label ID="lblMahdt" runat="server" Text="lblMahdt" Visible="false"></asp:Label>--%>
                </td>
            </tr>
              <tr>
                <td  class="theten">
                    Ngày t&#7841;o tài kho&#7843;n:</td>
                <td class="dieukhien" align="left">
                   <%-- <asp:Label ID="lblMahtdt" runat="server" Text="lblhtdt" Visible="true"></asp:Label>--%>
                    <asp:TextBox ID="txtNgaytaoTK" runat="server" Width="195px"></asp:TextBox>
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
                <asp:Button ID="btnThem" runat="server" Text="Thêm tài kho&#7843;n" onclick="btnThem_Click" 
                     />&nbsp;<asp:Button ID="btnXoaTK" runat="server" Text="Xóa tài kho&#7843;n" onclick="btnXoaTK_Click" 
                    />
               <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
                &nbsp;<asp:Button ID="btnMoi" runat="server" 
                    Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <asp:GridView ID="grvTaiKhoan" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                        ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" 
                        onselectedindexchanging="grvTaiKhoan_SelectedIndexChanging" PageSize="100">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="STT" Visible="false">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--<asp:TextBox ID="txtSTT" ReadOnly="true" runat="server"></asp:TextBox>--%>
                                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã thành viên" SortExpression="MaGV" 
                                Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblMa" runat="server" Text='<%#Bind("MaGV") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblMa" runat="server" Text='<%#Bind("MaGV") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên &#273;&#259;ng nh&#7853;p" SortExpression="TenDangNhap">
                                <ItemTemplate>
                                    <%#Eval("TenDangNhap")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTenDN" runat="server" ReadOnly="true" 
                                        Text='<%#Bind("TenDangNhap")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quy&#7873;n" SortExpression="Quyen">
                                <ItemTemplate>
                                    <%#Eval("Quyen")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQuyen" runat="server" Text='<%#Bind("Quyen")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Ngày t&#7841;o tk" SortExpression="NgayTaoTK">
                                <ItemTemplate>
                                    <%#Eval("NgayTaoTK")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNgayTaoTK" runat="server" Text='<%#Bind("NgayTaoTK")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                          <%--  <asp:CommandField EditText="S&#7917;a" HeaderText="Ch&#7885;n" InsertText="" 
                                ShowEditButton="True" />
                            <asp:CommandField HeaderText="Xóa" ShowDeleteButton="True" />--%>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
           
            </asp:Panel>
        <br />
        </td>
        </tr>
      
        </table>
    </center>
</asp:Content>


