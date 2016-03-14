namespace TriviaCrack
{
    partial class Admin
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
            this.DGV_questions = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_categories = new System.Windows.Forms.ListBox();
            this.BT_modify = new System.Windows.Forms.Button();
            this.BT_delete = new System.Windows.Forms.Button();
            this.BT_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_questions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Catégories";
            // 
            // DGV_questions
            // 
            this.DGV_questions.AllowUserToResizeColumns = false;
            this.DGV_questions.AllowUserToResizeRows = false;
            this.DGV_questions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_questions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_questions.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_questions.Location = new System.Drawing.Point(153, 91);
            this.DGV_questions.MultiSelect = false;
            this.DGV_questions.Name = "DGV_questions";
            this.DGV_questions.ReadOnly = true;
            this.DGV_questions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_questions.Size = new System.Drawing.Size(457, 280);
            this.DGV_questions.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(149, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Questions";
            // 
            // LB_categories
            // 
            this.LB_categories.BackColor = System.Drawing.Color.White;
            this.LB_categories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LB_categories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_categories.ForeColor = System.Drawing.Color.Black;
            this.LB_categories.FormattingEnabled = true;
            this.LB_categories.ItemHeight = 20;
            this.LB_categories.Location = new System.Drawing.Point(12, 91);
            this.LB_categories.Name = "LB_categories";
            this.LB_categories.Size = new System.Drawing.Size(126, 280);
            this.LB_categories.TabIndex = 9;
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
            this.BT_modify.Location = new System.Drawing.Point(479, 16);
            this.BT_modify.Name = "BT_modify";
            this.BT_modify.Size = new System.Drawing.Size(60, 60);
            this.BT_modify.TabIndex = 6;
            this.BT_modify.UseVisualStyleBackColor = true;
            this.BT_modify.Click += new System.EventHandler(this.BT_addMod_Click);
            // 
            // BT_delete
            // 
            this.BT_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_delete.Enabled = false;
            this.BT_delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BT_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BT_delete.Image = global::TriviaCrack.Properties.Resources.delete;
            this.BT_delete.Location = new System.Drawing.Point(550, 16);
            this.BT_delete.Name = "BT_delete";
            this.BT_delete.Size = new System.Drawing.Size(60, 60);
            this.BT_delete.TabIndex = 5;
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
            this.BT_add.Location = new System.Drawing.Point(408, 16);
            this.BT_add.Name = "BT_add";
            this.BT_add.Size = new System.Drawing.Size(60, 60);
            this.BT_add.TabIndex = 4;
            this.BT_add.UseVisualStyleBackColor = true;
            this.BT_add.Click += new System.EventHandler(this.BT_addMod_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(624, 382);
            this.Controls.Add(this.LB_categories);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGV_questions);
            this.Controls.Add(this.BT_modify);
            this.Controls.Add(this.BT_delete);
            this.Controls.Add(this.BT_add);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(640, 421);
            this.MinimumSize = new System.Drawing.Size(640, 421);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Panneau d\'administrateurs";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_questions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_add;
        private System.Windows.Forms.Button BT_delete;
        private System.Windows.Forms.Button BT_modify;
        private System.Windows.Forms.DataGridView DGV_questions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LB_categories;
    }
}