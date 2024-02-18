using System;
using System.Collections.Generic;
using System.ComponentModel;
using Transactions.Models;
using static Xamarin.Essentials.Permissions;

namespace Transactions.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        TransactionsListViewModel lvm;
        public Transaction Transaction { get; set; }

        public List<string> TransactionTypes { get; } = new List<string> { "Income", "Expense" };

        public List<string> DescriptionCategories { get; } = new List<string> { "Food", "Health", "Transport", "Fun", "Gift", "Salary" };

        public TransactionViewModel() { Transaction = new Transaction(); }
        public TransactionsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Transaction.Name; }
            set
            {
                if (Transaction.Name != value)
                {
                    Transaction.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public decimal Amount
        {
            get { return Transaction.Amount; }
            set
            {
                if (Transaction.Amount != value)
                {
                    Transaction.Amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        public string Description
        {
            get { return Transaction.Description; }
            set
            {
                Transaction.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public DateTime Date
        {
            get { return Transaction.Date; }
            set
            {
                if (Transaction.Date != value)
                {
                    Transaction.Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string TransactionType
        {
            get { return Transaction.Type.ToString(); }
            set
            {
                if (Enum.TryParse(value, out TransactionType type))
                {
                    Transaction.Type = type;
                    OnPropertyChanged("TransactionType");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return Amount != 0 ||
                       !string.IsNullOrEmpty(Description?.Trim()) ||
                       Date != default(DateTime) ||
                       !string.IsNullOrEmpty(TransactionType?.Trim());
            }
        }


        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(v));
            }
        }
    }
}
