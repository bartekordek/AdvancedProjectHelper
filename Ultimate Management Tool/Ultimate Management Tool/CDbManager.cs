using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DBManager
{
	/// <summary>
	/// This is a database interface class.
	/// It handles necessary db operations.
	/// </summary>
	class CDbManager
	{
		public CDbManager()
		{
			dbConnection = null;
        }

		~CDbManager()
		{
			dbConnection.Close();
        }

		public void ExecuteQuery( String query )
		{
			if( null == dbConnection )
			{
				CreateConnection();
            }
			SQLiteCommand command = new SQLiteCommand( query, dbConnection );
		}

		public void CreateNewDbFile( String dbFilePath )
		{
			SetDbFilePath( dbFilePath );
			CreateSqlFile();
			CreateConnection();
        }

		private void CreateSqlFile()
		{
			SQLiteConnection.CreateFile( this.dbPath );
		}

		public void CreateConnection( String dbFilePath = "", Boolean isFileSystem = true)
		{
			SetDbFilePath( dbFilePath );
            if( isFileSystem )
			{
				CreateConnection2File();
            }
			else
			{
				CreateConnection2Server();
            }
		}

		private void CreateConnection2File()
		{
			if( null == dbConnection )
			{
				dbConnection = new SQLiteConnection( "Data Source=" + dbPath + " ;Version=3;" );
				dbConnection.Open();
			}
        }

		private void CreateConnection2Server()
		{

		}

		private void SetDbFilePath(String dbFilePath)
		{
			if( "" != dbFilePath )
			{
				dbPath = dbFilePath;
			}
        }

		private String dbPath;
		private SQLiteConnection dbConnection;
	}
}
