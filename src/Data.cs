/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2018/2/6
 * Time: 11:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ZhongYi.Filter;

namespace ZhongYi
{
	/// <summary>
	/// Description of Data.
	/// </summary>
	public class Data
	{
		private char[] SEPARATOR = new char[] { ',' };
		private char[] TRIM_CHARS = new char[] { '\n', '\r', '\t' };
		
		List<ZhongYaoInfo> zhongyaos;
		NameCollections zhongyaoNameCollections;
		
		private static Data instance = new Data();
		
		public static Data Instance {
			get {
				return instance;
			}
		}
		
		private Data()
		{
			zhongyaos = new List<ZhongYaoInfo>();
		}
		
		public void Load()
		{
			loadZhongYao();
			Logger.info("Load finished.");
		}
		
		public ZhongYaoInfo getZhongYao(string str)
		{
			foreach (ZhongYaoInfo info in zhongyaos)
			{
				if (String.Equals(info.name, str)) {
					return info;
				}
			}
			return null;
		}
		
		public List<ZhongYaoInfo> queryZhongYao(string str)
		{
			List<ZhongYaoInfo> list = new List<ZhongYaoInfo>();
			foreach (ZhongYaoInfo info in zhongyaos) {
				if (info.name.Contains(str)) {
					list.Add(info);
				}
			}
			return list;
		}
		
		public List<NameInfo> queryZhongyaoName(string str)
		{
			return zhongyaoNameCollections.Query(str);
		}
		
		private void loadZhongYao()
		{
			DirectoryInfo dir = new DirectoryInfo("data/zhongyao");
			FileInfo[] files = dir.GetFiles("*.xml");
			foreach (FileInfo file in files) {
				if (String.Equals(file.Name, "template.xml")) {
					continue;
				}
				
				XmlDocument doc = new XmlDocument();
				Logger.info("Load " + file.FullName);
				doc.Load(file.FullName);	//加载Xml文件
				XmlElement root = doc.DocumentElement;   //获取根节点
				loadZhongYao(root);
			}
			
			// 中药按照拼音字母顺序排序
			// 逗号“,”的ASCII码为“2C”，大于小写字母“a”（ASCII为“61”），
			// 这样可以确保 an,z 会排在 ang 的前面。（因为 , 小于 g）
			zhongyaos.Sort((a,b) => string.Join(",", a.pinyin).CompareTo(string.Join(",", b.pinyin)));
			
			var zhongyaoNames = new List<NameInfo>();
			foreach (ZhongYaoInfo zyInfo in zhongyaos) {
				NameInfo nameInfo = new NameInfo(zyInfo.name, zyInfo.pinyin);
				zhongyaoNames.Add(nameInfo);
			}
			zhongyaoNameCollections = new NameCollections(zhongyaoNames);
		}
		
		private void loadZhongYao(XmlElement root)
		{
			ZhongYaoInfo zhongyao = new ZhongYaoInfo();
			
			XmlElement name = (XmlElement)root.GetElementsByTagName("名称")[0];
			string hz = name.GetAttribute("hz");   //获取hz属性值
			string py = name.GetAttribute("py");   //获取py属性值
			string [] pinyin = py.Split(SEPARATOR);
			if (pinyin.Length != hz.Length) {
				throw new InvalidDataException("Invalid pinyin for [" + hz
				                               + "]， pinyin [" + py + "]");
			}
			zhongyao.name = hz;
			zhongyao.pinyin = pinyin;
			
			zhongyao.jieshao = getInnerText(root, "介绍");
			
			XmlElement yaoxing = (XmlElement)root.GetElementsByTagName("药性")[0];
			zhongyao.qiwei = getInnerText(yaoxing, "气味");
			zhongyao.guijing = getInnerText(yaoxing, "归经");
			zhongyao.duxing = tryGetInnerText(yaoxing, "毒性");
			
			zhongyao.gongxiao = getInnerText(root, "功效");
			
			XmlElement yingyong = (XmlElement)root.GetElementsByTagName("应用")[0];
			foreach (XmlNode para in yingyong.GetElementsByTagName("para"))
			{
				XmlElement element = (XmlElement)para;
				YingYongInfo yyInfo = new YingYongInfo();
				yyInfo.biaoti = tryGetInnerText(element, "title");
				element.RemoveChild(element.ChildNodes[0]); // 删除 title后才能使用 InnerText 获取所要的文本
				yyInfo.neirong = element.InnerText.Trim(TRIM_CHARS);
				zhongyao.yingyongs.Add(yyInfo);
			}
			
			zhongyao.yongfa = getInnerText(root, "用法用量");
			zhongyao.zhuyi = tryGetInnerText(root, "使用注意");
			
			foreach (XmlNode jianbie in root.GetElementsByTagName("鉴别用药"))
			{
				XmlElement element = (XmlElement)jianbie;
				JianBieInfo jbInfo = new JianBieInfo();
				List<XmlNode> list = new List<XmlNode>();
				foreach (XmlNode jy in element.GetElementsByTagName("鉴药"))
				{
					jbInfo.jianyao.Add(jy.InnerText);
					list.Add(jy);
				}
				
				// 删除“鉴药”元素，以便正确读取“鉴别用药”的内容
				foreach (XmlNode item in list) {
					element.RemoveChild(item);
				}
				jbInfo.neirong = jianbie.InnerText.Trim(TRIM_CHARS);
				zhongyao.jianbies.Add(jbInfo);
			}
			
			zhongyao.qita = tryGetInnerText(root, "其他");
			foreach (XmlNode fuyao in root.GetElementsByTagName("附药"))
			{
				zhongyao.fuyaos.Add(fuyao.InnerText);
			}
			
			zhongyaos.Add(zhongyao);
		}
		
		private string getInnerText(XmlElement parent, string tagName)
		{
			XmlNodeList list = parent.GetElementsByTagName(tagName);
			return ((XmlElement)list[0]).InnerText;
		}
		
		private string tryGetInnerText(XmlElement parent, string tagName)
		{
			XmlNodeList list = parent.GetElementsByTagName(tagName);
			return (list.Count == 0) ? "" : ((XmlElement)list[0]).InnerText;
		}
	}
}
