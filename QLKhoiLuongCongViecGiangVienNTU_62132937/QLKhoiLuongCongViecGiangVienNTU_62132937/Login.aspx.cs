using System;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.SessionState;
using System.Data.Entity;
using Azure;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class Login : System.Web.UI.Page
    {
        MaHoa mh = new MaHoa();
        QUANLYGIANGVIENEntities2 tm = new QUANLYGIANGVIENEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            hplQuenMK.Visible = true;
            //Session.Contents["TrangThai"] = "ChuaDangNhap";
        }

        protected void btDangNhap_Click(object sender, EventArgs e)
        {
            #region
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || (string.IsNullOrEmpty(txtPassword.Text.Trim())))
            {
                lblthongbao.Text = "Hãy kiểm tra lại tên đăng nhập và mật khẩu";
                return;
            }
            var ac = from c in tm.TaiKhoan
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
                        Response.Redirect("ChaoMung.aspx");
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
                        Response.Redirect("ChaoMung.aspx");
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