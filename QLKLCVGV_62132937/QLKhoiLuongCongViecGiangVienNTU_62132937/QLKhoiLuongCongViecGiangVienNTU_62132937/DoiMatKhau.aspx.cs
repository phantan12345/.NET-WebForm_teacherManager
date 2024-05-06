using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Dangnhap"] != null) && (Session.Contents["TrangThai"].ToString() == "DaDangNhap"))
            {

                var dangnhap = Session["Dangnhap"].ToString();

                var tt = from c in ql.TaiKhoan where c.TenDangNhap == dangnhap select new { c.TenDangNhap };

                foreach (var item in tt)
                {
                    txtUserName.Text = item.TenDangNhap.Trim();

                }
            }
            else
                if ((Session.Contents["TrangThai"].ToString() == "ChuaDangNhap") && (Session["Dangnhap"] == null))
            {
                Response.Redirect("Login.aspx?url=" + Request.Url.PathAndQuery);
            }

        }
        protected void btDoiMK_Click(object sender, EventArgs e)
        {
            TaiKhoan ac = ql.TaiKhoan.SingleOrDefault(c => c.TenDangNhap == txtUserName.Text && c.MaGV == c.GiaoVien.MaGV && c.MatKhau == txtPasswordcu.Text.Trim());
            if (txtnhappassmoi.Text == txtpassmoi.Text)
            {
                ac.MatKhau = txtpassmoi.Text;
                //db.SubmitChanges();

                ql.SaveChanges();
                lblThongbao.Text = "Bạn đổi mật khẩu thành công";
                Response.Redirect("ThongTinCaNhan.aspx");
            }
            else
                lblThongbao.Text = "Bạn nhập lại mật khẩu mới không đúng";

        }
    }
}
