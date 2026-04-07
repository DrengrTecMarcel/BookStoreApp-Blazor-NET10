using BookStoreApp.Blazor.Server.UI.Models;
using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;


namespace BookStoreApp.Blazor.Server.UI.Components.Pages.Authors
{
    public partial class AuthorTable
    {
        [Inject] IAuthorService authorService { get; set; }
        [Inject] IJSRuntime js {  get; set; }

        [Parameter]
        public List<AuthorReadOnlyDto> Authors { get; set; }

        [Parameter]
        public int TotalSize { get; set; }

        [Parameter]
        public EventCallback<QueryParameters> OnScroll { get; set; }

        private async ValueTask<ItemsProviderResult<AuthorReadOnlyDto>> LoadAuthors(ItemsProviderRequest request)
        {
            var authorNum = Math.Min(request.Count, TotalSize = request.StartIndex);
            await OnScroll.InvokeAsync(new QueryParameters
            {
                StartIndex = request.StartIndex,
                PageSize = authorNum == 0 ? request.Count : authorNum
            });
            return new ItemsProviderResult<AuthorReadOnlyDto>(Authors, TotalSize);
        }

        private async Task Delete(int authorId)
        {
            var author = Authors.First(q => q.Id == authorId);
            var confirm = await js.InvokeAsync<bool>("confirm", $"Are You Surer You Want To Delete {author.FirstName} {author.LastName}?");
            if (confirm)
            {
                var response = await authorService.Delete(authorId);
                if (response.Success)
                {
                    await OnInitializedAsync();
                }
            }
        }
    }
}
