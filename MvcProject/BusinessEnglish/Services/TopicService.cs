﻿namespace BusinessEnglish.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    public class TopicService : IBaseService<Topic>
    {
        private EnglishDbContext db = new EnglishDbContext();

        public void Create(Topic obj)
        {
            db.Topics.Find(obj);
            db.Topics.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var topic = db.Topics.Find(id);

            if (topic == null)
            {
                return;
            }

            db.Topics.Remove(topic);
            db.SaveChanges();
        }

        public Topic Get(int id)
        {
            return db.Topics.Find(id);
        }

        public IEnumerable<Topic> GetAll()
        {
            var topics = db.Topics.OrderBy(x => x.Id).ToList();

            foreach (var topic in topics)
            {
                var sections = (IEnumerable<Section>)db.Sections.Include(s => s.Topic).Where(x => x.TopicId == topic.Id).ToList();
                topic.Sections = sections;
            }

            return topics;
        }

        public void Update(Topic obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Topic> FilterTopicsWithName(IEnumerable<Topic> topics, string name)
        {
            return topics.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}