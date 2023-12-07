namespace DW_IAP
{
    public static class PurchasableExtensions
    {
        public static Consumable AsConsumable(this Purchasable purchasable)
        {
            try
            {
                return purchasable as Consumable;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static NonConsumable AsNonConsumable(this Purchasable purchasable)
        {
            try
            {
                return purchasable as NonConsumable;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static Subscription AsSubscription(this Purchasable purchasable)
        {
            try
            {
                return purchasable as Subscription;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}