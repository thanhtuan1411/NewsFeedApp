using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NewsFeedApplication.Models
{
    public interface INewsFeedRepository
    {
        IEnumerable<NewsFeed> GetAll();
        NewsFeed Get(int id);
        NewsFeed Add(NewsFeed item);
        void Remove(int id);
        bool Update(NewsFeed item);
    }
    public class NewsFeedRepository : INewsFeedRepository
    {
        private readonly NewsFeedContext _db;

        public NewsFeedRepository()
        {
            _db = new NewsFeedContext();
        }

        public IEnumerable<NewsFeed> GetAll()
        {
            return _db.NewsFeeds;
        }

        public NewsFeed Get(int id)
        {
            return _db.NewsFeeds.Find(id);
        }

        public NewsFeed Add(NewsFeed newsfeed)
        {
            _db.NewsFeeds.Add(newsfeed);
            _db.SaveChanges();
            return newsfeed;
        }

        public void Remove(int id)
        {
            NewsFeed newsfeed = _db.NewsFeeds.Find(id);
            _db.NewsFeeds.Remove(newsfeed);
            _db.SaveChanges();
        }

        public bool Update(NewsFeed item)
        {
            NewsFeed newNewsFeed =_db.NewsFeeds.Find(item.NewsFeedID);
            if (newNewsFeed == null)
                return false;

            newNewsFeed.PublicationDate = item.PublicationDate.Date;
            newNewsFeed.NewsFeedText = item.NewsFeedText;
            _db.SaveChanges();
            return true;
        }

    }
}