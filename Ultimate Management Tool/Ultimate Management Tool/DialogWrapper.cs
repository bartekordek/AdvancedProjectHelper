using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogWrapper
{
	class CDialogWrapper
	{
		static String CreateFile( String extension )
		{
			System.IO.Stream myStream;
			SaveFileDialog newDbDialog = new SaveFileDialog();

			newDbDialog.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
			newDbDialog.FilterIndex = 2;
			newDbDialog.RestoreDirectory = true;

			if( newDbDialog.ShowDialog() == DialogResult.OK )
			{
				if( ( myStream = newDbDialog.OpenFile() ) != null )
				{
					myStream.Close();
					return newDbDialog.FileName;
				}
			}
			return "";
		}
	}
}
