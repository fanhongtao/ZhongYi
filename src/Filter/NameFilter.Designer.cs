/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/3/8
 * Time: 13:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ZhongYi.Filter
{
	partial class NameFilter
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
			this.inputTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// inputTextBox
			// 
			this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputTextBox.Location = new System.Drawing.Point(0, 0);
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.Size = new System.Drawing.Size(150, 21);
			this.inputTextBox.TabIndex = 0;
			// 
			// StockFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.inputTextBox);
			this.Name = "StockFilter";
			this.Size = new System.Drawing.Size(150, 21);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox inputTextBox;
	}
}
