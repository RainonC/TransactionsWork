using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using System.Windows.Input;
using Transactions.Models;
using Transactions.Views;
using Xamarin.Forms;

namespace Transactions.ViewModels
{
    
        public class TransactionsListViewModel : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;

            public ObservableCollection<TransactionViewModel> Transactions { get; set; }

        private string currentFilter;


        public ICommand CreateTransactionCommand { protected set; get; }

            public ICommand DeleteTransactionCommand { protected set; get; }

            public ICommand SaveTransactionCommand { protected set; get; }
            public ICommand BackCommand { protected set; get; }
            TransactionViewModel selectedTransaction;

            public INavigation Navigation { get; set; }

            public TransactionsListViewModel()
            {
                Transactions = new ObservableCollection<TransactionViewModel>();
                CreateTransactionCommand = new Command(CreateTransaction);
                DeleteTransactionCommand = new Command(DeleteTransaction);
                SaveTransactionCommand = new Command(SaveTransaction);
                BackCommand = new Command(Back);

            // Установим начальный фильтр (например, "Income" или "Outcome")
            SetFilter("Income");
        }

            public void Back()
            {
                Navigation.PopAsync();
            }

            private void SaveTransaction(object transactionObject)
            {


                TransactionViewModel transaction = transactionObject as TransactionViewModel;
                if (transaction != null && transaction.IsValid && !Transactions.Contains(transaction))
                {
                    Transactions.Add(transaction);
                    Back();
                }
            }

            private void DeleteTransaction(object transactionObject)
            {


                TransactionViewModel transaction = transactionObject as TransactionViewModel;
                if (transaction != null)
                {
                    Transactions.Remove(transaction);
                    Back();
                }
            }

            private void CreateTransaction(object obj)
            {
                Navigation.PushAsync(new TransactionPage(new TransactionViewModel() { ListViewModel = this }));
            }

            public TransactionViewModel SelectedTransaction
            {
                get { return selectedTransaction; }
                set
                {
                    if (selectedTransaction != value)
                    {
                        TransactionViewModel tempTransaction = value;
                        selectedTransaction = null;
                        OnPropertyChanged("SelectedTransaction");
                        Navigation.PushAsync(new TransactionPage(tempTransaction));
                    }
                }
            }

            private void OnPropertyChanged(string v)
            {


                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(v));
            }

        // Новый метод для установки фильтра
        public void SetFilter(string filter)
        {
            currentFilter = filter;
            FilterTransactions();
        }

        // Метод для применения фильтрации
        private void FilterTransactions()
        {
            var filteredTransactions = Transactions.ToList().Where(t => t.TransactionType == currentFilter).ToList();
            Transactions = new ObservableCollection<TransactionViewModel>(filteredTransactions);
        }

    }
}

