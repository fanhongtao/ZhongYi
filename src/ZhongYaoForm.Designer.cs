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
			this.label1 = new System.Windows.Forms.Label();
			this.outputText = new System.Windows.Forms.RichTextBox();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.zhongyaoListBox = new System.Windows.Forms.ListBox();
			this.nameFilter = new ZhongYi.Filter.NameFilter();
			this.inputPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputPanel
			// 
			this.inputPanel.Controls.Add(this.nameFilter);
			this.inputPanel.Controls.Add(this.label1);
			this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.inputPanel.Location = new System.Drawing.Point(0, 0);
			this.inputPanel.Margin = new System.Windows.Forms.Padding(4);
			this.inputPanel.Name = "inputPanel";
			this.inputPanel.Padding = new System.Windows.Forms.Padding(13, 12, 13, 0);
			this.inputPanel.Size = new System.Drawing.Size(379, 44);
			this.inputPanel.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(13, 12);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "中药查询：";
			// 
			// outputText
			// 
			this.outputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputText.Location = new System.Drawing.Point(0, 0);
			this.outputText.Margin = new System.Windows.Forms.Padding(4);
			this.outputText.Name = "outputText";
			this.outputText.ReadOnly = true;
			this.outputText.Size = new System.Drawing.Size(321, 282);
			this.outputText.TabIndex = 3;
			this.outputText.Text = "";
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 44);
			this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(4);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.zhongyaoListBox);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.outputText);
			this.mainSplitContainer.Size = new System.Drawing.Size(379, 282);
			this.mainSplitContainer.SplitterDistance = 53;
			this.mainSplitContainer.SplitterWidth = 5;
			this.mainSplitContainer.TabIndex = 4;
			// 
			// zhongyaoListBox
			// 
			this.zhongyaoListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zhongyaoListBox.FormattingEnabled = true;
			this.zhongyaoListBox.ItemHeight = 15;
			this.zhongyaoListBox.Location = new System.Drawing.Point(0, 0);
			this.zhongyaoListBox.Margin = new System.Windows.Forms.Padding(4);
			this.zhongyaoListBox.Name = "zhongyaoListBox";
			this.zhongyaoListBox.Size = new System.Drawing.Size(53, 282);
			this.zhongyaoListBox.TabIndex = 0;
			// 
			// nameFilter
			// 
			this.nameFilter.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameFilter.Hint = "输入中药名 或 拼音（全拼 或 缩写）";
			this.nameFilter.Location = new System.Drawing.Point(138, 12);
			this.nameFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nameFilter.Name = "nameFilter";
			this.nameFilter.Size = new System.Drawing.Size(228, 26);
			this.nameFilter.TabIndex = 1;
			// 
			// ZhongYaoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 326);
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.inputPanel);
			this.Margin = new System.Windows.Forms.Padding(4);
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
		private System.Windows.Forms.RichTextBox outputText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel inputPanel;
		private ZhongYi.Filter.NameFilter nameFilter;
	}
}
