   M S B A M L   `   `   `  ����A  =Fluxos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Fluxos.AuxiliarFluxos.Auxiliar  5   	   clr-namespace:FluxosFluxos  5   	       Fluxos.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   (myclr-namespace:Fluxos.Auxiliar   5   	   "localclr-namespace:Fluxos   5   	   -   5          � Title$  KSlide��5   	   $	��800��6/   $
��1500��6<    � WindowState$ 	Maximized=�6I    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Fluxos.MainWindow   OkInformacao   Command# Z 5      6L     5   
   -   5           Help# Z 5      6D     5   
   -   5           
OkInputBox# Z 5      6J     5   
   -   5           HideHelp# Z 5      6H     5   
   -   5           Email# Z 5      6E     5   
   -   5        	   Canhoto# Z	 5      6G     5   
   -   5        
   Abrir# Z
 5      6E     5   
   -	   5           EntrarModoDesenho# Z 5      6Q     5   
   -
   5        # Z	 5      6G     5   
   -   5           SairApp# Z 5      6G     5   
   -   5           AumentarLinha# Z 5      6M     5!   
   -   5           DiminuirLinha# Z 5!      6M     5#   
   -   5           Vermelho# Z 5#      6H     5%   
   -   5           Azul# Z 5%      6D     5'   
   -   5           Verde# Z 5'      6E     5)   
   -   5           ApagarDesenho# Z 5)      6M     5+   
   -   5           ApagarArquivo# Z 5+      6M     5-   
   -   5           EntrarModoApresentacao# Z 5-      6V     5/   
   -   5           
SlideClick# Z 5/      6J   .��53      � -   5        $��GradePrincipal��53       � RowDefinitions 54   
   +   %Fluxos.Auxiliar.RowDefinitionExtended  55      $��50 �6'     56      $��* �6'     57      $	��180 �6'     58      $	��180 �6'    � ColumnDefinitions 5:   
   .   (Fluxos.Auxiliar.ColumnDefinitionExtended  5;      $	��250 �6*     5<      $��* �6*     5=      $��25 �6*   .+�5?   
   �� -   5        $��canvasKinect��5?      $��1��6%   $��1��63   %   Fluxos.Auxiliar.CanvasInteracao  5@   
   -   5          Name$ canvasDesenho��5@      $��1��64   $��1��6D   "   Fluxos.Auxiliar.MenuVertical  5B   
   -   5          Name$ menuVertical��5B      $
��Left=�60   $y�Visible=�6K   $��1��5C      $��1��6*   5D          Fluxos.Auxiliar.MenuSlides  5F   
   -   5          Name$ 
menuSlides��5F      $
��Left=�6,   $y�Visible=�6G   $��1��5G      $��1��6*   $��Bottom=�67   5H      4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5J   
   -   5        $��seletorSensorUI��5J   "   $��1��69   $��Center=�6I   $	��Top=�6f   8	  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer	  5K   
   -   5        $��
verUsuario��5K      $��1��5L      $��50��5N      $��Center=�5O      $	��Top=�5P      4
  .Microsoft.Kinect.Toolkit.Controls.KinectRegion 
  KinectRegion 5M      ��  �� ElementName$ kinectRegion��5P      ]� 5S   
   $��2��6   .+�5T      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  -   5        $��scrollViewer��5T   #   $��1��5U      $��0��5V      .��5W      � -   5         �Name$ 	wrapPanel��5X      $��Center=�5W       � Orientation$ Vertical=�5Y      .+�5\      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton     Label$ 1��6)     5]      $ 2��6)     5^      $ 3��6)     5_      $ 4��6)     5`      $ 5��6)   5a      5c      5d      �� 5e   
   -   5        $��slider��5e      $��20��5f        �� Orientation$  Vertical=�5g      ! � Minimum$	! -27Q�5h      " � Maximum$" 27Q�5i      # � SmallChange$# 1Q�5j      $ � Value$$ 0Q�5k      $��2��5m      $��1��5n      ��5l      �� $ imagemCamera��% �� Path$% ActualHeight�5o      ]� 5q   
   $��2��6   $��0��6!   $��2��61   .+�5r      :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  -   5        $��	btnFechar��5r   #   $��Right=�65   $	��180��5s      
����iA�
�������&   LabelBackground
& �����.��5u      �� -    5        ' ��Name$' imgBtnFechar��5u      $��60��6.   $��60��6:   $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Sair.png��6F   ( J� RenderTransformOrigin$( 0.289,0.542&�6�   5v      �� 5z      ) �� Orientation$) 
Horizontal=�6   $
��Left=�62   $	��862��6M   .+�5|        -!   5        $��btnAbrir��5|   '   $	��180��5}      
����iA�
�������
& �����.��5      �� -"   5        $' imgBtnAbrir��5      $��60��61   $��60��6=   $e��_C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Abrir.png��6I   $( 0.289,0.542&�6�   5�        5�      -#   5        $��btnDesenhar��5�   '   $	��180��5�      
����iA�
�������
& �����.��5�      �� -$   5        $' imgBtnDesenhar��5�      $��60��64   $��60��6@   $g��aC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Desenho.png��6L   $( 0.289,0.542&�6�   5�      �� 5�      -%   5        * ��Name$* tblGestures��5�   .   + �� TextWrapping$
+ Wrap=�6   $��TextBox��6C   $��25(�6R   $	��200��6a   5�      5�      ]� 5�   
   $��3��6   $��0��6!   $��2��61   .+�5�        -&   5        $��btnApresentacao��5�   #   $	��180��5�      
����iA�
�������
& �����$��Right=�5�   +   .��5�      �� -'   5        $' imgApresentacao��5�      $��60��61   $��60��6=   $l��fC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Apresentacao.png��5�       $( 0.289,0.542&�6�   5�        5�      -(   5        $��
btnExcluir��5�   #   $	��180��5�      
����iA�
�������
& �����$��Right=�5�   +   .��5�      �� -)   5        $' imgSalvarDesenho��5�      $��60��62   $��60��6>   $g��aC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Excluir.png��5�       $( 0.289,0.542&�6�   5�      �� 5�      $) 
Horizontal=�6   $
��Left=�62   $
��1110��6M   .+�5�        -*   5        $��btnAumentaLinha��5�   '   $	��180��5�      
����iA�
�������
& �����.��5�      �� -+   5        $' imgAumentaLinha��5�      $��60��65   $��60��6A   $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Mais.png��6M   $( 0.289,0.542&�6�   5�        5�      -,   5        $��btnDiminuirLinha��5�   '   $	��180��5�      
����iA�
�������
& �����.��5�      �� --   5        $' imgDiminuirLinha��5�      $��60��66   $��60��6B   $e��_C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Menos.png��6N   $( 0.289,0.542&�6�   5�        5�      -.   5        $��btnVermelho��5�   '   $	��180��5�      
����iA�
�������
& �����.��5�      �� -/   5        $' imgVermelho��5�      $��60��61   $��60��6=   $h��bC:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Vermelho.png��5�       $( 0.289,0.542&�6�   5�        5�      -0   5        $��btnVerde��5�   '   $	��180��5�      
����iA�
�������
& �����.��5�      �� -1   5        $' imgVerde��5�      $��60��6.   $��60��6:   $e��_C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Verde.png��5�       $( 0.289,0.542&�6�   5�        5�      -2   5        $��btnAzul��5�   '   $	��180��5�      
����iA�
�������
& �����.��5�      �� -3   5        $' imgAzul��5�      $��60��6-   $��60��69   $d��^C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Azul.png��5�       $( 0.289,0.542&�6�   5�        5�      -4   5        $��	btnApagar��5�   '   $	��180��5�      
����iA�
�������
& �����.��5�      �� -5   5        $' 	imgApagar��5�      $��60��6/   $��60��6;   $f��`C:\Users\Renato\Documents\Visual Studio 2013\Projects\Fluxos\Fluxos\bin\Debug\Imagens/Apagar.png��5�       $( 0.289,0.542&�6�   5�      5�      5�      (   "Fluxos.Auxiliar.MensagemInformacao  5�   
   -6   5        ,  Name$, msgInformacao��5�       $	��500��5�       $	��250��5�       $��3��5�       $��2��5�       $y�Hidden=�5�          Fluxos.Auxiliar.InputBox  5�   
   -7   5        -  Name$- InputBox��5�      $	��500��5�      $	��300��5�      $��3��5�      $��2��5�      $y�Hidden=�5�         Fluxos.Auxiliar.Help  5�   
   -8   5        .  Name$. hlpHelp��5�      $��3��5�      $��2��5�      $y�Hidden=�5�      �� 5�   
   -9   5        / ��Name$/ Teste��5�      $	��500��5�      $	��250��5�      $��3��5�      $��2��5�      5�      5�      