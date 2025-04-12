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
using System.Windows.Media.Animation;

namespace FotruneWheel.Pages
{
    /// <summary>
    /// Логика взаимодействия для InformationPage.xaml
    /// </summary>
    public partial class InformationPage : Page
    {
        MainWindow mainWindow;
        public InformationPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            pageInf.Focus();
            mainWindow = _mainWindow;
            mainWindow.WindowState = WindowState.Maximized;
            Classes.Connection.LoadSharesCurrent(currentShares);
            Animation();
            LoadGroups();

            // this.KeyDown += new KeyEventHandler(Border_PreviewKeyDown);
        }
        public class CurrentShares
        {
            public string sheetNumber { get; set; }
            public string count { get; set; }

            public CurrentShares(string sheetNumber, string count)
            {
                this.sheetNumber = sheetNumber;
                this.count = count;
            }
        }
        public List<CurrentShares> currentShares = new List<CurrentShares>();
        public void LoadGroups()
        {
            var buttonWinner = new List<Classes.Winners>();
            buttonWinner = mainWindow.winners.Where(x => int.Parse(x.prizeID.ToString()) == int.Parse(mainWindow.currentGroup.ToString())).ToList();
            if (buttonWinner.Count > 0)
            {
                buttonTextPage2.Text = "Победители";
                buttonTextPage2.FontSize = 77;
            }
            else
            {
                buttonTextPage2.Text = "Разыграть";
                buttonTextPage2.FontSize = 87;
            }
            int countUsers = 0;
            int countShares = 0;
            if (mainWindow.currentGroup == 2)
            {
                firstGroupPhoto.ImageSource = new BitmapImage(new Uri(mainWindow.localPath + "/images/" + mainWindow.groupPrizes[0].img));
                nameFirstGroup.Text = mainWindow.groupPrizes[0].name;
                countFirstGroup.Text += mainWindow.groupPrizes[0].count;
                for (int i = 0; i < currentShares.Count; i++)
                {
                    if (Convert.ToInt32(currentShares[i].count) >= Convert.ToInt32(mainWindow.groupPrizes[mainWindow.currentGroup - 2].needShares)&& Convert.ToInt32(currentShares[i].count) <= Convert.ToInt32(mainWindow.groupPrizes[mainWindow.currentGroup - 2].maxShares))
                    {
                        countShares += Convert.ToInt32(currentShares[i].count);
                        countUsers++;
                    }
                }
                countUsersFirst.Text += countUsers.ToString();
                countUsersSecond.Text += countShares.ToString();
            }
            else if (mainWindow.currentGroup == 3)
            {
                firstGroupPhoto.ImageSource = new BitmapImage(new Uri(mainWindow.localPath + "/images/" + mainWindow.groupPrizes[1].img));
                nameFirstGroup.Text = mainWindow.groupPrizes[1].name;
                countFirstGroup.Text += mainWindow.groupPrizes[1].count;
                for (int i = 0; i < currentShares.Count; i++)
                {
                    if (Convert.ToInt32(currentShares[i].count) >= Convert.ToInt32(mainWindow.groupPrizes[mainWindow.currentGroup - 2].needShares))
                    {
                        countShares += Convert.ToInt32(currentShares[i].count);
                        countUsers++;
                    }
                }
                countUsersFirst.Text += countUsers.ToString();
                countUsersSecond.Text += countShares.ToString();
            }
            else if (mainWindow.currentGroup == 4)
            {
                firstGroupPhoto.ImageSource = new BitmapImage(new Uri(mainWindow.localPath + "/images/" + mainWindow.groupPrizes[2].img));
                nameFirstGroup.Text = mainWindow.groupPrizes[2].name;
                countFirstGroup.Text += mainWindow.groupPrizes[2].count;
                for (int i = 0; i < currentShares.Count; i++)
                {
                    if (Convert.ToInt32(currentShares[i].count) >= Convert.ToInt32(mainWindow.groupPrizes[mainWindow.currentGroup - 2].needShares))
                    {
                        countShares += Convert.ToInt32(currentShares[i].count);
                        countUsers++;
                    }
                }
                countUsersFirst.Text += countUsers.ToString();
                countUsersSecond.Text += countShares.ToString();
            }

            if (nameFirstGroup.Text.Length < 20)
            {
                nameFirstGroup.Margin = new Thickness(55, 218, 65, 0);
            }
            else
            {
                nameFirstGroup.Margin = new Thickness(55, 128, 65, 0);
            }
        }
        public async void Animation()
        {
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(1.5))
            };
            mainGrid.BeginAnimation(OpacityProperty, myDoubleAnimation);
            await Task.Delay(1500);
        }
        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TakeOff(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void tshirtButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.winners.Clear();
            Classes.Connection.LoadWinners(mainWindow.winners);
            if (mainWindow.currentGroup == 2)
            {
                if (mainWindow.winners.Count < Convert.ToInt32(mainWindow.groupPrizes[1].count) + Convert.ToInt32(mainWindow.groupPrizes[2].count))
                {
                    MessageBox.Show("Сначала нужно разыграть другие призы");
                }
                else
                {
                    mainWindow.OpenPages(MainWindow.pages.prizes);
                }
            }
            else if (mainWindow.currentGroup == 3)
            {
                if (mainWindow.winners.Count < Convert.ToInt32(mainWindow.groupPrizes[2].count))
                {
                    MessageBox.Show("Сначала нужно разыграть другие призы");
                }
                else
                {
                    mainWindow.OpenPages(MainWindow.pages.prizes);
                }
            }
            else
            {
                mainWindow.OpenPages(MainWindow.pages.prizes);
            }
        }

        private void f2press(object sender, KeyEventArgs e)
        {
            mainWindow.winners.Clear();
            Classes.Connection.LoadWinners(mainWindow.winners);
            if (e.Key == Key.F2)
            {
                if (mainWindow.currentGroup == 2)
                {
                    if (mainWindow.winners.Count < Convert.ToInt32(mainWindow.groupPrizes[1].count)+ Convert.ToInt32(mainWindow.groupPrizes[2].count))
                    {
                        MessageBox.Show("Сначала нужно разыграть другие призы");
                    }
                    else
                    {
                        mainWindow.OpenPages(MainWindow.pages.prizes);
                    }
                }
                else if(mainWindow.currentGroup == 3)
                {
                    if (mainWindow.winners.Count < Convert.ToInt32(mainWindow.groupPrizes[2].count))
                    {
                        MessageBox.Show("Сначала нужно разыграть другие призы");
                    }
                    else
                    {
                        mainWindow.OpenPages(MainWindow.pages.prizes);
                    }
                }
                else
                {
                    mainWindow.OpenPages(MainWindow.pages.prizes);
                }
            
               
            }
        }

        private void mainGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void back(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPages(MainWindow.pages.preview);
        }
    }
}
