using Conway.InterimPods.Core.Entities;
using Conway.InterimPods.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace Conway.InterimPods.Presentation.Components.Pages.PodManagement
{
    public partial class PodProcessing : ComponentBase
    {
        [Inject] private IPodScanRepository podScansService { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] private RemoteApiOptions remoteApiOptions { get; set; }

        [Inject] private IConfiguration configuration { get; set; }

        private List<PodScan> podScans = new List<PodScan>();


        private PodScan currentPodScan => podScans != null && podScans.Count > 0 ? podScans[currentIndex] : null;

        //private RadzenDataGrid<PodScan> podScansDataGrid;

        private string DocumentUrl { get; set; }
        private string CurrentFile { get; set; }

        private bool isLoading { get; set; } = true;
        private bool isProcessing { get; set; } = false;

        private int currentIndex = 0;
        private int TotalCount => podScans.Count;

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            await LoadDataAsync();
            isLoading = false;
        }

        protected async Task LoadDataAsync()
        {
            var scanResults = await podScansService.FindPodScansAsync(doc => doc.Status == "processing");
            if (scanResults != null)
            {
                podScans = scanResults.ToList();
                if (podScans.Count > 0)
                {
                    DocumentUrl = GetDocumentUrl();
                }
            }
            isLoading = false;
        }

        private async Task HandleValidSubmit()
        {
            podScans[currentIndex].Status = "complete";
            await podScansService.UpdatePodScanAsync(podScans[currentIndex]);
            //NavigationManager.NavigateTo("/");
            await LoadDataAsync();
            StateHasChanged();
        }

        private string TicketIdString
        {
            get => podScans[currentIndex].TicketId?.ToString() ?? string.Empty;
            set
            {
                if (int.TryParse(value, out var parsedValue))
                {
                    podScans[currentIndex].TicketId = parsedValue;
                }
                else
                {
                    podScans[currentIndex].TicketId = null;
                }
            }
        }

        private string OrderIdString
        {
            get => podScans[currentIndex]?.OrderId?.ToString() ?? string.Empty;
            set
            {
                if (!int.TryParse(value, out var parsedValue))
                {
                    podScans[currentIndex].OrderId = parsedValue;
                }
                else
                {
                    podScans[currentIndex].OrderId = null;
                }
            }
        }


        private string GetDocumentUrl()
        {

            //return NavigationManager.ToAbsoluteUri($"api/v1/documents/{podScans[currentIndex].Id}").ToString().Replace(":88", ":84");
            string baseUrl = configuration["RemoteApi:BaseUrl"]; // Fetch from appsettings.json
            var url = $"{baseUrl}/{podScans[currentIndex].Id}";
            return $"{baseUrl}/{podScans[currentIndex].Id}";
        }

        protected async Task ProcessDirectory()
        {
            //isProcessing = true;
            //var progress = new Progress<string>();
            //await pdfReadingService.ProcessDirectory(progress);
            //CurrentFile = progress.ToString();
            //isProcessing = false;
            //await LoadDataAsync();
            //StateHasChanged();
        }

        private async void Next()
        {
            if (currentIndex < podScans.Count - 1)
            {
                currentIndex++;
            }
            DocumentUrl = GetDocumentUrl();
            StateHasChanged();
        }

        private async void Previous()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            DocumentUrl = GetDocumentUrl();
            StateHasChanged();
        }



    }
}
