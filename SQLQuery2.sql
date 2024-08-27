
CREATE TABLE Movies(
movieId INT Primary Key Identity,
Title NVARCHAR(100),
Description NVARCHAR(MAX),
Genre NVARCHAR(50),
Duration INT ,
ReleaseDate DATETIME 
)

CREATE TABLE SHOWTIME(
showtimeId INT Primary Key Identity,
MovieId INT Foreign Key References Movies(movieId),
Showtime DATETIME,
AvailableSeats INT 
)
CREATE TABLE BOOKING(
bookingId INT Primary Key Identity,
ShowtimeId INT Foreign Key References Showtime(showtimeId),
NumberOfSeats INT,
UserName NVARCHAR(100), 
Email NVARCHAR(100) 
)
SELECT * FROM Movies
INSERT INTO Movies(Title,Description,Genre,Duration,ReleaseDate)
VALUES('Kalki',
'Kalki 2898 AD is a 2024 Indian Telugu-language epic science fiction film 
directed by Nag Ashwin and produced by','SciFi',140,GETDATE())