-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 24, 2021 at 06:59 AM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbms`
--

-- --------------------------------------------------------

--
-- Table structure for table `fees`
--

CREATE TABLE `fees` (
  `Student_id` int(11) NOT NULL,
  `Fee_month` text NOT NULL,
  `Fee_status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `fees`
--

INSERT INTO `fees` (`Student_id`, `Fee_month`, `Fee_status`) VALUES
(1, 'june', 'paid'),
(2, 'june', 'pending'),
(3, 'june', 'pending'),
(4, 'june', 'paid'),
(5, 'june', 'pending');

-- --------------------------------------------------------

--
-- Table structure for table `furniture`
--

CREATE TABLE `furniture` (
  `Furniture_id` int(11) NOT NULL,
  `Furniture_type` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `furniture`
--

INSERT INTO `furniture` (`Furniture_id`, `Furniture_type`) VALUES
(1, 'type a'),
(2, 'type b'),
(3, 'type c'),
(4, 'type d'),
(5, 'type e');

-- --------------------------------------------------------

--
-- Table structure for table `hostel`
--

CREATE TABLE `hostel` (
  `Building_number` int(10) UNSIGNED ZEROFILL NOT NULL,
  `Number_of_rooms` int(10) UNSIGNED ZEROFILL NOT NULL,
  `Number_of_students` int(10) UNSIGNED ZEROFILL NOT NULL,
  `Annual_expenses` double NOT NULL,
  `Location` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `hostel`
--

INSERT INTO `hostel` (`Building_number`, `Number_of_rooms`, `Number_of_students`, `Annual_expenses`, `Location`) VALUES
(0000000001, 0000000020, 0000000100, 1500000, 'abc'),
(0000000002, 0000000025, 0000000150, 1463000, 'def'),
(0000000003, 0000000025, 0000000200, 2500000, 'ghi'),
(0000000004, 0000000021, 0000000090, 2400000, 'jkl'),
(0000000005, 0000000030, 0000000120, 3000000, 'mno');

-- --------------------------------------------------------

--
-- Table structure for table `mess`
--

CREATE TABLE `mess` (
  `Mess_incharge` int(11) NOT NULL,
  `Monthly_expenses` int(11) NOT NULL,
  `Mess_timings` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mess`
--

INSERT INTO `mess` (`Mess_incharge`, `Monthly_expenses`, `Mess_timings`) VALUES
(1, 53000, '2 PM'),
(2, 36000, '7 PM'),
(3, 15000, '8 AM');

-- --------------------------------------------------------

--
-- Table structure for table `mess_employee`
--

CREATE TABLE `mess_employee` (
  `Employee_id` int(11) NOT NULL,
  `Employee_name` text NOT NULL,
  `Employee_Address` text NOT NULL,
  `Employee_salary` int(11) NOT NULL,
  `Employee_phone_number` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mess_employee`
--

INSERT INTO `mess_employee` (`Employee_id`, `Employee_name`, `Employee_Address`, `Employee_salary`, `Employee_phone_number`) VALUES
(1, 'james', 'chennai', 250000, '9546872310'),
(2, 'david', 'chennai', 200000, '9876542310'),
(3, 'charles', 'kerala', 150000, '9855647123'),
(4, 'steven', 'delhi', 200000, '9876541235'),
(5, 'paul', 'chennai', 150000, '9512364780');

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `Room_id` int(11) NOT NULL,
  `Capacity` int(11) NOT NULL,
  `Furniture_id` int(11) NOT NULL,
  `Building_number` int(10) UNSIGNED ZEROFILL NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`Room_id`, `Capacity`, `Furniture_id`, `Building_number`) VALUES
(1, 4, 2, 0000000001),
(2, 5, 1, 0000000001),
(3, 4, 4, 0000000004),
(4, 4, 2, 0000000002),
(5, 5, 4, 0000000003),
(6, 4, 5, 0000000002);

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `Student_id` int(11) NOT NULL,
  `Student_name` varchar(100) NOT NULL,
  `Student_fathername` varchar(100) NOT NULL,
  `Room_id` int(11) NOT NULL,
  `Phone_number` varchar(11) NOT NULL,
  `DOB` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`Student_id`, `Student_name`, `Student_fathername`, `Room_id`, `Phone_number`, `DOB`) VALUES
(1, 'noah', 'alexander', 2, '9647892130', '03-05-2001'),
(2, 'olivia', 'matthew', 4, '9546872310', '05-11-2002'),
(3, 'ava', 'mason', 4, '9872563140', '04-11-2003'),
(4, 'sophia', 'freddie', 4, '9632587410', '06-12-2002'),
(5, 'ella', 'harry', 5, '9898456712', '25-03-2001');

-- --------------------------------------------------------

--
-- Table structure for table `visitor`
--

CREATE TABLE `visitor` (
  `CNIC` varchar(20) NOT NULL,
  `Student_id` int(11) NOT NULL,
  `Visitor_name` varchar(30) NOT NULL,
  `Time_in` varchar(10) NOT NULL,
  `Time_out` varchar(10) NOT NULL,
  `Date_of_visit` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `visitor`
--

INSERT INTO `visitor` (`CNIC`, `Student_id`, `Visitor_name`, `Time_in`, `Time_out`, `Date_of_visit`) VALUES
('1', 1, 'mia', '8 AM', '8:20 AM', '02-05-2021'),
('2', 4, 'isla', '5:30 AM', '5:45 AM', '23-5-2021');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `fees`
--
ALTER TABLE `fees`
  ADD PRIMARY KEY (`Student_id`);

--
-- Indexes for table `furniture`
--
ALTER TABLE `furniture`
  ADD PRIMARY KEY (`Furniture_id`);

--
-- Indexes for table `hostel`
--
ALTER TABLE `hostel`
  ADD PRIMARY KEY (`Building_number`);

--
-- Indexes for table `mess_employee`
--
ALTER TABLE `mess_employee`
  ADD PRIMARY KEY (`Employee_id`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`Room_id`),
  ADD KEY `fk_furn_id` (`Furniture_id`),
  ADD KEY `bd_number` (`Building_number`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`Student_id`),
  ADD KEY `fk_room_id` (`Room_id`);

--
-- Indexes for table `visitor`
--
ALTER TABLE `visitor`
  ADD PRIMARY KEY (`CNIC`),
  ADD KEY `fk_stud_id` (`Student_id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `fees`
--
ALTER TABLE `fees`
  ADD CONSTRAINT `fees_ibfk_1` FOREIGN KEY (`Student_id`) REFERENCES `student` (`Student_id`);

--
-- Constraints for table `room`
--
ALTER TABLE `room`
  ADD CONSTRAINT `bd_number` FOREIGN KEY (`Building_number`) REFERENCES `hostel` (`Building_number`),
  ADD CONSTRAINT `fk_furn_id` FOREIGN KEY (`Furniture_id`) REFERENCES `furniture` (`Furniture_id`);

--
-- Constraints for table `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `fk_room_id` FOREIGN KEY (`Room_id`) REFERENCES `room` (`Room_id`);

--
-- Constraints for table `visitor`
--
ALTER TABLE `visitor`
  ADD CONSTRAINT `fk_stud_id` FOREIGN KEY (`Student_id`) REFERENCES `student` (`Student_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
