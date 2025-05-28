using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class RoomSearchModel : PageModel
    {
        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        public List<string> AvailableRooms { get; set; } = new List<string>();

        private Dictionary<string, List<DateTime>> mockData = new()
        {
            { "101", Enumerable.Range(0, 10).Select(i => DateTime.Today.AddDays(i)).ToList() },
            { "102", Enumerable.Range(2, 5).Select(i => DateTime.Today.AddDays(i)).ToList() },
            { "103", Enumerable.Range(5, 5).Select(i => DateTime.Today.AddDays(i)).ToList() },
        };

        public void OnPost()
        {
            if (StartDate == default || EndDate == default || StartDate > EndDate)
            {
                ModelState.AddModelError("", "請輸入正確的日期範圍。");
                return;
            }

            int totalDays = (EndDate - StartDate).Days + 1;
            var dates = Enumerable.Range(0, totalDays).Select(i => StartDate.AddDays(i)).ToList();

            foreach (var room in mockData)
            {
                if (dates.All(d => room.Value.Contains(d)))
                {
                    AvailableRooms.Add(room.Key);
                }
            }
        }
        public void OnGet()
        {
            if (StartDate == default)
                StartDate = DateTime.Today;

            if (EndDate == default)
                EndDate = DateTime.Today.AddDays(2);
        }
    }
}
