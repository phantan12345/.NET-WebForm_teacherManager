using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public partial class ThongKeGiangDayTheoGiangVien : System.Web.UI.Page
    {
        QUANLYGIANGVIENEntities2 ql = new QUANLYGIANGVIENEntities2();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {
                var Dangnhap = Session["Dangnhap"].ToString();
                var MemberID = Session["MemberID"].ToString();
                var tt = from c in ql.TaiKhoan
                         where (c.TenDangNhap == Dangnhap && c.MaGV.ToString() == MemberID && c.MaGV == c.GiaoVien.MaGV)
                         select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
                foreach (var item in tt)
                {

                    //txtGiaoVien.Text = item.TenGV;
                    if (Session["MemberID"].ToString() == item.MaGV.ToString() && item.Quyen == "Giáo vụ")
                    {
                        //Response.Redirect("Login.aspx?url=" + Request.Url.PathAndQuery);
                        //xuly();
                        //ddlMaGV.Enabled = true;
                        txtTenGV.Visible = false;
                        ddlMaGV.Visible = true;
                        ddlMaGV.Enabled = true;
                    }
                    else
                    {
                        if (Session["MemberID"].ToString() == item.MaGV.ToString() && item.Quyen == "Giáo viên")
                        {
                            //LayGV();
                            txtTenGV.Text = item.TenGV;
                            ddlMaGV.SelectedItem.Text = item.TenGV;
                            ddlMaGV.Visible = false;
                            lblMa.Text = Session["MemberID"].ToString();

                        }
                    }
                }
            }
            else
            {
                if (Session.Contents["TrangThai"].ToString() == "ChuaDangNhap")
                    Response.Redirect("Login.aspx?url=" + Request.Url.PathAndQuery);
            }
            if (!IsPostBack)
            {
                //LayGV();
                LoadNamHoc();
                LoadGiangVien();
                Label1.Visible = false;
                Label2.Visible = false;
                ddlNamHoc.Items.Insert(0, new ListItem("--Chọn năm học--", "0"));
            }

            //xuly();
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
        /// Xây dựng phương thức load giang viên
        /// </summary>
        public void LoadGiangVien()
        {
            var GiangVien = from c in ql.GiaoVien
                                //where c.MaGV==ma
                            select new {c.TenGV,c.MaGV};
            ddlMaGV.DataSource = GiangVien.ToList();
            ddlMaGV.DataTextField = "TenGV";
            ddlMaGV.DataValueField = "MaGV";
            ddlMaGV.DataBind();
            ddlMaGV.Items.Insert(0, new ListItem("--Chọn giáo viên--", "0"));
        }

        /// <summary>
        /// Xử lý việc tính giờ các hoạt động của giảng viên trong giảng dạy
        /// </summary>
        public void xuly()
        {
            //var lop = ql.st_LayLopDTTinChi(ddlMaGV.SelectedValue);
            //lay ve thong tin lop học theo tin chỉ và học lý thuyết có mã môn học LM101 học trung cấp chuyên nghiệp , VLVH
            var lop = ql.st_LayLopDTNienChe(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //lay ve thong tin lop học theo niên chế học đại học , cao đẳng và học lý thuyết có mã môn học LM101
            var lopnc = ql.st_LayLopDTNienCheDHCD(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //lấy lớp đào tạo tín chỉ là đại học cao đẳng học lý thyết có mã môn LM01
            var loptc = ql.st_LayLopDTTinChiDHCD(lblMa.Text, ddlNamHoc.SelectedItem.Text);

            //lay thuc hanh voi ma loai mon LM02
            var lopth = ql.st_LayLopThucHanhGV(lblMa.Text, ddlNamHoc.SelectedItem.Text);

            //thực hành của lớp đào tạo theo TCCN
            var TCCN = ql.st_LayLopTHTCCN(lblMa.Text, ddlNamHoc.SelectedItem.Text);

            //lay ve thong tin lop làm project có mã môn học LM03
            var project = ql.Project(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //lay ve thong tin lop thực tập sư phạm có mã môn học LM04
            var TTSP = ql.st_SuPham(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //lay ve thong tin lop thực xí nghiệp có mã môn học LM05
            var TTXN = ql.st_TTxiNghiep(lblMa.Text, ddlNamHoc.SelectedItem.Text);

            //Lấy về thông tin Hướng dẫn nghiên cứu khoa học nam cuối
            var HDNCKH_NamCuoi = ql.st_HDNCKH_NamCuoi(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //Lấy về thông tin Hướng dẫn nghiên cứu khoa học của sinh viên 1, 2,3
            var HDNCKH_NamGanCuoi = ql.st_HDNCKH_NamGanCuoi(lblMa.Text, ddlNamHoc.SelectedItem.Text);

            //Lấy về thông tin Giáo viên nghiên cứu khoa học cấp trường
            var GV_NCKH_CapTruong = ql.GiaoVien_NCKH_CapTruong(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //Lấy về thông tin Giáo viên nghiên cứu khoa học cấp bộ
            var GV_NCKH_CapBo = ql.GiaoVien_NCKH_CapBo(lblMa.Text, ddlNamHoc.SelectedItem.Text);

            //lấy thông tin đồ án
            var DoAn = ql.LoadDoAnTotNghiep(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //lấy thông tin quản lý phòng máy
            var Qlpm = ql.st_LoadQuanLyPhongMay(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //var lấy số % giờ chuẩn ựược giảm cho giảng viên có chức vụ tương ứng
            var CV = ql.st_LoadGiangVienChucVu(lblMa.Text);
            double hs = 1;
            double SOGIODAY = 0;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("TenMon");
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("SOGIODAY");
            DataRow dr1;
            #region Tính giờ % chức vụ
            foreach (var cv in CV)
            {
                SOGIODAY = (double.Parse(cv.PhanTramDuocGiam.ToString()) * double.Parse(cv.SoGioChuan.ToString())) * 2 / 100;
                dr1 = dt1.NewRow();
                dr1["TenMon"] = cv.TenChucVu;
                dr1["SOGIODAY"] = SOGIODAY;
                dr1["GhiChu"] = cv.PhanTramDuocGiam + "\t% giờ chuẩn";
                dt1.Rows.Add(dr1);
            }
            #endregion
            #region Tính giờ quản lý phòng máy
            foreach (var qlpm in Qlpm)
            {
                SOGIODAY = double.Parse(qlpm.SoLuongPM.ToString()) * 40;
                dr1 = dt1.NewRow();
                dr1["TenMon"] = "Quản lý và bảo trì phòng máy";
                dr1["SOGIODAY"] = SOGIODAY;
                dr1["GhiChu"] = qlpm.GhiChu;
                dt1.Rows.Add(dr1);
            }
            grvViecNgoaiGio.DataSource = dt1;
            grvViecNgoaiGio.DataBind();
            #endregion
            //double SoGioThucTeDay = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("TenMon");
            dt.Columns.Add("SoTiet");
            dt.Columns.Add("TenLop");
            dt.Columns.Add("SiSo");
            dt.Columns.Add("hs");
            dt.Columns.Add("SOGIODAY");
            dt.Columns.Add("GhiChu");
            DataRow dr;

            //Tính giờ ra đề và hướng dẫn đồ án
            foreach (var da in DoAn)
            {
                if (da.SoDeTai.ToString() != "0")
                {
                    SOGIODAY = double.Parse(da.SoDeTai.ToString()) * 12;
                    dr = dt.NewRow();
                    dr["TenMon"] = "Ra đề hướng dẫn đồ án";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = da.TenLop;
                    dr["SiSo"] = da.SoDeTai;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = da.SoDeTai + "\tÐồ án";
                    dt.Rows.Add(dr);
                }
                //Tính giờ chấm đồ án
                if (da.SoBuoiChamBai.ToString() != "0")
                {
                    SOGIODAY = double.Parse(da.SoBuoiChamBai.ToString()) * 2;
                    dr = dt.NewRow();
                    dr["TenMon"] = "Chấm đồ án";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = da.TenLop;
                    dr["SiSo"] = da.SoBuoiChamBai;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = da.SoBuoiChamBai + "\tsố buổi chấm";
                    dt.Rows.Add(dr);
                }
                //Tính giờ phản biện đồ án
                if (da.SoDoAnPBien.ToString() != "0")
                {
                    SOGIODAY = double.Parse(da.SoDoAnPBien.ToString()) * 2;
                    dr = dt.NewRow();
                    dr["TenMon"] = "Phản biện đồ án tốt nghệp";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = da.TenLop;
                    dr["SiSo"] = da.SoDoAnPBien;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = da.SoDoAnPBien + "\tÐồ án";
                    dt.Rows.Add(dr);
                }
            }

            #region
            foreach (var capbo in GV_NCKH_CapBo)
            {
                dr = dt.NewRow();
                dr["TenMon"] = "Nghiên cứu khoa học";
                dr["SoTiet"] = 120;
                dr["TenLop"] = capbo.TenDeTai;
                dr["SiSo"] = 1;
                dr["hs"] = 1;
                dr["sogioday"] = 120;
                dr["GhiChu"] = capbo.NamThamGiaNC + "(Cấp bộ)";
                dt.Rows.Add(dr);
            }
            #endregion
            #region
            foreach (var captruong in GV_NCKH_CapTruong)
            {
                dr = dt.NewRow();
                dr["TenMon"] = "Nghiên cứu khoa học";
                dr["SoTiet"] = 60;
                dr["TenLop"] = captruong.TenDeTai;
                dr["SiSo"] = 1;
                dr["hs"] = 1;
                dr["sogioday"] = 60;
                dr["GhiChu"] = captruong.NamThamGiaNC + "(Cấp trường)";
                dt.Rows.Add(dr);
            }
            #endregion
            #region
            foreach (var ncgc in HDNCKH_NamGanCuoi)
            {
                SOGIODAY = 20 * int.Parse(ncgc.SoLuong.ToString());
                dr = dt.NewRow();
                dr["TenMon"] = "Hướng dẫn nghiên cứu đề tài khoa học";
                dr["SoTiet"] = SOGIODAY;
                dr["TenLop"] = ncgc.GhiChu;
                dr["SiSo"] = ncgc.SoLuong;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = ncgc.NamHoc;
                dt.Rows.Add(dr);
            }
            #endregion
            #region
            foreach (var nc in HDNCKH_NamCuoi)
            {
                SOGIODAY = 10 * int.Parse(nc.SoLuong.ToString());
                dr = dt.NewRow();
                dr["TenMon"] = "Hướng dẫn nghiên cứu đề tài khoa học";
                dr["SoTiet"] = SOGIODAY;
                dr["TenLop"] = nc.GhiChu;
                dr["SiSo"] = nc.SoLuong;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = nc.NamHoc;
                dt.Rows.Add(dr);
            }
            #endregion
            //duyệt các bản ghi hướng dẫn thực tập sư phạm
            foreach (var item3 in TTSP)
            {
                #region

                //SOGIODAY = ((double.Parse(item3.SoTiet.ToString()) / 15)*5*3/30)*int.Parse(item3.SoSV.ToString());
                SOGIODAY = 1 * int.Parse(item3.SoSV.ToString()) * int.Parse(item3.SoTiet.ToString());
                dr = dt.NewRow();
                dr["TenMon"] = item3.TenMon;
                dr["SoTiet"] = item3.SoTiet;
                dr["TenLop"] = item3.TenLop;
                dr["SiSo"] = item3.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item3.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }

            //duyệt các bản ghi hướng dẫn project 
            foreach (var item2 in project)
            {
                #region

                SOGIODAY = int.Parse(item2.SoSV.ToString()) * 2;
                dr = dt.NewRow();
                dr["TenMon"] = item2.TenMon;
                dr["SoTiet"] = item2.SoTiet;
                dr["TenLop"] = item2.TenLop;
                dr["SiSo"] = item2.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item2.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }

            //tinh lớp thuc hành TCCN
            #region
            foreach (var tccn in TCCN)
            {

                if (int.Parse(tccn.SoSV.ToString()) < 20)
                {
                    hs = 0.75;

                }
                else
                {
                    if ((int.Parse(tccn.SoSV.ToString()) >= 20) && (int.Parse(tccn.SoSV.ToString()) <= 24))
                    {
                        hs = 0.85;
                    }
                    else
                    {
                        if ((int.Parse(tccn.SoSV.ToString()) == 25))
                        {
                            hs = 1;
                        }
                        else
                        {
                            if ((int.Parse(tccn.SoSV.ToString()) >= 26) && (int.Parse(tccn.SoSV.ToString()) <= 30))
                            {
                                hs = 1.1;
                            }
                            else
                            {
                                if ((int.Parse(tccn.SoSV.ToString()) >= 31) && (int.Parse(tccn.SoSV.ToString()) <= 35))
                                {
                                    hs = 1.2;
                                }
                                else
                                {
                                    if ((int.Parse(tccn.SoSV.ToString()) >= 36) && (int.Parse(tccn.SoSV.ToString()) <= 40))
                                    {
                                        hs = 1.4;
                                    }
                                }
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(tccn.SoTiet.ToString()) * 0.6 * hs * 0.8 * 1;
                dr = dt.NewRow();
                dr["TenMon"] = tccn.TenMon;
                dr["SoTiet"] = tccn.SoTiet;
                dr["TenLop"] = tccn.TenLop;
                dr["SiSo"] = tccn.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = tccn.TenLoai;
                dt.Rows.Add(dr);
            }
            #endregion

            //Tính lớp thực hành cac hệ ĐH, CĐ
            #region
            foreach (var item4 in lopth)
            {

                if (int.Parse(item4.SoSV.ToString()) < 20)
                {
                    hs = 0.75;

                }
                else
                {
                    if ((int.Parse(item4.SoSV.ToString()) >= 20) && (int.Parse(item4.SoSV.ToString()) <= 24))
                    {
                        hs = 0.85;
                    }
                    else
                    {
                        if ((int.Parse(item4.SoSV.ToString()) == 25))
                        {
                            hs = 1;
                        }
                        else
                        {
                            if ((int.Parse(item4.SoSV.ToString()) >= 26) && (int.Parse(item4.SoSV.ToString()) <= 30))
                            {
                                hs = 1.1;
                            }
                            else
                            {
                                if ((int.Parse(item4.SoSV.ToString()) >= 31) && (int.Parse(item4.SoSV.ToString()) <= 35))
                                {
                                    hs = 1.2;
                                }
                                else
                                {
                                    if ((int.Parse(item4.SoSV.ToString()) >= 36) && (int.Parse(item4.SoSV.ToString()) <= 40))
                                    {
                                        hs = 1.4;
                                    }
                                }
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(item4.SoTiet.ToString()) * 0.6 * hs * 1 * 1;
                dr = dt.NewRow();
                dr["TenMon"] = item4.TenMon;
                dr["SoTiet"] = item4.SoTiet;
                dr["TenLop"] = item4.TenLop;
                dr["SiSo"] = item4.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item4.TenLoai;
                dt.Rows.Add(dr);
            }
            #endregion


            //duyệt các bản ghi hướng dẫn thực tập xí nghiệp

            foreach (var item6 in TTXN)
            {

                #region
                if (int.Parse(item6.SoSV.ToString()) < 15)
                {
                    hs = 0.5;

                }
                else
                {
                    if ((int.Parse(item6.SoSV.ToString()) >= 15) && (int.Parse(item6.SoSV.ToString()) <= 24))
                    {
                        hs = 0.7;
                    }
                    else
                    {
                        if (int.Parse(item6.SoSV.ToString()) >= 25)
                        {
                            hs = 1;
                        }
                    }
                }
                SOGIODAY = (double.Parse(item6.SoTiet.ToString()) / 15) * 5 * 3 * hs;
                dr = dt.NewRow();
                dr["TenMon"] = item6.TenMon;
                dr["SoTiet"] = item6.SoTiet;
                dr["TenLop"] = item6.TenLop;
                dr["SiSo"] = item6.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item6.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }
            //lấy lớp đào tạo tín chỉ ĐH, Cao đẳng...
            foreach (var tc in loptc)
            {
                #region
                if (int.Parse(tc.SoSV.ToString()) < 60)
                {
                    hs = 1;

                }
                else
                {
                    if ((int.Parse(tc.SoSV.ToString()) >= 61) && (int.Parse(tc.SoSV.ToString()) < 100))
                    {
                        hs = 1.1;
                    }
                    else
                    {
                        if ((int.Parse(tc.SoSV.ToString()) >= 101) && (int.Parse(tc.SoSV.ToString()) <= 150))
                        {
                            hs = 1.2;
                        }
                        else
                        {
                            if (int.Parse(tc.SoSV.ToString()) > 150)
                            {
                                hs = 1.3;
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(tc.SoTiet.ToString()) * hs * 1 * 1 * 1 * 1.1;
                dr = dt.NewRow();
                dr["TenMon"] = tc.TenMon;
                dr["SoTiet"] = tc.SoTiet;
                dr["TenLop"] = tc.TenLop;
                dr["SiSo"] = tc.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = tc.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }

            //duyệt tất cả các bản ghi là lớp niên chế học lý thuyết thuộc đại học, cao đẳng
            foreach (var item1 in lopnc)
            {
                #region
                if (int.Parse(item1.SoSV.ToString()) < 60)
                {
                    hs = 1;

                }
                else
                {
                    if ((int.Parse(item1.SoSV.ToString()) >= 61) && (int.Parse(item1.SoSV.ToString()) < 100))
                    {
                        hs = 1.1;
                    }
                    else
                    {
                        if ((int.Parse(item1.SoSV.ToString()) >= 101) && (int.Parse(item1.SoSV.ToString()) <= 150))
                        {
                            hs = 1.2;
                        }
                        else
                        {
                            if (int.Parse(item1.SoSV.ToString()) > 150)
                            {
                                hs = 1.3;
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(item1.SoTiet.ToString()) * hs * 1 * 1 * 1;
                dr = dt.NewRow();
                dr["TenMon"] = item1.TenMon;
                dr["SoTiet"] = item1.SoTiet;
                dr["TenLop"] = item1.TenLop;
                dr["SiSo"] = item1.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item1.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }
            //duyêt tất cả các bản ghi của lớp trung cấp chuyên nghiệp, VLVH
            foreach (var item in lop)
            {
                if (int.Parse(item.SoSV.ToString()) < 60)
                {
                    hs = 1;

                }
                else
                {
                    if ((int.Parse(item.SoSV.ToString()) >= 61) && (int.Parse(item.SoSV.ToString()) < 100))
                    {
                        hs = 1.1;
                    }
                    else
                    {
                        if ((int.Parse(item.SoSV.ToString()) >= 101) && (int.Parse(item.SoSV.ToString()) <= 150))
                        {
                            hs = 1.2;
                        }
                        else
                        {
                            if (int.Parse(item.SoSV.ToString()) > 150)
                            {
                                hs = 1.3;
                            }
                        }
                    }
                }

                SOGIODAY = double.Parse(item.SoTiet.ToString()) * 1 * 1 * hs * 0.8;


                dr = dt.NewRow();
                dr["TenMon"] = item.TenMon;
                dr["SoTiet"] = item.SoTiet;
                dr["TenLop"] = item.TenLop;
                dr["SiSo"] = item.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item.TenLoai;
                dt.Rows.Add(dr);
            }
            GrvThongKeTheGiangVien.DataSource = dt;
            GrvThongKeTheGiangVien.DataBind();
            double tong1 = 0;
            double tong2 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tong1 += double.Parse(dt.Rows[i][5].ToString());
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                tong2 += double.Parse(dt1.Rows[i][2].ToString());
            }
            lblTong2.Text = tong2.ToString();
            lblTong1.Text = tong1.ToString();
        }
        /// <summary>
        /// Xử lý thống kê giờ của giảng viên nếu là giáo viên
        /// </summary>
        public void xuly1(string ma)
        {
            //var lop = ql.st_LayLopDTTinChi(ddlMaGV.SelectedValue);
            //lay ve thong tin lop học theo tin chỉ và học lý thuyết có mã môn học LM101 học trung cấp chuyên nghiệp , VLVH
            var lop = ql.st_LayLopDTNienChe(ma, ddlNamHoc.SelectedItem.Text);
            //lay ve thong tin lop học theo niên chế học đại học , cao đẳng và học lý thuyết có mã môn học LM101
            var lopnc = ql.st_LayLopDTNienCheDHCD(ma, ddlNamHoc.SelectedItem.Text);
            //lấy lớp đào tạo tín chỉ là đại học cao đẳng học lý thyết có mã môn LM01
            var loptc = ql.st_LayLopDTTinChiDHCD(ma, ddlNamHoc.SelectedItem.Text);

            //lay thuc hanh voi ma loai mon LM02
            var lopth = ql.st_LayLopThucHanhGV(ma, ddlNamHoc.SelectedItem.Text);

            //thực hành của lớp đào tạo theo TCCN
            var TCCN = ql.st_LayLopTHTCCN(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //lay ve thong tin lop làm project có mã môn học LM03
            var project = ql.Project(ma, ddlNamHoc.SelectedItem.Text);
            //lay ve thong tin lop thực tập sư phạm có mã môn học LM04
            var TTSP = ql.st_SuPham(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //lay ve thong tin lop thực xí nghiệp có mã môn học LM05
            var TTXN = ql.st_TTxiNghiep(ma, ddlNamHoc.SelectedItem.Text);

            //Lấy về thông tin Hướng dẫn nghiên cứu khoa học nam cuối
            var HDNCKH_NamCuoi = ql.st_HDNCKH_NamCuoi(ma, ddlNamHoc.SelectedItem.Text);
            //Lấy về thông tin Hướng dẫn nghiên cứu khoa học của sinh viên 1, 2,3
            var HDNCKH_NamGanCuoi = ql.st_HDNCKH_NamGanCuoi(ma, ddlNamHoc.SelectedItem.Text);
            //Lấy về thông tin Giáo viên nghiên cứu khoa học cấp trường
            var GV_NCKH_CapTruong = ql.GiaoVien_NCKH_CapTruong(ma, ddlNamHoc.SelectedItem.Text);
            //Lấy về thông tin Giáo viên nghiên cứu khoa học cấp bộ
            var GV_NCKH_CapBo = ql.GiaoVien_NCKH_CapBo(ma, ddlNamHoc.SelectedItem.Text);

            //lấy thông tin đồ án
            var DoAn = ql.LoadDoAnTotNghiep(ma, ddlNamHoc.SelectedItem.Text);

            //lấy thông tin quản lý phòng máy
            var Qlpm = ql.st_LoadQuanLyPhongMay(lblMa.Text, ddlNamHoc.SelectedItem.Text);
            //var lấy số % giờ chuẩn ựược giảm cho giảng viên có chức vụ tương ứng
            var CV = ql.st_LoadGiangVienChucVu(lblMa.Text);

            double hs = 1;
            double SOGIODAY = 0;
            double SoGioThucTeDay = 0;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("TenMon");
            dt1.Columns.Add("GhiChu");
            dt1.Columns.Add("SOGIODAY");
            DataRow dr1;
            #region Tính giờ % chức vụ
            foreach (var cv in CV)
            {
                SOGIODAY = (double.Parse(cv.PhanTramDuocGiam.ToString()) * double.Parse(cv.SoGioChuan.ToString())) * 2 / 100;
                dr1 = dt1.NewRow();
                dr1["TenMon"] = cv.TenChucVu;
                dr1["SOGIODAY"] = SOGIODAY;
                dr1["GhiChu"] = cv.PhanTramDuocGiam + "\t% giờ chuẩn";
                dt1.Rows.Add(dr1);
            }
            #endregion
            #region Tính giờ quản lý phòng máy
            foreach (var qlpm in Qlpm)
            {
                SOGIODAY = double.Parse(qlpm.SoLuongPM.ToString()) * 40;
                dr1 = dt1.NewRow();
                dr1["TenMon"] = "Quản lý và bảo trì phòng máy";
                dr1["SOGIODAY"] = SOGIODAY;
                dr1["GhiChu"] = qlpm.GhiChu;
                dt1.Rows.Add(dr1);
            }
            grvViecNgoaiGio.DataSource = dt1;
            grvViecNgoaiGio.DataBind();
            #endregion
            DataTable dt = new DataTable();
            dt.Columns.Add("TenMon");
            dt.Columns.Add("SoTiet");
            dt.Columns.Add("TenLop");
            dt.Columns.Add("SiSo");
            dt.Columns.Add("hs");
            dt.Columns.Add("SOGIODAY");
            dt.Columns.Add("GhiChu");
            DataRow dr;

            //Tính giờ ra đề và hướng dẫn đồ án
            foreach (var da in DoAn)
            {

                if (da.SoDeTai.ToString() != "0")
                {
                    SOGIODAY = double.Parse(da.SoDeTai.ToString()) * 12;
                    dr = dt.NewRow();
                    dr["TenMon"] = "Ra đề hướng dẫn đồ án";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = da.TenLop;
                    dr["SiSo"] = da.SoDeTai;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = da.SoDeTai + "\tÐồ án";
                    dt.Rows.Add(dr);
                }
                //Tính giờ chấm đồ án
                if (da.SoBuoiChamBai.ToString() != "0")
                {
                    SOGIODAY = double.Parse(da.SoBuoiChamBai.ToString()) * 2;
                    dr = dt.NewRow();
                    dr["TenMon"] = "Chấm đồ án";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = da.TenLop;
                    dr["SiSo"] = da.SoBuoiChamBai;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = da.SoBuoiChamBai + "\tsố buổi chấm";
                    dt.Rows.Add(dr);
                }
                //Tính giờ phản biện đồ án
                if (da.SoDoAnPBien.ToString() != "0")
                {
                    SOGIODAY = double.Parse(da.SoDoAnPBien.ToString()) * 2;
                    dr = dt.NewRow();
                    dr["TenMon"] = "Phản biện đồ án tốt nghệp";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = da.TenLop;
                    dr["SiSo"] = da.SoDoAnPBien;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = da.SoDoAnPBien + "\tÐồ án";
                    dt.Rows.Add(dr);
                }
            }

            #region
            foreach (var capbo in GV_NCKH_CapBo)
            {
                dr = dt.NewRow();
                dr["TenMon"] = "Nghiên cứu khoa học";
                dr["SoTiet"] = 120;
                dr["TenLop"] = capbo.TenDeTai;
                dr["SiSo"] = 1;
                dr["hs"] = 1;
                dr["sogioday"] = 120;
                dr["GhiChu"] = capbo.NamThamGiaNC + "(Cấp bộ)";
                dt.Rows.Add(dr);
            }
            #endregion
            #region
            foreach (var captruong in GV_NCKH_CapTruong)
            {
                dr = dt.NewRow();
                dr["TenMon"] = "Nghiên cứu khoa học";
                dr["SoTiet"] = 60;
                dr["TenLop"] = captruong.TenDeTai;
                dr["SiSo"] = 1;
                dr["hs"] = 1;
                dr["sogioday"] = 60;
                dr["GhiChu"] = captruong.NamThamGiaNC + "(Cấp trường)";
                dt.Rows.Add(dr);
            }
            #endregion
            #region
            foreach (var ncgc in HDNCKH_NamGanCuoi)
            {
                SOGIODAY = 20 * int.Parse(ncgc.SoLuong.ToString());
                dr = dt.NewRow();
                dr["TenMon"] = "Hướng dẫn nghiên cứu đề tài khoa học";
                dr["SoTiet"] = SOGIODAY;
                dr["TenLop"] = ncgc.GhiChu;
                dr["SiSo"] = ncgc.SoLuong;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = ncgc.NamHoc;
                dt.Rows.Add(dr);
            }
            #endregion
            #region
            foreach (var nc in HDNCKH_NamCuoi)
            {
                SOGIODAY = 10 * int.Parse(nc.SoLuong.ToString());
                dr = dt.NewRow();
                dr["TenMon"] = "Hướng dẫn nghiên cứu đề tài khoa học";
                dr["SoTiet"] = SOGIODAY;
                dr["TenLop"] = nc.GhiChu;
                dr["SiSo"] = nc.SoLuong;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = nc.NamHoc;
                dt.Rows.Add(dr);
            }
            #endregion
            //duyệt các bản ghi hướng dẫn thực tập sư phạm
            foreach (var item3 in TTSP)
            {
                #region

                //SOGIODAY = ((double.Parse(item3.SoTiet.ToString()) / 15)*5*3/30)*int.Parse(item3.SoSV.ToString());
                SOGIODAY = 1 * int.Parse(item3.SoSV.ToString()) * int.Parse(item3.SoTiet.ToString());
                dr = dt.NewRow();
                dr["TenMon"] = item3.TenMon;
                dr["SoTiet"] = item3.SoTiet;
                dr["TenLop"] = item3.TenLop;
                dr["SiSo"] = item3.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item3.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }

            //duyệt các bản ghi hướng dẫn project 
            foreach (var item2 in project)
            {
                #region

                SOGIODAY = int.Parse(item2.SoSV.ToString()) * 2;
                dr = dt.NewRow();
                dr["TenMon"] = item2.TenMon;
                dr["SoTiet"] = item2.SoTiet;
                dr["TenLop"] = item2.TenLop;
                dr["SiSo"] = item2.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item2.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }

            //tinh lớp thuc hành TCCN
            #region
            foreach (var tccn in TCCN)
            {

                if (int.Parse(tccn.SoSV.ToString()) < 20)
                {
                    hs = 0.75;

                }
                else
                {
                    if ((int.Parse(tccn.SoSV.ToString()) >= 20) && (int.Parse(tccn.SoSV.ToString()) <= 24))
                    {
                        hs = 0.85;
                    }
                    else
                    {
                        if ((int.Parse(tccn.SoSV.ToString()) == 25))
                        {
                            hs = 1;
                        }
                        else
                        {
                            if ((int.Parse(tccn.SoSV.ToString()) >= 26) && (int.Parse(tccn.SoSV.ToString()) <= 30))
                            {
                                hs = 1.1;
                            }
                            else
                            {
                                if ((int.Parse(tccn.SoSV.ToString()) >= 31) && (int.Parse(tccn.SoSV.ToString()) <= 35))
                                {
                                    hs = 1.2;
                                }
                                else
                                {
                                    if ((int.Parse(tccn.SoSV.ToString()) >= 36) && (int.Parse(tccn.SoSV.ToString()) <= 40))
                                    {
                                        hs = 1.4;
                                    }
                                }
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(tccn.SoTiet.ToString()) * 0.6 * hs * 0.8 * 1;
                dr = dt.NewRow();
                dr["TenMon"] = tccn.TenMon;
                dr["SoTiet"] = tccn.SoTiet;
                dr["TenLop"] = tccn.TenLop;
                dr["SiSo"] = tccn.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = tccn.TenLoai;
                dt.Rows.Add(dr);
            }
            #endregion

            //Tính lớp thực hành
            #region
            foreach (var item4 in lopth)
            {
                SoGioThucTeDay = (double.Parse(item4.SoTiet.ToString()) / 30) * double.Parse(item4.SoBuoiTren1DVHocTrinh.ToString()) * 3;
                if (int.Parse(item4.SoSV.ToString()) < 20)
                {
                    hs = 0.75;

                }
                else
                {
                    if ((int.Parse(item4.SoSV.ToString()) >= 20) && (int.Parse(item4.SoSV.ToString()) <= 24))
                    {
                        hs = 0.85;
                    }
                    else
                    {
                        if ((int.Parse(item4.SoSV.ToString()) == 25))
                        {
                            hs = 1;
                        }
                        else
                        {
                            if ((int.Parse(item4.SoSV.ToString()) >= 26) && (int.Parse(item4.SoSV.ToString()) <= 30))
                            {
                                hs = 1.1;
                            }
                            else
                            {
                                if ((int.Parse(item4.SoSV.ToString()) >= 31) && (int.Parse(item4.SoSV.ToString()) <= 35))
                                {
                                    hs = 1.2;
                                }
                                else
                                {
                                    if ((int.Parse(item4.SoSV.ToString()) >= 36) && (int.Parse(item4.SoSV.ToString()) <= 40))
                                    {
                                        hs = 1.4;
                                    }
                                }
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(item4.SoTiet.ToString()) * 0.6 * hs * 1 * 1;
                dr = dt.NewRow();
                dr["TenMon"] = item4.TenMon;
                dr["SoTiet"] = item4.SoTiet;
                dr["TenLop"] = item4.TenLop;
                dr["SiSo"] = item4.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item4.TenLoai;
                dt.Rows.Add(dr);
            }
            #endregion


            //duyệt các bản ghi hướng dẫn thực tập xí nghiệp

            foreach (var item6 in TTXN)
            {

                #region
                if (int.Parse(item6.SoSV.ToString()) < 15)
                {
                    hs = 0.5;

                }
                else
                {
                    if ((int.Parse(item6.SoSV.ToString()) >= 15) && (int.Parse(item6.SoSV.ToString()) <= 24))
                    {
                        hs = 0.7;
                    }
                    else
                    {
                        if (int.Parse(item6.SoSV.ToString()) >= 25)
                        {
                            hs = 1;
                        }
                    }
                }
                SOGIODAY = (double.Parse(item6.SoTiet.ToString()) / 15) * 5 * 3 * hs;
                dr = dt.NewRow();
                dr["TenMon"] = item6.TenMon;
                dr["SoTiet"] = item6.SoTiet;
                dr["TenLop"] = item6.TenLop;
                dr["SiSo"] = item6.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item6.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }
            //lấy lớp đào tạo tín chỉ ĐH, Cao đẳng...
            foreach (var tc in loptc)
            {
                #region
                if (int.Parse(tc.SoSV.ToString()) < 60)
                {
                    hs = 1;

                }
                else
                {
                    if ((int.Parse(tc.SoSV.ToString()) >= 61) && (int.Parse(tc.SoSV.ToString()) < 100))
                    {
                        hs = 1.1;
                    }
                    else
                    {
                        if ((int.Parse(tc.SoSV.ToString()) >= 101) && (int.Parse(tc.SoSV.ToString()) <= 150))
                        {
                            hs = 1.2;
                        }
                        else
                        {
                            if (int.Parse(tc.SoSV.ToString()) > 150)
                            {
                                hs = 1.3;
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(tc.SoTiet.ToString()) * hs * 1 * 1 * 1 * 1.1;
                dr = dt.NewRow();
                dr["TenMon"] = tc.TenMon;
                dr["SoTiet"] = tc.SoTiet;
                dr["TenLop"] = tc.TenLop;
                dr["SiSo"] = tc.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = tc.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }

            //duyệt tất cả các bản ghi là lớp niên chế học lý thuyết thuộc đại học, cao đẳng
            foreach (var item1 in lopnc)
            {
                #region
                if (int.Parse(item1.SoSV.ToString()) < 60)
                {
                    hs = 1;

                }
                else
                {
                    if ((int.Parse(item1.SoSV.ToString()) >= 61) && (int.Parse(item1.SoSV.ToString()) < 100))
                    {
                        hs = 1.1;
                    }
                    else
                    {
                        if ((int.Parse(item1.SoSV.ToString()) >= 101) && (int.Parse(item1.SoSV.ToString()) <= 150))
                        {
                            hs = 1.2;
                        }
                        else
                        {
                            if (int.Parse(item1.SoSV.ToString()) > 150)
                            {
                                hs = 1.3;
                            }
                        }
                    }
                }
                SOGIODAY = double.Parse(item1.SoTiet.ToString()) * hs * 1 * 1 * 1;
                dr = dt.NewRow();
                dr["TenMon"] = item1.TenMon;
                dr["SoTiet"] = item1.SoTiet;
                dr["TenLop"] = item1.TenLop;
                dr["SiSo"] = item1.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item1.TenLoai;
                dt.Rows.Add(dr);
                #endregion
            }
            //duyêth tất cả các bản ghi của lớp trung cấp chuyên nghiệp, VLVH
            foreach (var item in lop)
            {
                if (int.Parse(item.SoSV.ToString()) < 60)
                {
                    hs = 1;

                }
                else
                {
                    if ((int.Parse(item.SoSV.ToString()) >= 61) && (int.Parse(item.SoSV.ToString()) < 100))
                    {
                        hs = 1.1;
                    }
                    else
                    {
                        if ((int.Parse(item.SoSV.ToString()) >= 101) && (int.Parse(item.SoSV.ToString()) <= 150))
                        {
                            hs = 1.2;
                        }
                        else
                        {
                            if (int.Parse(item.SoSV.ToString()) > 150)
                            {
                                hs = 1.3;
                            }
                        }
                    }
                }

                SOGIODAY = double.Parse(item.SoTiet.ToString()) * 1 * 1 * hs * 0.8;


                dr = dt.NewRow();
                dr["TenMon"] = item.TenMon;
                dr["SoTiet"] = item.SoTiet;
                dr["TenLop"] = item.TenLop;
                dr["SiSo"] = item.SoSV;
                dr["hs"] = hs;
                dr["sogioday"] = SOGIODAY;
                dr["GhiChu"] = item.TenLoai;
                dt.Rows.Add(dr);
            }
            GrvThongKeTheGiangVien.DataSource = dt;
            GrvThongKeTheGiangVien.DataBind();
            double tong1 = 0;
            double tong2 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tong1 += double.Parse(dt.Rows[i][5].ToString());
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                tong2 += double.Parse(dt1.Rows[i][2].ToString());
            }
            lblTong2.Text = tong2.ToString();
            lblTong1.Text = tong1.ToString();
        }

        protected void btThongKe_Click(object sender, EventArgs e)
        {

            var Dangnhap = Session["Dangnhap"].ToString();
            var MemberID = Session["MemberID"].ToString();
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label8.Visible = true;
            Label10.Visible = true;
            lblGioChuan.Visible = true;
            lblGioVuotQua.Visible = true;
            lbltonggiochuan.Visible = true;
            lblTong2.Visible = true;
            lblTong1.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            lblMucThanhToan.Visible = true;
            lblThanhToan.Visible = true;
            lblThanhTien.Visible = true;
            lblTien.Visible = true;
            var tt = from c in ql.TaiKhoan
                     where (c.TenDangNhap == Dangnhap && c.MaGV.ToString() == MemberID && c.MaGV == c.GiaoVien.MaGV)
                     select new { c.MaGV, c.GiaoVien.TenGV, c.Quyen };
            foreach (var item in tt)
            {

                //txtGiaoVien.Text = item.TenGV;
                if (Session["MemberID"].ToString() == item.MaGV.ToString() && item.Quyen == "Giáo vụ")
                {
                    //Response.Redirect("Login.aspx?url=" + Request.Url.PathAndQuery);
                    xuly();
                    ddlMaGV.Enabled = true;
                }
                else if (Session["MemberID"].ToString() == item.MaGV.ToString() && item.Quyen == "Giáo viên")
                {
                    //LayGV();
                    txtTenGV.Text = item.TenGV;
                    ddlMaGV.SelectedItem.Text = item.TenGV;
                    lblMa.Text = Session["MemberID"].ToString();
                    xuly1(Session["MemberID"].ToString());
                    //
                    Label3.Visible = true;
                    Label4.Visible = true;
                    Label5.Visible = true;
                    Label6.Visible = true;
                    Label8.Visible = true;
                    Label10.Visible = true;
                    lblGioChuan.Visible = true;
                    lblGioVuotQua.Visible = true;
                    lbltonggiochuan.Visible = true;
                    lblTong2.Visible = true;
                    lblTong1.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    lblMucThanhToan.Visible = true;
                    lblThanhToan.Visible = true;
                    lblThanhTien.Visible = true;
                    lblTien.Visible = true;

                }
            }
            int thanhtoan = 0;
            GiaoVien gv = ql.GiaoVien.SingleOrDefault(c => c.MaGV == lblMa.Text);
            //var HNC = ql.ThongTinHocNangCao(lblMa.Text, ddlNamHoc.SelectedItem.Text.ToString());
            //HocNangCao HNC=ql.HocNangCaos.SingleOrDefault()
            HocBSNangCao HNC = ql.HocBSNangCao.SingleOrDefault(c => c.MaGV == lblMa.Text && c.NamHoc == ddlNamHoc.SelectedItem.Text.ToString());
            if (gv != null)
            {
                if (HNC != null)
                {
                    lblGioChuan.Text = "0";
                }
                if (HNC == null)
                {
                    lblGioChuan.Text = (double.Parse(gv.GioChuan.SoGioChuan.ToString()) * 2).ToString();
                }
                if ((gv.TrinhDoHocVan == "Thạc sỹ") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) > 5)
                {
                    thanhtoan = 25000;
                }
                else
                {
                    if ((gv.TrinhDoHocVan == "Thạc sỹ") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) == 5)
                    {
                        thanhtoan = 20000;
                    }
                    else
                    {
                        if ((gv.TrinhDoHocVan == "Đại học") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) > 20)
                        {
                            thanhtoan = 22000;
                        }
                        else
                        {
                            if ((gv.TrinhDoHocVan == "Đại học") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) > 10 && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) < 20)
                            {
                                thanhtoan = 20000;
                            }
                            else
                            {
                                if (((gv.TrinhDoHocVan != "Thạc sỹ") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) != 5)
                               || ((gv.TrinhDoHocVan != "Đại học") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) != 20)
                                || ((int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv.NamVaoLam.ToString())) != 10)
                               )
                                {
                                    thanhtoan = 18000;
                                }
                            }
                        }

                    }
                }
                if (gv.MaChucDanh == "CD5")
                {
                    thanhtoan = 15000;
                }
                lblThanhToan.Text = thanhtoan.ToString();
            }
            lbltonggiochuan.Text = (double.Parse(lblTong1.Text) + double.Parse(lblTong2.Text)).ToString();
            lblGioVuotQua.Text = (double.Parse(lbltonggiochuan.Text) - double.Parse(lblGioChuan.Text)).ToString();
            lblTien.Text = (double.Parse(lblGioVuotQua.Text) * double.Parse(lblThanhToan.Text)).ToString();
        }


        protected void ddlMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMa.Text = ddlMaGV.SelectedValue.ToString();
        }
        protected void GrvThongKeTheGiangVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvThongKeTheGiangVien.PageIndex = e.NewPageIndex;
            //LoadGiangVien(Session["MemberID"].ToString());
            LoadGiangVien();
        }
        protected void btnThoat_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThongTinCaNhan.aspx");
            //Response.Redirect("Default.aspx");
        }


        protected void btnXuatExcel_Click(object sender, EventArgs e)
        {
            {
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application Appex = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workBook = Appex.Workbooks.Add(misValue);
                Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(1);
                //tạo ra cac cell de truy xuat den  cell Cells[1,2] trong do 1 là hang,2 là cot
                Microsoft.Office.Interop.Excel.Range cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[1, 1];
                cell.Value2 = "TRƯỜNG  ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN";
                cell.Font.Italic = true;
                cell.Font.Size = 11;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[2, 1];
                cell.Value2 = "Khoa công nghệ thông tin";
                cell.Font.Italic = true;
                cell.Font.Size = 11;
                cell.Font.Underline = true;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[1, 5];
                cell.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
                cell.Font.Italic = true;
                cell.Font.Size = 11;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.15;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[2, 5];
                cell.Value2 = "Độc lập - Tự Do - Hạnh Phúc";
                cell.Font.Underline = true;
                cell.Font.Italic = true;
                cell.Font.Size = 11;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[3, 2];
                cell.Value2 = "BẢNG KÊ KHAI";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Font.Italic = true;
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                //cell.ColumnWidth = 7;
                cell.RowHeight = 20.25;
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[3, 3];
                cell.Value2 = "GIỜ GIẢNG NĂM HỌC " + ddlNamHoc.SelectedItem.Text;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Font.Italic = true;
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                //cell.ColumnWidth = 7;
                cell.RowHeight = 20.25;

                GiaoVien gv = ql.GiaoVien.SingleOrDefault(c => c.MaGV == lblMa.Text && c.MaChucDanh == c.GioChuan.MaChucDanh && c.MaBoMon == c.BoMon.MaBoMon);
                if (gv != null)
                {
                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[5, 1];
                    cell.Value2 = "Họ và tên:\t" + gv.TenGV.ToString();
                    cell.Font.Bold = true;
                    cell.Font.Size = 11;
                    cell.Font.Name = "Times New Roman";
                    cell.RowHeight = 20;
                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[6, 1];
                    cell.Value2 = "Bộ môn:\t" + gv.BoMon.TenBoMon.ToString();
                    cell.Font.Bold = true;
                    cell.Font.Size = 11;
                    cell.Font.Name = "Times New Roman";
                    cell.RowHeight = 20;
                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[7, 1];
                    cell.Value2 = "Chức danh:\t" + gv.GioChuan.TenChucDanh.ToString();
                    cell.Font.Bold = true;
                    cell.Font.Size = 11;
                    cell.Font.Name = "Times New Roman";
                    cell.RowHeight = 20;
                }
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[9, 1];
                cell.Value2 = "I.GIỜ GIẢNG DẠY";
                cell.Font.Bold = true;
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;
                //lay tu csdl
                #region lấy theo giờ giảng dạy
                #region
                double hs = 1;
                double SOGIODAY = 0;
                var lop = ql.st_LayLopDTNienChe(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                var lp=from l in ql.GiangDay
                      where (l.GiaoVien.MaGV == lblMa.Text &&  l.NamHoc == ddlNamHoc.SelectedItem.Text)
                      select new {l.Lop };
                //lay ve thong tin lop học theo niên chế và học lý thuyết có mã môn học LM101 các lớp đại học, cao đẳng
                var lopnc = ql.st_LayLopDTNienCheDHCD(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //lay ve thong tin lop học theo tín chỉ và học lý thuyết có mã môn học LM101 các lớp đại học, cao đẳng
                var loptc = ql.st_LayLopDTTinChiDHCD(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //lay thuc hanh voi ma loai mon LM02
                var lopth = ql.st_LayLopThucHanhGV(lblMa.Text, ddlNamHoc.SelectedItem.Text);

                //thực hành của lớp đào tạo theo TCCN
                var TCCN = ql.st_LayLopTHTCCN(lblMa.Text, ddlNamHoc.SelectedItem.Text);

                //lay ve thong tin lop làm project có mã môn học LM03
                var project = ql.Project(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //lay ve thong tin lop thực tập sư phạm có mã môn học LM04
                var TTSP = ql.st_SuPham(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //lay ve thong tin lop thực xí nghiệp có mã môn học LM05
                var TTXN = ql.st_TTxiNghiep(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //Lấy về thông tin Hướng dẫn nghiên cứu khoa học nam cuối
                var HDNCKH_NamCuoi = ql.st_HDNCKH_NamCuoi(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //Lấy về thông tin Hướng dẫn nghiên cứu khoa học của sinh viên 1, 2,3
                var HDNCKH_NamGanCuoi = ql.st_HDNCKH_NamGanCuoi(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //Lấy về thông tin Giáo viên nghiên cứu khoa học cấp trường
                var GV_NCKH_CapTruong = ql.GiaoVien_NCKH_CapTruong(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //Lấy về thông tin Giáo viên nghiên cứu khoa học cấp bộ
                var GV_NCKH_CapBo = ql.GiaoVien_NCKH_CapBo(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                //lấy thông tin đồ án
                var DoAn = ql.LoadDoAnTotNghiep(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                DataTable dt = new DataTable();
                dt = new DataTable();
                dt.Columns.Add("TenMon");
                dt.Columns.Add("SoTiet");
                dt.Columns.Add("TenLop");
                dt.Columns.Add("SiSo");
                dt.Columns.Add("hs");
                dt.Columns.Add("SOGIODAY");
                dt.Columns.Add("GhiChu");
                DataRow dr;
                #endregion
                #region Tính giờ ra đề và hướng dẫn đồ án
                foreach (var da in DoAn)
                {
                    //hướng dẫn đồ án
                    if (da.SoDeTai.ToString() != "0")
                    {
                        SOGIODAY = double.Parse(da.SoDeTai.ToString()) * 12;
                        dr = dt.NewRow();
                        dr["TenMon"] = "Ra đề hướng dẫn đồ án";
                        dr["SoTiet"] = SOGIODAY;
                        dr["TenLop"] = da.TenLop;
                        dr["SiSo"] = da.SoDeTai;
                        dr["hs"] = hs;
                        dr["sogioday"] = SOGIODAY;
                        dr["GhiChu"] = da.SoDeTai + "\tĐồ án";
                        dt.Rows.Add(dr);
                    }
                    //Tính giờ chấm đồ án
                    if (da.SoBuoiChamBai.ToString() != "0")
                    {
                        SOGIODAY = double.Parse(da.SoBuoiChamBai.ToString()) * 2;
                        dr = dt.NewRow();
                        dr["TenMon"] = "Chấm đồ án";
                        dr["SoTiet"] = SOGIODAY;
                        dr["TenLop"] = da.TenLop;
                        dr["SiSo"] = da.SoBuoiChamBai;
                        dr["hs"] = hs;
                        dr["sogioday"] = SOGIODAY;
                        dr["GhiChu"] = da.SoBuoiChamBai + "\tSố buổi chấm";
                        dt.Rows.Add(dr);
                    }
                    //Tính giờ phản biện đồ án
                    if (da.SoDoAnPBien.ToString() != "0")
                    {
                        SOGIODAY = double.Parse(da.SoDoAnPBien.ToString()) * 2;
                        dr = dt.NewRow();
                        dr["TenMon"] = "Phản biện đồ án tốt nghiệp";
                        dr["SoTiet"] = SOGIODAY;
                        dr["TenLop"] = da.TenLop;
                        dr["SiSo"] = da.SoDoAnPBien;
                        dr["hs"] = hs;
                        dr["sogioday"] = SOGIODAY;
                        dr["GhiChu"] = da.SoBuoiChamBai + "\tĐồ án";
                        dt.Rows.Add(dr);
                    }
                }
                #endregion
                #region
                foreach (var capbo in GV_NCKH_CapBo)
                {
                    dr = dt.NewRow();
                    dr["TenMon"] = "Nghiên cứu khoa học";
                    dr["SoTiet"] = 120;
                    dr["TenLop"] = capbo.TenDeTai;
                    dr["SiSo"] = 1;
                    dr["hs"] = 1;
                    dr["sogioday"] = 120;
                    dr["GhiChu"] = capbo.NamThamGiaNC + "(Cấp bộ)";
                    dt.Rows.Add(dr);
                }
                #endregion
                #region
                foreach (var captruong in GV_NCKH_CapTruong)
                {
                    dr = dt.NewRow();
                    dr["TenMon"] = "Nghiên cứu khoa học";
                    dr["SoTiet"] = 60;
                    dr["TenLop"] = captruong.TenDeTai;
                    dr["SiSo"] = 1;
                    dr["hs"] = 1;
                    dr["sogioday"] = 60;
                    dr["GhiChu"] = captruong.NamThamGiaNC + "(Cấp trường)";
                    dt.Rows.Add(dr);
                }
                #endregion
                #region
                foreach (var ncgc in HDNCKH_NamGanCuoi)
                {
                    SOGIODAY = 20 * int.Parse(ncgc.SoLuong.ToString());
                    dr = dt.NewRow();
                    dr["TenMon"] = "Hướng dẫn nghiên cứu đề tài khoa học";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = ncgc.GhiChu;
                    dr["SiSo"] = ncgc.SoLuong;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = ncgc.NamHoc;
                    dt.Rows.Add(dr);
                }
                #endregion
                #region
                foreach (var nc in HDNCKH_NamCuoi)
                {
                    SOGIODAY = 10 * int.Parse(nc.SoLuong.ToString());
                    dr = dt.NewRow();
                    dr["TenMon"] = "Hướng dẫn nghiên cứu đề tài khoa học";
                    dr["SoTiet"] = SOGIODAY;
                    dr["TenLop"] = nc.GhiChu;
                    dr["SiSo"] = nc.SoLuong;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = nc.NamHoc;
                    dt.Rows.Add(dr);
                }
                #endregion
                //duyệt các bản ghi hướng dẫn thực tập sư phạm
                #region
                foreach (var item3 in TTSP)
                {


                    //SOGIODAY = ((double.Parse(item3.SoTiet.ToString()) / 15)*5*3/30)*int.Parse(item3.SoSV.ToString());
                    SOGIODAY = 1 * int.Parse(item3.SoSV.ToString()) * int.Parse(item3.SoTiet.ToString());
                    dr = dt.NewRow();
                    dr["TenMon"] = item3.TenMon;
                    dr["SoTiet"] = item3.SoTiet;
                    dr["TenLop"] = item3.TenLop;
                    dr["SiSo"] = item3.SoSV;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = item3.TenLoai;
                    dt.Rows.Add(dr);

                }
                #endregion
                //duyệt các bản ghi hướng dẫn project 
                #region
                foreach (var item2 in project)
                {


                    SOGIODAY = int.Parse(item2.SoSV.ToString()) * 2;
                    dr = dt.NewRow();
                    dr["TenMon"] = item2.TenMon;
                    dr["SoTiet"] = item2.SoTiet;
                    dr["TenLop"] = item2.TenLop;
                    dr["SiSo"] = item2.SoSV;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = item2.TenLoai;
                    dt.Rows.Add(dr);

                }
                #endregion


                //tinh lớp thuc hành TCCN
                #region
                foreach (var tccn in TCCN)
                {

                    if (int.Parse(tccn.SoSV.ToString()) < 20)
                    {
                        hs = 0.75;

                    }
                    else
                    {
                        if ((int.Parse(tccn.SoSV.ToString()) >= 20) && (int.Parse(tccn.SoSV.ToString()) <= 24))
                        {
                            hs = 0.85;
                        }
                        else
                        {
                            if ((int.Parse(tccn.SoSV.ToString()) == 25))
                            {
                                hs = 1;
                            }
                            else
                            {
                                if ((int.Parse(tccn.SoSV.ToString()) >= 26) && (int.Parse(tccn.SoSV.ToString()) <= 30))
                                {
                                    hs = 1.1;
                                }
                                else
                                {
                                    if ((int.Parse(tccn.SoSV.ToString()) >= 31) && (int.Parse(tccn.SoSV.ToString()) <= 35))
                                    {
                                        hs = 1.2;
                                    }
                                    else
                                    {
                                        if ((int.Parse(tccn.SoSV.ToString()) >= 36) && (int.Parse(tccn.SoSV.ToString()) <= 40))
                                        {
                                            hs = 1.4;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    SOGIODAY = double.Parse(tccn.SoTiet.ToString()) * 0.6 * hs * 0.8 * 1;
                    dr = dt.NewRow();
                    dr["TenMon"] = tccn.TenMon;
                    dr["SoTiet"] = tccn.SoTiet;
                    dr["TenLop"] = tccn.TenLop;
                    dr["SiSo"] = tccn.SoSV;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = tccn.TenLoai;
                    dt.Rows.Add(dr);
                }
                #endregion

                //Tính lớp thực hành
                #region
                foreach (var item4 in lopth)
                {
                    //SoGioThucTeDay = (double.Parse(item4.SoTiet.ToString()) / 30) * double.Parse(item4.SoBuoiTren1DVHocTrinh.ToString()) * 3;
                    if (int.Parse(item4.SoSV.ToString()) < 20)
                    {
                        hs = 0.75;
                    }
                    else
                    {
                        if ((int.Parse(item4.SoSV.ToString()) >= 20) && (int.Parse(item4.SoSV.ToString()) <= 24))
                        {
                            hs = 0.85;
                        }
                        else
                        {
                            if ((int.Parse(item4.SoSV.ToString()) == 25))
                            {
                                hs = 1;
                            }
                            else
                            {
                                if ((int.Parse(item4.SoSV.ToString()) >= 26) && (int.Parse(item4.SoSV.ToString()) <= 30))
                                {
                                    hs = 1.1;
                                }
                                else
                                {
                                    if ((int.Parse(item4.SoSV.ToString()) >= 31) && (int.Parse(item4.SoSV.ToString()) <= 35))
                                    {
                                        hs = 1.2;
                                    }
                                    else
                                    {
                                        if ((int.Parse(item4.SoSV.ToString()) >= 36) && (int.Parse(item4.SoSV.ToString()) <= 40))
                                        {
                                            hs = 1.4;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //SOGIODAY = SoGioThucTeDay * 0.6 * hs;
                    SOGIODAY = double.Parse(item4.SoTiet.ToString()) * hs * 0.6;
                    dr = dt.NewRow();
                    dr["TenMon"] = item4.TenMon;
                    dr["SoTiet"] = item4.SoTiet;
                    dr["TenLop"] = item4.TenLop;
                    dr["SiSo"] = item4.SiSo;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = item4.TenLoai;
                    dt.Rows.Add(dr);
                }
                #endregion


                //duyệt các bản ghi hướng dẫn thực tập xí nghiệp

                #region
                foreach (var item6 in TTXN)
                {

                    if (int.Parse(item6.SoSV.ToString()) < 15)
                    {
                        hs = 0.5;

                    }
                    else
                    {
                        if ((int.Parse(item6.SoSV.ToString()) >= 15) && (int.Parse(item6.SoSV.ToString()) <= 24))
                        {
                            hs = 0.7;
                        }
                        else
                        {
                            if (int.Parse(item6.SoSV.ToString()) >= 25)
                            {
                                hs = 1;
                            }
                        }
                    }
                    SOGIODAY = (double.Parse(item6.SoTiet.ToString()) / 15) * 5 * 3 * hs;
                    dr = dt.NewRow();
                    dr["TenMon"] = item6.TenMon;
                    dr["SoTiet"] = item6.SoTiet;
                    dr["TenLop"] = item6.TenLop;
                    dr["SiSo"] = item6.SoSV;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = item6.TenLoai;
                    dt.Rows.Add(dr);

                }
                #endregion
                //duyệt tất cả các bản ghi là lớp tín chỉ học đại học,cao đẳng,...
                #region
                foreach (var tc in loptc)
                {

                    if (int.Parse(tc.SoSV.ToString()) < 60)
                    {
                        hs = 1;

                    }
                    else
                    {
                        if ((int.Parse(tc.SoSV.ToString()) >= 61) && (int.Parse(tc.SoSV.ToString()) < 100))
                        {
                            hs = 1.1;
                        }
                        else
                        {
                            if ((int.Parse(tc.SoSV.ToString()) >= 101) && (int.Parse(tc.SoSV.ToString()) <= 150))
                            {
                                hs = 1.2;
                            }
                            else
                            {
                                if (int.Parse(tc.SoSV.ToString()) > 150)
                                {
                                    hs = 1.3;
                                }
                            }
                        }
                    }
                    SOGIODAY = double.Parse(tc.SoTiet.ToString()) * hs * 1 * 1 * 1 * 1.1;
                    dr = dt.NewRow();
                    dr["TenMon"] = tc.TenMon;
                    dr["SoTiet"] = tc.SoTiet;
                    dr["TenLop"] = tc.TenLop;
                    dr["SiSo"] = tc.SoSV;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = tc.TenLoai;
                    dt.Rows.Add(dr);

                }
                #endregion

                //duyệt tất cả các bản ghi là lớp niên chế học đại học,cao đẳng,...
                #region
                foreach (var item1 in lopnc)
                {

                    if (int.Parse(item1.SoSV.ToString()) < 60)
                    {
                        hs = 1;

                    }
                    else
                    {
                        if ((int.Parse(item1.SoSV.ToString()) >= 61) && (int.Parse(item1.SoSV.ToString()) < 100))
                        {
                            hs = 1.1;
                        }
                        else
                        {
                            if ((int.Parse(item1.SoSV.ToString()) >= 101) && (int.Parse(item1.SoSV.ToString()) <= 150))
                            {
                                hs = 1.2;
                            }
                            else
                            {
                                if (int.Parse(item1.SoSV.ToString()) > 150)
                                {
                                    hs = 1.3;
                                }
                            }
                        }
                    }
                    SOGIODAY = double.Parse(item1.SoTiet.ToString()) * hs * 1 * 1 * 1;
                    dr = dt.NewRow();
                    dr["TenMon"] = item1.TenMon;
                    dr["SoTiet"] = item1.SoTiet;
                    dr["TenLop"] = item1.TenLop;
                    dr["SiSo"] = item1.SoSV;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = item1.TenLoai;
                    dt.Rows.Add(dr);

                }
                #endregion
                //tính dạy các lớp trung cấp, vừa làm vừa học
                #region
                foreach (var item in lop)
                {
                    if (int.Parse(item.SoSV.ToString()) < 60)
                    {
                        hs = 1;

                    }
                    else
                    {
                        if ((int.Parse(item.SoSV.ToString()) >= 61) && (int.Parse(item.SoSV.ToString()) < 100))
                        {
                            hs = 1.1;
                        }
                        else
                        {
                            if ((int.Parse(item.SoSV.ToString()) >= 101) && (int.Parse(item.SoSV.ToString()) <= 150))
                            {
                                hs = 1.2;
                            }
                            else
                            {
                                if (int.Parse(item.SoSV.ToString()) > 150)
                                {
                                    hs = 1.3;
                                }
                            }
                        }
                    }

                    SOGIODAY = double.Parse(item.SoTiet.ToString()) * 1 * 1 * hs * 0.8;


                    dr = dt.NewRow();
                    dr["TenMon"] = item.TenMon;
                    dr["SoTiet"] = item.SoTiet;
                    dr["TenLop"] = item.TenLop;
                    dr["SiSo"] = item.SoSV;
                    dr["hs"] = hs;
                    dr["sogioday"] = SOGIODAY;
                    dr["GhiChu"] = item.TenLoai;
                    dt.Rows.Add(dr);
                }
                #endregion
                #endregion
                //khai báo từng cột trong excel
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[10, 1];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Học phần";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[10, 2];
                cell.EntireColumn.AutoFit();
                cell.ColumnWidth = 2.88;
                cell.RowHeight = 20.25;
                cell.Value2 = "Số tiết";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;


                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[10, 3];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Tên lớp";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;
                cell.ColumnWidth = 2.88;
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[10, 4];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Sỹ số";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[10, 5];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Hệ số";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;
                cell.ColumnWidth = 2.88;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[10, 6];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Số giờ được tính";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[10, 7];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Ghi chú";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;
                cell.ColumnWidth = 6;
                cell.RowHeight = 20.25;
                //Duyệt qua các rows của bảng
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + 11, 1];
                    //can text cua cell sang ben trai
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt.Rows[i][0].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;


                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + 11, 2];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt.Rows[i][1].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.ColumnWidth = 3;
                    cell.RowHeight = 20.25;

                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + 11, 3];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt.Rows[i][2].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.ColumnWidth = 3;
                    cell.RowHeight = 20.25;
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + 11, 4];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt.Rows[i][3].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + 11, 5];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt.Rows[i][4].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.ColumnWidth = 2.88;
                    cell.RowHeight = 20.25;
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + 11, 6];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt.Rows[i][5].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + 11, 7];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt.Rows[i][6].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                }
                double tong1 = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tong1 += double.Parse(dt.Rows[i][5].ToString());
                }
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[dt.Rows.Count + 11, 1];
                cell.Value2 = "Tổng cộng 1:";
                cell.Font.Bold = true;
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[dt.Rows.Count + 11, 6];
                cell.Value2 = tong1.ToString();
                cell.Font.Bold = true;
                cell.Font.Size = 11;
                //Giờ quy đổi từ các hoạt động khác
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[dt.Rows.Count + 13, 1];
                cell.Value2 = "II. GIỜ QUY ĐỔI TỪ CÁC HOẠT ĐỘNG KHÁC";
                cell.Font.Bold = true;
                cell.Font.Size = 11;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[dt.Rows.Count + 14, 1];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Nội dung công việc";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[dt.Rows.Count + 14, 2];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Số giờ được tính";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[dt.Rows.Count + 14, 3];
                cell.EntireColumn.AutoFit();
                cell.Value2 = "Ghi chú";
                cell.Font.Bold = true;
                cell.Font.Name = "Times New Roman";
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                cell.Borders.LineStyle = BorderStyle.None;
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("TenMon");
                dt1.Columns.Add("GhiChu");
                dt1.Columns.Add("SOGIODAY");
                DataRow dr1;
                //Load quan ly phong may
                var Qlpm = ql.st_LoadQuanLyPhongMay(lblMa.Text, ddlNamHoc.SelectedItem.Text);
                foreach (var qlpm in Qlpm)
                {
                    SOGIODAY = double.Parse(qlpm.SoLuongPM.ToString()) * 40;
                    dr1 = dt1.NewRow();
                    dr1["TenMon"] = "Quản lý và bảo trì phòng máy";
                    dr1["SOGIODAY"] = SOGIODAY;
                    dr1["GhiChu"] = qlpm.GhiChu;
                    dt1.Rows.Add(dr1);
                }
                //var lấy số % giờ chuẩn ựược giảm cho giảng viên có chức vụ tương ứng
                var CV = ql.st_LoadGiangVienChucVu(lblMa.Text);
                foreach (var cv in CV)
                {
                    SOGIODAY = (double.Parse(cv.PhanTramDuocGiam.ToString()) * double.Parse(cv.SoGioChuan.ToString())) * 2 / 100;
                    dr1 = dt1.NewRow();
                    dr1["TenMon"] = cv.TenChucVu;
                    dr1["SOGIODAY"] = SOGIODAY;
                    dr1["GhiChu"] = cv.PhanTramDuocGiam + "\t% giờ chuẩn";
                    dt1.Rows.Add(dr1);
                }

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + dt.Rows.Count + 15, 1];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt1.Rows[i][0].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + dt.Rows.Count + 15, 3];
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt1.Rows[i][1].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                    cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[i + dt.Rows.Count + 15, 2];
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    cell.EntireColumn.AutoFit();
                    cell.Value2 = dt1.Rows[i][2].ToString();
                    cell.Borders.LineStyle = BorderStyle.None;
                    cell.Font.Name = "Time New Roman";
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                }
                double tong2 = 0;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    tong2 += double.Parse(dt1.Rows[i][2].ToString());
                }
                int hang = dt.Rows.Count + dt1.Rows.Count + 15;
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang, 1];
                cell.Value2 = "Tổng cộng 2:";
                cell.Font.Bold = true;
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang, 2];
                cell.Value2 = tong2.ToString();
                cell.Font.Bold = true;
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 2, 1];
                cell.Value2 = "III. THANH TOÁN GIỜ GIẢNG DẠY";
                cell.Font.Bold = true;
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 3, 1];
                cell.Value2 = "Tổng số giờ chuẩn thực hiện trong học kỳ:  ";
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 3, 2];
                cell.EntireColumn.AutoFit();
                cell.Value2 = tong1 + tong2;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                int thanhtoan = 0;
                GiaoVien gv1 = ql.GiaoVien.SingleOrDefault(c => c.MaGV == ddlMaGV.SelectedItem.Value.ToString() || c.MaGV == lblMa.Text);
                if (gv1 != null)
                {
                    if ((gv1.TrinhDoHocVan == "Thạc sỹ") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) > 5)
                    {
                        thanhtoan = 25000;
                    }
                    else
                    {
                        if ((gv1.TrinhDoHocVan == "Thạc sỹ") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) == 5)
                        {
                            thanhtoan = 20000;
                        }
                        else
                        {
                            if ((gv1.TrinhDoHocVan == "Đại học") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) > 20)
                            {
                                thanhtoan = 22000;
                            }
                            else
                            {
                                if ((gv1.TrinhDoHocVan == "Đại học") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) > 10 && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) < 20)
                                {
                                    thanhtoan = 20000;
                                }
                                else
                                {
                                    if (((gv1.TrinhDoHocVan != "Thạc sỹ") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) != 5)
                                   || ((gv1.TrinhDoHocVan != "Đại học") && (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) != 20)
                                    || ((int.Parse(DateTime.Now.Year.ToString()) - int.Parse(gv1.NamVaoLam.ToString())) != 10)
                                   )
                                    {
                                        thanhtoan = 18000;
                                    }
                                }
                            }
                        }
                    }
                    if (gv1.MaChucDanh == "CD5")
                    {
                        thanhtoan = 15000;
                    }
                    //var HNC = ql.ThongTinHocNangCao(lblMa.Text, ddlNamHoc.SelectedItem.Text.ToString());
                    HocBSNangCao HNC = ql.HocBSNangCao.SingleOrDefault(c => c.MaGV == lblMa.Text && c.NamHoc == ddlNamHoc.SelectedItem.Text.ToString());
                    if (HNC == null)
                    {
                        cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 4, 1];
                        cell.Value2 = "Số giờ tiêu chuẩn:  ";
                        cell.Font.Size = 11;
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        cell.Font.Name = "Times New Roman";
                        cell.RowHeight = 20.25;
                        cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 4, 2];
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        cell.EntireColumn.AutoFit();
                        cell.Value2 = (int.Parse(gv1.GioChuan.SoGioChuan.ToString()) * 2).ToString();
                        cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 5, 1];
                        cell.Value2 = "Số giờ vượt tiêu chuẩn:  ";
                        cell.Font.Size = 11;
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        cell.Font.Name = "Times New Roman";
                        cell.RowHeight = 20.25;

                        cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 5, 2];
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        cell.EntireColumn.AutoFit();
                        cell.Value2 = (tong1 + tong2) - (int.Parse(gv1.GioChuan.SoGioChuan.ToString()) * 2);

                        cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 6, 1];
                        cell.Value2 = "Mức thanh toán:  ";
                        cell.Font.Size = 11;
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        cell.Font.Name = "Times New Roman";
                        cell.RowHeight = 20.25;

                        cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 6, 2];
                        cell.EntireColumn.AutoFit();
                        cell.Value2 = thanhtoan.ToString() + " VND/1h";
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        cell.Font.Name = "Times New Roman";
                        cell.RowHeight = 20.25;

                        cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 6, 3];
                        cell.Value2 = "Thành tiền:  " + ((tong1 + tong2) - (int.Parse(gv1.GioChuan.SoGioChuan.ToString()) * 2)) * thanhtoan; ;
                        cell.Font.Size = 11;
                        cell.Font.Name = "Times New Roman";
                        cell.RowHeight = 20.25;

                    }
                    else
                    {
                        if (HNC != null)
                        {
                            cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 4, 1];
                            cell.Value2 = "Số giờ tiêu chuẩn:  ";
                            cell.Font.Size = 11;
                            cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            cell.Font.Name = "Times New Roman";
                            cell.RowHeight = 20.25;

                            cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 4, 2];
                            cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            cell.EntireColumn.AutoFit();
                            cell.Value2 = "0";

                            cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 5, 1];
                            cell.Value2 = "Số giờ vượt tiêu chuẩn:  ";
                            cell.Font.Size = 11;
                            cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            cell.Font.Name = "Times New Roman";
                            cell.RowHeight = 20.25;

                            cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 5, 2];
                            cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            cell.EntireColumn.AutoFit();
                            cell.Value2 = (tong1 + tong2);

                            cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 6, 1];
                            cell.Value2 = "Mức thanh toán:  ";
                            cell.Font.Size = 11;
                            cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            cell.Font.Name = "Times New Roman";
                            cell.RowHeight = 20.25;

                            cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 6, 2];
                            cell.EntireColumn.AutoFit();
                            cell.Value2 = thanhtoan.ToString() + " VND/1h";
                            cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            cell.Font.Name = "Times New Roman";
                            cell.RowHeight = 20.25;

                            cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 6, 3];
                            cell.Value2 = "Thành tiền:  " + (tong1 + tong2) * thanhtoan; ;
                            cell.Font.Size = 11;
                            cell.Font.Name = "Times New Roman";
                            cell.RowHeight = 20.25;
                        }

                    }

                }
                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 8, 3];
                cell.Value2 = "Hưng Yên, " + "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 10, 1];
                cell.Value2 = "TRƯỞNG KHOA:  ";
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 10, 2];
                cell.Value2 = "TRƯỞNG BỘ MÔN:  ";
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                cell = (Microsoft.Office.Interop.Excel.Range)workSheet.Cells[hang + 10, 4];
                cell.Value2 = "NGƯỜI KÊ KHAI:  ";
                cell.Font.Size = 11;
                cell.Font.Name = "Times New Roman";
                cell.RowHeight = 20.25;

                workBook.SaveAs(Server.MapPath("~/upload/" + ddlMaGV.SelectedItem.Text), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing);
                workBook.Close(false, Type.Missing, Type.Missing);
                Appex.Quit();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('Saved');", true);
            }

        }
    }
}