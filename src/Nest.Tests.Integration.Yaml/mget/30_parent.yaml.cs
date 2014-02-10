using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.Mget
{
	public partial class Mget30ParentYaml30Tests
	{
		
		public class Parent30Tests
		{
			private readonly RawElasticClient _client;
		
			public Parent30Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void ParentTests()
			{

				//do indices.create 
				this._client.IndicesCreatePost("test_1", "SERIALIZED BODY HERE", nv=>nv);

				//do cluster.health 
				this._client.ClusterHealthGet(nv=>nv);

				//do index 
				this._client.IndexPost("test_1", "test", "1", "SERIALIZED BODY HERE", nv=>nv);

				//do index 
				this._client.IndexPost("test_1", "test", "2", "SERIALIZED BODY HERE", nv=>nv);

				//do mget 
				this._client.MgetPost("test_1", "test", "SERIALIZED BODY HERE", nv=>nv);
			}
		}
	}
}