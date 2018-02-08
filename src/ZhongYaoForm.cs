/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/2/6
 * Time: 14:01
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
	/// Description of ZhongYaoForm.
	/// </summary>
	public partial class ZhongYaoForm : Form
	{
		private const int TITLE_SIZE = 30;
		private const int TEXT_SIZE = 20;
		
		private bool hasHandler = false;
		private EventHandler textUpdateHandler;
		
		public ZhongYaoForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			textUpdateHandler = new EventHandler(inputComboBox_TextUpdate);
			addTextUpdateHandler();
			inputComboBox.DropDown += new EventHandler(inputComboBox_DropDown);
			inputComboBox.KeyDown += new KeyEventHandler(inputComboBox_KeyDown);
			inputComboBox.SelectedValueChanged += new EventHandler(inputComboBox_SelectedIndexChanged);
			queryListBox.DisplayMember = "name";
		}
		
		private void inputComboBox_DropDown(object sender, EventArgs e)
		{
			// 从 ComboBox 中选择已有的项时，不需要再次显示 ListBox 进行选择
			deleteTextUpdateHandler();
			
			// 当 ListBox 显示时，如果用鼠标按下 ComboBox 的下拉按钮，需要隐藏 ListBox
			queryListBox.Visible = false;
		}
		
		private void inputComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			inputCombox_Enter();
			
			// 考虑到 DropDown 中删除了 handler，在这里需要重新添加进去
			// 注意：不能在 DropDownClosed 中添加（太早了，等同于DropDown中没有删除）
			addTextUpdateHandler();
		}
		
		private void inputComboBox_TextUpdate(object sender, EventArgs e)
		{
			string text = inputComboBox.Text;
			
			// 当 ComboBox 下拉菜单显示时，如果收到 TextUpdate 事件，说明是下拉之后，在
			// 某些下拉项的基础上进行了修改。这时，显示 ListBox 更好一些。
			if (inputComboBox.DroppedDown) {
				// 关闭 ComboBox 下拉菜单
				inputComboBox.DroppedDown = false;
				
				// 重新设置 ComboBox 输入框中的文本
				// 如果不重新设置，测试时发现一些问题：
				// 1. 启动程序
				// 2. 输入“天”，并依次选择“天仙藤”、“天冬”、“天南星”、“天山雪莲”
				// 3. 在 ComboBox 下拉菜单中，将光标移动到 “天冬”上（此时 ComboBox 输入框显示“天冬”）
				// 4. 依次按键：方向键右键、Backspace
				// 期望结果：ComboBox 输入框显示“天” ，并根据“天”显示匹配的候选项。
				// 测试结果: 显示“天山雪莲”，但根据“天”显示匹配的候选项。 具体原因未知。
				inputComboBox.Text = text;
				inputComboBox.SelectionStart = inputComboBox.Text.Length;
			}
			
			if (text.Length == 0) {
				queryListBox.Visible = false;
				return;
			}
			
			if (! queryListBox.Visible) {
				if (queryListBox.Size.Width != inputComboBox.Size.Width) {
					queryListBox.Size = new Size(inputComboBox.Size.Width, 200);
				}
				queryListBox.Visible = true;
			}
			
			queryListBox.Items.Clear();
			List<ZhongYaoInfo> listQuery = Data.Instance.queryZhongYao(text);
			queryListBox.Items.AddRange(listQuery.ToArray());
			if (listQuery.Count > 0) {
				queryListBox.SelectedIndex = 0;
			}
		}
		
		private void inputComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			// Logger.info("inputComboBox_KeyDown " + e.KeyCode);
			if (queryListBox.Visible) {
				inputComboBox_KeyDown_ListBox(e);
			} else {
				inputComboBox_KeyDown_ComboBox(e);
			}
			
		}
		
		private void inputComboBox_KeyDown_ComboBox(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up) {
				// 用于实现通过上下键直接从 ComboBox 历史中选择要显示的内容。此时不需要候选项
				deleteTextUpdateHandler();
			} else if (e.KeyCode == Keys.Down) {
				deleteTextUpdateHandler();
			} else if (e.KeyCode == Keys.Left) {
				addTextUpdateHandler();
			} else if (e.KeyCode == Keys.Right) {
				addTextUpdateHandler();
			} else if (e.KeyCode == Keys.Escape) {
				if (inputComboBox.DroppedDown) {
					// DropDown 时删除了事件，此时需要重新添加上
					addTextUpdateHandler();
				}
			}
		}
		
		private void inputComboBox_KeyDown_ListBox(KeyEventArgs e)
		{
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
					//deleteTextUpdateHandler();
					string result = ((ZhongYaoInfo)queryListBox.Items[queryListBox.SelectedIndex]).name;
					inputComboBox.Text = result;
					inputComboBox.SelectionStart = inputComboBox.Text.Length;
					
					string line = inputComboBox.Text.Trim();
					if (line.Length == 0) {
						return;
					}
					
					// 将查询历史记录添加到 ComboBox
					inputComboBox.Items.Remove(line);
					inputComboBox.Items.Insert(0, line);
					inputComboBox.Text = line;
					inputComboBox.SelectionStart = inputComboBox.Text.Length;
					
					inputCombox_Enter();
					
					addTextUpdateHandler();
					queryListBox.Visible = false;
				}
			}
		}
		
		private void inputCombox_Enter()
		{
			// 清空outputText，但保留其ZoomFactor
			// 注意需要两次设置ZoomFactor，参考：
			// https://social.msdn.microsoft.com/Forums/windows/en-US/8b61eef0-b712-4b8b-9f5f-c9bbf75abb53/richtextbox-zoomfactor-problems?forum=winforms
			float factor = outputText.ZoomFactor;
			outputText.ResetText();
			outputText.ZoomFactor = 1f;
			outputText.ZoomFactor = factor;
			
			string line = inputComboBox.Text.Trim();
			Data data = Data.Instance;
			ZhongYaoInfo info = data.getZhongYao(line);
			if (info == null) {
				Logger.error("没有收录 [" + line + "]");
				showMissZhongYao(line);
			} else {
				showZhongYao(info);
			}
		}
		
		private void showMissZhongYao(string str)
		{
			int start = outputText.Text.Length;
			outputText.AppendText("没有收录中药： " + str + "\n");
			outputText.Select(start, outputText.Text.Length - start);
			outputText.SelectionColor = Color.Red;
		}
		
		private void showZhongYao(ZhongYaoInfo zhongyao)
		{
			show(zhongyao.name, TITLE_SIZE);
			show(" (" + string.Join(", ", zhongyao.pinyin) + ")", TITLE_SIZE);
			outputText.AppendText("\n");
			outputText.AppendText("\n");
			
			showLine(zhongyao.jieshao);
			
			showLine("【药性】");
			showLine(zhongyao.qiwei);
			showLine(zhongyao.guijing);
			showLine(zhongyao.duxing);
			
			showItem("【功效】", zhongyao.gongxiao);
			
			showLine("【应用】");
			foreach (YingYongInfo yyInfo in zhongyao.yingyongs) {
				showLine(yyInfo.biaoti);
				showLine(yyInfo.neirong);
				outputText.AppendText("\n");
			}
			
			showItem("【用法用量】", zhongyao.yongfa);
			showItem("【使用注意】", zhongyao.zhuyi);
			
			foreach(JianBieInfo jbInfo in zhongyao.jianbies) {
			  showItem("【鉴别用药】", jbInfo.neirong);	
			}
			
			showItem("【其他】", zhongyao.qita);
			showItem("【附药】", string.Join(", ", zhongyao.fuyaos));
		}
		
		private void show(string text)
		{
			show(text, TEXT_SIZE);
		}
		
		private void show(string text, int size)
		{
			int start = outputText.Text.Length;
			outputText.AppendText(text);
			outputText.Select(start, outputText.Text.Length - start);
			outputText.SelectionFont = new Font("宋体", size); 
		}
		
		private void showItem(string title, string text)
		{
			if (text.Length == 0) {
				return;
			}
			showLine(title);
			showLine(text);
		}
		
		private void showLine(string text)
		{
			showLine(text, TEXT_SIZE);
		}
		
		private void showLine(string text, int size)
		{
			if (text.Length == 0) {
				return;
			}
			
			show(text, size);
			outputText.AppendText("\n");
		}
		
		private void addTextUpdateHandler()
		{
			if (!hasHandler) {
				inputComboBox.TextChanged += textUpdateHandler;
				hasHandler = true;
			}
		}
		
		private void deleteTextUpdateHandler()
		{
			if (hasHandler) {
				inputComboBox.TextChanged -= textUpdateHandler;
				hasHandler = false;
			}
		}
	}
}
