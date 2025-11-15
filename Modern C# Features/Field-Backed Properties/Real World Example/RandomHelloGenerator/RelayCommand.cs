using System.Windows.Input;

namespace RandomHelloGenerator;

// Credit: https://stackoverflow.com/questions/3531772/binding-button-click-to-a-method

public class RelayCommand : ICommand
{
    readonly Action _execute;

    public RelayCommand(Action execute) => _execute = execute;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _execute();
}