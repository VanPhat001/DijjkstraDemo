   M S B A M L   `   `   `  ����G  CShortestPath, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ShortestPath.ViewsShortestPath.Views  5   	   &     ShortestPath.Views.SettingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ShortestPath.Views     5   	     � Title$  SettingWindow��5   	   $	��450��6   $	��800��6,   .��5	      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   6,   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��2* �6   6*   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $��* �6   6+   �� 5      $	��100 �6   6-    � 	Resources 5   
    �� 
TargetType �� Property �� Value��%<  '��       '�� �     '�� I    �� 5      " ��6   .�5      ��  � ��$ Center=�66   6G   �� 5       � ��$ Center=�68   6I   �� 5       � ��$ 20(�6-   6:   �� 5       � ��
 ��  �6>   �� 5       � ��$
 Bold"�6/   6>   5       �� 5!      " ��6   .�5"      ��  � ��$ Center=�66   6G   5#      �� 5$      " ��6   .�5%      ��  � ��$ Center=�66   6G   �� 5&       � ��$ Right=�68   6H   �� 5'       � ��$ 0,0,20,0q�6,   6?   �� 5(       � ��$ 20(�6-   6:   5)      5*      .+�5-   
   �� $��1��6   Rows:6(   �� 5.   
   -   5         ��Name$ 
sliderRows��5.   .   $��1��6   $��1��6    � Minimum$ 5Q�6B   	 � Maximum$	 30Q�6N   6]   �� 5/   
   $��1��6   $��2��6   ��50      �� 51      
 �� Orientation$
 
Horizontal=�6   .+�52      �� $��40��6    �� TextAlignment$ Center=�6)   ��53      ��  �� ElementName$ 
sliderRows�� �� Path$ Value� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=�6�   �� 54      /6#   �� 55      ��6    �� $ 
sliderRows��$ Maximum�6X   56      58      �� 5;   
   $��2��6   Cols:6(   �� 5<   
   -   5        $ 
sliderCols��5<   .   $��2��6   $��1��6   $ 5Q�6B   $	 30Q�6N   6]   �� 5=   
   $��2��6   $��2��6   ��5>      �� 5?      $
 
Horizontal=�6   .+�5@      �� $��40��6   $ Center=�6)   ��5A      �� $ 
sliderCols��$ Value�$ TwoWay=�$ 	LostFocus=�6�   �� 5B      /6#   �� 5C      ��6    �� $ 
sliderCols��$ Maximum�6X   5D      5F      �� 5I   
   -   5        $��5��5I      $��3��6   $��44��62   $��28(�6>   
����  �$
��Bold"�6^   .��6�   OK6�   5J      5K      