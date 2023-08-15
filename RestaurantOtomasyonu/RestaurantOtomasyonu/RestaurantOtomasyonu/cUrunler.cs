using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantOtomasyonu
{
    class cUrunler
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _urunid;
        private int _urunturno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;
        #endregion
        #region Properties
        public int Urunid { get => _urunid; set => _urunid = value; }
        public int Urunturno { get => _urunturno; set => _urunturno = value; }
        public string Urunad { get => _urunad; set => _urunad = value; }
        public decimal Fiyat { get => _fiyat; set => _fiyat = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; } 
        #endregion

        public void urunleriListeleByUrunAdi(ListView lv, string urunadi)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from Urunler where DURUM=0 and URUNAD like '&' + @urunAdi + '&' ", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = urunadi;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add( string.Format("{0:0#00.0}",dr["FIYAT"].ToString()));
                    sayac++;

                }

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
        }
        public int urunEkle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Urunler(URUNADI,KATEGORIID,ACIKLAMA,FIYAT) values (@urunAd,@katId,@aciklama,@fiyat)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select Urunler.*,KATEGORIADI from Urunler Inner Join Kategoriler on Kategoriler.ID=Urunler.KATEGORIID where Urunler.DURUM=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                    
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    
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
                
                con.Dispose();
                con.Close();
            }
        }

        public void urunleriListele2(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kategoriler", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cUrunCesitleri urun = new cUrunCesitleri()
                    {
                        UrunTurNo = Convert.ToInt32(dr["UrunTurNo"]),
                        KategoriAd = dr["KategoriAd"].ToString(),
                        Aciklama = dr["Aciklama"].ToString()
                    };

                    comboBox.Items.Add(urun);
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr?.Close();
                con.Dispose();
                con.Close();
            }
        }


        public void urunleriListele(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kategoriler", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string kategoriAdi = dr["KATEGORIADI"].ToString();
                    comboBox.Items.Add(kategoriAdi);
                }
                comboBox.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr?.Close();
                con.Dispose();
                con.Close();
            }
        }




        public int urunGuncelle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update Urunler set URUNAD=@urunad,KATAGORIID=@katID,ACIKLAMA=@aciklama,FIYAT=@fiyat where ID=@urunID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunad", SqlDbType.Int).Value = u._urunad;
                cmd.Parameters.Add("@katID", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.Int).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Int).Value = u._fiyat;
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        public int urunSil(cUrunler u, int kat)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "update Urunler set Durum=1 where";
            if (kat == 0)
            {
                sql += "KATEGORIID=@urunID";
            }         
            else
            {
                sql += "ID=@urunID";
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
          
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        public void urunleriListeleByUrunId(ListView lv, int urunId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select Urunler.*,KATEGORIADI, Urunler.URUNADI, Urunler.FIYAT from Urunler Inner Join kategoriler on kategoriler.ID=Urunler.KATEGORIID where urunler.DURUM=0 and urunler.KATEGORIID=@urunID ", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = urunId;

            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADI"].ToString());  
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                    sayac++;

                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        public void urunleriListeleIstatisklereGore(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.Urunler.URUNAD , sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.Urunler ON dbo.kategoriler.ID = dbo.Urunler.KATEGORIID INNER JOIN dbo.satislar ON dbo.Urunler.ID = dbo.satislar.URUNID INNER JOIN dbo.adisyonlar ON dbo.satislar.ADISYONID =  dbo.adisyonlar.ID Where (CONVERT(datetime,TARIH,104) BETWEEN CONVERT datetime, '01.01.2023',104) AND CONVERT(datetime,'01.01.2015',104)) group by dbo.Urunler.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
                    sayac++;

                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        public void urunleriListeleIstatisklereGoreUrunId(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis, int urunKatId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.Urunler.URUNAD , sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.Urunler ON dbo.kategoriler.ID = dbo.Urunler.KATEGORIID INNER JOIN dbo.satislar ON dbo.Urunler.ID = dbo.satislar.URUNID INNER JOIN dbo.adisyonlar ON dbo.satislar.ADISYONID =  dbo.adisyonlar.ID Where (CONVERT(datetime,TARIH,104) BETWEEN CONVERT datetime, '01.01.2023',104) AND CONVERT(datetime,'01.01.2015',104)) and (dbo.Uurnler.KATEGORIID=@katId) group by dbo.Urunler.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunKatId;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
                    sayac++;

                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }






    }
}
