using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static DataGridStyle.ViewModels.MainWindowViewModel;

namespace DataGridStyle.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMaximize = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Member> members = new List<Member>();
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(membersDataGrid.Items.Count.ToString());
            members.Clear();
            int i = 0;
            foreach (var item in membersDataGrid.ItemsSource)
            {
                // 检查 DataGridCheckBoxColumn 列中的 IsChecked 属性是否为 true，表示该行被选中
                DataGridCheckBoxColumn checkBoxColumn = membersDataGrid.Columns[0] as DataGridCheckBoxColumn;
                if (checkBoxColumn != null && checkBoxColumn.GetCellContent(item) is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    members.Add(item as Member);

                    Console.WriteLine((item as Member).Number);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine((item as Member).Number);
                    Console.ResetColor();

                }
            }
            MessageBox.Show(members.Count.ToString());
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in membersDataGrid.ItemsSource)
            {
                DataGridCheckBoxColumn checkBoxColumn = membersDataGrid.Columns[0] as DataGridCheckBoxColumn;
                if (checkBoxColumn != null && checkBoxColumn.GetCellContent(item) is CheckBox checkBox)
                {
                    checkBox.IsChecked = true;
                }
            }
        }

        private void check_Unchecked(object sender, RoutedEventArgs e)
        {

            foreach (var item in membersDataGrid.ItemsSource)
            {
                DataGridCheckBoxColumn checkBoxColumn = membersDataGrid.Columns[0] as DataGridCheckBoxColumn;
                if (checkBoxColumn != null && checkBoxColumn.GetCellContent(item) is CheckBox checkBox)
                {
                    checkBox.IsChecked = false;
                }
            }
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
