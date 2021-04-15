using AllMixedUp.Data;
using AllMixedUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Services
{
    public class MaterialService
    {
        private readonly Guid _userId;
        public MaterialService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE method
        public bool CreateMaterial(MaterialCreate model)
        {
            var entity =
                new Material()
                {
                    OwnerId = _userId,
                    MaterialID = model.MaterialID,
                    MaterialName = model.MaterialName,
                    HealthHazard = model.HealthHazard,
                    CreatedDate = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Material.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //ADD Method
        public IEnumerable<MaterialListItem> GetMaterial()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Material
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MaterialListItem
                                {
                                    //UserID = e.UserID,
                                    //UserName = e.FirstName + " " + e.LastName,
                                    //Email = e.Email,
                                    CreatedDate = e.CreatedDate
                                }
                        );

                return query.ToArray();
            }
        }

        //Detail 
        public UserDetail GetMaterialById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Material
                        .Single(e => e.MaterialID == id && e.OwnerId == _userId);
                return
                    new UserDetail
                    {
                        //UserID = entity.UserID,
                        //FirstName = entity.FirstName,
                        //LastName = entity.LastName,
                        //Email = entity.Email,
                        CreatedDate = entity.CreatedDate,
                        ModifiedDate = entity.ModifiedDate
                    };
            }
        }

        //UPDATE
        public bool UpdateMaterial(MaterialEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Material
                        .Single(e => e.MaterialID == model.MaterialID && e.OwnerId == _userId);

                //entity.FirstName = model.FirstName;
                //entity.LastName = model.LastName;
                //entity.Email = model.Email;
                entity.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteMaterial(int materialID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Material
                        .Single(e => e.MaterialID == materialID && e.OwnerId == _userId);

                ctx.Material.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
