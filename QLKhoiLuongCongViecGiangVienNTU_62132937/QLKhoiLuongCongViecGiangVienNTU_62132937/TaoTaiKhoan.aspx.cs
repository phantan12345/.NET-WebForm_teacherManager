using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class TaoTaiKhoan : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        MaHoa mh=new MaHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {
                var tt = from c in ql.TaiKhoan
                         where (c.TenDangNhap == Session["Dangnhap"].ToString() && c.MaGV.ToString() == Session["MemberID"].ToString() && c.MaGV == c.GiaoVien.MaGV)
                         select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
                foreach (var item in tt)
                {

                    //txtTenGV.Text = item.TenGV;
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
                Loaddrop();
                LoadGrid();

            }
        }

        /// <summary>
        /// Lấy ra giáo viên chưa có tài khoản để tạo tài khoản
        /// </summary>
        public void Loaddrop()
        {
            var thongtin = ql.st_LayThanhvien();
            ddlMaGV.DataSource = thongtin;
            ddlMaGV.DataTextField = "TenGV";
            ddlMaGV.DataValueField = "MaGV";
            ddlMaGV.DataBind();


        }
        /// <summary>
        /// Load thông tin tài khoản lê gridview
        /// </summary>
        public void LoadGrid()
        {
            string chuoi = "";
            Regex rg = new Regex(chuoi);
            string[] kq;
            var ct = from c in ql.TaiKhoan
                     select new { c.MaGV, c.TenDangNhap, c.Quyen, c.NgayTaoTK };
            DataTable dt = new DataTable();
            dt.Columns.Add("MaGV");
            dt.Columns.Add("TenDangNhap");
            dt.Columns.Add("Quyen");
            dt.Columns.Add("NgayTaoTK");
            DataRow dr;
            foreach (var item in ct)
            {
                dr = dt.NewRow();
                dr["MaGV"] = item.MaGV;
                dr["TenDangNhap"] = item.TenDangNhap;
                dr["Quyen"] = item.Quyen;
                chuoi = item.NgayTaoTK.ToString();
                kq = chuoi.Split(' ');
                dr["NgayTaoTK"] = kq[0].ToString();
                //dr["NgayTaoTK"] = item.NgayTaoTK.ToString();
                dt.Rows.Add(dr);
            }
            grvTaiKhoan.DataSource = dt;
            grvTaiKhoan.DataBind();
        }
        /// <summary>
        /// Xây dựng phương thức kiểm tra rỗng
        /// </summary>
        /// <returns></returns>
        public bool KiemTraRong()
        {
            bool kt = false;
            if (txtUsename.Text == "" || txtMatKhau.Text == "")
            //if (txtMaLop.Text == "")
            {
                kt = true;
            }
            else
            {
                if (txtUsename.Text != "" && txtMatKhau.Text != "")
                {
                    kt = false;
                }

            }
            return kt;

        }

        /// <summary>
        /// Xây dựng phương thức kiểm tra trùng tên đăng nhập
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public bool KiemTraTrungTenDN(string tendn)
        {
            bool kt = false;
            var tendangnhap = from c in ql.TaiKhoan
                              select c;
            foreach (TaiKhoan tk in tendangnhap)
            {
                if (tendn == tk.TenDangNhap.ToString())
                {
                    kt = true;
                }
            }
            return kt;

        }
        public void Refresh1()
        {
            txtUsename.Text = ""; txtMatKhau.Text = "";
            txtNgaytaoTK.Text = "";
            ddlMaGV.SelectedValue = "0";
            ddlChonQuyen.SelectedItem.Text = "--Chọn quyền--";
            ddlMaGV.SelectedItem.Text = "--Chọn giáo viên--";

        }

        protected void ddlMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMaGV.Text = ddlMaGV.SelectedValue.ToString();
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraTrungTenDN(txtUsename.Text) == false)
                {
                    if (KiemTraRong() == false)
                    {
                        TaiKhoan tk = new TaiKhoan();
                        tk.MaGV = lblMaGV.Text;
                        tk.TenDangNhap = txtUsename.Text;
                        tk.MatKhau = mh.Encrypt("tk61", txtMatKhau.Text + "");
                        tk.Quyen = ddlChonQuyen.SelectedItem.Text;
                        //txtNgaytaoTK.Text = DateTime.Now.ToString();
                        //tk.NgayTaoTK = DateTime.Parse(txtNgaytaoTK.Text);
                        tk.NgayTaoTK = DateTime.Parse(DateTime.Now.ToShortDateString());
                        ql.TaiKhoan.Add(tk);
                        ql.SaveChanges();
                        LoadGrid();
                        Refresh1();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Không được để trống thông tin');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Tên đăng nhập đã tồn tại');", true);
                }
            }

            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Tạo tài khoản không thành công');", true);
            }
        }

        protected void btnMoi_Click(object sender, EventArgs e)
        {
            Refresh1();
        }
        protected void btnXoaTK_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan tk = ql.TaiKhoan.SingleOrDefault(c => c.MaGV == lblMaGV.Text);
                ql.TaiKhoan.Remove(tk);
                ql.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn xóa thành công');", true);

                Refresh1();
                ddlMaGV.Focus();
            }

            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa chọn lớp muốn xóa');", true);
                Refresh1();
            }

        }
        protected void grvTaiKhoan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTaiKhoan.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
        protected void grvTaiKhoan_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                Label lblMa = (Label)grvTaiKhoan.Rows[e.NewSelectedIndex].FindControl("lblMa");
                TaiKhoan tk = ql.TaiKhoan.SingleOrDefault(c => c.MaGV == lblMa.Text);
                lblMaGV.Text = tk.MaGV.ToString();
                ddlMaGV.SelectedItem.Text = tk.GiaoVien.TenGV.ToString();
                txtUsename.Text = tk.TenDangNhap.ToString();
                txtMatKhau.Text = tk.MatKhau.ToString();
                ddlChonQuyen.SelectedItem.Text = tk.Quyen.ToString();
                string[] ngay = tk.NgayTaoTK.ToString().Split(' ');
                txtNgaytaoTK.Text = ngay[0].ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}