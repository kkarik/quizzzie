   M S B A M L   `   `   `  ����  QuizApp    QuizApp.EditOptionsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$1  +Редактировать варианты��5   	   $	��300��6(   $	��400��65    � WindowStartupLocation$ CenterScreen=�5   	   ���#ffd640 � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   ShadowDepth	 �� 
TargetType
 �� CornerRadius��%�  &	        �� 5   
   " ��6$   .�5      ��  � �� �#fcad0d6+   �� 5	       � ��
 �   �6+   �� 5
       � ��$ 16(�6)   �� 5       � ��$
 12,8q�6(   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       � ��$ 45��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5        5      $ 15Q�6'   $ #1C2833��67   $ 5Q�6G   5      �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� #��z��6!   $
 8��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5       .��5!      � $��10q�6    � RowDefinitions 5"   
   �� 5#      $��* �6   �� 5$      $
��Auto �6   .+�5'   
   &   System.Windows.Controls.DataGrid  -   5        $��OptionsDataGrid��5'      $��0,0,0,10q�6*      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .  ���#cccccc$��1q�5(   )   
�������$��5q�5)      $��14(�6      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$' !Название варианта��6%      
IsReadOnly .     Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Name+6l   5-      �� 51   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�52      �� -   5        $��Добавить��52      $	��100��6@   #��[  6L   �� 53      -   5        $��Удалить��53      $	��100��6B   $��5,0,0,0q�6N   #��[  6_   �� 54      -   5        $��Сохранить��54      $	��100��6B   $��5,0,0,0q�6N   #��[  6_   55      56      57      