   M S B A M L   `   `   `  ����A  =ZooApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZooAppZooApp  5          ZooApp.ChecksPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:ZooApp     5        N� Title$  
ChecksPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.1* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
CheckCombo��5      $��0��6'   $��2��64   6H   �� 5   
   $��1��6   $��0��6"   .+�5      �� $&�� Информация о чеке��6   $��16(�60   $��Center=�6>   �� 5      -   5         ��Name$ 	DateLabel��5      $��
Дата: ��6'   $��12(�68   $��Center=�6F   �� 5      -   5        $ PayLabel��5      $��Оплатил: ��6&   $��12(�6:   $��Center=�6H   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ProductsDataGrid��5      $��1��6-   $��1��6:   �� 5   
   -   5         ��Name$ 
SaveButton��5      $��2��6%   $��2��62   $+��%Сохранить чек в файл��6F   {�.  6w   5      5      