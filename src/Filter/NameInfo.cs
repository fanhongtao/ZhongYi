/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2020/2/5
 * Time: 20:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ZhongYi.Filter
{
	/// <summary>
	/// Description of StockAbbrInfo.
	/// </summary>
	public class NameInfo
	{
		/// <summary>
		/// （中药）名称
		/// </summary>
		private readonly string name;
		
		/// <summary>
		/// <para>名称对应的拼音：</para>
		/// <para>1. 数组中的每个字符串对应一个汉字的拼音（根据XML中的定义，可能是空串""）</para>
		/// <para>2. 按照 name 中汉字的顺序排列（name中第一个汉字，对应数组中第一个拼音 …… 以此类推）</para>
		/// </summary>
		private readonly string[] pinyin;
		
		/// <summary>
		/// 完整的拼音串（减少显示时运算）
		/// </summary>
		private readonly string pys;
		
		/// <summary>
		/// ASCII形式的拼音，用于按拼音检索
		/// </summary>
		private readonly string asciiPy;
		
		private static NameInfo empty = new NameInfo("", new string[] {""});
		public static NameInfo Empty {
			get {
				return empty;
			}
		}
		
		public NameInfo(string name, string[] pinyin)
		{
			this.name = name;
			this.pinyin = pinyin;
			this.pys = string.Join(",", this.pinyin);
			this.asciiPy = string.Join("", this.pinyin);
			
			// 将拼音中的 声调 去掉，方便后期进行拼音匹配
			asciiPy = asciiPy.Replace('ā', 'a');
			asciiPy = asciiPy.Replace('á', 'a');
			asciiPy = asciiPy.Replace('ǎ', 'a');
			asciiPy = asciiPy.Replace('à', 'a');
			asciiPy = asciiPy.Replace('ē', 'e');
			asciiPy = asciiPy.Replace('é', 'e');
			asciiPy = asciiPy.Replace('ě', 'e');
			asciiPy = asciiPy.Replace('è', 'e');
			asciiPy = asciiPy.Replace('ī', 'i');
			asciiPy = asciiPy.Replace('í', 'i');
			asciiPy = asciiPy.Replace('ǐ', 'i');
			asciiPy = asciiPy.Replace('ì', 'i');
			asciiPy = asciiPy.Replace('ō', 'o');
			asciiPy = asciiPy.Replace('ó', 'o');
			asciiPy = asciiPy.Replace('ǒ', 'o');
			asciiPy = asciiPy.Replace('ò', 'o');
			asciiPy = asciiPy.Replace('ū', 'u');
			asciiPy = asciiPy.Replace('ú', 'u');
			asciiPy = asciiPy.Replace('ǔ', 'u');
			asciiPy = asciiPy.Replace('ù', 'u');
			asciiPy = asciiPy.Replace('ǖ', 'v');
			asciiPy = asciiPy.Replace('ǘ', 'v');
			asciiPy = asciiPy.Replace('ǚ', 'v');
			asciiPy = asciiPy.Replace('ǜ', 'v');
			asciiPy = asciiPy.Replace('ü', 'v');
		}
		
		/// <summary>
		/// 获取 名称
		/// </summary>
		public string Name
		{
			get {
				return name;
			}
		}
		
		public override string ToString()
		{
			return String.Format("{0} ({1})", name, pys);
		}
		
		/// <summary>
		/// 判断名字对应的拼音是否与输入的 py 匹配
		/// </summary>
		/// <param name="py">待匹配的拼音</param>
		/// <returns>true: 匹配; false: 不匹配</returns>
		public bool MatchPinYin(string py)
		{
			bool ret = true;
			int start = 0;
			foreach (char ch in py) {
				int idx = asciiPy.IndexOf(ch, start);
				if (idx == -1) {
					ret = false;
					break;
				}
				start = idx + 1;
			}
			return ret;
		}
	}
}
