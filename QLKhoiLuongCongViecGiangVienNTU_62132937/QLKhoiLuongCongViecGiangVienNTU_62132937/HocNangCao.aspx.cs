using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class HocNangCao : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 tc = new QUANLYGIANGVIENEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {
                var memberID = Session["MemberID"].ToString();
                var dangnhap = Session["Dangnhap"].ToString();


                var tt = from c in tc.TaiKhoan
                         where (c.TenDangNhap == dangnhap && c.MaGV.ToString() == memberID && c.MaGV == c.GiaoVien.MaGV)
                         select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
                GiaoVien gv = tc.GiaoVien.Single(c => c.MaGV == memberID);
                foreach (var item in tt)
                {
                    txtGV.Text = item.TenGV.ToString();
                    lblma.Text = item.MaGV.ToString();
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
                LoadGrid();
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));

            }
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


        /// <summary>
        /// Xây dựng phương thức load dữ liệu lên gridview
        /// </summary>
        public void LoadGrid()
        {
            string ma1 = Session["MemberID"].ToString();
            //var gv = tc.LoadHocNangCao(lblma.Text);

            var gv = tc.LoadHocNangCao(ma1);
            GrvHocNangCao.DataSource = gv;
            GrvHocNangCao.DataBind();
        }
        public bool KTra(string namhoc1)
        {
            bool kt = false;
            var namhoc = tc.st_LayNamHoc(lblma.Text);
            foreach (var item in namhoc)
            {
                if (namhoc1 == item)
                {
                    kt = true;
                }
                else { kt = false; }
            }
            return kt;
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                if (KTra(ddlNamHoc.SelectedItem.Text) == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Năm học đã tồn tại');", true);
                }
                else
                {
                    var hnc = tc.ThemHocVien(lblma.Text, ddlNamHoc.SelectedItem.Text, txtGhiChu.Text);
                    tc.SaveChanges();
                    LoadGrid();

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
                var hocvien = tc.SuaHocVien(lblMaBang.Text, ddlNamHoc.SelectedItem.Text, txtGhiChu.Text);
                tc.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn sửa thành công');", true);
                Response.Redirect("HocNangCao.aspx");

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void GrvHocNangCao_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var mabang = tc.LoadHocNangCao(lblma.Text);
            foreach (var item in mabang)
            {
                lblMaBang.Text = item.Ma.ToString();
                txtGhiChu.Text = item.GhiChu.ToString();
                ddlNamHoc.SelectedItem.Text = item.NamHoc.ToString();

            }

            Label lblMa = (Label)GrvHocNangCao.Rows[e.NewSelectedIndex].FindControl("lblMa");
            var ttbang = tc.LayTTDeSua(int.Parse(lblMa.Text));
            foreach (var hv in ttbang)
            {
                lblma.Text = hv.MaGV.ToString();
                lblMaBang.Text = hv.Ma.ToString();
                txtGhiChu.Text = hv.GhiChu.ToString();
                ddlNamHoc.SelectedItem.Text = hv.NamHoc.ToString();

            }
            //HocNangCao hnc = tc.HocNangCaos.SingleOrDefault(c =>lblMaBang.Text  == lblMa.Text);

        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var hocvien = tc.XoaHocVien(lblMaBang.Text);
                tc.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn xóa thành công');", true);
                Response.Redirect("HocNangCao.aspx");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}