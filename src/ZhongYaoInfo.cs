/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/2/6
 * Time: 10:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ZhongYi
{
	/// <summary>
	/// 记录一味中药的相关信息
	/// </summary>
	public class ZhongYaoInfo
	{
		/// <summary>
		/// 中药名
		/// </summary>
		public string name { get; set; }
		
		/// <summary>
		/// <para>中药名对应的拼音：</para>
		/// <para>1. 数组中的每个字符串对应一个汉字的拼音（根据XML中的定义，可能是空串""）</para>
		/// <para>2. 按照 name 中汉字的顺序排列（name中第一个汉字，对应数组中第一个拼音 …… 以此类推）</para>
		/// </summary>
		public string[] pinyin { get; set; }
		
		/// <summary>
		/// 介绍
		/// </summary>
		public string jieshao { get; set; }
		
		/// <summary>
		/// 药性 之 气味
		/// </summary>
		public string qiwei { get; set; }
		
		/// <summary>
		/// 药性 之 归经
		/// </summary>
		public string guijing { get; set; }
		
		/// <summary>
		/// 药性 之 毒性
		/// </summary>
		public string duxing { get; set; }
		
		/// <summary>
		/// 功效
		/// </summary>
		public string gongxiao { get; set; }
		
		/// <summary>
		/// 中药的具体应用
		/// <para>  1. 按XML中定义的顺序排列 </para>
		/// </summary>
		public List<YingYongInfo> yingyongs;
		
		/// <summary>
		/// 用法用量
		/// </summary>
		public string yongfa { get; set; }
		
		/// <summary>
		/// 使用注意
		/// </summary>
		public string zhuyi { get; set; }
		
		/// <summary>
		/// 鉴别用药
		/// </summary>
		public List<JianBieInfo> jianbies;
		
		/// <summary>
		/// 其他
		/// </summary>
		public string qita { get; set; }
		
		/// <summary>
		/// 附药
		/// </summary>
		public List<string> fuyaos;
		
		public ZhongYaoInfo()
		{
			yingyongs = new List<YingYongInfo>();
			jianbies = new List<JianBieInfo>();
			fuyaos = new List<string>();
		}
	}
}
