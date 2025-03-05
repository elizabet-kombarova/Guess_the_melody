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
using System.Windows.Shapes;
using System.IO;

namespace Угадай_мелодию
{
    /// <summary>
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Открытие справки приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spravka_Click(object sender, RoutedEventArgs e)
        {
            Справка справка = new Справка();
            справка.Show();
        }

        /// <summary>
        /// Проверка данных перед входом в программу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            string Name = string.Format(tbName.Text);
            string Parol = string.Format(passwordBox.Password);
            if (tbUser.SelectedIndex == 0)
            {
                try
                {
                    if (Name == "")
                        throw new Exception("Необходимо ввести имя игрока");

                    Игра_Угадай_мелодию игра_Угадай_Мелодию = new Игра_Угадай_мелодию(Name);
                    игра_Угадай_Мелодию.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        /// <summary>
        /// Визуал, соответствующий выбранной категории пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tbUser.SelectedIndex == 0)
            {
                lb.Content = "Введите имя:";
                tbName.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Hidden;
            }
        }
    }
}
