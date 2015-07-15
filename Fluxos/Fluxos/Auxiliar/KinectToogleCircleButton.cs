using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Fluxos.Auxiliar
{
    public class KinectToogleCircleButton : KinectCircleButton
    {
        public bool IsChecked { get; set; }
        public KinectToogleCircleButton()
        {
            Click += AlterarEstado;
            //this.Background = Brushes.RoyalBlue;
        }
        private void AlterarEstado
        (object sender, System.Windows.RoutedEventArgs e)
        {
            IsChecked = !IsChecked;
            if (IsChecked)
                this.Foreground = Brushes.Red;
            else
                this.Foreground = Brushes.RoyalBlue;
        }
    }
}
