<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HuongDanNCKH.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.HuongDanNCKH1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            border-bottom: 0.01px solid #5f9ae0;
            text-align: right;
            padding: 5px;
            width: 35%;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0px;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: 0px;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1"  Runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" style="width: 1000px" border="1px">
            <tr>
                <td colspan="2" align="center" class="dongtieude">
                    <b>QU&#7842;N LÝ THÔNG TIN -&gt;&nbsp;</b>H&#431;&#7898;NG D&#7850;N NGHIÊN C&#7912;U KHOA H&#7884;C</td>
            </tr>
          
            <tr>
                <td class="style1">
                   Giáo viên</td>
                <td class="dieukhien">
                    <asp:TextBox ID="txtGiaoVien" runat="server" Height="23px" Width="389px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="theten">
                   Mã &#273;&#7873; tài</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtMaDT" runat="server" Width="55%" MaxLength="200" Enabled="false"
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="theten">
                   Sinh viên n&#259;m</td>
                <td class="dieukhien" align="left">
                     <asp:DropDownList ID="ddlSVNam" AutoPostBack="false" Width="41%" Height="32px" 
                         runat="server">
                        <asp:ListItem Value="0">---Ch&#7885;n n&#259;m sinh viên theo h&#7885;c---</asp:ListItem>
                         <asp:ListItem Value="1">N&#259;m cu&#7889;i</asp:ListItem>
                         <asp:ListItem Value="2">Khác (1, 2, 3)</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td class="theten">
                    S&#7889; l&#432;&#7907;ng</td>
                <td class="dieukhien" align="left">
                    <asp:TextBox ID="txtSoLuong" runat="server" Width="31%" MaxLength="200" Enabled="true"
                        Height="23px"></asp:TextBox>
                </td>
            </tr>
                  <tr>
                <td  class="style1">
                    N&#259;m h&#7885;c</td>
                <td class="dieukhien">
                    <asp:DropDownList ID="ddlNamHoc" runat="server" Height="29px" Width="152px">
                        <asp:ListItem Value="0">--Ch&#7885;n n&#259;m --</asp:ListItem>
                    </asp:DropDownList>
                   <%-- &nbsp;- &nbsp;<asp:DropDownList ID="ddlNamHoc1" runat="server" Height="29px" Width="110px">
                        <asp:ListItem Value="0">--Ch&#7885;n n&#259;m --</asp:ListItem>
                    </asp:DropDownList>--%>
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
           
        <tr>
          <td colspan="2" align="center" class="dongdieukhien" valign="middle">
                <asp:Button ID="btnThem" runat="server" Text="Thêm m&#7899;i" Width="115px"
                    onclick="btnThem_Click" />&nbsp;
                <asp:Button ID="btnSua" runat="server" Text="S&#7917;a thông tin" 
                    onclick="btnSua_Click" />

               <%-- &nbsp; <asp:Button ID="btnXoa" runat="server" Text="Xóa thông tin" 
                    onclick="btnXoa_Click" />--%>
               <%//<asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" OnClick="lbtSave_Click"> <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>--%>
               <%-- <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link" OnClick="lbtTaoMoi_Click"> <img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" style="padding: 5px;" width="76%">
          <asp:Panel ID="Panel1" runat="server" Width="100%">
           <asp:GridView ID="GrvHDNCKH" runat="server" Width="100%" AllowPaging="true" 
                  AutoGenerateColumns="false" 
                  onselectedindexchanging="GrvHDNCKH_SelectedIndexChanging" 
                  onpageindexchanging="GrvHDNCKH_PageIndexChanging" 
                  onrowdeleting="GrvHDNCKH_RowDeleting" AutoGenerateSelectButton="True" PageSize="100" 
                  >
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                            <asp:TemplateField HeaderText="Mã" SortExpression="Ma" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("Ma") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("Ma") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tên giáo viên" SortExpression="TenGV">
                                <ItemTemplate>
                                    <%#Eval("TenGV")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenGV")%>' ID="txtTenGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="H&#432;&#7899;ng d&#7851;n sinh viên n&#259;m" SortExpression="SVNam">
                                <ItemTemplate>
                                    <%#Eval("SVNam")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SVNam")%>' ID="txtSVNam"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S&#7889; l&#432;&#7907;ng" SortExpression="SoLuong">
                                <ItemTemplate>
                                    <%#Eval("SoLuong")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("SoLuong")%>' ID="txtSoLuong"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="N&#259;m h&#7885;c" SortExpression="NamHoc">
                                <ItemTemplate>
                                    <%#Eval("NamHoc")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("NamHoc")%>' ID="txtNamHoc"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi chú" SortExpression="GhiChu">
                                <ItemTemplate>
                                    <%#Eval("GhiChu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GhiChu")%>' ID="txtGhiChu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                           
                            <%--<asp:CommandField InsertText="" ShowEditButton="True" EditText="S&#7917;a" HeaderText="Ch&#7885;n" />--%>
                            <asp:CommandField HeaderText="Xóa" ShowDeleteButton="true" />
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


