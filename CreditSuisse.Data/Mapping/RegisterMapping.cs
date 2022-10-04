using Dapper.FluentMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Data.Mapping
{
    public static class RegisterMapping
    {
        public static void Initialize() =>
            FluentMapper.Initialize(config =>
            {
                //config.AddMap(new SystemsMap());
                //config.AddMap(new SystemsAuxMap());
                //TODO: config.AddMap(new CampeonatosMap());
            });
    }
}
