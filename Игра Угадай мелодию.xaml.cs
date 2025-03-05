//**********************************************************************************
//* Название программы: "Игровое приложение "Угадай мелодию""                      *
//*                                                                                *
//* Назначение программы:  *
//*                                                                                *
//* Разработчик: студентка группы ПР-330/б Комбарова В.В.                          *
//*                                                                                *
//* Версия: 1.0                                                                    *
//**********************************************************************************

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
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Diagnostics;

namespace Угадай_мелодию
{
    /// <summary>
    /// Логика взаимодействия для Игра_Угадай_мелодию.xaml
    /// </summary>
    public partial class Игра_Угадай_мелодию : Window
    {
        private MediaPlayer mediaPlayer;
        public string GamerName;
        GuessTheMelody melody = new GuessTheMelody();

        public Игра_Угадай_мелодию(string gamerName)
        {
            InitializeComponent();

            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaEnded += melody.MediaPlayer_MediaEnded;

            Rus100.Tag = 100;
            Rus200.Tag = 200;
            Rus300.Tag = 300;
            Foreign100.Tag = 100;
            Foreign200.Tag = 200;
            Foreign300.Tag = 300;
            Cartoon100.Tag = 100;
            Cartoon200.Tag = 200;
            Cartoon300.Tag = 300;
            Young100.Tag = 100;
            Young200.Tag = 200;
            Young300.Tag = 300;

            GamerName = gamerName;
        }

        /// <summary>
        /// Проигрывание песен категории "90-е русские" стоимостю 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rus100_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("90Rus100");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("90Rus100", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Rus100);
        }

        /// <summary>
        /// Проигрывание песен категории "90-е русские" стоимостю 200
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rus200_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("90Rus200");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("90Rus200", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Rus200);
        }

        /// <summary>
        /// Проигрывание песен категории "90-е русские" стоимостю 300
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rus300_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("90Rus300");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("90Rus300", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Rus300);
        }

        /// <summary>
        /// Проигрывание песен категории "Из мультфильмов" стоимостю 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cartoon100_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("FromCartoon100");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "Из какого мультика песня?";
            melody.UpdateVariantButtons("FromCartoon100", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Cartoon100);
        }

        /// <summary>
        /// Проигрывание песен категории "Из мультфильмов" стоимостю 200
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cartoon200_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("FromCartoon200");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "Из какого мультика песня?";
            melody.UpdateVariantButtons("FromCartoon200", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Cartoon200);
        }

        /// <summary>
        /// Проигрывание песен категории "Из мультфильмов" стоимостю 300
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cartoon300_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("FromCartoon300");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "Из какого мультика песня?";
            melody.UpdateVariantButtons("FromCartoon300", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Cartoon300);
        }

        /// <summary>
        /// Проигрывание песен категории "Зарубежные" стоимостю 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foreign100_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("CatForeign100");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("CatForeign100", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Foreign100);
        }

        /// <summary>
        /// Проигрывание песен категории "Зарубежные" стоимостю 200
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foreign200_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("CatForeign200");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("CatForeign200", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Foreign200);
        }

        /// <summary>
        /// Проигрывание песен категории "Зарубежные" стоимостю 300
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foreign300_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("CatForeign300");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("CatForeign300", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Foreign300);
        }

        /// <summary>
        /// Проигрывание песен категории "Молодежные" стоимостю 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Young100_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("Youth100");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("Youth100", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Young100);
        }

        /// <summary>
        /// Проигрывание песен категории "Молодежные" стоимостю 200
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Young200_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("Youth200");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("Youth200", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Young200);
        }

        /// <summary>
        /// Проигрывание песен категории "Молодежные" стоимостю 300
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Young300_Click(object sender, RoutedEventArgs e)
        {
            melody.PlayRandomMusic("Youth300");
            Button clickedButton = sender as Button;
            melody.AddSelectedButton(clickedButton);
            Podskazka.Text = "";
            melody.UpdateVariantButtons("Youth300", variant1, variant2, variant3, variant4);
            melody.ResetButtonColors(variant1, variant2, variant3, variant4);
            melody.DisableAllButtons(Young300);
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

        /// <summary>
        /// Переход к финальному раунду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Final_Click(object sender, RoutedEventArgs e)
        {
            Финал финал = new Финал(melody, GamerName);
            финал.Show();
            Hide();
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
    }
}
