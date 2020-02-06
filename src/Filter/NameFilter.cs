/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2020/2/5
 * Time: 13:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZhongYi.Filter
{
	/// <summary>
	/// 根据名称（汉字）或对应的拼音（全拼或缩写）来选择条目的控件
	/// </summary>
	public partial class NameFilter : UserControl
	{
		NameListForm listForm;
		ListBox queryListBox;
		
		#region Hint
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern Int32 SendMessage(IntPtr hWnd, int msg,
			int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
		
		private string _hint;
		
		[Description("文本框中的提示信息。")]
		public string Hint
		{
			get { return _hint; }
			set
			{
				_hint = value;
				SendMessage(inputTextBox.Handle, 0x1501, 0, _hint);
			}
		}
		#endregion
		
		public NameFilter()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			inputTextBox.TextChanged += new EventHandler(inputTextBox_TextChanged);
			inputTextBox.KeyDown += new KeyEventHandler(inputTextBox_KeyDown);
			inputTextBox.LostFocus += new EventHandler(inputTextBox_LostFocus);
			
			listForm = new NameListForm();
			queryListBox = listForm.QueryListBox;
			queryListBox.MouseClick += new MouseEventHandler(queryListBox_MouseClick);
		}
		
		void inputTextBox_LostFocus(object sender, EventArgs e)
		{
			// 在输入过程中，如果 TextBox 失去焦点（焦点会跑到 ListBox 上），
			// 需要重新让 TextBox 获取焦点，以实现连续输入。
			if (listForm.Visible) {
				inputTextBox.Focus();
			}
		}
		
		void inputTextBox_TextChanged(object sender, EventArgs e)
		{
			if (inputTextBox.Text.Length == 0) {
				// NameSelected(sender, new NameEventArgs(NameInfo.Empty));
				listForm.Hide();
				return;
			}
			
			if (!listForm.Visible) {
				listForm.Font = this.Font;
				listForm.Width = inputTextBox.Width;
				listForm.Show(inputTextBox);
			}
			
			queryListBox.Items.Clear();
			queryListBox.Items.AddRange(query(inputTextBox.Text).ToArray());
			if (queryListBox.Items.Count > 0) {
				queryListBox.SelectedIndex = 0;
			}
		}
		
		void inputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (!listForm.Visible) {
				return;
			}
			
			if (e.KeyCode == Keys.Up) {
				e.Handled = true;
				if (queryListBox.SelectedIndex > 0) {
					queryListBox.SelectedIndex -= 1;
				}
			} else if (e.KeyCode == Keys.Down) {
				e.Handled = true;
				if (queryListBox.SelectedIndex < queryListBox.Items.Count - 1) {
					queryListBox.SelectedIndex += 1;
				}
			} else if (e.KeyCode == Keys.Enter) {
				if (queryListBox.SelectedIndex != -1) {
					listBox_Selected(sender, queryListBox);
				}
			}
		}
		
		void queryListBox_MouseClick(object sender, MouseEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			int index = listBox.IndexFromPoint(e.X, e.Y);
			if (index != -1) {
				listBox.SelectedIndex = index;
				listBox_Selected(sender, listBox);
			}
		}
		
		//定义委托
		public delegate void NameSelectedHandler(object sender, NameEventArgs e);
		
		public event NameSelectedHandler NameSelected;
		
		void listBox_Selected(object sender, ListBox listbox)
		{
			if (NameSelected != null) {
				NameInfo info = (NameInfo)listbox.SelectedItem;
				NameSelected(sender, new NameEventArgs(info));
			}
			
			listForm.Hide();
		}
		
		// 查询的委托
		// 根据输入的字符串（汉字 或 拼音），查询满足条件的名字列表
		public delegate List<NameInfo> QueryNames(string input);
		
		public QueryNames queryNames;
		
		private List<NameInfo> query(string input)
		{
			List<NameInfo> list;
			if (queryNames == null) {
				list = new List<NameInfo>();
			} else {
				list = queryNames(input);
			}
			return list;
		}
	}
}