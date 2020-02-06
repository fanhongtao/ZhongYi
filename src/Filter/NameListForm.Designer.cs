/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/3/9
 * Time: 20:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ZhongYi.Filter
{
	partial class NameListForm
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
			this.queryListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// queryListBox
			// 
			this.queryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.queryListBox.FormattingEnabled = true;
			this.queryListBox.ItemHeight = 12;
			this.queryListBox.Location = new System.Drawing.Point(0, 0);
			this.queryListBox.Name = "queryListBox";
			this.queryListBox.Size = new System.Drawing.Size(300, 300);
			this.queryListBox.TabIndex = 0;
			// 
			// StockListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.Controls.Add(this.queryListBox);
			this.Name = "StockListForm";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox queryListBox;
	}
}
