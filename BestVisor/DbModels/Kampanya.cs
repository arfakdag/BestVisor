using System;
using System.Collections.Generic;

namespace BestVisor.DbModels
{
    public partial class Kampanya
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string CampaignSms { get; set; }
        public string CampaignDesc { get; set; }
        public string SektorList { get; set; }
    }
}
