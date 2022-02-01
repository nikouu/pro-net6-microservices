using Grpc.Net.Client;
using microservice_map_info.Protos;

var channel = GrpcChannel.ForAddress(new Uri("https://localhost:7170"));
var client = new DistanceInfo.DistanceInfoClient(channel);
var response = await client.GetDistanceAsync(new Cities { OriginCity = "Auckland, New Zealand", DestinationCity = "Wellington, New Zealand" });

Console.WriteLine(response.Kilometers);

Console.Read();