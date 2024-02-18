using Transactions.Views;
using Transactions.Models;

using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transactions
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "transactions.db";
        public static TransactionRepository database;
        public static TransactionRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new TransactionRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DBListPage());


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}

