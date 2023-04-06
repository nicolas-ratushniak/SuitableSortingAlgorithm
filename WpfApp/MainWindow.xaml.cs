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

    private SortContext _context = new();
    private ISortStrategy _strategy;
    private ArrayGenerator _generator = new();

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
        ArrayInputTB.Text = ArrayDecoder.ArrayToString(array);
    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(ArrayInputTB.Text))
        {
            WarningMessageLB.Content = "*The array is empty";
            return;
        }
        if (!ArrayDecoder.TryParseArray(ArrayInputTB.Text, out int[] array))
        {
            WarningMessageLB.Content = "*Invalid array entered";
            return;
        }
        if (_strategy is null)
        {
            WarningMessageLB.Content = "*None of sort algorithms was chosen";
            return;
        }

        WarningMessageLB.Content = "";

        _context.SetStrategy(_strategy);
        _context.Sort(array!);
        ArrayInputTB.Text = ArrayDecoder.ArrayToString(array!);
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        ArrayInputTB.Text = "";
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
