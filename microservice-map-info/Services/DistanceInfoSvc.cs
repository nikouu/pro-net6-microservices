using System.Text.Json;

// 🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔🤔
namespace microservice_map_info.Services
{
    public interface IDistanceInfoSvc
    {
        Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity);
    }

    public class DistanceInfoSvc : IDistanceInfoSvc
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DistanceInfoSvc(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(int, string)> GetDistanceAsync(string originCity, string destinationCity)
        {
            var httpClient = _httpClientFactory.CreateClient("DistanceMicroservice");
            var microserviceUrl = $"?originCity={originCity}&destinationCity={destinationCity}";

            var responseStream = await httpClient.GetStreamAsync(microserviceUrl);
            
            var distanceData = await JsonSerializer.DeserializeAsync<MapDistanceInfo>(responseStream);

            var distance = 0;
            var distanceType = "";

            foreach (var row in distanceData.Rows)
            {
                foreach (var rowElement in row.Elements)
                {
                    if (int.TryParse(CleanDistanceInfo(rowElement.Distance.Text), out var distanceConverted))
                    {
                        distance += distanceConverted;
                        if (rowElement.Distance.Text.EndsWith("mi"))
                        {
                            distanceType = "miles";
                        }

                        if (rowElement.Distance.Text.EndsWith("km"))
                        {
                            distanceType = "kilometers";
                        }
                    }
                }
            }

            return (distance, distanceType);
        }

        private string CleanDistanceInfo(string value)
        {
            return value
                .Replace("mi", "")
                .Replace("mi", "")
                .Replace(",", "");
        }
    }

    public class MapDistanceInfo
    {
        public string[] DestinationAddresses { get; set; }
        public string[] OriginAddresses { get; set; }
        public Row[] Rows { get; set; }
        public string Status { get; set; }
    }

    public class Row
    {
        public Element[] Elements { get; set; }
    }

    public class Element
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public string Status { get; set; }
    }

    public class Distance
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

    public class Duration
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
