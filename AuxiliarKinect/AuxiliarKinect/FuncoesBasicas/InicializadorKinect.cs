using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Interaction;
using Microsoft.Kinect.Toolkit.Controls;

namespace AuxiliarKinect.FuncoesBasicas
{

    public class InicializadorKinect
    {
        public Action<KinectSensor> MetodoInicializadorKinect { get; set; }

        public KinectSensorChooser SeletorKinect { get; private set; }

        public InicializadorKinect()
        {
            SeletorKinect = new KinectSensorChooser();
            SeletorKinect.KinectChanged += SeletorKinect_KinectChanged;
            SeletorKinect.Start();
        }

        private void SeletorKinect_KinectChanged(object sender, KinectChangedEventArgs kinectArgs)
        {

            if (kinectArgs.OldSensor != null)
            {
                try
                {
                    if (kinectArgs.OldSensor.DepthStream.IsEnabled)
                        kinectArgs.OldSensor.DepthStream.Disable();

                    if (kinectArgs.OldSensor.SkeletonStream.IsEnabled)
                        kinectArgs.OldSensor.SkeletonStream.Disable();

                    if (kinectArgs.OldSensor.ColorStream.IsEnabled)
                        kinectArgs.OldSensor.ColorStream.Disable();

                }
                catch (InvalidOperationException)
                {
                    //captura exceção em algum dos fluxos caso entre em estado inválido
                }
            }

            if (kinectArgs.NewSensor != null)
            {
                if (MetodoInicializadorKinect != null)
                    MetodoInicializadorKinect(SeletorKinect.Kinect);
            }

        }

        /*
        public static KinectSensor InicializarPrimeiroSensor(int pAnguloElevacaoInicial)
        {
            KinectSensor lKinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
            lKinect.Start();
            lKinect.ElevationAngle = pAnguloElevacaoInicial;

            return lKinect;
        }
         * */
    }


}
