<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HeDaoTao.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.HeDaoTao1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
        <table cellpadding="0" cellspacing="0" style="width: 100%" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;THÔNG TIN H&#7878; &#272;ÀO T&#7840;O</b></td>
            </tr>
          
            <tr>
                <td style="width:40% " class="theten">
                    Mã h&#7879; &#273;ào t&#7841;o</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtMaHeDT" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    Tên h&#7879; &#273;ào t&#7841;o</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtTenHeDT" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="width: 40%" class="theten">
                    S&#7889; bu&#7893;i trên 1 &#272;VHT</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtSoBuoiCho1DVHT" runat="server" Width="63%" MaxLength="200" 
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 40%"  class="theten">
                    Mô t&#7843;</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtMota" runat="server" Height="42px" MaxLength="30" 
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
            &nbsp;<asp:Button ID="btnMoi" runat="server" Text="Nh&#7853;p m&#7899;i" onclick="btnMoi_Click" 
                   />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
           <asp:GridView ID="GrvHeDT" runat="server" Width="100%" AllowPaging="true" 
                  AutoGenerateColumns="false" 
                  
                  AutoGenerateSelectButton="True" 
                  onselectedindexchanging="GrvHeDT_SelectedIndexChanging" 
                  onpageindexchanging="GrvHeDT_PageIndexChanging" PageSize="100" 
                   >
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                            <asp:TemplateField HeaderText="Mã h&#7879; &#273;ào t&#7841;o" SortExpression="MaHDT" Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaHDT") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaHDT") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên h&#7879; &#273;ào t&#7841;o" SortExpression="TenHeDT">
                                <ItemTemplate>
                                    <%#Eval("TenHeDT")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenHeDT")%>' ID="txtTenHeDT"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="S&#7889; bu&#7893;i trên 1 &#272;VHT" SortExpression="SoBuoiTren1DVHocTrinh">
                                <ItemTemplate>
                                    <%#Eval("SoBuoiTren1DVHocTrinh")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoBuoiTren1DVHocTrinh")%>' ID="txtSoBuoiTrenDVHT"></asp:TextBox></EditItemTemplate>
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

