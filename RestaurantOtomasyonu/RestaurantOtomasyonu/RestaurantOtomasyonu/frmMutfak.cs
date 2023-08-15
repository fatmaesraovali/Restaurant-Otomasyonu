using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantOtomasyonu
{
    public partial class frmMutfak : Form
    {
        public frmMutfak()
        {
            InitializeComponent();
        }
        private void frmMutfak_Load(object sender, EventArgs e)
        {
            cUrunCesitleri AnaKategori = new cUrunCesitleri();
            AnaKategori.urunCesitleriniGetir(cbKategoriler);
            //cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
           

            label6.Visible = false;
            txtArama.Visible = false;

            cUrunler C = new cUrunler();
            C.urunleriListele(lvGıdaListesi);
            C.urunleriListele(cbKategoriler);
        }

        private void Temizle()
        {
            txtGıdaAdı.Clear();
            txtGıdaFiyatı.Clear();
            txtGıdaFiyatı.Text = string.Format("{0:0.##}", 0);

        }

      

        private void btnMasaCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGıdaAdı.Text.Trim()=="" || txtGıdaFiyatı.Text.Trim()=="" || cbKategoriler.SelectedItem.ToString()=="Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı Fiyatı ve kategori seçilmemiştir,", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGıdaFiyatı.Text);
                    c.Urunad = txtGıdaAdı.Text;
                    c.Aciklama = "Ürün eklendi";
                    c.Urunturno = urunturNo;
                    int sonuc = c.urunEkle(c);
                    if (sonuc!=0)
                    {   
                        MessageBox.Show("Ürün Eklenmiştir");
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAdı.Text.Trim()=="")
                {
                    MessageBox.Show("Lütfen bir kategori ismi giriniz.", "Dikkat Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gida = new cUrunCesitleri();
                    gida.KategoriAd = txtKategoriAdı.Text;
                    gida.Aciklama = txtAciklama.Text;
                    int sonuc = gida.urunKategoriEkle(gida);
                    if (sonuc !=0)
                    {
                        MessageBox.Show("Kategori Eklenmiştir");
                        yenile();
                        Temizle();
                    }
                }
            }
        }

        int urunturNo = 0;
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunler u = new cUrunler();
            if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
            {
                u.urunleriListele(cbKategoriler);
            }
            else
            {
                //cUrunCesitleri cesit = (cUrunCesitleri)cbKategoriler.SelectedIndex;
                //urunturNo = cesit.UrunTurNo;
                u.urunleriListeleByUrunId(lvGıdaListesi, cbKategoriler.SelectedIndex + 1);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGıdaAdı.Text.Trim() == "" || txtGıdaFiyatı.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı Fiyatı ve kategori seçilmemiştir,", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGıdaFiyatı.Text);
                    c.Urunad = txtGıdaAdı.Text;
                    c.Urunid = Convert.ToInt32(txtUrunId.Text);
                    c.Urunturno = Convert.ToInt32(txtKategoriId.Text);
                    c.Aciklama = "Ürün Güncellendi";
                    c.Urunturno = Convert.ToInt32(txtUrunId.Text);
                    int sonuc = c.urunGuncelle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Güncellenmiş");
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAdı.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz.", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gida = new cUrunCesitleri();
                    gida.KategoriAd = txtKategoriAdı.Text;
                    gida.Aciklama = txtAciklama.Text;
                    gida.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = gida.urunKategoriGuncelle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Güncellenmiştir");      
                        gida.urunCesitleriniGetir(lvKategoriler);
                        Temizle();
                    }
                }
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKategoriAdı.Text = lvGıdaListesi.SelectedItems[0].SubItems[1].Text;
            txtKategoriId.Text = lvGıdaListesi.SelectedItems[0].SubItems[0].Text;
            txtAciklama.Text = lvGıdaListesi.SelectedItems[0].SubItems[2].Text;
        }

        private void lvGıdaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGıdaListesi.SelectedItems.Count>0)
            {
                txtGıdaAdı.Text = lvGıdaListesi.SelectedItems[0].SubItems[3].Text;
                txtGıdaFiyatı.Text = lvGıdaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunId.Text = lvGıdaListesi.SelectedItems[0].SubItems[0].Text;
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (lvGıdaListesi.SelectedItems.Count>0)
                {
                    if (MessageBox.Show("Ürün Silmekte Emin Misiniz?", "Dikkat, Bilgiler Silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                    {
                         cUrunler c = new cUrunler();
                         c.Urunid = Convert.ToInt32(txtUrunId.Text);
                    
                         int sonuc = c.urunSil(c, Convert.ToInt32(txtKategoriId.Text));
                         if (sonuc != 0)
                         {
                              MessageBox.Show("Ürün Silinmiştir..");      
                              cbKategoriler_SelectedIndexChanged(sender, e);
                              yenile();
                              Temizle();
                         }
                    }
                }
                else
                {
                    MessageBox.Show("Ürün Silmek için bir ürün seçiniz.?", "Dikkat, ürün seçmediniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (lvKategoriler.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Ürün Silmekte Emin Misiniz?", "Dikkat, Bilgiler Silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cUrunCesitleri uc = new cUrunCesitleri();
                   
     
                        int sonuc = uc.urunKategoriSil(Convert.ToInt32(txtKategoriId.Text));
                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün silinmiştir");
                            cUrunler c = new cUrunler();
                            c.Urunid = Convert.ToInt32(txtKategoriId.Text);
                            c.urunSil(c, 0);
                            yenile();
                            Temizle();
                        }
                    }
                }
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            txtArama.Visible = true;
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                cUrunler u = new cUrunler();
                u.urunleriListeleByUrunAdi(lvGıdaListesi, txtArama.Text);
            }
            else
            {
                cUrunCesitleri uc = new cUrunCesitleri();
                uc.urunCesitleriniGetir(lvKategoriler, txtArama.Text);
            }
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGıdaListesi.Visible = true;
            yenile();
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGıdaListesi.Visible = false;
            yenile();
          //  cUrunCesitleri uc = new cUrunCesitleri();
          //  uc.urunCesitleriniGetir(lvKategoriler);
        }
        private void yenile()
        {
            cUrunCesitleri uc = new cUrunCesitleri();
            uc.urunCesitleriniGetir(cbKategoriler);
            uc.urunCesitleriniGetir(lvKategoriler);
            cUrunler c = new cUrunler();
            c.urunleriListele(lvGıdaListesi);
        }
    }
    
}
