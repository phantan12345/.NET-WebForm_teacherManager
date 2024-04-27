using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class GiangVien : System.Web.UI.Page
    {

        QUANLYGIANGVIENEntities2 tcm = new QUANLYGIANGVIENEntities2();
        ExecutedID ex=new ExecutedID();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {

                var memberID = Session["MemberID"].ToString();
                var dangnhap = Session["Dangnhap"].ToString();


                var tt = from c in tcm.TaiKhoan
                         where (c.TenDangNhap == dangnhap && c.MaGV.ToString() == memberID && c.MaGV == c.GiaoVien.MaGV)
                         select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
                foreach (var item in tt)
                {

                    if (Session["MemberID"].ToString() == item.MaGV.ToString() && item.Quyen == "Giáo viên")
                    {
                        //Response.Redirect("ThongTinCaNhan.aspx?url="+Request.Url.PathAndQuery);
                        Response.Redirect("Logout.aspx?url=" + Request.Url.PathAndQuery);
                    }
                }
            }
            else
            {
                if (Session.Contents["TrangThai"].ToString() == "ChuaDangNhap")
                    //Response.Redirect("Login.aspx");
                    Response.Redirect("Login.aspx?url=" + Request.Url.PathAndQuery);
            }
            if (!IsPostBack)
            {
                LoadBoMon();
                LoadChucDanh();
                LoadChucVu();
                LoadGridView();
                //ddlGioitinh.Items.Insert(0, new ListItem("--Chọn giới tính--", "0"));
            }
        }
        //Lam moi cac control
        public bool KiemTraRong()
        {
            if (txtMa.Text == "" || txtHoTen.Text == "" || txtNS.Text == "" || txtThamNien.Text == "" || drChucDanh.Text == "" || drChucVu.Text == "" || txtCMTND.Text == "" || txtEmail.Text == "")
            {
                return true;
            }
            else return false;
        }
        public void refresh1()
        {
            txtCMTND.Text = "";
            txtdiachi.Text = "";
            txtDT.Text = "";
            txtEmail.Text = "";
            txtGhiChu.Text = "";
            txtHoTen.Text = "";
            txtMa.Text = "";
            txtNS.Text = "";
            txtDT.Text = "";
            txtThamNien.Text = "";
            //drChucDanh.Text = "";
            //drChucVu.Text = "";
            //cboTrinhDo.Text = "";
        }
        //Load thong tin giang vien len gridview
        public void LoadGridView()
        {
            var GiangVien = from c in tcm.GiaoVien
                            select new { c.MaGV, c.TenGV, c.ChucVu.TenChucVu, c.TrinhDoHocVan, c.GioChuan.TenChucDanh, c.Email, c.DiaChi, c.NamVaoLam, c.BoMon.TenBoMon, c.GhiChu };
            DataTable dt = new DataTable();
            dt.Columns.Add("MaGV");
            dt.Columns.Add("TenGV");
            dt.Columns.Add("TenBoMon");
            dt.Columns.Add("TrinhDoHocVan");
            dt.Columns.Add("TenChucVu");
            dt.Columns.Add("Email");
            dt.Columns.Add("NamVaoLam");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("GhiChu");

            DataRow dr;
            foreach (var item in GiangVien)
            {
                dr = dt.NewRow();
                dr["MaGV"] = item.MaGV;
                dr["TenGV"] = item.TenGV;
                dr["TenBoMon"] = item.TenBoMon;
                dr["TrinhDoHocVan"] = item.TrinhDoHocVan;
                dr["TenChucVu"] = item.TenChucVu;
                dr["Email"] = item.Email;
                dr["NamVaoLam"] = item.NamVaoLam;
                dr["DiaChi"] = item.DiaChi;
                dr["GhiChu"] = item.GhiChu;
                dt.Rows.Add(dr);
            }
            grvGiangVien1.DataSource = dt;
            grvGiangVien1.DataBind();
        }
        //Load chuc vu vao drop chuc vu
        public void LoadChucVu()
        {
            var ChucVu = from c in tcm.ChucVu
                         select new {c.TenChucVu,c.MaChucVu};
            drChucVu.DataSource = ChucVu.ToList();
            drChucVu.DataTextField = "TenChucVu";
            drChucVu.DataValueField = "MaChucVu";
            drChucVu.DataBind();
            drChucVu.Items.Insert(0, new ListItem("--Chọn chức vụ--", "0"));


        }
        //Load thong tin Chuc Danh vao drop chuc danh
        public void LoadChucDanh()
        {
            var ChucDanh = from c in tcm.GioChuan
                           select new { c.TenChucDanh,c.MaChucDanh};
            drChucDanh.DataSource = ChucDanh.ToList();
            drChucDanh.DataTextField = "TenChucDanh";
            drChucDanh.DataValueField = "MaChucDanh";
            drChucDanh.DataBind();
            drChucDanh.Items.Insert(0, new ListItem("--Chọn chức danh--", "0"));
        }
        /// <summary>
        /// Xây dựng phương thức lấy về các bộ môn
        /// </summary>
        public void LoadBoMon()
        {
            var BoMon = from c in tcm.BoMon
                        select new { c.TenBoMon, c.MaBoMon };
            ddlBoMon.DataSource = BoMon.ToList();
            ddlBoMon.DataTextField = "TenBoMon";
            ddlBoMon.DataValueField = "MaBoMon";
            ddlBoMon.DataBind();
            ddlBoMon.Items.Insert(0, new ListItem("--Chọn bộ môn--", "0"));



        }
        //Load Thông tin giảng viên được chọn từ gridview lên các controls
        protected void grvGiangVien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lblMa = (Label)grvGiangVien1.Rows[e.NewSelectedIndex].FindControl("lblMa");
            GiaoVien tc = tcm.GiaoVien.SingleOrDefault(c => c.MaGV == lblMa.Text);
            txtMa.Text = tc.MaGV.ToString();
            txtHoTen.Text = tc.TenGV.ToString();
            //ddlGioitinh.Text = tc.GioiTinh.ToString();
            string[] ngaysinh = tc.NgaySinh.ToString().Split(' ');
            txtNS.Text = ngaysinh[0].ToString();
            txtCMTND.Text = tc.SoCMTND.ToString();
            //
            if (tc.TrinhDoHocVan == "Cao học")
            {
                cboTrinhDo.SelectedValue = "1";
                cboTrinhDo.SelectedItem.Text = tc.TrinhDoHocVan;
                lblMaHocVan.Text = tc.TrinhDoHocVan;
            }
            if (tc.TrinhDoHocVan == "Đại học")
            {
                cboTrinhDo.SelectedValue = "2";
                cboTrinhDo.SelectedItem.Text = tc.TrinhDoHocVan;
                lblMaHocVan.Text = tc.TrinhDoHocVan;
            }
            if (tc.TrinhDoHocVan == "Cao đẳng")
            {
                cboTrinhDo.SelectedValue = "3";
                cboTrinhDo.SelectedItem.Text = tc.TrinhDoHocVan;
                lblMaHocVan.Text = tc.TrinhDoHocVan;
            }
            if (tc.TrinhDoHocVan == "Trung cấp")
            {
                cboTrinhDo.SelectedValue = "4";
                cboTrinhDo.SelectedItem.Text = tc.TrinhDoHocVan;
                lblMaHocVan.Text = tc.TrinhDoHocVan;
            }
            if (tc.TrinhDoHocVan == "Thạc sỹ")
            {
                cboTrinhDo.SelectedValue = "5";
                cboTrinhDo.SelectedItem.Text = tc.TrinhDoHocVan;
                lblMaHocVan.Text = tc.TrinhDoHocVan;
            }
            //cboTrinhDo.SelectedItem.Text = tc.TrinhDoHocVan;
            //lblMaHocVan.Text = tc.TrinhDoHocVan;
            //
            if (tc.MaChucDanh == tc.GioChuan.MaChucDanh)
            {
                drChucDanh.SelectedValue = tc.MaChucDanh;
                drChucDanh.SelectedItem.Text = tc.GioChuan.TenChucDanh;

            }
            //drChucDanh.SelectedItem.Text = tc.GioChuan.TenChucDanh;
            //drChucDanh.SelectedValue = tc.MaChucDanh;
            //
            if (tc.MaChucVu == tc.ChucVu.MaChucVu)
            {
                drChucVu.SelectedValue = tc.MaChucVu;
                drChucVu.SelectedItem.Text = tc.ChucVu.TenChucVu;
            }

            //
            if (tc.MaBoMon == tc.BoMon.MaBoMon)
            {
                ddlBoMon.SelectedValue = tc.MaBoMon;
                ddlBoMon.SelectedItem.Text = tc.BoMon.TenBoMon;
            }


            if (tc.GioiTinh == "Nữ")
            {
                ddlGioitinh.SelectedValue = "1";
                ddlGioitinh.SelectedItem.Text = tc.GioiTinh;
            }
            if (tc.GioiTinh == "Nam")
            {
                ddlGioitinh.SelectedValue = "2";
                ddlGioitinh.SelectedItem.Text = tc.GioiTinh;
            }
            //ddlGioitinh.SelectedItem.Text = tc.GioiTinh;
            #region
            //var ChucDanh = from c in tcm.GioChuans where c.MaChucDanh==tc.MaChucDanh
            //               select c;
            //foreach (var item in ChucDanh)
            //{
            //    drChucDanh.DataTextField = item.TenChucDanh;
            //    drChucDanh.DataValueField = item.MaChucDanh;
            //}
            //var ChucVu = from c in tcm.ChucVus where c.MaChucVu==tc.MaChucVu
            //             select c;

            //foreach (var item1 in ChucVu)
            //{
            //    drChucVu.DataTextField = item1.TenChucVu;
            //    drChucVu.DataValueField = item1.MaChucVu;
            //}
            // // 
            //var BoMon = from c in tcm.BoMons
            //            where c.MaBoMon == tc.MaBoMon
            //            select c;
            //foreach (var item3 in BoMon)
            //{
            //    ddlBoMon.DataTextField = item3.TenBoMon;
            //    ddlBoMon.DataValueField = item3.MaBoMon;
            //}
            #endregion
            txtThamNien.Text = tc.NamVaoLam.ToString();
            txtEmail.Text = tc.Email.ToString();
            txtdiachi.Text = tc.DiaChi.ToString();
            txtDT.Text = tc.DienThoai.ToString();
            txtGhiChu.Text = tc.GhiChu.ToString();
            txtMa.Enabled = false;
        }
        //Xóa giảng viên được chọn trong gridview
        protected void grvGiangVien_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblMa = (Label)grvGiangVien1.Rows[e.RowIndex].FindControl("lblMa");
            GiaoVien tc = tcm.GiaoVien.SingleOrDefault(c => c.MaGV == lblMa.Text);
            tcm.GiaoVien.Remove(tc);
            tcm.SaveChanges();
            LoadGridView();
            txtHoTen.Focus();
            Response.Redirect("GiangVien.aspx");
        }
        protected void grvGiangVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvGiangVien1.PageIndex = e.NewPageIndex;
            LoadGridView();

        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                GiaoVien tc = tcm.GiaoVien.SingleOrDefault(c => c.MaGV == txtMa.Text);
                tc.MaGV = txtMa.Text;
                tc.TenGV = txtHoTen.Text;
                //
                tc.MaBoMon = ddlBoMon.SelectedValue.ToString();
                tc.GioiTinh = ddlGioitinh.SelectedItem.Text;
                tc.NgaySinh = DateTime.Parse(txtNS.Text);
                tc.SoCMTND = txtCMTND.Text;
                if (upAnh.HasFile)
                {
                    string t = "upload/";
                    tc.Anh = t + upAnh.FileName;
                    string path = Server.MapPath("..\\upload") + "\\" + upAnh.FileName;
                    upAnh.SaveAs(path);
                }
                else { tc.Anh = "anh"; }
                //tc.TrinhDoHocVan = cboTrinhDo.SelectedItem.Text;
                tc.TrinhDoHocVan = lblMaHocVan.Text;
                tc.MaChucDanh = drChucDanh.SelectedValue;
                tc.MaChucVu = drChucVu.SelectedValue;
                tc.NamVaoLam = txtThamNien.Text;
                tc.Email = txtEmail.Text;
                tc.DiaChi = txtdiachi.Text;
                tc.DienThoai = txtDT.Text;
                tc.GhiChu = txtGhiChu.Text;
                tcm.SaveChanges();
                LoadGridView();
                //refresh1();
                //lblThongBao.Text = "Đã cập nhật thành công";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Cập nhật thành công');", true);
                txtHoTen.Focus();
                Response.Redirect("GiangVien.aspx");

            }
            catch (Exception) { throw; }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtMa.Text = ex.LayMaGiangVien().ToString();
                if (KiemTraRong() == false)
                {
                    GiaoVien tc1 = new GiaoVien();
                    tc1.MaGV = txtMa.Text;
                    tc1.TenGV = txtHoTen.Text;
                    //
                    tc1.MaBoMon = ddlBoMon.SelectedValue.ToString();
                    tc1.GioiTinh = ddlGioitinh.SelectedItem.Text;
                    tc1.NgaySinh = DateTime.Parse(txtNS.Text);
                    tc1.SoCMTND = txtCMTND.Text;
                    if (upAnh.HasFile)
                    {
                        string t = "upload/";
                        tc1.Anh = t + upAnh.FileName;
                        string path = Server.MapPath("..\\upload") + "\\" + upAnh.FileName;
                        upAnh.SaveAs(path);
                    }
                    else { tc1.Anh = "anh"; }
                    //tc1.TrinhDoHocVan = cboTrinhDo.SelectedItem.Text ;
                    tc1.TrinhDoHocVan = lblMaHocVan.Text;
                    tc1.MaChucDanh = drChucDanh.SelectedValue;
                    tc1.MaChucVu = drChucVu.SelectedValue;
                    tc1.NamVaoLam = txtThamNien.Text;
                    tc1.Email = txtEmail.Text;
                    tc1.DiaChi = txtdiachi.Text;
                    tc1.DienThoai = txtDT.Text;
                    tc1.GhiChu = txtGhiChu.Text;
                    tcm.GiaoVien.Add(tc1);
                    tcm.SaveChanges();
                    LoadGridView();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('Bạn thêm thành công');", true);
                    //refresh1();
                    Response.Redirect("GiangVien.aspx");
                    txtMa.Focus();
                }
                else { ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('Bạn cần nhập đầy đủ thông tin.');", true); }
            }
            catch (Exception)
            { throw; }
        }
        protected void grvGiangVien1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnNhapExcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("NhapNhanVienTuExcel.aspx");

        }
        protected void btnMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("GiangVien.aspx");

        }
        protected void cboTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMaHocVan.Text = cboTrinhDo.SelectedItem.Text;
        }
        protected void btnTim_Click(object sender, EventArgs e)
        {
            var thongtinGV = from c in tcm.GiaoVien
                             where c.MaGV.Contains(txtTT.Text.Trim()) || c.TenGV.Contains(txtTT.Text.Trim()) || c.BoMon.TenBoMon.Contains(txtTT.Text.Trim()) || c.DiaChi.Contains(txtTT.Text.Trim())
                             select new { c.MaGV, c.TenGV, c.ChucVu.TenChucVu, c.TrinhDoHocVan, c.GioChuan.TenChucDanh, c.Email, c.DiaChi, c.NamVaoLam, c.BoMon.TenBoMon, c.GhiChu };
            grvGiangVien1.DataSource = thongtinGV;
            grvGiangVien1.DataBind();
        }
    }
}