using System;
using Newtonsoft.Json;

namespace myCommunity
{
	/// <summary>
	/// Base event the abstract class containing basic fields that are shared among all the types of event, news etc...
	/// </summary>

	public abstract class BaseEvent
	{
		[JsonProperty ("id")]
		public string ID { get; set; }

		[JsonProperty ("title")]
		public string Title { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}
}

