/*
 * Created by SharpDevelop.
 * User: fhtao
 * Date: 2020/2/6
 * Time: 13:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ZhongYi
{
	partial class ZuFangForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel headPanel;
		private ZhongYi.Filter.NameFilter nameFilter;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox outputText;
		
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
			this.headPanel = new System.Windows.Forms.Panel();
			this.nameFilter = new ZhongYi.Filter.NameFilter();
			this.addButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.outputText = new System.Windows.Forms.RichTextBox();
			this.headPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// headPanel
			// 
			this.headPanel.Controls.Add(this.nameFilter);
			this.headPanel.Controls.Add(this.addButton);
			this.headPanel.Controls.Add(this.label1);
			this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headPanel.Location = new System.Drawing.Point(0, 0);
			this.headPanel.Name = "headPanel";
			this.headPanel.Size = new System.Drawing.Size(762, 28);
			this.headPanel.TabIndex = 0;
			// 
			// nameFilter
			// 
			this.nameFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nameFilter.Hint = "输入中药名 或 拼音（全拼 或 缩写）";
			this.nameFilter.Location = new System.Drawing.Point(61, 0);
			this.nameFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nameFilter.Name = "nameFilter";
			this.nameFilter.Size = new System.Drawing.Size(626, 28);
			this.nameFilter.TabIndex = 2;
			// 
			// addButton
			// 
			this.addButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.addButton.Location = new System.Drawing.Point(687, 0);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 28);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "添加";
			this.addButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "中药";
			// 
			// outputText
			// 
			this.outputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputText.Location = new System.Drawing.Point(0, 28);
			this.outputText.Name = "outputText";
			this.outputText.Size = new System.Drawing.Size(762, 429);
			this.outputText.TabIndex = 1;
			this.outputText.Text = "";
			// 
			// ZuFangForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(762, 457);
			this.Controls.Add(this.outputText);
			this.Controls.Add(this.headPanel);
			this.Name = "ZuFangForm";
			this.Text = "ZuFangForm";
			this.headPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
