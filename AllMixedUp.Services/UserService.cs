using AllMixedUp.Data;
using AllMixedUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Services
{
    public class UserService
    {
        private readonly Guid _userId;
        public UserService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    CreatedDate = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .User
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserID = e.UserID,
                                    UserName = e.FirstName + " " + e.LastName,
                                    Email = e.Email,
                                    CreatedDate = e.CreatedDate
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
