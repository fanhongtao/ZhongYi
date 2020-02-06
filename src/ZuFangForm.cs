/*
 * Created by SharpDevelop.
 * User: fhtao
 * Date: 2020/2/6
 * Time: 13:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZhongYi
{
	/// <summary>
	/// Description of ZuFangForm.
	/// </summary>
	public partial class ZuFangForm : Form
	{
		private const int TITLE_SIZE = 30;
		private const int TEXT_SIZE = 20;
		
		public ZuFangForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			nameFilter.queryNames = Data.Instance.queryZhongyaoName;
			nameFilter.NameSelected += NameSelected;
		}
		
		void NameSelected(object sender, Filter.NameEventArgs e)
		{
			addZhongYao(e.NamnInfo.Name);
		}
		
		/// <summary>
		/// 添加一味中药
		/// </summary>
		/// <param name="name"></param>
		private void addZhongYao(string name)
		{
			ZhongYaoInfo info = Data.Instance.getZhongYao(name);
			if (info == null) {
				Logger.error("没有收录 [" + name + "]");
			} else {
				show(info.name, TEXT_SIZE);
				outputText.AppendText("\n");
			}
		}
		
		private void show(string text, int size)
		{
			int start = outputText.Text.Length;
			outputText.AppendText(text);
			outputText.Select(start, outputText.Text.Length - start);
			outputText.SelectionFont = new Font("宋体", size); 
		}
	}
}
