using Microsoft.EntityFrameworkCore;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;
using Task9ASPNetCore.Infrastructure.Busines;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.Infrastructure.Busines.Mapping;
using Task9ASPNetCore.Infrastructure.Data;
using Task9ASPNetCore.Infrastructure.Data.Repositorys;
using Task9ASPNetCore.Services.Interfaces;
using Task9ASPNetCore.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program), typeof(CourseToCourseDTOProfile), typeof(GroupToGroupDTOProfile), typeof(StudentToStudentDTOProfile));


// Add services to the container.
builder.Services.AddControllersWithViews();

//Conect to Db
builder.Services.AddDbContext<DBContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("ConString"));
    });

//Use Dependency injection
builder.Services.AddTransient<IRepository<Course>, CourseRepository>();
builder.Services.AddTransient<IRepository<Group>, GroupRepository>();
builder.Services.AddTransient<IRepository<Student>, StudentRepository>();
builder.Services.AddTransient<IServices<CourseDTO>,CourseServise>();
builder.Services.AddTransient<IServices<GroupDTO>, GroupService>();
builder.Services.AddTransient<IGroupDeleteCheck, GroupService>();
builder.Services.AddTransient<IServices<StudentDTO>, StudentService>();





var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DBContext>();
    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Course}/{action=Index}/{id?}");

app.Run();
