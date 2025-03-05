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
    /// Логика взаимодействия для Результаты.xaml
    /// </summary>
    public partial class Результаты : Window
    {
        GuessTheMelody melody = new GuessTheMelody();
        private bool resultsRecorded = false;
        public string GamerName;
        public Результаты(GuessTheMelody melody, string gamerName)
        {
            InitializeComponent();
            this.melody = melody;
            GamerName = gamerName;

            if (!resultsRecorded)
            {
                string fileName = "Статистика.txt";
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine($"Имя игрока: {GamerName}" + "\n" + $"Набрано баллов: {melody.totalPoints}");
                    writer.WriteLine();
                }

                resultsRecorded = true;
            }

            string[] lines = File.ReadAllLines("Статистика.txt");
            foreach (string line in lines)
            {
                lbxStat.Items.Add(line);
            }

            tblResults.Text = "Поздравляем!" + "\n" + $"Вы набрали {melody.totalPoints} баллов";
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
        /// Закрытие приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseIt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
