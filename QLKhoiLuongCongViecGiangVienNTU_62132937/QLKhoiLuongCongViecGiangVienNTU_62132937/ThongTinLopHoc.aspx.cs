using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class ThongTinLopHoc : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 db = new QUANLYGIANGVIENEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {
                var memberID = Session["MemberID"].ToString();
                var dangnhap = Session["Dangnhap"].ToString();


                var tt = from c in db.TaiKhoan
                         where (c.TenDangNhap == dangnhap && c.MaGV.ToString() == memberID && c.MaGV == c.GiaoVien.MaGV)
                         select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
                GiaoVien gv = db.GiaoVien.Single(c => c.MaGV == memberID);
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
                //LayHinhThucDT();
                LoadHeDaoTao();
                LoadGrid();
                //ddlChonLopLT.Enabled = false;
                //txtTenLop.Enabled = false;
                //ddlHeDT.Enabled = false;
                //ddlHTDT.Enabled = false;
            }
        }
        /// <summary>
        /// Xây dựng phương thức kiểm tra trùng mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public bool KiemTraTrungMa(string malop)
        {
            bool kt = false;
            var lop = from c in db.Lop
                      select c;
            foreach (Lop cl in lop)
            {
                if (malop == cl.MaLop.ToString())
                {
                    kt = true;
                }
            }
            return kt;

        }
        /// <summary>
        /// Lấy tên hệ đào tạo
        /// </summary>
        public void LoadHeDaoTao()
        {
            var HeDT = (from c in db.HeDaoTao
                        select new { c.MaHDT, c.TenHeDT }).Distinct();
            ddlHeDT.DataSource = HeDT.ToList();
            ddlHeDT.DataTextField = "TenHeDT";
            ddlHeDT.DataValueField = "MaHDT";
            ddlHeDT.DataBind();

        }
        /// <summary>
        /// Phương thức kiểm tra rỗng
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Xây dựng phương thức kiểm tra rỗng
        /// </summary>
        /// <returns></returns>
        public bool KiemTraRong()
        {
            bool kt = false;
            if (txtTenLop.Text == "" || txtSiSo.Text == "" || txtMaLop.Text == "")
            //if (txtMaLop.Text == "")
            {
                return true;
            }
            else
            {
                if (txtTenLop.Text == "" && txtSiSo.Text == "" && txtMaLop.Text == "")
                {
                    return false;
                }

            }
            return kt;

        }

        /// <summary>
        /// Làm rỗng các ô text
        /// </summary>
        public void Refresh1()
        {
            txtMaLop.Text = ""; txtTenLop.Text = "";
            txtSiSo.Text = ""; txtGhiChu.Text = "";
            //ddlHeDT.SelectedValue = "0"; ddlHTDT.SelectedValue = "0";
            ddlChonLopLT.SelectedValue = "0";
            ckThucHanh.Checked = false;
            ckLyThuyet.Checked = false;
            //ddlHeDT.SelectedValue = "0";
            //ddlHTDT.SelectedValue = "0";

        }
        /// <summary>
        /// Phương thức load thông tin lớp lên gridview
        /// </summary>
        public void LoadGrid()
        {
            var thongtinlop = from c in db.Lop
                              select new { c.MaHeDT, c.MaLop, c.TenLop, c.SiSo, c.HinhThucDT, c.GhiChu, c.HeDaoTao.TenHeDT, };
            GrvLop.DataSource = thongtinlop.ToList();
            GrvLop.DataBind();
        }
        /// <summary>
        /// Lấy về các lớp học lý thuyết
        /// </summary>
        public void LoadLopLyThuyet()
        {
            var lophoclt = (db.st_LayLopLyThuyet()).Distinct();
            ddlChonLopLT.DataSource = lophoclt;
            ddlChonLopLT.DataValueField = "MaLop";
            ddlChonLopLT.DataTextField = "MaLop";
            ddlChonLopLT.DataBind();
        }

        /// <summary>
        /// xây dựng phương thức lấy thôgn tin chi tiết của lớp lý thuyết
        /// </summary>
        public void LayThongThinChiTiet()
        {
            var thongtin = (from c in db.Lop
                            where c.HeDaoTao.MaHDT == c.MaHeDT && c.MaLop == ddlChonLopLT.SelectedValue.ToString()
                            select new { c.MaHeDT, c.TenLop }).Distinct();
            foreach (var item in thongtin)
            {
                lblMahdt.Text = item.MaHeDT.ToString();
                txtTenLop.Text = item.TenLop;

            }

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraRong() == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Không được để trống mã hoặc tên hoặc sĩ số');", true);

                }
                if (ckThucHanh.Checked == true)
                {

                    //ddlChonLopLT.Visible = false;
                    //lblChonLopLT.Visible = false;
                    //LoadLopLyThuyet();

                    if (KiemTraTrungMa(txtMaLop.Text) == false)
                    {

                        if (KiemTraRong() == false)
                        {
                            Lop lop = new Lop();
                            lop.MaLop = txtMaLop.Text;
                            //lop.MaHeDT = ddlHeDT.SelectedValue.ToString();
                            lop.MaHeDT = lblMahdt.Text;
                            lop.TenLop = txtTenLop.Text;
                            lop.SiSo = int.Parse(txtSiSo.Text);
                            lop.GhiChu = txtGhiChu.Text;
                            lop.HinhThucDT = ddlHTDT.SelectedItem.Text;
                            db.Lop.Add(lop);
                            db.SaveChanges();
                            LoadGrid();
                            Refresh1();
                            Response.Redirect("ThongTinLopHoc.aspx");
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Mã bạn nhập đã tồn tại!');", true);
                    }
                }
                if (ckLyThuyet.Checked == true)
                {

                    if (KiemTraTrungMa(txtMaLop.Text) == false)
                    {

                        if (KiemTraRong() == false)
                        {
                            Lop lop = new Lop();
                            lop.MaLop = txtMaLop.Text;
                            //lop.MaHeDT = ddlHeDT.SelectedValue.ToString();
                            lop.MaHeDT = lblMahdt.Text;
                            lop.TenLop = txtTenLop.Text;
                            lop.SiSo = int.Parse(txtSiSo.Text);
                            lop.GhiChu = txtGhiChu.Text;
                            lop.HinhThucDT = ddlHTDT.SelectedItem.Text;
                            db.Lop.Add(lop);
                            db.SaveChanges();
                            LoadGrid();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);
                            Refresh1();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Mã bạn nhập đã tồn tại!');", true);
                    }
                }

            }


            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Không được để trống thông tin');", true);

            }
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenLop.Enabled = true;
                ddlHeDT.Enabled = true;
                ddlHTDT.Enabled = true;
                Lop lop = db.Lop.SingleOrDefault(c => c.MaLop == txtMaLop.Text);
                lop.MaHeDT = lblMahdt.Text;
                lop.HinhThucDT = ddlHTDT.SelectedItem.Text;
                lop.TenLop = txtTenLop.Text;
                lop.SiSo = Convert.ToInt32(txtSiSo.Text);
                lop.GhiChu = txtGhiChu.Text;
                db.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn sửa thành công');", true);
                //Refresh1();
                Response.Redirect("ThongTinLopHoc.aspx");
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa chọn lớp muốn sửa');", true);
                //Refresh1();

            }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Lop lop = db.Lop.SingleOrDefault(c => c.MaLop == txtMaLop.Text);
                db.Lop.Remove(lop);
                db.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn xóa thành công');", true);

                //Refresh1();
                ddlHeDT.Focus();
                Response.Redirect("ThongTinLopHoc.aspx");
            }

            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa chọn lớp muốn xóa');", true);
                Refresh1();
            }

        }
        protected void GrvLop_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var LopThucHanh = db.st_LayMaLopThucHanh();
            var LopLyThuyet = db.st_LayMaLopLT();
            Label lblMa = (Label)GrvLop.Rows[e.NewSelectedIndex].FindControl("lblMa");
            foreach (var item in LopLyThuyet)
            {
                if (lblMa.Text == item.MaLop.ToString())
                {
                    txtTenLop.Enabled = true;
                    ddlHeDT.Enabled = true;
                    ddlHTDT.Enabled = true;

                }
            }
            foreach (var item in LopThucHanh)
            {
                if (lblMa.Text == item.MaLop.ToString())
                {
                    ddlHeDT.Enabled = false;
                    ddlHTDT.Enabled = false;
                }
            }
            Lop lop = db.Lop.SingleOrDefault(c => c.MaLop == lblMa.Text && c.MaHeDT == c.HeDaoTao.MaHDT);
            txtMaLop.Text = lop.MaLop.ToString().Trim();
            txtMaLop.Enabled = false;
            if (lop.MaHeDT == lop.HeDaoTao.MaHDT)
            {
                ddlHeDT.SelectedValue = lop.MaHeDT;
                ddlHeDT.SelectedItem.Text = lop.HeDaoTao.TenHeDT;
                lblMahdt.Text = lop.MaHeDT.ToString();
            }
            //ddlHeDT.SelectedItem.Text = lop.HeDaoTao.TenHeDT;
            //lblMahdt.Text = lop.MaHeDT.ToString(); 
            txtTenLop.Text = lop.TenLop;
            //if (lop.HinhThucDT=="Niên chế")
            //{
            //    lblMahtdt.Text=
            //}
            //
            //if (lop.HinhThucDT == "Niên chế")
            //{
            //    ddlHTDT.SelectedValue = "1";
            //    ddlHTDT.SelectedItem.Text = lop.HinhThucDT;
            //}
            //if (lop.HinhThucDT == "Tín chỉ")
            //{
            //    ddlHTDT.SelectedValue = "2";
            //    ddlHTDT.SelectedItem.Text = lop.HinhThucDT;
            //}

            ddlHTDT.SelectedItem.Text = lop.HinhThucDT.ToString();
            txtSiSo.Text = lop.SiSo.ToString();
            txtGhiChu.Text = lop.GhiChu;
        }


        protected void GrvLop_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvLop.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        //public void LayHinh thức đào tạo
        public void LayHinhThucDT()
        {
            var thongtin = (from c in db.Lop
                            where c.MaLop == ddlChonLopLT.SelectedValue.ToString()
                            select new { c.HinhThucDT }).Distinct();
            foreach (var item in thongtin)
            {
                ddlHTDT.SelectedItem.Text = item.HinhThucDT.ToString();
            }
        }
        protected void ddlChonLopLT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlHeDT.Items.Clear();
            LayHinhThucDT();
            LayThongThinChiTiet();
            var thongtin = (from c in db.Lop
                            where c.HeDaoTao.MaHDT == c.MaHeDT && c.MaLop == ddlChonLopLT.SelectedValue.ToString()
                            select new { c.MaHeDT, c.HeDaoTao.TenHeDT, c.MaLop, c.TenLop }).Distinct();
            ddlHeDT.DataSource = thongtin.ToList();
            ddlHeDT.DataTextField = "TenHeDT";
            ddlHeDT.DataValueField = "MaHeDT";
            ddlHeDT.DataBind();
            foreach (var item in thongtin)
            {
                txtMaLop.Text = item.MaLop.ToString() + ".";
                txtTenLop.Text = item.TenLop.ToString() + ".";

            }
            ddlHeDT.Enabled = false;
            ddlHTDT.Enabled = false;
        }
        protected void ckThucHanh_CheckedChanged(object sender, EventArgs e)
        {
            LoadLopLyThuyet();
            ddlChonLopLT.Enabled = true; ;
            lblChonLopLT.Enabled = true;
            txtTenLop.Enabled = true;
            ddlHeDT.Enabled = true;
            ddlHTDT.Enabled = true;
        }
        protected void ckLyThuyet_CheckedChanged(object sender, EventArgs e)
        {
            ddlChonLopLT.Enabled = false;
            txtTenLop.Enabled = true;
            ddlHeDT.Enabled = true;
            ddlHTDT.Enabled = true;
        }
        protected void btnMoi_Click(object sender, EventArgs e)
        {
            //Refresh1();
            Response.Redirect("ThongTinLopHoc.aspx");
            ckLyThuyet.Checked = false;
            ckThucHanh.Checked = false;
            ddlChonLopLT.Enabled = true;
            ddlHTDT.SelectedItem.Text = "--Chọn hình thức đào tạo--";
            ddlHeDT.SelectedItem.Text = "--Chọn hệ đào tạo--";
        }
        protected void ddlHeDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMahdt.Text = ddlHeDT.SelectedValue.ToString();

        }


        protected void btnTim_Click(object sender, EventArgs e)
        {
            var thongtinlop = from c in db.Lop
                              where c.MaLop.Contains(txtMa.Text.Trim()) || c.TenLop.Contains(txtMa.Text.Trim())
                              select new { c.MaHeDT, c.MaLop, c.TenLop, c.SiSo, c.HinhThucDT, c.GhiChu, c.HeDaoTao.TenHeDT, };
            GrvLop.DataSource = thongtinlop;
            GrvLop.DataBind();
        }
    }
}