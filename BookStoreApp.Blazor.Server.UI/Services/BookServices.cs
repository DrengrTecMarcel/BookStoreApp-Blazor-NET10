using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;


namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class BookServices : BaseHttpService, IBookService
    {
        private readonly IClient client;
        private readonly IMapper mapper;

        public BookServices(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<Response<int>> CreateBook(BookCreateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.BooksPOSTAsync(book);
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<int>(exeption);
            }
            return response;
        }

        public async Task<Response<int>> DeleteBook(int id)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.BooksDELETEAsync(id);
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<int>(exeption);
            }
            return response;
        }

        public async Task<Response<int>> EditBook(int id, BookUpdateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.BooksPUTAsync(id, book);
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<int>(exeption);
            }
            return response;
        }

        public async Task<Response<List<BookReadOnlyDto>>> GetBook()
        {
            Response<List<BookReadOnlyDto>> response;
            try
            {
                await GetBearerToken();
                var data = await client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<List<BookReadOnlyDto>>(exeption);
            }

            return response;
        }
       
        public async Task<Response<BookDetailsDto>> GetBook(int id)
        {
            Response<BookDetailsDto> response;
            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<BookDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<BookDetailsDto>(exeption);
            }

            return response;
        }

        public async Task<Response<BookUpdateDto>> GetUpdateForBook(int id)
        {
            Response<BookUpdateDto> response;
            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<BookUpdateDto>
                {
                    Data = mapper.Map<BookUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<BookUpdateDto>(exeption);
            }

            return response;
        }
    }
}
