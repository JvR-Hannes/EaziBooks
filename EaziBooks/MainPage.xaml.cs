namespace EaziBooks
{
    public partial class MainPage : ContentPage
    {
        private List<decimal> _incomes = new List<decimal>();
        private List<decimal> _expenses = new List<decimal>();

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnAddIncomeClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(IncomeAmountEntry.Text, out decimal incomeAmount) && !string.IsNullOrWhiteSpace(IncomeSourceEntry.Text))
            {
                _incomes.Add(incomeAmount);
                UpdateTotals();
                ClearIncomeFields();
            }
            else
            {
                DisplayAlert("Error", "Please enter valid income details.", "OK");
            }
        }
        private void OnAddExpenseClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(ExpenseAmountEntry.Text, out decimal expenseAmount) && !string.IsNullOrWhiteSpace(ExpenseDescriptionEntry.Text))
            {
                _expenses.Add(expenseAmount);
                UpdateTotals();
                ClearExpenseFields();
            }
            else
            {
                DisplayAlert("Error", "Please enter valid expense details.", "OK");
            }
        }
        private void UpdateTotals()
        {
            decimal totalIncome = _incomes.Sum();
            decimal totalExpense = _expenses.Sum();
            decimal netProfit = totalIncome - totalExpense;

            TotalIncomeLabel.Text = $"Total Income: R{totalIncome:F2}";
            TotalExpenseLabel.Text = $"Total Expenses: R{totalExpense:F2}";
            NetProfitLabel.Text = $"Net Profit: R{netProfit:F2}";
        }
        private void ClearExpenseFields()
        {
            ExpenseDescriptionEntry.Text = string.Empty;
            ExpenseAmountEntry.Text = string.Empty;
        }
        private void ClearIncomeFields()
        {
            IncomeSourceEntry.Text = string.Empty;
            IncomeAmountEntry.Text = string.Empty;
        }



    }
}
