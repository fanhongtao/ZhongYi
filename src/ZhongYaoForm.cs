/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/2/6
 * Time: 14:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
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
		
		public ZhongYaoForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void InputComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				inputCombox_Enter(sender, e);
			}
		}
		
		private void inputCombox_Enter(object sender, KeyEventArgs e)
		{
			// 清空outputText，但保留其ZoomFactor
			// 注意需要两次设置ZoomFactor，参考：
			// https://social.msdn.microsoft.com/Forums/windows/en-US/8b61eef0-b712-4b8b-9f5f-c9bbf75abb53/richtextbox-zoomfactor-problems?forum=winforms
			float factor = outputText.ZoomFactor;
			outputText.ResetText();
			outputText.ZoomFactor = 1f;
			outputText.ZoomFactor = factor;
			
			string line = inputComboBox.Text.Trim();
			if (line.Length == 0) {
				return;
			}
			
			// 将查询历史记录添加到 ComboBox
			inputComboBox.Items.Remove(line);
			inputComboBox.Items.Insert(0, line);
			inputComboBox.Text = line;
			inputComboBox.SelectionStart = inputComboBox.Text.Length;
			
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
	}
}
