using Microsoft.EntityFrameworkCore;
using Task9ASPNetCore.Domain.Core;

namespace Task9ASPNetCore.Infrastructure.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course[]
                {
                    new Course{Id =3, Name = "C#",Description =" Learn C# Lenguage"},
                    new Course{Id =4, Name = "Java",Description =" Learn Java Lenguage"},
                    new Course{Id =5, Name = "Python",Description =" Learn Python Lenguage"},
                    new Course{Id =6, Name = "Ruby",Description =" Learn Ruby Lenguage"},
                    new Course{Id =7, Name = "SQL",Description =" Learn SQL Lenguage"},
                });

            modelBuilder.Entity<Group>().HasData(
                new Group[]
                {
                    new Group{Id =11, CourseId=3,Name = "SR-01"},
                    new Group{Id =2, CourseId=3,Name = "SR-02"},
                    new Group{Id =3, CourseId=4,Name = "SR-03"},
                    new Group{Id =4, CourseId=4,Name = "SR-04"},
                    new Group{Id =5, CourseId=5,Name = "SR-05"},
                    new Group{Id =6, CourseId=5,Name = "SR-06"},
                    new Group{Id =7, CourseId=6,Name = "SR-07"},
                    new Group{Id =8, CourseId=6,Name = "SR-08"},
                    new Group{Id =9, CourseId=7,Name = "SR-09"},
                    new Group{Id =10, CourseId=7,Name = "SR-10"},
                }); ;

            modelBuilder.Entity<Student>().HasData(
                new Student[]
                {
                    new Student{Id =2, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =3, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =4, GroupId=3, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =5, GroupId=3, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =6, GroupId=5, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},

                    new Student{Id =7, GroupId=5, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =8, GroupId=6, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},

                    new Student{Id =9, GroupId=6, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =10, GroupId=7, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =11, GroupId=7, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =12, GroupId=9, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =13, GroupId=9, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =14, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =15, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =16, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =17, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =18, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =19, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =20, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                    new Student{Id =21, GroupId=11, FirstName ="Oleh", LastName =" rynt", Patronymic ="Olehovich"},
                });

        }
    }
}