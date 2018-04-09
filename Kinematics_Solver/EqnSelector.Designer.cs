namespace Kinematics_Solver
{
    partial class EqnSelector
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
            this.LocationTimeBtn = new System.Windows.Forms.Button();
            this.VelocitySquaredBtn = new System.Windows.Forms.Button();
            this.VelocityTimeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LocationTimeBtn
            // 
            this.LocationTimeBtn.Location = new System.Drawing.Point(12, 12);
            this.LocationTimeBtn.Name = "LocationTimeBtn";
            this.LocationTimeBtn.Size = new System.Drawing.Size(300, 30);
            this.LocationTimeBtn.TabIndex = 0;
            this.LocationTimeBtn.Text = "X(t) = X0 + V0(T-T0)+A/2*(T-T0)^2";
            this.LocationTimeBtn.UseVisualStyleBackColor = true;
            this.LocationTimeBtn.Click += new System.EventHandler(this.LocationTimeBtn_Click);
            // 
            // VelocitySquaredBtn
            // 
            this.VelocitySquaredBtn.Location = new System.Drawing.Point(12, 57);
            this.VelocitySquaredBtn.Name = "VelocitySquaredBtn";
            this.VelocitySquaredBtn.Size = new System.Drawing.Size(300, 30);
            this.VelocitySquaredBtn.TabIndex = 1;
            this.VelocitySquaredBtn.Text = "V^2 = V0^2 +2*A*(X-X0)";
            this.VelocitySquaredBtn.UseVisualStyleBackColor = true;
            this.VelocitySquaredBtn.Click += new System.EventHandler(this.VelocitySquaredBtn_Click);
            // 
            // VelocityTimeBtn
            // 
            this.VelocityTimeBtn.Location = new System.Drawing.Point(12, 104);
            this.VelocityTimeBtn.Name = "VelocityTimeBtn";
            this.VelocityTimeBtn.Size = new System.Drawing.Size(300, 30);
            this.VelocityTimeBtn.TabIndex = 2;
            this.VelocityTimeBtn.Text = "V(t) = V +A*(T-T0)";
            this.VelocityTimeBtn.UseVisualStyleBackColor = true;
            this.VelocityTimeBtn.Click += new System.EventHandler(this.VelocityTimeBtn_Click);
            // 
            // EqnSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.VelocityTimeBtn);
            this.Controls.Add(this.VelocitySquaredBtn);
            this.Controls.Add(this.LocationTimeBtn);
            this.Name = "EqnSelector";
            this.Text = "Selection";
            this.Load += new System.EventHandler(this.EqnSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LocationTimeBtn;
        private System.Windows.Forms.Button VelocitySquaredBtn;
        private System.Windows.Forms.Button VelocityTimeBtn;
    }
}