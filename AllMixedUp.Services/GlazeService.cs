using AllMixedUp.Data;
using AllMixedUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Services
{
    public class GlazeService
    {
        private readonly Guid _userId;
        public GlazeService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<GlazeListItem> GetGlaze()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Glaze
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GlazeListItem
                                {
                                    GlazeID = e.GlazeID,
                                    GlazeName = e.GlazeName,
                                    UserID = (int)e.UserID,
                                    Description = e.Description,
                                    IngredientList = e.IngredientList,
                                    MinCone = e.MinCone,
                                    MaxCone = e.MaxCone,
                                    MainColor = e.MainColor,
                                    Atmosphere = e.Atmosphere,
                                    FoodSafe = e.FoodSafe,
                                }
                        );

                return query.ToArray();
            }
        }


        //CREATE method
        public bool CreateGlaze(GlazeCreate model)
        {
            var entity =
                new Glaze()
                {
                    OwnerId = _userId,
                    GlazeID = model.GlazeID,
                    GlazeName = model.GlazeName,
                    User = model.User,
                    Description = model.Description,
                    IngredientList = model.IngredientList,
                    MinCone = model.MinCone,
                    MaxCone = model.MaxCone,
                    MainColor = model.MainColor,
                    Atmosphere = model.Atmosphere,
                    FoodSafe = model.FoodSafe,
                    CreatedDate = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Glaze.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Detail 
        public GlazeDetail GetGlazeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Glaze
                        .Single(e => e.GlazeID == id && e.OwnerId == _userId);
                return
                    new GlazeDetail
                    {
                        GlazeID = entity.GlazeID,
                        GlazeName = entity.GlazeName,
                        User = entity.User.LastName,
                        Description = entity.Description,
                        IngredientList = entity.IngredientList,
                        MinCone = entity.MinCone,
                        MaxCone = entity.MaxCone,
                        MainColor = entity.MainColor,
                        Atmosphere = entity.Atmosphere,
                        FoodSafe = entity.FoodSafe,
                        CreatedDate = entity.CreatedDate,
                        ModifiedDate = entity.ModifiedDate
                    };
            }
        }

        //UPDATE
        public bool UpdateGlaze(GlazeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Glaze
                        .SingleOrDefault(e => e.UserID == model.GlazeID && e.OwnerId == _userId);

                entity.GlazeName = model.GlazeName;
                entity.Description = model.Description;
                entity.IngredientList = model.IngredientList;
                entity.MinCone = model.MinCone;
                entity.MaxCone = model.MaxCone;
                entity.MainColor = model.MainColor;
                entity.Atmosphere = model.Atmosphere;
                entity.Surface = model.Surface;
                entity.Opacity = model.Opacity;
                entity.FoodSafe = model.FoodSafe;
                entity.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteGlaze(int glazeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Glaze
                        .Single(e => e.GlazeID == glazeID && e.OwnerId == _userId);

                ctx.Glaze.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
