   M S B A M L   `   `   `  ����O  KPatientResultsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PatientResultsSystem.ViewModelsPatientResultsSystem.ViewModels  5      )    #PatientResultsSystem.Views.MainView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      D
viewModels-clr-namespace:PatientResultsSystem.ViewModels     5        N� Title$  View Patients��5       � DataContext 5      7  1PatientResultsSystem.ViewModels.MainViewViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��10,20,10,10q�6!   $��Center=�66   $��16(�6S   $
��Bold"�6a   
���   �Patients In System5      &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��10,10,10,20q�6    $��Center=�65      AutoGenerateColumns .     
IsReadOnly . $	��600��5      ��6   �� *
Patients+ �� SelectedItem 6@   �� *SelectedPatient+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Last Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 0.25* 68   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6F   �� *
LastName+  5      $ 
First Name��6%   $ 0.25* 69   	 6G   �� *	FirstName+  5      $ Date of Birth��6%   $ 0.25* 6<   	 6J   �� *DoB+
 �� StringFormat$
 d��  5      $ ID��6%   $ 0.25* 61   	 6?   �� *ID+5      �� 5!   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10,10,10,10q�6X   .+�5"      �� $��20,10,20,10q�6   ��6*   �� *ViewPatientInfoCommand+.��5#      �� $ 
Horizontal=�6   .+�5$      �� $��8,0,4,0q�6   $��20��6-   $��Center=�69   $ ��../Resources/user_icon.png��6T   �� 5%      $��4,0,8,0q�6    $��View Patient Info��61   5&      5'      �� 5(      $��20,10,20,10q�6   ��6*   �� *ViewReportCommand+.��5)      �� $ 
Horizontal=�6   .+�5*      �� $��8,0,4,0q�6   $��20��6-   $��Center=�69   $"��../Resources/folder_icon.png��6T   �� 5+      $��4,0,8,0q�6    $��View Report��61   5,      5-      �� 5.      $��20,10,20,10q�6   ��6*   �� *CompleteQuestionnaireCommand+.��5/      �� $ 
Horizontal=�6   .+�50      �� $��8,0,4,0q�6   $��20��6-   $��Center=�69   $"��../Resources/folder_icon.png��6T   �� 51      $��4,0,8,0q�6    $��Complete Questionnaire��61   52      53      54      55      56      