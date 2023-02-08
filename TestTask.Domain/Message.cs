namespace TestTask.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Contact_id { get; set; }
        public Contact Contact { get; set; }
    }
}
