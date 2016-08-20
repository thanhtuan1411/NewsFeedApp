using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsFeedApplication.Models
{
    public class NewsFeed
    {
        [Key]
        public int NewsFeedID { get; set; }       
        public string NewsFeedText { get; set; }       
        public DateTime PublicationDate { get; set; }

    }
}