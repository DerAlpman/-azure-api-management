using Newtonsoft.Json;

namespace AzureAPIManagement.Models
{
    public class Locomotive
    {
        [JsonProperty(PropertyName = "id")]
        public string ModelRange { get; set; }

        public string Type { get; set; }

        public int Length { get; set; }

        public int ServiceWeight { get; set; }

        public int Vmax { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
