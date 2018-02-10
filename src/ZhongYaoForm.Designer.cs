/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/2/6
 * Time: 14:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ZhongYi
{
	partial class ZhongYaoForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.inputPanel = new System.Windows.Forms.Panel();
			this.inputComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.outputText = new System.Windows.Forms.RichTextBox();
			this.queryListBox = new System.Windows.Forms.ListBox();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.zhongyaoListBox = new System.Windows.Forms.ListBox();
			this.inputPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputPanel
			// 
			this.inputPanel.Controls.Add(this.inputComboBox);
			this.inputPanel.Controls.Add(this.label1);
			this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.inputPanel.Location = new System.Drawing.Point(0, 0);
			this.inputPanel.Name = "inputPanel";
			this.inputPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
			this.inputPanel.Size = new System.Drawing.Size(284, 35);
			this.inputPanel.TabIndex = 2;
			// 
			// inputComboBox
			// 
			this.inputComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputComboBox.FormattingEnabled = true;
			this.inputComboBox.Location = new System.Drawing.Point(104, 10);
			this.inputComboBox.Name = "inputComboBox";
			this.inputComboBox.Size = new System.Drawing.Size(170, 20);
			this.inputComboBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "中药查询：";
			// 
			// outputText
			// 
			this.outputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputText.Location = new System.Drawing.Point(0, 0);
			this.outputText.Name = "outputText";
			this.outputText.ReadOnly = true;
			this.outputText.Size = new System.Drawing.Size(240, 226);
			this.outputText.TabIndex = 3;
			this.outputText.Text = "";
			// 
			// queryListBox
			// 
			this.queryListBox.FormattingEnabled = true;
			this.queryListBox.ItemHeight = 12;
			this.queryListBox.Location = new System.Drawing.Point(104, 29);
			this.queryListBox.Name = "queryListBox";
			this.queryListBox.Size = new System.Drawing.Size(170, 88);
			this.queryListBox.TabIndex = 2;
			this.queryListBox.Visible = false;
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 35);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.zhongyaoListBox);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.outputText);
			this.mainSplitContainer.Size = new System.Drawing.Size(284, 226);
			this.mainSplitContainer.SplitterDistance = 40;
			this.mainSplitContainer.TabIndex = 4;
			// 
			// zhongyaoListBox
			// 
			this.zhongyaoListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zhongyaoListBox.FormattingEnabled = true;
			this.zhongyaoListBox.ItemHeight = 12;
			this.zhongyaoListBox.Location = new System.Drawing.Point(0, 0);
			this.zhongyaoListBox.Name = "zhongyaoListBox";
			this.zhongyaoListBox.Size = new System.Drawing.Size(40, 226);
			this.zhongyaoListBox.TabIndex = 0;
			// 
			// ZhongYaoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.queryListBox);
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.inputPanel);
			this.Name = "ZhongYaoForm";
			this.Text = "ZhongYaoForm";
			this.inputPanel.ResumeLayout(false);
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox zhongyaoListBox;
		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.ListBox queryListBox;
		private System.Windows.Forms.RichTextBox outputText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox inputComboBox;
		private System.Windows.Forms.Panel inputPanel;
	}
}
