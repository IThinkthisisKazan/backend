-- 2.  �������� �������
CREATE TABLE dvd (
	dvd_id	INTEGER identity(1,1)  PRIMARY KEY ,
	title	VARCHAR(100) NOT NULL,
	production_year	INTEGER NOT NULL
);

CREATE TABLE customer (
	customer_id	INTEGER identity(1,1) PRIMARY KEY ,
	first_name	VARCHAR(100) NOT NULL,
	last_name	VARCHAR(100) NOT NULL,
	passport_code	INTEGER NOT NULL,
	registration_date	DATE NOT NULL
);

CREATE TABLE offer (
	offer_id	INTEGER identity(1,1) PRIMARY KEY ,
	dvd_id	INTEGER NOT NULL,
	customer_id	INTEGER NOT NULL,
	offer_date	DATE NOT NULL,
	return_date	DATE ,
);

-- 3.  ����������� SQL ������� ��� ���������� ������ �������.
INSERT INTO dvd (title, production_year) 
VALUES 
	('����������� �� �����', 1997), 
	('�����������', 2013), 
	('����� ��������', 2004), 
	('������', 2010), 
	('�������� ��� ������� �������', 1991), 
	('��������', 2010),
	('�������', 1999), 
	('����� � �������', 1985), 
	('���������� ����, ����� ���', 2010),
	('����� ���� ����', 2014),
	('��� ���', 2004),
	('������ �������� �������', 1998);

SELECT * FROM dvd

INSERT INTO customer (first_name, last_name, passport_code, registration_date) 
VALUES
	('����', '������', 123456, '2020-05-02'), 
	('����������', '�����������', 654321, '2020-05-02'), 
	('�����', '���������', 654123, '2020-05-11'),
	('���', '��������', 230612, '2006-11-07'),
	('����', '�������', 741012, '2020-03-22'),
	('����', '������', 123213, '2020-05-12');

SELECT * FROM customer

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) 
VALUES 
	(1, 2, '2020-02-03', '2020-02-13'), 
	(2, 1, '2020-01-20', '2020-01-30'), 
	(3, 3, '2020-02-15', '2019-02-25'),
	(4, 2, '2020-04-10', '2018-04-20'),
	(5, 7, '2020-02-12', NULL),
	(8, 9, '2020-04-22', NULL),
	(6, 3, '2020-04-08', '2020-04-18');

SELECT * FROM offer

-- 4.  ����������� SQL ������ ��������� ������ ���� DVD, ��� ������� ������� 2010, 
--	��������������� � ���������� ������� �� �������� DVD.
SELECT * 
FROM dvd 
WHERE production_year = 2010 
ORDER BY title ASC;

--5.  ����������� SQL ������ ��� ��������� ������ DVD ������, ������� � ��������� �����
--	��������� � ��������.
SELECT offer.return_date, dvd.title
FROM offer JOIN dvd ON offer.dvd_id = dvd.dvd_id
WHERE offer.return_date IS NULL;

--6.  �������� SQL ������ ��� ��������� ������ ��������, ������� ����� �����-���� DVD 
--	����� � ������� ����. � ����������� ������� ���������� ����� �������� ����� ����� 
--	����� �������.
SELECT customer.first_name, customer.last_name, customer.passport_code, customer.registration_date,
       dvd.title, dvd.production_year 
FROM customer 
LEFT JOIN offer ON offer.customer_id = customer.customer_id
LEFT JOIN dvd ON offer.dvd_id = dvd.dvd_id     
WHERE 
datediff(YEAR, offer_date, GETDATE()) = GETDATE() ;
	
