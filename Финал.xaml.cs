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

namespace Угадай_мелодию
{
    /// <summary>
    /// Логика взаимодействия для Финал.xaml
    /// </summary>
    public partial class Финал : Window
    {
        GuessTheMelody melody = new GuessTheMelody();
        public string GamerName;

        public Финал(GuessTheMelody melody, string gamerName)
        {
            InitializeComponent();
            this.melody = melody;
            LastSong.Tag = 2000;
            GamerName = gamerName;
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
        /// Прослушивание финальной песни
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastSong_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("FinalSongs");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            melody.UpdateVariantButtons("FinalSongs", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(LastSong);
        }

        /// <summary>
        /// Переход к главному окну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        /// <summary>
        /// Просмотр правил игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pravila_Click(object sender, RoutedEventArgs e)
        {
            Правила_игры правила_Игры = new Правила_игры();
            правила_Игры.Show();
        }

        /// <summary>
        /// Переход к окну с результатами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Results_Click(object sender, RoutedEventArgs e)
        {
            Результаты результаты = new Результаты(melody, GamerName);
            результаты.Show();
            Hide();
        }

        /// <summary>
        /// Вариант ответа 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void variant1_Click(object sender, RoutedEventArgs e)
        {
            melody.UpdateButtonColor(variant1, lbSchet, variant1, variant2, variant3, variant4, GamerName);
            melody.MediaStop();
        }

        /// <summary>
        /// Вариант ответа 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void variant2_Click(object sender, RoutedEventArgs e)
        {
            melody.UpdateButtonColor(variant2, lbSchet, variant1, variant2, variant3, variant4, GamerName);
            melody.MediaStop();
        }

        /// <summary>
        /// Вариант ответа 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void variant3_Click(object sender, RoutedEventArgs e)
        {
            melody.UpdateButtonColor(variant3, lbSchet, variant1, variant2, variant3, variant4, GamerName);
            melody.MediaStop();
        }

        /// <summary>
        /// Вариант ответа 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void variant4_Click(object sender, RoutedEventArgs e)
        {
            melody.UpdateButtonColor(variant4, lbSchet, variant1, variant2, variant3, variant4, GamerName);
            melody.MediaStop();
        }
    }
}
