namespace MovieAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<SearchModel> SearchModels { get; set; }
    }
}
