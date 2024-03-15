using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public interface IBlogService
    {
        IQueryable<BlogModel> Query();
        Result Add(BlogModel model);
        Result Update(BlogModel model);
        Result Delete(int id);

        List<BlogModel> GetList();
        BlogModel GetItem(int id);
    }

    public class BlogService : IBlogService
    {
        private readonly Db _db;

        public BlogService(Db db)
        {
            _db = db;
        }

        public IQueryable<BlogModel> Query()
        {
            return _db.Blogs.OrderBy(b => b.Title).Select(b => new BlogModel
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                PublishedAt = b.PublishedAt,
                ContentOutput = b.Content,
                PublishedAtOutput = b.PublishedAt.ToString("MM/dd/yyyy")
            });
        }

        public Result Add(BlogModel model)
        {
            Blog entity = new Blog
            {
                Title = model.Title.Trim(),
                Content = model.Content,
                PublishedAt = model.PublishedAt
            };

            _db.Blogs.Add(entity);
            _db.SaveChanges();

            model.Id = entity.Id;

            return new SuccessResult();
        }

        public Result Update(BlogModel model)
        {
            Blog entity = _db.Blogs.Find(model.Id);
            if (entity is null)
                return new ErrorResult("Blog not found!");

            entity.Title = model.Title.Trim();
            entity.Content = model.Content;
            entity.PublishedAt = model.PublishedAt;

            _db.Blogs.Update(entity);
            _db.SaveChanges();

            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            Blog entity = _db.Blogs.Find(id);
            if (entity is null)
                return new ErrorResult("Blog not found!");

            _db.Blogs.Remove(entity);
            _db.SaveChanges();

            return new SuccessResult();
        }

        public List<BlogModel> GetList() => Query().ToList();

        public BlogModel GetItem(int id) => Query().SingleOrDefault(q => q.Id == id);
    }
}
