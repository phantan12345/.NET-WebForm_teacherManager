using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class Logout : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            hplQuenMK.Visible = true;
            Session.Contents["TrangThai"] = "ChuaDangNhap";
            Session["MemberID"] = "";
        }
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
        MaHoa mh = new MaHoa();
        protected void btDangNhap_Click(object sender, EventArgs e)
        {
            #region
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || (string.IsNullOrEmpty(txtPassword.Text.Trim())))
            {
                lblthongbao.Text = "Hãy kiểm tra lại tên đăng nhập và mật khẩu";
                return;
            }
            var ac = from c in ql.TaiKhoan
                     where c.TenDangNhap == txtUserName.Text
                     select c;
            bool kt = false;
            foreach (TaiKhoan account in ac)
            {
                if ((txtUserName.Text == account.TenDangNhap) && (mh.Encrypt("tk61", txtPassword.Text + "") == account.MatKhau) && (account.Quyen.ToString() == "Giáo vụ"))
                {
                    kt = true;
                    Session["Dangnhap"] = txtUserName.Text.ToString();
                    Session["MemberID"] = account.MaGV;
                    Session.Contents["TrangThai"] = "DaDangNhap";
                    string url = Request.QueryString["url"];
                    if (!string.IsNullOrEmpty(url))
                        Response.Redirect(url);
                    else
                        Response.Redirect("ThongTinCaNhan.aspx");
                }

                if ((txtUserName.Text == account.TenDangNhap) && (mh.Encrypt("tk61", txtPassword.Text + "") == account.MatKhau) && (account.Quyen.ToString() == "Giáo viên"))
                {
                    kt = true;
                    Session["Dangnhap"] = txtUserName.Text.ToString();
                    Session.Contents["TrangThai"] = "DaDangNhap";
                    Session["MemberID"] = account.MaGV;
                    string url = Request.QueryString["url"];
                    if (!string.IsNullOrEmpty(url))
                        Response.Redirect(url);
                    else
                        Response.Redirect("ThongTinCaNhan.aspx");
                }

                else
                {
                    if ((txtUserName.Text == account.TenDangNhap) || (txtPassword.Text == account.MatKhau))
                    {
                        lblthongbao.Text = "Bạn đăng nhập không thành công";
                        hplQuenMK.Visible = false;
                    }
                }
            }
            #endregion
        }
    }
}
