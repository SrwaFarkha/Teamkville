namespace TeamKville.Server.Data.DataModels
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
