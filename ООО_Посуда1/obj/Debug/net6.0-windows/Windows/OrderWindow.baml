   M S B A M L   `   `   `  ����O  KООО_Посуда1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ООО_Посуда1.WindowsООО_Посуда1.Windows  5   	   .    (ООО_Посуда1.Windows.OrderWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ООО_Посуда1.Windows     5   	     � Title$  OrderWindow��5   	   $	��450��6   $	��800��6*   $	��425��5	   	   $	��775��6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �  5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      .+�5      �� $��Пункт выдачи��6   �� 5      -   5         ��Name$ PickupPointComboBox��5      $��1��64   �� 5      $��Дата доставки��6   $��1��6,   �� 5       -   5         ��Name$ DeliveryDate��5       $��1��6*   $��1��67   �� 5"      $��Код получения��6   $��2��6,   �� 5#      -   5        $ 
PickupCode��5#      $��2��6(   $��1��65   5$      �� 5&   
   -   5         ��Name$ ProductListView��5&      $��1��6,   � 5(   
   $��2��6    5)      �� 5*      �� 5+      �� 5,      .+�5/      �� -   5         ��Name$ 
BackButton��5/      $��
Назад��6)   69   �� 50      -   5        $ 	MakeOrder��50      $)��#Сформировать заказ��6(   $��1��6E   6U   �� 51      -   5        $ 
MakeTicket��51      $)��#Сформировать талон��6)   $��2��6F   6V   52      53      54      