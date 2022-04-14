
using System;

namespace Debugger
{
    partial class SmLDebuggerFrameWindow
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
            this.lstCode = new System.Windows.Forms.ListBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblStack = new System.Windows.Forms.Label();
            this.lstStack = new System.Windows.Forms.ListBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst Code
            // 
            this.lstCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCode.FormattingEnabled = true;
            this.lstCode.ItemHeight = 15;
            this.lstCode.Location = new System.Drawing.Point(31, 56);
            this.lstCode.Name = "Instructions List";
            this.lstCode.Size = new System.Drawing.Size(321, 244);
            this.lstCode.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(32, 35);
            this.lblCode.Name = "Instructions List";
            this.lblCode.Size = new System.Drawing.Size(35, 15);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Instructions List";
            // 
            // Stack
            // 
            this.lblStack.AutoSize = true;
            this.lblStack.Location = new System.Drawing.Point(375, 35);
            this.lblStack.Name = "Stack List";
            this.lblStack.Size = new System.Drawing.Size(35, 15);
            this.lblStack.TabIndex = 4;
            this.lblStack.Text = "Stack List";
            // 
            // lstStack
            // 
            this.lstStack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStack.FormattingEnabled = true;
            this.lstStack.ItemHeight = 15;
            this.lstStack.Location = new System.Drawing.Point(375, 56);
            this.lstStack.Name = "Stack List";
            this.lstStack.Size = new System.Drawing.Size(321, 244);
            this.lstStack.TabIndex = 3;
            this.lstStack.SelectedIndexChanged += new System.EventHandler(this.lstStack_SelectedIndexChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.Location = new System.Drawing.Point(32, 382);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(664, 42);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // SmLDebuggerFrameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 524);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblStack);
            this.Controls.Add(this.lstStack);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lstCode);
            this.Name = "SmLDebuggerFrameWindow";
            this.Text = "SML Debugger";
            this.Load += new System.EventHandler(this.SmLDebuggerFrameWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lstStack_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            callback("ok");
        }

        #endregion

        public System.Windows.Forms.ListBox lstCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblStack;
        public System.Windows.Forms.ListBox lstStack;
        public System.Windows.Forms.Button btnContinue;

    }
}