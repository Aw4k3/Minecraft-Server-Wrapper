   M S B A M L   `   `   `  ���� S  OMinecraft Server Wrapper, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Minecraft_Server_WrapperMinecraft_Server_Wrapper  .    (Minecraft_Server_Wrapper.WrapperSettings   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Minecraft_Server_Wrapper       � Title$  WrapperSettings��$	��400��$	��450��
����������	#FF101010 � WindowStyle$
 None=� � AllowsTransparency .  � 
ResizeMode$ NoResize=�$��Bahnschrift Light)�$��18(� � 	Resources  �� 
TargetType   
SkinButton �� Property �� Value �� 
TargetType	 �� 	Resources
 ��Name �� RadiusX �� RadiusY �� Triggers P� Property P� Value :� RoutedEvent	 �� To g� Duration �� 
TargetName �� TargetProperty	 W� To g� 	BeginTime	 t� To��%  &	        '�� P     '�� �     �� " ��.���  � �� �� " ��.R��� #��z��$��Center=�$��Right=��� " ��	 ���� '��       " ��.���  �@��CornerRadius$
 12.5����  �@��Padding$	 5,2q��� " ��.���  � �� �� " ��.R�� .+��� 
�������.���� $��Content���� $
 ToggleSwitch��$��60��$��30�����	#FF202020$ 15��$ 15��$��Right=��� $
 Toggle��$��22��$��22��
���  ��$ 11��$ 11��$��	400,0,0,0q� P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��:� $ Checked��.[��� .���� .���� $
 LimeX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $ 40X�$ 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $ 22X�$ 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $ 	340,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin�:� $ 	Unchecked��.[��� .���� .���� $ DarkRedX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $ 40X�$ 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $ 22X�$ 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $ 	400,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin�.��� -   .+�]� -    ]�Name$ TitleBar��$��20��$	��Top=�$��Center=�$	��450�����	#FF323280��.  .+�� $��20��$	��450��.+��� -   $��Minecraft Server��$��20��
�������$��11(��� -    ��Name$
 Exit��$��X��$��20��$��20��
�������$��11(�$��	430,0,0,0q���Z� ��Z� �� -   $ Minimize��$��-��$��20��$��20��
�������$��11(�$��
410,0,20,0q���Z� ��Z� �� $��Title Bar Color��$
��Left=�$��37��$��	10,25,0,0q�$	��Top=�$	��330��
�������$��24(��� -   $
 TitleBarColor�����	#FF323280
�������$��1��$ 5��$ 5��$��374,28,10,341q�$��30�� � Cursor$
 Hand���� -    ��Name$ ShowWarningOutput��$��Warning Output��$
��Left=�$��37��$��	10,67,0,0q�$	��Top=�$	��430��
�������$��24(� d� 	IsChecked$
 TrueY��� -   $ ShowErrorOutput��$��Error Output��$
��Left=�$��37��$��
10,109,0,0q�$	��Top=�$	��430��
�������$��24(�$
 TrueY��� $��Default Output Color��$
��Left=�$��37��$��
10,151,0,0q�$	��Top=�$	��330��
�������$��24(��� -	   $
 DefaultOutputColor��
�������
�������$��1��$ 5��$ 5��$��374,154,10,215q�$��30��$
 Hand���� -
    ��Name$ WarningOutputColorLabel��$��Warning Output Color��$
��Left=�$��37��$��
10,193,0,0q�$	��Top=�$	��330��
�������$��24(��� -   $
 WarningOutputColor��
��� ���
�������$��1��$ 5��$ 5��$��374,197,10,173q�$��30��$
 Hand���� -   $ ErrorOutputColorLabel��$��Error Output Color��$
��Left=�$��37��$��
10,235,0,0q�$	��Top=�$	��330��
�������$��24(��� -   $
 ErrorOutputColor�����	#FFFF4040
�������$��1��$ 5��$ 5��$��374,238,10,132q�$��30��$
 Hand���� -   $  ErrorOutputColorLabel_Copy��$��Player Event Output Color��$
��Left=�$��37��$��
10,277,0,0q�$	��Top=�$	��330��
�������$��24(��� -   $
 ErrorOutputColor_Copy�����	#FF84FFFF
�������$��1��$ 5��$ 5��$��374,281,10,89q�$��30��$
 Hand���� $��Foreground Opacity (%)��$
��Left=�$��37��$��
10,319,0,0q�$	��Top=�$	��330��
�������$��24(��� -    ��Name$ ForegroundOpacityValue��$
��Left=�$��25��$��374,326,0,0q�$��95��$	��Top=�$��66��$��Center=�$��Right=��� $��Background Skin��$
��Left=�$��37��$��
10,361,0,0q�$	��Top=�$	��330��
�������$��24(��� -   $ ChangeBackgroundSkin��$��No Skin��$
��Left=�$��37��$��300,361,0,0q�$	��Top=�$	��140�����	#FF0080FF$��Right=�#��[  $
 Hand�� � ToolTip$ Shift Click to clear����Z� ��Z� 