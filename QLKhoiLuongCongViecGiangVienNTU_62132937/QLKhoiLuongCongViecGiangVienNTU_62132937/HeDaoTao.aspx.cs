using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class HeDaoTao1 : System.Web.UI.Page
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
                txtMaHeDT.Enabled = false;
                LoadGrid();
                Refresh1();
            }

        }
        //xây dựng phương thức làm rỗng
        public void Refresh1()
        {
            txtMaHeDT.Text = "";
            txtTenHeDT.Text = "";
            txtSoBuoiCho1DVHT.Text = "";
            txtMota.Text = "";

        }
        /// <summary>
        /// Xây dựng phương thức kiểm tra rỗng
        /// </summary>
        /// <returns></returns>
        public bool KiemTraRong()
        {
            bool kt = false;
            if (txtTenHeDT.Text == "" || txtSoBuoiCho1DVHT.Text == "")
            //if (txtMaLop.Text == "")
            {
                return true;
            }
            else
            {
                if (txtTenHeDT.Text != "" && txtSoBuoiCho1DVHT.Text != "")
                {
                    return false;
                }

            }
            return kt;

        }
        //xây dựng phương thức load gridview
        public void LoadGrid()
        {
            var DSHDT = from c in ql.HeDaoTao
                        select c;
            GrvHeDT.DataSource = DSHDT.ToList();
            GrvHeDT.DataBind();
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHeDT.Text = ex.LayMaHDT().ToString();
            try
            {
                if (KiemTraRong() == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Không được để trống tên hệ đào tạo hoặc số buổi trên 1 đơn vị HT');", true);
                    Refresh1();
                }
                else
                {
                    if (KiemTraRong() == false)
                    {
                        HeDaoTao hc = new HeDaoTao();
                        hc.MaHDT = txtMaHeDT.Text;
                        hc.TenHeDT = txtTenHeDT.Text;
                        hc.SoBuoiTren1DVHocTrinh = Convert.ToInt32(txtSoBuoiCho1DVHT.Text);
                        hc.GhiChu = txtMota.Text;
                        ql.HeDaoTao.Add(hc);
                        ql.SaveChanges();
                        LoadGrid();
                        //Refresh1();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn đã thêm thành công');", true);
                        Response.Redirect("HeDaoTao.aspx");
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
                HeDaoTao hc = ql.HeDaoTao.SingleOrDefault(c => c.MaHDT == txtMaHeDT.Text);
                hc.MaHDT = txtMaHeDT.Text;
                hc.TenHeDT = txtTenHeDT.Text;
                hc.SoBuoiTren1DVHocTrinh = Convert.ToInt32(txtSoBuoiCho1DVHT.Text);
                hc.GhiChu = txtMota.Text;
                ql.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn sửa thành công');", true);
                //Refresh1();
                txtTenHeDT.Focus();
                Response.Redirect("HeDaoTao.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa chọn hệ đào tạo muốn sửa');", true);
            }

        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn có muốn xóa không');", true);
                HeDaoTao hc = ql.HeDaoTao.SingleOrDefault(c => c.MaHDT == txtMaHeDT.Text);
                ql.HeDaoTao.Remove(hc);
                ql.SaveChanges();
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn xóa thành công');", true);

                //Refresh1();
                txtTenHeDT.Focus();
                Response.Redirect("HeDaoTao.aspx");
            }

            catch (Exception)
            {

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa chọn hệ đào tạo muốn xóa');", true);
            }
        }

        protected void GrvHeDT_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label lblMa = (Label)GrvHeDT.Rows[e.NewSelectedIndex].FindControl("lblMa");
            HeDaoTao hc = ql.HeDaoTao.SingleOrDefault(c => c.MaHDT == lblMa.Text);
            txtMaHeDT.Text = hc.MaHDT.ToString();
            txtTenHeDT.Text = hc.TenHeDT.ToString();
            txtSoBuoiCho1DVHT.Text = hc.SoBuoiTren1DVHocTrinh.ToString();
            txtMota.Text = hc.GhiChu.ToString();

        }
        protected void GrvHeDT_PageIndexChanging(object sender, GridViewPageEventArgs e)

        {
            GrvHeDT.PageIndex = e.NewPageIndex;
            LoadGrid();

        }
        protected void btnMoi_Click(object sender, EventArgs e)
        {
            Refresh1();
        }
    }
}