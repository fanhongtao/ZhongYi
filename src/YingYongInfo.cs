/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/2/6
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ZhongYi
{
	/// <summary>
	/// 中药的应用
	/// </summary>
	public class YingYongInfo
	{
		/// <summary>
		/// 应用的标题。注意，如果没有标题，则为null
		/// </summary>
		public string biaoti { get; set; }
		
		/// <summary>
		/// 应用的内容。
		/// </summary>
		public string neirong { get; set; }
		
		public YingYongInfo()
		{
		}
	}
}
