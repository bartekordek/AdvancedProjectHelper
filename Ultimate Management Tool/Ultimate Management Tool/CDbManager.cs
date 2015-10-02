using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Ultimate_Management_Tool
{
	class CDbManager
	{
		public CDbManager()
		{
			dbConnection = null;
        }

		public void CreateConnection(String dbFilePath, Boolean isFileSystem = true)
		{
			SetDbFilePath( dbFilePath );
            if( true == isFileSystem )
			{

			}
		}

		private void CreateConnection2File()
		{

		}

		private void SetDbFilePath(String dbFilePath)
		{
			dbPath = dbFilePath;
        }

		private Boolean isOnFileSystem;
		private String dbPath;
		private SQLiteConnection dbConnection;
	}
}
