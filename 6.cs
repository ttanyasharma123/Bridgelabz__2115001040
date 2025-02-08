using System;

// Base class: Order
class Order
{
    public int OrderId { get; set; }
    public string OrderDate { get; set; }

    public Order(int orderId, string orderDate)
    {
        OrderId = orderId;
        OrderDate = orderDate;
    }

    // Virtual method to be overridden by subclasses
    public virtual string GetOrderStatus()
    {
        return "Order placed.";
    }
}

// Subclass: ShippedOrder
class ShippedOrder : Order
{
    public string TrackingNumber { get; set; }

    public ShippedOrder(int orderId, string orderDate, string trackingNumber) : base(orderId, orderDate)
    {
        TrackingNumber = trackingNumber;
    }

    public override string GetOrderStatus()
    {
        return "Order shipped. Tracking Number: " + TrackingNumber;
    }
}

// Subclass: DeliveredOrder
class DeliveredOrder : ShippedOrder
{
    public string DeliveryDate { get; set; }

    public DeliveredOrder(int orderId, string orderDate, string trackingNumber, string deliveryDate) : base(orderId, orderDate, trackingNumber)
    {
        DeliveryDate = deliveryDate;
    }

    public override string GetOrderStatus()
    {
        return "Order delivered on: " + DeliveryDate;
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Order order = new Order(1001, "2025-02-08");
        ShippedOrder shippedOrder = new ShippedOrder(1002, "2025-02-07", "TRK123456");
        DeliveredOrder deliveredOrder = new DeliveredOrder(1003, "2025-02-06", "TRK789012", "2025-02-09");

        Console.WriteLine(order.GetOrderStatus());
        Console.WriteLine(shippedOrder.GetOrderStatus());
        Console.WriteLine(deliveredOrder.GetOrderStatus());
    }
}
