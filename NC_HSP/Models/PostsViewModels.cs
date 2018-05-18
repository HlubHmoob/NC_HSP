using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NC_HSP.Models
{
    public class PostsViewModels
    {
        public int Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string Title { get; set; }

        [AllowHtml]
        public string BodyText { get; set; }
        public string MediaUrl { get; set; }
    }
}