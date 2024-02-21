
class Transaction
{
    DateTime dateTime;
    string description;
    decimal amount;
    string category;
    Guid ID {get; set;} = Guid.NewGuid();

    public Transaction(DateTime _dateTime, string _description, decimal _amount, string _category, Guid _ID)
    {
        dateTime = _dateTime;
        description = _description;
        amount = _amount;
        category = _category;
        ID = _ID;
    }
}
