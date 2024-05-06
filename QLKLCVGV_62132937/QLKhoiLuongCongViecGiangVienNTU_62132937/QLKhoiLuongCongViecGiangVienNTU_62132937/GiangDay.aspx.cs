using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class GiangDay1 : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {
                var Dangnhap = Session["Dangnhap"].ToString();
                var MemberID = Session["MemberID"].ToString();
                var tt = from c in ql.TaiKhoan
                         where (c.TenDangNhap == Dangnhap && c.MaGV.ToString() == MemberID && c.MaGV == c.GiaoVien.MaGV)
                         select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
                foreach (var item in tt)
                {

                    txtTenGV.Text = item.TenGV;
                    if (Session["MemberID"].ToString() == item.MaGV.ToString() && item.Quyen == "Giáo vụ")
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
                ddlDSLop.Enabled = false;
                ddlMonHoc.Enabled = false;
                //txtSoSV.Enabled = false;
                LoadLopHoc();
                LoadNamHoc();
                LoadGridview();
                //ddlMonHoc.Items.Insert(0,new ListItem ("--Chọn môn học--","0"));
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }

        }
        /// <summary>
        /// Kiem tra nhap thong tin tren cac control
        /// </summary>
        /// <returns></returns>
        public bool KiemTraRong()
        {
            if (ddlNamHoc.Text == "" || ddlMonHoc.Text == "" || ddlDSLop.Text == "")
            { return true; }
            else return false;
        }
        /// <summary>
        /// Làm mới các control
        /// </summary>
        public void Refresh1()
        {
            txtGhiChu.Text = "";
            //ddlDSLop.Text="";
            //ddlMonHoc.Text = "";
            //ddlNamHoc.Text = "";
            //ddlNamHoc1.Text = "";

        }

        /// <summary>
        /// load nam học
        /// </summary>
        public void LoadNamHoc()
        {
            string[] mang = new string[5];
            for (int i = 0; i < 5; i++)
            {
                mang[i] = ((int.Parse(DateTime.Now.Year.ToString()) - i) + "-" + (int.Parse(DateTime.Now.Year.ToString()) - i + 1)).ToString();
            }
            ddlNamHoc.DataSource = mang;
            ddlNamHoc.DataBind();
        }


        ///// <summary>
        ///// Load nam hoc tu dong
        ///// </summary>
        //public void LoadNamHoc()
        //{
        //    int nam = 0;
        //    int nam1 = Convert.ToInt32(DateTime.Now.Year.ToString());
        //    nam = nam1 + 1;
        //    ddlNamHoc.SelectedItem.Text = DateTime.Now.Year.ToString();
        //    ddlNamHoc1.SelectedItem.Text = nam.ToString();
        //}
        /// <summary>
        /// Load thông tin lớp học lên drop
        /// </summary>
        public void LoadLopHoc()
        {
            var LopHoc = from c in ql.Lop
                         select c;
            ddlDSLop.DataSource = LopHoc.ToList();
            ddlDSLop.DataTextField = "MaLop";
            ddlDSLop.DataValueField = "MaLop";
            ddlDSLop.DataBind();
            ddlDSLop.Items.Insert(0, new ListItem("--Chọn lớp--", "0"));
        }
        protected void optLyThuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (optLyThuyet.Checked == true)
            {
                var c = ql.LoadMonLyThuyet(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                ddlMonHoc.Items.Insert(0, new ListItem("--Chọn môn học--", "0"));
                //
                ddlDSLop.Enabled = true;
                //txtSoSV.Enabled = false;
                ddlMonHoc.Enabled = true;
                LoadNamHoc();
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }
        }
        protected void optThucHanh_CheckedChanged(object sender, EventArgs e)
        {
            if (optThucHanh.Checked == true)
            {
                var c = ql.LoadMonThucHanh(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                ddlMonHoc.Items.Insert(0, new ListItem("--Chọn môn học--", "0"));
                //
                txtSoSV.Text = "0";
                txtSoSV.Enabled = false;
                ddlMonHoc.Enabled = true;
                ddlDSLop.Enabled = true;
                LoadNamHoc();
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }
        }
        protected void optProject_CheckedChanged(object sender, EventArgs e)
        {
            if (optProject.Checked == true)
            {
                var c = ql.LoadMonProject(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                ddlMonHoc.Items.Insert(0, new ListItem("--Chọn môn học--", "0"));
                //
                txtSoSV.Enabled = true;
                ddlMonHoc.Enabled = true; ;
                ddlDSLop.Enabled = true;
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));

            }
        }
        protected void optThucTapXiNghiep_CheckedChanged(object sender, EventArgs e)
        {
            if (optThucTapXiNghiep.Checked == true)
            {
                var c = ql.LoadMonTTXN(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                ddlMonHoc.Items.Insert(0, new ListItem("--Chọn môn học--", "0"));
                txtSoSV.Enabled = true;
                ddlMonHoc.Enabled = true;
                ddlDSLop.Enabled = true;
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }
        }
        protected void optThucTapSuPham_CheckedChanged(object sender, EventArgs e)
        {
            if (optThucTapSuPham.Checked == true)
            {
                var c = ql.LoadMonTTSP(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                ddlMonHoc.Items.Insert(0, new ListItem("--Chọn môn học--", "0"));
                //
                txtSoSV.Enabled = true;
                ddlDSLop.Enabled = true;
                ddlMonHoc.Enabled = true; ;
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }
        }
        public void LoadGridview()
        {
            var MemberID = Session["MemberID"].ToString();
            var gd = from c in ql.GiangDay
                     where c.MaGV == MemberID && c.MaGV == c.GiaoVien.MaGV && c.MaMon == c.MonHoc.MaMon && c.MaLop == c.Lop.MaLop
                     select new { c.MaMon, c.MaGV, c.MaLop, c.Lop.TenLop, c.GiaoVien.TenGV, c.MonHoc.TenMon, c.GhiChu, c.NamHoc, c.SoSV };
            DataTable dt = new DataTable();
            dt.Columns.Add("MaGV");
            dt.Columns.Add("TenGV");
            dt.Columns.Add("MaMon");
            dt.Columns.Add("TenMon");
            dt.Columns.Add("MaLop");
            dt.Columns.Add("TenLop");
            //
            dt.Columns.Add("SoSV");

            dt.Columns.Add("GhiChu");
            dt.Columns.Add("NamHoc");
            DataRow dr;
            foreach (var item in gd)
            {
                dr = dt.NewRow();
                dr["MaGV"] = item.MaGV;
                dr["TenGV"] = item.TenGV;
                dr["MaMon"] = item.MaMon;
                dr["TenMon"] = item.TenMon;
                dr["MaLop"] = item.MaLop;
                dr["TenLop"] = item.TenLop;
                //
                dr["SoSV"] = item.SoSV;

                dr["GhiChu"] = item.GhiChu;
                dr["NamHoc"] = item.NamHoc;
                dt.Rows.Add(dr);

            }
            GrvHDNCKH.DataSource = dt;
            GrvHDNCKH.DataBind();

        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraRong() == false)
                {
                    GiangDay gd = new GiangDay();
                    gd.MaGV = Session["MemberID"].ToString();
                    gd.MaLop = ddlDSLop.SelectedValue.ToString();
                    gd.MaMon = ddlMonHoc.SelectedValue.ToString();
                    gd.NamHoc = ddlNamHoc.SelectedItem.Text.Trim();
                    //
                    gd.SoSV = Convert.ToInt32(txtSoSV.Text);

                    gd.GhiChu = txtGhiChu.Text;
                    ql.GiangDay.Add(gd);
                    ql.SaveChanges();
                    Refresh1();
                    LoadGridview();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn thêm thành công');", true);
                    Response.Redirect("GiangDay.aspx");
                }
                else { ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Hãy nhập đủ thông tin');", true); }
            }
            catch (Exception)
            { throw; }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string mamon = Session["MemberID"].ToString();
                GiangDay gd = ql.GiangDay.SingleOrDefault(c => c.MaGV == mamon.ToString() && c.MaMon == ddlMonHoc.SelectedValue.ToString() && c.MaLop == ddlDSLop.SelectedValue.ToString());
                ql.GiangDay.Remove(gd);
                ql.SaveChanges();
                Refresh1();
                LoadGridview();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn xóa thành công');", true);
                Response.Redirect("GiangDay.aspx");
            }
            catch (Exception)
            { throw; }
        }
        protected void GrvHDNCKH_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lblMa = (Label)GrvHDNCKH.Rows[e.NewSelectedIndex].FindControl("lblMa");
            Label lblMa1 = (Label)GrvHDNCKH.Rows[e.NewSelectedIndex].FindControl("lblMa1");
            Label lblMa2 = (Label)GrvHDNCKH.Rows[e.NewSelectedIndex].FindControl("lblMa2");
            GiangDay gd = ql.GiangDay.SingleOrDefault(c => c.MaGV == lblMa.Text && c.MaLop == lblMa1.Text && c.MaMon == lblMa2.Text);
            txtTenGV.Text = gd.MaGV.ToString();
            //Đưa tên lớp hoc vừa select vào trong drop lớp học
            var lh = from c1 in ql.Lop
                     where c1.MaLop == gd.MaLop
                     select c1;
            ddlDSLop.DataSource = lh.ToList();
            ddlDSLop.DataTextField = "MaLop";
            ddlDSLop.DataValueField = "MaLop";
            ddlDSLop.DataBind();
            //Đưa tên môn học vừa select vào trong drop môn học
            var mh = from c in ql.MonHoc
                     where c.MaMon == gd.MaMon
                     select c;
            ddlMonHoc.DataSource = mh.ToList();
            ddlMonHoc.DataTextField = "TenMon";
            ddlMonHoc.DataValueField = "MaMon";
            ddlMonHoc.DataBind();
            ddlNamHoc.SelectedItem.Text = gd.NamHoc.ToString();
            txtGhiChu.Text = gd.GhiChu.ToString();
            //
            txtSoSV.Text = gd.SoSV.ToString();

            ddlMonHoc.Enabled = false;
            ddlDSLop.Enabled = false;
            txtTenGV.Enabled = false;
        }
        protected void ddlDSLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMaLop.Visible = true;
            lblMaLop.Text = ddlDSLop.SelectedItem.Value.ToString();
            if (optLyThuyet.Checked == true)
            {
                var monhoc = ql.LoadMonLyThuyet(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = monhoc;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                //
                ddlDSLop.Enabled = true;
                ddlMonHoc.Enabled = true;
                var lop = from c in ql.Lop
                          where c.MaLop == ddlDSLop.SelectedValue.ToString()
                          select new { c.SiSo };
                foreach (var item in lop)
                {
                    txtSoSV.Text = item.SiSo.ToString();
                }
            }
            if (optThucHanh.Checked == true)
            {
                var c = ql.LoadMonThucHanh(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                //
                //txtSoSV.Text = "0";
                var lop = from cm in ql.Lop
                          where cm.MaLop == ddlDSLop.SelectedValue.ToString()
                          select new { cm.SiSo };
                foreach (var item in lop)
                {
                    txtSoSV.Text = item.SiSo.ToString();
                }
                txtSoSV.Enabled = true;
                ddlMonHoc.Enabled = true;
                ddlDSLop.Enabled = true;
            }
            if (optProject.Checked == true)
            {
                var c = ql.LoadMonProject(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                //
                txtSoSV.Enabled = true;
                ddlMonHoc.Enabled = true; ;
                ddlDSLop.Enabled = true;

            }
            if (optThucTapXiNghiep.Checked == true)
            {
                var c = ql.LoadMonTTXN(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                txtSoSV.Text = "";
                txtSoSV.Enabled = true;
                ddlMonHoc.Enabled = true;
                ddlDSLop.Enabled = true;
            }
            if (optThucTapSuPham.Checked == true)
            {
                var c = ql.LoadMonTTSP(ddlDSLop.SelectedValue);
                ddlMonHoc.DataSource = c;
                ddlMonHoc.DataTextField = "TenMon";
                ddlMonHoc.DataValueField = "MaMon";
                ddlMonHoc.DataBind();
                //
                txtSoSV.Text = "";
                txtSoSV.Enabled = true;
                ddlDSLop.Enabled = true;
                ddlMonHoc.Enabled = true; ;
            }
        }
        protected void ddlNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNamHoc.Text = ddlNamHoc.SelectedItem.Text;
        }
        protected void ddlMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblThongBao1.Visible = true;
            GiangDay gd = ql.GiangDay.SingleOrDefault(c => c.MaLop == ddlDSLop.SelectedItem.Value.ToString() && c.MaMon == ddlMonHoc.SelectedItem.Value.ToString());
            if (gd != null)
            {
                lblThongBao1.Text = "Môn học và lớp học đã tồn tại người dạy. Hãy xem lại dữ liệu nhâp!";
            }
            else { lblThongBao1.Text = ""; }

        }

        protected void GrvHDNCKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  
    }
}