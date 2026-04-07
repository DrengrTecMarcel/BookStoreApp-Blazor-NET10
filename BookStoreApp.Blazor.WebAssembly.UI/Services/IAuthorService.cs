using BookStoreApp.Blazor.WebAssembly.UI.Models;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<AuthorReadOnlyDtoVirtulalizeResponse>> GetAuthor(QueryParameters queryParams);

        Task<Response<List<AuthorReadOnlyDto>>> GetAuthor();

        Task<Response<AuthorDetailsDto>> GetAuthor(int id);

        Task<Response<AuthorUpdateDto>> GetUpdateForAuthors(int id);

        Task<Response<int>> CreateAuthor(AuthorCreateDto author);

        Task<Response<int>> EditAuthor(int id, AuthorUpdateDto author);

        Task<Response<int>> Delete(int id);
    }
}