﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantOtomasyonu
{
    class cMusteriler
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _musteriid;
        private string _musteriad;
        private string _musterisoyad;
        private string _telefon;
        private string _Adres;
        private string _email;
        #endregion
        #region Properties
        public int Musteriid { get => _musteriid; set => _musteriid = value; }
        public string Musteriad { get => _musteriad; set => _musteriad = value; }
        public string Musterisoyad { get => _musterisoyad; set => _musterisoyad = value; }
        public string Telefon { get => _telefon; set => _telefon = value; }
        public string Adres { get => _Adres; set => _Adres = value; }
        public string Email { get => _email; set => _email = value; }
        #endregion

        public bool MusteriVarmi(string tlf)
        {

            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "MusteriVarmi";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;

            if (con.State == ConnectionState.Closed)
            
                con.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);
                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;
                
                }
                finally
                {
                    con.Close();
                }
                return sonuc;
            
        }

        public int musteriEkle(cMusteriler m)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Musteriler(AD,SOYAD,TELEFON,ADRES,EMAIL) values (@ad,@soyad,@telefon,@adres,@email); select SCOPE_IDENTITY()", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ad", SqlDbType.NVarChar).Value = m._musteriad;
                cmd.Parameters.Add("@soyad", SqlDbType.NVarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("@telefon", SqlDbType.NVarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.Text).Value = m._Adres;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = m._email;
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }




            return sonuc;
        }

        public bool musteriBilgileriGuncelle(cMusteriler m)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Musteriler set AD=@ad,SOYAD=@soyad,TELEFON=@telefon,ADRES=@adres,EMAIL=@email where ID=@musteriId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ad", SqlDbType.NVarChar).Value = m._musteriad;
                cmd.Parameters.Add("@soyad", SqlDbType.NVarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("@telefon", SqlDbType.NVarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.Text).Value = m._Adres;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = m._email;
                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = m._musteriid;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }




            return sonuc;
        }

        public void musterileriGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from Musteriler",con);

            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(dr["ID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());
                        sayac++;

                    }
                
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        public void musterileriGetirId(int MusteriID,TextBox ad,TextBox soyad,TextBox tlf,TextBox adres,TextBox email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from Musteriler where ID=@MusteriID", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = MusteriID;
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ad.Text = dr["AD"].ToString();
                    soyad.Text = dr["SOYAD"].ToString();
                    tlf.Text = dr["TELEFON"].ToString();
                    adres.Text = dr["ADRES"].ToString();
                    email.Text = dr["EMAIL"].ToString();

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message; 
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void musterigetirAd(ListView lv, string musteriAd)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from Musteriler where AD like @musteriAd + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriAd", SqlDbType.VarChar).Value = musteriAd;
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());

                    sayac++;

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void musterigetirSoyad(ListView lv, string musteriSoyad)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from Musteriler where SOYAD like @musteriSoyad + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriSoyad", SqlDbType.VarChar).Value = musteriSoyad;
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());

                    sayac++;

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void musterigetirTlf(ListView lv, string tlf)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from Musteriler where TELEFON like @tlf + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("tlf", SqlDbType.VarChar).Value = tlf;
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());

                    sayac++;

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

    }
}
