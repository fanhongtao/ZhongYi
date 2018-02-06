/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/2/6
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ZhongYi
{
	/// <summary>
	/// 鉴别用药
	/// </summary>
	public class JianBieInfo
	{
		/// <summary>
		/// "鉴别用药"的内容。
		/// </summary>
		public string neirong;
		
		/// <summary>
		/// 鉴别用药 中所涉及的药的名字
		/// </summary>
		public List<string> jianyao;
		
		public JianBieInfo()
		{
			jianyao = new List<string>();
		}
	}
}
