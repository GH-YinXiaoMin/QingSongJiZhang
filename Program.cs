using QingSongJiZhang.Models;
using QingSongJiZhang.Port;
using QingSongJiZhang.Servieces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DataBaseAttribute>(builder.Configuration.GetSection("DataBaseAttribute"));

builder.Services.AddSingleton<RecordsServieces>();

builder.Services.AddGraphQLServer()
                .AddQueryType<Query>();

builder.Services.AddGraphQLServer()
                .AddMutationType<Mutation>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
app.MapGraphQL();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();
