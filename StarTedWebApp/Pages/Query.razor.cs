using Microsoft.AspNetCore.Components;
using StarTedSystem.BLL;
using StarTedSystem.Entities;

namespace StarTedWebApp.Pages
{
    public partial class Query : ComponentBase
    {

        [Inject]
        ClubServices ClubServices { get; set; }

        [Inject]
        EmployeeServices EmployeeServices { get; set; }

        private List<Club>? Clubs { get; set; }
        private List<Employee> Employees { get; set; }
        private Dictionary<string, string> Errors { get; set; } = new();
        private string? FeedbackMessage { get; set; }

        private int currentPage = 1;
        private int PageSize => 5;

        /// <summary>
        /// calculates the total number of pages needed
        /// </summary>
        private int totalPages => (int)Math.Ceiling((double)Clubs.Count / PageSize);
        //int pages = (int)Math.Ceiling((double)12 / (double)5);

        [Inject]
        NavigationManager NavigationManager { get; set; }


        /// <summary>
        /// Initializes the component
        /// </summary>
        protected override void OnInitialized()
        {
            Clubs = ClubServices.GetClubs();
            Employees = EmployeeServices.GetEmployees();

            base.OnInitialized();
        }

        /// <summary>
        /// Filters and retrieves club data
        /// </summary>
        /// <param name="active">Check active or inactive clubs</param>
        private void FilterData(bool active)
        {
            try
            {
                Clubs = ClubServices.GetClubs(active);
                currentPage = 1;
            }
            catch (Exception ex)
            {
                Errors.Add("Error", ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all club data
        /// </summary>
        private void HandleSearch()
        {
            Clubs = ClubServices.GetClubs();
            currentPage = 1;
        }

        /// <summary>
        /// Changes the current page
        /// </summary>
        /// <param name="page">The page number to navigate to.</param>
        private void ChangePage(int page)
        {
            currentPage = Math.Max(1, Math.Min(page, totalPages));
            StateHasChanged();
        }
    }
}