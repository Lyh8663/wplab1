using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest.UI.Chapter1
{
	/// <summary>
	/// C1_SY2.xaml 的交互逻辑
	/// </summary>
	public partial class C1_SY2 : ChildPage
	{

		string folder_path = "";
		string[] folder_files;

		string dest_file = "";

		public C1_SY2()
		{
			InitializeComponent();
		}

		private void SelectDirectory(object sender, RoutedEventArgs e)
		{
			FolderBrowserDialog m_Dialog = new FolderBrowserDialog
			{
				Description = "请选择所查找的文件夹："
			};
			DialogResult result = m_Dialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				folder_path = m_Dialog.SelectedPath.Trim();
				searchDirectoryLabel.Content = folder_path;
			}
		}

		private void SearchFiles(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(folder_path))
			{
				System.Windows.MessageBox.Show("请选择要查找的文件夹");
				return;
			}
			if (Directory.Exists(folder_path))//检查文件目录是否存在
			{
				//搜索给定字符串的文件
				folder_files = Directory.GetFiles(folder_path,
						 textBox.Text, SearchOption.AllDirectories);
				foundFileListBox.Items.Clear();
				foreach (string folder_file in folder_files)
				{
					int selected_index = foundFileListBox.Items.Add(folder_file);
					foundFileListBox.SelectedIndex = selected_index;
				}
			}
		}

		private void AddFiles(object sender, RoutedEventArgs e)
		{
			foreach (string item in foundFileListBox.Items)
			{
				if (!targetFileListBox.Items.Contains(item))
					targetFileListBox.Items.Add(item);
			}
		}

		private void ClearFiles(object sender, RoutedEventArgs e)
		{
			targetFileListBox.Items.Clear();
		}

		private void MoveUp(object sender, RoutedEventArgs e)
		{
			if (targetFileListBox.SelectedItem == null) return;
			int sel_index = targetFileListBox.SelectedIndex;
			string sel_str = targetFileListBox.SelectedItem.ToString();
			if (sel_index > 0)
			{
				//将当前选中的项与前一项交换，并交换列表框的选中序号
				targetFileListBox.Items[sel_index] = targetFileListBox.Items[sel_index - 1];
				targetFileListBox.Items[sel_index - 1] = sel_str;
				targetFileListBox.SelectedIndex = sel_index - 1;
			}

		}

		private void MoveDown(object sender, RoutedEventArgs e)
		{
			if (targetFileListBox.SelectedItem == null) return;
			int sel_index = targetFileListBox.SelectedIndex;
			string sel_str = targetFileListBox.SelectedItem.ToString();
			if (sel_index < targetFileListBox.Items.Count - 1)
			{
				//将当前选中的项与下一项交换，并交换列表框的选中序号
				targetFileListBox.Items[sel_index] = targetFileListBox.Items[sel_index + 1];
				targetFileListBox.Items[sel_index + 1] = sel_str;
				targetFileListBox.SelectedIndex = sel_index + 1;
			}
		}

		private void OpenFile(object sender, RoutedEventArgs e)
		{
			if (targetFileListBox.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("未选中任何文件。");
				return;
			}
			else if (!File.Exists(targetFileListBox.SelectedItem.ToString()))
			{
				System.Windows.MessageBox.Show("文件不存在，可能已被删除或移动到其他位置。");
				return;
			}
			else Process.Start(targetFileListBox.SelectedItem.ToString());
		}

		private void NameTargetFile(object sender, RoutedEventArgs e)
		{
			SaveFileDialog m_Dialog = new SaveFileDialog
			{
				Title = "选择要合并后的文件",
				InitialDirectory = System.Environment.SpecialFolder.DesktopDirectory.ToString(),
				OverwritePrompt = false,
				Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
			};
			if (m_Dialog.ShowDialog() == DialogResult.OK)
			{
				dest_file = m_Dialog.FileName;
				targetNameLabel.Content = dest_file;
			}
		}

		private void MergeFiles(object sender, RoutedEventArgs e)
		{
			//处理特殊情况
			if (string.IsNullOrEmpty(dest_file))
			{
				System.Windows.MessageBox.Show("请选择保存文件名称");
				return;
			}
			if (File.Exists(dest_file))
			{
				File.Delete(dest_file);
			}

			//准备写文件所需的缓冲区
			byte[] dataBuffer = new byte[100000];
			byte[] file_name_buf;

			//用于记录无效文件的字符串
			string invalidFiles = "";

			//打开目标文件准备写入
			try
			{
				//使用using可以让异常出现时也能及时释放文件资源
				using (FileStream fs_dest = new FileStream(dest_file, FileMode.CreateNew, FileAccess.Write))
				{
					foreach (string item in targetFileListBox.Items)
					{
						//确认文件是否存在
						if (!File.Exists(item))
						{
							invalidFiles += item + "\n";
							continue;
						}

						FileInfo fi_source = new FileInfo(item);

						//写入文件名
						if (addFileNameCheckBox.IsChecked.Value)
						{
							file_name_buf = Encoding.Default.GetBytes(fi_source.Name);
							fs_dest.Write(file_name_buf, 0, file_name_buf.Length);

							//换行
							if (newLineCheckBox.IsChecked.Value)
							{
								fs_dest.WriteByte((byte)13);
								fs_dest.WriteByte((byte)10);
							}
						}

						//写入数据
						using (FileStream fs_source = new FileStream(fi_source.FullName, FileMode.Open, FileAccess.Read))
						{
							int read_len = fs_source.Read(dataBuffer, 0, 100000);
							while (read_len > 0)
							{
								fs_dest.Write(dataBuffer, 0, read_len);
								read_len = fs_source.Read(dataBuffer, 0, 100000);
							}

							//换行
							if (newLineCheckBox.IsChecked.Value)
							{
								fs_dest.WriteByte((byte)13);
								fs_dest.WriteByte((byte)10);
							}
							fs_source.Close();
							fs_source.Dispose();
						}
					}
					fs_dest.Flush();
					fs_dest.Close();
					fs_dest.Dispose();
				}
				if (!string.IsNullOrEmpty(invalidFiles))
				{
					System.Windows.MessageBox.Show("合并已完成。\n以下文件不存在，已自动跳过。\n" + invalidFiles);
				}
				else
				{
					System.Windows.MessageBox.Show("合并已完成。");
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("文件合并失败！\n异常信息：\n" + ex.ToString());
			}
			if(openFileCheckBox.IsChecked.Value) OpenFile(dest_file);
		}

		private void OpenFile(string fileName)
		{
			try
			{
				Process.Start(fileName);
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("文件打开失败！\n异常信息：\n" + ex.ToString());
			}
		}
	}
}
