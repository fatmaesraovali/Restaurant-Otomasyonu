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
    class cPersoneller
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _PersonelId;
        private int _PersonelGorevId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;

        #endregion
        #region Properties
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int PersonelGorevId { get => _PersonelGorevId; set => _PersonelGorevId = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; }
        #endregion

        public bool personelEntryControl(string password, int UserId)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@Id and PAROLA=@password", con);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }


            return result;
        }
        public void personelGetByInformation (ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller", con);
            
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();

                }

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                cPersoneller p = new cPersoneller();
                p._PersonelId = Convert.ToInt32(dr["ID"]);
                p._PersonelGorevId = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                p._PersonelDurum = Convert.ToBoolean(dr["DURUM"]);
                cb.Items.Add(p);
            }
            dr.Close();
            con.Close();

        }
        public override string ToString()
        {
            return PersonelAd + " " + PersonelSoyad; 
        }
        public void personelBilgileriniGetirLV(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Personeller.*,PersonelGorevleri.GOREV from Personeller Inner Join PersonelGorevleri on PersonelGorevleri.ID=Personeller.GOREVID where Personeller.DURUM=0", con);

            if (con.State == ConnectionState.Closed)
            {

                con.Open();

            }

            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());

                i++;


            }
            dr.Close();
            con.Close();

        }
        public void personelBilgileriniGetirfromIDLV(ListView lv, int perID)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Personeller.*,PersonelGorevleri.GOREV from Personeller Inner Join PersonelGorevleri on PersonelGorevleri.ID=Personeller.GOREVID where Personeller.DURUM=0 and Personeller.ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;  
            if (con.State == ConnectionState.Closed)
            {

                con.Open();

            }

            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());

                i++;


            }
            dr.Close();
            con.Close();

        }
        public string personelBilgiGetirIsim(int perId)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select AD + SOYAD from Personeller where Personeller.DURUM=0 and Personeller.ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;
           

            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();

                }
                sonuc = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            
            con.Close();
            return sonuc;
        }
        public bool personelSifreDegistir(int PersonelID, string pass)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update Personeller set PAROLA=@pas where ID=@perId", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = PersonelID;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;


            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            con.Close();

            return sonuc;

        }
        public bool personelEkle(cPersoneller cp)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert into Personeller(AD,SOYAD,KULLANICIADI,PAROLA,GOREVID) values (@AD,@SOYAD,@KULLANICIADI,@PAROLA,@GOREVID)", con);
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("KULLANICIADI", SqlDbType.VarChar).Value = _PersonelKullaniciAdi;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
            


            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            con.Close();

            return sonuc;

        }
        public bool personelGuncelle(cPersoneller cp, int perId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update Personeller set AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA,GOREVID=@GOREVID where ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
            


            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            con.Close();

            return sonuc;

        }
        public bool personelSil(int perId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update Personeller set DURUM=1 where ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;


            try
            {
                if (con.State == ConnectionState.Closed)
                {

                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            con.Close();

            return sonuc;

        }





    }
}