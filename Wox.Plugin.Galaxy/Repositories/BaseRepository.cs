using Dapper;
using SqlKata;
using SqlKata.Compilers;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;

namespace Wox.Plugin.Galaxy.Repositories
{
	abstract class BaseRepository
	{
		protected BaseRepository(ConnectionStringSettings connectionString)
		{
			Connection = new SQLiteConnection(connectionString.ConnectionString);
			Compiler = new SqliteCompiler();
		}

		protected static SQLiteConnection Connection { get; set; }
		protected static Compiler Compiler { get; set; }


		protected static IEnumerable<T> Query<T>(SqlKata.Query query)
		{
			var sql = Compiler.Compile(query);
			return Connection.Query<T>(sql.Sql, sql.NamedBindings);
		}
	}
}
