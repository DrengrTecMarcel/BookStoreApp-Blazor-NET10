using BookStoreApp.Blazor.WebAssembly.UI.Models;
using BookStoreApp.Blazor.WebAssembly.UI.Services;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;

namespace BookStoreApp.Blazor.WebAssembly.UI.Pages.Books
{
    public partial class BookTable
    {
        [Inject] IBookService bookService { get; set; }
        [Inject] IJSRuntime js { get; set; }

        [Parameter]
        public List<BookReadOnlyDto> Books { get; set; }

        [Parameter]
        public int TotalSize { get; set; }

        [Parameter]
        public EventCallback<QueryParameters> OnScroll { get; set; }

        private async ValueTask<ItemsProviderResult<BookReadOnlyDto>> LoadBooks(ItemsProviderRequest request)
        {
            var authorNum = Math.Min(request.Count, TotalSize = request.StartIndex);
            await OnScroll.InvokeAsync(new QueryParameters
            {
                StartIndex = request.StartIndex,
                PageSize = authorNum == 0 ? request.Count : authorNum
            });
            return new ItemsProviderResult<BookReadOnlyDto>(Books, TotalSize);
        }

        private async Task DeleteBook(int bookId)
        {
            var book = Books.First(q => q.Id == bookId);
            var confirm = await js.InvokeAsync<bool>("confirm", $"Are You Surer You Want To Delete {book.Title}?");
            if (confirm)
            {
                var response = await bookService.DeleteBook(bookId);
                if (response.Success)
                {
                    await OnInitializedAsync();
                }
            }
        }

    }
}
