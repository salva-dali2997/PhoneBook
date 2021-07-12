USE master;

CREATE DATABASE PhoneBook;

USE PhoneBook;

CREATE TABLE contact
(
	contact_id		int				identity(1,1)		primary key,
	first_name		varchar(40)		not null,
	last_name		varchar(40)		null,
	phone_number	varchar(15)		null,
	email			varchar(64)		null,
	date_of_birth	datetime		null,
)

CREATE TABLE address
(
	address_id			int			identity(1,1)		primary key,
	street_address_1	varchar(40)	not null,
	street_address_2	varchar(40)	null,
	city				varchar(40)	null,
	state				varchar(40)	null,
	zip_code			varchar(8)	null

)

CREATE TABLE contact_address
(
	contact_id			int			not null,
	address_id			int			not null

	constraint			fk_contact_address_id		primary key		(contact_id, address_id)
)

INSERT INTO contact
(first_name, last_name, phone_number, email, date_of_birth)
VALUES

INSERT INTO address
(street_address_1, city, state, zip_code)
VALUES

INSERT INTO contact_address
(contact_id, address_id)
VALUES


SELECT * 
FROM contact
SELECT * 
FROM address

	