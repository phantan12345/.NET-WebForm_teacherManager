using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class NhapNhanVienTuExcel : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 tcm = new QUANLYGIANGVIENEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Load thong tin giang vien len gridview
        public void LoadGridView()
        {
            var GiangVien = from c in tcm.GiaoVien
                            select c;
            grvGiangVien1.DataSource = GiangVien;
            grvGiangVien1.DataBind();
        }
        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="fUpload">The upload control .</param>
        /// <param name="fPath">The path string.</param>
        public static string UploadFile(FileUpload fUpload)
        {
            string fPath = String.Empty;
            try
            {
                fPath = HttpContext.Current.Server.MapPath("~/upload/" + fUpload.FileName);
                FileInfo fInfo = new FileInfo(fPath);
                if (fInfo.Exists)
                {
                    fInfo.Delete();
                }
                fUpload.SaveAs(fPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return fPath;
        }
        protected void btnLoadExcel_Click(object sender, EventArgs e)
        {
            UploadFile(fulExcel);
        }
        protected string valid(OleDbDataReader myreader, int stval)//if any columns are found null then they are replaced by zero
        {
            object val = myreader[stval];
            if (val != DBNull.Value)
                return val.ToString();
            else
                return Convert.ToString(0);
        }
        public void ThemGiangVien(string MaGV, string TenGV, string GioiTinh, string NgaySinh, string SoCMTND, string Anh, string TrinhDoHocVan, string MaChucVu,
          string MaChucDanh, string NamVaoLam, string Email, string DiaChi, string GhiChu)
        {
            Anh = "0";
            GiaoVien gv = new GiaoVien();
            gv.MaGV = MaGV;
            gv.TenGV = TenGV;
            gv.GioiTinh = GioiTinh;
            gv.NgaySinh = DateTime.Parse(NgaySinh);
            gv.SoCMTND = SoCMTND;
            gv.Anh = Anh;
            gv.TrinhDoHocVan = TrinhDoHocVan;
            gv.MaChucDanh = MaChucDanh;
            gv.MaChucVu = MaChucVu;
            gv.NamVaoLam = NamVaoLam;
            gv.Email = Email;
            gv.DiaChi = DiaChi;
            gv.GhiChu = GhiChu;
            tcm.GiaoVien.Add(gv);
            tcm.SaveChanges();
            LoadGridView();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('Bạn thêm thành công');", true);
        }
        protected void btnCapNhatVaoCSDL_Click(object sender, EventArgs e)
        {
            OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/upload/*.xls") + ";Extended Properties=Excel 8.0");
            try
            {
                OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
                oconn.Open();
                OleDbDataReader odr = ocmd.ExecuteReader();
                string MaGV = "";
                string TenGV = "";
                string GioiTinh = "";
                string NgaySinh = "";
                string SoCMTND = "";
                string Anh = "";
                string TrinhDoHocVan = "";
                string MaChucVu = "";
                string MaChucDanh = "";
                string NamVaoLam = "";
                string Email = "";
                string DiaChi = "";
                string GhiChu = "";
                while (odr.Read())
                {
                    MaGV = valid(odr, 0);
                    TenGV = valid(odr, 1);
                    GioiTinh = valid(odr, 2);
                    NgaySinh = valid(odr, 3);
                    SoCMTND = valid(odr, 4);
                    TrinhDoHocVan = valid(odr, 5);
                    Anh = valid(odr, 6);
                    MaChucDanh = valid(odr, 7);
                    MaChucVu = valid(odr, 8);
                    NamVaoLam = valid(odr, 9);
                    Email = valid(odr, 10);
                    DiaChi = valid(odr, 11);
                    GhiChu = valid(odr, 12);
                    ThemGiangVien(MaGV, TenGV, GioiTinh, NgaySinh, SoCMTND, Anh, TrinhDoHocVan, MaChucVu, MaChucDanh, NamVaoLam, Email, DiaChi, GhiChu);
                }
                oconn.Close();
            }
            catch (DataException ee)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert(Quá trình thêm đã có lỗi xảy ra);", true);
            }
            //finally
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert(Quá trình thêm đã có lỗi xảy ra);", true);
            //}
        }
    }
}