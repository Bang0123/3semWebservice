using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPMeasurementSender
{
    class NameGenerator
    {
        List<string> readings203 = new List<string>
            {
                "Lokale:203:Temp:19:Lyd:65:Lys:400",
                "Lokale:203:Temp:20:Lyd:70:Lys:400",
                "Lokale:203:Temp:20:Lyd:68:Lys:400",
                "Lokale:203:Temp:21:Lyd:64:Lys:400",
                "Lokale:203:Temp:21:Lyd:60:Lys:400",
                "Lokale:203:Temp:21:Lyd:65:Lys:400",
                "Lokale:203:Temp:22:Lyd:67:Lys:400",
                "Lokale:203:Temp:22:Lyd:65:Lys:400",
                "Lokale:203:Temp:22:Lyd:78:Lys:400",
                "Lokale:203:Temp:22:Lyd:69:Lys:400",
                "Lokale:203:Temp:23:Lyd:69:Lys:400",
                "Lokale:203:Temp:23:Lyd:57:Lys:400",
                "Lokale:203:Temp:23:Lyd:65:Lys:400",
            };
        List<string> readings201 = new List<string>
            {
                "Lokale:201:Temp:20:Lyd:65:Lys:400",
                "Lokale:201:Temp:20:Lyd:70:Lys:400",
                "Lokale:201:Temp:20:Lyd:68:Lys:400",
                "Lokale:201:Temp:21:Lyd:64:Lys:400",
                "Lokale:201:Temp:21:Lyd:60:Lys:400",
                "Lokale:201:Temp:21:Lyd:65:Lys:400",
                "Lokale:201:Temp:22:Lyd:67:Lys:400",
                "Lokale:201:Temp:22:Lyd:65:Lys:400",
                "Lokale:201:Temp:22:Lyd:78:Lys:400",
                "Lokale:201:Temp:22:Lyd:69:Lys:400",
                "Lokale:201:Temp:23:Lyd:69:Lys:400",
                "Lokale:201:Temp:23:Lyd:57:Lys:400",
                "Lokale:201:Temp:23:Lyd:65:Lys:400"
            };

        public Measurement randomname(int lokalenr)
        {
            Random rng = new Random();
            //  string measurement = readings201[index];
            Measurement tempMeasurement = new Measurement(lokalenr, rng.Next(56, 80), rng.Next(200, 600), rng.Next(18, 24));
            return tempMeasurement;
        }
    }
}

