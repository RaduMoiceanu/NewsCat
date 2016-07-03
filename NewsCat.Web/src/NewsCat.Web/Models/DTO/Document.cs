using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCat.Web.Models.DTO
{
    [Serializable]
    public class Document
    {
        public int DocumentId { get; set; }

        public int FeedId { get; set; }

        public Feed Feed { get; set; }

        public DateTime ImportDate { get; set; }

        public string RawContent { get; set; }

        public string Content { get; set; }

        public bool IsNew { get; set; } = true;

        public bool IsRead { get; set; } = false;

        public DateTime? ReadDate { get; set; }


        public List<DocumentTag> Tags { get; set; }


        public Document()
        {
        }
    }
}
