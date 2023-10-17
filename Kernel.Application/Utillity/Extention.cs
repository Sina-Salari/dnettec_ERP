using Kernel.Domain.Enums;
using Kernel.Domain.Models;
using Kernel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Designer.Infrastructure
{
    public static class Extention
    {
        /// <summary>
        /// For Get All Entity And Entity Field
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static List<Entity> GetEntitySystemFromAssembly(this List<Entity> Data)
        {
            var Entites = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(p => p.BaseType?.Name == Constants.BaseEntity).ToList();

            foreach (var Entity in Entites)
            {
                Entity entity = new Entity()
                {
                    EntityName = Entity.Name,
                    EntityFields = new List<EntityField>(),
                };
                Data.Add(entity);

                foreach (var Field in Entity.GetProperties())
                {
                    if (Field.PropertyType?.BaseType?.Name != Constants.BaseEntity && Field.PropertyType?.BaseType != null)
                    {
                        var SystemType = Field.PropertyType.FullName;

                        Enums.FieldType FieldType = Enums.FieldType.Enum;
                        if (Field.Name.Contains(Constants.Id) && Field.Name != Constants.Id && SystemType.Contains(Constants.Guid))
                        {
                            FieldType = Enums.FieldType.FK;
                        }
                        else if (SystemType.Contains(Constants.Int))
                        {
                            FieldType = Enums.FieldType.Int;
                        }
                        else if (SystemType.Contains(Constants.String))
                        {
                            FieldType = Enums.FieldType.String;
                        }
                        else if (SystemType.Contains(Constants.Guid))
                        {
                            FieldType = Enums.FieldType.Guid;
                        }
                        else if (SystemType.Contains(Constants.Boolean))
                        {
                            FieldType = Enums.FieldType.Boolean;
                        }
                        else if (SystemType.Contains(Constants.DateTime))
                        {
                            FieldType = Enums.FieldType.DateTime;
                        }

                        entity.EntityFields.Add(new EntityField()
                        {
                            EntityId = entity.Id,
                            FieldName = Field.Name,
                            FeildType = FieldType,
                        });
                    }
                }
            }

            //foreach (var item in Data)
            //{
            //    foreach (var FK in item.EntityFields.Where(p => p.FeildType == Enums.FieldType.FK))
            //    {
            //        var Releted = Data.FirstOrDefault(p => p.EntityName ==  FK.FieldName.Replace(Constants.Id,""));
            //        if(Releted == null && FK.FieldName.Replace(Constants.Id, "") == Constants.RelatedEntity)
            //        {
            //            Releted = Data.FirstOrDefault(p => p.EntityName == Constants.Entity);
            //        }
            //        FK. = Releted.Id;
            //    }
            //}

            return Data;
        }


        /// <summary>
        /// Get Base Field => item 1 : Name & item2 : type
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static List<Tuple<string, string>> GetBaseField(this List<Tuple<string, string>> Model)
        {
            var BaseEntites = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(p => p.Name == Constants.BaseEntity).Single();

            foreach (var field in BaseEntites.GetProperties())
            {
                var Type = "";
                var SystemType = field.GetGetMethod().ReturnType.FullName;
                if (SystemType.Contains(Constants.Int))
                {
                    Type = Constants.Int;
                }
                else if (SystemType.Contains(Constants.Guid))
                {
                    Type = Constants.uniqueidentifier;
                }
                else if (SystemType.Contains(Constants.Boolean))
                {
                    Type = Constants.bit;
                }
                else if (SystemType.Contains(Constants.DateTime))
                {
                    Type = Constants.datetime2;
                }
                Model.Add(Tuple.Create(field.Name, Type));
            }

            return Model;
        }
    }
}
