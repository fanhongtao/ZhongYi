/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2020/2/5
 * Time: 18:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ZhongYi.Filter
{
	/// <summary>
	/// 用于在自定义控件 和 控件使用界面之间传递参数
	/// </summary>
	public class NameEventArgs : EventArgs
	{
		private NameInfo nameInfo;
		
		public NameEventArgs(NameInfo info)
		{
			nameInfo = info;
		}
		
		public NameInfo NamnInfo
		{
			get
			{
				return nameInfo;
			}
		}
	}
}
