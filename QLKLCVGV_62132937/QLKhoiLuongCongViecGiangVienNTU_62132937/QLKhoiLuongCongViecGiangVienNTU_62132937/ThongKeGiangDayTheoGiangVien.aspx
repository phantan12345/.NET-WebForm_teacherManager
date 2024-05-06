<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThongKeGiangDayTheoGiangVien.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.ThongKeGiangDayTheoGiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>TH&#7888;NG KÊ GI&#7900; D&#7840;Y GI&#7842;NG VIÊN</b></td>
            </tr>
             <tr>
                <td class="theten">
                    Ch&#7885;n gi&#7843;ng viên</td>
                <td class="dieukhien">
                    <%--<asp:DropDownList ID="cboGiangVien" runat="server" AutoPostBack="false" 
                        Height="25px" Width="169px" 
                        onselectedindexchanged="cboGiangVien_SelectedIndexChanged" >
                    </asp:DropDownList>--%>
                    <asp:DropDownList ID="ddlMaGV" AutoPostBack="true" Width="200px" Height="25px" runat="server" 
                        onselectedindexchanged="ddlMaGV_SelectedIndexChanged">
                        <asp:ListItem Value="0">---Ch&#7885;n môn h&#7885;c---</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtTenGV" runat="server" Width="253px"></asp:TextBox>
                    <%--<asp:TextBox ID="txtMaBoMon" runat="server" Width="169px" MaxLength="200" 
                        Height="23px"></asp:TextBox>--%>
                    <asp:Label ID="lblMa" runat="server" Text="lblMaGV" Visible="false"></asp:Label>&nbsp;&nbsp;
                    <asp:Label ID="lblNamHoc" runat="server" Text="N&#259;m H&#7885;c"></asp:Label>  &nbsp; 
                    <asp:DropDownList ID="ddlNamHoc" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            
        <tr>
            <td colspan="2" align="center" class="dongdieukhien" valign="middle">
                <asp:Button ID="btThongKe" runat="server" Text="Th&#7889;ng kê" onclick="btThongKe_Click" 
                    />
                &nbsp; 
                <asp:Button ID="btnThoat" runat="server" Text="Thoát" Width="89px" onclick="btnThoat_Click" 
                     />
            &nbsp;<asp:Button ID="btnXuatExcel" runat="server" Text="Xu&#7845;t excel" 
                    onclick="btnXuatExcel_Click" />
            </td>
        </tr>
             <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
         
          <asp:Panel ID="Panel1" runat="server" Width="100%">
         <div style="text-align:left; font-size:16px; font-weight:bold" >
          <asp:Label ID="Label2" runat="server" Visible="false" Font-Size="16px" Font-Bold="true" Text=" I. GI&#7900; GI&#7842;NG D&#7840;Y"></asp:Label>
         </div>
              <asp:GridView ID="GrvThongKeTheGiangVien" runat="server" AutoGenerateColumns="False" 
                  Width="99%"  AllowPaging="True" 
                  BackColor="White" 
                  BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                  onpageindexchanging="GrvThongKeTheGiangVien_PageIndexChanging" 
                  PageSize="100" Enabled="true"
                 >
               <Columns>
                            <asp:TemplateField HeaderText="H&#7885;c ph&#7847;n" SortExpression="TenMon" 
                                Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TenMon") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TenMon") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S&#7889; ti&#7871;t" SortExpression="SoTiet">
                                <ItemTemplate>
                                    <%#Eval("SoTiet")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoTiet")%>' ID="txtTenChucVu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
            
                             <asp:TemplateField HeaderText="Tên L&#7899;p" SortExpression="TenLop">
                                <ItemTemplate>
                                    <%#Eval("TenLop")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenLop")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S&#7929; s&#7889;" SortExpression="SiSo">
                            <ItemTemplate>
                                    <%#Eval("SiSo")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SiSo")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="H&#7879; S&#7889; " SortExpression="hs">
                            <ItemTemplate>
                                    <%#Eval("hs")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("hs")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S&#7889; gi&#7901; &#273;&#432;&#7907;c tính" SortExpression="SOGIODAY">
                            <ItemTemplate>
                                    <%#Eval("SOGIODAY")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SOGIODAY")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                            <ItemTemplate>
                                    <%#Eval("GhiCHu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiCHu")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                  <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                  <HeaderStyle BackColor="#4682b4" Font-Bold="True" ForeColor="#FFFFCC" />
                  <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                  <RowStyle BackColor="White" ForeColor="#330099" VerticalAlign="Middle" />
                  <SelectedRowStyle BackColor="#FFCC66" VerticalAlign="Middle" Font-Bold="True" ForeColor="#663399" />
                  <SortedAscendingCellStyle BackColor="#FEFCEB" />
                  <SortedAscendingHeaderStyle BackColor="#AF0101" />
                  <SortedDescendingCellStyle BackColor="#F6F0C0" />
                  <SortedDescendingHeaderStyle BackColor="#7E0000" />

              </asp:GridView>
            
                  <div style="text-align:left; ">
                    <asp:Label ID="Label3" runat="server" Text="T&#7893;ng c&#7897;ng 1:  " 
                  Font-Bold="True" Enabled="False" Font-Size="15px" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Label ID="lblTong1" runat="server" 
                  Font-Bold="True"  Enabled="False" Font-Size="15px" Visible="False" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  </div>
                  <br />
           <div style="text-align:left"> 
           <asp:Label ID="Label1" runat="server" Font-Bold="true" Visible="false" Font-Size="16px" Text="II. GI&#7900; QUY &#272;&#7892;I CÁC HO&#7840;T &#272;&#7896;NG KHÁC"></asp:Label>
           </div>
                 
              <asp:GridView ID="grvViecNgoaiGio" runat="server" AutoGenerateColumns="False" 
                  Width="99%"  AllowPaging="True" 
                  BackColor="White" 
                  BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 >
               <Columns>
                            <asp:TemplateField HeaderText="N&#7897;i dung công vi&#7879;c" SortExpression="TenMon" 
                                Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TenMon") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TenMon") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S&#7889; gi&#7901; &#273;&#432;&#7907;c tính" SortExpression="SOGIODAY">
                                <ItemTemplate>
                                    <%#Eval("SOGIODAY")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SOGIODAY")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
            
                             <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                                <ItemTemplate>
                                    <%#Eval("GhiChu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiCHu")%>' ID="txtGhiCHu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
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
              <div style="text-align:left">
                 <asp:Label ID="Label4" runat="server" Font-Size="15px" Text="T&#7893;ng c&#7897;ng 2:  " 
                  Font-Bold="True" Enabled="False" Visible="False"></asp:Label>
              <asp:Label ID="lblTong2" runat="server" Font-Size="15px"
                  Font-Bold="True" Enabled="False" Visible="False" ></asp:Label>
              </div>
         <br />
            <div style="text-align:left;">
                <asp:Label ID="Label5" runat="server" Font-Size="18px" Text="III.THANH TOÁN GI&#7900; GI&#7842;NG D&#7840;Y" 
                  Font-Bold="True" Visible="False"></asp:Label><br />
              <asp:Label ID="Label6" Visible="False" Font-Size="15px" runat="server" Text="T&#7893;ng s&#7889; gi&#7901; chu&#7849;n h&#7885;c k&#7923;:  "></asp:Label>
              <asp:Label  ID="lbltonggiochuan" Visible="False" Font-Bold="true"  Font-Size="15px" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="Label8" Visible="False" runat="server"  Font-Size="15px" Text="S&#7889; gi&#7901; chu&#7849;n:  "></asp:Label>
              <asp:Label ID="lblGioChuan" Visible="False" runat="server"  Font-Bold="true"  Font-Size="15px" Text=""></asp:Label><br />
              <asp:Label ID="Label10" Visible="False" runat="server"  Font-Size="15px" Text="S&#7889; gi&#7901; v&#432;&#7907;t quá:  "></asp:Label>
              <asp:Label ID="lblGioVuotQua" Visible="False"   Font-Bold="true"  Font-Size="15px" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblMucThanhToan" runat="server" Font-Size="15px" 
                    Text="M&#7913;c thanh toán: " Visible="false" ></asp:Label>
                <asp:Label ID="lblThanhToan" runat="server" Font-Bold="true" Font-Size="15px" 
                    Text="" Visible="False"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblThanhTien" runat="server" Font-Size="15px" 
                    Text="Thành ti&#7873;n:  " Visible="false"></asp:Label>
                <asp:Label ID="lblTien" runat="server" Font-Bold="true" Font-Size="15px" 
                    Text="" Visible="False"></asp:Label>
            </div>
                
            </asp:Panel>
        <br />
        </td>
        </tr>
      
        </table>
    </center>
   
</asp:Content>


