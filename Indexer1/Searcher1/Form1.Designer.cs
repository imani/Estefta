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
            this.trv_categories = new System.Windows.Forms.TreeView();
            this.lbl_categories = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_query
            // 
            this.txt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_query.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_query.Location = new System.Drawing.Point(120, 30);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(441, 32);
            this.txt_query.TabIndex = 0;
            this.txt_query.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_search.Location = new System.Drawing.Point(19, 30);
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
            this.txt_answer.Location = new System.Drawing.Point(19, 85);
            this.txt_answer.Multiline = true;
            this.txt_answer.Name = "txt_answer";
            this.txt_answer.ReadOnly = true;
            this.txt_answer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_answer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_answer.Size = new System.Drawing.Size(542, 440);
            this.txt_answer.TabIndex = 2;
            this.txt_answer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // trv_categories
            // 
            this.trv_categories.BackColor = System.Drawing.SystemColors.Menu;
            this.trv_categories.CheckBoxes = true;
            this.trv_categories.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.trv_categories.Location = new System.Drawing.Point(571, 58);
            this.trv_categories.Name = "trv_categories";
            this.trv_categories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trv_categories.RightToLeftLayout = true;
            this.trv_categories.Size = new System.Drawing.Size(210, 467);
            this.trv_categories.TabIndex = 7;
            this.trv_categories.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trv_categories_AfterCheck);
            // 
            // lbl_categories
            // 
            this.lbl_categories.AutoSize = true;
            this.lbl_categories.Font = new System.Drawing.Font("B Yekan", 11.25F);
            this.lbl_categories.Location = new System.Drawing.Point(708, 30);
            this.lbl_categories.Name = "lbl_categories";
            this.lbl_categories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_categories.Size = new System.Drawing.Size(67, 23);
            this.lbl_categories.TabIndex = 8;
            this.lbl_categories.Text = "موضوعات:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 543);
            this.Controls.Add(this.lbl_categories);
            this.Controls.Add(this.trv_categories);
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
        private System.Windows.Forms.TreeView trv_categories;
        private System.Windows.Forms.Label lbl_categories;
    }
}

