using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DatabaseLibrary.Abstract;
using DatabaseLibrary.Config;
using DatabaseLibrary.Conrete.Dto;
using DatabaseLibrary.Conrete.Entities;
using DatabaseLibrary.Infrastructure;

namespace ConsoleDebugApplication
{
    class Program
    {
        static Program()
        {
            AutoMapperConfig.Initialize();
        }

        static void Main(string[] args)
        {
            //ImportCsvData();

            var lines = File.ReadAllLines(@"..\..\MOCK_DATA.csv");
            var users = lines.Skip(1).AsQueryable().ProjectTo<User>();
            using (IUserRepository repository = new EfUserRepository())
            {
                var task = repository.InsertManyAsync(users);
                task.Wait();
            }

        }

        static void Test()
        {
            using (var ctx = new ChallengeDbContext())
            {
                var dtos = ctx.Users.ProjectTo<UserDto>().ToList();

                foreach (var userDto in dtos)
                {
                    Console.WriteLine($"{userDto.FirstName} {userDto.Salary} {userDto.SalaryRatio}");
                }
            }
        }

        static void ImportCsvData()
        {
            var lines = File.ReadAllLines(@"..\..\MOCK_DATA.csv");
            using (var ctx = new ChallengeDbContext())
            {
                foreach (var line in lines.Skip(1))
                {
                    var split = line.Split(',');
                    var user = new User
                    {
                        FirstName = split[0],
                        LastName = split[1],
                        Phone = split[2],
                        Salary = decimal.Parse(split[3], CultureInfo.InvariantCulture)
                    };
                    ctx.Users.Add(user);
                }
                ctx.SaveChanges();
            }
        }
    }
}
