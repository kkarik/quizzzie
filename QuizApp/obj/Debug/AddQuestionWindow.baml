   M S B A M L   `   `   `  ����  QuizApp    QuizApp.AddQuestionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Добавить вопрос��5   	   $	��400��6!   $	��450��6.   ���#ffd640 � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   ShadowDepth	 �� 
TargetType
 �� CornerRadius  TextBlockStyle��%l  &	        &	 �    �� 5   
   " ��6$   .�5	      ��  � �� �#fcad0d6+   �� 5
       � ��
 �   �6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 12,8q�6(   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       � ��$ 45��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5        5      $ 15Q�6'   $ #1C2833��67   $ 5Q�6G   5      �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� #��z��6!   $
 8��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5       �� 5$   
   " ��6'   .�5%      ��  � ��$ 18(�6)   �� 5&       � ��
 �   �6+   �� 5'       � ��$
 Bold"�6+   �� 5(       � ��$ 10q�6'   5)      5*      .��5+      � $��10q�6    � RowDefinitions 5,   
   �� 5-      $
��Auto �6   �� 5.      $��* �6   �� 5/      $
��Auto �6   .+�53   
   �� $��0��6   $��0,0,0,10q�6"   .+�54      �� $ ��Текст вопроса:��6   $
��Bold"�6.   $��0,0,0,5q�6@   #��[ 6Q   �� 55      -   5        $��QuestionTextBox��55      $��14(�6-   $��5q�6;   �� 57      $&�� Правильный ответ:��6   $
��Bold"�61   $��	10,10,0,5q�6C   #��[ 6V   �� 58      -   5        $��CorrectAnswerTextBox��58      $��14(�62   $��5q�6@   �� 5:      $N��HВарианты ответа (каждый с новой строки):��6   $
��Bold"�6H   $��	10,10,0,5q�6Z   #��[ 6m   �� 5;      -   5        $��OptionsTextBox��5;      $��14(�6,   $��5q�6:    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6[   $	��100��6~   5<      �� 5?   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5@      �� -   5        $��Добавить��5@      $	��100��6@   #��[  6L   �� 5A      -   5        $��Отмена��5A      $	��100��6A   #��[  6M   $��5,0,0,0q�6r   5B      5C      5D      