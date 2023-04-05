using SortingLib;
using ArrayExtensionsLib;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _arrayInput = "";
    private string _warningMessage = "";
    private SortContext _context = new();
    private ISortStrategy _strategy;
    private ArrayGenerator _generator = new();

    public string ArrayInput
    {
        get => _arrayInput;

        set
        {
            if (_arrayInput != value)
            {
                _arrayInput = value;
            }
            OnPropertyChanged();
        }
    }

    public string WarningMessage
    {
        get => _warningMessage;

        set
        {
            if (_warningMessage != value)
            {
                _warningMessage = value;
            }
            OnPropertyChanged();
        }
    }

    public MainWindow()
    {
        DataContext = this;
        InitializeComponent();
    }

    public void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private void GenerateButon_Click(object sender, RoutedEventArgs e)
    {
        const int MinValue = -24;
        const int MaxValue = 25;
        const int ArraySize = 50;

        var array = new int[ArraySize];
        _generator.PopulateRandomly(array, MinValue, MaxValue);
        ArrayInput = ArrayDecoder.ArrayToString(array);
    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        if (ArrayDecoder.TryParseArray(ArrayInput, out int[] array))
        {
            if (_strategy is null)
            {
                WarningMessage = "*None of sort algorithms was chosen";
                return;
            }
            WarningMessage = "";

            _context.SetStrategy(_strategy);
            _context.Sort(array);
            ArrayInput = ArrayDecoder.ArrayToString(array);
        }
        else if (string.IsNullOrEmpty(ArrayInput))
        {
            WarningMessage = "*The array is empty";
        }
        else
        {
            WarningMessage = "*Invalid array entered";
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        ArrayInput = "";
    }

    private void SortOptionCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        string? text = (sender as ComboBox)?.SelectedItem as string;

        _strategy = text switch
        {
            "Bubble Sort" => new BubbleSort(),
            "Shaker Sort" => new ShakerSort(),
            "Insertion Sort" => new InsertionSort(),
            "Stooge Sort" => new StoogeSort(),
            "Shell Sort" => new ShellSort(),
            "Merge sort" => new MergeSort(),
            "Selection Sort" => new SelectionSort(),
            "Quick Sort" => new QuickSort(),
            _ => new BubbleSort()
        };
    }
}
