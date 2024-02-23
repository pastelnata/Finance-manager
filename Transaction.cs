using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Finance
{
    class Transaction
    {
        
        internal string Description {get; set;}
        internal decimal Amount {get; set;}
        internal string Category {get; set;}
        internal Guid ID {get; set;} = Guid.NewGuid();
        internal DateTime Date {get; set;} = DateTime.UtcNow;

        public Transaction(string _description, decimal _amount, string _category)
        {
            Description = _description;
            Amount = _amount;
            Category = _category;
        }

        [JsonProperty, JsonPropertyName("Description")]
        public string GetDescription{get {return Description; }}

        [JsonProperty, JsonPropertyName("Amount")]
        public decimal GetAmount{get {return Amount; }}

        [JsonProperty, JsonPropertyName("Category")]
        public string GetCategory{get {return Category; }}

        [JsonProperty, JsonPropertyName("Date")]
        public DateTime GetDate{get {return Date; }}
        
        [JsonProperty, JsonPropertyName("ID")]
        public Guid GetID{get {return ID; }}
    }
}