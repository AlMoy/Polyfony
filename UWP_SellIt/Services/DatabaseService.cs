using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SellIt.Services
{
    public class DatabaseService
    {
		private SQLiteConnection sqliteConnection;

		public SQLiteConnection SqliteConnection
		{
			get { return sqliteConnection; }
			set { sqliteConnection = value; }
		}

	}
}
