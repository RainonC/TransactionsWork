using Transactions;
using Transactions.Models;
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
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            transactionsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void transactionsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Transaction selectedtransaction = (Transaction)e.SelectedItem;
            DBTransactionPage transactionPage = new DBTransactionPage();
            transactionPage.BindingContext = selectedtransaction;
            await Navigation.PushAsync(transactionPage);
        }

        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            DBTransactionPage transactionPage = new DBTransactionPage();
            transactionPage.BindingContext = transaction;
            await Navigation.PushAsync(transactionPage);
        }
    }
}