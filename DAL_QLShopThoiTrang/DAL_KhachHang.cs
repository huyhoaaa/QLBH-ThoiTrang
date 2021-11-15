﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_QLShopThoiTrang;

namespace DAL_QLShopThoiTrang
{
    public class DAL_KhachHang: DbConnect
    {
    public DataTable ListKH()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ListKH";
                cmd.Connection = conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    public bool ThemKH(DTO_KhachHang kh)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemKH";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("dienthoai", kh.DienThoai);
                cmd.Parameters.AddWithValue("tenkh", kh.TenKH);
                cmd.Parameters.AddWithValue("diachi", kh.DiaChi);
                cmd.Parameters.AddWithValue("gioitinh", kh.GioiTinh);
                cmd.Parameters.AddWithValue("email", kh.EmailNV);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool SuaKH(DTO_KhachHang kh)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaKH";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("dienthoai", kh.DienThoai);
                cmd.Parameters.AddWithValue("tenkh", kh.TenKH);
                cmd.Parameters.AddWithValue("diachi", kh.DiaChi);
                cmd.Parameters.AddWithValue("gioitinh", kh.GioiTinh);
                if (cmd.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool XoaKH(string dienthoai)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaKH";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("dienthoai", dienthoai);
                if (cmd.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
