using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace AvaloniaPlatformApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Application.Current.RequestedThemeVariant = true ? ThemeVariant.Dark : ThemeVariant.Light;
    }
}