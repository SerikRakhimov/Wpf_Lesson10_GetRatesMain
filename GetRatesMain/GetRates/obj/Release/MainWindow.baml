   M S B A M L   `   `   `  ���� C  ?GetRates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GetRatesGetRates      GetRates.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:GetRates     -     � Title$  Курсы валют��$	��450��$	��800�� � 	Resources  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value&   System.Windows.Controls.DataGrid��%�   '��       '  �     �� " �� P�  �@J�IsMouseOver . . ���  � ��
 �   ���  � ��
 ���w����  � ��
 �OO/���  � ��
 �������  � ��$ Comic Sans MS)��� "  ���  � ��$ Comic Sans MS)�.��� .+�  -   $��ratesDataGrid��   
IsReadOnly . $
��Left=�$	��297��$��
189,36,0,0q�$	��Top=�$	��398��	   AutoGenerateColumns	 .  
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Множитель��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    FontSize$ 14Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Quant+  $ Валюта��$	 160 $ 14Q� �� *Title+  $ Курс к тенге��$	 110 $ 14Q� �� *Description+�� -   $��Обновить��$
��Left=�$��326,362,0,0q�$	��Top=�$	��133��$��24�� J� RenderTransformOrigin$ 0.957,0.126&�