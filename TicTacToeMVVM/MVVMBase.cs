using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToeMVVM;

public class MVVMBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}