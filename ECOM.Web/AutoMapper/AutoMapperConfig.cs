using AutoMapper;


namespace ECOM.Web.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperDomainToVw>();
                x.AddProfile<AutoMapperVwToDomain>();
            });
        }
    }
}