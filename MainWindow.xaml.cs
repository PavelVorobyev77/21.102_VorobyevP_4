using _21._102_VorobyevP_4.Entity;
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

namespace _21._102_VorobyevP_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Entities context;
        private IQueryable<Group> query;

        public MainWindow()
        {
            InitializeComponent();
            context = new Entities(); // Создание экземпляра контекста базы данных
            LoadData.ItemsSource = context.Group.ToList(); // Загрузка данных из базы данных в DataGrid
            query = context.Group; // Инициализация запроса для работы с данными
        }

        private void SortComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ApplySorting();
        }

        private void ApplySorting()
        {
            var sortOption = SortComboBox.SelectedIndex;

            // Применение сортировки
            switch (sortOption)
            {
                case 0:
                    query = query.OrderBy(g => g.Title); // Если выбрано "По возрастанию группы"
                    break;
                case 1:
                    query = query.OrderByDescending(g => g.Title); // Если выбрано "По убыванию группы"
                    break;
                case 2:
                    query = query.OrderBy(g => g.CourseNumber);
                    break;
                case 3:
                    query = query.OrderByDescending(g => g.CourseNumber);
                    break;
            }

            LoadData.ItemsSource = query.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string groupName = SearchTextBox.Text.Trim();

            // Фильтрация по названию группы
            if (!string.IsNullOrWhiteSpace(groupName)) 
            {
                query = context.Group.Where(g => g.Title.Contains(groupName));
            }
            else
            {
                // если строка поиска пуста, то выводим все группы
                query = context.Group;
            }

            // смотрим результаты после применения фильтрации
            if (query.Any()) // если есть хотя бы один результат
            {
                // применяем сортировку 
                ApplySorting();
            }
            else
            {
                // если результатов поиска не найдено, выводим сообщение об этом
                MessageBox.Show("Результатов поиска не найдено.", "Поиск", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = ""; // Сброс строки поиска
            SortComboBox.SelectedIndex = -1; // Сброс выбора в ComboBox

            // Сброс сортировки и загрузка всех групп
            query = context.Group;
            LoadData.ItemsSource = query.ToList();
        }
    }
}

