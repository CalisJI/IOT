   M S B A M L   `   `   `  ����C  ?WPF_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF_TESTWPF_TEST  5   	       WPF_TEST.Login_form   5   	   a ]DevExpress.Xpf.Core.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WPF_TEST     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5         	  Login  � DataContext#  [  5
       � Title$ Login��5   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	   .��5      � .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF2281D1��6#   � 5      $ 	#FF34268A��6#    � Offset$ 1Q�65   � 5      $ 	#FF33288B��6#   $ 0.645Q�65   5      5      �� 5   
   $	��280��6   $	��240��6    $��Bottom=�6-   $
��0,80q�6H   	 �� RadiusY$	 12��6V   
 �� RadiusX$
 12��6c   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 2Q�6Y      Color$ Purple��6i   5       � 5!   
   $��Bottom=�6   $��35,80q�6*   $	��240��69   #  [  6F   .+�5"      �� $��LOGIN��6   $��Center=�6$   $	��Top=�6A   $��6q�6Y   
�������$��20(�6z   �� 5#      $��Center=�6   $��15q�64   .+�5$      �� -   5         ��Name$ tb_user��5%      $
��0,10q�5&      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 USER��5(       % !MaterialDesignFloatingHintTextBox#��[ 5)      $��Champagne &Limousines)�5*      $��18(�5+      ��5'      �� *UserID+.��5+   #   5-      G� 5.      -   5         G�Name$ pass_box��5/      $
��0,10q�50      $ PASSWORD��53       ) %MaterialDesignFloatingHintPasswordBox#��[ 54      $0��*Champagne &                     Limousines)�55      $��18(�56   !   57      58      �� 59   
   -   5        $��Loginbutton��5?      $	��150��5:      $��Center=�5;      $��Bottom=�5<      $
��0,65q�5=      $��LOGIN��5A      ��5@      �� *Login+5C      �� 5E   
   $��FORGOT PASSWORD?��6   $��Center=�6,   $��Bottom=�6I   $��30q�6d   
������� � Cursor$
 Hand��6�   �� 5F   
   -   5        $	��Top=�5G      $��Right=�5H      $��40��5I      $��40��5J        MaterialDesignIconButton#��[ 5L       � ToolTip$ Close��5M      .��5N      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�5O      $��30��6   $��30��5P      
�������6   5Q      5R      5T      