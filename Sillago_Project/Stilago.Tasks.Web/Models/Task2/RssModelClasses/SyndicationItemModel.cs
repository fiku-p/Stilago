using System;

namespace WebApplication1.Models.RssModelClasses
{
    public class SyndicationItemModel
    {
        public string Title { get; set; }
        public SyndicationLinkModel TitleSyndicationLink { get; set; }
        public DateTimeOffset UploadedDate { get; set; }
        public string Description { get; set; }
        public SyndicationLinkModel SyndicationLink { get; set; }
    }
}