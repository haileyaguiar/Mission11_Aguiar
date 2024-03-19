namespace Mission11_Aguiar.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
