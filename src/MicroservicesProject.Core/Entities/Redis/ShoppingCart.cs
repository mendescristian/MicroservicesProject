namespace MicroservicesProject.Core.Entities.Redis
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                if (Items is null || !Items.Any())
                    return totalPrice;

                foreach (ShoppingCartItem item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }

                return totalPrice;
            }
        }

        public ShoppingCart()
        {
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
            Items = new List<ShoppingCartItem>();
        }
    }
}
