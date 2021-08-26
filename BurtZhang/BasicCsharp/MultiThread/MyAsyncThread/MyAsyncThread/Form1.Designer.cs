
namespace MyAsyncThread
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
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAysnc = new System.Windows.Forms.Button();
            this.btnAsyncAdvanced = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(41, 73);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(130, 40);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAysnc
            // 
            this.btnAysnc.Location = new System.Drawing.Point(41, 138);
            this.btnAysnc.Name = "btnAysnc";
            this.btnAysnc.Size = new System.Drawing.Size(130, 37);
            this.btnAysnc.TabIndex = 1;
            this.btnAysnc.Text = "Async";
            this.btnAysnc.UseVisualStyleBackColor = true;
            this.btnAysnc.Click += new System.EventHandler(this.btnAysnc_Click);
            // 
            // btnAsyncAdvanced
            // 
            this.btnAsyncAdvanced.Location = new System.Drawing.Point(41, 197);
            this.btnAsyncAdvanced.Name = "btnAsyncAdvanced";
            this.btnAsyncAdvanced.Size = new System.Drawing.Size(130, 38);
            this.btnAsyncAdvanced.TabIndex = 2;
            this.btnAsyncAdvanced.Text = "Aynsc Advance";
            this.btnAsyncAdvanced.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced.Click += new System.EventHandler(this.btnAsyncAdvanced_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAsyncAdvanced);
            this.Controls.Add(this.btnAysnc);
            this.Controls.Add(this.btnSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAysnc;
        private System.Windows.Forms.Button btnAsyncAdvanced;
    }
}

