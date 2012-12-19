namespace Searcher1
{
    partial class Form1
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
            this.txt_query = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_answer = new System.Windows.Forms.TextBox();
            this.lbl_cat = new System.Windows.Forms.Label();
            this.lbl_subcat = new System.Windows.Forms.Label();
            this.cmb_cat = new System.Windows.Forms.ComboBox();
            this.cmb_subcat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_query
            // 
            this.txt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_query.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_query.Location = new System.Drawing.Point(120, 26);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(418, 32);
            this.txt_query.TabIndex = 0;
            this.txt_query.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_search.Location = new System.Drawing.Point(24, 26);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(90, 36);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "بپرس";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_answer
            // 
            this.txt_answer.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.txt_answer.Location = new System.Drawing.Point(19, 162);
            this.txt_answer.Multiline = true;
            this.txt_answer.Name = "txt_answer";
            this.txt_answer.ReadOnly = true;
            this.txt_answer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_answer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_answer.Size = new System.Drawing.Size(542, 325);
            this.txt_answer.TabIndex = 2;
            this.txt_answer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_cat
            // 
            this.lbl_cat.AutoSize = true;
            this.lbl_cat.Font = new System.Drawing.Font("B Yekan", 10F);
            this.lbl_cat.Location = new System.Drawing.Point(481, 85);
            this.lbl_cat.Name = "lbl_cat";
            this.lbl_cat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_cat.Size = new System.Drawing.Size(50, 21);
            this.lbl_cat.TabIndex = 3;
            this.lbl_cat.Text = "موضوع:";
            this.lbl_cat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_subcat
            // 
            this.lbl_subcat.AutoSize = true;
            this.lbl_subcat.Font = new System.Drawing.Font("B Yekan", 10F);
            this.lbl_subcat.Location = new System.Drawing.Point(461, 121);
            this.lbl_subcat.Name = "lbl_subcat";
            this.lbl_subcat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_subcat.Size = new System.Drawing.Size(70, 21);
            this.lbl_subcat.TabIndex = 4;
            this.lbl_subcat.Text = "زیر موضوع:";
            this.lbl_subcat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_cat
            // 
            this.cmb_cat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_cat.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.cmb_cat.FormattingEnabled = true;
            this.cmb_cat.Location = new System.Drawing.Point(120, 85);
            this.cmb_cat.Name = "cmb_cat";
            this.cmb_cat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_cat.Size = new System.Drawing.Size(355, 25);
            this.cmb_cat.TabIndex = 5;
            this.cmb_cat.SelectedIndexChanged += new System.EventHandler(this.cmb_cat_SelectedIndexChanged);
            // 
            // cmb_subcat
            // 
            this.cmb_subcat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_subcat.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.cmb_subcat.FormattingEnabled = true;
            this.cmb_subcat.Location = new System.Drawing.Point(120, 121);
            this.cmb_subcat.Name = "cmb_subcat";
            this.cmb_subcat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_subcat.Size = new System.Drawing.Size(335, 25);
            this.cmb_subcat.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 499);
            this.Controls.Add(this.cmb_subcat);
            this.Controls.Add(this.cmb_cat);
            this.Controls.Add(this.lbl_subcat);
            this.Controls.Add(this.lbl_cat);
            this.Controls.Add(this.txt_answer);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_query);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_query;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_answer;
        private System.Windows.Forms.Label lbl_cat;
        private System.Windows.Forms.Label lbl_subcat;
        private System.Windows.Forms.ComboBox cmb_cat;
        private System.Windows.Forms.ComboBox cmb_subcat;
    }
}

