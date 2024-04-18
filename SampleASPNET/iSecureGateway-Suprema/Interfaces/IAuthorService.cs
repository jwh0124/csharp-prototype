using iSecureGateway_Suprema.Models;

namespace iSecureGateway_Suprema.Interfaces
{
    public interface IAuthorService
    {
        Task<ICollection<Author>> RetrieveAuthorList();

        Task<Author?> RetrieveAuthor(string code);

        Task<Author> RegistAuthor(Author author);

        Task UpdateAuthor(Author author);

        Task DeleteAuthor(Author author);
    }
}
