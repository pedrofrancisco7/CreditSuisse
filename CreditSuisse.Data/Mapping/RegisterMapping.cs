using Dapper.FluentMap;

namespace CreditSuisse.Data.Mapping
{
    public static class RegisterMapping
    {
        public static void Initialize() =>
            FluentMapper.Initialize(config =>
            {                
            });
    }
}
