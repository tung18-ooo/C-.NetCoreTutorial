   M S B A M L   `   `   `  ����L  HCS039_TestAdapter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CS039_TestAdapterCS039_TestAdapter  5   	   "    CS039_TestAdapter.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CS039_TestAdapter     5   	   -   5          � Title$  Test DataAdapter��5   	   $	��450��6"   $	��800��6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $
��30px �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5       $��0��6   ��62   �� 6L   �� 5   
   $��1��6   
������� �� Orientation$ 
Horizontal=�65   .+�5      �� -   5         ��Name$ btnLoad��5      $
��Load��6&   $
��20,0q�65   6F   �� 5      -   5        $ btnSave��5      $
��Save��6&   $
��20,0q�65   6\   �� 5      -   5        $ 	btnDelete��5      $��Delete��6(   $
��20,0q�69   6b   5      5      5      