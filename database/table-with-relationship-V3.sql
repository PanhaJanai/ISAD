PRAGMA foreign_keys = ON; -- Enable foreign key constraints (SQLite needs this explicitly)

BEGIN;

CREATE TABLE IF NOT EXISTS tbCustomer (
  CustomerID INTEGER PRIMARY KEY AUTOINCREMENT,
  FullName NVARCHAR(50),
  Sex CHAR(1),
  PhoneNumber VARCHAR(20)
);

CREATE TABLE IF NOT EXISTS tbStaff (
  StaffID INTEGER PRIMARY KEY AUTOINCREMENT,
  FullName NVARCHAR(50),
  Sex CHAR(1),
  BirthDate DATE,
  StaffPosition NVARCHAR(50),
  StaffAddress NVARCHAR(100),
  PhoneNumber NVARCHAR(20),
  Salary DECIMAL(10, 2), -- SQLite uses DECIMAL for monetary values
  HiredDate DATE,
  Photo BLOB, -- VARBINARY(MAX) equivalent
  StoppedWork INTEGER -- BIT equivalent (0 or 1)
);

CREATE TABLE IF NOT EXISTS tbUser (
  UserID INTEGER PRIMARY KEY AUTOINCREMENT,
  Username NVARCHAR(50),
  Password NVARCHAR(50),
  StaffID INTEGER REFERENCES tbStaff(StaffID) ON DELETE CASCADE ON UPDATE CASCADE
); 

CREATE TABLE IF NOT EXISTS tbDriver (
  DriverID INTEGER PRIMARY KEY AUTOINCREMENT,
  FullName NVARCHAR(50),
  Sex CHAR(1),
  BirthDate DATE,
  DriverAddress NVARCHAR(50),
  PhoneNumber VARCHAR(20),
  Salary DECIMAL(10, 2),
  HiredDate DATE,
  Photo BLOB,
  StoppedWork INTEGER
);

CREATE TABLE IF NOT EXISTS tbBus (
  BusID INTEGER PRIMARY KEY AUTOINCREMENT,
  BusNumber NVARCHAR(10),
  TicketPrice DECIMAL(10, 2),
  DriverID INTEGER REFERENCES tbDriver(DriverID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS tbTruck (
  TruckID INTEGER PRIMARY KEY AUTOINCREMENT,
  TruckNumber NVARCHAR(10),
  DriverID INTEGER REFERENCES tbDriver(DriverID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS tbPackage (
  PackageID INTEGER PRIMARY KEY AUTOINCREMENT,
  PackageName NVARCHAR(50),
  PackagePrice DECIMAL(10, 2),
  DeliveryDate DATE,
  DepartureDate DATE,
  ReceiverContactInformation VARCHAR(20),
  OriginName NVARCHAR(50),
  DestinationName NVARCHAR(50),
  CustomerID INTEGER REFERENCES tbCustomer(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE,
  StaffID INTEGER REFERENCES tbStaff(StaffID) ON DELETE CASCADE ON UPDATE CASCADE,
  TruckID INTEGER REFERENCES tbTruck(TruckID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS tbTicket (
  TicketID INTEGER PRIMARY KEY AUTOINCREMENT,
  PurchaseDate DATE,
  DepartureDate DATE,
  OriginName NVARCHAR(50),
  DestinationName NVARCHAR(50),
  CustomerID INTEGER REFERENCES tbCustomer(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE,
  StaffID INTEGER REFERENCES tbStaff(StaffID) ON DELETE CASCADE ON UPDATE CASCADE,
  BusID INTEGER REFERENCES tbBus(BusID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS tbPaymentTicket (
  PaymentTicketID INTEGER PRIMARY KEY AUTOINCREMENT,
  PaymentDate DATE,
  PaymentAmount DECIMAL(10, 2),
  TicketID INTEGER REFERENCES tbTicket(TicketID) ON DELETE CASCADE ON UPDATE CASCADE,
  StaffID INTEGER
);

CREATE TABLE IF NOT EXISTS tbPaymentPackage (
  PaymentPackageID INTEGER PRIMARY KEY AUTOINCREMENT,
  PaymentDate DATE,
  PaymentAmount DECIMAL(10, 2),
  PackageID INTEGER REFERENCES tbPackage(PackageID) ON DELETE CASCADE ON UPDATE CASCADE,
  StaffID INTEGER
);

CREATE TABLE IF NOT EXISTS tbInvoiceTicket( 
  InvoiceTicketID INTEGER PRIMARY KEY AUTOINCREMENT,
  StaffID INTEGER,
  CustomerID INTEGER,
  RouteID INTEGER,
  BusID INTEGER,
  DriverID INTEGER,
  TicketID INTEGER,
  BookingID INTEGER,
  PaymentTicketID INTEGER
);

CREATE TABLE IF NOT EXISTS tbInvoicePackage(
  InvoicePackageID INTEGER PRIMARY KEY AUTOINCREMENT,
  StaffID INTEGER,
  CustomerID INTEGER,
  RouteID INTEGER,
  TruckID INTEGER,
  DriverID INTEGER,
  PackageID INTEGER,
  PaymentPackageID INTEGER
);

COMMIT;
