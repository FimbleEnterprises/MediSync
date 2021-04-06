namespace MediSync {
	partial class Form_AdditionalTools {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btn_Done = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_ChangeDefaultDashboards = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Done
			// 
			this.btn_Done.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Done.Location = new System.Drawing.Point(12, 334);
			this.btn_Done.Name = "btn_Done";
			this.btn_Done.Size = new System.Drawing.Size(288, 45);
			this.btn_Done.TabIndex = 1;
			this.btn_Done.Text = "Done";
			this.btn_Done.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btn_ChangeDefaultDashboards);
			this.groupBox1.Location = new System.Drawing.Point(12, -3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(288, 331);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// btn_ChangeDefaultDashboards
			// 
			this.btn_ChangeDefaultDashboards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_ChangeDefaultDashboards.Location = new System.Drawing.Point(6, 12);
			this.btn_ChangeDefaultDashboards.Name = "btn_ChangeDefaultDashboards";
			this.btn_ChangeDefaultDashboards.Size = new System.Drawing.Size(276, 45);
			this.btn_ChangeDefaultDashboards.TabIndex = 1;
			this.btn_ChangeDefaultDashboards.Text = "Change Default Dashboards";
			this.btn_ChangeDefaultDashboards.UseVisualStyleBackColor = true;
			this.btn_ChangeDefaultDashboards.Click += new System.EventHandler(this.btn_ChangeDefaultDashboards_Click);
			// 
			// Form_AdditionalTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(312, 391);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_Done);
			this.Name = "Form_AdditionalTools";
			this.Text = "Additional Tools";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_Done;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_ChangeDefaultDashboards;
	}
}