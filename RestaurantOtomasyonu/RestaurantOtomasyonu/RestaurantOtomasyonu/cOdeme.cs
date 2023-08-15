﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantOtomasyonu
{
    class cOdeme
    {
        cGenel gnl = new cGenel();

        #region Fields
        
        private int _AdisyonID;
        private int _OdemeTurId;
        private decimal _AraToplam;
        private decimal _Indirim;
        private decimal _Kdvtutari;
        private decimal _GenelToplam;
        private DateTime _Tarih;
        private int _MusteriId;
        #endregion
        #region Properties
    
        public int AdisyonID { get => _AdisyonID; set => _AdisyonID = value; }
        public int OdemeTurId { get => _OdemeTurId; set => _OdemeTurId = value; }
        public decimal AraToplam { get => _AraToplam; set => _AraToplam = value; }
        public decimal Indirim { get => _Indirim; set => _Indirim = value; }
        public decimal Kdvtutari { get => _Kdvtutari; set => _Kdvtutari = value; }
        public decimal GenelToplam { get => _GenelToplam; set => _GenelToplam = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int MusteriId { get => _MusteriId; set => _MusteriId = value; }
        #endregion

        public bool billClose(cOdeme bill)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into HesapOdemeleri(ADISYONID,ODEMETURID,MUSTERIID,ARATOPLAM,KDVTUTARI,INDIRIM,TOPAMTUTAR) values (@ADISYONID,@ODEMETURID,@MUSTERIID,@ARATOPLAM,@KDVTUTARI,@INDIRIM,@TOPAMTUTAR)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("ADISYONID", SqlDbType.Int).Value = bill._AdisyonID;
                cmd.Parameters.Add("ODEMETURID", SqlDbType.Int).Value = bill._OdemeTurId;
                cmd.Parameters.Add("MUSTERIID", SqlDbType.Int).Value = bill._MusteriId;
                cmd.Parameters.Add("ARATOPLAM", SqlDbType.Int).Value = bill._AraToplam;
                cmd.Parameters.Add("KDVTUTARI", SqlDbType.Int).Value = bill._Kdvtutari;
                cmd.Parameters.Add("INDIRIM", SqlDbType.Int).Value = bill._Indirim;
                cmd.Parameters.Add("TOPLAMTUTAR", SqlDbType.Int).Value = bill._GenelToplam;


                result = Convert.ToBoolean(cmd.ExecuteNonQuery());


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

        public decimal sumTotalforClientId(int clientId)
        {
            decimal total = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(TOPLAMTUTAR) as total from HesapOdemeleri Where MUSTERIID=@clientId",con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("clientId", SqlDbType.Int).Value = clientId;
                total = Convert.ToDecimal(cmd.ExecuteScalar());

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


            return total;
        }
    }

}
