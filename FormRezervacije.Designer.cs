namespace ProjekatProba
{
    partial class FormRezervacije
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
            this.cbMarka = new System.Windows.Forms.ComboBox();
            this.cbKubikaza = new System.Windows.Forms.ComboBox();
            this.cbGorivo = new System.Windows.Forms.ComboBox();
            this.cbPogon = new System.Windows.Forms.ComboBox();
            this.cbKaroserija = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMenjac = new System.Windows.Forms.ComboBox();
            this.cbBrojVrata = new System.Windows.Forms.ComboBox();
            this.cbGodiste = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrikaziPonude = new System.Windows.Forms.Button();
            this.lbPonude = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dpPreuzimanje = new System.Windows.Forms.DateTimePicker();
            this.dpVracanje = new System.Windows.Forms.DateTimePicker();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberi marku:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odaberi kubikazu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(572, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Odaberi gorivo:";
            // 
            // cbMarka
            // 
            this.cbMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMarka.FormattingEnabled = true;
            this.cbMarka.Location = new System.Drawing.Point(49, 37);
            this.cbMarka.Name = "cbMarka";
            this.cbMarka.Size = new System.Drawing.Size(175, 23);
            this.cbMarka.TabIndex = 3;
            this.cbMarka.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // cbKubikaza
            // 
            this.cbKubikaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKubikaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKubikaza.FormattingEnabled = true;
            this.cbKubikaza.Location = new System.Drawing.Point(309, 37);
            this.cbKubikaza.Name = "cbKubikaza";
            this.cbKubikaza.Size = new System.Drawing.Size(175, 23);
            this.cbKubikaza.TabIndex = 4;
            this.cbKubikaza.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // cbGorivo
            // 
            this.cbGorivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGorivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGorivo.FormattingEnabled = true;
            this.cbGorivo.Location = new System.Drawing.Point(575, 37);
            this.cbGorivo.Name = "cbGorivo";
            this.cbGorivo.Size = new System.Drawing.Size(175, 23);
            this.cbGorivo.TabIndex = 5;
            this.cbGorivo.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // cbPogon
            // 
            this.cbPogon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPogon.FormattingEnabled = true;
            this.cbPogon.Location = new System.Drawing.Point(575, 88);
            this.cbPogon.Name = "cbPogon";
            this.cbPogon.Size = new System.Drawing.Size(175, 23);
            this.cbPogon.TabIndex = 11;
            this.cbPogon.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // cbKaroserija
            // 
            this.cbKaroserija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKaroserija.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKaroserija.FormattingEnabled = true;
            this.cbKaroserija.Location = new System.Drawing.Point(309, 88);
            this.cbKaroserija.Name = "cbKaroserija";
            this.cbKaroserija.Size = new System.Drawing.Size(175, 23);
            this.cbKaroserija.TabIndex = 10;
            this.cbKaroserija.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(49, 88);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(175, 23);
            this.cbModel.TabIndex = 9;
            this.cbModel.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(572, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Odaberi pogon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(306, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Odaberi karoseriju:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Odaberi model:";
            // 
            // cbMenjac
            // 
            this.cbMenjac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMenjac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMenjac.FormattingEnabled = true;
            this.cbMenjac.Location = new System.Drawing.Point(575, 141);
            this.cbMenjac.Name = "cbMenjac";
            this.cbMenjac.Size = new System.Drawing.Size(175, 23);
            this.cbMenjac.TabIndex = 17;
            this.cbMenjac.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // cbBrojVrata
            // 
            this.cbBrojVrata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrojVrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBrojVrata.FormattingEnabled = true;
            this.cbBrojVrata.Location = new System.Drawing.Point(309, 141);
            this.cbBrojVrata.Name = "cbBrojVrata";
            this.cbBrojVrata.Size = new System.Drawing.Size(175, 23);
            this.cbBrojVrata.TabIndex = 16;
            this.cbBrojVrata.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // cbGodiste
            // 
            this.cbGodiste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGodiste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGodiste.FormattingEnabled = true;
            this.cbGodiste.Location = new System.Drawing.Point(49, 141);
            this.cbGodiste.Name = "cbGodiste";
            this.cbGodiste.Size = new System.Drawing.Size(175, 23);
            this.cbGodiste.TabIndex = 15;
            this.cbGodiste.SelectionChangeCommitted += new System.EventHandler(this.NoviOdabir);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(572, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Odaberi menjac";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(306, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Odaberi broj vrata:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Odaberi godiste:";
            // 
            // btnPrikaziPonude
            // 
            this.btnPrikaziPonude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrikaziPonude.Location = new System.Drawing.Point(49, 182);
            this.btnPrikaziPonude.Name = "btnPrikaziPonude";
            this.btnPrikaziPonude.Size = new System.Drawing.Size(701, 38);
            this.btnPrikaziPonude.TabIndex = 18;
            this.btnPrikaziPonude.Text = "Prikazi dostupne termine odabranog automobila:";
            this.btnPrikaziPonude.UseVisualStyleBackColor = true;
            this.btnPrikaziPonude.Click += new System.EventHandler(this.btnPrikaziPonude_Click);
            // 
            // lbPonude
            // 
            this.lbPonude.FormattingEnabled = true;
            this.lbPonude.Location = new System.Drawing.Point(49, 226);
            this.lbPonude.Name = "lbPonude";
            this.lbPonude.Size = new System.Drawing.Size(701, 238);
            this.lbPonude.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(46, 469);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 18);
            this.label10.TabIndex = 20;
            this.label10.Text = "Odaberite datum preuzimanja";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(46, 526);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 18);
            this.label11.TabIndex = 21;
            this.label11.Text = "Odaberite datum vracanja:";
            // 
            // dpPreuzimanje
            // 
            this.dpPreuzimanje.Location = new System.Drawing.Point(49, 495);
            this.dpPreuzimanje.Name = "dpPreuzimanje";
            this.dpPreuzimanje.Size = new System.Drawing.Size(200, 20);
            this.dpPreuzimanje.TabIndex = 22;
            this.dpPreuzimanje.ValueChanged += new System.EventHandler(this.dpPreuzimanje_ValueChanged);
            // 
            // dpVracanje
            // 
            this.dpVracanje.Location = new System.Drawing.Point(49, 553);
            this.dpVracanje.Name = "dpVracanje";
            this.dpVracanje.Size = new System.Drawing.Size(200, 20);
            this.dpVracanje.TabIndex = 23;
            this.dpVracanje.ValueChanged += new System.EventHandler(this.dpVracanje_ValueChanged);
            // 
            // txtCena
            // 
            this.txtCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCena.Location = new System.Drawing.Point(536, 469);
            this.txtCena.Name = "txtCena";
            this.txtCena.ReadOnly = true;
            this.txtCena.Size = new System.Drawing.Size(214, 26);
            this.txtCena.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(332, 468);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 18);
            this.label12.TabIndex = 25;
            this.label12.Text = "Ukupna cena rezervacije:";
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervisi.Location = new System.Drawing.Point(335, 509);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(195, 53);
            this.btnRezervisi.TabIndex = 26;
            this.btnRezervisi.Text = "Rezervisi";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(555, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 53);
            this.button1.TabIndex = 27;
            this.button1.Text = " Vrati se nazad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.dpVracanje);
            this.Controls.Add(this.dpPreuzimanje);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbPonude);
            this.Controls.Add(this.btnPrikaziPonude);
            this.Controls.Add(this.cbMenjac);
            this.Controls.Add(this.cbBrojVrata);
            this.Controls.Add(this.cbGodiste);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbPogon);
            this.Controls.Add(this.cbKaroserija);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbGorivo);
            this.Controls.Add(this.cbKubikaza);
            this.Controls.Add(this.cbMarka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRezervacije";
            this.Text = "FormRezervacije";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMarka;
        private System.Windows.Forms.ComboBox cbKubikaza;
        private System.Windows.Forms.ComboBox cbGorivo;
        private System.Windows.Forms.ComboBox cbPogon;
        private System.Windows.Forms.ComboBox cbKaroserija;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMenjac;
        private System.Windows.Forms.ComboBox cbBrojVrata;
        private System.Windows.Forms.ComboBox cbGodiste;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPrikaziPonude;
        private System.Windows.Forms.ListBox lbPonude;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dpPreuzimanje;
        private System.Windows.Forms.DateTimePicker dpVracanje;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRezervisi;
        private System.Windows.Forms.Button button1;
    }
}