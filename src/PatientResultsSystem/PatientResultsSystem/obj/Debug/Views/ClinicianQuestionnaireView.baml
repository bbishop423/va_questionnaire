   M S B A M L   `   `   `  ����O  KPatientResultsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PatientResultsSystem.ViewModelsPatientResultsSystem.ViewModels  5      I)clr-namespace:PatientResultsSystem.ModelsPatientResultsSystem.Models  5      ;    5PatientResultsSystem.Views.ClinicianQuestionnaireView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      D
viewModels-clr-namespace:PatientResultsSystem.ViewModels     5      <models)clr-namespace:PatientResultsSystem.Models     5        N� Title$  Clinician Questionnaire��5       � DataContext 5      <  6PatientResultsSystem.ViewModels.QuestionnaireViewModel  5	   
    � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value)  #System.Windows.Controls.DataGridRow   QuestionTemplate	 �� DataType1  +PatientResultsSystem.Models.QuestionWrapper  AnswerTemplate
 � Minimum � Maximum �� TickFrequency �� TickPlacement �� IsSnapToTickEnabled � Value �� UpdateSourceTrigger  ValueTemplate �� 
IsReadOnly��%�  '        '  A    &	  �    &	 �    &	 �    �� 5   
   "  6   .�5      ��  � �� 6+   Z� �� 5       � �� 6,   Z� �� 5       � ��
 �   �6+    5      P� 5       �@ 
IsSelected . . �5      ��  � �� 63   Z� �� 5       � �� 64   Z� �� 5       � ��
 �   �63   5      5      �� 5   
   "  6   .�5      ��  � �� 6+   Z� �� 5       � �� 6,   Z� �� 5        � ��
 �   �6+    5!      P� 5"       �@ 
IsSelected . . �5#      ��  � �� 63   Z� �� 5$       � �� 64   Z� �� 5%       � ��
 �   �63   5&      5(      �� 5+   
   "	  60   .R�5,      �� $��	5,10,0,10q�6   ��6+   �� *
Question+5-      �� 50   
   "	  6.   .R�51      �� $��	0,10,0,10q�6   $
 0Q�6(   $	 100Q�64   $ 10Q�6B   $ BottomRight=�6U    . 
������� 52   +   �� *Answer+$ PropertyChanged=�53      �� 56   
   "	  6-   .R�57      �� $��50��6   $��25��6!   $��Center=�6-   $��Center=�6J   {�.   . ��58      �� *Answer+59      5:      .��5=      �  � RowDefinitions 5>   
   �� 5?      �� 5@      $
��Auto �6   .+�5D   
   &   System.Windows.Controls.DataGrid  $��10,10,10,10q�6   $��Center=�6(      AutoGenerateColumns .     
IsReadOnly .    GridLinesVisibility$
 None=�5E   <      HeadersVisibility$
 None=�6W   ��6   �� *QuestionAnswerSet+   Columns 5F      4  .System.Windows.Controls.DataGridTemplateColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.5* 6)      CellTemplate 5H      �� 5I       �� ResourceKey$ QuestionTemplate��6)   5K        5L      $ * 6)    5M      �� 5N      $ AnswerTemplate��6)   5P        5Q      $	 .3* 6)    5R      �� 5S      $ ValueTemplate��6)   5U      5W      �� 5Z   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10,10,10,10q�6X   .+�5[      �� $��20,10,20,10q�6   ��6*   �� *CancelCommand+.��5\      �� $ 
Horizontal=�6   .+�5]      �� $��8,0,4,0q�6   $��20��6-   $��Center=�69   $"��../Resources/cancel_icon.png��6T   �� 5^      $��4,0,8,0q�6    $��Cancel��61   5_      5`      �� 5a      $��20,10,20,10q�6   ��6*   �� *FinishCommand+.��5b      �� $ 
Horizontal=�6   .+�5c      �� $��8,0,4,0q�6   $��20��6-   $��Center=�69   $ ��../Resources/save_icon.png��6T   �� 5d      $��4,0,8,0q�6    $��Submit��61   5e      5f      5g      5h      5i      