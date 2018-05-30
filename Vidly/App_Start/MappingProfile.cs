using AutoMapper;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewCustomerViewModel, Customer>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.MemberShipType, opt => opt.Ignore())
                .ForMember(c => c.Name, vm => vm.MapFrom(model => model.Customer.Name))
                .ForMember(c => c.DateOfBirth, vm => vm.MapFrom(model => model.Customer.DateOfBirth))
                .ForMember(c => c.IsSubscribeToNewsLetter,
                    vm => vm.MapFrom(model => model.Customer.IsSubscribeToNewsLetter))
                .ForMember(c => c.MemberShipTypeId, vm => vm.MapFrom(
                    model => model.Customer.MemberShipTypeId));

        }
    }
}

