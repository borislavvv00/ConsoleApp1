   M S B A M L   `   `   `  ����D  @ExpenseIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Expenselt	Expenselt  5          Expenselt.ExpenseItHome   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Expenselt     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  ExpenseIt - Home��5      $	��800��5	      $	��450��5
      .��5      � $��
10,0,10,10q�6   ��5   
   �� 5       �� ImageSource$ watermark.png��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $
��0.5* �6   .+�5   
   �� $��1��6   ��6   ��  �� Path$ PersonsChecked�� 5   
   -   5         �Name$ 
GridHeight��5      $��1��5      $��1��5      �� 5   
   $��1��5      $��Center=�5       $��Center=�5!      $��20(�5#      $
��Bold"�5$      ���#4E87D4��5"      ��  �� RelativeSource ��  �� AncestorType" �$ MainCaptionText�5%      �� 5&   
   $��1��6   $��1��6"   .+�5'      �� $��35��5(       �� Padding$ 5q�5)      ���#4E87D4._�5,      �� $��Center=�6   
�������.��6F   Names6M   5-      �� 5/      $
��Auto=�6   .��50      �� -   5        $��peopleListBox��51      ��52      �� 	 �� ElementName$	 
GridHeight��$ ActualHeight���53      ��  �� " �$ ExpenseDataSource���55      �� 56      .R�57      �� ��6$   �� $
 Name�58      5:      5;      5=      �� 5>   
   $��2��5?      $
��Left=�5@      $��Bottom=�5A      ��5B      �� $ LastChecked��� 5D   
   -   5        $��3��5E      $��1��5F      $	��125��5G      $��25��5H      $��0,10,0,0q�5I      $��Right=�5J      ��5L      �� $	 peopleListBox��$ SelectedItem.Name�5M      5N      