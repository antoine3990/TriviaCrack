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
            this.BT_modifyQuestion = new System.Windows.Forms.Button();
            this.BT_deleteQuestion = new System.Windows.Forms.Button();
            this.BT_addQuestion = new System.Windows.Forms.Button();
            this.LB_categories = new System.Windows.Forms.ListBox();
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
            // BT_modifyQuestion
            // 
            this.BT_modifyQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_modifyQuestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_modifyQuestion.Enabled = false;
            this.BT_modifyQuestion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_modifyQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BT_modifyQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_modifyQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_modifyQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BT_modifyQuestion.Image = global::TriviaCrack.Properties.Resources.edit;
            this.BT_modifyQuestion.Location = new System.Drawing.Point(479, 16);
            this.BT_modifyQuestion.Name = "BT_modifyQuestion";
            this.BT_modifyQuestion.Size = new System.Drawing.Size(60, 60);
            this.BT_modifyQuestion.TabIndex = 6;
            this.BT_modifyQuestion.UseVisualStyleBackColor = true;
            // 
            // BT_deleteQuestion
            // 
            this.BT_deleteQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_deleteQuestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_deleteQuestion.Enabled = false;
            this.BT_deleteQuestion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_deleteQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BT_deleteQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_deleteQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_deleteQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BT_deleteQuestion.Image = global::TriviaCrack.Properties.Resources.delete;
            this.BT_deleteQuestion.Location = new System.Drawing.Point(550, 16);
            this.BT_deleteQuestion.Name = "BT_deleteQuestion";
            this.BT_deleteQuestion.Size = new System.Drawing.Size(60, 60);
            this.BT_deleteQuestion.TabIndex = 5;
            this.BT_deleteQuestion.UseVisualStyleBackColor = true;
            // 
            // BT_addQuestion
            // 
            this.BT_addQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BT_addQuestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_addQuestion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BT_addQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BT_addQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BT_addQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_addQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BT_addQuestion.Image = global::TriviaCrack.Properties.Resources.add;
            this.BT_addQuestion.Location = new System.Drawing.Point(408, 16);
            this.BT_addQuestion.Name = "BT_addQuestion";
            this.BT_addQuestion.Size = new System.Drawing.Size(60, 60);
            this.BT_addQuestion.TabIndex = 4;
            this.BT_addQuestion.UseVisualStyleBackColor = true;
            // 
            // LB_categories
            // 
            this.LB_categories.BackColor = System.Drawing.Color.White;
            this.LB_categories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LB_categories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_categories.ForeColor = System.Drawing.Color.Black;
            this.LB_categories.FormattingEnabled = true;
            this.LB_categories.ItemHeight = 20;
            this.LB_categories.Items.AddRange(new object[] {
            "Art",
            "Divertissement",
            "Géographie",
            "Histoire",
            "Science",
            "Sport"});
            this.LB_categories.Location = new System.Drawing.Point(12, 91);
            this.LB_categories.Name = "LB_categories";
            this.LB_categories.Size = new System.Drawing.Size(126, 280);
            this.LB_categories.TabIndex = 9;
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
            this.Controls.Add(this.BT_modifyQuestion);
            this.Controls.Add(this.BT_deleteQuestion);
            this.Controls.Add(this.BT_addQuestion);
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
        private System.Windows.Forms.Button BT_addQuestion;
        private System.Windows.Forms.Button BT_deleteQuestion;
        private System.Windows.Forms.Button BT_modifyQuestion;
        private System.Windows.Forms.DataGridView DGV_questions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LB_categories;
    }
}