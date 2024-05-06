<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GiangVien.aspx.cs" Inherits="QLKhoiLuongCongViecGiangVienNTU_62132937.GiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border: 1px solid #6495ED" width="100%" cellpadding="0px" cellspacing="0px" >
     <tr>
            <td colspan="2" align="center" style="font-size: 12px; padding-bottom: 4px; padding-top: 4px;
                background-color: #1e90ff; height: 26px;">
                <b>QU&#7842;N TR&#7882; H&#7878; TH&#7888;NG -&gt;&nbsp;QU&#7842;N LÝ GI&#7842;NG VIÊN </b>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="theten">
                Mã gi&#7843;ng viên:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtMa" runat="server" Width="255px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="theten">
                H&#7885; tên:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtHoTen" runat="server" Width="255px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td  class="theten">
                B&#7897; môn
            </td>
            <td class="dieukhien">
                <asp:DropDownList ID="ddlBoMon" AutoPostBack= "false" Width="255px" runat="server">
                    <asp:ListItem Value="0">---Ch&#7885;n b&#7897; môn---</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToValidate="ddlBoMon" ErrorMessage="Hãy ch&#7885;n b&#7897; môn" 
                    ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
            </td>
        </tr>

         <tr>
            <td  class="theten">
                Trình &#273;&#7897;:
            </td>
            <td class="dieukhien">
                <asp:DropDownList ID="cboTrinhDo" AutoPostBack="true" runat="server" 
                    Width="255px" onselectedindexchanged="cboTrinhDo_SelectedIndexChanged" 
                    >
                    <asp:ListItem Value="0">---Ch&#7885;n trình &#273;&#7897; h&#7885;c v&#7845;n---</asp:ListItem>
                    <asp:ListItem Value="1">Cao h&#7885;c</asp:ListItem>
                    <asp:ListItem Value="2">&#272;&#7841;i h&#7885;c</asp:ListItem>
                    <asp:ListItem Value="3">Cao &#273;&#7859;ng</asp:ListItem>
                    <asp:ListItem Value="4">Trung c&#7845;p</asp:ListItem>
                    <asp:ListItem Value="5">Th&#7841;c s&#7929;</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblMaHocVan" runat="server" Text="Label" Visible="false"></asp:Label>
               <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="cboTrinhDo" ErrorMessage="Hãy ch&#7885;n trình &#273;&#7897; h&#7885;c v&#7845;n" 
                    ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
            </td>
        </tr>
        <tr>
            <td  class="theten">
                Ngày sinh:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtNS" runat="server" Width="195px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td  class="theten">
                Gi&#7899;i tính:
            </td>
            <td class="dieukhien" style="height: 26px">
                <asp:DropDownList ID="ddlGioitinh" runat="server" Height="22px" Width="201px">
                    <asp:ListItem Value="0">---Ch&#7885;n gi&#7899;i tính---</asp:ListItem>
                    <asp:ListItem Value="1">N&#7919;</asp:ListItem>
                    <asp:ListItem Value="2">Nam</asp:ListItem>
                </asp:DropDownList>
               <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="ddlGioitinh" ErrorMessage="Hãy ch&#7885;n gi&#7899;i tính" 
                    ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="theten">
                Email:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtEmail" runat="server" Width="255px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="vldtKTmail" runat="server" ErrorMessage="Hòm th&#432; không &#273;úng &#273;&#7883;nh d&#7841;ng"
                    ControlToValidate="txtEmail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="theten">
                S&#7889; &#273;i&#7879;n tho&#7841;i:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtDT" runat="server" Width="255px"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtDT" 
                    ErrorMessage="Ch&#7881; &#273;&#432;&#7907;c nh&#7853;p s&#7889;" MaximumValue="9" 
                    MinimumValue="0" ForeColor="Red"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
           <td class="theten">
                S&#7889; ch&#7913;ng minh th&#432; nhân dân:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtCMTND" runat="server" Width="255px"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" 
                    ControlToValidate="txtCMTND" ErrorMessage="Ch&#7881; &#273;&#432;&#7907;c nh&#7853;p s&#7889;" MaximumValue="9" 
                    MinimumValue="0" ForeColor="Red"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="theten">
                &#272;&#7883;a ch&#7881;:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtdiachi" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
         <tr>
           <td class="theten">
                N&#259;m vào làm:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtThamNien" runat="server" Width="255px"  ></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator3" runat="server" 
                    ControlToValidate="txtThamNien" ErrorMessage="(1940-2011)" MaximumValue="2011" 
                    MinimumValue="1940" ForeColor="Red"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
          <td class="theten">
               &#7842;nh &#273;&#7841;i di&#7879;n:
            </td>
            <td class="dieukhien">
                <asp:FileUpload ID="upAnh" runat="server" Width="216px" />
            </td>
        </tr>
         <tr>
           <td class="theten">
                Ch&#7913;c danh:
            </td>
            <td class="dieukhien">
                <asp:DropDownList ID="drChucDanh" runat="server" Width="255px">
                    <asp:ListItem Value="0">---Ch&#7885;n ch&#7913;c danh---</asp:ListItem>
                    <asp:ListItem Value="1">Gi&#7843;ng viên</asp:ListItem>
                    <asp:ListItem Value="1">T&#7853;p s&#7921;</asp:ListItem>
                </asp:DropDownList>
              <%--  <asp:CompareValidator ID="CompareValidator5" runat="server" 
                    ControlToValidate="drChucDanh" ErrorMessage="Hãy ch&#7885;n ch&#7913;c danh "
                    ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
            </td>
        </tr>
         <tr>
            <td class="theten">
                Ch&#7913;c v&#7909;:
            </td>
           <td class="dieukhien">
                <asp:DropDownList ID="drChucVu" runat="server" Width="255px">
                     <asp:ListItem Value="0">---Ch&#7885;n ch&#7913;c v&#7909;---</asp:ListItem>
                    <%-- <asp:ListItem Value="1">Không có ch&#7913;c v&#7909;</asp:ListItem>--%>
                </asp:DropDownList>
               <%-- <asp:CompareValidator ID="CompareValidator4" runat="server" 
                    ControlToValidate="drChucVu" ErrorMessage="Hãy ch&#7885;n ch&#7913;c v&#7909;"
                    ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
            </td>
        </tr>
         <tr>
           <td class="theten">
                Ghi chú:
            </td>
            <td class="dieukhien">
                <asp:TextBox ID="txtGhiChu" runat="server" Width="258px" Height="50px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" style="color: Red; font-size: 15px; font-weight: bold;
                width: 100%; height: 25px;">
                <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="dongdieukhien" >
                    <asp:Button ID="btnThem" runat="server" Text="Thêm gi&#7843;ng viên" 
                        onclick="btnThem_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnLuu" runat="server" Text="L&#432;u thông tin" 
                        onclick="btnLuu_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnNhapExcel" runat="server" Text="Nh&#7853;p t&#7915; excel" 
                        onclick="btnNhapExcel_Click" />
                    <%--<asp:LinkButton ID="lbtThemTV" runat="server" CssClass="Link">  <img src="Image/user.png" style="border:0px;"/><b>&nbsp;Thêm thành viên</b></asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="lbtSave" runat="server" CssClass="Link" > <img src="Image/save.png" style="border:0px;" /><b>&nbsp;L&#432;u thông tin</b></asp:LinkButton>
                <asp:LinkButton ID="lbtTaoMoi" runat="server" CssClass="Link"><img src="Image/New.gif" style="border:0px;" /><b>&nbsp;T&#7841;o m&#7899;i</b></asp:LinkButton>--%>
                   &nbsp; <asp:Button ID="btnMoi" runat="server" Text="Nh&#7853;p m&#7899;i" Width="95px" 
                        onclick="btnMoi_Click" />
                    &nbsp; Thông tin:&nbsp;<asp:TextBox ID="txtTT" Width="200px" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnTim" runat="server" Text="Tìm" 
                        onclick="btnTim_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="padding: 5px;" width="76%">
                <br />
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                        <asp:GridView ID="grvGiangVien1" runat="server" Width="100%" 
                        AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="1000" 
                        onselectedindexchanging="grvGiangVien_SelectedIndexChanging" 
                        onpageindexchanging="grvGiangVien_PageIndexChanging" 
                            onrowdeleting="grvGiangVien_RowDeleting" AutoGenerateSelectButton="True" onselectedindexchanged="grvGiangVien1_SelectedIndexChanged" 
                         >
                       
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã gi&#7843;ng viên" SortExpression="MaGV" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaGV") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="H&#7885; và Tên" SortExpression="HoVaTen">
                                <ItemTemplate>
                                    <%#Eval("TenGv")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenGv")%>' ID="txtHoTen"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="B&#7897; môn" SortExpression="TenBoMon">
                                <ItemTemplate>
                                    <%#Eval("TenBoMon")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenBoMon")%>' ID="txtTenBoMon"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="TrinhDoHocVan" HeaderText="Trình &#273;&#7897;" 
                                SortExpression="TrinhDoHocVan" />
                                 
                                 <asp:TemplateField HeaderText="Ch&#7913;c v&#7909;" SortExpression="TenChucVu">
                                <ItemTemplate>
                                    <%#Eval("TenChucVu")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TenChucVu")%>' ID="txtTenCHucVu"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <ItemTemplate>
                                    <%#Eval("Email")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("Email")%>' ID="txtmail"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>      
                            <asp:BoundField DataField="NamVaoLam" HeaderText="N&#259;m vào làm" 
                                SortExpression="NamVaoLam" />
                                 <asp:TemplateField HeaderText="&#272;&#7883;a ch&#7881;" 
                                SortExpression="DiaChi">
                                <ItemTemplate>
                                    <%#Eval("DiaChi")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("DiaChi")%>' ID="txtdiachi"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Xóa" ShowDeleteButton="True" />
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

