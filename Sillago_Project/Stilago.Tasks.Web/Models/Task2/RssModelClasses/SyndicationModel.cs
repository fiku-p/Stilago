﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models.RssModelClasses
{
    public class SyndicationModel
    {
        public SyndicationModel()
        {
            SyndicationItem = new List<SyndicationItemModel>();
        }

        public string Title { get; set; }
        public string Link { get; set; }
        public string Copyright { get; set; }
        public DateTime LastBuildDate { get; set; }
        public List<SyndicationItemModel> SyndicationItem { get; set; }
    }
}
