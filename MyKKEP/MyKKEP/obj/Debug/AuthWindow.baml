   M S B A M L   `   `   `  ����A  =MyKKEP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyKKEPMyKKEP  5   	       MyKKEP.AuthWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MyKKEP     5   	     � Title$  
AuthWindow��5   	   $	��450��6   $	��300��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��80 �6   6*   .+�5   
   �� $��Авторизация��6   $��25(�6'   $��Center=�65   $��Center=�6R   6o   �� 5   
   $��
Логин��6   $��20(�6!   $��1��6/   $��Center=�6<   $��5q�6Y   6f   �� 5   
   -   5         ��Name$ TxtLogin��5      $	��190��6$   $��30��60   $��1��6<      TextBoxBaseControlTemplate#��[  6I   6�   �� 5   
   $��Пароль��6   $��20(�6"   $��2��60   $��Center=�6=   $��5q�6Z   6h   G� 5   
   -   5         G�Name$ TxtPassword��5      $	��190��6+   $��30��67   $��2��6C    " PasswordBoxBaseControlTemplate#��[ 6P   6�   �� 5   
   -   5        $��BtnLogin��5   !   $��
Войти��6   $��3��6H   $	��Top=�6U   $	��100��6m   $��25(�6y     RoundedButtonStyle#��[ 6�   6�   5      5      