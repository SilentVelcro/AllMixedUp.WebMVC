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
                    MaterialName = model.MaterialName,
                    HealthHazard = model.HealthHazard,
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
                        .Where(e => e.MaterialID == e.MaterialID)
                        .Select(
                            e =>
                                new MaterialListItem
                                {
                                    MaterialID = e.MaterialID,
                                    MaterialName = e.MaterialName,
                                    HealthHazard = e.HealthHazard,
                                }
                        );

                return query.ToArray();
            }
        }

        //Detail 
        public MaterialDetail GetMaterialById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Material
                        .Single(e => e.MaterialID == id);
                return
                    new MaterialDetail
                    {
                        MaterialID = entity.MaterialID,
                        MaterialName = entity.MaterialName,
                        HealthHazard = entity.HealthHazard,
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
                        .Single(e => e.MaterialID == model.MaterialID);

                entity.MaterialName = model.MaterialName;
                entity.HealthHazard = model.HealthHazard;

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
                        .Single(e => e.MaterialID == materialID);

                ctx.Material.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
