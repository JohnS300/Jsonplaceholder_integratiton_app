public static class DatabaseService
{
    public static Task AddOrder(string orderId, string status)
    {
        // Logic to add an order with a status to the database
    }

    public static Task UpdateOrderStatus(string orderId, string status)
    {
        // Logic to update the order's status in the database
    }

    public static Task<bool> IsOrderComplete(string orderId)
    {
        // Logic to check if an order has received all required message types
    }

    public static Task DeleteOrder(string orderId)
    {
        // Logic to delete the order from the database if complete
    }
}
