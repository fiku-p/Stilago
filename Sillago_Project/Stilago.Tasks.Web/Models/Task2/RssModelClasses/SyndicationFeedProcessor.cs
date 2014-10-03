using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using WebApplication1.Models.RssModelClasses;

namespace WebApplication1.Models.Task2.RssModelClasses
{
    public static class SyndicationFeedProcessor
    {
        static SyndicationFeedProcessor()
        {
            Syndication = new SyndicationModel();
        }

        public static SyndicationModel Syndication { get; set; }



        public static SyndicationModel ProcessSyndication(SyndicationFeed syndicationFeed)
        {
            if (syndicationFeed != null)
            {
                Syndication.SyndicationItem = syndicationFeed.Items.Select(MapSyndicationItem).ToList();
                return Syndication;
            }
            return new SyndicationModel();
        }

        public static SyndicationItemModel MapSyndicationItem(SyndicationItem syndicationItems)
        {
            return new SyndicationItemModel
            {
                Title = syndicationItems.Title.Text,
                TitleSyndicationLink = MapSyndicationLink(syndicationItems.Links, "alternate"),
                Description = syndicationItems.Summary.Text,
                UploadedDate = syndicationItems.PublishDate,
                SyndicationLink = MapSyndicationLink(syndicationItems.Links, "enclosure")
            };
        }

        public static SyndicationLinkModel MapSyndicationLink(IEnumerable<SyndicationLink> syndicationLink, string relationshipType)
        {
            foreach (var link in syndicationLink)
            {
                if (link.RelationshipType == relationshipType)
                {
                    return new SyndicationLinkModel
                    {
                        Length = link.Length,
                        AbsolutePath = link.Uri.AbsoluteUri,
                        MediaType = link.MediaType,
                        Uri = link.Uri.AbsolutePath
                    };
                }
                if (link.RelationshipType == relationshipType)
                {
                    return new SyndicationLinkModel
                    {
                        Length = link.Length,
                        AbsolutePath = link.Uri.AbsoluteUri,
                        MediaType = link.MediaType,
                        Uri = link.Uri.AbsolutePath
                    };
                }
            }
            return new SyndicationLinkModel();
        }
    }
}