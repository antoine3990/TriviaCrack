namespace TriviaCrack
{
    partial class AddModPlayers
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
            this.TB_name = new System.Windows.Forms.TextBox();
            this.LB_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_admin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.CB_science = new System.Windows.Forms.ComboBox();
            this.CB_divertissement = new System.Windows.Forms.ComboBox();
            this.CB_geographie = new System.Windows.Forms.ComboBox();
            this.CB_histoire = new System.Windows.Forms.ComboBox();
            this.CB_sport = new System.Windows.Forms.ComboBox();
            this.CB_art = new System.Windows.Forms.ComboBox();
            this.BT_accept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_name
            // 
            this.TB_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TB_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_name.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.TB_name.Location = new System.Drawing.Point(15, 101);
            this.TB_name.Name = "TB_name";
            this.TB_name.Size = new System.Drawing.Size(330, 33);
            this.TB_name.TabIndex = 1;
            // 
            // LB_title
            // 
            this.LB_title.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LB_title.Location = new System.Drawing.Point(0, 0);
            this.LB_title.Name = "LB_title";
            this.LB_title.Size = new System.Drawing.Size(435, 80);
            this.LB_title.TabIndex = 125;
            this.LB_title.Text = "Ajout d\'un joueur";
            this.LB_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 23);
            this.label1.TabIndex = 126;
            this.label1.Text = "Nom";
            // 
            // BT_admin
            // 
            this.BT_admin.BackgroundImage = global::TriviaCrack.Properties.Resources.incorrect;
            this.BT_admin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_admin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BT_admin.FlatAppearance.BorderSize = 0;
            this.BT_admin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_admin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_admin.Location = new System.Drawing.Point(351, 101);
            this.BT_admin.Name = "BT_admin";
            this.BT_admin.Size = new System.Drawing.Size(72, 33);
            this.BT_admin.TabIndex = 127;
            this.BT_admin.Tag = "no";
            this.BT_admin.UseVisualStyleBackColor = true;
            this.BT_admin.Click += new System.EventHandler(this.BT_admin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(357, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 128;
            this.label2.Text = "Admin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 129;
            this.label3.Text = "Points";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TriviaCrack.Properties.Resources.science_small;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(32, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 27);
            this.pictureBox1.TabIndex = 130;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TriviaCrack.Properties.Resources.histoire_small;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(236, 180);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 27);
            this.pictureBox2.TabIndex = 131;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::TriviaCrack.Properties.Resources.divertissement_small;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(100, 180);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 27);
            this.pictureBox3.TabIndex = 132;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::TriviaCrack.Properties.Resources.sport_small;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(304, 180);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 27);
            this.pictureBox4.TabIndex = 133;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::TriviaCrack.Properties.Resources.geographie_small;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Location = new System.Drawing.Point(168, 180);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(27, 27);
            this.pictureBox5.TabIndex = 134;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::TriviaCrack.Properties.Resources.art_small;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Location = new System.Drawing.Point(372, 180);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(27, 27);
            this.pictureBox6.TabIndex = 135;
            this.pictureBox6.TabStop = false;
            // 
            // CB_science
            // 
            this.CB_science.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CB_science.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_science.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_science.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_science.ForeColor = System.Drawing.Color.White;
            this.CB_science.FormattingEnabled = true;
            this.CB_science.Location = new System.Drawing.Point(29, 213);
            this.CB_science.Name = "CB_science";
            this.CB_science.Size = new System.Drawing.Size(33, 27);
            this.CB_science.TabIndex = 136;
            // 
            // CB_divertissement
            // 
            this.CB_divertissement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CB_divertissement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_divertissement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_divertissement.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_divertissement.ForeColor = System.Drawing.Color.White;
            this.CB_divertissement.FormattingEnabled = true;
            this.CB_divertissement.Location = new System.Drawing.Point(97, 213);
            this.CB_divertissement.Name = "CB_divertissement";
            this.CB_divertissement.Size = new System.Drawing.Size(33, 27);
            this.CB_divertissement.TabIndex = 137;
            // 
            // CB_geographie
            // 
            this.CB_geographie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CB_geographie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_geographie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_geographie.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_geographie.ForeColor = System.Drawing.Color.White;
            this.CB_geographie.FormattingEnabled = true;
            this.CB_geographie.Location = new System.Drawing.Point(165, 213);
            this.CB_geographie.Name = "CB_geographie";
            this.CB_geographie.Size = new System.Drawing.Size(33, 27);
            this.CB_geographie.TabIndex = 138;
            // 
            // CB_histoire
            // 
            this.CB_histoire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CB_histoire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_histoire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_histoire.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_histoire.ForeColor = System.Drawing.Color.White;
            this.CB_histoire.FormattingEnabled = true;
            this.CB_histoire.Location = new System.Drawing.Point(233, 213);
            this.CB_histoire.Name = "CB_histoire";
            this.CB_histoire.Size = new System.Drawing.Size(33, 27);
            this.CB_histoire.TabIndex = 139;
            // 
            // CB_sport
            // 
            this.CB_sport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CB_sport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_sport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_sport.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_sport.ForeColor = System.Drawing.Color.White;
            this.CB_sport.FormattingEnabled = true;
            this.CB_sport.Location = new System.Drawing.Point(301, 213);
            this.CB_sport.Name = "CB_sport";
            this.CB_sport.Size = new System.Drawing.Size(33, 27);
            this.CB_sport.TabIndex = 140;
            // 
            // CB_art
            // 
            this.CB_art.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CB_art.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_art.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_art.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_art.ForeColor = System.Drawing.Color.White;
            this.CB_art.FormattingEnabled = true;
            this.CB_art.Location = new System.Drawing.Point(369, 213);
            this.CB_art.Name = "CB_art";
            this.CB_art.Size = new System.Drawing.Size(33, 27);
            this.CB_art.TabIndex = 141;
            // 
            // BT_accept
            // 
            this.BT_accept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_accept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.BT_accept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BT_accept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.BT_accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_accept.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_accept.ForeColor = System.Drawing.Color.White;
            this.BT_accept.Location = new System.Drawing.Point(15, 257);
            this.BT_accept.Name = "BT_accept";
            this.BT_accept.Size = new System.Drawing.Size(402, 53);
            this.BT_accept.TabIndex = 142;
            this.BT_accept.Text = "Ajouter";
            this.BT_accept.UseVisualStyleBackColor = true;
            this.BT_accept.Click += new System.EventHandler(this.BT_accept_Click);
            // 
            // AddModPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(435, 324);
            this.Controls.Add(this.BT_accept);
            this.Controls.Add(this.CB_art);
            this.Controls.Add(this.CB_sport);
            this.Controls.Add(this.CB_histoire);
            this.Controls.Add(this.CB_geographie);
            this.Controls.Add(this.CB_divertissement);
            this.Controls.Add(this.CB_science);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BT_admin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_title);
            this.Controls.Add(this.TB_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddModPlayers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Ajouter un joueur";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_name;
        private System.Windows.Forms.Label LB_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_admin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ComboBox CB_science;
        private System.Windows.Forms.ComboBox CB_divertissement;
        private System.Windows.Forms.ComboBox CB_geographie;
        private System.Windows.Forms.ComboBox CB_histoire;
        private System.Windows.Forms.ComboBox CB_sport;
        private System.Windows.Forms.ComboBox CB_art;
        private System.Windows.Forms.Button BT_accept;
    }
}