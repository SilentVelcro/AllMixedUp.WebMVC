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

        //CREATE method
        public bool CreateGlaze(GlazeCreate model)
        {
            var entity =
                new Glaze()
                {
                    OwnerId = _userId,
                    UserID = model.UserID,
                    GlazeID = model.GlazeID,
                    GlazeName = model.GlazeName,
                    User = model.User,
                    Description = model.Description,
                    MinimumCone = model.MinimumCone,
                    MaximumCone = model.MaximumCone,
                    Hue = model.Hue,
                    Atmosphere = model.Atmosphere,
                    FinishID = model.finishID,
                    Finish = model.Finish,
                    FoodSafe = model.FoodSafe,
                    CreatedDate = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Glaze.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //ADD Method
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
                                    UserID = e.UserID,
                                    Description = e.Description,
                                    MinimumCone = e.MinimumCone,
                                    MaximumCone = e.MaximumCone,
                                    Hue = e.Hue,
                                    Atmosphere = e.Atmosphere,
                                    Finish = e.Finish,
                                    FoodSafe = e.FoodSafe,
                                }
                        );

                return query.ToArray();
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
                        MinimumCone = entity.MinimumCone,
                        MaximumCone = entity.MaximumCone,
                        Hue = entity.Hue,
                        Atmosphere = entity.Atmosphere,
                        Finish = entity.Finish,
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
                        .Single(e => e.UserID == model.GlazeID && e.OwnerId == _userId);

                entity.GlazeName = model.GlazeName;
                entity.Description = model.Description;
                entity.MinimumCone = model.MinimumCone;
                entity.MaximumCone = model.MaximumCone;
                entity.Hue = model.Hue;
                entity.Atmosphere = model.Atmosphere;
                entity.FoodSafe = model.FoodSafe;
                entity.FinishID = model.FinishID;
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
                        .Single(e => e.UserID == glazeID && e.OwnerId == _userId);

                ctx.Glaze.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
