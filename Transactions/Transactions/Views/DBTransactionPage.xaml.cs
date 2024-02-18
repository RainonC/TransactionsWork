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
    public partial class DBTransactionPage : ContentPage
    {
        public DBTransactionPage()
        {
            InitializeComponent();
        }

        private void Loobu_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Transaction transaction = (Transaction)BindingContext;
            App.Database.DeleteItem(transaction.Id);
            this.Navigation.PopAsync();
        }

        private void Salvesta_Clicked(object sender, EventArgs e)
        {
            Transaction transaction = (Transaction)BindingContext;
            if (!String.IsNullOrEmpty(transaction.Name))
            {
                App.Database.SaveItem(transaction);
            }
            this.Navigation.PopAsync();
        }
    }
}