using BookStoreApp.Blazor.Server.UI.Models;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        Task<Response<BookReadOnlyDtoVirtulalizeResponse>> GetBook(QueryParameters queryParams);

        Task<Response<List<BookReadOnlyDto>>> GetBook();

        Task<Response<BookDetailsDto>> GetBook(int id);

        Task<Response<BookUpdateDto>> GetUpdateForBook(int id);

        Task<Response<int>> CreateBook(BookCreateDto book);

        Task<Response<int>> EditBook(int id, BookUpdateDto book);

        Task<Response<int>> DeleteBook(int id);
    }
}