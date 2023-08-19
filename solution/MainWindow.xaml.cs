using solution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SQLite;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;


namespace solution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region DataContext
        private readonly ViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModel(new View());
            DataContext = _viewModel;
        }

        #endregion DataContext

        #region WindowEvent
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ToMiniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void ToMaxButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowClose();
        }
        #endregion WindowEvent

        #region ButtonEvent
        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("정말로 진행하시겠습니까?", "확인", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // _viewModel.ChangeString1Command.Execute(null);
                SQLiteDataReaderExample(FilePathList.DefaultPath);
            }
        }
        #endregion ButtonEvent

        #region Function
        #region WindowEvent

        public void WindowLoaded()
        {
            try
            {

            }
            catch (Exception ex)
            {
                string Data = "WindowLoaded    " + ex.ToString();
                Console.WriteLine(Data);
            }
        }

        public void WindowClose()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("프로그램을 종료 하시겠습니까 ?", "프로그램 종료", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        this.Close();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            catch (Exception ex)
            {
                string Data = "WindowClose    " + ex.ToString();
                Console.WriteLine(Data);
            }
        }
        #endregion WindowEvent
        #endregion Function


        private string _connectionString;

        public void SQLiteDataReaderExample(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT Field1, Field2, Field3 FROM Recipe";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string field1 = reader["Field1"].ToString();
                            string field2 = reader["Field2"].ToString();
                            string field3 = reader["Field3"].ToString();

                            Console.WriteLine($"Field1: {field1}, Field2: {field2}, Field3: {field3}");
                        }
                    }
                }

                conn.Close();
            }
        }

       
    }
}
