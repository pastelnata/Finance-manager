namespace Finance
{
    class Transaction
    {
        private string description {get;}
        private decimal amount {get;}
        private string category {get;}
        private Guid ID {get; set;} = Guid.NewGuid();
        private DateTime date = DateTime.UtcNow;

        public Transaction(string _description, decimal _amount, string _category)
        {
            description = _description;
            amount = _amount;
            category = _category;
        }

        internal string GetDescription()
        {
            return description;
        }

        internal decimal GetAmount()
        {
            return amount;
        }

        internal string GetCategory()
        {
            return category;
        }

        internal Guid GetID()
        {
            return ID;
        }

        internal DateTime GetDate()
        {
            return date;
        }
    }
}