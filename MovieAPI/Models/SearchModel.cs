namespace MovieAPI.Models
{
    public class SearchModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength:100, MinimumLength =2)]
        public string SearchValue { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
