using AllMixedUp.Data;
using AllMixedUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;
        public IngredientService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE method
        public bool CreateIngredient(IngredientCreate model)
        {

            var entity =
                new Ingredient()
                {
                    OwnerId = _userId,
                    MaterialID = model.MaterialID,
                    Quantity = model.Quantity,
                    CreatedDate = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredient.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //ADD Method
        public IEnumerable<IngredientListItem> GetIngredient()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredient
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientID = e.IngredientID,
                                    MaterialID = e.MaterialID,
                                    Name = e.Material.MaterialName,
                                    Quantity = e.Quantity,
                                }
                        );

                return query.ToArray();
            }
        }

        //Detail 
        public IngredientDetail GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredient
                        .Single(e => e.IngredientID == id && e.OwnerId == _userId);
                return
                    new IngredientDetail
                    {
                        IngredientID = entity.IngredientID,
                        Name = entity.Material.MaterialName,
                        Quantity = entity.Quantity,
                    };
            }
        }

        //UPDATE
        public bool UpdateIngredient(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredient
                        .Single(e => e.IngredientID == model.IngredientID && e.OwnerId == _userId);

                entity.Quantity = model.Quantity;
                entity.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteIngredient(int ingredientID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredient
                        .Single(e => e.IngredientID == ingredientID && e.OwnerId == _userId);

                ctx.Ingredient.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddIngredientToGlaze(int id, IngredientCreate model)
        {
            var newIngredient = new Ingredient()
            {
             OwnerId = _userId,
             MaterialID = model.MaterialID,
             Quantity = model.Quantity,
             CreatedDate = DateTimeOffset.Now
            };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredient.Add(newIngredient);

                var entity =
                    ctx
                        .Glaze
                        .Single(e => e.GlazeID == id);

                entity.IngredientList.Add(newIngredient);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
