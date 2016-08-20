using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NewsFeedApplication.Models
{
    public class NewsFeedContext : DbContext
    {
        public DbSet<NewsFeed> NewsFeeds { get; set; }
       
    }
  
    
}