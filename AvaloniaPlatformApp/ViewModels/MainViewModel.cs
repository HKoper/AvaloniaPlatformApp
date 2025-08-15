
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AvaloniaPlatformApp.ViewModels;

public class MainViewModel : ViewModelBase
{


    private string? _searchText;
    private bool _isBusy;

    public string? SearchText
    {
        get => _searchText;
        set => this.RaiseAndSetIfChanged(ref _searchText, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

    private bool _isPaneOpen = true;

    public bool IsPaneOpen
    {
        get => _isPaneOpen;
        set => this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
    }

    private ListItemTemplate? _selectedListItem;


    public ListItemTemplate? SelectedListItem
    {
        get => _selectedListItem;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedListItem, value);
            OnSelectedListItemChanged(value);


        }
    }

    private ViewModelBase? _currentPage = new HomeViewModel();

    public ViewModelBase? CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    void OnSelectedListItemChanged(ListItemTemplate? newValue)
    {
        if (newValue is null) return;
        var instance = Activator.CreateInstance(newValue.ModelType);
        if (instance is null) return;
        CurrentPage = instance as ViewModelBase;
    }

    public ObservableCollection<ListItemTemplate> Items { get; set; } = new ObservableCollection<ListItemTemplate>()
    {
        new ListItemTemplate(typeof(HomeViewModel),"HomeRegular"),
        new ListItemTemplate(typeof(RecordingViewModel),"MusicRegular"),
        new ListItemTemplate(typeof(FileManagerViewModel), "FolderRegular"),
    };


    private ReactiveCommand<Unit, Unit> _triggerPaneCommand;

    public ReactiveCommand<Unit, Unit> TriggerPaneCommand
    {
        get { return _triggerPaneCommand ?? ReactiveCommand.Create(() => { IsPaneOpen = !IsPaneOpen; }); }
    }
}
