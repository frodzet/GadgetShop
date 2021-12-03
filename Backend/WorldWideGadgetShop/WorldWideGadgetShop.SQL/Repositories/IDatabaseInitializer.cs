namespace WorldWideGadgetShop.SQL.Repositories
{
    public interface IDatabaseInitializer
    {
        void SeedDatabase(DBContext ctx);
    }
}