namespace microservice_map_info.Services
{
    public class QuoteSvc
    {
        private readonly IDistanceInfoSvc _distanceInfoSvc;
        public QuoteSvc(IDistanceInfoSvc distanceInfoSvc)
        {
            _distanceInfoSvc = distanceInfoSvc;
        }
    }
}
