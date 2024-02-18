using Transactions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transactions.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionsListPage : ContentPage
    {
        public TransactionsListPage()
        {
            InitializeComponent();
            BindingContext = new TransactionsListViewModel() { Navigation = this.Navigation };
        }
    }
}