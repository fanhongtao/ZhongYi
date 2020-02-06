/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2017/4/17
 * Time: 10:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ZhongYi
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			showForm(new ZhongYaoForm(), zhongyaoPage);
			showForm(new ZuFangForm(), zuFangPage);
			
			Logger.SetTextBox(logTextBox);
			Logger.info("Program start.");
			
			Data.Instance.Load();
		}
		
		void CleanLogButtonClick(object sender, System.EventArgs e)
		{
			Logger.clean();
		}
		
		// 在TabPage中显示对应的Form
		private void showForm(Form form, Control tabPage)
		{
			form.TopLevel = false;
			form.Parent = tabPage;
			form.ControlBox = false;
			form.Dock = System.Windows.Forms.DockStyle.Fill;
			form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			form.Show();
		}
	}
}
