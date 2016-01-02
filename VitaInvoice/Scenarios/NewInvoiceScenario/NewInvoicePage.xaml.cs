using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Holographic;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VitaInvoice.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VitaInvoice.Scenarios.NewInvoiceScenario
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewInvoicePage : Page
    {
        public NewInvoicePage()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ConceptsLB.ItemsSource = ViewModel.Concepts;
            Loaded -= OnLoaded;
        }

        public NewInvoiceViewModel ViewModel { get; } = new NewInvoiceViewModel();


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddConcept();
        }

        private void AmountTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                AddConcept();
        }

        private void AddConcept()
        {
            var concept = conceptTB.Text;
            var amount = 0m;
            if (string.IsNullOrWhiteSpace(concept))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorText.Text = "Concept cannot be empty";
                conceptTB.Focus(FocusState.Keyboard);
                return;
            }
            if (!decimal.TryParse(amountTB.Text, out amount))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorText.Text = "Invalid number format in the amount";
                amountTB.SelectionStart = 0;
                amountTB.SelectionLength = amountTB.Text.Length;
                amountTB.Focus(FocusState.Keyboard);
                return;
            }

            ViewModel.Concepts.Add(new Concept {Name = conceptTB.Text, Amount = decimal.Parse(amountTB.Text)});
            conceptTB.Text = "";
            amountTB.Text = "";
            conceptTB.Focus(FocusState.Keyboard);

            ErrorBorder.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void ConceptsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemoveConceptButton.Visibility = ConceptsLB.SelectedItem != null
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void RemoveConceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConceptsLB.SelectedItem == null)
                return;
            ViewModel.Concepts.Remove(ConceptsLB.SelectedItem as Concept);
        }
    }
}
