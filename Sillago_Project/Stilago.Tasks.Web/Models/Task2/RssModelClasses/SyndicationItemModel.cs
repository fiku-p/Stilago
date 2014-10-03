using System;

namespace Stilago.Tasks.Web.Models.Task2.RssModelClasses
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