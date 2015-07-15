using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Fluxos.Auxiliar
{
    public class KinectToggleButton : KinectTileButton
    {
        public bool IsChecked { get; set; }
        public KinectToggleButton()
        {
            Click += AlterarEstado;
            this.Background = Brushes.RoyalBlue;
        }
        private void AlterarEstado
        (object sender, System.Windows.RoutedEventArgs e)
        {
            IsChecked = !IsChecked;
            if (IsChecked)
                this.Background = Brushes.DarkBlue;
            else
                this.Background = Brushes.RoyalBlue;
        }
    }

    /*
     <my:KinectToggleButton x:Name="btnEscalaCinza" 
                                       Content="Escala Cinza" 
                                       Height="130" 
                                       Foreground="White"/>

                <my:KinectToggleButton x:Name="btnEsqueletoUsuario"
                                       Content="Esqueleto do Usuário" 
                                       Height="130"
                                       Foreground="White"/>
     */
}
