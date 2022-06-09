using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HuceDocs.Data.Models;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.Document;
using HuceDocs.Services.ViewModels.User;
using Newtonsoft.Json.Linq;

namespace HuceDocs.Services.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>()
                //.ForMember(destination => destination.FullName,
                //    options => options.MapFrom(source => source.DisplayName))
                ;
            CreateMap<UserViewModel, User>();
            //CreateMap<UserUpdateRequest, User>();
            //CreateMap<UserInfo, UserUpdateRequest>();
            CreateMap<List<User>, List<UserViewModel>>();

            CreateMap<Document, DocumentVM>();
            CreateMap<DocumentVM, Document>();
            //CreateMap<JObject, UserConfigViewModel>()
            //    .ForMember(x => x.EmailNotification, y => y.MapFrom(j => j.SelectToken("EmailNotification")))
            //    .ForMember(x => x.AppNotification, y => y.MapFrom(j => j.SelectToken("AppNotification")))
            //    .ForAllOtherMembers(x => x.Ignore());
            //CreateMap<UserConfigViewModel, JObject>()
            //    .ForMember(dest => dest["EmailNotification"], cfg => { cfg.MapFrom(src => src.EmailNotification); })
            //    .ForMember(dest => dest["AppNotification"], cfg => { cfg.MapFrom(src => src.AppNotification); })
            //    .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
