using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class QuenMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        QUANLYGIANGVIENEntities2 st = new QUANLYGIANGVIENEntities2();
        MaHoa mh = new MaHoa();

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {

                var abc = st.st_QuenMatKhau(txtUsername.Text, txtEmail.Text);
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Credentials = new System.Net.NetworkCredential("2051050435tan@ou.edu.vn", "0372745193");
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                MailMessage omail = new MailMessage();
                foreach (var item in abc)
                {
                    omail.From = new MailAddress("2051050435tan@ou.edu.vn", "Admin");
                    omail.To.Add(txtEmail.Text);
                    omail.Subject = "Mật khẩu quản trị";
                    omail.Body = "Mật khẩu của bạn là: " + mh.Decrypt("tk61", item.matkhau.ToString().Trim());
                    omail.Priority = MailPriority.High;
                    omail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    omail.ReplyTo = new MailAddress(txtEmail.Text);
                    lblThongBao.Text = "Mật khẩu được gửi thành công";
                    SmtpServer.Send(omail);
                }

            }
            catch (Exception ex)
            {

                lblThongBao.Text = "Sai Email hoặc maatk khẩu";
            }
        }
    }
}