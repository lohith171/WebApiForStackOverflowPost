using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<StackOverflowPost> list = new List<StackOverflowPost>();

        public ValuesController()
        {
        }

        [Route("api/values")]
        [HttpGet]
        public List<StackOverflowPost> myList()
        {
            return list;
        }

        [Route("api/values/{title}")]
        [HttpGet]
        public StackOverflowPost getPost(string title)
        {
            StackOverflowPost obj = list.FirstOrDefault(x => x.getTitle() == title);
            if (obj != null) return obj;
            return null;
        }

        [Route("api/values/{title}/{description}")]
        [HttpPost]
        public StackOverflowPost PostNewpost(string title, string description)
        {
            StackOverflowPost obj = new StackOverflowPost(title, description);
            var ob = list.FirstOrDefault(x => x.getTitle() == title);
            if (ob == null)
            {
                list.Add(obj);
                return obj;
            }
            return null;

        }
        [Route("api/values/{title}/increase")]
        [HttpPut]
        public StackOverflowPost UpVoteAPost(string title)
        {
            StackOverflowPost obj = list.FirstOrDefault(x => x.getTitle() == title);
            if (obj != null)
            {
                obj.UpVote();
                return obj;
            }
            return null;
        }
        [Route("api/values/{title}/decrease")]
        [HttpPut]
        public StackOverflowPost DownVoteAPost(string title)
        {
            StackOverflowPost obj = list.FirstOrDefault(x => x.getTitle() == title);
            if (obj != null)
            {
                obj.DownVote();
                return obj;
            }
            return null;
        }

    }
}