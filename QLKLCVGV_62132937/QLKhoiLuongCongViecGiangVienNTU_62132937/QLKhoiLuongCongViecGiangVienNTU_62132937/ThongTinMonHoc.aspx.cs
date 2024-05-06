using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class ThongTinMonHoc : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        ExecutedID MaTuDong=new ExecutedID();
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
                //ddlLoaiMon.SelectedItem.Text = "--Chọn loại môn học --";
                //txtMaMon.Enabled = false;
                //ddlHeDaoTao.SelectedItem.Text = "--Chọn hệ đào tạo--";
                LoadLoaiMon();
                LoadHeDT();
                LoadGrid();
                txtMaMon.Enabled = false;
                txtTenMon.Enabled = false;
                txtSoTiet.Enabled = false;
                txtGhiChu.Enabled = false;
                ddlLoaiMon.Enabled = false;

            }
        }
        /// <summary>
        /// Lấy về hệ đào tạo
        /// </summary>
        public void LoadHeDT()
        {
            var hedaotao = (from c in ql.HeDaoTao
                            select new { c.MaHDT, c.TenHeDT }).Distinct();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHDT");
            dt.Columns.Add("TenHeDT");
            DataRow dr;
            foreach (var item in hedaotao)
            {
                dr = dt.NewRow();
                dr["MaHDT"] = item.MaHDT.ToString();
                dr["TenHeDT"] = item.TenHeDT.ToString();
                dt.Rows.Add(dr);
            }
            ddlHeDaoTao.DataSource = dt;
            ddlHeDaoTao.DataValueField = "MaHDT";
            ddlHeDaoTao.DataTextField = "TenHeDT";
            ddlHeDaoTao.DataBind();
            ddlHeDaoTao.Items.Insert(0, new ListItem("--Chọn hệ đào tạo--", "0"));
        }
        //Lấy về loại môn
        public void LoadLoaiMon()
        {
            var LoaiMon = from c in ql.LoaiMon
                              //where c.MaLoai==c.LoaiMon.MaLoai
                          select new { c.MaLoai, c.TenLoai };

            DataTable dt = new DataTable();
            dt.Columns.Add("MaLoai");
            dt.Columns.Add("TenLoai");
            DataRow dr;
            foreach (var item in LoaiMon)
            {
                dr = dt.NewRow();
                dr["MaLoai"] = item.MaLoai.ToString();
                dr["TenLoai"] = item.TenLoai.ToString();
                dt.Rows.Add(dr);
            }


            ddlLoaiMon.DataSource = dt;
            ddlLoaiMon.DataValueField = "MaLoai";
            ddlLoaiMon.DataTextField = "TenLoai";
            ddlLoaiMon.DataBind();
            ddlLoaiMon.Items.Insert(0, new ListItem("--Chọn loại môn--", "0"));
        }

        //làm rỗng các điều khiển
        public void Refresh1()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtSoTiet.Text = "";
            txtGhiChu.Text = "";
            //ddlLoaiMon.SelectedItem.Text = "--Chọn loại môn học --";
            //ddlLoaiMon.SelectedValue = "0";

        }

        /// <summary>
        /// Xây dựng phương thức kiểm tra rỗng
        /// </summary>
        /// <returns></returns>
        public bool KiemTraRong()
        {
            bool kt = false;
            if (txtTenMon.Text == "" || txtSoTiet.Text == "")
            //if (txtMaLop.Text == "")
            {
                return true;
            }
            else
            {
                if (txtTenMon.Text != "" && txtSoTiet.Text != "")
                {
                    return false;
                }

            }
            return kt;

        }
        //xây dựng phương thức load gridview
        public void LoadGrid()
        {
            var DSMonHoc = from c in ql.MonHoc
                           select new { c.LoaiMon.TenLoai, c.MaMon, c.SoTiet, c.TenMon, c.GhiChu, c.HeDaoTao.TenHeDT };
            DataTable dt = new DataTable();
            dt.Columns.Add("MaMon");
            dt.Columns.Add("TenMon");
            dt.Columns.Add("TenLoai");
            dt.Columns.Add("SoTiet");
            dt.Columns.Add("TenHeDT");
            dt.Columns.Add("GhiChu");
            DataRow dr;
            foreach (var item in DSMonHoc)
            {
                dr = dt.NewRow();
                dr["MaMon"] = item.MaMon.ToString();
                dr["TenMon"] = item.TenMon.ToString();
                dr["TenLoai"] = item.TenLoai.ToString();
                dr["SoTiet"] = item.SoTiet.ToString();
                dr["TenHeDT"] = item.TenHeDT.ToString();
                dr["GhiChu"] = item.GhiChu.ToString();
                dt.Rows.Add(dr);
            }
            GrvMonHoc.DataSource = dt;
            GrvMonHoc.DataBind();
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            txtMaMon.Text = MaTuDong.LayMaMonHoc().ToString();
            try
            {
                //if (ddlHeDaoTao.SelectedValue=="0")
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn chưa chọn hệ đào tạo');", true);
                //}
                if (KiemTraRong() == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Không được để trống tên môn  hoặc số tiết');", true);
                    Refresh1();
                }

                else
                {
                    if (KiemTraRong() == false)
                    {
                        MonHoc sj = new MonHoc();
                        sj.MaHeDT = lblMahedt.Text;
                        sj.MaLoai = ddlLoaiMon.SelectedValue;
                        sj.MaMon = txtMaMon.Text;
                        sj.TenMon = txtTenMon.Text;
                        //sj.NumberPeriod =int.TryParse( txtSoTiet.Text,out int NumberPeriod );
                        int sotiet;
                        Int32.TryParse(txtSoTiet.Text, out sotiet);
                        sj.SoTiet = sotiet;
                        sj.GhiChu = txtGhiChu.Text;
                        ql.MonHoc.Add(sj);
                        ql.SaveChanges();
                        LoadGrid();
                        //Refresh1();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);
                        Response.Redirect("ThongTinMonHoc.aspx");
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
                MonHoc sj = ql.MonHoc.SingleOrDefault(c => c.MaMon == txtMaMon.Text);
                //sj.MaLoai = ddlLoaiMon.SelectedValue;
                sj.MaLoai = lblMaLM.Text;
                sj.MaHeDT = lblMahedt.Text;

                sj.MaMon = txtMaMon.Text;
                sj.TenMon = txtTenMon.Text;
                sj.SoTiet = Convert.ToInt32(txtSoTiet.Text);
                sj.GhiChu = txtGhiChu.Text;
                ql.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn sửa thành công');", true);
                //Refresh1();
                txtTenMon.Focus();
                Response.Redirect("ThongTinMonHoc.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa chọn môn muốn sửa');", true);
            }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn có muốn xóa không');", true);
                MonHoc sj = ql.MonHoc.SingleOrDefault(c => c.MaMon == txtMaMon.Text);
                ql.MonHoc.Remove(sj);
                ql.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn xóa thành công');", true);

                //Refresh1();
                txtTenMon.Focus();
                Response.Redirect("ThongTinMonHoc.aspx");
            }

            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa chọn môn muốn xóa');", true);
            }
        }
        protected void GrvMonHoc_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lblMa = (Label)GrvMonHoc.Rows[e.NewSelectedIndex].FindControl("lblMa");
            MonHoc sj = ql.MonHoc.SingleOrDefault(c => c.MaMon == lblMa.Text);
            //ddlLoaiMon.Text = sj.MaLoai.ToString();
            if (sj.MaLoai == sj.LoaiMon.MaLoai)
            {
                ddlLoaiMon.SelectedValue = sj.MaLoai;
                ddlLoaiMon.SelectedItem.Text = sj.LoaiMon.TenLoai;
            }
            //ddlLoaiMon.SelectedItem.Text = sj.LoaiMon.TenLoai;
            //
            if (sj.MaHeDT == sj.HeDaoTao.MaHDT)
            {
                ddlHeDaoTao.SelectedValue = sj.MaHeDT;
                ddlHeDaoTao.SelectedItem.Text = sj.HeDaoTao.TenHeDT;
            }
            //ddlHeDaoTao.SelectedItem.Text = sj.HeDaoTao.TenHeDT;
            //ddlHeDaoTao.SelectedValue = sj.MaHeDT.ToString();
            lblMaLM.Text = sj.MaLoai;
            lblMahedt.Text = sj.MaHeDT;
            txtMaMon.Text = sj.MaMon.ToString();
            txtTenMon.Text = sj.TenMon.ToString();
            txtSoTiet.Text = sj.SoTiet.ToString();
            txtGhiChu.Text = sj.GhiChu.ToString();

            txtMaMon.Enabled = false;
            txtTenMon.Enabled = true;
            txtSoTiet.Enabled = true;
            txtGhiChu.Enabled = true;
            ddlLoaiMon.Enabled = true;
        }
        protected void GrvMonHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvMonHoc.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
        protected void btnMoi_Click(object sender, EventArgs e)
        {
            //Refresh1();
            Response.Redirect("ThongTinMonHoc.aspx");
            //txtMaMon.Enabled = false;
            //txtTenMon.Enabled = false;
            //txtSoTiet.Enabled = false;
            //txtGhiChu.Enabled = false;
            //ddlLoaiMon.Enabled = false;

        }
        protected void ddlHeDaoTao_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMahedt.Text = ddlHeDaoTao.SelectedValue.ToString();
            txtMaMon.Enabled = false;
            txtTenMon.Enabled = true;
            txtSoTiet.Enabled = true;
            txtGhiChu.Enabled = true;
            ddlLoaiMon.Enabled = true;
        }
        protected void ddlLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMaLM.Text = ddlLoaiMon.SelectedValue;
        }
        protected void btnTim_Click(object sender, EventArgs e)
        {
            var thongtinmh = from c in ql.MonHoc
                             where c.MaMon.Contains(txtMa.Text.Trim()) || c.TenMon.Contains(txtMa.Text.Trim()) || c.HeDaoTao.TenHeDT.Contains(txtMa.Text.Trim()) || c.LoaiMon.TenLoai.Contains(txtMa.Text.Trim())
                              && c.MaHeDT == c.HeDaoTao.MaHDT && c.MaLoai == c.LoaiMon.MaLoai
                             select new { c.LoaiMon.TenLoai, c.MaMon, c.SoTiet, c.TenMon, c.GhiChu, c.HeDaoTao.TenHeDT };
            GrvMonHoc.DataSource = thongtinmh.ToList();
            GrvMonHoc.DataBind();
        }
    }

}