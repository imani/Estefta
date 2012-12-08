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
            this.SuspendLayout();
            // 
            // txt_query
            // 
            this.txt_query.Location = new System.Drawing.Point(146, 26);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(246, 20);
            this.txt_query.TabIndex = 0;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(229, 63);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "بپرس";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_answer
            // 
            this.txt_answer.Location = new System.Drawing.Point(19, 139);
            this.txt_answer.Multiline = true;
            this.txt_answer.Name = "txt_answer";
            this.txt_answer.ReadOnly = true;
            this.txt_answer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_answer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_answer.Size = new System.Drawing.Size(498, 191);
            this.txt_answer.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 339);
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
    }
}

