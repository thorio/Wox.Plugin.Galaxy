using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Wox.Plugin.Galaxy.Extensions;
using SqlKata;

namespace Wox.Plugin.Galaxy.Repositories
{
	class ProductRepository : BaseRepository
	{
		public ProductRepository(ConnectionStringSettings connectionString) : base(connectionString)
		{

		}

		public IEnumerable<Entities.Product> GetProducts()
		{
			var query = new SqlKata.Query("GamePieces")
				.Select("GamePieces.releaseKey AS ReleaseKey",
					"GamePieces.value AS Title")
				.Join("GamePieceTypes", "GamePieces.gamePieceTypeId", "GamePieceTypes.id")
				.WhereIn("releaseKey",
					new SqlKata.Query("InstalledExternalProducts")
					.SelectRaw("platforms.name || '_' || InstalledExternalProducts.productId")
					.Join("Platforms", "InstalledExternalProducts.platformId", "Platforms.id")
					.Union(
						new SqlKata.Query("InstalledProducts")
						.SelectRaw("'gog_' || productId")
					)
				)
				.Where("GamePieceTypes.type", "originalTitle");
			return Query<Entities.Product>(query).Select(product =>
			{
				product.Title = product.Title.Match("{\"title\":\"(.*)\"}").Groups[1].Value;
				return product;
			});
		}
	}
}
