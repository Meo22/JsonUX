namespace JsonUX_WinForms
{
	partial class Form1
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtJsonInput = new System.Windows.Forms.TextBox();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnConvert = new System.Windows.Forms.Button();
			this.ddlFiles = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// txtJsonInput
			// 
			this.txtJsonInput.Location = new System.Drawing.Point(12, 56);
			this.txtJsonInput.MaxLength = 65536;
			this.txtJsonInput.Multiline = true;
			this.txtJsonInput.Name = "txtJsonInput";
			this.txtJsonInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtJsonInput.Size = new System.Drawing.Size(542, 532);
			this.txtJsonInput.TabIndex = 0;
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(641, 56);
			this.txtOutput.MaxLength = 65536;
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(542, 532);
			this.txtOutput.TabIndex = 1;
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(560, 288);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 23);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "Convert =>";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// ddlFiles
			// 
			this.ddlFiles.FormattingEnabled = true;
			this.ddlFiles.Location = new System.Drawing.Point(13, 29);
			this.ddlFiles.Name = "ddlFiles";
			this.ddlFiles.Size = new System.Drawing.Size(541, 21);
			this.ddlFiles.TabIndex = 3;
			this.ddlFiles.SelectedIndexChanged += new System.EventHandler(this.ddlFiles_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1198, 602);
			this.Controls.Add(this.ddlFiles);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.txtJsonInput);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtJsonInput;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.ComboBox ddlFiles;
	}
}

