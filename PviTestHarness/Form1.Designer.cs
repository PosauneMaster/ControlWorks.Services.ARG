﻿namespace PviTestHarness
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnTestCoilInfo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTestEuropean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTestCoilInfo
            // 
            this.btnTestCoilInfo.Location = new System.Drawing.Point(12, 140);
            this.btnTestCoilInfo.Name = "btnTestCoilInfo";
            this.btnTestCoilInfo.Size = new System.Drawing.Size(260, 23);
            this.btnTestCoilInfo.TabIndex = 1;
            this.btnTestCoilInfo.Text = "TestCoilInfo";
            this.btnTestCoilInfo.UseVisualStyleBackColor = true;
            this.btnTestCoilInfo.Click += new System.EventHandler(this.btnTestCoilInfo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Test American Label";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTestEuropean
            // 
            this.btnTestEuropean.Location = new System.Drawing.Point(12, 38);
            this.btnTestEuropean.Name = "btnTestEuropean";
            this.btnTestEuropean.Size = new System.Drawing.Size(260, 23);
            this.btnTestEuropean.TabIndex = 3;
            this.btnTestEuropean.Text = "Test European Label";
            this.btnTestEuropean.UseVisualStyleBackColor = true;
            this.btnTestEuropean.Click += new System.EventHandler(this.btnTestEuropean_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnTestEuropean);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTestCoilInfo);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTestCoilInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTestEuropean;
    }
}

