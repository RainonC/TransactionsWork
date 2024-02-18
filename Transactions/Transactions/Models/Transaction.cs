using SQLite;
using System;


public enum TransactionType
{
    Income,
    Expense
}

[Table("Transactions")]
public class Transaction
{
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int Id { get; set; }

    public string Name { get; set; }

    public TransactionType Type { get; set; } // доход или расход
    public decimal Amount { get; set; } //количество 
    public string Description { get; set; } //описание за что деньги пришли, или на что ушли
    public DateTime Date { get; set; } // дата получения/потери денег
    
}

