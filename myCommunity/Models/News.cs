using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCommunity.Models
{
	public class News : BaseEvent
    {

		// inherits "id", "title", "description", "short description" from BaseEvent

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


    }
}
