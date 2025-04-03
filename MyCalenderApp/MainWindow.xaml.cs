using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCalenderApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
    public partial class MainWindow : Window
    {
        // Declare global variables for year and month
        private int currentYear = 2025; // Default year
        private int currentMonth = 4;  // Default month (April)

        public MainWindow()
        {
            InitializeComponent();
            PopulateCalendar(2025, 4);
        }

        private void PopulateCalendar(int year, int month)
        {
            // Clear existing buttons if any
            CalendarGrid.Children.Clear();

            // Get the number of days in the month
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Get the first day of the month
            DateTime firstDay = new DateTime(year, month, 1);
            int startDayOfWeek = (int)firstDay.DayOfWeek; // Sunday = 0, Monday = 1, etc.

            // Add buttons for each day
            int currentRow = 0;
            for (int day = 1; day <= daysInMonth; day++)
            {
                // Calculate row and column for the current day
                int column = (startDayOfWeek + day - 1) % 7;
                currentRow = (startDayOfWeek + day - 1) / 7;

                // Create a button for the day
                Button dayButton = new Button
                {
                    Content = day.ToString(),
                    Width = 40,
                    Height = 40,
                    Margin = new Thickness(5),
                    Background = System.Windows.Media.Brushes.LightBlue
                };

                // Add the button to the grid
                Grid.SetRow(dayButton, currentRow);
                Grid.SetColumn(dayButton, column);
                CalendarGrid.Children.Add(dayButton);
            }
        }
        private void UpdateMonthYearDisplay()
        {
            MonthYearText.Text = $"{new DateTime(currentYear, currentMonth, 1):MMMM yyyy}";
        }
        private void PreviousMonth_Click(object sender, RoutedEventArgs e)
        {
            currentMonth--; // Decrement the month
            if (currentMonth < 1)
            {
                currentMonth = 12; // Wrap to December
                currentYear--;
            }
            PopulateCalendar(currentYear, currentMonth);
        }
        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            currentMonth++; // Decrement the month
            if (currentMonth > 12)
            {
                currentMonth = 1; // Wrap to December
                currentYear++;
            }
            PopulateCalendar(currentYear, currentMonth);
        }

    }