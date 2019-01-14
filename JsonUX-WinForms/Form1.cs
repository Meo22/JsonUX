using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonUX_WinForms
{
	public partial class Form1 : Form
	{
		static readonly string SamplesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples");

		static IList<string> GetSamples()
		{
			return Directory.GetFiles(SamplesPath).Select(f => Path.GetFileName(f)).ToList();
		}

		static string LoadFile(string file)
		{
			return File.ReadAllText(Path.Combine(SamplesPath, file));
		}

		public Form1()
		{
			InitializeComponent();

			ddlFiles.DataSource = GetSamples();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			txtJsonInput.Text = LoadFile(ddlFiles.SelectedValue.ToString());
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			try
			{
				var dic = JsonUX.Json.Parse.ParseExtended(txtJsonInput.Text);

				txtOutput.Text = string.Join(Environment.NewLine, dic);
			}
			catch(Exception ex)
			{
				txtOutput.Text = $"Error:{Environment.NewLine}{ex.Message}";
			}
		}

		private void ddlFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtJsonInput.Text = LoadFile(ddlFiles.SelectedValue.ToString());
		}
	}
}
