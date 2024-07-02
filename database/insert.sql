-- Inserting data into tbCustomer
INSERT INTO tbCustomer (FullName, Sex, PhoneNumber) 
VALUES 
('Alice Smith', 'F', '123-456-7890'),
('Bob Johnson', 'M', '234-567-8901'),
('Carol White', 'F', '345-678-9012');

-- Inserting data into tbStaff
INSERT INTO tbStaff (FullName, Sex, BirthDate, StaffPosition, StaffAddress, PhoneNumber, Salary, HiredDate, Photo, StoppedWork)
VALUES 
('David Brown', 'M', '1980-01-01', 'Manager', '123 Main St', '456-789-0123', 50000.00, '2020-06-01', NULL, 0),
('Eva Green', 'F', '1990-02-02', 'Clerk', '456 Elm St', '567-890-1234', 30000.00, '2021-01-15', NULL, 0),
('Frank Black', 'M', '1985-03-03', 'Driver', '789 Oak St', '678-901-2345', 40000.00, '2019-09-30', NULL, 1);

-- Inserting data into tbUser
INSERT INTO tbUser (Username, Password, StaffID)
VALUES 
('panha', '123', 1),
('hak', '321', 2),
('peng', 'password', 3);

-- Inserting data into tbDriver
INSERT INTO tbDriver (FullName, Sex, BirthDate, DriverAddress, PhoneNumber, Salary, HiredDate, Photo, StoppedWork)
VALUES 
('George King', 'M', '1975-04-04', '321 Birch St', '789-012-3456', 45000.00, '2018-07-20', NULL, 0),
('Hannah Queen', 'F', '1988-05-05', '654 Pine St', '890-123-4567', 42000.00, '2019-11-05', NULL, 0),
('Ian Prince', 'M', '1992-06-06', '987 Cedar St', '901-234-5678', 40000.00, '2022-02-10', NULL, 1);

-- Inserting data into tbBus
INSERT INTO tbBus (BusNumber, TicketPrice, DriverID)
VALUES 
('Bus100', 1000.00, 1),
('Bus200', 1200.00, 2),
('Bus300', 1500.00, 3);

-- Inserting data into tbTruck
INSERT INTO tbTruck (TruckNumber, DriverID)
VALUES 
('Truck100', 1),
('Truck200', 2),
('Truck300', 3);

-- Inserting data into tbPackage
INSERT INTO tbPackage (PackageName, PackagePrice, DeliveryDate, DepartureDate, ReceiverContactInformation, OriginName, DestinationName, CustomerID, StaffID, TruckID)
VALUES 
('Package A', 150.00, '2024-07-01', '2024-06-25', '123-456-7890', 'City A', 'City B', 1, 1, 1),
('Package B', 200.00, '2024-07-02', '2024-06-26', '234-567-8901', 'City C', 'City D', 2, 2, 2),
('Package C', 250.00, '2024-07-03', '2024-06-27', '345-678-9012', 'City E', 'City F', 3, 3, 3);

-- Inserting data into tbTicket
INSERT INTO tbTicket (PurchaseDate, DepartureDate, OriginName, DestinationName, CustomerID, StaffID, BusID)
VALUES 
('2024-06-20', '2024-06-25', 'City G', 'City H', 1, 1, 1),
('2024-06-21', '2024-06-26', 'City I', 'City J', 2, 2, 2),
('2024-06-22', '2024-06-27', 'City K', 'City L', 3, 3, 3);

-- Inserting data into tbPaymentTicket
INSERT INTO tbPaymentTicket (PaymentDate, PaymentAmount, TicketID, StaffID)
VALUES 
('2024-06-23', 1000.00, 1, 1),
('2024-06-24', 1200.00, 2, 2),
('2024-06-25', 1500.00, 3, 3);

-- Inserting data into tbPaymentPackage
INSERT INTO tbPaymentPackage (PaymentDate, PaymentAmount, PackageID, StaffID)
VALUES 
('2024-06-28', 150.00, 1, 1),
('2024-06-29', 200.00, 2, 2),
('2024-06-30', 250.00, 3, 3);

-- Inserting data into tbInvoiceTicket
INSERT INTO tbInvoiceTicket (StaffID, CustomerID, RouteID, BusID, DriverID, TicketID, BookingID, PaymentTicketID)
VALUES 
(1, 1, 1, 1, 1, 1, 1, 1),
(2, 2, 2, 2, 2, 2, 2, 2),
(3, 3, 3, 3, 3, 3, 3, 3);

-- Inserting data into tbInvoicePackage
INSERT INTO tbInvoicePackage (StaffID, CustomerID, RouteID, TruckID, DriverID, PackageID, PaymentPackageID)
VALUES 
(1, 1, 1, 1, 1, 1, 1),
(2, 2, 2, 2, 2, 2, 2),
(3, 3, 3, 3, 3, 3, 3);
