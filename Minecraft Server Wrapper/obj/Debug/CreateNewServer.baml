   M S B A M L   `   `   `  ����S  OMinecraft Server Wrapper, Version=1.2.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Minecraft_Server_WrapperMinecraft_Server_Wrapper  5   	   .    (Minecraft_Server_Wrapper.CreateNewServer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Minecraft_Server_Wrapper     5   	   -   5          � Title$  CreateNewServer��5   	   $	��300��6!   $	��800��6.   
������� � WindowStyle$
 None=�6M    � AllowsTransparency .  � 
ResizeMode$ NoResize=�6z   $��Bahnschrift Light)�6�   $��18(�6�   ���	#FF101010 � 	Resources 5	       �� 
TargetType �� 	Resources �� Property �� Value   RoundedButton	 �� 
TargetType
 ��Name �� CornerRadius �� EndPoint �� 
StartPoint � Color � Offset ��Name �� Triggers �� Value �� Binding �� ElementName �� Path �� 
TargetName :� RoutedEvent �� 
TargetName �� TargetProperty	 �� To g� Duration P� Property P� Value��%n  '��       &	  �     �� 5
   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$
 17.5��65   �� 5       �@��Padding$
 12,7q�60   5      5      5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      "	 ��6&   .R�5      �� $
 ButtonBorder��6!   $��2q�67   $
 17.5��6K   #��z��6_   ��5      �� 5   "   $ 0,0.5&�66   $ 1,0.5&�6G   .��5   &   � ButtonBorderGradStop1��$ White��6R   $ 0Q�6`   � 5   &   ButtonBorderGradStop2��$ White��6R   $ 1Q�6`   5   #   ._�5      �� $ ButtonContent��6/   #��z��6F   $��Center=�6j   $��Center=�6�   5       5      �� 5       $  ��6x    6*   �� $ 
GridWindow��$" Background.ImageBrush.Source�.a�5!   "   �� $ ButtonBorder��6)    � �� �	#F22020206Y   5"      :� 5#      $ 
MouseEnter��6+   .[�5$   "   �� .��5%   &   �� .��5&   *   �� $ ButtonBorderGradStop1��69   $ Color�6g   $ #6eb2ffX�6�   $ 00:00:00.100D�6�   �� 5'   *   $ ButtonBorderGradStop2��69   $ Color�6g   $ #f9abffX�6�   $ 00:00:00.200D�6�   5(   '   5)   #   5*      :� 5+      $ 
MouseLeave��6+   .[�5,   "   �� .��5-   &   �� .��5.   *   �� $ ButtonBorderGradStop1��69   $ Color�6g   $ WhiteX�6�   $ 00:00:00.100D�6�   �� 5/   *   $ ButtonBorderGradStop2��69   $ Color�6g   $ WhiteX�6�   $ 00:00:00.200D�6�   50   '   51   #   52      P� 53       �@J�IsMouseOver . . �54   "   ��  �@�Cursor$
 Hand��6;   55      P� 56       � {� .  . �57   "   �� $ ButtonBorder��6)    � �� 58   &   �� 59   *   $ 0,0.5&�6>   $ 1,0.5&�6O   .��5:   .   � $ 	#FF404040��6;   $ 0Q�6M   � 5;   .   $ 	#FF404040��6;   $ 1Q�6M   5<   +   5>   #   5?      5A      5C      5D      5E      .��5F      � .+�5G   
   ]� -   5         ]�Name$ TitleBar��5G      $��20��6&   $	��Top=�62   $��Center=�6J   $	��800��6g   ���	#FF323280��.  .+�5H      � $��20��6   $	��800��6   .+�5I      �� -   5        $��Minecraft Server��5I      $��20��63   
�������$��11(�6R   6`   �� 5J      -   5         ��Name$
 Exit��5J      $��X��6'   $��20��63   $��20��6?   
�������$��11(�6�   $��	780,0,0,0q�6�   ��6J   Z� ��6`   Z� 6�   �� 5K      -   5        $ Minimize��5K      $��-��6+   $��20��67   $��20��6C   
�������$��11(�6�   $��
760,0,20,0q�6�   ��6N   Z� ��6d   Z� 6�   5L      5M      �� 5O   
   $��Install Folder��6   $
��Left=�6)   $��35��6D   $��	10,31,0,0q�6P   $	��Top=�6c   $	��156��6{   
�������$��24(�6�   �� 5P   
   -   5          ��Name$  	ServerDir��5P      $
��Left=�6%   $��35��6@   $��
166,31,0,0q�6L   $��...\Minecraft Server��6`   $	��Top=�6|   $	��509��6�   
����������	#F2202020"! �� VerticalScrollBarVisibility$! Disabled=�6  ��6�   Z� 6  �� 5Q   
   -   5        $ BrowseServerFile��5Q      $��Browse��6+   $
��Left=�6<   $��35��6W   $��
680,31,0,0q�6c   $	��Top=�6w   $	��110��6�   
�������
�������$��20(�6�   #��[  6�   ��6�   Z� 6  �� 5S   
   $��Server Type��6   $
��Left=�6&   $��35��6A   $��	10,80,0,0q�6M   $	��Top=�6`   $	��156��6x   
�������$��24(�6�   �� 5T   
   -   5        " ��Name$" SelectServerType��5T      $
��Left=�6-   $��35��6H   $��
166,80,0,0q�6T   $	��Top=�6h   $	��230��6�   $��Right=�6�   $��Center=�6�   .@�5U      �� $��Vanilla��6   �� 5V      $��Forge��6   # �� 
IsSelected# . 6+   �� 5W      $��Bukkit��6   �� 5X      $��CraftBukkit��6   �� 5Y      $��Spigot��6   5Z      �� 5[   
   -	   5        $ ��Name$$ ServerTypeInfo��5[      $
��Left=�6(   $��25��6C   $��
404,85,0,0q�6O   $	��Top=�6c   $��25��6{   $��Info Synbol.png��6�   % J� Opacity$% 0Q�6�   �� 5\   
   $��Version��6   $
��Left=�6"   $��35��6=   $��
10,120,0,0q�6I   $	��Top=�6]   $	��156��6u   
�������$��24(�6�   �� 5]   
   -
   5        $" SelectServerVersion��5]      $
��Left=�60   $��35��6K   $��166,120,0,0q�6W   $	��Top=�6l   $	��230��6�   $��Right=�6�   $��Center=�6�   .@�5^      �� $��1.15.2��6   # . 6,   �� 5_      $��1.15.1��6   �� 5`      $
��1.15��6   �� 5a      $��1.14.4��6   �� 5b      $��1.14.3��6   �� 5c      $��1.14.2��6   �� 5d      $��1.14.1��6   �� 5e      $
��1.14��6   �� 5f      $��1.13.2��6   �� 5g      $��1.13.1��6   �� 5h      $
��1.13��6   �� 5i      $��1.12.2��6   �� 5j      $��1.12.1��6   �� 5k      $
��1.12��6   �� 5l      $��1.11.2��6   �� 5m      $��1.11.1��6   �� 5n      $
��1.11��6   �� 5o      $��1.10.2��6   �� 5p      $��1.10.1��6   �� 5q      $
��1.10��6   �� 5r      $��1.9.4��6   �� 5s      $��1.9.3��6   �� 5t      $��1.9.2��6   �� 5u      $��1.9.1��6   �� 5v      $	��1.9��6   �� 5w      $��1.8.9��6   �� 5x      $��1.8.8��6   �� 5y      $��1.8.7��6   �� 5z      $��1.8.6��6   �� 5{      $��1.8.5��6   �� 5|      $��1.8.4��6   �� 5}      $��1.8.3��6   �� 5~      $��1.8.2��6   �� 5      $��1.8.1��6   �� 5�      $	��1.8��6   �� 5�      $��1.7.10��6   �� 5�      $��1.7.9��6   �� 5�      $��1.7.8��6   �� 5�      $��1.7.7��6   �� 5�      $��1.7.6��6   �� 5�      $��1.7.5��6   �� 5�      $��1.7.4��6   �� 5�      $��1.7.3��6   �� 5�      $��1.7.2��6   �� 5�      $��1.7.1��6   �� 5�      $	��1.7��6   �� 5�      $��1.6.4��6   �� 5�      $��1.6.3��6   �� 5�      $��1.6.2��6   �� 5�      $��1.6.1��6   �� 5�      $	��1.6��6   �� 5�      $��1.5.2��6   �� 5�      $��1.5.1��6   �� 5�      $	��1.5��6   �� 5�      $��1.4.7��6   �� 5�      $��1.4.6��6   �� 5�      $��1.4.5��6   �� 5�      $��1.4.4��6   �� 5�      $��1.4.2��6   �� 5�      $��1.4.1��6   �� 5�      $��1.4.0��6   �� 5�      $��1.3.2��6   �� 5�      $��1.3.1��6   �� 5�      $��1.2.5��6   �� 5�      $��1.2.4��6   �� 5�      $��1.2.3��6   �� 5�      $��1.2.2��6   �� 5�      $��1.2.1��6   5�      �� 5�   
   -   5        $ DownloadInstall��5�      $��Download and Install��6*   $
��Left=�6I   $��35��6d   $��
10,255,0,0q�6p   $	��Top=�6�   $	��780��6�   
�������
�������$��20(�6�   #��[  6�   {�.  ��6�   Z� 69  5�      5�      