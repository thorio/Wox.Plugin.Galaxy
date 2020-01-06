using System.Collections.Generic;
using System.Linq;

namespace Wox.Plugin.Galaxy
{
	class Plugin : IPlugin
	{

		Repositories.ProductRepository ProductRepository { get; set; }

		public void Init(PluginInitContext context)
		{
			ProductRepository = new Repositories.ProductRepository(Environment.ConnectionString);

			// TODO: cache icons
		}

		public List<Result> Query(Query query)
		{
			var products = ProductRepository.GetProducts();

			var results = products
				.Where(product => product.Title.ToLower().Contains(query.RawQuery.ToLower()))
				.Select(product => ToResult(product))
				.ToList();

			return results;
		}

		private static Result ToResult(Entities.Product product)
		{
			return new Result()
			{
				Action = context => GalaxyClient.StartGame(product.ReleaseKey),
				Title = product.Title,
				SubTitle = product.ReleaseKey,
				Score = 100,
				IcoPath = "Images/default_lowres.png",
			};
		}
	}
}
