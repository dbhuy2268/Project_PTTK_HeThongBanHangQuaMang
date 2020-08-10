﻿using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        private DataProvider db;

        public ChiTietHoaDonDAO()
        {
            db = new DataProvider();
        }

        public List<ChiTietHoaDonDTO> DocChiTietHoaDon(int MaHD)
        {
            string query = "SELECT * FROM CHITIETHOADON WHERE MAHD = @MaHD";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            DataTable dt = db.ExecuteQuery(query, Find_values);
            List<ChiTietHoaDonDTO> ret = new List<ChiTietHoaDonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietHoaDonDTO temp = new ChiTietHoaDonDTO((int)dr["MACHITIETHOADON"], (int)dr["MAHANG"], (int)dr["MAHD"], (int)dr["SOLUONG"]);
                ret.Add(temp);
            }
            return ret;
        }

        public void ThemChiTietHoaDon(ChiTietHoaDonDTO CT)
        {
            string query = "INSERT INTO CHITIETHOADON(MAHOADON, MAHANG, SOLUONG) VALUES (@MaHD, @MaHang, @SoLuong)";
            List<SqlParameter> inserted_values = new List<SqlParameter>();
            inserted_values.Add(new SqlParameter("@MaHD", CT.maHoaDon));
            inserted_values.Add(new SqlParameter("@MaHang", CT.maHang));
            inserted_values.Add(new SqlParameter("@SoLuong", CT.soLuong));

            db.ExecuteNonQuery(query, inserted_values);
        }

        public void XoaChiTietHD(int MaHD)
        {
            string query = "DELETE FROM CHITIETHOADON WHERE MAHOADON = @MaHD";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            db.ExecuteNonQuery(query, Find_values);
        }


    }
}
