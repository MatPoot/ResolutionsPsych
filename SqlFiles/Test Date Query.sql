EXECUTE CreateLogin 'username123', 'password123', 'Secretary'
EXECUTE CreateLogin 'wow123', 'qwerty', 'Counsellor'

EXECUTE CreateClient 'Banana', NULL, 'Man', 'bananaman@banan.com', '(780)-123-4567', '1234 56 Street'
EXECUTE CreateCounsellor 'Mangodude'
EXECUTE CreateAppointment '2021-02-27', 1, 1, NULL

select * from Clients
--select * from Counsellors
--select * from Logins
select * from Appointments

select ClientID from Clients WHERE FirstName = 'James' and MiddleName is null and LastName = 'Dean'