   M S B A M L   `   `   `  ���� >  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPF.Models
WPF.Models      WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:WPF.Models     ���#2b2a2a  � Title$  
MainWindow��$	��650��$
��1000��$	��650��$
��1000�� � 	Resources  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value   WPF.Models.Score 	  score   NumWins	   NumDraws
   NumLoses   Winner��%�   '��       &	  f     �� " �� P�  �@J�IsMouseOver . . ���  �@J�Opacity$	 0.7Q���  � �� ��   $ 0��$	 0��$
 0��$
 none��.���  � ShowGridLines .  ���#2b2a2a � ColumnDefinitions �� $	��10* ��� $
��170* ��� $
��559* ��� $
��Auto ��� $
��246* � � RowDefinitions �� $	��19* ��� $	��76* ��� $��7* ��� $
��381* ��� $
��Auto ��� $
��133* �.+��� $��7�� �� ShowsPreview . $��3��$��3��$��Center=�$��Stretch=����#deb40b�� $��7�� . $��0��$��2��$��5�����#edbf05$��Stretch=�$��Center=��� $��7�� . $��0��$��4��$��5�����#deb614$��Stretch=�$��Center=�� $��5�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��1��
�������$��Stretch=�$��Bottom=� � Cursor$ Arrow���� $��2��$��1��
�������$��Stretch=�$��Bottom=�$ Arrow��� $��1�����#ffcd00� $��5��$��1�� � DataContext# [   �� �� �� �� .+��� -    ��Name$ numWins�����#e8e8e8$��Center=�$��Center=�$
��30px(�$
��Wrap=� �� TextAlignment$ Center=�����  �� StringFormat$* $Количество побед: {0}�� �� Path$ NumWins��� -   $ numLoses��$��1�����#e8e8e8$��Center=�$��Center=�$
��30px(�$
��Wrap=�$ Center=����� $2 ,Количество поражений: {0}��$ NumLoses��� -   $ numDraws��$��2�����#e8e8e8$��Center=�$��Center=�$
��30px(�$
��Wrap=�$ Center=����� $, &Количество ничьих: {0}��$ NumDraws��� -   $ winner��$��3�����#e8e8e8$��Center=�$��Center=�$
��30px(�$
��Wrap=�$ Center=����� $ Победитель: {0}��$ Winner�� $��5��$��5�� �� �� $	��10* ��� �� $	��10* ��� �� $	��10* ��� �� $	��10* ���  �� �� $��3* ��� .+��� -    ��Name$ b_Start�����#c49f08$��1��$��1�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 13��.���� .+��� -   $ textBlockStart�����#e8e8e8$��Consolas)�$
��40pt(�$��WrapWithOverflow=�$��Center=�$��Center=�
Старт�� -   $ b_Again��$��3�����#c49f08$��1�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 13��.���� .+��� ���#e8e8e8$��Consolas)�$
��35pt(�$��Center=�$��Center=�Еще раз�� -   $ b_Report��$��5�����#c49f08$��1�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 13��.���� .+��� ���#e8e8e8$��Consolas)�$
��21pt(�$��WrapWithOverflow=�$ Center=�$��Center=�$��Center=�*(Связь с разработчиком�� -	   $ b_RandomAction��$��7�����#c49f08$��1�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 13��.���� .+��� ���#e8e8e8$��Consolas)�$
��16pt(�$ Center=�$��WrapWithOverflow=�$��Center=�$��Center=�*(Сделать рондомный ход� $��3��$��3�� �� $��* ��� $��2* ��� $��* � �� $
��0.5* ��� $��5* ��� $
��0.5* ��� $��5* ��� $
��0.5* �.+�� $��1��$��1��.+��� -
    ��Name$ ComputerActionImage��� $��3��$��1��.+��� -   $ PlayerActionImage��� -    �Name$ ReportField��$��1��$��1��$��3��$y�Hidden=�{�.   �� $��* ��� $��3* �.+��� $��0�����#ffcd00$��Consolas)�$��40(�$��Center=�$��Center=�#!Введите пожелание�� -    ��Name$ 	rFTextBox��$��1�����#e8e8e8$��Consolas)�$
��25pt(� �� TextWrapping$
 Wrap=� �� 	MaxLength$	 100������ ���� .��� -   $ 
actionText��$��1��.+��� ���#e8e8e8$��Consolas)�$
��48pt(�$��WrapWithOverflow=�$��Center=�$��Center=�Компьютер� -   $ actionText2��$��3��.+��� ���#e8e8e8$��Consolas)�$
��48pt(�$��WrapWithOverflow=�$��Center=�$��Center=�
Игрок� $��2��$��3��$��1��$��	0 10 0 10q�.+��� -   $ b_Back�����#c49f08$��1��$��1��$y�Hidden=�{�.   ��%:   '��       �� " ��.���  �@��CornerRadius$ 13��.���� .+��� ���#e8e8e8$��Consolas)�$
��40pt(�$��WrapWithOverflow=�$��Center=�$��Center=�Отмена� $��4��$��3��.+��  �� �� �� .+��� -   $ b_Stone������ .���� $��Imges\stone.png���� -   $ 
b_Scissors��$��1������ .���� $��Imges\scissors.png���� -   $ b_Paper��$��2������ .���� $��Imges\paper.png��