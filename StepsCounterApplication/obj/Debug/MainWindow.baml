   M S B A M L   `   `   `  ����R  NStepsCounterApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:StepsCounterApplicationStepsCounterApplication  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   (    "StepsCounterApplication.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:StepsCounterApplication     5   	   RForms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   -   5          � Title$  Анализ шагов��5	   	   $	��419��6   $	��939��6+   .��5
      � $��5,0,5,5q�6    � ColumnDefinitions 5   
   �� 5      $	��60* �6   �� 5      $
��441* �6   �� 5      $
��428* �6   �� 5      $��0* �6   .+�5   
   �� $-��'Список пользователей��6   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   $��20(�6u   $��37��6�   $	��218��6�   $��2��6�   �� 5   
   $E��?График по выбранному пользователю��6   $
��Left=�6<   $��	39,10,0,0q�6W   $	��Top=�6j   $��20(�6�   $��37��6�   $	��364��6�   $��2��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	GridTable��5      $
��Left=�6&   $	��301��6A   $��	10,67,0,0q�6N   $	��Top=�6a   $	��506��6y   $��3��6�      
IsReadOnly .  � DataContext 5         System.Windows.Forms.Label  5      5      �� 5   
   -   5         ��Name$
 Plot��5      $
��Left=�6   $	��300��6:   $��	71,68,0,0q�6G   $	��Top=�6Z   $	��300��6r   $��2��6~   .+�5      �� $��Кол-во шагов��6   $
��Left=�6+    �� Left$	 521��6F   
 �� Top$ 41��6X   $	��Top=�6h   5      �� 5   
   -   5        $%��Сохранить данные��5      $
��Left=�6,   $��
173,19,0,0q�6G   $	��Top=�6[   $��1��6�   �� 5   
   -   5         ��Name$ 
LabelSteps��5      $��2��6$   $�� ��64   $
��Left=�6?   $��	28,67,0,0q�6Z   $	��Top=�6m   �� 5   
   -   5        $ 	LabelDays��5      $��2��6#   $�� ��63   $
��Left=�6>   $��344,342,0,0q�6Y   $	��Top=�6n   �� 5   
   $��2��6   $��Кол-во шагов��6    $
��Left=�67   $��	20,41,0,0q�6R   $	��Top=�6e   �� 5   
   $��2��6   $��День��6    $
��Left=�6/   $��376,342,0,0q�6J   $	��Top=�6_   5!      5"      