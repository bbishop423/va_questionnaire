   M S B A M L   `   `   `  ����O  KPatientResultsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PatientResultsSystem.ViewModelsPatientResultsSystem.ViewModels  5   	   ,    &PatientResultsSystem.Views.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   D
viewModels-clr-namespace:PatientResultsSystem.ViewModels     5   	     � Title$  	LoginView��5   	   $	��220��6   $	��350��6(    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � DataContext 5      4  .PatientResultsSystem.ViewModels.LoginViewModel  5	   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $
��Bold"�6!   
���  ��$��Center=�6D   ��5      ��  �� Path$ ErrorMessage�� 5   
   $��1��6   $��Center=�6!   $��Center=�6>   .+�5      ��  �� Target 6   ��  �� ElementName$ UserNameTextBox��.��6C   _User Name:6P   �� 5      -   5        $��UserNameTextBox��5      $��25��6-   $	��170��69   ��6E   �� $ UserName� �� Mode$ OneWayToSource=�5      � 5    
   $��2��6   $��Center=�6!   $��Center=�6>   .+�5!      ��  6   �� $ PasswordTextBox��.��6C   
_Password:6O   G� 5"      -   5        $��PasswordBox��5"      $��25��6.   $	��170��6:   6F   5#      � 5&   
   $��3��6   	 � ColumnDefinitions	 5'      �� 5(      �� 5)      .+�5,      �� -   5        $��CancelButton��5,      $��0��6)   $��Center=�69   $��Center=�6V   ��5-      �� $ CancelCommand�.��5.      �� 
 �� Orientation$
 
Horizontal=�6   .+�5/      �� $��8,0,4,0q�6   $��20��6-   $��Center=�69   $"��../Resources/cancel_icon.png��6T   �� 50      $��4,0,8,0q�6    $��Cancel��61   51      52      �� 53      -   5        $��LogInButton��53      $��1��6(   $��Center=�68   $��Center=�6U   ��54      �� $ LogInCommand�.��55      �� $
 
Horizontal=�6   .+�56      �� $��8,0,4,0q�6   $��20��6-   $��Center=�69   $!��../Resources/login_icon.png��6T   �� 57      $��4,0,8,0q�6    $��Login��61   58      59      5:      5;      5<      