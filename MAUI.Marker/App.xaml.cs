using Library.Marker.Database;


namespace MAUI.Marker
{
    public partial class App : Application
    {
        private readonly AppDbContext _dbContext;
        
        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            MainPage = new AppShell();
        }

        private void InitializeDatabase()
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

    }
}
