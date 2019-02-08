using AutoMapper;
using FM.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FM.WEB.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonViewModel, Person>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<Mailing, MailingViewModel>()
                .ForMember(
                    x => x.Persons , 
                    opt => opt.MapFrom(src => src.MailingPerson.Select(x => x.Person))
                );

            CreateMap<MailingViewModel, Mailing>();
            CreateMap<HomeGroup, HomeGroupViewModel>();
            CreateMap<HomeGroupViewModel, HomeGroup>();
        }
    }
}
