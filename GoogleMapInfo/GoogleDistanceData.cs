﻿namespace GoogleMapInfo
{
    public class GoogleDistanceData
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