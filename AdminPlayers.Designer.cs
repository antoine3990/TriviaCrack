namespace TriviaCrack
{
    partial class AdminPlayers
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
            this.LB_name = new System.Windows.Forms.Label();
            this.CB_players = new System.Windows.Forms.ComboBox();
            this.BT_modify = new System.Windows.Forms.Button();
            this.BT_delete = new System.Windows.Forms.Button();
            this.BT_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_name
            // 
            this.LB_name.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.LB_name.Location = new System.Drawing.Point(25, 81);
            this.LB_name.Name = "LB_name";
            this.LB_name.Size = new System.Drawing.Size(427, 55);
            this.LB_name.TabIndex = 120;
            this.LB_name.Text = "Nom du joueur";
            this.LB_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_players
            // 
            this.CB_players.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CB_players.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_players.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_players.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold);
            this.CB_players.ForeColor = System.Drawing.Color.White;
            this.CB_players.FormattingEnabled = true;
            this.CB_players.Location = new System.Drawing.Point(25, 149);
            this.CB_players.Name = "CB_players";
            this.CB_players.Size = new System.Drawing.Size(427, 67);
            this.CB_players.TabIndex = 118;
            // 
            // BT_modify
            // 
            this.BT_modify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_modify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_modify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_modify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BT_modify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_modify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BT_modify.Image = global::TriviaCrack.Properties.Resources.edit;
            this.BT_modify.Location = new System.Drawing.Point(209, 249);
            this.BT_modify.Name = "BT_modify";
            this.BT_modify.Size = new System.Drawing.Size(60, 60);
            this.BT_modify.TabIndex = 123;
            this.BT_modify.UseVisualStyleBackColor = true;
            this.BT_modify.Click += new System.EventHandler(this.BT_modify_Click);
            // 
            // BT_delete
            // 
            this.BT_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BT_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BT_delete.Image = global::TriviaCrack.Properties.Resources.delete;
            this.BT_delete.Location = new System.Drawing.Point(290, 249);
            this.BT_delete.Name = "BT_delete";
            this.BT_delete.Size = new System.Drawing.Size(60, 60);
            this.BT_delete.TabIndex = 122;
            this.BT_delete.UseVisualStyleBackColor = true;
            this.BT_delete.Click += new System.EventHandler(this.BT_delete_Click);
            // 
            // BT_add
            // 
            this.BT_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BT_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BT_add.Image = global::TriviaCrack.Properties.Resources.add;
            this.BT_add.Location = new System.Drawing.Point(138, 249);
            this.BT_add.Name = "BT_add";
            this.BT_add.Size = new System.Drawing.Size(60, 60);
            this.BT_add.TabIndex = 121;
            this.BT_add.UseVisualStyleBackColor = true;
            this.BT_add.Click += new System.EventHandler(this.BT_add_Click);
            // 
            // AdminPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(477, 337);
            this.Controls.Add(this.BT_modify);
            this.Controls.Add(this.BT_delete);
            this.Controls.Add(this.BT_add);
            this.Controls.Add(this.LB_name);
            this.Controls.Add(this.CB_players);
            this.Name = "AdminPlayers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Modification des joueurs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LB_name;
        private System.Windows.Forms.ComboBox CB_players;
        private System.Windows.Forms.Button BT_modify;
        private System.Windows.Forms.Button BT_delete;
        private System.Windows.Forms.Button BT_add;
    }
}