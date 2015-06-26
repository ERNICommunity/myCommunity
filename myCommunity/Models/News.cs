﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCommunity.Models
{
	public class News : BaseEvent
    {

		// inherits "id", "title", "description" from BaseEvent

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("pictureurls")]
        public string[] PictureUrls { get; set; }

        public string FirstPicUrl
        {
            get
            {
                if (PictureUrls == null) return "";

                return PictureUrls.Any() ? PictureUrls[0] : "";
            }
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
