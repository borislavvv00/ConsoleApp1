   M S B A M L   `   `   `  ����D  @ExpenseIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Expenselt	Expenselt  5          Expenselt.ExpenseReport   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Expenselt     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$"  ExpenseReport - View Expense��5      $	��800��5	      $	��450��5
      .��5      � ��5   
   �� 5       �� ImageSource$ watermark.png��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��3* �6    �� 5      $��3* �6    �� 5      $��* �6     5      �� 5      $��2* �6#   �� 5      $��* �6#   .+�5       �� $��1��6   $��Bottom=�6&   .+�5!      �� $��Expense Report For: ��5"      $��20(�5#      $
��Bold"�5$      ���#4E87D45%      �� 5&       �� Orientation$ 
Horizontal=�6   .+�5'      �� $��Name: ��6   $
��Bold"�6-   �� 5(      $
��Bold"�6:   ��6   ��  �� Path$
 Name�6:   5)      �� 5+      $ 
Horizontal=�6   .+�5,      �� $��Department: ��6   $
��Bold"�63   �� 5-      $
��Bold"�6@   ��6   �� $ 
Department�6@   5.      50      &   System.Windows.Controls.DataGrid  54      $��2��55      $��Stretch=�56      $��Stretch=�57         AutoGenerateColumns$ False��58         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 59         RowHeaderWidth$ 0Q�5;      ��5:      �� $ Expenses�	   Columns	 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ExpenseType��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� $ ExpenseType�   HeaderStyle 5>      �� 5?       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5@   "   ��  �� Property � �� �� Value �#4E87D46?   �� 5A   "    � ��
 �����6?   5B      5D        5E      $
 Amount��6P    6)   �� $ ExpenseAmount� 5F      �� 5G      "  6$   .�5H   "   ��  � �� �#4E87D46?   �� 5I   "    � ��
 �����6?   5J      5L      5N      5P      5R      5S      