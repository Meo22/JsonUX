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
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			txtJsonInput.Text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "samples", "deployment-variables-simple.json"));
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			var dic = JsonUX.Json.Parse.ParseSimple(txtJsonInput.Text);

			txtOutput.Text = string.Join(Environment.NewLine, dic.Select(x => x.Key + "=" + x.Value).ToArray());
		}
	}
}
