   M S B A M L   `   `   `  ����I  EWpfTeamProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfTeamProject.ViewWpfTeamProject.View  5   	   C&clr-namespace:WpfTeamProject.ViewModelWpfTeamProject.ViewModel  5   	   !    WpfTeamProject.View.JobList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfTeamProject.View     5   	   5vm&clr-namespace:WpfTeamProject.ViewModel     5   	   -   5          �Name$  currentWindow��5
   	    � Title$ JobList��5	   	   $	��400��6   $	��600��6&    � 	Resources 5      /   )WpfTeamProject.ViewModel.JobListViewModel   	viewModel��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   � $��0��6   $��0��6$   .+�5      �� $��Search:��6   $
��Left=�6&   $��	10,26,0,0q�6A   $	��Top=�6T   $
��auto��6l   $��0q�6y   �� 5      -   5         ��Name$ 	seacrhBox��5      $
��Left=�6)   $��	20,26,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��200��6�   5      �� 5    
   $��2��6   $��1��6)   .+�5!      �� $��	Job List:��6   $��5,10,0,0q�6(   $
��Left=�6:   $	��Top=�6U   $��18(�6m   $
��Bold"�6{   �� 5"      -   5         ��Name$ ListJobs��5"      $��5,10,0,0q�6)   ��6;   �� *	JobList+ �� Mode$ TwoWay=�	 �� Source#	 [  
 �� UpdateSourceTrigger$
 PropertyChanged=� �� View 5#      �� 5$      .P�5%      ��  �� Width$
 auto��6)   $��Job ID��67    �� DisplayMemberBinding 6G   �� *jobID+�� 5&      $
 auto��6)   $��	Job Title��67    6J   �� *	jobName+�� 5'      $��Employer��6)    6;   �� *
employer+�� 5(      $
 auto��6)   $��Job Description��66    6O   �� *jobDescription+�� 5)      $��Salary��6)    69   �� *	jobSalary+5*      5,      5-      � 5/   
   $��1��6   $��0��6$   $��	0,26,20,0q�61   $��Center=�6D    � DataContext# [  6a   .+�50      �� $��Search��6   $��0,0,20,0q�6&   $��75��68   ��6C   �� *SearchCommand+��6e   ��  �� ElementName$ 	seacrhBox�� �� Path$
 Text��� 51      $��ApplyJob��6   $��75��6(   ��63   �� *ApplyCommand+��6T   �� $ ListJobs��$ SelectedItem�52      � 54   
   $��1��6   $��2��6$   $��0,50,0,0q�61   $��Center=�6C   $	��Top=�6`   # [  6x   .+�55      �� $��Logout��6   $
��Left=�6&   $	��Top=�6A   $��75��6Y   $��0,0,0,30q�6d   ��56      �� *LogoutCommand+��68   �� $ currentWindow��57      58      59      