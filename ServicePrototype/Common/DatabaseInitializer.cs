using System.Data.Entity;

namespace ServicePrototype.Common
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<PrototypeContext>
    {
        protected override void Seed(PrototypeContext context)
        {
            base.Seed(context);
        }
    }
}
