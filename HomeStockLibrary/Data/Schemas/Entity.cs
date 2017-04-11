﻿using HomeStockLibrary.Data.Schemas.Core;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.UI;
using HomeStockLibrary.Core;
using System.Linq;
using HomeStockLibrary.Exceptions;

namespace HomeStockLibrary.Data.Schemas
{
    [DataContract]
    public class Entity : Validatble, IEntity
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "identityPrefix")]
        public string IdentityPrefix { get; set; }

        [DataMember(Name = "identityLength")]
        public int IdentityLength { get; set; }

        [DataMember(Name = "columns"), PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Column> Columns { get; set; }

        public override void ValidateProperties() {
            Validate(Name, "Name");
            Validate(IdentityPrefix, "IdentityPrefix");
            foreach (var column in Columns)
                column.ValidateProperties();

            List<Column> idendityColumns = Columns.Where(c => c.IdentityColumn == true).ToList();
            if (idendityColumns.Count != 1)
                throw new HomeStockPropertyException("Entity '" + Name + "' must define an identiy column");
        }
    }
}
