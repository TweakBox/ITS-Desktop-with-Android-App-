-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 08, 2016 at 11:20 AM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 5.6.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jsla`
--

-- --------------------------------------------------------

--
-- Table structure for table `meta_file`
--

CREATE TABLE `meta_file` (
  `File_ID` varchar(9) NOT NULL,
  `Title` varchar(20) NOT NULL,
  `SubjectIID` varchar(9) NOT NULL,
  `Description` text NOT NULL,
  `UploadedBy` varchar(9) NOT NULL,
  `UploadedTo` varchar(9) NOT NULL,
  `FilePath` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblquizinfo`
--

CREATE TABLE `tblquizinfo` (
  `QuizID` varchar(9) NOT NULL,
  `QuizTitle` varchar(255) DEFAULT NULL,
  `SubjectID` varchar(9) DEFAULT NULL,
  `TeacherID` varchar(9) DEFAULT NULL,
  `quizType` varchar(255) DEFAULT NULL,
  `Year` varchar(255) DEFAULT NULL,
  `SectionID` varchar(9) DEFAULT NULL,
  `No.ofItem` int(11) DEFAULT NULL,
  `Points` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_accounts`
--

CREATE TABLE `tbl_accounts` (
  `UserId` varchar(9) NOT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `AccType` varchar(25) DEFAULT NULL,
  `ReferenceId` varchar(255) DEFAULT NULL,
  `Attempts` int(11) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_accounts`
--

INSERT INTO `tbl_accounts` (`UserId`, `Password`, `AccType`, `ReferenceId`, `Attempts`) VALUES
('123123123', '123123123', 'Student', '123123123', 0),
('202020', '222222', 'Teacher', NULL, 0),
('303030', '333333', 'Admin', NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_course`
--

CREATE TABLE `tbl_course` (
  `CourseID` varchar(9) NOT NULL,
  `Course` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_course`
--

INSERT INTO `tbl_course` (`CourseID`, `Course`, `Description`) VALUES
('1', 'ICT', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_homeroom`
--

CREATE TABLE `tbl_homeroom` (
  `HomeRoomID` varchar(9) NOT NULL,
  `SectionID` varchar(9) DEFAULT NULL,
  `Year` varchar(25) DEFAULT NULL,
  `Adviser` varchar(255) DEFAULT NULL,
  `Room` varchar(5) DEFAULT NULL,
  `No.ofStudent` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_homework`
--

CREATE TABLE `tbl_homework` (
  `Homework_Id` int(11) NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Teacher_Id` varchar(9) DEFAULT NULL,
  `Section_Id` int(11) DEFAULT NULL,
  `Subject_Id` int(11) DEFAULT NULL,
  `DatePosted` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `DateDue` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_homework`
--

INSERT INTO `tbl_homework` (`Homework_Id`, `Title`, `Content`, `Teacher_Id`, `Section_Id`, `Subject_Id`, `DatePosted`, `DateDue`) VALUES
(1, 'Earth''s Composition', 'Research about the Earth''s soil composition', '303030', 1, 3, '2016-09-06 01:29:43', '2016-09-09 01:29:46'),
(2, 'kasdkadk', 'asdakjsdkahd', '202020', 1, 3, '2016-09-06 01:30:05', '2016-09-19 01:30:09'),
(3, 'asdadasdasdasdad,dkjadhahdkjhkahdkahkdakd', 'ad', '202020', 1, 3, '2016-09-06 01:30:31', '2016-09-16 01:30:36');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_notes`
--

CREATE TABLE `tbl_notes` (
  `Note_ID` varchar(9) NOT NULL,
  `Subject_ID` int(11) DEFAULT NULL,
  `Stud_ID` varchar(9) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Content` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sections`
--

CREATE TABLE `tbl_sections` (
  `Section_ID` int(11) NOT NULL,
  `Section` varchar(255) DEFAULT NULL,
  `Course_ID` varchar(255) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_sections`
--

INSERT INTO `tbl_sections` (`Section_ID`, `Section`, `Course_ID`, `Year`) VALUES
(1, 'Integrity', '1', 9),
(2, 'Fortitude', '1', 10),
(3, 'Piety', '1', 10);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_student`
--

CREATE TABLE `tbl_student` (
  `Stud_ID` varchar(9) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `MiddleName` varchar(255) DEFAULT NULL,
  `Section_ID` int(11) NOT NULL,
  `Avatar` blob
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_student`
--

INSERT INTO `tbl_student` (`Stud_ID`, `LastName`, `FirstName`, `MiddleName`, `Section_ID`, `Avatar`) VALUES
('#####-###', 'aga', 'gaga', 'gaga', 1, NULL),
('000000000', 'Ortiz', 'Patricia', NULL, 1, NULL),
('101010101', 'Balabis', 'Joyce', 'Mir', 1, NULL),
('123123123', 'Okura', 'Ryota', 'Borja', 1, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_subject`
--

CREATE TABLE `tbl_subject` (
  `Subject_ID` int(11) NOT NULL,
  `Subject_Code` varchar(255) DEFAULT NULL,
  `Subject_Name` varchar(25) DEFAULT NULL,
  `Year` varchar(25) DEFAULT NULL,
  `CourseID` varchar(9) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_subject`
--

INSERT INTO `tbl_subject` (`Subject_ID`, `Subject_Code`, `Subject_Name`, `Year`, `CourseID`) VALUES
(1, NULL, 'Oral Communication', NULL, NULL),
(2, NULL, 'Earth & Life Science', NULL, NULL),
(3, NULL, 'Earth Science', NULL, NULL),
(4, NULL, 'Literature', NULL, NULL),
(5, NULL, 'Multimedia', NULL, NULL),
(6, NULL, 'Programming', NULL, NULL),
(7, NULL, 'Animation', NULL, NULL),
(8, NULL, '21st Century', NULL, NULL),
(9, NULL, 'Physical Education', NULL, NULL),
(10, NULL, 'Business Math', NULL, NULL),
(11, NULL, 'General Math', NULL, NULL),
(12, NULL, 'Pre-Calculus', NULL, NULL),
(13, NULL, 'Differential Calculus', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_teachers`
--

CREATE TABLE `tbl_teachers` (
  `Teacher_Id` varchar(9) NOT NULL,
  `LastName` varchar(25) NOT NULL,
  `FirstName` varchar(25) NOT NULL,
  `MiddleInitial` varchar(3) DEFAULT NULL,
  `Avatar` varchar(255) DEFAULT NULL,
  `Status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `tbl_teachers`
--

INSERT INTO `tbl_teachers` (`Teacher_Id`, `LastName`, `FirstName`, `MiddleInitial`, `Avatar`, `Status`) VALUES
('202020', 'balabis', 'joyce', 'm', NULL, ''),
('303030', 'albania', 'eman', 'l', NULL, '');

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_studentinfo`
--
CREATE TABLE `vw_studentinfo` (
`Stud_ID` varchar(9)
,`LastName` varchar(255)
,`FirstName` varchar(255)
,`MiddleName` varchar(255)
,`Section` varchar(255)
,`Course` varchar(255)
,`Year` int(11)
);

-- --------------------------------------------------------

--
-- Structure for view `vw_studentinfo`
--
DROP TABLE IF EXISTS `vw_studentinfo`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_studentinfo`  AS  select `tbl_student`.`Stud_ID` AS `Stud_ID`,`tbl_student`.`LastName` AS `LastName`,`tbl_student`.`FirstName` AS `FirstName`,`tbl_student`.`MiddleName` AS `MiddleName`,`tbl_sections`.`Section` AS `Section`,`tbl_course`.`Course` AS `Course`,`tbl_sections`.`Year` AS `Year` from ((`tbl_student` join `tbl_sections` on((`tbl_student`.`Section_ID` = `tbl_sections`.`Section_ID`))) join `tbl_course` on((`tbl_sections`.`Course_ID` = `tbl_course`.`CourseID`))) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `meta_file`
--
ALTER TABLE `meta_file`
  ADD PRIMARY KEY (`File_ID`);

--
-- Indexes for table `tblquizinfo`
--
ALTER TABLE `tblquizinfo`
  ADD PRIMARY KEY (`QuizID`);

--
-- Indexes for table `tbl_accounts`
--
ALTER TABLE `tbl_accounts`
  ADD PRIMARY KEY (`UserId`);

--
-- Indexes for table `tbl_course`
--
ALTER TABLE `tbl_course`
  ADD PRIMARY KEY (`CourseID`);

--
-- Indexes for table `tbl_homeroom`
--
ALTER TABLE `tbl_homeroom`
  ADD PRIMARY KEY (`HomeRoomID`);

--
-- Indexes for table `tbl_homework`
--
ALTER TABLE `tbl_homework`
  ADD PRIMARY KEY (`Homework_Id`),
  ADD KEY `Teacher_Id` (`Teacher_Id`),
  ADD KEY `Subject_Id` (`Subject_Id`),
  ADD KEY `Section_Id` (`Section_Id`);

--
-- Indexes for table `tbl_notes`
--
ALTER TABLE `tbl_notes`
  ADD PRIMARY KEY (`Note_ID`),
  ADD KEY `Subject_ID` (`Subject_ID`);

--
-- Indexes for table `tbl_sections`
--
ALTER TABLE `tbl_sections`
  ADD PRIMARY KEY (`Section_ID`),
  ADD KEY `Course_ID` (`Course_ID`);

--
-- Indexes for table `tbl_student`
--
ALTER TABLE `tbl_student`
  ADD PRIMARY KEY (`Stud_ID`),
  ADD KEY `Section_ID` (`Section_ID`);

--
-- Indexes for table `tbl_subject`
--
ALTER TABLE `tbl_subject`
  ADD PRIMARY KEY (`Subject_ID`);

--
-- Indexes for table `tbl_teachers`
--
ALTER TABLE `tbl_teachers`
  ADD PRIMARY KEY (`Teacher_Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_homework`
--
ALTER TABLE `tbl_homework`
  MODIFY `Homework_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `tbl_subject`
--
ALTER TABLE `tbl_subject`
  MODIFY `Subject_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_homework`
--
ALTER TABLE `tbl_homework`
  ADD CONSTRAINT `tbl_homework_ibfk_1` FOREIGN KEY (`Teacher_Id`) REFERENCES `tbl_teachers` (`Teacher_Id`),
  ADD CONSTRAINT `tbl_homework_ibfk_3` FOREIGN KEY (`Subject_Id`) REFERENCES `tbl_subject` (`Subject_ID`),
  ADD CONSTRAINT `tbl_homework_ibfk_4` FOREIGN KEY (`Section_Id`) REFERENCES `tbl_sections` (`Section_ID`);

--
-- Constraints for table `tbl_notes`
--
ALTER TABLE `tbl_notes`
  ADD CONSTRAINT `tbl_notes_ibfk_1` FOREIGN KEY (`Subject_ID`) REFERENCES `tbl_subject` (`Subject_ID`);

--
-- Constraints for table `tbl_sections`
--
ALTER TABLE `tbl_sections`
  ADD CONSTRAINT `tbl_sections_ibfk_1` FOREIGN KEY (`Course_ID`) REFERENCES `tbl_course` (`CourseID`);

--
-- Constraints for table `tbl_student`
--
ALTER TABLE `tbl_student`
  ADD CONSTRAINT `tbl_student_ibfk_1` FOREIGN KEY (`Section_ID`) REFERENCES `tbl_sections` (`Section_ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
