namespace GBBNews.Models
{
    public class NewsArticle
    {
        public int NewsArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ArticlePicture {  get; set; }
        public string Newsarticle {  get; set; }
        public string Author { get; set; }
        public int NewsGenreId { get; set; }
        public virtual NewsGenre? NewsGenre { get; set; }

    }
}