   M S B A M L   `   `   `  ����A  =Fluxos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Fluxos.AuxiliarFluxos.Auxiliar  5      clr-namespace:FluxosFluxos  5          Fluxos.Auxiliar.Help   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      (myclr-namespace:Fluxos.Auxiliar   5      "localclr-namespace:Fluxos   5      .��5      4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -   5           Name$  kinectRegionHelp��5      .��5   
   � -   5        $��GradePrincipal��5      
������� � RowDefinitions 5      +   %Fluxos.Auxiliar.RowDefinitionExtended  5      $	��160 �6+     5      $��* �6+     5      $	��150 �6+     5      $��20 �6+    � ColumnDefinitions 5      .   (Fluxos.Auxiliar.ColumnDefinitionExtended  5      $��10 �6.     5      $	��160 �6.     5      $	��200 �6.     5      $��50 �6.     5      $��* �6.     5      $	��160 �6.     5      $��20 �6.   .+�5      �� -   5         ��Name$ imgHelp��5      $	��350��5      $	��350��5      $��0��5       $��1��5!      $��Center=�5"      $��3��5#      $��2��5$      $^��XC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Help/0.png��5%      :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  5'      -   5        $��btnExit��5(      $	��180��5)      $	��180��5*      
����iA�
�������   LabelBackground
 �����$��Right=�5.      $��5��5/      $��0��50         Fluxos.MainWindow   HideHelp#��Z 51      .��52      �� -   5        $ imgExit��52      $��80��53      $��80��54      $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Exit.png��55       J� RenderTransformOrigin$ 0.289,0.542&�56      57        59      -   5        $��btnNext��5:      $	��180��5;      $	��180��5<      
����iA�
������ 
 �����$��Right=�5@      $��5��5A      $��2��6!   .��5B      �� -   5        $ imgNext��5B      $��80��5C      $��80��5D      $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Next.png��5E      $ 0.289,0.542&�5F      5G        5I      -   5        $��btnPrevious��5J      $	��180��5K      $	��180��5L      
����iA�
������ 
 �����$��Right=�5P      $��0��5Q      $��2��5R      $��2��5S      $
��Left=�5T      .��5V      �� -	   5        $ imgPrevious��5V      $��80��5W      $��80��5X      $h��bC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Previous.png��5Y      $ 0.289,0.542&�5Z      5[      �� 5]      -
   5         ��Name$ 	lblTitulo��5]      $��Titulo��5^      
����iA�$��0��5`      $��1��5a      $��50(�5b      $
��Bold"�5c      $��Center=�5d      $��Center=�5e      $��5��5f      $
��Wrap=�5g      �� 5i      -   5        $ lblMensagem��5i      $��Mensagem��5j      
����iA�$��1��5l      $��3��5m      $��50(�5n      $
��Bold"�5o      $
��Left=�5p      $��Center=�5q      $��3��5r      $
��Wrap=�5s      �� 5u      -   5        $ lblObs��5u      $	��OBS��5v      
����iA�$��2��5x      $��2��5y      $��40(�5z      $
��Bold"�5{      $��Center=�5|      $��Center=�5}      $��3��5~      $
��Wrap=�5      5�      5�      5�      