using AllMixedUp.Data;
using AllMixedUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Services
{
    public class FinishService
    {
        private readonly Guid _userId;
        public FinishService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE method
        public bool CreateFinish(FinishCreate model)
        {
            var entity =
                new Finish()
                {
                    OwnerId = _userId,
                    FinishID = model.FinishID,
                    Op = model.Opacity,
                    Surf = model.Surface,
                    CreatedDate = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Finish.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //ADD Method
        public IEnumerable<FinishListItem> GetFinish()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Finish
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FinishListItem
                                {
                                    FinishID = e.FinishID,
                                    Op = e.Op,
                                    Surf = e.Surf,
                                    CreatedDate = e.CreatedDate
                                }
                        );

                return query.ToArray();
            }
        }

        //Detail 
        public FinishDetail GetFinishById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Finish
                        .Single(e => e.FinishID == id && e.OwnerId == _userId);
                return
                    new FinishDetail
                    {
                        FinishID = entity.FinishID,
                        Opacity = entity.Op,
                        Surface = entity.Surf,
                        CreatedDate = entity.CreatedDate,
                        ModifiedDate = entity.ModifiedDate
                    };
            }
        }

        //UPDATE
        public bool UpdateFinish(FinishEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Finish
                        .Single(e => e.FinishID == model.FinishID && e.OwnerId == _userId);

                entity.FinishID = model.FinishID;
                entity.Op = model.Opacity;
                entity.Surf = model.Surface;
                entity.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteFinish(int finishID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Finish
                        .Single(e => e.FinishID == finishID && e.OwnerId == _userId);

                ctx.Finish.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
