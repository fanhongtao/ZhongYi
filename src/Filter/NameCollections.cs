/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2020/2/5
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace ZhongYi.Filter
{
	/// <summary>
	/// 管理名称和拼音之间的对应关系
	/// </summary>
	public class NameCollections
	{
		private List<NameInfo> nameList;
		
		public NameCollections(List<NameInfo> list)
		{
			nameList = list;
		}
		
		public List<NameInfo> Query(string text)
		{
			char ch = text.ToCharArray()[0];
			if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')) {
				return QueryByPinYin(text.ToLower());
			} else {
				return QueryByText(text);
			}
		}
		
		private List<NameInfo> QueryByPinYin(string text)
		{
			List<NameInfo> list = new List<NameInfo>();
			foreach (NameInfo info in nameList) {
				if (info.MatchPinYin(text)) {
					list.Add(info);
				}
			}
			return list;
		}
		
		private List<NameInfo> QueryByText(string text)
		{
			List<NameInfo> list = new List<NameInfo>();
			foreach (NameInfo info in nameList) {
				if (info.Name.Contains(text)) {
					list.Add(info);
				}
			}
			return list;
		}
	}
}
