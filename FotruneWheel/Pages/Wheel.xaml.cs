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
using System.Windows.Threading;

namespace FotruneWheel.Pages
{
    /// <summary>
    /// Логика взаимодействия для Wheel.xaml
    /// </summary>
    public partial class Wheel : Page
    {
        public DispatcherTimer wheelTimer = new DispatcherTimer();
        private static readonly Random rand = new Random();
        public double currentAngle = 0;
        public int count = 0;
        public int countPrizes = 0;
        public int prize;
        public int wheelAngle;
        public bool IsRolling=true;
        public string result;

        public Wheel()
        {
            InitializeComponent();
            wheelTimer.Tick += wheelTimer_Tick;
            wheelTimer.Interval = new TimeSpan(0, 0, 0, 0, 150);
        }       
        private void wheelTimer_Tick(object sender, EventArgs e)
        {
            var bc = new BrushConverter();
            if (count== 0)
            {               
                IsRolling =false;
                ButtonRolling.Background= (Brush)bc.ConvertFrom("#b4b4b4");
                Rotate(wheelAngle);
                count++;
                if (wheelAngle > 360)
                {
                    wheelAngle -= 360;
                }
                currentAngle += wheelAngle;
                if (currentAngle > 360)
                {
                    currentAngle = currentAngle % 360;
                }
                prize = Convert.ToInt32(Math.Ceiling(currentAngle / 18));
                if (prize != 0)
                {
                    prize -= 1;
                }
                int[] values = new int[] { 425, 225, 375, -1, 25, 275, 400, 325, 100, 0, 200, 50, 350, 3000, 175, 475, 300, 125, 75, 500 };
                result = values[prize].ToString();
            }

            if (countPrizes > 0)
            {               
                int[] values = new int[] { 425, 225, 375, -1, 25, 275, 400, 325, 100, 0, 200, 50, 350, 3000, 175, 475, 300, 125, 75, 500 };
                PrizeTxt.Text = values[rand.Next(0,17)].ToString();
                countPrizes--;
            }

            if (countPrizes == 0)
            {
                IsRolling = true;
                wheelTimer.Stop();
                //ButtonRolling.Background = (Brush)bc.ConvertFrom("#1E90FF");
                //ButtonRolling.Style = (Style)ButtonRolling.FindResource("RollingButton2");
                PrizeTxt.Text = result;
            }          
        }
        public void Rotate(double angle)
        {          
            DoubleAnimation AnimatedRotateTransform = new DoubleAnimation()
            {
                By = angle,
                Duration = TimeSpan.FromSeconds(countPrizes * 150/1000d)
            };
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, AnimatedRotateTransform);
        }

        private void RoleWheel(object sender, RoutedEventArgs e)
        {
            if (IsRolling == true)
            {
                wheelAngle = rand.Next(360, 720);
                countPrizes = wheelAngle / 18;
                count = 0;
                wheelTimer.Start();
            }
            
           
        }
    }
}

