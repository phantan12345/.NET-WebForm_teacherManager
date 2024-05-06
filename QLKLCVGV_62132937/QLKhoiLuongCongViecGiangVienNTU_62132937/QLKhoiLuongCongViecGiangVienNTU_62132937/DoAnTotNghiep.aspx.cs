using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class DoAnTotNghiep1 : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        static string maLop;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {
                var memberID = Session["MemberID"].ToString();
                var dangnhap = Session["Dangnhap"].ToString();

                var tt = from c in ql.TaiKhoan
                         where (c.TenDangNhap == dangnhap && c.MaGV.ToString() == memberID && c.MaGV == c.GiaoVien.MaGV)
                         select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
                GiaoVien gv = ql.GiaoVien.Single(c => c.MaGV == memberID);
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
                LoadNamHoc();
                LoadGridView();
                LoadLopHoc();
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }
        }
        //Load len gridview thong tin do an tot nghiep
        public void LoadGridView()
        {
            string ma = Session["MemberID"].ToString();
            List<DoAnTotNghiep> c = ql.DoAnTotNghiep.Where(d=>d.MaGV==ma).ToList();
            grvDoAn.DataSource = c.ToList();
            grvDoAn.DataBind();
        }
        //Lam moi cac control
        public void Refresh1()
        {

            txtGhichu.Text = "";
            txtSoBuoi.Text = "";
            txtSoDoPhanBien.Text = "";
            txtSoLuong.Text = "";
        }
        public bool KiemTraRong()
        {
            if (txtSoBuoi.Text == "" || txtSoDoPhanBien.Text == "" || txtSoLuong.Text == "")
            { return true; }
            else return false;
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenGV.Text = Session["MemberID"].ToString(); ;
                if (KiemTraRong() == false)
                {
                    DoAnTotNghiep da = new DoAnTotNghiep();
                    da.MaGV = txtTenGV.Text;
                    da.MaLop = ddlLop.SelectedValue.ToString();
                    da.SoDeTai = int.Parse(txtSoLuong.Text);
                    da.SoDoAnPBien = int.Parse(txtSoDoPhanBien.Text);
                    da.SoBuoiChamBai = int.Parse(txtSoBuoi.Text);
                    da.NamHoc = ddlNamHoc.SelectedItem.Text;
                    da.GhiChu = txtGhichu.Text;
                    ql.DoAnTotNghiep.Add(da);
                    ql.SaveChanges();
                    LoadGridView();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);
                    Refresh1();
                    txtSoLuong.Focus();
                }
            }
            catch (Exception)
            { throw; }
        }
        /// <summary>
        /// load nam học
        /// </summary>
        public void LoadNamHoc()
        {
            //ddlNamHoc.Items.Clear();
            string[] mang = new string[5];
            for (int i = 0; i < 5; i++)
            {
                ddlNamHoc.Items.Clear();
                mang[i] = ((int.Parse(DateTime.Now.Year.ToString()) - i) + "-" + (int.Parse(DateTime.Now.Year.ToString()) - i + 1)).ToString();
            }
            ddlNamHoc.DataSource = mang;
            ddlNamHoc.DataBind();
        }
        /// <summary>
        /// Load thong tin lop hoc
        /// </summary>
        public void LoadLopHoc()
        {
            var LopHoc = ql.st_LayMaLopLT();
            ddlLop.DataSource = LopHoc;
            ddlLop.DataTextField = "TenLop";
            ddlLop.DataValueField = "MaLop";
            ddlLop.DataBind();
            ddlLop.Items.Insert(0, new ListItem("--Chọn lớp--", "0"));
        }
        protected void grvDoAn_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Label lblMa = (Label)grvDoAn.Rows[e.NewSelectedIndex].FindControl("lblMa");
            //Label lblMa1 = (Label)grvDoAn.Rows[e.NewSelectedIndex].FindControl("lblMa1");
            Label lblMa2 = (Label)grvDoAn.Rows[e.NewSelectedIndex].FindControl("lblMa2");

            DoAnTotNghiep da = ql.DoAnTotNghiep.SingleOrDefault(c => c.Ma.ToString() == lblMa2.Text);
            txtTenGV.Text = da.GiaoVien.TenGV.ToString();
            var lh = from c in ql.Lop
                     where c.MaLop == da.MaLop
                     select c;
            ddlLop.DataSource = lh;
            ddlLop.DataTextField = "TenLop";
            ddlLop.DataValueField = "MaLop";
            ddlLop.DataBind();
            txtSoLuong.Text = da.SoDeTai.ToString();
            txtSoDoPhanBien.Text = da.SoDoAnPBien.ToString();
            txtSoBuoi.Text = da.SoBuoiChamBai.ToString();
            txtGhichu.Text = da.GhiChu.ToString();
            lblMabang.Text = da.Ma.ToString();
            ddlNamHoc.SelectedItem.Text = da.NamHoc.ToString();

        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DoAnTotNghiep da = ql.DoAnTotNghiep.SingleOrDefault(c => c.Ma.ToString() == lblMabang.Text);
                da.MaLop = ddlLop.SelectedValue.ToString();
                da.SoDeTai = Convert.ToInt32(txtSoLuong.Text);
                da.SoDoAnPBien = Convert.ToInt32(txtSoDoPhanBien.Text);
                da.SoBuoiChamBai = Convert.ToInt32(txtSoBuoi.Text);
                da.NamHoc = ddlNamHoc.SelectedItem.Text;
                //ddlNamHoc.SelectedItem.Text = da.NamHoc.ToString();
                //string[] namhoc = da.NamHoc.Split('-');
                //ddlNamHoc.SelectedItem.Text = namhoc[0].ToString().Trim();
                //ddlNamHoc1.SelectedItem.Text = namhoc[1].ToString().Trim();
                da.GhiChu = txtGhichu.Text;
                ql.SaveChanges();
                LoadGridView();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn sửa thành công');", true);
                Response.Redirect("DoAnTotNghiep.aspx");
                //Refresh1();
                txtSoLuong.Focus();

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DoAnTotNghiep da = ql.DoAnTotNghiep.SingleOrDefault(c => c.Ma.ToString() == lblMabang.Text);
                ql.DoAnTotNghiep.Remove(da);
                ql.SaveChanges();
                LoadGridView();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn xóa thành công');", true);
                Response.Redirect("DoAnTotNghiep.aspx");
                //Refresh1();
                txtSoLuong.Focus();
            }

            catch (Exception)
            {
                throw;
            }
        }
        protected void grvDoAn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDoAn.PageIndex = e.NewPageIndex;
            LoadGridView();
        }
        protected void btRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoAnTotNghiep.aspx");
        }

    }
}