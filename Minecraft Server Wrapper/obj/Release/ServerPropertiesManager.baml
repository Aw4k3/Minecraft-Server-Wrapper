   M S B A M L   `   `   `  ���� S  OMinecraft Server Wrapper, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Minecraft_Server_WrapperMinecraft_Server_Wrapper  6    0Minecraft_Server_Wrapper.ServerPropertiesManager   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Minecraft_Server_Wrapper       � Title$  ServerPropertiesManager��$	��800��$
��1200��
����������	#FF101010 � WindowStyle$
 None=� � AllowsTransparency .  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$��Bahnschrift Light)�$��18(� � 	Resources  �� 
TargetType   RoundedButton �� Property �� Value	 �� 
TargetType
 ��Name �� CornerRadius �� EndPoint �� 
StartPoint � Color � Offset ��Name �� Triggers :� RoutedEvent �� 
TargetName �� TargetProperty	 �� To g� Duration P� Property P� Value �� 
TargetName �� 	Resources  	SearchBox � Cursor ��Name J� Opacity	 W� To ��Name  �� RadiusX! �� RadiusY" ��Name# g� 	BeginTime	$ t� To% �� Padding& �� Text' � Points��%p  &	        '�� ~    &	 �    '��  	    '�� �    �� " ��.���  � �� �� "	 ��.R��� $
 ButtonBorder��$��2q�$
 17.5������ $ 0,0.5&�$ 1,0.5&�.��� ButtonBorderGradStop1��$ White��$ 0Q�� ButtonBorderGradStop2��$ White��$ 1Q�._��� $ ButtonContent��#��z��$��Center=�$��Center=� :� $ 
MouseEnter��.[��� .���� .���� $ ButtonBorderGradStop1��$ Color�$ #6eb2ffX�$ 00:00:00.100D��� $ ButtonBorderGradStop2��$ Color�$ #f9abffX�$ 00:00:00.200D�:� $ 
MouseLeave��.[��� .���� .���� $ ButtonBorderGradStop1��$ Color�$ WhiteX�$ 00:00:00.100D��� $ ButtonBorderGradStop2��$ Color�$ WhiteX�$ 00:00:00.200D�P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��P�  � {� .  . ��� $ ButtonBorder�� � �� �� $ 0,0.5&�$ 1,0.5&�.��� $ 	#FF404040��$ 0Q�� $ 	#FF404040��$ 1Q��� " �� ���� '��       " ��.���  �@��CornerRadius$
 17.5����  �@��Padding$
 12,7q��� " ��.���  � �� �	#FFBFBFBF��  � �� �� "	 ��.R��� $
 SearchBorder��$��0,0,0,1q�$ IBeam������ $ 0,0.5&�$ 1,0.5&�.��� SearchBorderGradStop1��$ 	#FFBFBFBF��$ 0Q�� SearchBorderGradStop2��$ 	#FFBFBFBF��$	 0.5Q�� SearchBorderGradStop3��$ 	#FFBFBFBF��$ 1Q�._�� .+��� $ 
SearchIcon��$��23��$��23��$��SearchIcon.png��$
��Left=�$
 0.75Q��� #��z��$��Bottom=�$��	25,0,13,0q� :� $ GotKeyboardFocus��.[��� .���� .���� $ 00:00:00.200D�$ 	#FF00E8FFX�$ SearchBorderGradStop1��$ Color��� $ 00:00:00.200D�$ 	#FF00AEFFX�$ SearchBorderGradStop2��$ Color��� $ 00:00:00.200D�$ 	#FF00E8FFX�$ SearchBorderGradStop3��$ Color��� $ 00:00:00.200D�$ WhiteX�$* $(Foreground).(SolidColorBrush.Color)�W� $ 00:00:00.200D�$ 1X�$ 
SearchIcon��$ Opacity�:� $ LostKeyboardFocus��.[��� .���� .���� $ 00:00:00.200D�$ 	#FFBFBFBFX�$ SearchBorderGradStop1��$ Color��� $ 00:00:00.200D�$ 	#FFBFBFBFX�$ SearchBorderGradStop2��$ Color��� $ 00:00:00.200D�$ 	#FFBFBFBFX�$ SearchBorderGradStop3��$ Color��� $ 00:00:00.200D�$ 	#FFBFBFBFX�$* $(Foreground).(SolidColorBrush.Color)�W� $ 00:00:00.200D�$
 0.75X�$ 
SearchIcon��$ Opacity��� " ��.���  � �� �� "	 ��.R�� .+��� 
�������.���� $��Content���� $ ToggleSwitch��$��60��$��30�����	#FF202020$  15��$! 15��$��Right=��� $ Toggle��$��22��$��22��
���  ��$  11��$! 11��$��	356,0,0,0q� P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand��:� $ Checked��.[��� .���� $" CheckBoxChecking��.���� $
 LimeX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $ 40X�$# 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $ 22X�$# 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $$ 	296,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin�:� $ 	Unchecked��.[��� .���� $" CheckBoxUnChecking��.���� $ DarkRedX�$ 00:00:00.200D�$ Toggle��$. ((Rectangle.Fill).(SolidColorBrush.Color)�W� $ 40X�$# 00:00:00.000X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�W� $ 22X�$# 00:00:00.100X�$ 00:00:00.100D�$ Toggle��$ (Rectangle.Width)�t� $$ 	356,0,0,0X�$ 00:00:00.200D�$ Toggle��$ Margin��� " ��.���  � �� �� "	 ��.R�� .+��� 
�������
�������$��1q�$ 18��$% 7q�._��� #��z& � '' �   @���� �\���O��#��� 
�������.��� .+�]� -   ( ]�Name$( TitleBar��$��20��$	��Top=�$
��1200�����	#FF323280��.  .+�� $��20��$
��1200��.+��� -   $��Server Properties Editor��$��20��
�������$��11(�$	��5,4q��� -   ) ��Name$
) Exit��$��X��$��20��$��20��
�������$��11(�$��
1180,0,0,0q���Z� ��Z� �� -   $) Minimize��$��-��$��20��$��20��
�������$��11(�$��1160,0,20,0q���Z� ��Z� �� -   * ��Name$* SettingSearch��$��Search Settings��$
��Left=�$��30��$��	10,24,0,0q�$	��Top=�$
��1183��$
��Left=�#��[ $��22(��� $��1��$	��740��
�������$��400,57,799,3q��� $��1��$	��740��
�������$��800,57,399,3q��� $��Spawn Protection��$
��Left=�$��36��$��7,60,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* SpawnProtectionValue��$
��Left=�$��36��$��
283,60,0,0q�$	��Top=�$	��110��$��Right=��� $��Max Tick Time��$
��Left=�$��36��$��	7,101,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* MaxTickTimeValue��$
��Left=�$��36��$��283,101,0,0q�$	��Top=�$	��110��$��Right=��� $��
Query Port��$
��Left=�$��36��$��	7,142,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* QueryPortValue��$
��Left=�$��36��$��283,142,0,0q�$	��Top=�$	��110��$��Right=��� $��Generator Settings��$
��Left=�$��36��$��	7,183,0,0q�$	��Top=�$	��265��
�������$��24(��� -	   $* GeneratingSettingsValue��$
��Left=�$��36��$��283,183,0,0q�$	��Top=�$	��110��$��Right=��� -
   + ��Name$+ ForceGamemodeValue��$��Force Gamemode��$
��Left=�$��36��$��	7,224,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -   $+ AllowNetherValue��$��Allow Nether��$
��Left=�$��36��$��	7,265,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -   $+ EnforceWhitelistValue��$��Enforce Whitelist��$
��Left=�$��36��$��	7,306,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��Gamemode��$
��Left=�$��36��$��	7,347,0,0q�$	��Top=�$	��265��
�������$��24(��� -   , ��Name$, GamemodeValue��$
��Left=�$��36��$��283,347,0,0q�$	��Top=�$	��110��.@��� $��Survival��- �� 
IsSelected- . �� $��Creative���� $��	Adventure���� $��	Spectator���� -   $ + BroadcastConsoleToOpsValue��$��Broadcast console to OPs��$
��Left=�$��36��$��	7,388,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -   $+ EnableQueryValue��$��Enable Query��$
��Left=�$��36��$��	7,429,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��Player Idle Timout��$
��Left=�$��36��$��	7,470,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* PlayerIdleTimoutValue��$
��Left=�$��36��$��283,470,0,0q�$	��Top=�$	��110��$��Right=��� $��
Difficulty��$
��Left=�$��36��$��	7,511,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $, DifficultyValue��$
��Left=�$��36��$��283,511,0,0q�$	��Top=�$	��110��.@��� $��Peaceful���� $
��Easy���� $��Normal��- . �� $
��Hard���� -   $+ SpawnMonstersValue��$��Spawn Monsters��$
��Left=�$��36��$��	7,552,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -   $+ BroadcastRconToOpsValue��$��Broadcast R-Con to OPs��$
��Left=�$��36��$��	7,593,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��OP Permission Level��$
��Left=�$��36��$��	7,634,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $, OpPermissionLevelValue��$
��Left=�$��36��$��283,634,0,0q�$	��Top=�$	��110��.@��� $��1���� $��2���� $��3���� $��4��- . �� -   $+ PvpValue��$	��PVP��$
��Left=�$��36��$��	7,675,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -   $+ SnooperEnabledValue��$��Snooper Enabled��$
��Left=�$��36��$��	7,716,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��
Level Type��$
��Left=�$��36��$��	7,757,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $, LevelTypeValue��$
��Left=�$��36��$��283,757,0,0q�$	��Top=�$	��110��.@��� $��Default���� $
��Flat���� $��Large Biomes��- . �� $��	Amplified���� $��Buffet���� -   $+ HardcoreValue��$��Hardcore��$
��Left=�$��36��$��
407,60,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -   $+ EnableCommandBlockValue��$��Enable Command Block��$
��Left=�$��36��$��407,101,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��Max Players��$
��Left=�$��36��$��407,142,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* MaxPlayersValue��$
��Left=�$��36��$��683,142,0,0q�$	��Top=�$	��110��$��Right=��� $#��Network Compression Threshold��$
��Left=�$��36��$��407,183,0,0q�$	��Top=�$	��265��
�������$��17(�$��Bottom=��� -   $&*  NetworkCompressionThresholdValue��$
��Left=�$��36��$��683,183,0,0q�$	��Top=�$	��110��$��Right=��� $��Resource Pack Sha1��$
��Left=�$��36��$��407,224,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* ResourcePackSha1Value��$
��Left=�$��36��$��683,224,0,0q�$	��Top=�$	��110��$��Right=��� $��Max World Size��$
��Left=�$��36��$��407,265,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* MaxWorldSizeValue��$
��Left=�$��36��$��683,265,0,0q�$	��Top=�$	��110��$��Right=��� $��Function Permission Level��$
��Left=�$��36��$��407,306,0,0q�$	��Top=�$	��265��
�������$��20(�$��Bottom=��� -   $", FunctionPermissionLevelValue��$
��Left=�$��36��$��683,306,0,0q�$	��Top=�$	��110��.@��� $��1���� $��2���� $��3���� $��4��- . �� $��
R-Con Port��$
��Left=�$��36��$��407,347,0,0q�$	��Top=�$	��265��
�������$��24(��� -   $* RConPortValue��$
��Left=�$��36��$��683,347,0,0q�$	��Top=�$	��110��$��Right=��� $��Server Port��$
��Left=�$��36��$��407,388,0,0q�$	��Top=�$	��265��
�������$��24(��� -    $* ServerPortValue��$
��Left=�$��36��$��683,388,0,0q�$	��Top=�$	��110��$��Right=��� -!   $+ 
DebugValue��$��Debug��$
��Left=�$��36��$��407,429,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��	Server IP��$
��Left=�$��36��$��407,470,0,0q�$	��Top=�$	��265��
�������$��24(��� -"   $* ServerIpValue��$
��Left=�$��36��$��683,470,0,0q�$	��Top=�$	��110��$��Right=��� -#   $+ SpawnNPCsValue��$��
Spawn NPCs��$
��Left=�$��36��$��407,511,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -$   $+ AllowFlightValue��$��Allow Flight��$
��Left=�$��36��$��407,552,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��
Level Name��$
��Left=�$��36��$��407,593,0,0q�$	��Top=�$	��265��
�������$��24(��� -%   $* LevelNameValue��$
��Left=�$��36��$��683,593,0,0q�$	��Top=�$	��110��$��Right=��� $��View Distance��$
��Left=�$��36��$��407,634,0,0q�$	��Top=�$	��265��
�������$��24(��� -&   $* ViewDistanceValue��$
��Left=�$��36��$��683,634,0,0q�$	��Top=�$	��110��$��Right=��� $��Resource Pack��$
��Left=�$��36��$��407,675,0,0q�$	��Top=�$	��265��
�������$��24(��� -'   $* ResourcePackValue��$
��Left=�$��36��$��683,675,0,0q�$	��Top=�$	��110��$��Right=��� -(   $+ SpawnAnimalsValue��$��Spawn Animals��$
��Left=�$��36��$��407,716,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -)   $+ WhitelistValue��$��	Whitelist��$
��Left=�$��36��$��407,757,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��R-Con Password��$
��Left=�$��36��$��
807,60,0,0q�$	��Top=�$	��265��
�������$��24(��� -*   $* RConPasswordValue��$
��Left=�$��36��$��1083,60,0,0q�$	��Top=�$	��110��$��Right=��� -+   $+ GenerateStructuresValue��$��Generate Structures��$
��Left=�$��36��$��807,101,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��Max Build Height��$
��Left=�$��36��$��807,142,0,0q�$	��Top=�$	��265��
�������$��24(��� -,   $* MaxBuildHeightvalue��$
��Left=�$��36��$��1083,142,0,0q�$	��Top=�$	��110��$��Right=��� --   $+ OnlineModeValue��$��Online Mode��$
��Left=�$��36��$��807,183,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��
Level Seed��$
��Left=�$��36��$��807,224,0,0q�$	��Top=�$	��265��
�������$��24(��� -.   $* LevelSeedValue��$
��Left=�$��36��$��1083,224,0,0q�$	��Top=�$	��110��$��Right=��� -/   $"+ PreventProxyConnectionsValue��$��Prevent Proxy Connections��$
��Left=�$��36��$��807,265,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -0   $+ UseNativeTransportValue��$��Use Native Transport��$
��Left=�$��36��$��807,306,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� -1   $+ EnableRConValue��$��Enable R-Con��$
��Left=�$��36��$��807,347,0,0q�$	��Top=�$	��386��$��Center=�$��24(�
��������� $��Motd:��$
��Left=�$��36��$��807,383,0,0q�$	��Top=�$��70��
�������$��24(��� -2   $* 	MotdValue��$
��Left=�$	��246��$��807,424,0,0q�$	��Top=�$	��386��$
��Left=��� $��1��
�������$��807,675,7,124q��� -3   . ��Name$. SettingDescription��$��Description��$
��Left=�$	��114��$��806,676,0,0q�$	��Top=�$	��387��
�������$��18(�