using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantOtomasyonu
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
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

        private void frmSetting_Load(object sender, EventArgs e)
        {
            cPersoneller cp = new cPersoneller();
            cPersonelGorev cpg = new cPersonelGorev();
            string gorev = cpg.PersonelGorevTanim(cGenel._gorevId);
            if (gorev=="Müdür")
            {

                cp.personelGetByInformation(cbPersonel);
                cpg.PersonelGorevGetir(cbGörevi);
                cp.personelBilgileriniGetirLV(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnYeniDegistir.Enabled = false;
                btnEkle.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;
                lblBilgi.Text = "Mevki : Müdür / Yetki Sınırsız / Kullanıcı : " + cp.personelBilgiGetirIsim(cGenel._personelId);
        
            }
            else
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                lblBilgi.Text = "Mevki : Müdür / Yetki Sınırsız / Kullanıcı : " + cp.personelBilgiGetirIsim(cGenel._personelId);
            }
        }

        private void txtDegistir_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text.Trim() != "" || txtTekrarYeniSifre.Text.Trim() != "")
            {
                if (txtYeniSifre.Text == txtTekrarYeniSifre.Text)
                {
                    if (txtPersonelId.Text != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(txtPersonelId.Text), txtYeniSifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre değiştirme işlemi başarıyla gerçekleşmiştir.!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçini!");

                    }
                }
                else
                {
                    MessageBox.Show("Şifrelere Aynı Değil!");
                }
            }
            else
            {
                MessageBox.Show("Şifre Alanını Boş Bırakmayınız!");

            }
        }

        private void cbGörevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersonelGorev c = (cPersonelGorev)cbGörevi.SelectedItem;
            txtGörevID2.Text = Convert.ToString(c.PersonelGorevId);
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller c = (cPersoneller)cbPersonel.SelectedItem;
            txtPersonelId.Text = Convert.ToString(c.PersonelId);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = false;
            btnEkle.Enabled = true;
            btnYeniDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;
        }

        private void btnYeniDegistir_Click(object sender, EventArgs e)
        {

            if (lvPersoneller.SelectedItems.Count > 0)
            {


                if (txtAd.Text != "" || txtSoyad.Text != "" || txtSifre.Text != "" || txtSifreTekrar.Text != "" || txtGörevID2.Text != "")
                {
                    if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length > 5 || txtSifreTekrar.Text.Length > 5))
                    {
                        cPersoneller c = new cPersoneller();
                        c.PersonelAd = txtAd.Text.Trim();
                        c.PersonelSoyad = txtSoyad.Text.Trim();
                        c.PersonelParola = txtSifreTekrar.Text.Trim();
                        c.PersonelGorevId = Convert.ToInt32(txtGörevID2.Text);
                        bool sonuc = c.personelGuncelle(c, Convert.ToInt32(txtPersonelId.Text));
                        if (sonuc)
                        {
                            MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                            c.personelBilgileriniGetirLV(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt eklenirken bir hata oluştu.");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Aynı değil.");

                    }
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız.");

                }
            
            }
            else
            {
                MessageBox.Show("Kayıt seçiniz");

            }
        }
    private void btnSil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Silmek istediğinize amin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
                {
                    cPersoneller c = new cPersoneller();
                    bool sonuc = c.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt başarıyla silinmiştir");
                        c.personelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinirken bir hata oluştu");

                    }
                }
                else
                {
                    MessageBox.Show("Kayıt seçiniz");

                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Trim()!="" & txtSoyad.Text.Trim()!="" & txtSifre.Text.Trim()!="" & txtSifreTekrar.Text!="" & txtGörevID2.Text.Trim()!="")
            {
                if ((txtSifreTekrar.Text.Trim()==txtSifre.Text.Trim())&&(txtSifre.Text.Length>5 || txtSifreTekrar.Text.Length>5))
                {
                    cPersoneller c = new cPersoneller();
                    c.PersonelAd = txtAd.Text.Trim();
                    c.PersonelSoyad = txtSoyad.Text.Trim();
                    c.PersonelParola = txtSifreTekrar.Text.Trim();
                    c.PersonelGorevId = Convert.ToInt32(txtGörevID2.Text);
                    bool sonuc = c.personelEkle(c);
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                        c.personelBilgileriniGetirLV(lvPersoneller);

                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenirken bir hata oluştu.");

                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı değil.");

                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Trim() != "" || textBox8.Text.Trim() != "")
            {
                if (textBox9.Text == textBox8.Text)
                {
                    if (cGenel._personelId.ToString() != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(cGenel._personelId), textBox9.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre değiştirme işlemi başarıyla gerçekleşmiştir.!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçini!");

                    }
                }
                else
                {
                    MessageBox.Show("Şifrelere Aynı Değil!");
                }
            }
            else
            {
                MessageBox.Show("Şifre Alanını Boş Bırakmayınız!");

            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count>0)
            {
                btnSil.Enabled = true;
                txtPersonelId.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                cbGörevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;
                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                btnSil.Enabled = false;
            }
        }
    }
}
