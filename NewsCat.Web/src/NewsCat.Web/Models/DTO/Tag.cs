using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCat.Web.Models.DTO
{
    [Serializable]
    public class Tag
    {
        public int TagId { get; set; }

        public string Name { get; set; }


        public List<Feed> Feeds { get; set; }

        public List<Document> Documents { get; set; }


        public Tag()
        {
        }
    }
}
