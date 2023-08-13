namespace Discount.Application.Common.Dtos
{
    public class CouponDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public CouponDto()
        {
        }

        public CouponDto(string productName, string description, decimal amount)
        {
            ProductName = productName;
            Description = description;
            Amount = amount;
        }
    }
}
