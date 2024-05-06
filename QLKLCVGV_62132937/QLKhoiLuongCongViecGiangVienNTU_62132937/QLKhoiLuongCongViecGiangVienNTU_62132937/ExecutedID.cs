using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace QLKhoiLuongCongViecGiangVienNTU_62132937
{
    public class ExecutedID
    {
        QUANLYGIANGVIENEntities2 tmd = new QUANLYGIANGVIENEntities2();

        //Lấy số có trong từng mã
        private int LaySoTrongMa(ref string MaChu)
        {
            int maso = 1;
            //Ma ky hieu:NV,MH...
            string ma = "";
            StringBuilder x = new StringBuilder(MaChu.Trim());
            for (int i = 0; i < x.Length; i++)
            {
                if ((x[i] == '0') || (x[i] == '1') || (x[i] == '2') || (x[i] == '3') || (x[i] == '4') || (x[i] == '5') || (x[i] == '6') || (x[i] == '7') || (x[i] == '8') || (x[i] == '9'))
                {
                    string tg = MaChu.Substring(i);
                    maso = int.Parse(tg);
                    break;
                }
                ma = ma + x[i].ToString();
            }
            MaChu = ma + (maso + 1).ToString();
            return maso;
        }
        //Lấy mã lớn nhất trong mã
        public void LayMa(ref string ma, List<string> ds)
        {
            //Khai bao 1 bien max de lay ra so lon nhat trong day
            int max = 0;
            foreach (string xc in ds)
            {
                string tg = xc;
                if (max < LaySoTrongMa(ref tg))
                {
                    ma = tg;
                    //Do hàm lấy mã chạy 2 lần ,nên giá trị mã tăng lên 1 ta phải trừ đi 1
                    max = LaySoTrongMa(ref tg) - 1;
                }
            }
        }
        #region Lấy mã tự động cho bảng GiaoVien-Giang vien
        public string LayMaGiangVien()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.GiaoVien
                     select c;
            foreach (GiaoVien ds1 in ds)
            {
                dsma.Add(ds1.MaGV.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho Giang vien
                ma = "GV01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng BoMon-Bộ Môn
        public string LayMaBoMon()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.BoMon
                     select c;
            foreach (BoMon ds1 in ds)
            {
                dsma.Add(ds1.MaBoMon.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho bộ môn
                ma = "BM1";
            }
            return ma;

        }
        #endregion


        #region Lấy mã tự động cho bảng Hệ số lớp đông
        public string LayMa()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.HeSoLopDong
                     select c;
            foreach (HeSoLopDong ds1 in ds)
            {
                dsma.Add(ds1.MaHSLopDong.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho nhân viên
                ma = "LD01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng Loại môn học
        public string LayMaLoaiMon()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.LoaiMon
                     select c;
            foreach (LoaiMon ds1 in ds)
            {
                dsma.Add(ds1.MaLoai.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho nhân viên
                ma = "LM01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng Môn học
        public string LayMaMonHoc()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.MonHoc
                     select c;
            foreach (MonHoc ds1 in ds)
            {
                dsma.Add(ds1.MaMon.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho nhân viên
                ma = "MH01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng Chức vụ
        public string LayMaChucVu()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.ChucVu
                     select c;
            foreach (ChucVu ds1 in ds)
            {
                dsma.Add(ds1.MaChucVu.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho nhân viên
                ma = "CV01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng Giờ chuẩn
        public string LayMaChucDanh()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.GioChuan
                     select c;
            foreach (GioChuan ds1 in ds)
            {
                dsma.Add(ds1.MaChucDanh.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho nhân viên
                ma = "CD01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng Hệ đào tạo
        public string LayMaHDT()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.HeDaoTao
                     select c;
            foreach (HeDaoTao ds1 in ds)
            {
                dsma.Add(ds1.MaHDT.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho hệ đào tạo
                ma = "HDT01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng Hướng dẫn nghiên cứu khoa học
        public string LayMaHDNCKH()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.HuongDanNCKH
                     select c;
            foreach (HuongDanNCKH ds1 in ds)
            {
                dsma.Add(ds1.Ma.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho hệ đào tạo
                ma = "Ma01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã đề tài tự động cho bảng Giáo viên nghiên cứu khoa học
        public string LayMaDeTai()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.GiaoVienNCKH
                     select c;
            foreach (GiaoVienNCKH ds1 in ds)
            {
                dsma.Add(ds1.MaDeTai.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho đề tài
                ma = "DT01";
            }
            return ma;

        }
        #endregion
        #region Lấy mã tự động cho bảng Quản lý phòng máy-QLPhongMay
        public string LayMaQuanLy()
        {
            List<string> dsma = new List<string>();
            var ds = from c in tmd.QLPhongMay
                     select c;
            foreach (QLPhongMay ds1 in ds)
            {
                dsma.Add(ds1.MaQL.ToString());
            }
            string ma = "";
            LayMa(ref ma, dsma);
            if (ma == "")
            {
                //Gán mã đầu tiên cho quản lý phòng máy
                ma = "QL01";
            }
            return ma;

        }
        #endregion


    }
  
}