
namespace RestaurantOtomasyonu
{
    partial class frmRezervasyon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTarih = new System.Windows.Forms.TextBox();
            this.txtMasaSeç = new System.Windows.Forms.TextBox();
            this.txtKisiSayisi = new System.Windows.Forms.TextBox();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.cbMasaSec = new System.Windows.Forms.ComboBox();
            this.cbKisiSayisi = new System.Windows.Forms.ComboBox();
            this.txtMasaNo = new System.Windows.Forms.TextBox();
            this.txtMusteri = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lvMusteriler = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnYeniMusteri = new System.Windows.Forms.Button();
            this.btnRezervasyonAc = new System.Windows.Forms.Button();
            this.btnRezervasyonlar = new System.Windows.Forms.Button();
            this.btnMusteriGuncelle = new System.Windows.Forms.Button();
            this.btnMasaCikis = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(228, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarih :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(190, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Masa Seç :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(187, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kişi Sayısı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(191, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Açıklama :";
            // 
            // txtTarih
            // 
            this.txtTarih.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarih.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTarih.Location = new System.Drawing.Point(299, 104);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.ReadOnly = true;
            this.txtTarih.Size = new System.Drawing.Size(115, 28);
            this.txtTarih.TabIndex = 4;
            this.txtTarih.TextChanged += new System.EventHandler(this.txtTarih_TextChanged);
            // 
            // txtMasaSeç
            // 
            this.txtMasaSeç.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMasaSeç.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMasaSeç.Location = new System.Drawing.Point(299, 147);
            this.txtMasaSeç.Name = "txtMasaSeç";
            this.txtMasaSeç.ReadOnly = true;
            this.txtMasaSeç.Size = new System.Drawing.Size(115, 28);
            this.txtMasaSeç.TabIndex = 5;
            // 
            // txtKisiSayisi
            // 
            this.txtKisiSayisi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKisiSayisi.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtKisiSayisi.Location = new System.Drawing.Point(299, 190);
            this.txtKisiSayisi.Name = "txtKisiSayisi";
            this.txtKisiSayisi.ReadOnly = true;
            this.txtKisiSayisi.Size = new System.Drawing.Size(115, 28);
            this.txtKisiSayisi.TabIndex = 6;
            this.txtKisiSayisi.TextChanged += new System.EventHandler(this.txtKisiSayisi_TextChanged);
            // 
            // dtTarih
            // 
            this.dtTarih.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtTarih.Location = new System.Drawing.Point(419, 104);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(19, 29);
            this.dtTarih.TabIndex = 7;
            this.dtTarih.ValueChanged += new System.EventHandler(this.dtTarih_ValueChanged);
            this.dtTarih.Enter += new System.EventHandler(this.dtTarih_Enter);
            this.dtTarih.MouseEnter += new System.EventHandler(this.dtTarih_MouseEnter);
            this.dtTarih.MouseLeave += new System.EventHandler(this.dtTarih_MouseLeave);
            // 
            // cbMasaSec
            // 
            this.cbMasaSec.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbMasaSec.FormattingEnabled = true;
            this.cbMasaSec.Location = new System.Drawing.Point(419, 147);
            this.cbMasaSec.Name = "cbMasaSec";
            this.cbMasaSec.Size = new System.Drawing.Size(19, 29);
            this.cbMasaSec.TabIndex = 8;
            this.cbMasaSec.SelectedIndexChanged += new System.EventHandler(this.cbMasaSec_SelectedIndexChanged);
            this.cbMasaSec.MouseEnter += new System.EventHandler(this.cbMasaSec_MouseEnter);
            this.cbMasaSec.MouseLeave += new System.EventHandler(this.cbMasaSec_MouseLeave);
            // 
            // cbKisiSayisi
            // 
            this.cbKisiSayisi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbKisiSayisi.FormattingEnabled = true;
            this.cbKisiSayisi.Location = new System.Drawing.Point(419, 190);
            this.cbKisiSayisi.Name = "cbKisiSayisi";
            this.cbKisiSayisi.Size = new System.Drawing.Size(19, 29);
            this.cbKisiSayisi.TabIndex = 9;
            this.cbKisiSayisi.SelectedIndexChanged += new System.EventHandler(this.cbKisiSayisi_SelectedIndexChanged);
            this.cbKisiSayisi.MouseEnter += new System.EventHandler(this.cbKisiSayisi_MouseEnter);
            this.cbKisiSayisi.MouseLeave += new System.EventHandler(this.cbKisiSayisi_MouseLeave);
            // 
            // txtMasaNo
            // 
            this.txtMasaNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMasaNo.Location = new System.Drawing.Point(444, 147);
            this.txtMasaNo.Name = "txtMasaNo";
            this.txtMasaNo.ReadOnly = true;
            this.txtMasaNo.Size = new System.Drawing.Size(12, 29);
            this.txtMasaNo.TabIndex = 10;
            this.txtMasaNo.Visible = false;
            // 
            // txtMusteri
            // 
            this.txtMusteri.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMusteri.Location = new System.Drawing.Point(649, 94);
            this.txtMusteri.Name = "txtMusteri";
            this.txtMusteri.Size = new System.Drawing.Size(145, 29);
            this.txtMusteri.TabIndex = 11;
            this.txtMusteri.TextChanged += new System.EventHandler(this.txtMusteri_TextChanged);
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelefon.Location = new System.Drawing.Point(800, 94);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(145, 29);
            this.txtTelefon.TabIndex = 12;
            this.txtTelefon.TextChanged += new System.EventHandler(this.txtTelefon_TextChanged);
            // 
            // txtAdres
            // 
            this.txtAdres.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAdres.Location = new System.Drawing.Point(951, 94);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(145, 29);
            this.txtAdres.TabIndex = 13;
            this.txtAdres.TextChanged += new System.EventHandler(this.txtAdres_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(649, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Müşteri";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(800, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Telefon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(951, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Adres";
            // 
            // lvMusteriler
            // 
            this.lvMusteriler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvMusteriler.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lvMusteriler.FullRowSelect = true;
            this.lvMusteriler.GridLines = true;
            this.lvMusteriler.HideSelection = false;
            this.lvMusteriler.Location = new System.Drawing.Point(649, 129);
            this.lvMusteriler.MultiSelect = false;
            this.lvMusteriler.Name = "lvMusteriler";
            this.lvMusteriler.Size = new System.Drawing.Size(446, 239);
            this.lvMusteriler.TabIndex = 17;
            this.lvMusteriler.UseCompatibleStateImageBehavior = false;
            this.lvMusteriler.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MusteriNO";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ad";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Soyad";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Telefon";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Adres";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Email";
            // 
            // btnYeniMusteri
            // 
            this.btnYeniMusteri.BackgroundImage = global::RestaurantOtomasyonu.Properties.Resources.yenimüsteri;
            this.btnYeniMusteri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYeniMusteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniMusteri.Location = new System.Drawing.Point(398, 418);
            this.btnYeniMusteri.Name = "btnYeniMusteri";
            this.btnYeniMusteri.Size = new System.Drawing.Size(144, 66);
            this.btnYeniMusteri.TabIndex = 18;
            this.btnYeniMusteri.UseVisualStyleBackColor = true;
            this.btnYeniMusteri.Click += new System.EventHandler(this.btnYeniMüsteri_Click);
            // 
            // btnRezervasyonAc
            // 
            this.btnRezervasyonAc.BackgroundImage = global::RestaurantOtomasyonu.Properties.Resources.rezerve_açı;
            this.btnRezervasyonAc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRezervasyonAc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRezervasyonAc.Location = new System.Drawing.Point(548, 418);
            this.btnRezervasyonAc.Name = "btnRezervasyonAc";
            this.btnRezervasyonAc.Size = new System.Drawing.Size(144, 66);
            this.btnRezervasyonAc.TabIndex = 19;
            this.btnRezervasyonAc.UseVisualStyleBackColor = true;
            this.btnRezervasyonAc.Click += new System.EventHandler(this.btnRezervasyonAç_Click);
            // 
            // btnRezervasyonlar
            // 
            this.btnRezervasyonlar.BackgroundImage = global::RestaurantOtomasyonu.Properties.Resources.rezerveler;
            this.btnRezervasyonlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRezervasyonlar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRezervasyonlar.Location = new System.Drawing.Point(698, 418);
            this.btnRezervasyonlar.Name = "btnRezervasyonlar";
            this.btnRezervasyonlar.Size = new System.Drawing.Size(144, 66);
            this.btnRezervasyonlar.TabIndex = 20;
            this.btnRezervasyonlar.UseVisualStyleBackColor = true;
            this.btnRezervasyonlar.Click += new System.EventHandler(this.btnRezervasyonlar_Click);
            // 
            // btnMusteriGuncelle
            // 
            this.btnMusteriGuncelle.BackgroundImage = global::RestaurantOtomasyonu.Properties.Resources.müsteriguncelle;
            this.btnMusteriGuncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMusteriGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMusteriGuncelle.Location = new System.Drawing.Point(848, 418);
            this.btnMusteriGuncelle.Name = "btnMusteriGuncelle";
            this.btnMusteriGuncelle.Size = new System.Drawing.Size(144, 66);
            this.btnMusteriGuncelle.TabIndex = 21;
            this.btnMusteriGuncelle.UseVisualStyleBackColor = true;
            this.btnMusteriGuncelle.Click += new System.EventHandler(this.btnMusteriGuncelle_Click);
            // 
            // btnMasaCikis
            // 
            this.btnMasaCikis.BackgroundImage = global::RestaurantOtomasyonu.Properties.Resources.masalarçıkışbutonu;
            this.btnMasaCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMasaCikis.Location = new System.Drawing.Point(100, 553);
            this.btnMasaCikis.Name = "btnMasaCikis";
            this.btnMasaCikis.Size = new System.Drawing.Size(65, 60);
            this.btnMasaCikis.TabIndex = 24;
            this.btnMasaCikis.UseVisualStyleBackColor = true;
            this.btnMasaCikis.Click += new System.EventHandler(this.btnMasaCikis_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.BackgroundImage = global::RestaurantOtomasyonu.Properties.Resources.masalargeridönbutonu;
            this.btnGeriDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriDon.Location = new System.Drawing.Point(29, 553);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(65, 60);
            this.btnGeriDon.TabIndex = 23;
            this.btnGeriDon.UseVisualStyleBackColor = true;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAciklama.Location = new System.Drawing.Point(299, 233);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(139, 135);
            this.txtAciklama.TabIndex = 25;
            // 
            // frmRezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RestaurantOtomasyonu.Properties.Resources.stock_photo_black_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1179, 616);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.btnMasaCikis);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnMusteriGuncelle);
            this.Controls.Add(this.btnRezervasyonlar);
            this.Controls.Add(this.btnRezervasyonAc);
            this.Controls.Add(this.btnYeniMusteri);
            this.Controls.Add(this.lvMusteriler);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtMusteri);
            this.Controls.Add(this.txtMasaNo);
            this.Controls.Add(this.cbKisiSayisi);
            this.Controls.Add(this.cbMasaSec);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.txtKisiSayisi);
            this.Controls.Add(this.txtMasaSeç);
            this.Controls.Add(this.txtTarih);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRezervasyon";
            this.Text = "frmRezervasyon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRezervasyon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTarih;
        private System.Windows.Forms.TextBox txtMasaSeç;
        private System.Windows.Forms.TextBox txtKisiSayisi;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private System.Windows.Forms.ComboBox cbMasaSec;
        private System.Windows.Forms.ComboBox cbKisiSayisi;
        private System.Windows.Forms.TextBox txtMasaNo;
        private System.Windows.Forms.TextBox txtMusteri;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvMusteriler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnYeniMusteri;
        private System.Windows.Forms.Button btnRezervasyonAc;
        private System.Windows.Forms.Button btnRezervasyonlar;
        private System.Windows.Forms.Button btnMusteriGuncelle;
        private System.Windows.Forms.Button btnMasaCikis;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.TextBox txtAciklama;
    }
}