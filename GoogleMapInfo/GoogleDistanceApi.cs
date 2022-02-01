using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapInfo
{
    public class GoogleDistanceApi
    {
        public async Task<GoogleDistanceData> GetMapDistance(string originCity, string destinationCity)
        {
            // the web call out to Google
            Thread.Sleep(200);

            GoogleDistanceData data = new GoogleDistanceData
            {
                DestinationAddresses = new[]
                {
                    "Auckland, New Zealand"
                },
                OriginAddresses = new[]
                {
                    "Wellington, New Zealand"
                },
                Rows = new[]
                {
                    new Row
                    {
                        Elements = new Element[]
                        {
                            new Element
                            {
                                Distance = new Distance
                                {
                                    Text = "642 km",
                                    Value = 642000
                                },
                                Duration = new Duration
                                {
                                    Text = "7 hours 49 mins",
                                    Value = 28140
                                },
                                Status = "OK"
                            }
                        }
                    }
                },
                Status = "OK"
            };

            return data;
        }
    }
}
