   M S B A M L   `   `   `  ����R  NMicrosoft.Windows.Shell, Version=3.0.1.0, Culture=neutral, PublicKeyToken=nullF8clr-namespace:Microsoft;assembly=Microsoft.Windows.Shell	Microsoft  5   	   O KPatientResultsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PatientResultsSystem.ViewModelsPatientResultsSystem.ViewModels 5   	   Q-clr-namespace:PatientResultsSystem.ConvertersPatientResultsSystem.Converters 5   	   G(clr-namespace:PatientResultsSystem.ViewsPatientResultsSystem.Views 5   	   %   PatientResultsSystem.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jshell8clr-namespace:Microsoft;assembly=Microsoft.Windows.Shell     5   	   D
viewModels-clr-namespace:PatientResultsSystem.ViewModels     5   	   D
converters-clr-namespace:PatientResultsSystem.Converters     5   	   :views(clr-namespace:PatientResultsSystem.Views     5   	   -   5          � Title$  Patient Results System��5   	   $	��720��6(   $
��1280��65    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowState$ 	Maximized=�6.    � Icon$ ../Resources/favicon.ico��5
   	    � DataContext 5      9 3PatientResultsSystem.ViewModels.MainWindowViewModel  5   
    � 	Resources 5      )  #PatientResultsSystem.Views.MainView   MainView/  )PatientResultsSystem.Views.AddPatientView  AddPatientView,  &PatientResultsSystem.Views.AddUserView  AddUserView8  2PatientResultsSystem.Views.SelectQuestionnaireView  SelectQuestionnaireView9  3PatientResultsSystem.Views.PatientQuestionnaireView  PatientQuestionnaireView;  5PatientResultsSystem.Views.ClinicianQuestionnaireView  ClinicianQuestionnaireView+  %PatientResultsSystem.Views.ReportView  
ReportView<	 6PatientResultsSystem.Converters.EnumToStringsConverter  EnumToStringsC
 =PatientResultsSystem.Converters.UserTypeToVisibilityConverter  UserTypeToVisibility��%  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �       5   
   6     5   
   6     5   
   6     5   
   6(     5   
   6)     5   
   6+     5   
   6   	  5   
   6,   
  5   
   63   5      .��5!      �  � RowDefinitions 5"   
   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      �� 5&      $
��Auto �6    � ColumnDefinitions 5(   
   �� 5)      $��* �6   �� 5*      $��5* �6   .+�5.   
   o� $��0��6   $��2��6   .@�5/      m� $��_File��6   .@�50      m� $��_Exit��6    m� Command 6*   �� *ExitCommand+51      m� 52      $��_Help��6   .@�53      m� $��_About��6   54      55      �� 58   
   $��1��6   $��2��6   
���   �$��1q�6F   ._�59      ]� .+�5:      �� $
��Left=�6   $��30,10,30,10q�6/   $��70��6E   $
��Left=�6Q   $0��*../Resources/va_banner_black_and_white.gif��6l   �� 5;      $��Right=�6   $��30,10,30,10q�6/   $	��100��6D   $��Right=�6Q   $"��../Resources/va_research.gif��6m   5<      5=      �� 5A   
   $��2��6   $��0��6   
���   �$��1q�6B   ._�5B      �� .+�5D      �� $��10,10,10,20q�6   $��10,10,10,10q�60   $��Current User��6F   
���   �$��1q�6p   .��5E      �� .+�5F      �� $	��Top=�6$   $��
10,10,10,0q�69   ��6M   �� *CurrentUser.UserName+	 �� StringFormat$	 User Name: {0}���� 5G      $	��Top=�6$   $��10,10,10,10q�69   ��6N   �� *CurrentUser.Type+
 �� 	Converter#
 [ $	 User Type: {0}��5I      5J      �� 5L      $��	0,20,0,20q�6   $��Center=�6,   ��6I   �� *HomeCommand+.��5M      ��  �� Orientation$ 
Horizontal=�6!   .+�5N      �� $��8,0,4,0q�6    $��20��61   $��Center=�6=   $!��../Resources/users_icon.png��6X   �� 5O      $��4,0,8,0q�6$   $��	Main Page��65   5P      5Q      �� 5R      $��	0,20,0,20q�6   $��Center=�6,   ��6I   �� *AddPatientCommand+��5S      �� 5T      $ 
Horizontal=�6%   .+�5U      �� $��8,0,4,0q�6$   $��20��65   $��Center=�6A   $��../Resources/add_icon.png��6\   �� 5V      $��4,0,8,0q�6(   $��Add Patient��69   5W      5Y      �� 5Z      $��	0,20,0,20q�6   $��Center=�6,   y�6I   �� *CurrentUser.Type+#
 [ ��5[      �� *AddUserCommand+��5\      �� 5]      $ 
Horizontal=�6%   .+�5^      �� $��8,0,4,0q�6$   $��20��65   $��Center=�6A   $��../Resources/add_icon.png��6\   �� 5_      $��4,0,8,0q�6(   $��Add User��69   5`      5b      5c      5d       � 5g   
   -   5          �Name$ 	PageFrame��5g      $��2��6#   $��1��60     � NavigationUIVisibility$ Hidden=�6@   
���   �$��1q�6t   �� 5i   
   $��3��6   $��2��6!   5k      5l      5m      