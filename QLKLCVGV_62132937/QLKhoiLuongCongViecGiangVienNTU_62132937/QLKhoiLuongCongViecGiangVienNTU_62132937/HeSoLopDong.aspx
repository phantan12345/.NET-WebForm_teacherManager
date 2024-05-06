<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HeSoLopDong.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.HeSoLopDong1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN H&#7878; S&#7888; L&#7898;P &#272;ÔNG</b></td>
            </tr>
           <%  
            //   <tr>
            //    <td colspan="2">
            //        <asp:Label ID="lblThongtin" runat="server" Font-Bold="true"></asp:Label>
            //    </td>
            //</tr>
            %>
             <tr>
                <td class="theten">
                    Mã h&#7879; s&#7889; l&#7899;p &#273;ông</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtMaHeSo" Width="60%" runat="server"></asp:TextBox>
</td>
            </tr>
                   <tr>
                 <td class="theten">
                    Hình th&#7913;c d&#7841;y</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlHinhThucDay" AutoPostBack="false" Height="25px" 
                        runat="server">
                        <asp:ListItem Value="0">---Ch&#7885;n hình th&#7913;c d&#7841;y---</asp:ListItem>
                        <asp:ListItem Value="1">Lý thuy&#7871;t</asp:ListItem>
                        <asp:ListItem Value="2">Th&#7921;c hành</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td class="hesolopdong" colspan="2" >
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T&#7915; &nbsp;<asp:TextBox ID="txtTu" runat="server" 
                        Width="120px" MaxLength="200" 
                        Height="23px" >
                         
                        </asp:TextBox>
                      <%--  <asp:RegularExpressionValidator ID="vlktKTraTu" runat="server" ErrorMessage="Không &#273;&#432;&#7907;c &#273;&#7875; tr&#7889;ng"
                    ControlToValidate="txtTu"></asp:RegularExpressionValidator>--%>
                        &nbsp; &nbsp; &#272;&#7871;n &nbsp;<asp:TextBox ID="txtDen" runat="server" Width="120px" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                      <%--  <asp:RegularExpressionValidator ID="vlktKtraDen" runat="server" ErrorMessage="Không &#273;&#432;&#7907;c &#273;&#7875; tr&#7889;ng"
                    ControlToValidate="txtDen"></asp:RegularExpressionValidator>--%>
                       
               
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
               
            </tr>
              <tr>
                <td class="theten">
                    H&#7879; s&#7889;</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtHeSo" runat="server" Width="50%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
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
                    &nbsp;
              
                <asp:Button ID="btnMoi" runat="server" Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" 
                   />
              
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
            <asp:GridView ID="GrvHeSoLopDong" runat="server" Width="100%" AllowPaging="true" 
                  AutoGenerateColumns="false" AutoGenerateSelectButton="True" 
                  onselectedindexchanging="GrvHeSoLopDong_SelectedIndexChanging" 
                  onpageindexchanging="GrvHeSoLopDong_PageIndexChanging" >
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                            <asp:TemplateField HeaderText="Mã HS l&#7899;p &#273;ông" SortExpression="MaHSLopDong" Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaHSLopDong") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaHSLopDong") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="T&#7915;" SortExpression="Tu">
                                <ItemTemplate>
                                    <%#Eval("Tu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("Tu")%>' ID="txtTu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#272;&#7871;n " SortExpression="Den">
                                <ItemTemplate>
                                    <%#Eval("Den")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("Den")%>' ID="txtDen"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                          

                             <asp:TemplateField HeaderText="H&#7879; s&#7889;" SortExpression="HeSo">
                                <ItemTemplate>
                                    <%#Eval("HeSo")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("HeSo")%>' ID="txtHeSo"></asp:TextBox>
                                    </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hình th&#7913;c d&#7841;y" SortExpression="HinhThucDay">
                                <ItemTemplate>
                                    <%#Eval("HinhThucDay")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("HinhThucDay")%>' ID="txtHTDay"></asp:TextBox>
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

