   M S B A M L   `   `   `  ����A  =ZooApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZooAppZooApp  5   	       ZooApp.WorkerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ZooApp     5   	     � Title$  WorkerWindow��5   	   $	��450��6   $	��800��6+   .��5	      � -   5         �Name$ Nazadd��5	       � RowDefinitions 5
   
   �� 5      $
��0.1* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ ZonesButton��5      $��0��6&   $��0��66   $��Зоны��6C   6R   �� 5   
   -   5        $ AnimalsButton��5      $��1��6(   $��0��68   $��Животные��6E   6X   �� 5   
   -   5        $ ProductTypesButton��5      $��2��6-   $��0��6=   $��Типы товаров��6J   6a   �� 5   
   -   5        $ ProductsButton��5      $��3��6)   $��0��69   $��Товары��6F   6W    � 5   
   -   5          �Name$ 	PageFrame��5      $��1��6#   $��4��60     � NavigationUIVisibility$ Hidden=�6D   $��0,5,0,0q�6d   �� 5   
   -   5        $ Nassad��5      $��
назад��6!   $��5��61   $��0��6A   6O   5      5      