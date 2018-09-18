using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factura;


namespace FacturaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Tax Registration Number:", "F40/2964/2015");
            dictionary.Add("VAT number:", "RO35010201");
            dictionary.Add("Address: ", "Strada Binelui 205-D,Bucuresti, jud. Bucuresti, România");
            dictionary.Add("Phone:", "0755702116");
            dictionary.Add("Email :", "adrian@crmextensions.com");
            dictionary.Add("Bank:", "BANCA COMERCIALA ROMANA SA");
            dictionary.Add("SWIFT:", "RNCBROBU");
            dictionary.Add("IBAN(EUR):", "RO53RNCB0178146583900003");

            Dictionary<string, string> invoiceDetails = new Dictionary<string, string>();
            invoiceDetails.Add("Invoice-Number: ", "1");
            invoiceDetails.Add("Invoice-Date (dd/mm/yyyy): ", DateTime.Now.ToString("M/d/yyyy"));
            invoiceDetails.Add("Due Date (dd/mm/yyyy):", DateTime.Now.AddDays(21).ToString("M/d/yyyy"));

            Factura1 factura = new Factura1();
            var customerData = new Customer("Google Group", "Iasi", "Plaiul verde 34", "RO8798211","8726585");
            factura.CreateInvoice(dictionary, invoiceDetails, customerData);
        }
    }
}
