using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence
{
    //Extensions.Configuration ve Extensions.Configuration.Json paketleri yokleniyor bunun için.
    //Başka bir katmandaki json dosyasından okuma işlemi yapılıyor ve connection string okunuyor.
    //NpgSql ve tools paketleride bu katmana kuruluyor.
    //Design paketi ise startup olan api katmanına kuruluyor entityframework için.

    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/NeuronLogisticsServer.Api"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}