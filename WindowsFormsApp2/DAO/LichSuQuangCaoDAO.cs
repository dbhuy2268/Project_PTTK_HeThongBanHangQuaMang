﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class LichSuQuangCaoDAO
    {
        private readonly DataProvider dp;

        public LichSuQuangCaoDAO()
        {
            this.dp = new DataProvider();
        }

        public void ThemLichSu(int MaLS, int MaKH, int MaMH)
        {
            string query = "INSERT INTO dbo.LICHSUQUANGCAO(MAKH, MAHANG) VALUES (@makh, @mamh)";
            List<SqlParameter> values = new List<SqlParameter>
            {
                new SqlParameter("@makh", MaKH),
                new SqlParameter("@mamh", MaMH)
            };

            dp.ExecuteNonQuery(query, values);
        }

        public int LayMaLichSu()
        {
            String query = "SELECT * FROM dbo.LICHSUQUANGCAO";
            DataTable dt = this.dp.ExecuteQuery(query);

            List<LichSuQuangCaoDTO> lsS = new List<LichSuQuangCaoDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                LichSuQuangCaoDTO ls = new LichSuQuangCaoDTO((int)dr["MALSQC"], (int)dr["MAKH"], (int)dr["MAHANG"]);

                lsS.Add(ls);
            }

            return Int32.Parse(lsS[lsS.Count - 1].maLSQC.ToString());
        }
    }
}
