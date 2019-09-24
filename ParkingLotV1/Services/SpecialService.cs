using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotV1.Services
{
    public class SpecialService : ISpecialService
    {
        public string SpecialMethod()
        {
            return "I am special";
        }
    }
}