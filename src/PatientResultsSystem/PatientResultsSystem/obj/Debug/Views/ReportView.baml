   M S B A M L   `   `   `  ����O  KPatientResultsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PatientResultsSystem.ViewModelsPatientResultsSystem.ViewModels  5      l hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5      +    %PatientResultsSystem.Views.ReportView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      D
viewModels-clr-namespace:PatientResultsSystem.ViewModels     5      �charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5        N� Title$  Patient Report��5       � DataContext 5      5  /PatientResultsSystem.ViewModels.ReportViewModel  5   
   .��5      �� .��5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      .+�5      �� $��0��6   $��0��6%   $��120,10,0,10q�65   $��14(�6J   $
��Bold"�6X   $��	Underline{�5      Patient Info5      �� 5"      $��0��6   $��1��6%   $��	0,10,0,10q�65   $��Center=�6H   $��14(�6e   $
��Bold"�6s   $��	Underline{�5#      Average Values5%      �� 5(      $��1��6   $��0��6&   $��120,10,10,10q�66   .+�5)      �� $��0,0,0,10q�6   �� 5*      $�Name: ��6    �� 5+      �6   �� *ThisPatient.LastName+ �� 5,      $�, ��6    �� 5-      �6   �� *ThisPatient.FirstName+5.      �� 5/      $��0,0,0,10q�6   �� 50      $
�ID: ��6    �� 51      �6   �� *ThisPatient.ID+52      �� 53      $��0,0,0,10q�6   �� 54      $�Test Date: ��6    �� 55      �6   �� *ThisPatient.TestDate+ �� StringFormat$ 
dd-MM-yyyy��56      57      &   System.Windows.Controls.DataGrid  5:      $��1��6   $��1��6$   $��10,10,10,10q�64      
IsReadOnly .    AutoGenerateColumns .  ��6[   �� *	AvgValues+   Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ Total��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 68   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6B   �� *
AvgTotal+  5>      $ Basic��6)   $	 * 68   
 6B   �� *
AvgBasic+  5?      $ Advanced��6)   $	 * 6;   
 6E   �� *AvgAdvanced+  5@      $ Adjust��6)   $	 * 69   
 6C   �� *	AvgAdjust+  5A      $ Aided��6)   $	 * 68   
 6B   �� *
AvgAided+5C      �� 5F      $��2��6   $��0��6&   $��120,10,10,10q�66   .+�5G      �� $��	0,10,0,10q�6   $��14(�6/   $
��Bold"�6=   $��	Underline{�6O   Hearing Aid Summary5I      �� 5J      $��0,0,0,10q�6   ��6.   �� *HearingAidSummary+5K      >  8System.Windows.Controls.DataVisualization.Charting.Chart  5N      $��2��6   $��1��6*   $��10,10,10,10q�6:   $	��400��6O      Title$ Patient Averages��6\      Series. 5O      E  ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  H	  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries 	  IndependentValuePath$	 Key��6M    	  DependentValuePath$ Value��6h    	  ItemsSource 6(   �� *AverageChart+6h   5P        5S      $��3��6   $��0��6*   $��2��6:   $��10,10,10,10q�6N   $	��300��6c   $ Basic��6p   . 5T      B
  <System.Windows.Controls.DataVisualization.Charting.BarSeries
  $	 Key��6H   $ Value��5U   %    5T   %   �� *
BasicChart+5U   %   5V        5Y      $��4��6   $��0��6*   $��2��6:   $��10,10,10,10q�6N   $	��300��6c   $ Advanced��6p   . 5Z      
  $	 Key��6K   $ Value��5[   %    5Z   %   �� *AdvancedChart+5[   %   5\        5_      $��5��6   $��0��6*   $��2��6:   $��10,10,10,10q�6N   $	��300��6c   $ Adjust��6p   . 5`      
  $	 Key��6I   $ Value��5a   %    5`   %   �� *AdjustChart+5a   %   5b        5e      $��6��6   $��0��6*   $��2��6:   $��10,10,10,10q�6N   $	��300��6c   $ Aided��6p   . 5f      
  $	 Key��6H   $ Value��5g   %    5f   %   �� *
AidedChart+5g   %   5h      5i      5j      5k      