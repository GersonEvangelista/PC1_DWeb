// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<StoreDbContext>
    (options => options.UseSqlServer(cnx));


//AQUI VAN TODAS LAS INTERFACES IMPLEMENTADAS EN EL PROYECTO
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();