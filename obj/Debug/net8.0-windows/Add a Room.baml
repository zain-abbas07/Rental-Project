   M S B A M L   `   `   `  ����D  @RentARoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:RentARoom	RentARoom  5   	       RentARoom.Add_a_Room   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:RentARoom     5   	     � Title$  
Add_a_Room��5   	   $	��450��6   $	��800��6)   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Room Number:��6   $��0��6'   �� 5   
   -   5         ��Name$ RoomNumberTextBox��5      $��0��6-   $��	100,0,0,0q�6:   �� 5   
   $��Description:��6   $��1��6'   �� 5   
   -   5        $ DescriptionTextBox��5      $��1��6.   $��	100,0,0,0q�6;   �� 5   
   $��Price Per Night ($):��6   $��2��6/   �� 5   
   -   5        $ PricePerNightTextBox��5      $��2��60   $��	100,0,0,0q�6=   �� 5   
   -   5        $	��Add��5      $��3��6   $
��Left=�6D   $��
100,10,0,0q�6_   �� 5"   
   -   5        $��Cancel��5"      $��3��6"   $��Right=�6J   $��
0,10,100,0q�6f   5#      5$      