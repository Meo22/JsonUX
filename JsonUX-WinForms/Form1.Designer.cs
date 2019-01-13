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
			this.SuspendLayout();
			// 
			// txtJsonInput
			// 
			this.txtJsonInput.Location = new System.Drawing.Point(12, 56);
			this.txtJsonInput.Multiline = true;
			this.txtJsonInput.Name = "txtJsonInput";
			this.txtJsonInput.Size = new System.Drawing.Size(400, 382);
			this.txtJsonInput.TabIndex = 0;
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(499, 56);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(400, 382);
			this.txtOutput.TabIndex = 1;
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(418, 223);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 23);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "Convert =>";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 450);
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
	}
}

