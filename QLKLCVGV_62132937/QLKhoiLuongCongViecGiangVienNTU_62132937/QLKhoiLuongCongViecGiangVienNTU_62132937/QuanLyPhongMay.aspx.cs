using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class QuanLyPhongMay : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        ExecutedID ex=new ExecutedID(); 
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

                    txtGV.Text = item.TenGV;
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
                //txtGiaoVien.Text = item.TenGV;
                LoadGrid();
                LoadNamHoc();
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));

            }
        }
        /// <summary>
        /// Làm rỗng các ô text
        /// </summary>
        public void Refresh1()
        {
            txtMa.Text = "";
            txtSoLuongPM.Text = "";
            txtGhiChu.Text = "";

        }
        /// <summary>
        /// Xây dựng phương thức load dữ liệu lên gridview
        /// </summary>
        public void LoadGrid()
        {
            string ma = Session["MemberID"].ToString();
            var qlpm = from c in ql.QLPhongMay
                           //where c.MaGV == c.GiaoVien.MaGV
                       where c.MaGV == ma.ToString()
                       select new { c.MaQL, c.GiaoVien.TenGV, c.SoLuongPM, c.NamHoc, c.GhiChu };

            DataTable dt = new DataTable();
            dt.Columns.Add("MaQL");
            dt.Columns.Add("TenGV");
            dt.Columns.Add("SoLuongPM");
            dt.Columns.Add("NamHoc");
            dt.Columns.Add("GhiChu");
            DataRow dr;
            foreach (var item1 in qlpm)
            {
                dr = dt.NewRow();
                dr["MaQL"] = item1.MaQL;
                dr["TenGV"] = item1.TenGV;
                dr["SoLuongPM"] = item1.SoLuongPM;
                dr["NamHoc"] = item1.NamHoc;
                dr["GhiChu"] = item1.GhiChu;
                dt.Rows.Add(dr);
            }
            GrvQLPM.DataSource = dt;
            GrvQLPM.DataBind();
        }
        public bool KtraRong()
        {
            //if (txtMaDT.Text == "" || ddlNamHoc.SelectedValue == "0" || ddlNamHoc1.SelectedValue == "0")
            if (txtSoLuongPM.Text == "" || txtGhiChu.Text == "")
            {
                return false;
            }
            else
                return true;
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
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                txtMa.Text = ex.LayMaQuanLy().ToString();
                if (txtSoLuongPM.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn chưa nhập vào số phòng máy quản lý');", true);
                }
                if (txtGhiChu.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Nhập vào chi tiết  tên các phòng máy quản lý');", true);
                }
                if (KtraRong() == true)
                {
                    QLPhongMay qlpm = new QLPhongMay();
                    qlpm.MaQL = txtMa.Text;
                    qlpm.MaGV = Session["MemberID"].ToString();
                    qlpm.SoLuongPM = int.Parse(txtSoLuongPM.Text);
                    qlpm.NamHoc = ddlNamHoc.SelectedItem.Text;
                    qlpm.GhiChu = txtGhiChu.Text;
                    ql.QLPhongMay.Add(qlpm);
                    ql.SaveChanges();
                    LoadGrid();
                    //Refresh1();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);
                    Response.Redirect("QuanLyPhongMay.aspx");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                QLPhongMay qlpm = ql.QLPhongMay.SingleOrDefault(c => c.MaQL == txtMa.Text);
                //qlpm.MaGV = Session["MemberID"].ToString();
                qlpm.SoLuongPM = int.Parse(txtSoLuongPM.Text);
                qlpm.NamHoc = ddlNamHoc.SelectedItem.Text;
                //qlpm.NamHoc = ddlNamHoc.SelectedItem.Text + '-' + ddlNamHoc1.SelectedItem.Text;            
                qlpm.GhiChu = txtGhiChu.Text;
                ql.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn sửa thành công');", true);
                Response.Redirect("QuanLyPhongMay.aspx");
                //Refresh1();
                txtSoLuongPM.Focus();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void GrvQLPM_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lblMa = (Label)GrvQLPM.Rows[e.NewSelectedIndex].FindControl("lblMa");
            QLPhongMay qlpm = ql.QLPhongMay.SingleOrDefault(c => c.MaQL == lblMa.Text);
            txtMa.Text = qlpm.MaQL.ToString();
            txtSoLuongPM.Text = qlpm.SoLuongPM.ToString().Trim();
            ddlNamHoc.SelectedItem.Text = qlpm.NamHoc.ToString();
            //ddlSVNam.Text = nckh.SVNam.ToString().Trim();
            //string[] namhoc = qlpm.NamHoc.Split('-');
            //ddlNamHoc.SelectedItem.Text = namhoc[0].ToString().Trim();
            //ddlNamHoc1.SelectedItem.Text = namhoc[1].ToString().Trim();
            txtGhiChu.Text = qlpm.GhiChu.ToString();
        }
        protected void GrvQLPM_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvQLPM.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            QLPhongMay qlpm = ql.QLPhongMay.SingleOrDefault(c => c.MaQL == txtMa.Text);
            ql.QLPhongMay.Remove(qlpm);
            ql.SaveChanges();
            LoadGrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã xóa thành c');", true);
            Response.Redirect("QuanLyPhongMay.aspx");
        }
    }
}