using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace RestaurantOtomasyonu
{
    class cSiparis
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _Id;
        private int _adisyonID;
        private int _urunId;
        private int _adet;
        private int _masaId;
        #endregion
        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int AdisyonID { get => _adisyonID; set => _adisyonID = value; }
        public int UrunId { get => _urunId; set => _urunId = value; }
        public int Adet { get => _adet; set => _adet = value; }
        public int MasaId { get => _masaId; set => _masaId = value; } 
        #endregion

        public void getByOrder(ListView lv, int AdisyonId)

        {
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNAD, FIYAT,Satislar.ID,URUNID,Satislar.ADET from Satislar Inner Join Urunler on Satislar.URUNID=Urunler.ID Where ADISYONID=@AdısyonId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;
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
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

                    sayac++;
                }
            }
            catch (SqlException ex)
            {

                string hata =ex.Message;
                
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

        }

        public bool setSaveOrder(cSiparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satislar(ADISYONID,URUNID,ADET,MASAID,DURUM) values (@AdisyonNo,@UrunId,@Adet,@MasaId,1)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler.AdisyonID;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler.UrunId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler.Adet;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler.MasaId;
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

        public void setDeleteOrder(int satisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From Satislar Where ID=@SatisID", con);

            cmd.Parameters.Add("@SatisID", SqlDbType.Int).Value = satisId;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public decimal GenelToplam(int musteriId)
        {
            decimal geneltoplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT SUM(dbo.satislar.ADET * FIYAT) AS fiyat FROM dbo.musteriler INNER JOIN dbo.PaketSiparis ON dbo.musteriler.ID = PakerSiparis.MUSTERIID INNER JOIN Adisyonlar on Adisyonlar.ID=PaketSiparis.ADISYONID inner join dbo.satislar ON dbo.Adisyonlar.ID = dbo.satislar.ADISYONID INNER JOIN dbo.urunler ON dbo.urunler ON dbo.satislar.URUNID = dbo.urunler.ID Where (dbo.PaketSiparis.MUSTERIDI = @musteriId) AND (dbo.PaketSiparis.DURUM = 0)", con);
            cmd.Parameters.Add("musteriId", SqlDbType.Int).Value = musteriId;           
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                geneltoplam = Convert.ToDecimal(cmd.ExecuteScalar());
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
            return geneltoplam;
        }

        public void adisyonpaketsiparisDetaylari(ListView lv, int adisyonID)
        {
            lv.Items.Clear();
            decimal geneltoplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select satislar.ID as satisID,urunler.URUNAD,urunler.ADET from satislar Inner Join Adisyonlar on Adisyonlar.ID=satislar.ADISYONID INNER JOIN urunler.ID=satislar.URUNID where satislar.ADISYONID=@adisyonID", con);
            cmd.Parameters.Add("adisyonID", SqlDbType.Int).Value = adisyonID;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int i = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["satisID"].ToString());
                    lv.Items[i].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[i].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[i].SubItems.Add(dr["FIYAT"].ToString());

                    i++;
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
    }
}
