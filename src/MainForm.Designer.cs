/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2017/4/17
 * Time: 10:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ZhongYi
{
	partial class MainForm
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
			this.logGroupBox = new System.Windows.Forms.GroupBox();
			this.logTextBox = new System.Windows.Forms.RichTextBox();
			this.logPanel = new System.Windows.Forms.Panel();
			this.cleanLogButton = new System.Windows.Forms.Button();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.zhongyaoPage = new System.Windows.Forms.TabPage();
			this.logGroupBox.SuspendLayout();
			this.logPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.mainTabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// logGroupBox
			// 
			this.logGroupBox.Controls.Add(this.logTextBox);
			this.logGroupBox.Controls.Add(this.logPanel);
			this.logGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logGroupBox.Location = new System.Drawing.Point(0, 0);
			this.logGroupBox.Name = "logGroupBox";
			this.logGroupBox.Size = new System.Drawing.Size(284, 67);
			this.logGroupBox.TabIndex = 1;
			this.logGroupBox.TabStop = false;
			this.logGroupBox.Text = "Log";
			// 
			// logTextBox
			// 
			this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logTextBox.Location = new System.Drawing.Point(3, 42);
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.Size = new System.Drawing.Size(278, 22);
			this.logTextBox.TabIndex = 0;
			this.logTextBox.Text = "";
			// 
			// logPanel
			// 
			this.logPanel.Controls.Add(this.cleanLogButton);
			this.logPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.logPanel.Location = new System.Drawing.Point(3, 17);
			this.logPanel.Name = "logPanel";
			this.logPanel.Size = new System.Drawing.Size(278, 25);
			this.logPanel.TabIndex = 1;
			// 
			// cleanLogButton
			// 
			this.cleanLogButton.Location = new System.Drawing.Point(1, 3);
			this.cleanLogButton.Name = "cleanLogButton";
			this.cleanLogButton.Size = new System.Drawing.Size(75, 23);
			this.cleanLogButton.TabIndex = 0;
			this.cleanLogButton.Text = "清除日志";
			this.cleanLogButton.UseVisualStyleBackColor = true;
			this.cleanLogButton.Click += new System.EventHandler(this.CleanLogButtonClick);
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.mainSplitContainer.Name = "mainSplitContainer";
			this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.mainTabControl);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.logGroupBox);
			this.mainSplitContainer.Size = new System.Drawing.Size(284, 261);
			this.mainSplitContainer.SplitterDistance = 190;
			this.mainSplitContainer.TabIndex = 1;
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.zhongyaoPage);
			this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabControl.Location = new System.Drawing.Point(0, 0);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(284, 190);
			this.mainTabControl.TabIndex = 1;
			// 
			// zhongyaoPage
			// 
			this.zhongyaoPage.Location = new System.Drawing.Point(4, 22);
			this.zhongyaoPage.Name = "zhongyaoPage";
			this.zhongyaoPage.Padding = new System.Windows.Forms.Padding(3);
			this.zhongyaoPage.Size = new System.Drawing.Size(276, 164);
			this.zhongyaoPage.TabIndex = 0;
			this.zhongyaoPage.Text = "中药查询";
			this.zhongyaoPage.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.mainSplitContainer);
			this.Name = "MainForm";
			this.Text = "ZhongYi";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.logGroupBox.ResumeLayout(false);
			this.logPanel.ResumeLayout(false);
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.mainTabControl.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TabPage zhongyaoPage;
		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.Button cleanLogButton;
		private System.Windows.Forms.Panel logPanel;
		private System.Windows.Forms.RichTextBox logTextBox;
		private System.Windows.Forms.GroupBox logGroupBox;
	}
}
