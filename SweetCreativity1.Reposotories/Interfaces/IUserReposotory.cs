using SweetCreativity1.Core.Entities;

namespace SweetCreativity1.Reposotories.Interfaces
{
    public interface IUserReposotory : ISave
    {
        User Get(string id);
        IEnumerable<User> GetAll();
        void Add(User obj);
        void Update(User obj);
        void Delete(User obj);
        //object GetUserById(string? userId);
        void UpdateUser(User user);
        User GetUserById(string? userId);
        //object GetFavoritesByUserId(string? userId);
        //void UpdateUser(User user);


        //int Find(int id);
    }
}