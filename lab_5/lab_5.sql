-- 2.  Добавьте таблицы
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

-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.
INSERT INTO dvd (title, production_year) 
VALUES 
	('Достучаться до небес', 1997), 
	('Исчезнувшая', 2013), 
	('Грань будущего', 2004), 
	('Начало', 2010), 
	('Пролетая над гнездом кукушки', 1991), 
	('Прометей', 2010),
	('Матрица', 1999), 
	('Назад в будущее', 1985), 
	('Здравствуй папа, новый год', 2010),
	('Между нами горы', 2014),
	('Олд Бой', 2004),
	('Спасти рядового Брайана', 1998);

SELECT * FROM dvd

INSERT INTO customer (first_name, last_name, passport_code, registration_date) 
VALUES
	('Иван', 'Иванов', 123456, '2020-05-02'), 
	('Аннастасия', 'Владимирова', 654321, '2020-05-02'), 
	('Елена', 'Андреевна', 654123, '2020-05-11'),
	('Оля', 'Орозаева', 230612, '2006-11-07'),
	('Маша', 'Окунева', 741012, '2020-03-22'),
	('Юрий', 'Петров', 123213, '2020-05-12');

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

-- 4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, 
--	отсортированных в алфавитном порядке по названию DVD.
SELECT * 
FROM dvd 
WHERE production_year = 2010 
ORDER BY title ASC;

--5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время
--	находятся у клиентов.
SELECT offer.return_date, dvd.title
FROM offer JOIN dvd ON offer.dvd_id = dvd.dvd_id
WHERE offer.return_date IS NULL;

--6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD 
--	диски в текущем году. В результатах запроса необходимо также отразить какие диски 
--	брали клиенты.
SELECT customer.first_name, customer.last_name, customer.passport_code, customer.registration_date,
       dvd.title, dvd.production_year 
FROM customer 
LEFT JOIN offer ON offer.customer_id = customer.customer_id
LEFT JOIN dvd ON offer.dvd_id = dvd.dvd_id     
WHERE 
datediff(YEAR, offer_date, GETDATE()) = GETDATE() ;
	
