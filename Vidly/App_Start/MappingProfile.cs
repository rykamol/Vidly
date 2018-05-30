using AutoMapper;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewMovieViewModel, Movie>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Movie.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Movie.Name))
                .ForMember(c => c.RealeaseDate, vm => vm.MapFrom(model => model.Movie.RealeaseDate))
                .ForMember(c => c.AddedDate, vm => vm.MapFrom(model => model.Movie.AddedDate))
                .ForMember(c => c.GenreId, vm => vm.MapFrom(model => model.Movie.GenreId))
                .ForMember(c => c.NumberInStoke, vm => vm.MapFrom(
                    model => model.Movie.NumberInStoke))
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

