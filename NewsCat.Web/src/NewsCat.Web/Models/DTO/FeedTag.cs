using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCat.Web.Models.DTO
{
    [Serializable]
    public class FeedTag
    {
        public int FeedTagId { get; set; }

        public int FeedId { get; set; }

        public Feed Feed { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int SortKey { get; set; }
    }
}
