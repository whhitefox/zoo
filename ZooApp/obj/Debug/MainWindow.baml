   M S B A M L   `   `   `  ����A  =ZooApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZooAppZooApp  5   	       ZooApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ZooApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      �� 5      $
��0.5* �6   .+�5   
   �� $��1��6   $��1��6"   .+�5      �� $��Авторизация��6   $��Center=�6*   $��Bottom=�6G   $��24(�6b   $��0,0,0,10q�6p   �� 5      $��
Логин��6   �� 5      -   5         ��Name$ LoginTextBox��5      4  .System.Windows.Automation.AutomationProperties   HelpText$ 
Логин��6,   �� 5      $��Пароль��6   G� 5      -   5         G�Name$ PasswordBox��5      $ Пароль��6/   $��0,0,0,20q�6V   �� 5      -   5         ��Name$ LoginButton��5      $��
Войти��6*   $��20(�6:   6H   5      5      5      