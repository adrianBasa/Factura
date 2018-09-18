using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura
{
    public class Customer
    {
        public string CompanyName;
        public string City;
        public string Address;
        public string VAT;
        public string ZipCode;

        public  Customer(string companyName, string city, string address, string vat, string zip)
        {
            CompanyName = companyName;
            City = city;
            Address = address;
            VAT = vat;
            ZipCode = zip;
        }
    }
}
