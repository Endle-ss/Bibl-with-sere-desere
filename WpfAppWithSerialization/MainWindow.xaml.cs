using SerializationLibrary;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppWithSerialization
{
    public partial class MainWindow : Window
    {
        private readonly Serializer _serializer;
        private const string FilePath = "data.json";

        public MainWindow()
        {
            InitializeComponent();
            _serializer = new Serializer();
        }

        private async void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            var data = InputTextBox.Text;
            await _serializer.SerializeAsync(data, FilePath);
            MessageBox.Show("Data serialized!");
        }

        private async void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            var data = await _serializer.DeserializeAsync<string>(FilePath);
            OutputTextBox.Text = data ?? "No data found";
            MessageBox.Show("Data deserialized!");
        }
    }
}
