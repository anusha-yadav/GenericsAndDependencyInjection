using Newtonsoft.Json;

namespace ECommerce.Common.Models
{
    /// <summary>
    /// The User
    /// </summary>
    public class User
    {

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
