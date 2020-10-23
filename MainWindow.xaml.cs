using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncodingTool
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			InitEncodingList();
		}

		private void InitEncodingList()
		{
			tbEncoding.Items.Clear();

			foreach(var encoding in Encoding.GetEncodings())
			{
				tbEncoding.Items.Add(encoding.Name);
			}
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			string character = tbCharacter.Text.Trim();

			if (!string.IsNullOrEmpty(character))
			{
				tbOutput.Text = string.Join(",",character.Select(t => EncodingHelper.ConvertToUnicodeCodePoint(t)));
			}
			else
			{
				tbOutput.Text = string.Empty;
			}
		}

		private void btnCalcHex_Click(object sender, RoutedEventArgs e)
		{
			string character = tbCharacterTarget.Text.Trim();
			if(!string.IsNullOrEmpty(character))
			{
				string encodingTxt = tbEncoding.Text.Trim();
				Encoding encoding = null;

				try
				{
					encoding = Encoding.GetEncoding(encodingTxt);
					tbOutputTarget.Text = BitConverter.ToString(encoding.GetBytes(character));
				}
				catch
				{
					MessageBox.Show($"'{encodingTxt}' is an invalid Encoding");
				}
				
			}
			else
			{
				tbOutputTarget.Text = string.Empty;
			}
		}
	}
}
