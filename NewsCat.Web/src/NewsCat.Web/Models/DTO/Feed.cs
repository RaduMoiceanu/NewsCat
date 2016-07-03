using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCat.Web.Models.DTO
{
    [Serializable]
    public class Feed
    {
        public int FeedId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime CreateDate { get; set; }

        public int SortKey { get; set; }

        public bool IsActive { get; set; } = true;


        public List<Document> Documents { get; set; }

        public List<FeedTag> Tags { get; set; }


        public Feed()
        {
        }
    }
}
