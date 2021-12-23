namespace FeyzaBagiroz_Odev1_BookStore.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string BookSerialNo { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public int PublishDate { get; set; }
    }

}
