using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.IndicesGetFieldMapping
{
	public partial class IndicesGetFieldMapping10BasicYaml10Tests
	{
		
		public class Setup10Tests
		{
			private readonly RawElasticClient _client;
		
			public Setup10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void SetupTests()
			{

				//do indices.create 
				this._client.IndicesCreatePost("test_index", "SERIALIZED BODY HERE", nv=>nv);
			}
		}
		
		public class GetFieldMappingWithNoIndexAndType10Tests
		{
			private readonly RawElasticClient _client;
		
			public GetFieldMappingWithNoIndexAndType10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void GetFieldMappingWithNoIndexAndTypeTests()
			{

				//do indices.get_field_mapping 
				this._client.IndicesGetFieldMapping("text", nv=>nv);
			}
		}
		
		public class GetFieldMappingByIndexOnly10Tests
		{
			private readonly RawElasticClient _client;
		
			public GetFieldMappingByIndexOnly10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void GetFieldMappingByIndexOnlyTests()
			{

				//do indices.get_field_mapping 
				this._client.IndicesGetFieldMapping("test_index", "text", nv=>nv);
			}
		}
		
		public class GetFieldMappingByTypeField10Tests
		{
			private readonly RawElasticClient _client;
		
			public GetFieldMappingByTypeField10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void GetFieldMappingByTypeFieldTests()
			{

				//do indices.get_field_mapping 
				this._client.IndicesGetFieldMapping("test_index", "test_type", "text", nv=>nv);
			}
		}
		
		public class GetFieldMappingByTypeFieldWithAnotherFieldThatDoesntExist10Tests
		{
			private readonly RawElasticClient _client;
		
			public GetFieldMappingByTypeFieldWithAnotherFieldThatDoesntExist10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void GetFieldMappingByTypeFieldWithAnotherFieldThatDoesntExistTests()
			{

				//do indices.get_field_mapping 
				this._client.IndicesGetFieldMapping("test_index", "test_type", "System.Collections.Generic.List`1[System.Object]", nv=>nv);
			}
		}
		
		public class GetFieldMappingWithIncludeDefaults10Tests
		{
			private readonly RawElasticClient _client;
		
			public GetFieldMappingWithIncludeDefaults10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void GetFieldMappingWithIncludeDefaultsTests()
			{

				//do indices.get_field_mapping 
				this._client.IndicesGetFieldMapping("test_index", "test_type", "text", nv=>nv);
			}
		}
	}
}