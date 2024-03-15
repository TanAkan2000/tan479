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
    public interface IUserService
    {
        IQueryable<UserModel> Query();
        Result Add(UserModel model);
        Result Update(UserModel model);
        Result Delete(int id);

        List<UserModel> GetList();
        UserModel GetItem(int id);
    }

    public class UserService : IUserService
    {
        private readonly Db _db;

        public UserService(Db db)
        {
            _db = db;
        }

        public IQueryable<UserModel> Query()
        {
            return _db.Users.OrderBy(u => u.UserName).Select(u => new UserModel
            {
                Id = u.Id,
                UserName = u.UserName,
                AuthorType = u.AuthorType,
                BirthDate = u.BirthDate,
                Email = u.Email,
                Password = u.Password,
                IsAuthor = u.IsAuthor,
                BirthDateOutput = u.BirthDate.ToString("MM/dd/yyyy"),
                EmailOutput = u.Email,
                PasswordOutput = u.Password,
                IsAuthorOutput = u.IsAuthor ? "Yes" : "No"
            });
        }

        public Result Add(UserModel model)
        {
            User entity = new User
            {
                UserName = model.UserName.Trim(),
                AuthorType = model.AuthorType,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Password = model.Password,
                IsAuthor = model.IsAuthor
            };

            _db.Users.Add(entity);
            _db.SaveChanges();

            model.Id = entity.Id;

            return new SuccessResult();
        }

        public Result Update(UserModel model)
        {
            User entity = _db.Users.Find(model.Id);
            if (entity is null)
                return new ErrorResult("User not found!");

            entity.UserName = model.UserName.Trim();
            entity.AuthorType = model.AuthorType;
            entity.BirthDate = model.BirthDate;
            entity.Email = model.Email;
            entity.Password = model.Password;
            entity.IsAuthor = model.IsAuthor;

            _db.Users.Update(entity);
            _db.SaveChanges();

            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            User entity = _db.Users.Find(id);
            if (entity is null)
                return new ErrorResult("User not found!");

            _db.Users.Remove(entity);
            _db.SaveChanges();

            return new SuccessResult();
        }

        public List<UserModel> GetList() => Query().ToList();

        public UserModel GetItem(int id) => Query().SingleOrDefault(q => q.Id == id);
    }
}
