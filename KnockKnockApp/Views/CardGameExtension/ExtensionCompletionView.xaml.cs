using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Views.CardGameExtension;

public partial class ExtensionCompletionView : ContentView
{
    public static readonly BindableProperty CurrentExtensionProperty = BindableProperty.Create(nameof(CurrentExtension), typeof(Extension), typeof(ExtensionCompletionView));

    public Extension CurrentExtension
    {
        get => (Extension)GetValue(CurrentExtensionProperty);
        set => SetValue(CurrentExtensionProperty, value);
    }

    public static readonly BindableProperty NavigateToSelectCardGameExtensionCommandProperty = BindableProperty.Create(nameof(NavigateToSelectCardGameExtensionCommand), typeof(RelayCommand), typeof(ExtensionCompletionView));

    public RelayCommand NavigateToSelectCardGameExtensionCommand
    {
        get { return (RelayCommand)GetValue(NavigateToSelectCardGameExtensionCommandProperty); }
        set { SetValue(NavigateToSelectCardGameExtensionCommandProperty, value); }
    }

    public ExtensionCompletionView()
	{
		InitializeComponent();
	}
}