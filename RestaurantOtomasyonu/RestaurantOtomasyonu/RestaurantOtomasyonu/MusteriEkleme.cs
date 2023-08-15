using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RestaurantOtomasyonu
{
    public partial class MusteriEkleme : Form
    {
        public MusteriEkleme()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {


            if (txtTelefon.Text.Length>3)
            {
                if (txtMusteriAd.Text=="" || txtMusteriSoyad.Text=="")
                {
                    MessageBox.Show("Lütfen müşteri ad ve soyad alanlarını doldurunuz."); 
                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    bool sonuc = c.MusteriVarmi(txtTelefon.Text);
                    if (!sonuc)
                    {
                        c.Musteriad = txtMusteriAd.Text;
                        c.Musterisoyad = txtMusteriSoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Adres = txtAdres.Text;
                        c.Email = txtEmail.Text;
                        txtMusteriNo.Text = c.musteriEkle(c).ToString();
                        if (txtMusteriNo.Text !="")
                        {
                            MessageBox.Show("Müşteri Eklendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Eklenemedi!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimle kayıt bulunmakta!!!");

                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 3 haneli bir telefon numarası giriniz.");
            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (cGenel._MusteriEkleme==0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                cGenel._MusteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if (cGenel._MusteriEkleme == 1)
            {
                frmPaketSiparis frm = new frmPaketSiparis();
                cGenel._MusteriEkleme = 0;
                this.Close();
                frm.Show();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 3)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen müşteri ad ve soyad alanlarını doldurunuz.");
                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    c.Musteriad = txtMusteriAd.Text;
                    c.Musterisoyad = txtMusteriSoyad.Text;
                    c.Telefon = txtTelefon.Text;
                    c.Email = txtEmail.Text;
                    c.Adres = txtAdres.Text;
                    c.Musteriid = Convert.ToInt32(txtMusteriNo.Text);
                    bool sonuc=c.musteriBilgileriGuncelle(c);
                    if (sonuc)
                    {
                        
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Güncellendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Güncellenemedi!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimle kayıt bulunmakta!!!");

                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 3 haneli bir telefon numarası giriniz.");
            }
        }

        private void MusteriEkleme_Load(object sender, EventArgs e)
        {
            if (cGenel._MusteriId>0)
            {
                cMusteriler c = new cMusteriler();
                txtMusteriNo.Text = cGenel._MusteriId.ToString();
                c.musterileriGetirId(Convert.ToInt32(txtMusteriNo.Text), txtMusteriAd, txtMusteriSoyad, txtTelefon, txtAdres, txtEmail);
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnMasaCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?","Uyarı !!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)    
            {
                Application.Exit();
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            frmMusteriAra frm = new frmMusteriAra();
            this.Close();
            frm.Show();
        }
    }
}
