using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitaInvoice.Model;

namespace VitaInvoice.Scenarios.NewInvoiceScenario
{
    public class NewInvoiceViewModel
    {
        public ObservableCollection<Concept> Concepts { get; } = new ObservableCollection<Concept>();
    }
}
