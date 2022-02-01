using GoogleMapInfo;
using Grpc.Core;
using microservice_map_info.Protos;

namespace microservice_map_info.Services
{
    public class DistanceInfoService
    {
        private readonly ILogger<DistanceInfoService> _logger;
        private readonly GoogleDistanceApi _googleDistanceApi;

        public DistanceInfoService(ILogger<DistanceInfoService> logger, GoogleDistanceApi googleDistanceApi)
        {
            _logger = logger;
            _googleDistanceApi = googleDistanceApi;
        }

        public async Task<DistanceData> GetDistance(Cities cities, ServerCallContext context)
        {
            var totalKilometers = "0";
            var distanceData = _googleDistanceApi.GetMapDistance(cities.OriginCity, cities.DestinationCity);

            //foreach (var distanceDataRow in distanceData.rows)
            //{
            //    foreach (var element in distanceDataRow.elements)
            //    {
            //        totalKilometers = element.distance.text;
            //    }

            //}

            return new DistanceData { Kilometers = totalKilometers };
        }
    }
}
