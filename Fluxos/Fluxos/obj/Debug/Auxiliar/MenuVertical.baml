   M S B A M L   `   `   `  ����A  =Fluxos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Fluxos.AuxiliarFluxos.Auxiliar  5      clr-namespace:FluxosFluxos  5      "    Fluxos.Auxiliar.MenuVertical   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,myclr-namespace:Fluxos.Auxiliar     5      &localclr-namespace:Fluxos     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      .��5      4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -   5        $��kinectRegionMenu��5      .��5   
   � -   5        $��	GradeMenu��5      $��0,0,0,0q�6    
�������  � RowDefinitions  5      +   %Fluxos.Auxiliar.RowDefinitionExtended  5      $	��180 �6+     5      $	��180 �6+     5      $	��180 �6+     5      $	��180 �6+    � ColumnDefinitions 5      .   (Fluxos.Auxiliar.ColumnDefinitionExtended  5      $	��180 �6.     5      $	��180 �6.     5      $	��180 �6.     5      $	��180 �6.   .+�5      :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  -   5        $��btnAbrir��5   #   $	��180��5      
����iA�
�������   LabelBackground
 �����   Fluxos.MainWindow   Abrir#��Z 5      .��5      �� -   5         ��Name$ imgBtnAbrir��5      $��60��6-   $��60��69   $e��_C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Abrir.png��6E    J� RenderTransformOrigin$ 0.289,0.542&�6�   5        5       -   5        $��btnDesenhar��5    #   $��0��66   $��1��6F   $	��180��5!      
����iA�
�������
 �����   EntrarModoDesenho#��Z 5"      .��5#      �� -   5        $ imgBtnDesenhar��5#      $��60��60   $��60��6<   $g��aC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Desenho.png��6H   $ 0.289,0.542&�6�   5$        5&      -   5        $��btnExcluirInicial��5&   #   $	��180��5'      
����iA�
�������
 �����$��Right=�5(   +   $��0��5)   #   $��2��63      ApagarArquivo#��Z 5*   #   .��5+      �� -   5        $ imgSalvarDesenhoInicial��5+      $��60��69   $��60��6E   $g��aC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Excluir.png��5,       $ 0.289,0.542&�6�   5-        5/      -	   5        $��btnHelp��5/   #   $	��180��50      
����iA�
�������
 �����$��Right=�51   +   $��1��52   #   $��2��63      Help#��Z 53   #   .��54      �� -
   5        $ imgHelp��54      $��60��6)   $��60��65   $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Help.png��55       $ 0.289,0.542&�6�   56        58      -   5        $��	btnFechar��58   #   $��Right=�65   $��0��6L   $��3��6\   $	��180��59      
����iA�
�������
 �����	   SairApp#��Z	 5:      .��5;      �� -   5        $ imgBtnFechar��5;      $��60��6.   $��60��6:   $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Sair.png��6F   $ 0.289,0.542&�6�   5<      4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5>      -   5        $��seletorSensorUI��5>   &   $��1��5?   &   $��3��5@   &   $��Center=�5A   &   $��Center=�5B   &   8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  5D      -   5        $��
verUsuario��5D   !   $��1��5E      $��3��5F   !   $	��130��5H      $��Center=�5I      $��Center=�5J      
   KinectRegion
 5G      ��  �� ElementName$ kinectRegionMenu��5J      .   (Fluxos.Auxiliar.KinectToogleCircleButton  5L      -   5          Name$ 
btnCanhoto��5L   *   $��1��5M   *   $��0��6:   $	��180��5N      
����iA�
�������
 �����   Canhoto#��Z 5O      .��5P      �� -   5        $ imgBtnCanhoto��5P      $��60��6/   $��60��6;   $p��jC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/maoesquerdaLetra.png��6G   $ 0.289,0.542&�6�   5Q        5T      -   5          Name$ btnEmail��5T   #   $��1��5U   *   $��1��6:   $	��180��5V      
����iA�
�������
 �����   Email#��Z 5W      .��5X      �� -   5        $ imgBtnEmail��5X      $��60��6-   $��60��69   $e��_C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/email.png��6E   $ 0.289,0.542&�6�   5Y        5\      -   5        $��btnAumentaLinha��5\   #   $��2��6:   $��0��6J   $	��180��5]      
����iA�
�������
 �����   AumentarLinha#��Z 5^      .��5_      �� -   5        $ imgAumentaLinha��5_      $��60��61   $��60��6=   $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Mais.png��6I   $ 0.289,0.542&�6�   5`        5b      -   5        $��btnDiminuirLinha��5b   #   $	��180��5c      
����iA�
�������
 �����$��3��5d   #   $��0��63      DiminuirLinha#��Z 5e   #   .��5f      �� -   5        $ imgDiminuirLinha��5f      $��60��62   $��60��6>   $e��_C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Menos.png��6J   $ 0.289,0.542&�6�   5g        5i      -   5        $ btnVermelho��5i   *   $	��180��5j      
����iA�
�������
 �����$��2��5k   #   $��1��63      Vermelho#��Z 5l   #   .��5m      �� -   5        $ imgVermelho��5m      $��60��6-   $��60��69   $h��bC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Vermelho.png��5n       $ 0.289,0.542&�6�   5o        5q      -   5        $ btnVerde��5q   *   $	��180��5r      
����iA�
�������
 �����$��3��5s   #   $��1��63      Verde#��Z 5t   #   .��5u      �� -   5        $ imgVerde��5u      $��60��6*   $��60��66   $e��_C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Verde.png��5v       $ 0.289,0.542&�6�   5w        5y      -   5        $ btnAzul��5y   *   $	��180��5z      
����iA�
�������
 �����$��2��5{   #   $��2��63      Azul#��Z 5|   #   .��5}      �� -   5        $ imgAzul��5}      $��60��6)   $��60��65   $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Azul.png��5~       $ 0.289,0.542&�6�   5        5�      -   5        $��	btnApagar��5�   #   $	��180��5�      
����iA�
�������
 �����$��3��5�   #   $��2��63      ApagarDesenho#��Z 5�   #   .��5�      �� -   5        $ 	imgApagar��5�      $��60��6+   $��60��67   $f��`C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Apagar.png��5�       $ 0.289,0.542&�6�   5�        5�      -   5        $��
btnExcluir��5�   #   $	��180��5�      
����iA�
�������
 �����$��Right=�5�   +   $��2��5�   #   $��3��63   #��Z 5�   #   .��5�      �� -    5        $ imgSalvarDesenho��5�      $��60��62   $��60��6>   $g��aC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Excluir.png��5�       $ 0.289,0.542&�6�   5�        5�      -!   5        $��btnApresentacao��5�   #   $	��180��5�      
����iA�
�������
 �����$��Right=�5�   +   $��3��5�   #   $��3��63      EntrarModoApresentacao#��Z 5�   #   .��5�      �� -"   5        $ imgApresentacao��5�      $��60��61   $��60��6=   $l��fC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Apresentacao.png��5�       $ 0.289,0.542&�6�   5�      5�      5�      5�      