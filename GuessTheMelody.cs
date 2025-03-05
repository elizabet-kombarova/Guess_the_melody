using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;

namespace Угадай_мелодию
{
    public class GuessTheMelody
    {
        private MediaPlayer mediaPlayer;
        private string currentSong;
        public int totalPoints = 0;
        public List<Button> selectedButtons = new List<Button>();
        private List<string> remainingSongs = new List<string>();
        private string currentFolder = "";
        private SolidColorBrush defaultButtonColor = new SolidColorBrush(Color.FromArgb(0xFF, 0xD1, 0x00, 0x58));
        public bool buttonsLocked = false;

        public GuessTheMelody()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        /// <summary>
        /// Метод, воспроизводящий музыку рандомным образом
        /// </summary>
        /// <param name="folderName"></param>
        public void PlayRandomMusic(string folderName)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string musicFolderPath = Path.Combine(projectPath, folderName);
            string[] musicFiles = Directory.GetFiles(musicFolderPath);
            remainingSongs = new List<string>(musicFiles);
            Random randomizer = new Random();
            string randomMusicFilePath = remainingSongs[randomizer.Next(0, remainingSongs.Count)];
            remainingSongs.Remove(randomMusicFilePath);
            mediaPlayer.Open(new Uri(randomMusicFilePath));
            mediaPlayer.Play();
        }

        /// <summary>
        /// Остановка медиаплеера
        /// </summary>
        public void MediaStop()
        {
            mediaPlayer.Stop();
        }

        /// <summary>
        ///  Метод для получения названия песни из пути к файлу
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetSongName(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        /// <summary>
        /// Метод, декодирующий путь к песне для получения названия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
            currentSong = GetSongName(mediaPlayer.Source.AbsolutePath);
            currentSong = Uri.UnescapeDataString(currentSong);

            Button variant1 = new Button();
            Button variant2 = new Button();
            Button variant3 = new Button();
            Button variant4 = new Button();
            UpdateVariantButtons(currentFolder, variant1, variant2, variant3, variant4);
        }

        /// <summary>
        /// // Обработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Timer_Tick(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
        }

        /// <summary>
        /// Метод, сохраняющий выбранную кнопку в список
        /// </summary>
        /// <param name="button"></param>
        public void AddSelectedButton(Button button)
        {
            if (button != null && button.Tag is int points)
            {
                selectedButtons.Add(button);
            }
        }

        /// <summary>
        /// Метод, устанавливающий названия песен на кнопки
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="variant1"></param>
        /// <param name="variant2"></param>
        /// <param name="variant3"></param>
        /// <param name="variant4"></param>
        public void UpdateVariantButtons(string folderName, Button variant1, Button variant2, Button variant3, Button variant4)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string musicFolderPath = Path.Combine(projectPath, folderName);

            string[] musicFiles = Directory.GetFiles(musicFolderPath);
            Random randomizer = new Random();

            List<int> randomIndexes = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = randomizer.Next(0, musicFiles.Length);
                while (randomIndexes.Contains(randomIndex))
                {
                    randomIndex = randomizer.Next(0, musicFiles.Length);
                }
                randomIndexes.Add(randomIndex);
            }

            variant1.Content = GetSongName(musicFiles[randomIndexes[0]]);
            variant2.Content = GetSongName(musicFiles[randomIndexes[1]]);
            variant3.Content = GetSongName(musicFiles[randomIndexes[2]]);
            variant4.Content = GetSongName(musicFiles[randomIndexes[3]]);
        }
               
        /// <summary>
        /// Метод для установки цвета кнопок и подсчета баллов
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="lbSchet"></param>
        /// <param name="variant1"></param>
        /// <param name="variant2"></param>
        /// <param name="variant3"></param>
        /// <param name="variant4"></param>
        /// <param name="GamerName"></param>
        public void UpdateButtonColor(Button buttons, Label lbSchet, Button variant1, Button variant2, Button variant3, Button variant4, string GamerName)
        {
            string currentSong = GetSongName(mediaPlayer.Source.AbsolutePath);
            currentSong = Uri.UnescapeDataString(currentSong);

            if (!buttonsLocked) 
            {
                buttonsLocked = true; 
                if (buttons.Content.ToString() == currentSong)
                {
                    buttons.Background = Brushes.Green;

                    foreach (Button button in selectedButtons)
                    {
                        int points = (int)button.Tag;
                        totalPoints += points;
                    }
                    lbSchet.Content = $"{totalPoints} баллов";
                    selectedButtons.Clear();
                }
                else
                {
                    buttons.Background = Brushes.Red;

                    selectedButtons.Clear();
                    totalPoints -= 100;
                    lbSchet.Content = $"{totalPoints} баллов";

                    if (variant1.Content.ToString() == currentSong)
                    {
                        variant1.Background = Brushes.Green;
                    }
                    else if (variant2.Content.ToString() == currentSong)
                    {
                        variant2.Background = Brushes.Green;
                    }
                    else if (variant3.Content.ToString() == currentSong)
                    {
                        variant3.Background = Brushes.Green;
                    }
                    else if (variant4.Content.ToString() == currentSong)
                    {
                        variant4.Background = Brushes.Green;
                    }

                    mediaPlayer.Stop();
                }
            }
        }

        /// <summary>
        /// Метод, возвращающий возможность нажимать кнопки
        /// </summary>
        public void ResetButtonsLock()
        {
            buttonsLocked = false;
        }

        /// <summary>
        /// Метод, возвращающий первоначальный цвет кнопок
        /// </summary>
        /// <param name="variant1"></param>
        /// <param name="variant2"></param>
        /// <param name="variant3"></param>
        /// <param name="variant4"></param>
        public void ResetButtonColors(Button variant1, Button variant2, Button variant3, Button variant4)
        {
            variant1.Background = defaultButtonColor;
            variant2.Background = defaultButtonColor;
            variant3.Background = defaultButtonColor;
            variant4.Background = defaultButtonColor;
            ResetButtonsLock();
        }

        /// <summary>
        /// Метод, блокирующий повторный доступ к кнопкам
        /// </summary>
        /// <param name="button"></param>
        public void DisableAllButtons(Button button)
        {
            button.IsEnabled = false;
        }
    }
}
