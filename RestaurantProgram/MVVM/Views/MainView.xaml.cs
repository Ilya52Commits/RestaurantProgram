namespace RestaurantProgram.MVVM.Views;

public partial class MainView
{
    public MainView()
    {
        InitializeComponent();
        MainFrame.NavigationService.Navigate(new MenuView());
    }
}