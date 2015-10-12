using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuilder
{
	class CDbBuilder
	{
		static public void CreateEmptyDb( DBManager.CDbManager dbManager, string dbPath = "mainDataBase.db" )
		{
			CreateFile( dbManager, dbPath );
			CreateConnection( dbManager );
			CreateTables( dbManager );
        }

		static private void CreateFile( DBManager.CDbManager dbManager, string dbPath )
		{
			dbManager.CreateNewDbFile( dbPath );
		}

		static private void CreateConnection( DBManager.CDbManager dbManager)
		{
			dbManager.CreateConnection();
		}	

		static private void CreateTables( DBManager.CDbManager dbManager )
		{
			dbManager.ExecuteQuery( 
				"CREATE TABLE UserACtivities " + 
				"(" +
					"id INTEGER NOT NULL AUTO_INCREMENT " + 
					"userId INTEGER NOT NULL" +
				")" 
				);
		}
	}
}
