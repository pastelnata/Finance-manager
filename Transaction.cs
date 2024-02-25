using Newtonsoft.Json;

namespace Finance
{
    class Transaction
    {
        
        private string Description;
        private decimal Amount;
        private string Category;
        private Guid ID = Guid.NewGuid();
        private DateTime Date = DateTime.UtcNow;

        public Transaction(string _description, decimal _amount, string _category)
        {
            Description = _description;
            Amount = _amount;
            Category = _category;
        }

        [JsonProperty(nameof(GetDescription))]
        public string GetDescription
        {
            get {return Description; }
            set {Description = value; }
        }

        [JsonProperty(nameof(GetAmount))]
        public decimal GetAmount
        {
            get {return Amount; }
            set {Amount = value; }
        }

        [JsonProperty(nameof(GetCategory))]
        public string GetCategory
        {
            get {return Category; }
            set {Category = value; }
        }

        [JsonProperty(nameof(GetID))]
        public Guid GetID
        {
            get {return ID; }
            set {ID = value; }
        }

        [JsonProperty(nameof(GetDate))]
        public DateTime GetDate
        {
            get {return Date; }
            set {Date = value; }
        }
    }
}