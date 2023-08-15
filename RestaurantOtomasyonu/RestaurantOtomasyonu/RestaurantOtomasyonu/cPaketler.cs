using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantOtomasyonu
{
    class cPaketler
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _ID;
        private int _AdditionID;
        private int _ClientId;
        private int _Description;
        private int _State;
        private int _Paytypeid;
        #endregion
        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int AdditionID { get => _AdditionID; set => _AdditionID = value; }
        public int ClientId { get => _ClientId; set => _ClientId = value; }
        public int Description { get => _Description; set => _Description = value; }
        public int State { get => _State; set => _State = value; }
        public int Paytypeid { get => _Paytypeid; set => _Paytypeid = value; } 
        #endregion

        public bool OrderSeriveceOpen(cPaketler order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into PaketSiparis(ADISYONID,MUSTERIID,ODEMETURID,ACIKLAMA) values (@ADISYONID,@MUSTERIID,@ODEMETURID,@ACIKLAMA)", con);

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADİSYONID", SqlDbType.Int).Value = order._AdditionID;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = order._ClientId;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = order._Paytypeid;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = order._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            return result;
        }

        public void OrderSeriveceClose(int AdditionID)
        { 
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update PaketSiparis set PaketSiparis.durum=1 where PaketSiparis.ADISYONID=@AdditionID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdditionID", SqlDbType.Int).Value = AdditionID;
                cmd.ExecuteNonQuery();
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

        public int OdemeTurIdGetir(int AdisyonId)
        {
            int OdemeTurID = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select PaketSiparis.ODEMETURID from PaketSiparis Inner Join Adisyonlar on PaketSiparis.ADISYONID=Adisyonlar.ID where Adisyonlar.ID=@AdisyonId",con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;

                OdemeTurID = Convert.ToInt32(cmd.ExecuteNonQuery());
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
            return OdemeTurID;
        }

        public int MusteriSonAdisyonIDGetir(int MusteriID)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Adisyonlar.ID from Adisyonlar Inner Join PaketSiparis on PaketSiparis.ADISYONID=Adisyonlar.ID where (Adisyonlar.DURUM=0) and (PaketSiparis.DURUM=0) and PaketSiparis MUSTERIID=@MusteriID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;

                no = Convert.ToInt32(cmd.ExecuteScalar());
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
            return no;
        }

        public bool getCheckOpenAdditionID(int AdditionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Adsiyonlar where (DURUM=0) and (ID=@AdditionID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdditionID", SqlDbType.Int).Value = AdditionID;
                
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


    }
}
