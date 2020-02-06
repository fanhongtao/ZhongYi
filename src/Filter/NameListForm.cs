/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2020/2/5
 * Time: 20:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using AhDung.WinForm.Controls;

namespace ZhongYi.Filter
{
	/// <summary>
	/// Description of NameListForm.
	/// </summary>
	public partial class NameListForm : FloatLayerBase
	{
		public NameListForm()
		{
			InitializeComponent();
			
			this.Movable = false;
		}
		
		public ListBox QueryListBox
		{
			get { return queryListBox; }
		}
	}
}
