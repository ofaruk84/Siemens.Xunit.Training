namespace ProductWebApi.Modals
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
