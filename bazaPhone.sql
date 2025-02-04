use subscribersTelephoneCompany;

create table ��������(����� int identity(1,1) primary key, ��� varchar(200), ������������ date, ������������� varchar(50), ��������������� varchar(200))
insert into �������� values
('��������� ��������� ��������', '08.10.2005', '89964438612', '�. ��������, ��. �������������, ��� ������������ ��. 28'),
('�������� ����� �������������', '09.02.2005', '89308325199', '�. ��������, ��. ������� ��� 16'),
('��������� ������� ����������', '01.06.2005', '89300328940', '�. ��������, ��. �������������'),
('����� ������� ���������', '01.07.2005', '89004796226', '�. ��������, ��. 3-��');

create table ������������������� (����� int identity(1,1) primary key, ������ int, ����� int foreign key references ������(�����), ������ varchar(200))
insert into ������������������� values
('1000', 1, '1 3 5'),
('1000', 1, '2 1'),
('932', 2, '1'),
('633', 3, '3 4');

create table �������� (����� int identity(1,1) primary key, ������������� int foreign key references ��������(�����), ���� date, ����� varchar(100))
insert into �������� values
(1, '01.11.2023', '+300'),
(1, '11.10.2023', '-200'),
(1, '09.09.2023', '+200'),
(2, '04.12.2023', '-300'),
(2, '03.11.2023', '+200'),
(3, '23.08.2023', '+1000'),
(4, '01.12.2023', '-234'),
(4, '16.10.2023', '+234');

create table ������ (����� int identity(1,1) primary key, ������������ varchar(200), ��������� int, ������ varchar(50), ������������������ varchar(200))
insert into ������ values
('����������', '10', '��� � �����', '��� ��� ���'),
('����������', '10', '��� � �����', '��� ��� ���'),
('������������', '10', '��� � �����', '��� ��� ���'),
('������������������', '80', '��� � �����', '��� ��� ���'),
('��������������������', '129', '��� � �����', '��� ��� ���');

create table ������ (����� int identity(1,1) primary key, ������������ varchar(100), ��������� int, ��������������� int, ������������� int, �������� varchar(50))
insert into ������ values
('BlackOnline+', '400', '200', '20', '50 ��'),
('Online+', '300', '100', '20', '50 ��'),
('Online', '200', '50', '10', '��������');

create table �������� (����� int identity(1,1) primary key, �������������� date, ��������������� varchar(200), ������������ varchar(50), ����� int foreign key references ������(�����))
insert into �������� values
('02.02.2021', '�. ��������', '���������', 1),
('02.02.2021', '�. ��������', '������', 1),
('02.05.2021', '�. ��������', '����������', 2),
('02.03.2021', '�. ��������', '����', 3);

alter table �������� add foreign key (�����) references ��������(�����)
alter table �������� add foreign key (�����) references �������������������(�����)

drop table �������������������
drop table ������
drop table ������
drop table ��������
drop table ��������
drop table ��������
