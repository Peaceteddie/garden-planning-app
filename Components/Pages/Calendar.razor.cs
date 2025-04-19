using System.Globalization;
using Models;
namespace Components.Pages;

public partial class Calendar
{
    bool ShowDialog = false;
    const int NumberOfDaysInWeek = 7;
    DateTime? DialogDate = null;
    DateTime? DisplayingMonth = new(DateTime.Now.Year, DateTime.Now.Month, 1);
    readonly DateTime CurrentDate = DateTime.Now.Date;

    CultureInfo LocalCultureInfo => new(CultureInfo.CurrentCulture.Name) { DateTimeFormat = { FirstDayOfWeek = DayOfWeek.Monday } };
    IEnumerable<string> DayNames => Enumerable.Range(0, NumberOfDaysInWeek).Select(GetRelativeDayName);
    int FirstDayOfWeek => (int)LocalCultureInfo.DateTimeFormat.FirstDayOfWeek;
    string DayWidthPercentage => $"{100.0 / NumberOfDaysInWeek:F2}%";

    int GetOffset(DateTime date) => ((int)new DateTime(date.Year, date.Month, 1).DayOfWeek - FirstDayOfWeek + NumberOfDaysInWeek) % NumberOfDaysInWeek;
    string GetCellClass(DateTime? date) => date.HasValue && date.Value.Day == CurrentDate.Day ? "bg-light" : "";
    string GetRelativeDayName(int i) => LocalCultureInfo.DateTimeFormat.DayNames[(FirstDayOfWeek + i) % NumberOfDaysInWeek];

    List<List<DateTime?>> CalendarWeeks
    {
        get
        {
            var days = new List<List<DateTime?>>();
            var offset = GetOffset(CurrentDate);
            var daysInMonth = DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month);
            var weeks = (int)Math.Ceiling((offset + daysInMonth) / (double)NumberOfDaysInWeek);

            int dayCounter = 1;
            for (int w = 0; w < weeks; w++)
            {
                var week = new List<DateTime?>();
                for (int d = 0; d < NumberOfDaysInWeek; d++)
                {
                    int cellIndex = w * NumberOfDaysInWeek + d;
                    week.Add(cellIndex >= offset && dayCounter <= daysInMonth ? new(CurrentDate.Year, CurrentDate.Month, dayCounter++) : null);
                }
                days.Add(week);
            }
            return days;
        }
    }

    void OpenDay(DateTime? date)
    {
        if (date.HasValue)
        {
            DialogDate = date.Value;
            ShowDialog = true;
            StateHasChanged();
        }
    }

    void CloseDialog(PlannedCrop? crop)
    {
        if (crop != null)
        {
            Console.WriteLine(crop);
        }
        ShowDialog = false;
        DialogDate = null;
        StateHasChanged();
    }
}