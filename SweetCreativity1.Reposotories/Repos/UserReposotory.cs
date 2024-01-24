using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SweetCreativity1.Reposotories.Repos
{
    public class UserReposotory : IUserReposotory
    {
        private SweetCreativity1Context _context;
        public UserReposotory(SweetCreativity1Context context)
        {
            _context = context;
        }
        public void Add(User obj)
        {
            _context.Users.Add(obj);
            Save();
        }

        public void Delete(User obj)
        {
            _context.Set<User>().Remove(obj);
            Save();
        }

        public User Get(string id)
        {
            return _context.Users.Find(id);
        }


        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(string? userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            Save(); // Assuming there is a Save method in your repository to save changes
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _context.Users.Update(obj);
        }
    }
}