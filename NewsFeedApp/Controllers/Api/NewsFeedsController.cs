using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsFeedApplication.Models;

namespace NewsFeedApplication.Controllers
{
    public class NewsFeedsController : ApiController
    {
        private static readonly INewsFeedRepository _newsfeeds = new NewsFeedRepository();
        // GET api/<controller>
        public IEnumerable<NewsFeed> Get()
        {
            return _newsfeeds.GetAll();
        }

        // GET api/<controller>/5
        public NewsFeed Get(int id)
        {
            NewsFeed c = _newsfeeds.Get(id);
            if (c == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return c;
        }

        // POST api/<controller>
        public NewsFeed Post(NewsFeed newsfeed)
        {
            return _newsfeeds.Add(newsfeed);

        }

        // PUT api/<controller>/5
        public NewsFeed Put(NewsFeed newsfeed)
        {
            if (!_newsfeeds.Update(newsfeed))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return newsfeed;

        }

        // DELETE api/<controller>/5
        public NewsFeed Delete(int id)
        {
            NewsFeed c = _newsfeeds.Get(id);
            _newsfeeds.Remove(id);
            return c;
        }
    }
}