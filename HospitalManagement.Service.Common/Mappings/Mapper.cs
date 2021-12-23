using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HospitalManagement.Data.Entities;
using HospitalManagement.Service.Common.Dtos.Products;

namespace HospitalManagement.Service.Common.Mappings
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Products
            CreateMap<ProductToInsertDto, ProductEntity>();
            CreateMap<ProductEntity, ProductToReturnDto>();

            CreateMap<ProductToReturnDto, ProductEntity>();
            CreateMap<ProductEntity, ProductToReturnDto>();

            CreateMap<ProductToUpdateDto, ProductEntity>();
            CreateMap<ProductEntity, ProductToUpdateDto>();
        }
    }
}
