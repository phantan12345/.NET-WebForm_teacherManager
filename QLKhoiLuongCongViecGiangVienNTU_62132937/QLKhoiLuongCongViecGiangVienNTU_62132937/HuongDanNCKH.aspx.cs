using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class HuongDanNCKH1 : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        ExecutedID NCKH = new ExecutedID();

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
                   
                    txtGiaoVien.Text = item.TenGV;
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
                txtGiaoVien.Enabled = false;
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }
           
        }
        /// <summary>
        /// Làm rỗng các ô text
        /// </summary>
        public void Refresh1()
        {
            txtMaDT.Text = "";
            txtGhiChu.Text = "";
            //ddlSVNam.Text = "";
            //ddlSVNam.Text = "";
            ddlSVNam.SelectedValue = "0";
            //ddlNamHoc.SelectedValue = "0";


        }
        /// <summary>
        /// Xây dựng phương thức load dữ liệu lên gridview
        /// </summary>
        public void LoadGrid()
        {
            string ma = Session["MemberID"].ToString();
            var nckh = from c in ql.HuongDanNCKH
                           //where c.MaGV == c.GiaoVien.MaGV
                       where c.MaGV == ma.ToString()
                       select c;

            DataTable dt = new DataTable();
            dt.Columns.Add("Ma");
            dt.Columns.Add("TenGV");
            dt.Columns.Add("SVNam");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("NamHoc");
            dt.Columns.Add("GhiChu");
            DataRow dr;
            //foreach (var item in nckh)
            //{
            var hdnckh = from c in ql.HuongDanNCKH
                         where c.MaGV == c.GiaoVien.MaGV
                         select new { c.Ma, c.GiaoVien.TenGV, c.SVNam, c.SoLuong, c.NamHoc, c.GhiChu };
            foreach (var item1 in hdnckh)
            {
                dr = dt.NewRow();
                dr["Ma"] = item1.Ma;
                dr["TenGV"] = item1.TenGV;
                dr["SVNam"] = item1.SVNam;
                dr["SoLuong"] = item1.SoLuong;
                dr["NamHoc"] = item1.NamHoc;
                dr["GhiChu"] = item1.GhiChu;
                dt.Rows.Add(dr);
            }
            GrvHDNCKH.DataSource = dt;
            GrvHDNCKH.DataBind();
            //}

        }
        public bool KtraRong()
        {
            if (txtMaDT.Text == "")
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
            txtMaDT.Text = NCKH.LayMaHDNCKH();
            try
            {


                if (KtraRong() == true)
                {
                    HuongDanNCKH nckh = new HuongDanNCKH();
                    nckh.MaGV = Session["MemberID"].ToString();
                    nckh.Ma = txtMaDT.Text;
                    nckh.SVNam = ddlSVNam.SelectedItem.Text;
                    nckh.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                    nckh.NamHoc = ddlNamHoc.SelectedItem.Text;
                    nckh.GhiChu = txtGhiChu.Text;
                    ql.HuongDanNCKH.Add(nckh);
                    ql.SaveChanges();
                    LoadGrid();
                    //Refresh1();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);
                    Response.Redirect("HuongDanNCKH.aspx");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Không được để trống thông tin');", true);

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
                HuongDanNCKH hdnckh = ql.HuongDanNCKH.SingleOrDefault(c => c.Ma == txtMaDT.Text);
                hdnckh.Ma = txtMaDT.Text;
                hdnckh.SVNam = ddlSVNam.SelectedItem.Text;
                hdnckh.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                hdnckh.NamHoc = ddlNamHoc.SelectedItem.Text;
                hdnckh.GhiChu = txtGhiChu.Text;
                ql.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn sửa thành công');", true);
                Response.Redirect("HuongDanNCKH.aspx");
                //Refresh1();
                ddlSVNam.Focus();

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {

        }
        protected void GrvHDNCKH_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lblMa = (Label)GrvHDNCKH.Rows[e.NewSelectedIndex].FindControl("lblMa");
            HuongDanNCKH nckh = ql.HuongDanNCKH.SingleOrDefault(c => c.Ma == lblMa.Text);
            txtMaDT.Text = nckh.Ma.ToString().Trim();
            ddlSVNam.SelectedItem.Text = nckh.SVNam.ToString().Trim();
            txtSoLuong.Text = nckh.SoLuong.ToString().Trim();
            ddlNamHoc.SelectedItem.Text = nckh.NamHoc.ToString();
            //ddlSVNam.Text = nckh.SVNam.ToString().Trim();
            //string[] namhoc = nckh.NamHoc.Split('-');
            //ddlNamHoc.SelectedItem.Text = namhoc[0].ToString().Trim();
            //ddlNamHoc1.SelectedItem.Text = namhoc[1].ToString().Trim();
            txtGhiChu.Text = nckh.GhiChu.ToString();
        }
        protected void GrvHDNCKH_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label madetai = (Label)GrvHDNCKH.Rows[e.RowIndex].FindControl("lblMa");
            //var tintuc = st.sp_Xoatin(int.Parse(lblNewsid1.Text), "Xóa bài viết thành công");
            //LoadGrid();
            HuongDanNCKH nckh = ql.HuongDanNCKH.SingleOrDefault(c => c.Ma == madetai.Text);
            ql.HuongDanNCKH.Remove(nckh);
            ql.SaveChanges();
            LoadGrid();
            Response.Redirect("HuongDanNCKH.aspx");
        }
        protected void GrvHDNCKH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvHDNCKH.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }
}