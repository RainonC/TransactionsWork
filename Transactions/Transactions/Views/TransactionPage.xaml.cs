using Transactions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transactions.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionPage : ContentPage
    {
        public TransactionViewModel ViewModel { get; set; }
        public TransactionPage(TransactionViewModel viewModel)
        {

            InitializeComponent();
            ViewModel = viewModel;
            this.BindingContext = ViewModel;
        }
    }
}