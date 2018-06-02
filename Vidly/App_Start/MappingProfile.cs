using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<MemberShipType, MemberShipTypeDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>()
                .ForMember(cdto => cdto.MemberShipTypeDto, opt => opt.MapFrom(m => m.MemberShipType));

            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(x => x.MemberShipType, opt => opt.Ignore());

            CreateMap<GenreDto, Genre>().ReverseMap();


            CreateMap<Movie, MovieDto>()
                .ForMember(mdto => mdto.GenreDto, opt => opt.MapFrom(m => m.Genre));

            CreateMap<MovieDto, Movie>()
               .ForMember(m => m.Id, opt => opt.Ignore())
               .ForMember(m => m.AddedDate, opt => opt.Ignore())
               .ForMember(m => m.Genre, opt => opt.Ignore());




            //CreateMap<CustomerDto, Customer>()
            //    .ForMember(c => c.MemberShipType, opt => opt.Ignore())
            //    .ForMember(c => c.Id, opt => opt.Ignore())
            //    .ForMember(c => c.Name, opt => opt.MapFrom(dto => dto.Name))
            //    .ForMember(c => c.DateOfBirth, opt => opt.MapFrom(dto => dto.DateOfBirth))
            //    .ForMember(c => c.IsSubscribeToNewsLetter, opt => opt.MapFrom(dto => dto.IsSubscribeToNewsLetter))
            //    .ForMember(c => c.MemberShipTypeId, opt => opt.MapFrom(dto => dto.MemberShipTypeId));



            CreateMap<NewMovieViewModel, Movie>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(c => c.RealeaseDate, vm => vm.MapFrom(model => model.RealeaseDate))
                 .ForMember(c => c.GenreId, vm => vm.MapFrom(model => model.GenreId))
                .ForMember(c => c.NumberInStoke, vm => vm.MapFrom(
                    model => model.NumberInStoke))
                .ReverseMap();


            CreateMap<NewCustomerViewModel, Customer>()
                .ForMember(x => x.Id, opt => opt.MapFrom(model => model.Customer.Id))
                .ForMember(x => x.MemberShipType, opt => opt.MapFrom(x => x.Customer.MemberShipType))
                .ForMember(c => c.Name, vm => vm.MapFrom(model => model.Customer.Name))
                .ForMember(c => c.DateOfBirth, vm => vm.MapFrom(model => model.Customer.DateOfBirth))
                .ForMember(c => c.IsSubscribeToNewsLetter,
                    vm => vm.MapFrom(model => model.Customer.IsSubscribeToNewsLetter))
                .ForMember(c => c.MemberShipTypeId, vm => vm.MapFrom(
                    model => model.Customer.MemberShipTypeId))
                .ReverseMap();





            //CreateMap<Customer, NewCustomerViewModel>()
            //    .ForMember(x => x.MemberShipTypes, opt => opt.Ignore())
            //    .ForMember(c => c.Customer.Name, vm => vm.MapFrom(model => model.Name))
            //    .ForMember(c => c.Customer.DateOfBirth, vm => vm.MapFrom(model => model.DateOfBirth))
            //    .ForMember(c => c.Customer.IsSubscribeToNewsLetter,
            //        vm => vm.MapFrom(model => model.IsSubscribeToNewsLetter))
            //    .ForMember(c => c.Customer.MemberShipTypeId, vm => vm.MapFrom(
            //        model => model.MemberShipTypeId));

        }
    }
}

