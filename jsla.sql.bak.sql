/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50505
Source Host           : 127.0.0.1:3306
Source Database       : jsla

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2016-09-11 12:21:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for meta_file
-- ----------------------------
DROP TABLE IF EXISTS `meta_file`;
CREATE TABLE `meta_file` (
  `File_ID` varchar(9) NOT NULL,
  `Title` varchar(20) NOT NULL,
  `SubjectIID` varchar(9) NOT NULL,
  `Description` text NOT NULL,
  `UploadedBy` varchar(9) NOT NULL,
  `UploadedTo` varchar(9) NOT NULL,
  `FilePath` text NOT NULL,
  PRIMARY KEY (`File_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of meta_file
-- ----------------------------

-- ----------------------------
-- Table structure for tblquizinfo
-- ----------------------------
DROP TABLE IF EXISTS `tblquizinfo`;
CREATE TABLE `tblquizinfo` (
  `QuizID` varchar(9) NOT NULL,
  `QuizTitle` varchar(255) DEFAULT NULL,
  `SubjectID` varchar(9) DEFAULT NULL,
  `TeacherID` varchar(9) DEFAULT NULL,
  `quizType` varchar(255) DEFAULT NULL,
  `Year` varchar(255) DEFAULT NULL,
  `SectionID` varchar(9) DEFAULT NULL,
  `No.ofItem` int(11) DEFAULT NULL,
  `Points` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuizID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblquizinfo
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_academicstaff
-- ----------------------------
DROP TABLE IF EXISTS `tbl_academicstaff`;
CREATE TABLE `tbl_academicstaff` (
  `_ID` varchar(9) NOT NULL,
  `LastName` varchar(25) NOT NULL,
  `FirstName` varchar(25) NOT NULL,
  `MiddleInitial` varchar(3) DEFAULT NULL,
  `Gender` varchar(255) DEFAULT NULL,
  `Avatar` varchar(255) DEFAULT NULL,
  `Status` varchar(10) NOT NULL,
  PRIMARY KEY (`_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of tbl_academicstaff
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_accounts
-- ----------------------------
DROP TABLE IF EXISTS `tbl_accounts`;
CREATE TABLE `tbl_accounts` (
  `UserId` varchar(9) NOT NULL,
  `Password` varchar(10) DEFAULT NULL,
  `AccType` varchar(25) DEFAULT NULL,
  `ReferenceId` varchar(255) DEFAULT NULL,
  `Attempts` int(11) DEFAULT '0',
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_accounts
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_announcement
-- ----------------------------
DROP TABLE IF EXISTS `tbl_announcement`;
CREATE TABLE `tbl_announcement` (
  `_ID` int(11) NOT NULL,
  `DatePosted` datetime DEFAULT NULL,
  `Poster` blob,
  PRIMARY KEY (`_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_announcement
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_branch
-- ----------------------------
DROP TABLE IF EXISTS `tbl_branch`;
CREATE TABLE `tbl_branch` (
  `_ID` int(11) NOT NULL,
  `Branch` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_branch
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_class
-- ----------------------------
DROP TABLE IF EXISTS `tbl_class`;
CREATE TABLE `tbl_class` (
  `_ID` varchar(9) NOT NULL,
  `SubjectID` varchar(25) DEFAULT NULL,
  `SectionID` varchar(25) DEFAULT NULL,
  `Faculty` varchar(9) DEFAULT NULL,
  `School Year` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_class
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_classlist
-- ----------------------------
DROP TABLE IF EXISTS `tbl_classlist`;
CREATE TABLE `tbl_classlist` (
  `_ID` varchar(9) NOT NULL,
  `Class_ID` varchar(9) DEFAULT NULL,
  `Stud_No` varchar(9) DEFAULT NULL,
  PRIMARY KEY (`_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_classlist
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_course
-- ----------------------------
DROP TABLE IF EXISTS `tbl_course`;
CREATE TABLE `tbl_course` (
  `CourseID` varchar(9) NOT NULL,
  `Course` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CourseID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_course
-- ----------------------------
INSERT INTO `tbl_course` VALUES ('1', 'ICT', null);

-- ----------------------------
-- Table structure for tbl_homeroom
-- ----------------------------
DROP TABLE IF EXISTS `tbl_homeroom`;
CREATE TABLE `tbl_homeroom` (
  `HomeRoomID` varchar(9) NOT NULL,
  `SectionID` varchar(9) DEFAULT NULL,
  `Year` varchar(25) DEFAULT NULL,
  `Adviser` varchar(255) DEFAULT NULL,
  `Room` varchar(5) DEFAULT NULL,
  `No.ofStudent` int(11) DEFAULT NULL,
  PRIMARY KEY (`HomeRoomID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_homeroom
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_homework
-- ----------------------------
DROP TABLE IF EXISTS `tbl_homework`;
CREATE TABLE `tbl_homework` (
  `Homework_Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Teacher_Id` varchar(9) DEFAULT NULL,
  `Section_Id` varchar(9) DEFAULT NULL,
  `Subject_Id` int(11) DEFAULT NULL,
  `DatePosted` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `DateDue` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Homework_Id`),
  KEY `Teacher_Id` (`Teacher_Id`),
  KEY `Subject_Id` (`Subject_Id`),
  KEY `Section_Id` (`Section_Id`),
  CONSTRAINT `tbl_homework_ibfk_1` FOREIGN KEY (`Teacher_Id`) REFERENCES `tbl_teachers` (`Teacher_Id`),
  CONSTRAINT `tbl_homework_ibfk_3` FOREIGN KEY (`Subject_Id`) REFERENCES `tbl_subject` (`Subject_ID`),
  CONSTRAINT `tbl_homework_ibfk_4` FOREIGN KEY (`Section_Id`) REFERENCES `tbl_sections` (`Section_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_homework
-- ----------------------------
INSERT INTO `tbl_homework` VALUES ('1', 'Earth\'s Composition', 'Research about the Earth\'s soil composition', '303030', '1', '3', '2016-09-09 14:35:50', '2016-09-12 01:29:46');
INSERT INTO `tbl_homework` VALUES ('2', 'kasdkadk', 'asdakjsdkahd', '202020', '1', '3', '2016-09-06 01:30:05', '2016-09-19 01:30:09');
INSERT INTO `tbl_homework` VALUES ('3', 'asdadasdasdasdad,dkjadhahdkjhkahdkahkdakd', 'ad', '202020', '1', '3', '2016-09-06 01:30:31', '2016-09-16 01:30:36');
INSERT INTO `tbl_homework` VALUES ('4', 'marvs', 'lahdkahkjhdkjhdkahdkhkdashd', '202020', '1', '2', '2016-09-09 14:56:17', '2016-09-07 14:54:37');
INSERT INTO `tbl_homework` VALUES ('5', 'ajsdgjasd', 'aksdakhdakdad', '303030', '1', '2', '2016-09-06 14:55:11', '2016-09-14 14:55:15');

-- ----------------------------
-- Table structure for tbl_notes
-- ----------------------------
DROP TABLE IF EXISTS `tbl_notes`;
CREATE TABLE `tbl_notes` (
  `Note_ID` varchar(9) NOT NULL,
  `Subject_ID` varchar(9) DEFAULT NULL,
  `Stud_ID` varchar(9) DEFAULT NULL,
  `Note` text,
  PRIMARY KEY (`Note_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_notes
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_student
-- ----------------------------
DROP TABLE IF EXISTS `tbl_student`;
CREATE TABLE `tbl_student` (
  `Stud_ID` varchar(9) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `MiddleName` varchar(255) DEFAULT NULL,
  `Section_ID` varchar(9) NOT NULL,
  `Avatar` blob,
  `Gender` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Stud_ID`),
  KEY `Section_ID` (`Section_ID`),
  CONSTRAINT `tbl_student_ibfk_1` FOREIGN KEY (`Section_ID`) REFERENCES `tbl_sections` (`Section_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_student
-- ----------------------------
INSERT INTO `tbl_student` VALUES ('#####-###', 'aga', 'gaga', 'gaga', '1', null, null);
INSERT INTO `tbl_student` VALUES ('000000000', 'Ortiz', 'Patricia', null, '1', null, null);
INSERT INTO `tbl_student` VALUES ('101010101', 'Balabis', 'Joyce', 'Mir', '1', null, null);
INSERT INTO `tbl_student` VALUES ('123123123', 'Okura', 'Ryota', 'Borja', '1', null, null);

-- ----------------------------
-- Table structure for tbl_subject
-- ----------------------------
DROP TABLE IF EXISTS `tbl_subject`;
CREATE TABLE `tbl_subject` (
  `Subject_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Subject_Code` varchar(255) DEFAULT NULL,
  `Subject_Name` varchar(25) DEFAULT NULL,
  `Year` varchar(25) DEFAULT NULL,
  `CourseID` varchar(9) DEFAULT NULL,
  PRIMARY KEY (`Subject_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbl_subject
-- ----------------------------
INSERT INTO `tbl_subject` VALUES ('1', null, 'Oral Communication', null, null);
INSERT INTO `tbl_subject` VALUES ('2', null, 'Earth & Life Science', null, null);
INSERT INTO `tbl_subject` VALUES ('3', null, 'Earth Science', null, null);
INSERT INTO `tbl_subject` VALUES ('4', null, 'Literature', null, null);
INSERT INTO `tbl_subject` VALUES ('5', null, 'Multimedia', null, null);
INSERT INTO `tbl_subject` VALUES ('6', null, 'Programming', null, null);
INSERT INTO `tbl_subject` VALUES ('7', null, 'Animation', null, null);
INSERT INTO `tbl_subject` VALUES ('8', null, '21st Century', null, null);
INSERT INTO `tbl_subject` VALUES ('9', null, 'Physical Education', null, null);
INSERT INTO `tbl_subject` VALUES ('10', null, 'Business Math', null, null);
INSERT INTO `tbl_subject` VALUES ('11', null, 'General Math', null, null);
INSERT INTO `tbl_subject` VALUES ('12', null, 'Pre-Calculus', null, null);
INSERT INTO `tbl_subject` VALUES ('14', null, 'Marvin\'s subject', null, null);
INSERT INTO `tbl_subject` VALUES ('15', null, 'ffdd, vvvv\"', null, null);

-- ----------------------------
-- Table structure for tbl_teachers
-- ----------------------------
DROP TABLE IF EXISTS `tbl_teachers`;
CREATE TABLE `tbl_teachers` (
  `Teacher_Id` varchar(9) NOT NULL,
  `LastName` varchar(25) NOT NULL,
  `FirstName` varchar(25) NOT NULL,
  `MiddleName` varchar(255) DEFAULT NULL,
  `Avatar` varchar(255) DEFAULT NULL,
  `Status` varchar(10) NOT NULL,
  PRIMARY KEY (`Teacher_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of tbl_teachers
-- ----------------------------
INSERT INTO `tbl_teachers` VALUES ('202020', 'balabis', 'joyce', 'm', null, '');
INSERT INTO `tbl_teachers` VALUES ('303030', 'albania', 'eman', 'l', null, '');

-- ----------------------------
-- View structure for vw_studentinfo
-- ----------------------------
DROP VIEW IF EXISTS `vw_studentinfo`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vw_studentinfo` AS SELECT
tbl_student.Stud_ID,
tbl_student.LastName,
tbl_student.FirstName,
tbl_student.MiddleName,
tbl_sections.Section,
tbl_course.Course,
tbl_sections.`Year`
FROM
tbl_student
INNER JOIN tbl_sections ON tbl_student.Section_ID = tbl_sections.Section_ID
INNER JOIN tbl_course ON tbl_sections.Course_ID = tbl_course.CourseID ;
