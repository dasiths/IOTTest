namespace IOTTest
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
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnCancelListening = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(25, 16);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(126, 29);
            this.btnAddDevice.TabIndex = 0;
            this.btnAddDevice.Text = "&Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(25, 81);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(78, 26);
            this.btnListen.TabIndex = 2;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(157, 16);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(439, 272);
            this.txtOutput.TabIndex = 3;
            // 
            // btnCancelListening
            // 
            this.btnCancelListening.Location = new System.Drawing.Point(25, 113);
            this.btnCancelListening.Name = "btnCancelListening";
            this.btnCancelListening.Size = new System.Drawing.Size(126, 27);
            this.btnCancelListening.TabIndex = 4;
            this.btnCancelListening.Text = "&Cancel Listening";
            this.btnCancelListening.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(25, 176);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(108, 27);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 300);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancelListening);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.btnAddDevice);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnCancelListening;
        private System.Windows.Forms.Button btnSend;
    }
}

