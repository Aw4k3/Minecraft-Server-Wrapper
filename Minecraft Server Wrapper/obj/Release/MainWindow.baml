   M S B A M L   `   `   `  ���� S  OMinecraft Server Wrapper, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Minecraft_Server_WrapperMinecraft_Server_Wrapper  )    #Minecraft_Server_Wrapper.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Minecraft_Server_Wrapper       � Title$  Minecraft Server Wrapper��$	��720��$
��1280��
������� � WindowStyle$
 None=� � AllowsTransparency .  � 
ResizeMode$ NoResize=�$��Bahnschrift Light)�$��18(����	#FF101010 � 	Resources  �� 
TargetType   ScalePercentage �� 	Resources �� Property �� Value  RoundedButton	 �� 
TargetType
 ��Name �� CornerRadius �� EndPoint �� 
StartPoint � Color � Offset ��Name �� Triggers �� Value �� Binding �� ElementName �� Path �� 
TargetName :� RoutedEvent �� 
TargetName �� TargetProperty	 �� To g� Duration P� Property P� Value ��Name �� RadiusX  �� RadiusY'  !System.Windows.VisualStateManager!   VisualStateGroups%  System.Windows.VisualStateGroup"   States   System.Windows.VisualState#   
Storyboard	$ W� To% g� 	BeginTime	& t� To  VerticalScrollThumb  HorizontalScrollThumb  CustomScrollBar' ]�Name( ]� Thumb) n�Name* �Name+ � ColumnDefinitions, � RowDefinitions- ��Name. �� CanContentScroll/ �� CanHorizontallyScroll0 �� CanVerticallyScroll1 ��Name4  .System.Windows.Automation.AutomationProperties2   AutomationId3 � Cursor4 �� ScrollableHeight5 � Maximum6 � Minimum*7 �� #ComputedVerticalScrollBarVisibility8 �� ViewportHeight9 �� ViewportSize: � Value; �� Mode< �� RelativeSource= �� ScrollableWidth> �� Orientation,? �� %ComputedHorizontalScrollBarVisibility@ �� ViewportWidth��%�  &	        '�� k     &	 �     '�� �    '�� 2    '�� �    '��     &	 X    &	 �    &	 �    7  7  '�� �    7  7  �� " �� ���� '��       " ��.���  �@��CornerRadius$ 8����  �@��Padding$	 3,1q��� " �� ���� '��       " ��.���  �@��CornerRadius$
 17.5����  �@��Padding$
 12,7q��� " ��.���  � �� �� "	 ��.R��� $
 ButtonBorder��$��2q�$
 17.5�����	#F3101010���� $ 0,0.5&�$ 1,0.5&�.��� ButtonBorderGradStop1��$ White��$ 0Q�� ButtonBorderGradStop2��$ White��$ 1Q�._��� $ ButtonContent��#��z��$��Center=�$��Center=� �� $  �� �� $ 
GridWindow��$" Background.ImageBrush.Source�.a��� $ ButtonBorder�� � �� �	#F2202020:� $ 
MouseEnter��.[��� .���� .���� $ ButtonBorderGradStop1��$ Color�$ #6eb2ffX�$ 00:00:00.100D��� $ ButtonBorderGradStop2��$ Color�$ #f9abffX�$ 00:00:00.200D�:� $ 
MouseLeave��.[��� .���� .���� $ ButtonBorderGradStop1��$ Color�$ WhiteX�$ 00:00:00.100D��� $ ButtonBorderGradStop2��$ Color�$ WhiteX�$ 00:00:00.200D�P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��P�  � {� .  . ��� $ ButtonBorder�� � �� �� $ 0,0.5&�$ 1,0.5&�.��� $ 	#FF404040��$ 0Q�� $ 	#FF404040��$ 1Q��� " �� ���� '��       " ��.���  �@��CornerRadius$ 8���� " ��.���  �@�FocusVisualStyle Z� ��  � ��$	 2,3q� ���� '��       " ��.���  �@��CornerRadius$ 8���� " ��.���  � �� �� "	 ��.R�� .+��� 
�������.���� $��Content���� $ ToggleSwitch��$��60��$��30�����	#FF202020$ 15��$  15��$��Right=��� $ Toggle��$��22��$��22��
���  ��$ 11��$  11��$��	286,0,0,0q�!   CheckBoxStates��."   CheckBoxChecked��.# �� .���� $
 LimeX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $$ 40X�$% 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $$ 22X�$% 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $& 	227,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin�  CheckBoxUnChecked��.# �� .���� $ DarkRedX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $$ 40X�$% 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $$ 22X�$% 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $& 	286,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin� P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��:� $ Checked��.[��� .���� .���� $
 LimeX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $$ 40X�$% 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $$ 22X�$% 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $& 	227,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin�:� $ 	Unchecked��.[��� .���� .���� $ DarkRedX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $$ 40X�$% 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $$ 22X�$% 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $& 	286,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin��� " ��.���  � �� �� "	 ��.R��� $
 TabItemContainer��$	��152��$��30�����	#F2202020���	#FF444444$��0,0,0,1q�$ 8,8,0,0��$��-2q�._��� $ TabItemContentPresenter��$��Header��$��Center=�$��Center=� P�  �@��
IsSelected . . ��� $ TabItemContainer�� � �� �#6eb2ff�� " n�.���  � �� �� "	 n�.R��� $
 ScrollThumb��$��4��$
��Auto�����	#F2181818$ 2��$��Right=�$	��0,2q� :� $ 
MouseEnter��.[��� .���� .���� $ 00:00:00.100D�$ 	#F2404040X�$ ScrollThumb��$1 +(Border.Background).(SolidColorBrush.Color)�W� $ 00:00:00.100D�$$ 10X�$ ScrollThumb��$ (Border.Width)�:� $ 
MouseLeave��.[��� .���� .���� $ 00:00:00.100D�$ 	#F2181818X�$ ScrollThumb��$1 +(Border.Background).(SolidColorBrush.Color)�W� $ 00:00:00.100D�$$ 4X�$ ScrollThumb��$ (Border.Width)��� " n�.���  � �� �� "	 n�.R��� $
 ScrollThumb��$
��Auto��$��4�����	#F2181818$ 2��$��Bottom=�$	��2,0q� :� $ 
MouseEnter��.[��� .���� .���� $ 00:00:00.100D�$ 	#F2404040X�$ ScrollThumb��$1 +(Border.Background).(SolidColorBrush.Color)�W� $ 00:00:00.100D�$$ 10X�$ ScrollThumb��$ (Border.Height)�:� $ 
MouseLeave��.[��� .���� .���� $ 00:00:00.100D�$ 	#F2181818X�$ ScrollThumb��$1 +(Border.Background).(SolidColorBrush.Color)�W� $ 00:00:00.100D�$$ 4X�$ ScrollThumb��$ (Border.Height)��� " ��.���  � �� �� "	 ��.R�]� $' 
PART_Track��( n� $) ScrollThumb�� P�  �@��Orientation$ Vertical=�. ��� $ 
PART_Track�� � �� . �� $ ScrollThumb��8    � ���� $ 
PART_Track�� � ��$ 10���� $ 
PART_Track�� � ��$ Right=�P�  �@��Orientation$ 
Horizontal=�. ��� $ ScrollThumb��8   � ���� $ 
PART_Track�� � ��$ 10���� $ 
PART_Track�� � ��$ Bottom=��� " ��.���  � �� �� "	 ��.R�� $
* Grid��#��z��+ �� $��* ��� $
��Auto �, �� $��* ��� $
��Auto �.+��� $!- PART_ScrollContentPresenter��#. z��/ .  0 .  #��z��#��z��$��0��#��z��$��0���� $1 PART_VerticalScrollBar��$2 VerticalScrollBar��$3 Arrow��$��1��#5 z4 $6 0Q�$��0��#y�z7 #9 z8 8��  : �� *VerticalOffset+$; OneWay=�< �� *TemplatedParent+�� $1 PART_HorizontalScrollBar��$2 HorizontalScrollBar��$3 Arrow��$��0��#5 z= $6 0Q�$> 
Horizontal=�$��1��#y�z? #9 z@ 8�� : �� *HorizontalOffset+$; OneWay=�< �� *TemplatedParent+.��� -   $* 
GridWindow������ A j� Stretch$A Uniform=�.+�]� -   B ]�Name$B TitleBar��$��20��$	��Top=�$��Center=�$
��1280�����	#FF323280��.  .+�� $��20��$
��1280��.+��� -   $��Minecraft Server��$��20��
�������$��11(��� -   C ��Name$
C Exit��$��X��$��20��$��20��
�������$��11(�$��
1260,0,0,0q���Z� ��Z� �� -   $C Minimize��$��-��$��20��$��20��
�������$��11(�$��1240,0,20,0q���Z� ��Z� �� -   $C WrapperSettings��$��20��$��20��$��11(�$��1220,0,40,0q���Z� ���� D �� ImageSource$D Gear.png��$A Uniform=��� $��Server File��$
��Left=�$��35��$��	10,31,0,0q�$	��Top=�$	��136��
�������$��24(��� -   E ��Name$E ServerFilePath��$
��Left=�$��35��$��
146,31,0,0q�F �� TextWrapping$
F Wrap=�$��...\server.jar��$	��Top=�$
��1009��
����������	#F2202020��Z� �� -   $C BrowseServerFile��$��Browse��$
��Left=�$��35��$��1160,31,0,0q�$	��Top=�$	��110��
�������
�������$��20(�#��[ ��Z� �� -	   G ��Name$G ServerOutputWindow��$
��Left=�$	��567��$��	10,75,0,0q�$	��Top=�$	��625�����	#F2202020
�������H �� 
IsReadOnlyH . $��12(�$I �� HorizontalScrollBarVisibility$
I Auto=�"J �� VerticalScrollBarVisibility$
J Auto=���Z� . �/� .T�J� �� -
   $E ServeroutputWindowScale��$
��Left=�$��16��$��
595,75,0,0q�$
��100%��$	��Top=�$��40��$��Right=�#��[  $��12(����	#FF303030
����������	#FF282828�� -   $
 InfoPanelBorder��$��645,75,335,78q�$	��567��$	��300�����	#F2202020$ 8��._��� -   K ��Name$K 	InfoPanel��$
��Left=�$	��567��$	��Top=�$	��300��
�������$��0q���Z� ��Z� .@��� -   L ��Name$L PlayerTabItem��$��Players��
���������Z� .���� -   M ��Name$M PlayerListWindow��$
��Left=�$��-1,0,0,0q�$	��538��$	��Top=�$	��300�����	#F2202020
���������Z� �� -   $L ModPluginsTabItem��$��Plugins/Mods��
���������Z� .���� -   $M ModPluginWindow��$
��Left=�$��-1,0,0,0q�$	��538��$	��Top=�$	��300�����	#F2202020
���������Z� �� $��RAM Limit (MB).....��$
��Left=�$��35��$��
950,75,0,0q�$	��Top=�$	��205��
�������$��24(��� -   $E ramLimit��$
��Left=�$��35��$��1160,75,0,0q�$
��2048��$	��Top=�$	��110��N J� RenderTransformOrigin$N -0.336,0.062&�$��Right=��� -   O ��Name$O ForceOnlineMode��$ ��Force Online Mode.........��$
��Left=�$��36��$��951,116,0,0q�$	��Top=�$	��316��$��Center=�$��24(�
��������� -   $O RunServerOnStartUp��$"��AutoStart Server............��$
��Left=�$��36��$��951,157,0,0q�$	��Top=�$	��316��$��Center=�$��24(�
��������� -   $C StartStopServer��$��Start Server��$
��Left=�$��35��$��951,201,0,0q�$	��Top=�$	��316��
�������
�������#��[ �� -   $C KickAll��$��Kick All��$
��Left=�$��35��$��950,248,0,0q�$	��Top=�$	��155��
�������
�������#��[ {�.  �� -   $C BanAll��$��Ban All��$
��Left=�$��35��$��1111,248,0,0q�$	��Top=�$	��155��
�������
�������#��[ {�.  �� -   $C opAll��$��OP All��$
��Left=�$��35��$��951,295,0,0q�$	��Top=�$	��154��
�������
�������#��[ {�.  �� -   $C deopAll��$��	De-OP All��$
��Left=�$��35��$��1111,295,0,0q�$	��Top=�$	��156��
�������
�������#��[ {�.  �� -   $C ClearOutputWindow��$��Clear Output Window��$
��Left=�$��35��$��951,466,0,0q�$	��Top=�$	��316��
�������
�������#��[ �� -   $C EditServerProperties��$��Edit Server Properties��$
��Left=�$��35��$��951,513,0,0q�$	��Top=�$	��316��
�������
�������#��[ {�.  �� -   $C BackupWorld��$��Backup Server World(s)��$
��Left=�$��35��$��951,560,0,0q�$	��Top=�$	��316��
�������
�������#��[ {�.  �� -   $C ShowInExplorer��$��Open Server Location��$
��Left=�$��35��$��951,607,0,0q�$	��Top=�$	��316��
�������
�������#��[ {�.  �� -   $E 
CommandBox��$
��Left=�$��35��$��
10,654,0,0q�$
F Wrap=�$��/��$	��Top=�$
��1145��
����������	#F2202020��Z� �� -   $C SendCommand��$��Execute��$
��Left=�$��35��$��1160,654,0,0q�$	��Top=�$	��110��
�������
�������$��20(�#��[ {�.  P � ToolTip$>P 8Chain commands by using a ";" (i.e command 1;command  2)��A� -   Q A�Name$Q StatusLight�����	#FFFF8000$
��Left=�$��17��$��	4,698,0,0q�
���   �$	��Top=�$��17���� -    R ��Name$R StatusIndicator��$��Server is not running��$
��Left=�$��
21,694,0,0q�$	��Top=�
�������$��26��$��14(�$	��776���� -!   $R PublicIP��$��---.---.---.---��$
��Left=�$��802,694,0,0q�$	��Top=����	#FF0098D1$��26��$��14(�$	��111��$��Right=�$
3 Hand���� $��	CPU Usage��$
��Left=�$��918,694,0,0q�$	��Top=�
�������$��26��$��14(�� -"   S �Name$S cpuUsageBar��$
��Left=�$��11��$��997,703,0,0q�$	��Top=�$	��100���� -#   $R cpuUsageValue��$
��---%��$
��Left=�$��1096,694,0,0q�$	��Top=�
�������$��26��$��14(�$��45���� -$   $R ramUsageValue��$��RAM Usage: ----MB��$
��Left=�$��1141,694,0,0q�$	��Top=�
�������$��26��$��14(�