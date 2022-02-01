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
                    "Auckland"
                },
                OriginAddresses = new[]
                {
                    "Wellington"
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
                                    Text = "Kilometers",
                                    Value = 700
                                },
                                Duration = new Duration
                                {
                                    Text = "Hours",
                                    Value = 10
                                }
                            }
                        }
                    }
                }
            };

            return data;
        }
    }
}
