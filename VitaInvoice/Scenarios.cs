using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using VitaInvoice.Scenarios.InvoicesScenario;
using VitaInvoice.Scenarios.NewInvoiceScenario;

namespace VitaInvoice
{
    public partial class MainPage : Page
    {
        public const string TITLE = "Invoices";

        List<Scenario> _scenarios = new List<Scenario>
        {
            new Scenario() { Title="Invoices", ClassType=typeof(InvoicesPage)},
            new Scenario() { Title="New Invoice", ClassType=typeof(NewInvoicePage)},
        };
    }

    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}
