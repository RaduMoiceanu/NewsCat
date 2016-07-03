using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCat.Web.Models.DTO
{
    [Serializable]
    public class DocumentTag
    {
        public int DocumentTagId { get; set; }

        public int DocumentId { get; set; }

        public Document Document { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int SortKey { get; set; }
    }
}
