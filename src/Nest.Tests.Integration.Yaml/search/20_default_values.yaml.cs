using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.Search
{
	public partial class Search20DefaultValuesYaml20Tests
	{
		
		public class DefaultIndex20Tests
		{
			private readonly RawElasticClient _client;
		
			public DefaultIndex20Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void DefaultIndexTests()
			{

				//do indices.create 
				this._client.IndicesCreatePost("test_2", null, nv=>nv);

				//do indices.create 
				this._client.IndicesCreatePost("test_1", null, nv=>nv);

				//do index 
				this._client.IndexPost("test_1", "test", "1", "SERIALIZED BODY HERE", nv=>nv);

				//do index 
				this._client.IndexPost("test_2", "test", "42", "SERIALIZED BODY HERE", nv=>nv);

				//do indices.refresh 
				this._client.IndicesRefreshPost("System.Collections.Generic.List`1[System.Object]", nv=>nv);

				//do search 
				this._client.SearchPost("_all", "test", "SERIALIZED BODY HERE", nv=>nv);
			}
		}
	}
}