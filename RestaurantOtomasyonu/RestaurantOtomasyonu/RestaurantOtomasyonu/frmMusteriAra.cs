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
    public partial class frmMusteriAra : Form
    {
        public frmMusteriAra()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterigetirAd(lvMusteriler, txtMusteriAd.Text);
        }


        private void btnMasaCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {

            MusteriEkleme m = new MusteriEkleme();
            cGenel._MusteriEkleme = 1;
            m.Show();
        }

        private void frmMusteriAra_Load(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterileriGetir(lvMusteriler);
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
           

        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count>0)
            {
                MusteriEkleme frm = new MusteriEkleme();
                cGenel._MusteriEkleme = 1;
                cGenel._MusteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                this.Close();
                frm.Show(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if (txtAdisyonID.Text!="")
            {
                cGenel._AdisyonId = txtAdisyonID.Text;
                cPaketler c = new cPaketler();

                bool sonuc = c.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonID.Text));
                if (sonuc)
                {
                    frmBill frm = new frmBill();
                    cGenel._ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdisyonID.Text + "Nolu adisyon bulunamadı");
                }
            }
            else
            {
                MessageBox.Show(txtAdisyonID.Text + "Aramak istediğiniz adisyonu yazınız");
            }
        }

        private void lvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}