using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseTableInsert
{
    public class EntityRepository
    {
        private readonly DatabaseContext _dbcontext;

        public EntityRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void InsertData(Entity entity)
        {
            _dbcontext.Entities.Add(entity);
            _dbcontext.SaveChanges();
        }
    }
}
