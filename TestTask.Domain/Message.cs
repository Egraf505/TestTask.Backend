namespace TestTask.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public TypeMessage TypeMessage{ get; set; }
        public Contact Contact{ get; set; }
    }
}
