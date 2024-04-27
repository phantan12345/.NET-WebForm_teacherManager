<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NhapNhanVienTuExcel.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.NhapNhanVienTuExcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table style="border: 1px solid #6495ED" width="100%" cellpadding="0px" cellspacing="0px" >
        
        <tr>
            <td colspan="2" class="dongdieukhien" >
                <asp:FileUpload ID="fulExcel" runat="server" />&nbsp;&nbsp;
                    <asp:Button ID="btnLoadExcel" runat="server" Text="Load File Excel" 
                        onclick="btnLoadExcel_Click"  />&nbsp;&nbsp;
                          <asp:Button ID="btnCapNhatVaoCSDL" runat="server" 
                    Text="Thêm gi&#7843;ng viên" onclick="btnCapNhatVaoCSDL_Click"  />&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="padding: 5px;" width="76%">
                <br />
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                  <%--  <asp:GridView ID="grvThanhvien" runat="server" AutoGenerateColumns="False" Width="760px"
                        DataKeyNames="MemberID" OnRowUpdating="grvThanhvien_RowUpdating" 
                        OnRowEditing="grvThanhvien_RowEditing" OnRowDeleting="grvThanhvien_RowDeleting"
                        AllowPaging="True" CellPadding="5" ForeColor="#333333" GridLines="None"
                        Height="220px" 
                        >--%>
                        <asp:GridView ID="grvGiangVien1" runat="server" Width="100%" 
                        AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="5" 
                         >
                       
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã gi&#7843;ng viên" SortExpression="MaGV">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên Giáo Viên" SortExpression="TenGV">
                                <ItemTemplate>
                                    <%#Eval("TenGV")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenGV")%>' ID="txtTenGV"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gi&#7899;i tính" SortExpression="GioiTinh">
                                <ItemTemplate>
                                    <%#Eval("GioiTinh")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("GioiTinh")%>' ID="txtGioiTinh"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày Sinh" SortExpression="NgaySinh">
                                <ItemTemplate>
                                    <%#Eval("NgaySinh")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("NgaySinh")%>' ID="txtNgaySinh"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>                           
                            <asp:BoundField DataField="SoCMTND" HeaderText="S&#7889; CMTND" 
                                SortExpression="SoCMTND" />
                            <asp:BoundField DataField="Anh" HeaderText="&#7842;nh" 
                                SortExpression="Anh" />
                            <asp:BoundField DataField="TrinhDoHocVan" HeaderText="Trình &#273;&#7897; h&#7885;c v&#7845;n" 
                                SortExpression="TrinhDoHocVan" />
                            <asp:BoundField DataField="MaChucDanh" HeaderText="Ch&#7913;c Danh" 
                                SortExpression="MaChucDanh" />
                            <asp:BoundField DataField="MaChucVu" HeaderText="Ch&#7913;c v&#7909;" 
                                SortExpression="MaChucVu" />
                            <asp:BoundField DataField="NamVaoLam" HeaderText="N&#259;m vào làm" 
                                SortExpression="NamVaoLam" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="DiaChi" HeaderText="&#272;&#7883;a ch&#7881;" 
                                SortExpression="DiaChi" />
                            <asp:BoundField DataField="GhiChu" HeaderText="Ghi chú" 
                                SortExpression="GhiChu" />
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
</asp:Content>

