   M S B A M L   `   `   `  ����O  KPatientResultsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PatientResultsSystem.ViewModelsPatientResultsSystem.ViewModels  5      ,    &PatientResultsSystem.Views.AddUserView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      D
viewModels-clr-namespace:PatientResultsSystem.ViewModels     5        N� Title$  Add User��5       � DataContext 5      6  0PatientResultsSystem.ViewModels.AddUserViewModel  5   
   .��5      �� .��5   
   � $��30,10,30,10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��0��6%   $��Right=�65   $��
0,10,10,10q�6Q   $��First Name: ��6e   �� 5      $��0��6   $��1��6#   $
��Left=�63   $	��200��6N   $��
10,10,0,10q�6Z   ��5      �� *	FirstName+ �� Mode$ OneWayToSource=��� 5       $��1��6   $��0��6%   $��Right=�65   $��
0,10,10,10q�6Q   $��Last Name: ��6e   �� 5!      $��1��6   $��1��6#   $
��Left=�63   $	��200��6N   $��
10,10,0,10q�6Z   ��5"      �� *
LastName+$ OneWayToSource=��� 5$      $��2��6   $��0��6%   $��Right=�65   $��
0,10,10,10q�6Q   $��
Username: ��6e   �� 5%      $��2��6   $��1��6#   $
��Left=�63   $	��200��6N   $��
10,10,0,10q�6Z   ��5&      �� *
UserName+$ OneWayToSource=��� 5(      $��3��6   $��0��6%   $��Right=�65   $��
0,10,10,10q�6Q   $��
Password: ��6e   �� 5)      $��3��6   $��1��6#   $
��Left=�63   $	��200��6N   $��
10,10,0,10q�6Z   ��5*      �� *
Password+$ OneWayToSource=��� 5,      $��4��6   $��0��6%   $��Right=�65   $��
0,10,10,10q�6Q   $��User Type: ��6e   �� 5-      $��4��6   $��1��6$   $	��200��64   $��
10,10,0,10q�6@   $
��Left=�5.      ��5-   T   �� *	UserTypes+ �� SelectedValue 5.   2   �� *Type+�� 50      $��5��6   $��1��6&    �� Orientation$ 
Horizontal=�66   .+�51      �� $��
0,10,15,10q�6   ��6-   �� *CancelCommand+.��52      �� $ 
Horizontal=�6!   .+�53      �� $��8,0,4,0q�6    $��20��61   $��Center=�6=   $"��../Resources/cancel_icon.png��6X   �� 54      $��4,0,8,0q�6$   $��Cancel��65   55      56      �� 57      $��
15,10,0,10q�6   ��6-   �� *AddUserCommand+.��58      �� $ 
Horizontal=�6!   .+�59      �� $��8,0,4,0q�6    $��20��61   $��Center=�6=   $��../Resources/add_icon.png��6X   �� 5:      $��4,0,8,0q�6$   $��Add User��65   5;      5<      5=      5>      5?      5@      