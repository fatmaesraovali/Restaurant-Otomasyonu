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
    public partial class frmRezervasyon : Form
    {
        public frmRezervasyon()
        {
            InitializeComponent();
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterileriGetir(lvMusteriler);

            cMasalar masa = new cMasalar();
            masa.MasaKapasitesiveDurumuGetir(cbMasaSec);

            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Time;
        }

        private void txtMusteri_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirAd(lvMusteriler, txtMusteri.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterigetirAd(lvMusteriler, txtAdres.Text);
        }
        void Temizle ()
        {
            txtAdres.Clear();
            txtKisiSayisi.Clear();
            txtMasaSeç.Clear();
            txtTarih.Clear();
            txtAdres.Clear(); 
        }

        private void btnRezervasyonAç_Click(object sender, EventArgs e)
        {
            cRezervasyon r = new cRezervasyon();

            if(lvMusteriler.SelectedItems.Count>0)
            {
                bool sonuc = r.RezervasyonAcikmiKontrol(Convert.ToInt32(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text)));
                if(!sonuc)
                {
                    if(txtTarih.Text !="")
                    {
                        if(txtKisiSayisi.Text !="")
                        {
                            cMasalar masa = new cMasalar();
                            if (masa.TableGetbyState(Convert.ToInt32(txtMasaNo.Text),1))
                            {
                                cAdisyon a = new cAdisyon();
                                a.Tarih = Convert.ToDateTime(txtTarih.Text);
                                a.ServisTurNo = 1;
                                a.MasaId = Convert.ToInt32(txtMasaNo.Text);
                                a.PersonelId = cGenel._personelId;

                                r.ClientId = Convert.ToInt32(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                                r.TableId = Convert.ToInt32(txtMasaNo.Text);
                                r.Date = Convert.ToDateTime(txtTarih.Text);
                                r.CleintCount = Convert.ToInt32(txtKisiSayisi.Text);
                                r.Description = txtAciklama.Text;

                                r.AdditionID = a.RezervasyonAdisyonAc(a);
                                sonuc = r.RezervasyonAc(r);

                                masa.setChangeTableState(txtMasaNo.Text, 3);

                                if(sonuc)
                                {
                                    MessageBox.Show("Rezervasyon başarıyla açılmıştır");
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon kayıtı gerçekleşememiştir lütfen yetkiliyle iletişime geçiniz.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon yapılan masa şu an dolu.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen kişi sayısı seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir tarih seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Bu müşteri üzerine açık bir rezervasyon bulunmaktadır.");
                }
            }
            
        }

        private void dtTarih_MouseEnter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_Enter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_MouseLeave(object sender, EventArgs e)
        {
            dtTarih.Width = 23;
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtTarih.Value.ToString();
        }

        private void txtKisiSayisi_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbKisiSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = cbKisiSayisi.SelectedItem.ToString();
        }

        private void cbMasaSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Enabled = true;
            txtMasaSeç.Text = cbMasaSec.SelectedItem.ToString();

            cMasalar kapasitesi = (cMasalar)cbMasaSec.SelectedItem;
            int kapasite = kapasitesi.KAPASITE;
            txtMasaNo.Text = Convert.ToString(kapasitesi.ID);

            cbKisiSayisi.Items.Clear();
            for (int i = 0; i < kapasite; i++)
            {
                cbKisiSayisi.Items.Add(i + 1);
            }
        }

        private void cbMasaSec_MouseEnter(object sender, EventArgs e)
        {
            cbMasaSec.Width = 220;
        }

        private void cbMasaSec_MouseLeave(object sender, EventArgs e)
        {
            cbMasaSec.Width = 23;
        }

        private void cbKisiSayisi_MouseLeave(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 23;
        }

        private void cbKisiSayisi_MouseEnter(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 100;
        }

        private void btnRezervasyonlar_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol frm = new frmSiparisKontrol();
            this.Close();
            frm.Show();
        }

        private void btnYeniMüsteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme frm = new MusteriEkleme();
            cGenel._MusteriEkleme = 0;                 
            this.Close();
            frm.Show();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if(lvMusteriler.SelectedItems.Count>0)
            {
                MusteriEkleme me = new MusteriEkleme();
                cGenel._MusteriEkleme = 0;
                cGenel._MusteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                this.Close();
                me.Show();
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
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtTarih_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
