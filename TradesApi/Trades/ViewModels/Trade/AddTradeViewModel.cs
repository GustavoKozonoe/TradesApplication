using System.ComponentModel.DataAnnotations;
using Trades.Entities;
using Trades.Entities.Enums;

namespace Trades.ViewModels
{
    public class AddTradeViewModel
    {
        [Required(ErrorMessage = "Counterparty is required", AllowEmptyStrings = false)] 
        public int CounterPartyId { get; set; }

        [
            Required(ErrorMessage = "Date is required", AllowEmptyStrings = false), 
            DataType(DataType.Date),
            DisplayFormat(DataFormatString = "MM/DD/YYYY"),
        ]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "A direction is required", AllowEmptyStrings = false)] 
        public DirectionEnum Direction { get; set; }

        [
            Required(ErrorMessage = "A price is required", AllowEmptyStrings = false), 
            DataType(DataType.Currency),
            RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")
        ]
        public double Price { get; set; }

        [
            Required(ErrorMessage = "Product's Name is required", AllowEmptyStrings = false), 
            MinLength(2, ErrorMessage = "Product's Name require at least 2 characters"),
            MaxLength(24, ErrorMessage = "Product's Name require a naximum of 24 characters")
        ]

        public string Product { get; set; }
        [
            Required(ErrorMessage = "A quantity is required", AllowEmptyStrings = false), 
            Range(1, 100000000000, ErrorMessage = "Min: 1 and Max: 100000000000"),
            RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")
        ]
        public int Quantity { get; set; }

        public Trade ToTrade()
        {
            var result = new Trade
            {
                CounterPartyId = CounterPartyId,
                Date = Date,
                Direction = Direction,
                Price = Price,
                Product = Product,
                Quantity = Quantity
            };

            return result;
        }
    }
}
