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

		public override string ToString ()
		{
			return String.Format ("{0}: {1}, {2}", ID, Title, Description);
		}

		public string ShortDescription
		{
			get {
				if (string.IsNullOrEmpty(Description)) return "";

				if (Description.Length < 53) return Description;

				return Description.Substring(0, 50) + "...";

			}
		}
	}
}

