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

namespace FotruneWheel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentGroup = 0;
        public List<Classes.Users> users = new List<Classes.Users>();
        public List<Classes.Prizes> prizes = new List<Classes.Prizes>();
        public List<Classes.Shares> shares = new List<Classes.Shares>();
        public List<Classes.groupPrizes> groupPrizes = new List<Classes.groupPrizes>();
        public List<Classes.Winners> winners = new List<Classes.Winners>();
        public List<Classes.Winners> firstGroupWinners = new List<Classes.Winners>();
        public List<Classes.Winners> secondGroupWinners = new List<Classes.Winners>();
        public List<Classes.Winners> thirdGroupWinners = new List<Classes.Winners>();
        public string localPath = System.IO.Directory.GetCurrentDirectory();
        public int currentPrize;
        public string numberOfDrawing;
        public bool aprooved = false;
        public string numberDocument="";
        public string date="";

        public MainWindow()
        {
            InitializeComponent();
            Classes.Connection.LoadUsers(users);
            Classes.Connection.LoadPrizes(prizes);
            Classes.Connection.LoadGroupPrizes(groupPrizes);
            Classes.Connection.LoadShares(shares);
            Classes.Connection.LoadWinners(winners);
            LoadWinners();
            numberOfDrawing = prizes[0].nrz;
            if (shares[0].approoved == "0")
            {
                aprooved = false;
            }
            else if(shares[0].approoved == "1")
            {
                aprooved = true;
            }
            OpenPages(pages.preview);
            //OpenPages(pages.documents);

        }
        public void LoadWinners()
        {
            if (winners.Count != 0)
            {
                for(int i = 0; i < winners.Count; i++)
                {
                    if(winners[i].prizeID == "2")
                    {
                        firstGroupWinners.Add(winners[i]);
                    }
                    else if(winners[i].prizeID == "3")
                    {
                        secondGroupWinners.Add(winners[i]);
                    }
                    else if(winners[i].prizeID == "4")
                    {
                        thirdGroupWinners.Add(winners[i]);
                    }
                }
            }
        }
        public enum pages
        {
            preview,
            prizes,
            information,
            documents
        }
        public void OpenPages(pages _pages)
        {
            if (_pages == pages.preview)
            {
                frame.Navigate(new Pages.PreviewPage(this));
            }
            else if (_pages == pages.prizes)
            {
                frame.Navigate(new Pages.FirstPrize(this));
            }
            else if (_pages == pages.information)

            {
                frame.Navigate(new Pages.InformationPage(this));
            }
            else if (_pages == pages.documents)

            {
                frame.Navigate(new Pages.Documents(this));
            }
        }
        private void Mooving(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
            //{
            //    DragMove();
            //}


        }
    }
}
