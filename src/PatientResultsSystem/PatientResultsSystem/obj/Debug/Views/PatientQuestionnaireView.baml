   M S B A M L   `   `   `  ����O  KPatientResultsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PatientResultsSystem.ViewModelsPatientResultsSystem.ViewModels  5      9    3PatientResultsSystem.Views.PatientQuestionnaireView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      D
viewModels-clr-namespace:PatientResultsSystem.ViewModels     5        N� Title$  Patient Questionnaire��5       � DataContext 5      <  6PatientResultsSystem.ViewModels.QuestionnaireViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   $��20,10,10,10q�6.   $��5,0,5,0q�6C   $��Center=�6U   ��6p   �� *PreviousCommand+.��6�   Previous Question5      � 5   
   $��0��6   $��1��6   $��Center=�6,   $��Center=�6I    5      �� 5      �� 5      �� 5      $
��Auto �6#   .+�5"      �� $��0��6   $��10,10,10,10q�6(   $	��500��6=   $
��Wrap=�6I   ��6]   �� *CurrentQuestion.Question+�� 5$      $��1��6   $��10,10,10,10q�6%   $	��200��6:    � Minimum$ 0Q�6F    � Maximum$	 100Q�6R    �� IsSnapToTickEnabled .  �� TickPlacement$ BottomRight=�6{    �� TickFrequency$ 10Q�5%      
�������	 � Value	 6;   �� *CurrentQuestion.Answer+�� 5'      $��2��6   $��50��6&   $��25��61   $��Center=�6=   $��Center=�6Z   {�.  
 �� 
IsReadOnly
 . ��5(      �� *CurrentQuestion.Answer+5)      �� 5+   
   $��0��6   $��2��6   $��10,10,20,10q�6.   $��5,0,5,0q�6C   $��Center=�6U   ��6p   �� *NextCommand+.��6�   Next Question5-      �� 5/   
   $��1��6   $��0��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�50      �� $��10,10,30,20q�6   $��5,0,5,0q�6*   $
��Left=�6<   ��51      �� *ExitCommand+.��61   Exit Questionnaire53      �� 54      $��30,10,10,20q�6   $��5,0,5,0q�6*   $��Right=�6<   ��55      �� *FinishCommand+.��63   Submit Questionnaire57      58      59      5:      