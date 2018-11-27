using NetworkPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
        public static class Data
        {
            public const double ReceiverHeight = 1.5; //[m]
            public const double MobileStationSensitivity = -114; //[dBm]
            public const double IntererenceMargin = 2;
            public const double FastFadeMargin = 5; //[dB]
            public const double ConnectorLoss = 3; //[dB]
            public const double ReceiverAntennaGain = 14; //[dB]
            public static Dictionary<CellShape, PolygonCharacteristics> CellShapeData =
                new Dictionary<CellShape, PolygonCharacteristics>
                {
                    {
                        CellShape.Hexagonal,
                        new PolygonCharacteristics
                        {
                            SidesNumber = 6,
                            CirfNValueMultiplier = 3,
                        }
                    },

                    {
                        CellShape.Square,
                        new PolygonCharacteristics
                        {
                            SidesNumber = 4,
                            CirfNValueMultiplier = 2,
                        }
                    }
                };
        }
    }
}
