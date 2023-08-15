using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace RestaurantOtomasyonu
{
    class cMasalar
    {
        #region Fields
        private int _ID;
        private int _KAPASITE;
        private int _SERVİSTURU;
        private int _DURUM;
        private int _ONAY;
        private string _MasaBilgi;
        #endregion
        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int KAPASITE { get => _KAPASITE; set => _KAPASITE = value; }
        public int SERVİSTURU { get => _SERVİSTURU; set => _SERVİSTURU = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int ONAY { get => _ONAY; set => _ONAY = value; }
        public string MasaBilgi { get => _MasaBilgi; set => _MasaBilgi = value; }
        #endregion

        cGenel gnl = new cGenel();
        public string SessionSum(int DURUM, string MasaId)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH,MasaId from Adisyonlar Right Join Masalar on Adisyonlar.MasaId=masalar.ID Where Masalar.DURUM=@durum and Adisyonlar.Durum=0 and masalar.ID=MasaId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = DURUM;
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Convert.ToInt32(MasaId);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
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
            return dt;


        }

        public int TableGetbyNumber(string TableValue)
        {
            string aa = TableValue;
            int lenght = aa.Length;

            if (lenght > 8)
            {
                return Convert.ToInt32(aa.Substring(lenght - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(lenght - 1, 1));
            }
        }

        public bool TableGetbyState(int ButtonName, int DURUM)
        {

            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM From Masalar Where Id=@MasaId and DURUM=@durum", con);

            cmd.Parameters.Add("MasaId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = DURUM;

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());

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

            return result;

        }
    
        public void setChangeTableState(string ButonName, int satate)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update masalar Set DURUM=@Durum where ID=@MasaNo", con);
            string MasaNo = "" ;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string aa = ButonName;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = satate;
            if (uzunluk>8)
            {
                MasaNo = aa.Substring(uzunluk - 2, 2);
            }
            else
            {
                MasaNo = aa.Substring(uzunluk - 1, 1);
            }
            cmd.Parameters.Add("MasaNo", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public void MasaKapasitesiveDurumuGetir(ComboBox cm)
        {
            cm.Items.Clear();
            string durum = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from Masalar", con);

            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cMasalar c = new cMasalar();
                if (c._DURUM == 2)
                    durum = "Dolu";
                else if (c._DURUM == 3)
                    durum = "Rezerve";
                c._KAPASITE = Convert.ToInt32(dr["KAPASITE"]);
                c._MasaBilgi = "Masa No: " + dr["ID"].ToString() + " Kapasitesi : " + dr["KAPASITE"].ToString();
                c.ID = Convert.ToInt32(dr["ID"]);
                cm.Items.Add(c);
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public override string ToString()
        {
            return MasaBilgi;
        }
    }

}
