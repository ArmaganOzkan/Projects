   M S B A M L   `   `   `  ����E  ASnake Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Snake_Game
Snake_Game  5   	       Snake_Game.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Snake_Game     5   	   -   5          � Title$  
Snake Game��5   	   $	��500��6   $	��800��6)      BackgroundColor#��[  65     	TextColor#��[ 6c     MainFont#��[ 6�    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ Assets/icon.ico��6.   .��5      (� .��5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $��* �6    6-   .+�5      �� -   5         ��Name$ 	ScoreText��5      $��Center=�6+   $��Center=�6H   $��Score: 0��6c   $��22(�6s   $��10q�6�   6�   �� 5      -   5         ��Name$ 
GridBorder��5      $��1��6)     GridLineColor#��[ 66   $	��1.5q�6c   $��Center=�6y   $��Center=�6�    �� EdgeMode$ Aliased=�6�   $��20,20,20,20q�6�   ._�5      A� -   5         A�Name$ GameGrid��5      $	��400��60   $	��400��6<     GridBackgroundColor#��[ 6I    J� SnapsToDevicePixels . 	 �� BitmapScalingMode$	 HighQuality=�6�   6�   5      �� 5      -   5        $ Overlay��5      $��1��6&     OverlayColor#��[ 63   $ Aliased=�5      ��5      �� 
 �� Path$
 ActualWidth� �� ElementName$ 
GridBorder����5      �� $
 ActualHeight�$ 
GridBorder����5      �� $
 Margin�$ 
GridBorder��._�5      �� -   5        $ OverlayText��5      $��Press Any Key To Start��61   $��26(�6O   $��Center=�6]   $��Center=�6z   $
��Wrap=�6�   6�   5      5       5!      5"      