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
using FotruneWheel.Classes;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Drawing.Layout;

namespace FotruneWheel.Pages
{
    /// <summary>
    /// Логика взаимодействия для PreviewPage.xaml
    /// </summary>
    public partial class PreviewPage : Page
    {
        MainWindow mainWindow;
        BrushConverter bc = new BrushConverter();
        public PreviewPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            mainWindow.WindowState = WindowState.Maximized;
            LoadGroups();


            Animation();
        }
        public void LoadGroups()
        {
            Classes.Connection.LoadWinners(mainWindow.winners);
            mainWindow.currentPrize = mainWindow.winners.Count;
            var buttonWinner = new List<Classes.Winners>();
            buttonWinner = mainWindow.winners.Where(x => int.Parse(x.prizeID.ToString()) == 4).ToList();
            var buttonWinner2 = new List<Classes.Winners>();
            buttonWinner2 = mainWindow.winners.Where(x => int.Parse(x.prizeID.ToString()) == 3).ToList();
            var buttonWinner3 = new List<Classes.Winners>();
            buttonWinner3 = mainWindow.winners.Where(x => int.Parse(x.prizeID.ToString()) == 2).ToList();
            if(buttonWinner.Count == Convert.ToInt32(mainWindow.groupPrizes[2].count))
            {
                nameFirstGroup.Visibility = Visibility.Hidden;
                countFirstGroup.Visibility = Visibility.Hidden;
                endLotery.Visibility = Visibility.Visible;
                resultOfPrize.Visibility = Visibility.Visible;
            }
            else
            {
                nameFirstGroup.Visibility = Visibility.Visible;
                countFirstGroup.Visibility = Visibility.Visible;
                endLotery.Visibility = Visibility.Hidden;
                resultOfPrize.Visibility = Visibility.Hidden;
            }
            if (buttonWinner2.Count == Convert.ToInt32(mainWindow.groupPrizes[1].count))
            {
                nameSecondGroup.Visibility = Visibility.Hidden;
                secondCountGroup.Visibility = Visibility.Hidden;
                endLotery2.Visibility = Visibility.Visible;
                resultOfPrize2.Visibility = Visibility.Visible;
            }
            else
            {
                nameSecondGroup.Visibility = Visibility.Visible;
                secondCountGroup.Visibility = Visibility.Visible;
                endLotery2.Visibility = Visibility.Hidden;
                resultOfPrize2.Visibility = Visibility.Hidden;
            }
            if (buttonWinner3.Count == Convert.ToInt32(mainWindow.groupPrizes[0].count))
            {
                nameThirdGroup.Visibility = Visibility.Hidden;
                thirdCountGroup.Visibility = Visibility.Hidden;
                endLotery3.Visibility = Visibility.Visible;
                resultOfPrize3.Visibility = Visibility.Visible;
            }
            else
            {
                nameThirdGroup.Visibility = Visibility.Visible;
                thirdCountGroup.Visibility = Visibility.Visible;
                endLotery3.Visibility = Visibility.Hidden;
                resultOfPrize3.Visibility = Visibility.Hidden;
            }
            firstGroupPhoto.ImageSource = new BitmapImage(new Uri(mainWindow.localPath + "/images/" + mainWindow.groupPrizes[2].img));
            nameFirstGroup.Text=mainWindow.groupPrizes[2].name;
            countFirstGroup.Text = mainWindow.groupPrizes[2].count;

            secondGroupPhoto.ImageSource = new BitmapImage(new Uri(mainWindow.localPath + "/images/" + mainWindow.groupPrizes[1].img));
            nameSecondGroup.Text=mainWindow.groupPrizes[1].name;
            secondCountGroup.Text = mainWindow.groupPrizes[1].count;

            thirdGroupPhoto.ImageSource = new BitmapImage(new Uri(mainWindow.localPath + "/images/" + mainWindow.groupPrizes[0].img));
            nameThirdGroup.Text= mainWindow.groupPrizes[0].name;
            thirdCountGroup.Text = mainWindow.groupPrizes[0].count;

            if (nameSecondGroup.Text.Length <= 17)
            {
                nameSecondGroup.Margin=new Thickness(17,37,13,0);
            }
            if (nameFirstGroup.Text.Length <=17)
            {
                nameFirstGroup.Margin = new Thickness(17, 37, 13, 0);
            }
            if (nameThirdGroup.Text.Length <=17)
            {
                nameThirdGroup.Margin = new Thickness(17, 37, 13, 0);
            }
            if (mainWindow.aprooved == true)
            {
                resultOfPrize.Text = "Утверждено";
                resultOfPrize2.Text = "Утверждено";
                resultOfPrize3.Text = "Утверждено";
                clearBD.Visibility = Visibility.Hidden;
                yesButton.Visibility = Visibility.Hidden;
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

        private void FirstPrize(object sender, MouseButtonEventArgs e)
        {
            mainWindow.currentGroup = 4;
            mainWindow.OpenPages(MainWindow.pages.information);
        }
        private void PrizesRotateEnter1()
        {
            DoubleAnimation AnimatedRotateTransform = new DoubleAnimation()
            {
                From = 310,
                To = 330,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize1.BeginAnimation(HeightProperty, AnimatedRotateTransform);
            DoubleAnimation AnimatedRotateTransform1_1 = new DoubleAnimation()
            {
                From = 310,
                To = 330,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize1.BeginAnimation(WidthProperty, AnimatedRotateTransform1_1);
            
        }
        private void PrizesRotateLeave1()
        {
            DoubleAnimation AnimatedRotateTransform = new DoubleAnimation()
            {
                From = 330,
                To = 310,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize1.BeginAnimation(HeightProperty, AnimatedRotateTransform);
            DoubleAnimation AnimatedRotateTransform1_1 = new DoubleAnimation()
            {
                From = 330,
                To = 310,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize1.BeginAnimation(WidthProperty, AnimatedRotateTransform1_1);

        }
        private void PrizesRotateEnter2()
        {
            DoubleAnimation AnimatedRotateTransform = new DoubleAnimation()
            {
                From = 310,
                To = 330,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize2.BeginAnimation(HeightProperty, AnimatedRotateTransform);
            DoubleAnimation AnimatedRotateTransform1_1 = new DoubleAnimation()
            {
                From = 310,
                To = 330,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize2.BeginAnimation(WidthProperty, AnimatedRotateTransform1_1);

        }
        private void PrizesRotateLeave2()
        {
            DoubleAnimation AnimatedRotateTransform = new DoubleAnimation()
            {
                From = 330,
                To = 310,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize2.BeginAnimation(HeightProperty, AnimatedRotateTransform);
            DoubleAnimation AnimatedRotateTransform1_1 = new DoubleAnimation()
            {
                From = 330,
                To = 310,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize2.BeginAnimation(WidthProperty, AnimatedRotateTransform1_1);

        }
        private void PrizesRotateEnter3()
        {
            DoubleAnimation AnimatedRotateTransform = new DoubleAnimation()
            {
                From = 310,
                To = 330,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize3.BeginAnimation(HeightProperty, AnimatedRotateTransform);
            DoubleAnimation AnimatedRotateTransform1_1 = new DoubleAnimation()
            {
                From = 310,
                To = 330,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize3.BeginAnimation(WidthProperty, AnimatedRotateTransform1_1);

        }
        private void PrizesRotateLeave3()
        {
            DoubleAnimation AnimatedRotateTransform = new DoubleAnimation()
            {
                From = 330,
                To = 310,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize3.BeginAnimation(HeightProperty, AnimatedRotateTransform);
            DoubleAnimation AnimatedRotateTransform1_1 = new DoubleAnimation()
            {
                From = 330,
                To = 310,
                Duration = TimeSpan.FromSeconds(0.1)
            };
            prize3.BeginAnimation(WidthProperty, AnimatedRotateTransform1_1);

        }
        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            PrizesRotateEnter1();
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            PrizesRotateLeave1();
        }

        private void Ellipse_MouseEnter_1(object sender, MouseEventArgs e)
        {
            PrizesRotateEnter2();
        }

        private void Ellipse_MouseLeave_1(object sender, MouseEventArgs e)
        {
            PrizesRotateLeave2();

        }

        private void Ellipse_MouseEnter_2(object sender, MouseEventArgs e)
        {
            PrizesRotateEnter3();
        }

        private void Ellipse_MouseLeave_2(object sender, MouseEventArgs e)
        {
            PrizesRotateLeave3();
        }

        private void prize2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.currentGroup = 3;
            mainWindow.OpenPages(MainWindow.pages.information);
        }

        private void prize3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.currentGroup = 2;
            mainWindow.OpenPages(MainWindow.pages.information);
        }

        private void clearBD_MouseEnter(object sender, MouseEventArgs e)
        {
            clearBD.Background = (Brush)bc.ConvertFrom("#FF827F7F");
        }

        private void clearBD_MouseLeave(object sender, MouseEventArgs e)
        {
            clearBD.Background = (Brush)bc.ConvertFrom("#dcdcdc");
        }

        private void Clear(object sender, MouseButtonEventArgs e)
        {
            deleteDocs.Margin = new Thickness(0, 60, 150, 0);
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            deleteDocs.BeginAnimation(OpacityProperty, myDoubleAnimation);
        }

        private void yes_MouseEnter(object sender, MouseEventArgs e)
        {
            yesButton.Background = (Brush)bc.ConvertFrom("#FF827F7F");
        }

        private void yes_MouseLeave(object sender, MouseEventArgs e)
        {
            yesButton.Background = (Brush)bc.ConvertFrom("#dcdcdc");
        }

        private void yes_Button(object sender, MouseButtonEventArgs e)
        {
            aproovedChoice.Margin = new Thickness(0, 60, 100, 0);
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            aproovedChoice.BeginAnimation(OpacityProperty, myDoubleAnimation);
        }

        private void document_MouseEnter(object sender, MouseEventArgs e)
        {
            documentButton.Background = (Brush)bc.ConvertFrom("#FF827F7F");
        }

        private void document_MouseLeave(object sender, MouseEventArgs e)
        {
            documentButton.Background = (Brush)bc.ConvertFrom("#dcdcdc");
        }

        private void DocumentPage(object sender, MouseButtonEventArgs e)
        {
            documentsBar.Margin = new Thickness(0, 60, 50, 0);
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            documentsBar.BeginAnimation(OpacityProperty, myDoubleAnimation);
        }

        private void documentsFirst(object sender, MouseButtonEventArgs e)
        {
            if (mainWindow.aprooved == true)
            {
                mainWindow.OpenPages(MainWindow.pages.documents);
            }
        }

        private void documentsSecond(object sender, MouseButtonEventArgs e)
        {
            mainWindow.date = dateDocs.Text;
            mainWindow.numberDocument = numberDocs.Text;
            mainWindow.winners.Clear();
            Classes.Connection.LoadWinners(mainWindow.winners);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 12);
            XFont font2 = new XFont("Arial", 16, XFontStyle.Bold);
            XFont font3 = new XFont("Arial", 9);
            XFont font4 = new XFont("Arial", 12, XFontStyle.Bold);
            XFont font5 = new XFont("Arial", 14, XFontStyle.Bold);
            XFont fontX = new XFont("Muller", 30, XFontStyle.Bold);
            double Width = 0;
            double Height = 0;
            gfx.DrawString("УТВЕРЖДАЮ", font, XBrushes.Black, new XRect(385, 25, Width, Height), XStringFormats.TopCenter);
            gfx.DrawString("Генеральный директор ПАО ПНППК", font, XBrushes.Black, new XRect(375, 45, Width, Height), XStringFormats.TopCenter);
            gfx.DrawString("________________ Андреев А.Г.", font, XBrushes.Black, new XRect(367, 75, Width, Height), XStringFormats.TopCenter);
            gfx.DrawString("'___'  _____ 2023 г.", font, XBrushes.Black, new XRect(333, 105, Width, Height), XStringFormats.TopCenter);
            gfx.DrawString("ПРОТОКОЛ", font2, XBrushes.Black, new XRect(295, 155, Width, Height), XStringFormats.TopCenter);
            gfx.DrawString("Заседания тиражной комиссии ЛОТЕРЕИ КАЧЕСТВА", font2, XBrushes.Black, new XRect(295, 182, Width, Height), XStringFormats.TopCenter);
            gfx.DrawString("№" + mainWindow.numberDocument + "      от  " + mainWindow.date, font, XBrushes.Black, new XRect(295, 205, Width, Height), XStringFormats.TopCenter);
            gfx.DrawString("Тиражная комиссия в составе:", font, XBrushes.Black, new XRect(50, 245, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("1. Злобина О.С.", font, XBrushes.Black, new XRect(50, 265, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("- Председатель комиссии", font, XBrushes.Black, new XRect(220, 265, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("2. Смрнов А.В.", font, XBrushes.Black, new XRect(50, 285, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("- Член тиражной комиссии", font, XBrushes.Black, new XRect(220, 285, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("3. Смольяков А.В", font, XBrushes.Black, new XRect(50, 305, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("- Член тиражной комиссии", font, XBrushes.Black, new XRect(220, 305, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("4. Фишер А.И. ", font, XBrushes.Black, new XRect(50, 325, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("- Член тиражной комиссии", font, XBrushes.Black, new XRect(220, 325, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("5. Долматова Л.П.", font, XBrushes.Black, new XRect(50, 345, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("- Секретарь тиражной комиссии", font, XBrushes.Black, new XRect(220, 345, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("Сообщает, что в розыгрыше учавствовало                 " + mainWindow.shares.Count + "    акций качества", font, XBrushes.Black, new XRect(50, 375, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("Выйгрыш выпал еа следующие №№ акций качества:", font, XBrushes.Black, new XRect(50, 400, Width, Height), XStringFormats.CenterLeft);

            gfx.DrawString("Категория приза", font5, XBrushes.Black, new XRect(90, 430, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("Количество призов", font5, XBrushes.Black, new XRect(350, 430, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("№№ выигравших акций", font5, XBrushes.Black, new XRect(200, 450, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("_______________________________________________________", font2, XBrushes.Black, new XRect(50, 451, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString("ПЕРВЫЙ ПРИЗ", font4, XBrushes.Black, new XRect(110, 475, Width, Height), XStringFormats.CenterLeft);
            gfx.DrawString(mainWindow.groupPrizes[0].count, font4, XBrushes.Black, new XRect(450, 475, Width, Height), XStringFormats.CenterLeft);
            Width = 120;
            Height = 493;
            int count = 0;
            for (int i = 0; i < mainWindow.winners.Count; i++)
            {

                if (Convert.ToInt32(mainWindow.winners[i].prizeID) == 2)
                {
                    var shareList = new List<Classes.Shares>();
                    shareList = mainWindow.shares.Where(x => x.unique_number.ToString() == mainWindow.winners[i].winShare).ToList();
                    if (count < 4)
                    {
                        gfx.DrawString(mainWindow.winners[i].series + " - " + mainWindow.winners[i].number, font3, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                        Width += 110;
                        count++;
                    }
                    else
                    {
                        count = 1;
                        Width = 120;
                        Height += 17;
                        gfx.DrawString(mainWindow.winners[i].series + " - " + mainWindow.winners[i].number, font3, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                        Width += 110;
                    }
                }

            }
            Width = 120;
            count = 0;
            Height += 20;
            gfx.DrawString("ВТОРОЙ ПРИЗ", font4, XBrushes.Black, new XRect(110, Height, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString(mainWindow.groupPrizes[1].count, font4, XBrushes.Black, new XRect(450, Height, 0, 0), XStringFormats.CenterLeft);
            Height += 20;
            for (int i = 0; i < mainWindow.winners.Count; i++)
            {
                if (Convert.ToInt32(mainWindow.winners[i].prizeID) == 3)
                {
                    var shareList = new List<Classes.Shares>();
                    shareList = mainWindow.shares.Where(x => x.unique_number.ToString() == mainWindow.winners[i].winShare).ToList();
                    if (count < 4)
                    {
                        gfx.DrawString(mainWindow.winners[i].series + " - " + mainWindow.winners[i].number, font3, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                        Width += 110;
                        count++;
                    }
                    else
                    {
                        count = 1;
                        Width = 120;
                        Height += 17;
                        gfx.DrawString(mainWindow.winners[i].series + " - " + mainWindow.winners[i].number, font3, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                        Width += 110;
                    }

                }

            }
            Width = 120;
            count = 0;
            Height += 20;
            gfx.DrawString("ТРЕТИЙ ПРИЗ", font4, XBrushes.Black, new XRect(110, Height, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString(mainWindow.groupPrizes[2].count, font4, XBrushes.Black, new XRect(450, Height, 0, 0), XStringFormats.CenterLeft);
            Height += 26;
            gfx.DrawString("По реестру", font3, XBrushes.Black, new XRect(277, Height, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("см. Приложение №1", font3, XBrushes.Black, new XRect(450, Height, 0, 0), XStringFormats.CenterLeft);

            page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);
            gfx.DrawString("_____________________________________________________________________________", font, XBrushes.Black, new XRect(60, 40, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Выйгравшие акции и предъявленный пакет акций, игравших в категориях:", font, XBrushes.Black, new XRect(60, 70, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("первый и второй призы автоматически аннулируются", font, XBrushes.Black, new XRect(60, 100, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Предложение комиссии    _______________________________________________________", font, XBrushes.Black, new XRect(60, 140, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("_____________________________________________________________________________", font, XBrushes.Black, new XRect(60, 170, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("_____________________________________________________________________________", font, XBrushes.Black, new XRect(60, 170, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Выдача призов состоится    _____________________________________________________", font, XBrushes.Black, new XRect(60, 200, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Подписи членов комиссии    _____________________________________________________", font, XBrushes.Black, new XRect(60, 230, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("__________________________________________", font, XBrushes.Black, new XRect(290, 260, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("__________________________________________", font, XBrushes.Black, new XRect(290, 290, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("__________________________________________", font, XBrushes.Black, new XRect(290, 320, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("__________________________________________", font, XBrushes.Black, new XRect(290, 350, 0, 0), XStringFormats.CenterLeft);


            string filename = "Protocol.pdf";
            document.Save(filename);
            Process.Start(filename);
        }

        private void documentsThird(object sender, MouseButtonEventArgs e)
        {
            mainWindow.date = dateDocs.Text;
            mainWindow.numberDocument = numberDocs.Text;
            mainWindow.winners.Clear();
            Classes.Connection.LoadWinners(mainWindow.winners);
            Classes.Connection.LoadShares(mainWindow.shares);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            page.Height = 666;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XPen pen = new XPen(XColors.Black, 1);

            XFont font = new XFont("Arial", 12);
            XFont font2 = new XFont("Arial", 16, XFontStyle.Bold);
            XFont font3 = new XFont("Arial", 9);
            XFont font4 = new XFont("Arial", 10);
            XFont font5 = new XFont("Arial", 12, XFontStyle.Bold);
            XFont font6 = new XFont("Arial", 9, XFontStyle.Bold);
            XFont fontX = new XFont("Muller", 30, XFontStyle.Bold);
            double Width = 0;
            double Height = 0;
            int countPages = 1;
            int allFreeze = 0;

            gfx.DrawString("Приложение к протоколу тиражной", font, XBrushes.Black, new XRect(585, 45, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("комиссии №   " + mainWindow.numberDocument + " от  " + mainWindow.date, font, XBrushes.Black, new XRect(585, 65, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Реестр выйгравших и погашенных акций качества.", font2, XBrushes.Black, new XRect(225, 95, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString(mainWindow.date, font, XBrushes.Black, new XRect(50, 115, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Лист  " + countPages, font, XBrushes.Black, new XRect(750, 115, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawLine(pen, 40, 125, 810, 125);
            gfx.DrawLine(pen, 40, 175, 810, 175);
            gfx.DrawLine(pen, 40, 205, 810, 205);

            gfx.DrawLine(pen, 40, 125, 40, 205);
            gfx.DrawLine(pen, 100, 125, 100, 205);
            gfx.DrawLine(pen, 160, 125, 160, 205);

            gfx.DrawLine(pen, 440, 125, 440, 175);
            gfx.DrawLine(pen, 510, 125, 510, 175);
            gfx.DrawLine(pen, 580, 125, 580, 175);
            gfx.DrawLine(pen, 810, 125, 810, 205);

            gfx.DrawLine(pen, 210, 175, 210, 205);
            gfx.DrawLine(pen, 260, 175, 260, 205);
            gfx.DrawLine(pen, 310, 175, 310, 205);
            gfx.DrawLine(pen, 360, 175, 360, 205);
            gfx.DrawLine(pen, 410, 175, 410, 205);
            gfx.DrawLine(pen, 460, 175, 460, 205);
            gfx.DrawLine(pen, 510, 175, 510, 205);
            gfx.DrawLine(pen, 560, 175, 560, 205);
            gfx.DrawLine(pen, 610, 175, 610, 205);
            gfx.DrawLine(pen, 660, 175, 660, 205);
            gfx.DrawLine(pen, 710, 175, 710, 205);
            gfx.DrawLine(pen, 760, 175, 760, 205);
            gfx.DrawLine(pen, 810, 175, 810, 205);

            gfx.DrawString("Таб.№", font, XBrushes.Black, new XRect(50, 137, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Цех", font, XBrushes.Black, new XRect(113, 137, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Фамилия, имя, отчество", font, XBrushes.Black, new XRect(240, 137, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("владельца", font, XBrushes.Black, new XRect(268, 152, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Категория", font, XBrushes.Black, new XRect(446, 137, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("приза", font, XBrushes.Black, new XRect(458, 152, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Стоимость", font, XBrushes.Black, new XRect(514, 137, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("приза", font, XBrushes.Black, new XRect(528, 152, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("Наименование приза", font, XBrushes.Black, new XRect(633, 137, 0, 0), XStringFormats.CenterLeft);

            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(113, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(167, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(217, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(267, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(317, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(367, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(417, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(467, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(517, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(567, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(617, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(667, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(717, 190, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(767, 190, 0, 0), XStringFormats.CenterLeft);


            int countLine = 0;
            Height = 225;
            for (int i = mainWindow.winners.Count - 1; i >= 0; i--)
            {
                countLine = 0;
                Width = 50;
                gfx.DrawString(mainWindow.winners[i].sheetNumber, font5, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                Width += 50;
                gfx.DrawString(mainWindow.winners[i].departament, font5, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                Width += 80;
                gfx.DrawString(mainWindow.winners[i].surname, font5, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                Width += 275;
                gfx.DrawString(mainWindow.winners[i].prizeID, font5, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                Width += 40;
                var prizeList = new List<Classes.Prizes>();
                prizeList = mainWindow.prizes.Where(x => x.unique_number.ToString() == mainWindow.winners[i].prize).ToList();
                double numberCost = Convert.ToDouble(prizeList[0].cost);
                string cost = string.Format("{0:f}", numberCost);
                gfx.DrawString(cost, font5, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                Width += 70;
                XTextFormatter tf = new XTextFormatter(gfx);
                tf.Alignment = XParagraphAlignment.Justify;
                tf.DrawString(prizeList[0].name, font5, XBrushes.Black, new XRect(Width, Height - 7, 240, 40), XStringFormats.TopLeft);
                // gfx.DrawString(prizeList[0].name, font6, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);


                Width = 55;
                Height += 30;
                var shareList = new List<Classes.Shares>();
                shareList = mainWindow.shares.Where(x => x.sheetNumber.ToString() == mainWindow.winners[i].sheetNumber).ToList();
                gfx.DrawString("выйгрыш", font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                Width += 75;
                gfx.DrawString(mainWindow.winners[i].series + "    -    " + mainWindow.winners[i].number, font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);

                int checkEleven = 0;
                for (int b = 0; b < shareList.Count; b++)
                {
                    if (shareList[b].freeze == "11")
                    {
                        checkEleven++;
                    }
                }
                if (checkEleven > 0)
                {
                    Height += 30;
                    Width = 55;
                    gfx.DrawString("погашено", font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                    Width += 75;
                    for (int j = 0; j < shareList.Count; j++)
                    {

                        if (shareList[j].freeze == "11")
                        {
                            allFreeze++;
                            if (countLine < 7)
                            {
                                gfx.DrawString(shareList[j].series + "    -    " + shareList[j].number, font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                                Width += 100;
                                countLine++;
                            }
                            else
                            {
                                countLine = 1;
                                Width = 130;
                                Height += 30;
                                gfx.DrawString(shareList[j].series + "    -    " + shareList[j].number, font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
                                Width += 100;
                            }
                        }
                        if (Height > 590 && (i == mainWindow.winners.Count - 1 || countLine == 7))
                        {
                            countPages++;
                            page = document.AddPage();
                            page.Orientation = PdfSharp.PageOrientation.Landscape;
                            page.Height = 666;
                            gfx = XGraphics.FromPdfPage(page);

                            gfx.DrawString(DateTime.Today.ToShortDateString(), font, XBrushes.Black, new XRect(50, 15, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("Лист  " + countPages, font, XBrushes.Black, new XRect(750, 15, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawLine(pen, 40, 25, 810, 25);
                            gfx.DrawLine(pen, 40, 75, 810, 75);
                            gfx.DrawLine(pen, 40, 105, 810, 105);

                            gfx.DrawLine(pen, 40, 25, 40, 105);
                            gfx.DrawLine(pen, 100, 25, 100, 105);
                            gfx.DrawLine(pen, 160, 25, 160, 105);

                            gfx.DrawLine(pen, 440, 25, 440, 75);
                            gfx.DrawLine(pen, 510, 25, 510, 75);
                            gfx.DrawLine(pen, 580, 25, 580, 75);
                            gfx.DrawLine(pen, 810, 25, 810, 105);

                            gfx.DrawLine(pen, 210, 75, 210, 105);
                            gfx.DrawLine(pen, 260, 75, 260, 105);
                            gfx.DrawLine(pen, 310, 75, 310, 105);
                            gfx.DrawLine(pen, 360, 75, 360, 105);
                            gfx.DrawLine(pen, 410, 75, 410, 105);
                            gfx.DrawLine(pen, 460, 75, 460, 105);
                            gfx.DrawLine(pen, 510, 75, 510, 105);
                            gfx.DrawLine(pen, 560, 75, 560, 105);
                            gfx.DrawLine(pen, 610, 75, 610, 105);
                            gfx.DrawLine(pen, 660, 75, 660, 105);
                            gfx.DrawLine(pen, 710, 75, 710, 105);
                            gfx.DrawLine(pen, 760, 75, 760, 105);
                            gfx.DrawLine(pen, 810, 75, 810, 105);

                            gfx.DrawString("Таб.№", font, XBrushes.Black, new XRect(50, 37, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("Цех", font, XBrushes.Black, new XRect(113, 37, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("Фамилия, имя, отчество", font, XBrushes.Black, new XRect(240, 37, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("владельца", font, XBrushes.Black, new XRect(268, 52, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("Категория", font, XBrushes.Black, new XRect(446, 37, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("приза", font, XBrushes.Black, new XRect(458, 52, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("Стоимость", font, XBrushes.Black, new XRect(514, 37, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("приза", font, XBrushes.Black, new XRect(528, 52, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("Наименование приза", font, XBrushes.Black, new XRect(633, 37, 0, 0), XStringFormats.CenterLeft);

                            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(113, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(167, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(217, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(267, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(317, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(367, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(417, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(467, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(517, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(567, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(617, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(667, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(717, 90, 0, 0), XStringFormats.CenterLeft);
                            gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(767, 90, 0, 0), XStringFormats.CenterLeft);

                            Height = 120;
                        }

                    }
                }

                Height += 30;
                if (Height > 590)
                {
                    countPages++;
                    page = document.AddPage();
                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                    page.Height = 666;
                    gfx = XGraphics.FromPdfPage(page);

                    gfx.DrawString(DateTime.Today.ToShortDateString(), font, XBrushes.Black, new XRect(50, 15, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("Лист  " + countPages, font, XBrushes.Black, new XRect(750, 15, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawLine(pen, 40, 25, 810, 25);
                    gfx.DrawLine(pen, 40, 75, 810, 75);
                    gfx.DrawLine(pen, 40, 105, 810, 105);

                    gfx.DrawLine(pen, 40, 25, 40, 105);
                    gfx.DrawLine(pen, 100, 25, 100, 105);
                    gfx.DrawLine(pen, 160, 25, 160, 105);

                    gfx.DrawLine(pen, 440, 25, 440, 75);
                    gfx.DrawLine(pen, 510, 25, 510, 75);
                    gfx.DrawLine(pen, 580, 25, 580, 75);
                    gfx.DrawLine(pen, 810, 25, 810, 105);

                    gfx.DrawLine(pen, 210, 75, 210, 105);
                    gfx.DrawLine(pen, 260, 75, 260, 105);
                    gfx.DrawLine(pen, 310, 75, 310, 105);
                    gfx.DrawLine(pen, 360, 75, 360, 105);
                    gfx.DrawLine(pen, 410, 75, 410, 105);
                    gfx.DrawLine(pen, 460, 75, 460, 105);
                    gfx.DrawLine(pen, 510, 75, 510, 105);
                    gfx.DrawLine(pen, 560, 75, 560, 105);
                    gfx.DrawLine(pen, 610, 75, 610, 105);
                    gfx.DrawLine(pen, 660, 75, 660, 105);
                    gfx.DrawLine(pen, 710, 75, 710, 105);
                    gfx.DrawLine(pen, 760, 75, 760, 105);
                    gfx.DrawLine(pen, 810, 75, 810, 105);

                    gfx.DrawString("Таб.№", font, XBrushes.Black, new XRect(50, 37, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("Цех", font, XBrushes.Black, new XRect(113, 37, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("Фамилия, имя, отчество", font, XBrushes.Black, new XRect(240, 37, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("владельца", font, XBrushes.Black, new XRect(268, 52, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("Категория", font, XBrushes.Black, new XRect(446, 37, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("приза", font, XBrushes.Black, new XRect(458, 52, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("Стоимость", font, XBrushes.Black, new XRect(514, 37, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("приза", font, XBrushes.Black, new XRect(528, 52, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("Наименование приза", font, XBrushes.Black, new XRect(633, 37, 0, 0), XStringFormats.CenterLeft);

                    gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(113, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(167, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(217, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(267, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(317, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(367, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(417, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(467, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(517, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(567, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(617, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(667, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("выпуск", font4, XBrushes.Black, new XRect(717, 90, 0, 0), XStringFormats.CenterLeft);
                    gfx.DrawString("№ акции", font4, XBrushes.Black, new XRect(767, 90, 0, 0), XStringFormats.CenterLeft);

                    Height = 120;
                }


            }
            if (Height > 450)
            {
                page = document.AddPage();
                page.Orientation = PdfSharp.PageOrientation.Landscape;
                page.Height = 666;
                gfx = XGraphics.FromPdfPage(page);
                Height = 0;
            }
            Height += 60;
            Width = 50;
            gfx.DrawString("Итого:    всего акций выйгравших   " + mainWindow.winners.Count, font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
            Height += 30;
            Width = 90;
            gfx.DrawString("Всего акций поагшеных   " + allFreeze, font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
            Height += 30;
            double fullCost = 0;
            for (int i = 0; i < mainWindow.prizes.Count; i++)
            {
                fullCost += Convert.ToDouble(mainWindow.prizes[i].cost);
            }
            string costFull = string.Format("{0:f}", fullCost);
            gfx.DrawString("Общая стоимость призов ", font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
            gfx.DrawString(costFull, font2, XBrushes.Black, new XRect(520, Height, 0, 0), XStringFormats.CenterLeft);
            Height += 30;
            Width = 120;

            gfx.DrawString("Председатель тиражной комиссии", font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);
            Height += 50;
            gfx.DrawString("Секретарь тиражной комиссии ", font4, XBrushes.Black, new XRect(Width, Height, 0, 0), XStringFormats.CenterLeft);






            string filename = "Приложение к протоколу.pdf";
            document.Save(filename);
            Process.Start(filename);
        }



        private void yesChoice(object sender, MouseButtonEventArgs e)
        {
            mainWindow.winners.Clear();
            Classes.Connection.LoadWinners(mainWindow.winners);
            if (mainWindow.winners.Count == Convert.ToInt32(mainWindow.groupPrizes[0].count) + Convert.ToInt32(mainWindow.groupPrizes[1].count) + Convert.ToInt32(mainWindow.groupPrizes[2].count))
            {
                clearBD.Visibility = Visibility.Hidden;
                yesButton.Visibility = Visibility.Hidden;
                resultOfPrize.Text = "Утверждено";
                resultOfPrize2.Text = "Утверждено";
                resultOfPrize3.Text = "Утверждено";
                mainWindow.aprooved = true;
                documentButton.Background = (Brush)bc.ConvertFrom("#dcdcdc");
                Classes.Connection.Approved();
            }
            else
            {
                questionAprooved.Text = "Разыграйте все призы";
                questionAprooved.Foreground = (Brush)bc.ConvertFrom("#ff0000");
            }

        }

        private async void noChoice(object sender, MouseButtonEventArgs e)
        {
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            aproovedChoice.BeginAnimation(OpacityProperty, myDoubleAnimation);
            await Task.Delay(300);
            aproovedChoice.Margin = new Thickness(2000);
        }

        private async void yesDelete(object sender, MouseButtonEventArgs e)
        {
            Classes.Connection.DeleteWinners();
            LoadGroups();
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            deleteDocs.BeginAnimation(OpacityProperty, myDoubleAnimation);
            await Task.Delay(300);
            deleteDocs.Margin = new Thickness(2000);

        }

        private async void noDelete(object sender, MouseButtonEventArgs e)
        {
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            deleteDocs.BeginAnimation(OpacityProperty, myDoubleAnimation);
            await Task.Delay(300);
            deleteDocs.Margin = new Thickness(2000);
        }

        private async void documentsBarClose(object sender, MouseEventArgs e)
        {
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            documentsBar.BeginAnimation(OpacityProperty, myDoubleAnimation);
            await Task.Delay(300);
            documentsBar.Margin = new Thickness(2000);
        }

        private async void aproovedLeave(object sender, MouseEventArgs e)
        {
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            aproovedChoice.BeginAnimation(OpacityProperty, myDoubleAnimation);
            await Task.Delay(300);
            aproovedChoice.Margin = new Thickness(2000);
        }

        private async void deleteLeave(object sender, MouseEventArgs e)
        {
            var myDoubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            deleteDocs.BeginAnimation(OpacityProperty, myDoubleAnimation);
            await Task.Delay(300);
            deleteDocs.Margin = new Thickness(2000);
        }
    }
}
