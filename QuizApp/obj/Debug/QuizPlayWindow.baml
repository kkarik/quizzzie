   M S B A M L   `   `   `  ����  QuizApp    QuizApp.QuizPlayWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )Прохождение викторины��5   	   $	��400��6'   $	��600��64   ���#ffd640 � 	Resources 5         AnswerRadioButtonStyle �� 
TargetType �� Property �� Value  ButtonStyle3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   ShadowDepth �� 
TargetType	 �� CornerRadius  TextBlockStyle��%�  &	        &	 T    &	 �    �� 5   
   " 	�6/   .�5      ��  � ��
 �   �6+   �� 5	       � ��$ 16(�6)   �� 5
       � ��$
 12,8q�6(   �� 5       � ��$
 10,5q�6'   �� 5       � ��$ 40��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6$   .�5      ��  � �� �#fcad0d6+   �� 5       � ��
 �   �6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 12,8q�6(   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       � ��$ 45��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5        5      $ 15Q�6'   $ #1C2833��67   $ 5Q�6G   5       �� 5!       � ��$ 10q�6'   �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%      �� #��z��6!   $	 8��6K   ._�5&      �� $��Center=�6/   $��Center=�6L   5'      5(      5*      5+      �� 5.   
   " ��6'   .�5/      ��  � ��$ 18(�6)   �� 50       � ��
 �   �6+   �� 51       � ��$
 Bold"�6+   �� 52       � ��$ 10q�6'   53      54      .��55      � $��10q�6   .+�56   
   �� .+�58      �� -   5        
 ��Name$
 QuestionText��58      #��[ 6.   $��16(�6V   $
��Wrap=�6d   $��0,0,0,20q�6x   �� 5;      -   5        $
 	TimerText��5;      #��[ 6+   $��14(�6S   
���  ��$��Right=�6r   $��0,0,0,10q�6�   �� 5>      -   5         ��Name$ AnswerOptions��5>      ��5?      �� 5@      .R�5A      	� -   5         	� 	GroupName$ Answers��5A   :   #��[  6g   ��6&   �� 6g   5B      5D      �� 5G      -   5         ��Name$ 
NextButton��5G      $%��Следующий вопрос��6)   {�.  $��0,20,0,0q�6o   #��[ 6�   5H      5I      5J      