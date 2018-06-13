using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLibrary.Conrete.Dto;
using DatabaseLibrary.Conrete.Entities;

namespace DatabaseLibrary.Config
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<User, UserDto>().
                    ForMember(source => source.Id, expr => expr.MapFrom(_ => _.Id)).
                    ForMember(source => source.FirstName, expr => expr.MapFrom(_ => _.FirstName)).
                    ForMember(source => source.LastName, expr => expr.MapFrom(_ => _.LastName)).
                    ForMember(source => source.Phone, expr => expr.MapFrom(_ => _.Phone)).
                    ForMember(source => source.Salary, expr => expr.MapFrom(_ => _.Salary)).
                    ForMember(source => source.SalaryRatio, expr => expr.MapFrom(_ => _.SalaryRatio));

                config.CreateMap<UserDto, User>().
                    ForMember(source => source.Id, expr => expr.MapFrom(_ => _.Id)).
                    ForMember(source => source.FirstName, expr => expr.MapFrom(_ => _.FirstName)).
                    ForMember(source => source.LastName, expr => expr.MapFrom(_ => _.LastName)).
                    ForMember(source => source.Phone, expr => expr.MapFrom(_ => _.Phone)).
                    ForMember(source => source.Salary, expr => expr.MapFrom(_ => _.Salary));

                config.CreateMap<string, User>()
                    .ForMember(source => source.FirstName, expr => expr.MapFrom(_ => _.Split(',')[0]))
                    .ForMember(source => source.LastName, expr => expr.MapFrom(_ => _.Split(',')[1]))
                    .ForMember(source => source.Phone, expr => expr.MapFrom(_ => _.Split(',')[2]))
                    .ForMember(source => source.Salary, expr => expr.MapFrom(_ => decimal.Parse(_.Split(',')[3], CultureInfo.InvariantCulture)));

            });

        }
    }
}
