   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  Сhat��5   	   $	��610��6   $	��800��6#    � WindowStyle$ ThreeDBorderWindow=�6/   .��5	      � -   5         �Name$ MainRoot��5	       � ColumnDefinitions 5
   
   �� 5      $
��513* �6   �� 5      $
��287* �6   .+�5   
   �� -   5         ��Name$ 	IPTextBox��5      $
��Left=�6%   $��	58,44,0,0q�6@    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��147��6   �� 5   
   $
��Left=�6   $��	25,43,0,0q�6/   $
��Wrap=�6B   $	��IP:��6V   $	��Top=�6a    J� RenderTransformOrigin$ 0.5,0.5&�6y   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 359.848Q�6&   T� 5      5      5      �� 5   
   $
��Left=�6   $��
260,44,0,0q�6/   $
��Wrap=�6C   $��Port:��6W   $	��Top=�6d   $��29��6|   �� 5   
   -   5        $ PortTextBox��5      $
��Left=�6'   $��
294,44,0,0q�6B   $
 Wrap=�6V   $	��Top=�6j   $��88��6�   �� 5   
   $
��Left=�6   $��
453,44,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   �� 6p    � Language$ ru-ru�6t   $�Имя��6�   �� 6�   $�:��6�   6�   �� 5   
   -   5        $ NameTextBox��5      $
��Left=�6'   $��
490,44,0,0q�6B   $
 Wrap=�6V   	 �� 	MaxLength$	 35��6j   $	��Top=�6y   $	��120��6�   $��2��6�   �� 5   
   -   5        
 ��Name$
 InOutButton��5      $��
Войти��6&   $
��Left=�66   $��
169,42,0,0q�6Q   $	��Top=�6e   $��92��6}   $��1��6�   6�   �� 5   
   -   5        $ 
KeyTextBox��5      $
��Left=�6&   $��	58,10,0,0q�6A   $
 Wrap=�6T   $	��Top=�6h   $	��147��6�   �� 5   
   $
��Left=�6   $��	21,10,0,0q�6/   $
��Wrap=�6B   $��	Ключ:��6V   $	��Top=�6c   �� 5    
   -   5        $ InputTextBox��5       $
��Left=�6(   $��
23,442,0,0q�6C    �� AcceptsReturn . $		 255��6l   $
 Wrap=�6|   $	��Top=�6�   $	��623��6�   $	��120��6�   $��2��6�   �� 5!   
   -   5        $
 
SendButton��5!      $��Отправить��6%   $
��Left=�69   $��152,442,0,0q�6T   $	��Top=�6i   $	��120��6�   $	��109��6�   $��1��6�   6�   �� 5"   
   -	   5        $ MainTextBox��5"      $
��Left=�6'   " �� VerticalScrollBarVisibility$
 Auto=�6B   $��	23,81,0,0q�6e   $
 Wrap=�6x   $	��Top=�6�    . $	��751��6�   $	��325��6�   $��2��6�   �� 5#   
   $
��Left=�6   $��
23,421,0,0q�6/   $
��Wrap=�6C   $"��Ваше сообщение:��6W   $	��Top=�6n   5&      5'      