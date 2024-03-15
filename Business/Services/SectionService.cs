using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Business.Services
{
    public interface ISectionService
    {
        IQueryable<SectionModel> Query();
        Result Add(SectionModel model);
        Result Update(SectionModel model);
        Result Delete(int id);
    }

    public class SectionService : ISectionService
    {
        private readonly Db _db;

        public SectionService(Db db)
        {
            _db = db;
        }

        // Read
        public IQueryable<SectionModel> Query()
        {
            return _db.Sections.Include(s => s.blogs).OrderBy(s => s.SectionName).Select(s => new SectionModel()
            {
                Id = s.Id,
                SectionName = s.SectionName,
                BlogCountOutput = s.blogs.Count,
                BlogNamesOutput = string.Join("<br />", s.blogs.Select(b => b.Title))
            });
        }

        // Create
        public Result Add(SectionModel model)
        {
            if (_db.Sections.Any(s => s.SectionName.ToLower() == model.SectionName.ToLower().Trim()))
                return new ErrorResult("Section with the same name exists!");

            Section entity = new Section()
            {
                SectionName = model.SectionName.Trim()
            };
            _db.Sections.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Section added successfully.");
        }

        // Update
        public Result Update(SectionModel model)
        {
            if (_db.Sections.Any(s => s.Id != model.Id && s.SectionName.ToLower() == model.SectionName.ToLower().Trim()))
                return new ErrorResult("Section with the same name exists!");

            Section entity = _db.Sections.Find(model.Id);
            if (entity is null)
                return new ErrorResult("Section not found!");

            entity.SectionName = model.SectionName.Trim();
            _db.Sections.Update(entity);
            _db.SaveChanges();
            return new SuccessResult("Section updated successfully.");
        }

        // Delete
        public Result Delete(int id)
        {
            Section entity = _db.Sections.Include(s => s.blogs).SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return new ErrorResult("Section not found!");

            if (entity.blogs is not null && entity.blogs.Any())
                return new ErrorResult("Section can't be deleted because it has related blogs!");

            _db.Sections.Remove(entity);
            _db.SaveChanges();
            return new SuccessResult("Section deleted successfully.");
        }
    }
}
