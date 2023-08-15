using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantOtomasyonu
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void rbNakit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblIndirim_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        cSiparis cs = new cSiparis(); int odemeTuru = 0;
        private void frmBill_Load(object sender, EventArgs e)
        {
            gbIndirim.Visible = false;
           
            if (cGenel._ServisTurNo == 1)
            {
                lblAdisyonId.Text = cGenel._AdisyonId;
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lblToplamTutar.Text = string.Format("0:0.000", toplam);
                    lblOdenecek.Text = string.Format("0:0.000", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKDV.Text = string.Format("{0:0.000}", kdv);
                }
                if (chkIndirim.Checked)
                    gbIndirim.Visible = false;
                else
                    gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else if (cGenel._ServisTurNo == 2)
            {
                lblAdisyonId.Text = cGenel._AdisyonId;
                cPaketler pc = new cPaketler();
                odemeTuru = pc.OdemeTurIdGetir(Convert.ToInt32(lblAdisyonId.Text));
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));


                if (odemeTuru == 1)
                {
                    rbKrediKartı.Checked = true;
                }
                else if (odemeTuru == 2)
                {
                    rbKrediKartı.Checked = true;
                }
                else if (odemeTuru == 3)
                {
                    rbTicket.Checked = true;
                }

                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lblToplamTutar.Text = string.Format("0:0.000", toplam);
                    lblOdenecek.Text = string.Format("0:0.000", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKDV.Text = string.Format("{0:0.000}", kdv);
                }
                if (chkIndirim.Checked)
                    gbIndirim.Visible = false;
                else
                    gbIndirim.Visible = true;
                txtIndirimTutari.Clear(); 
            }
        }

        private void txtIndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtIndirimTutari.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {
                    try
                    {
                        lblIndirim.Text = string.Format("{0:0.000}", Convert.ToDecimal(txtIndirimTutari.Text));
                    }
                    catch (Exception)
                    {
                        lblIndirim.Text = string.Format("{0:0.000}", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim Tutarı Toplam Tutardan Fazla Olamaz !!! ");
                }
            }
            catch (Exception)
            {
                lblIndirim.Text = string.Format("{0:0.000}", 0);
            }


        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndirim.Checked)
            {
                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else
            {
                gbIndirim.Visible = false;
                txtIndirimTutari.Clear();
            }
        }

        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text) > 0)
            {
                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(lblIndirim.Text);
                lblOdenecek.Text = string.Format("{0:0.000}", odenecek);
            }
            decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
            lblKDV.Text = string.Format("{0:0.000}", kdv);
        }

        cMasalar masalar = new cMasalar();
        cRezervasyon rezerve = new cRezervasyon();
        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            if (cGenel._ServisTurNo == 1)
            {
                int masaid = masalar.TableGetbyNumber(cGenel._ButtonName);
                int musteriId = 0;

                if (masalar.TableGetbyState(masaid, 4) == true)
                {
                    musteriId = rezerve.getByClientIdFromRezervasyon(masaid);
                }
                else
                {
                    musteriId = 1;
                }
                int odemeTurId = 0;
                if (rbNakit.Checked)
                {
                    odemeTurId = 1;
                }
                if (rbKrediKartı.Checked)
                {
                    odemeTurId = 2;
                }
                if (rbTicket.Checked)
                {
                    odemeTurId = 3;
                }

                cOdeme odeme = new cOdeme();

                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTurId;
                odeme.MusteriId = musteriId;
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKDV.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);
                if (result)
                {

                    MessageBox.Show("Hesap Kapatılmıştır.");
                    masalar.setChangeTableState(Convert.ToString(masaid), 1);

                    cRezervasyon c = new cRezervasyon();
                    c.rezervationclose(Convert.ToInt32(lblAdisyonId.Text));

                    cAdisyon a = new cAdisyon();
                    a.adisyonkapat(Convert.ToInt32(lblAdisyonId.Text), 0);

                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();



                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu. Lütfen yetkililere bildiriniz.");
                }

            }
            else if (cGenel._ServisTurNo == 2)
            {
                cOdeme odeme = new cOdeme();

                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTuru;
                odeme.MusteriId = 1;
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKDV.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);
                if (result)
                {



                    cAdisyon a = new cAdisyon();
                    a.adisyonkapat(Convert.ToInt32(lblAdisyonId.Text), 1);

                    cPaketler p = new cPaketler();
                    p.OrderSeriveceClose(Convert.ToInt32(lblAdisyonId.Text));
                    MessageBox.Show("Hesap Kapatılmıştır.");


                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();



                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu. Lütfen yetkililere bildiriniz.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("RestaurantOtomasyonu RESTAURANT", Baslik, sb, 350, 100, st);

            e.Graphics.DrawString("------------------", altBaslik, sb, 350, 120, st);
            e.Graphics.DrawString("Ürün Adı                         Adet                  Fiyatı", altBaslik, sb, 150, 250, st);
            e.Graphics.DrawString("-------------------------------------------------------------------------", altBaslik, sb, 150, 280, st);
            for (int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, icerik, sb, 150, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, icerik, sb, 350, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[3].Text, icerik, sb, 420, 300 + i * 30, st);
            }
            e.Graphics.DrawString("-------------------------------------------------------------------------", altBaslik, sb, 150, 300 + 30 * lvUrunler.Items.Count, st);
            e.Graphics.DrawString("İndirim Tutarı  :-----------------" + lblIndirim.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 1), st);
            e.Graphics.DrawString("KDV Tutarı  :-----------------" + lblKDV.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutar  :-----------------" + lblToplamTutar.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutarı  :-----------------" + lblOdenecek.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 4), st);
        }

        private void lvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblAdisyonId_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

    
}

