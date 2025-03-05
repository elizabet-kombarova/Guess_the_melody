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

namespace Угадай_мелодию
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        /// Открытие окна регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Регистрация регистрация = new Регистрация();
            регистрация.Show();
            Hide();
        }
    }
}
