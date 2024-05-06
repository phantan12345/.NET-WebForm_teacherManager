using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class GiaoVienNCKH1 : System.Web.UI.Page
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
                txtGiaoVien.Enabled = false;
                LoadNamHoc();
                LoadGridView();
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }
        }
        //Load thong tin len grid view
        public void LoadGridView()
        {
           
            var GV = from c in ql.GiaoVienNCKH
                     select new
                     {
                         c.MaDeTai,
                         c.MaGV,
                         c.GiaoVien.TenGV,
                         c.TenDeTai,
                         c.Cap,
                         c.NamThamGiaNC,
                         c.GhiChu
                     };
            DataTable dt = new DataTable();
            dt.Columns.Add("MaDeTai");
            dt.Columns.Add("TenGV");
            dt.Columns.Add("TenDeTai");
            dt.Columns.Add("Cap");
            dt.Columns.Add("NamThamGiaNC");
            dt.Columns.Add("GhiChu");
            DataRow dr;
            foreach (var item in GV)
            {
                dr = dt.NewRow();
                dr["MaDeTai"] = item.MaDeTai;
                dr["TenGV"] = item.TenGV;
                dr["TenDeTai"] = item.TenDeTai;
                dr["Cap"] = item.Cap;
                dr["NamThamGiaNC"] = item.Cap;
                dr["GhiChu"] = item.GhiChu;
                dt.Rows.Add(dr);
            }

            GrvGVNCKH.DataSource = dt;
            GrvGVNCKH.DataBind();
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
        public void Refresh1()
        {
            txtGhiChu.Text = "";
            txtMaDT.Text = "";
            //ddlNamHoc.Text = "";
            //ddlNamHoc1.Text = "";
            txtTenDT.Text = "";
            ddlCapThamGia.Text = "";

        }
        public bool KiemTraRong()
        {
            if (txtTenDT.Text == "" || txtMaDT.Text == "" || ddlCapThamGia.Text == "")
            { return true; }
            else return false;
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaDT.Text = ex.LayMaDeTai().ToString();
                GiaoVienNCKH gvNCKH = new GiaoVienNCKH();
                if (KiemTraRong() == false)
                {
                    gvNCKH.MaGV = Session["MemberID"].ToString();
                    gvNCKH.MaDeTai = txtMaDT.Text;
                    gvNCKH.TenDeTai = txtTenDT.Text;
                    gvNCKH.Cap = ddlCapThamGia.SelectedItem.Text;
                    gvNCKH.NamThamGiaNC = ddlNamHoc.SelectedItem.Text;
                    gvNCKH.GhiChu = txtGhiChu.Text;
                    ql.GiaoVienNCKH.Add(gvNCKH);
                    ql.SaveChanges();
                    LoadGridView();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn thêm thành công');", true);
                    //Refresh1();
                    Response.Redirect("GiaoVienNCKH.aspx");
                }

            }
            catch (Exception)
            { throw; }
        }
        protected void GrvGVNCKH_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lblMa = (Label)GrvGVNCKH.Rows[e.NewSelectedIndex].FindControl("lblMa");
            GiaoVienNCKH gv = ql.GiaoVienNCKH.SingleOrDefault(c => c.MaDeTai == lblMa.Text);
            //txtGiaoVien.Text = see
            txtMaDT.Text = gv.MaDeTai.ToString();
            txtTenDT.Text = gv.TenDeTai.ToString();
            ddlCapThamGia.SelectedItem.Text = gv.Cap.ToString();
            ddlNamHoc.SelectedItem.Text = gv.NamThamGiaNC.ToString();
            //string[] namhoc = gv.NamThamGiaNC.Split('-');
            //ddlNamHoc.SelectedItem.Text = namhoc[0].ToString().Trim();
            //ddlNamHoc1.SelectedItem.Text = namhoc[1].ToString().Trim();
            txtGhiChu.Text = gv.GhiChu.ToString();
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            GiaoVienNCKH gvNCKH = ql.GiaoVienNCKH.SingleOrDefault(c => c.MaDeTai == txtMaDT.Text);
            gvNCKH.MaGV = Session["MemberID"].ToString();
            gvNCKH.MaDeTai = txtMaDT.Text;
            gvNCKH.TenDeTai = txtTenDT.Text;
            gvNCKH.Cap = ddlCapThamGia.Text;
            gvNCKH.NamThamGiaNC = ddlNamHoc.SelectedItem.Text;
            gvNCKH.GhiChu = txtGhiChu.Text;
            ql.SaveChanges();
            LoadGridView();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Sửa thông tin thành công');", true);
            txtTenDT.Focus();
            Response.Redirect("GiaoVienNCKH.aspx");

        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            GiaoVienNCKH gv = ql.GiaoVienNCKH.SingleOrDefault(c => c.MaDeTai == txtMaDT.Text);
            ql.GiaoVienNCKH.Remove(gv);
            ql.SaveChanges();
            LoadGridView();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Xóa thông tin thành công');", true);
        }
        protected void GrvGVNCKH_PreRender(object sender, EventArgs e)
        {

        }
        protected void GrvGVNCKH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvGVNCKH.PageIndex = e.NewPageIndex;
            LoadGridView();
        }
    }
}