using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace RandomHelloGenerator;

public class ViewModel : INotifyPropertyChanged
{
    public ViewModel()
    {
        Result = string.Empty;
        
        Name = "Some Name";
        
        GenerageMessageCommand = new RelayCommand(OnClick);
    }

    public string Name
    {
        get => field;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            field = value;

            OnPropertyChanged(nameof(Name));
        }
    }

    public string Result
    {
        get => field;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            field = value;

            OnPropertyChanged(nameof(Result));
        }
    }

    public ICommand GenerageMessageCommand { get; }

    void OnClick()
    {
        Random random = new Random();
        var helloMessageIndex = random.Next(5);

        Result = helloMessageIndex switch
        {
            0 => $"{Name}, hello!",
            1 => $"{Name}, hello hello!",
            2 => $"{Name}, hello there!",
            3 => $"{Name}, hello and welcome!",
            4 => $"{Name}, hello and have great day!",
            _ => throw new UnreachableException("This should not happen!")
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    
    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
