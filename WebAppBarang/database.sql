CREATE DATABASE DB_BARANG

USE DB_BARANG

CREATE TABLE BARANG(
	ID_BARANG VARCHAR(5) PRIMARY KEY,
	NAMA VARCHAR(50),
	JENIS VARCHAR(50),
	HARGA MONEY
)

INSERT BARANG VALUES 
('B001', 'AIR FILTER ASSY M/L 300 DIESEL', 'SPARE PART', 375000),
('B002', 'ALTERNATORASSY T/KIJANG SUPER', 'SPARE PART',  750000),
('B003', 'BRAKE ADJUSTER T/INNOVA LEFT HAND', 'SPARE PART', 40000),
('B004', 'POWER STEERING HOSE D/ FEROSA', 'INTERIOR', 425000)