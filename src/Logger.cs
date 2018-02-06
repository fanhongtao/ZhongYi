/*
 * Created by SharpDevelop.
 * User: fht
 * Date: 2014/8/28
 * Time: 22:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ZhongYi
{
    /// <summary>
    /// Description of Logger.
    /// </summary>
    public static class Logger
    {
        static RichTextBox logBox;
        
        public static void SetTextBox(RichTextBox box)
        {
            logBox = box;
        }
        
        public static void info(string text)
        {
            string logInfo = getDateStr() + " " + text;
            Trace.WriteLine(logInfo);
            logBox.AppendText(logInfo + "\n");
        }
        
        public static void error(string text)
        {
            string logInfo = getDateStr() + " " + text;
            Trace.TraceError(logInfo);
            int start = logBox.Text.Length;
            logBox.AppendText(logInfo + "\n");
            logBox.Select(start, logBox.Text.Length - start);
            logBox.SelectionColor = Color.Red;
        }
        
        public static void debug(string text)
        {
            string logInfo = getDateStr() + " " + text;
            Trace.TraceError(logInfo);
            logBox.AppendText(logInfo + "\n");
        }
        
        static string getDateStr() {
            return String.Format("{0} {1}", DateTime.Now.ToLongDateString(),
                        DateTime.Now.ToLongTimeString());
        }
        
        public static void clean()
        {
            logBox.ResetText();
        }
    }
}
