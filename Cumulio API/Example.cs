using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CumulioAPI
{
	public class Example
	{
		public static void Main()
		{
			// Set the API key and token
			Cumulio client = new Cumulio("< Your API key >", "< Your API token >");
      dynamic properties;
      List<ExpandoObject> associations;

      // These examples use the synchronous method style -- equivalent asynchronous
      // methods are available, eg. createAsync(), updateAsync(), ...

      try {

        // Example 1: create a new dataset
        properties = new ExpandoObject();
        properties.type = "dataset";
        properties.name = new {
          en = "Burrito statistics",            
          nl = "Burrito-statistieken"
        };
        dynamic securable = client.create("securable", properties);
        Console.WriteLine("Dataset created with ID " + securable.id);


        // Example 2: update a dataset
        properties = new ExpandoObject();
        properties.description = new { nl = "Het aantal geconsumeerde burrito's per type" };
        client.update("securable", (string) securable.id, properties);
        Console.WriteLine("Dataset description updated");


        // Example 3: create 2 columns
        associations = new List<ExpandoObject>();
        dynamic association = new ExpandoObject();
        association.role = "Securable";
        association.id = securable.id;
        associations.Add(association);

        properties = new ExpandoObject();
        properties.type = "hierarchy";
        properties.format = "";
        properties.informat = "hierarchy";
        properties.order = 0;
        properties.name = new {
          nl = "Type of burrito"
        };
        client.create("column", properties, associations);
        Console.WriteLine("Column #0 created and associated");

        properties = new ExpandoObject();
        properties.type = "numeric";
        properties.format = ",.0f";
        properties.informat = "numeric";
        properties.order = 1;
        properties.name = new {
          nl = "Burrito weight"
        };
        client.create("column", properties, associations);
        Console.WriteLine("Column #1 created and associated");


        // Example 1: push 2 data points to a (pre-existing) dataset
        properties = new ExpandoObject();
        properties.securable_id = securable.id;
        properties.data = new List<List<String>> {
          new List<String> { "sweet", "126" },
          new List<String> { "sour", "352" }
        };
        client.create("data", properties);
        Console.WriteLine("Data rows pushed");

      }
      catch (CumulioException e) {
        Console.WriteLine("Error during communication with Cumul.io: " + e.details);
      }

		}
	}
}
