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

        public IEnumerable<GlazeListItem> GetAllGlazes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Glaze.Where(e=> e.OwnerId == _userId)
                        .Select(
                            e =>
                               new GlazeListItem
                                {
                                    GlazeID = e.GlazeID,
                                    GlazeName = e.GlazeName,
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<IngredientListItem> GetAllIngredientsByGlazeID(int glazeID)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
                    ctx.Glaze.Single(g => g.GlazeID == glazeID).ListOfIngredients
                    .Select(e => new IngredientListItem
                    {
                        MaterialName = e.Material.MaterialName,
                        Quantity = e.Quantity,
                    }
                     );
                return foundItems.ToArray();
            }
        }


        //CREATE method
        public bool CreateGlaze(GlazeCreate model)
        {
            var entity =
                new Glaze()
                {
                    OwnerId = _userId,
                    GlazeName = model.GlazeName,
                    Description = model.Description,
                    MinCone = model.MinCone,
                    MaxCone = model.MaxCone,
                    Opacity = model.Opacity,
                    Surface = model.Surface,
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
                var ingList = new List<IngredientDetail>();
                var entity = ctx
                                .Glaze
                                .Single(e => e.GlazeID == id && e.OwnerId == _userId);
                foreach (Ingredient ingredient in entity.ListOfIngredients)
                {
                    var ing = new IngredientDetail();
                    ing.MaterialName = ingredient.Material.MaterialName;
                    ing.Quantity = ingredient.Quantity;

                    ingList.Add(ing);
                }
                return
                    new GlazeDetail
                    {
                        GlazeID = entity.GlazeID,
                        GlazeName = entity.GlazeName,
                        Description = entity.Description,
                        MinCone = entity.MinCone,
                        MaxCone = entity.MaxCone,
                        MainColor = entity.MainColor,
                        Atmosphere = entity.Atmosphere,
                        Opacity = entity.Opacity,
                        Surface = entity.Surface,
                        FoodSafe = entity.FoodSafe,
                        CreatedDate = entity.CreatedDate,
                        ModifiedDate = entity.ModifiedDate,
                        IngredientList = ingList,
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
                        .SingleOrDefault(e => e.OwnerId == _userId);

                entity.GlazeName = model.GlazeName;
                entity.Description = model.Description;
                entity.ListOfIngredients = (ICollection<Ingredient>)model.IngredientList;
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
