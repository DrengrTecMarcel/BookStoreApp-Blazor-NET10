using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Models;
using BookStoreApp.Blazor.Server.UI.Services.Base;


namespace BookStoreApp.Blazor.Server.UI.Services
{

    public class AuthorServices : BaseHttpService, IAuthorService
    {
        private readonly IClient client;
        private readonly IMapper mapper;

        public AuthorServices(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<Response<int>> CreateAuthor(AuthorCreateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.AuthorsPOSTAsync(author);
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<int>(exeption);
            }
            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.AuthorsDELETEAsync(id);
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<int>(exeption);
            }
            return response;
        }

        public async Task<Response<int>> EditAuthor(int id, AuthorUpdateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.AuthorsPUTAsync(id, author);
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<int>(exeption);
            }
            return response;
        }

        public async Task<Response<AuthorDetailsDto>> GetAuthor(int id)
        {
            Response<AuthorDetailsDto> response;
            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGET2Async(id);
                response = new Response<AuthorDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<AuthorDetailsDto>(exeption);
            }

            return response;
        }

        public async Task<Response<AuthorReadOnlyDtoVirtulalizeResponse>> GetAuthor(QueryParameters queryParams)
        {
            Response<AuthorReadOnlyDtoVirtulalizeResponse> response;
            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(queryParams.StartIndex, queryParams.PageSize);
                response = new Response<AuthorReadOnlyDtoVirtulalizeResponse>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<AuthorReadOnlyDtoVirtulalizeResponse>(exeption);
            }

            return response;
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> GetAuthor()
        {
            Response<List<AuthorReadOnlyDto>> response;
            try
            {
                await GetBearerToken();
                var data = await client.GetAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<List<AuthorReadOnlyDto>>(exeption);
            }

            return response;
        }

        public async Task<Response<AuthorUpdateDto>> GetUpdateForAuthors(int id)
        {
            Response<AuthorUpdateDto> response;
            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGET2Async(id);
                response = new Response<AuthorUpdateDto>
                {
                    Data = mapper.Map<AuthorUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException exeption)
            {
                response = ConvertApiExceptions<AuthorUpdateDto>(exeption);
            }

            return response;
        }
    }
}
