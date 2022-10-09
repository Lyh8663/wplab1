using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using DotNetSpeech;

namespace WPFTest.UI.Chapter1
{
	/// <summary>
	/// C1_SY1.xaml 的交互逻辑
	/// </summary>
	public partial class C1_SY1 : ChildPage
	{
		readonly SpVoice voice = new SpVoice();

		public C1_SY1()
		{
			InitializeComponent();
		}


		private bool CheckInput()
		{
			if (textBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("输入不能为空");
				return false;
			}
			return true;
		}

		private void GetPinYinBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CheckInput())
				return;

			listBox.Items.Clear();

			char one_char = textBox.Text.Trim().ToCharArray()[0];
			int ch_int = (int)one_char;
			if (ch_int > 127)
			{
				ChineseChar chineseChar = new ChineseChar(one_char);
				System.Collections.ObjectModel.ReadOnlyCollection<string> pinyins = chineseChar.Pinyins;
				//string pin_str = "";
				foreach (string pinyin in pinyins)
				{
					if (!string.IsNullOrEmpty(pinyin)) listBox.Items.Add(pinyin);
					//pin_str += pin + "\r\n";
				}
			}
		}

		private void TransferTraditionalBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CheckInput())
				return;

			listBox.Items.Clear();

			string t = ChineseConverter.Convert(textBox.Text.Trim(),
			ChineseConversionDirection.TraditionalToSimplified);
			listBox.Items.Add(t);
		}

		private void TransterSimplifiedBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CheckInput())
				return;

			listBox.Items.Clear();

			string t = ChineseConverter.Convert(textBox.Text.Trim(),
			ChineseConversionDirection.SimplifiedToTraditional);
			listBox.Items.Add(t);
		}

		private void GetSoundBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CheckInput())
				return;

			SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
			voice.Speak(textBox.Text.Trim(), spFlags);
		}
	}
}
