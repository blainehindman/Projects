namespace CodeWidgitCore.Models
{
    public class WidgitFeedViewModel
    {
  
        public Guid WidgitId { get; set; }

        public string WidgitName { get; set; } = null!;

        public string WidgitDescription { get; set; } = null!;

        public string CreatorId { get; set; } = null!;
  
        public string CreatorUsername { get; set; } = null!;
    
        public string PublishedDate { get; set; } = null!;

        public string UpdatedDate { get; set; } = null!;

        public int WidgitDownloads { get; set; }

        public double? WidgitRating { get; set; }
        public int WidgitRatingTotal { get; set; }
        public int WidgitRatingsCount { get; set; }
        public int WidgitViews { get; set; }

        public int WidgitLikesCount { get; set; }

        public int WidgitCommentsCount { get; set; }

        public Guid WidgitFileId { get; set; }

        public string WidgitFile { get; set; } = null!;
    }
}
