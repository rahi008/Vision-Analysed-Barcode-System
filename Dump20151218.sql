-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: barcode_data
-- ------------------------------------------------------
-- Server version	5.7.9-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `barcode_results`
--

DROP TABLE IF EXISTS `barcode_results`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `barcode_results` (
  `Sl` int(11) NOT NULL AUTO_INCREMENT,
  `Product_Name` char(255) DEFAULT NULL,
  `Batch_number` char(255) DEFAULT NULL,
  `Date` varchar(255) DEFAULT NULL,
  `Start_time` char(255) DEFAULT NULL,
  `End_time` char(255) DEFAULT NULL,
  `Total_inspected` int(70) DEFAULT NULL,
  `Total_rejected` int(70) DEFAULT NULL,
  `User` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Sl`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `barcode_results`
--

LOCK TABLES `barcode_results` WRITE;
/*!40000 ALTER TABLE `barcode_results` DISABLE KEYS */;
INSERT INTO `barcode_results` VALUES (33,'Robotics & Microcontroller','213165',NULL,'12/16/2015 5:16:57 PM','12/16/2015 5:17:09 PM',8,0,NULL),(34,'Shokoler jonno podarthobiddya','4861',NULL,'12/16/2015 5:18:10 PM','12/16/2015 5:18:37 PM',6,6,NULL),(35,'Shokoler jonno podarthobiddya','64894',NULL,'12/16/2015 5:59:18 PM','12/16/2015 5:59:45 PM',10,10,NULL),(36,'Shokoler jonno podarthobiddya','12',NULL,NULL,NULL,NULL,NULL,NULL),(37,'tasty','2','12/16/2015','07:52 PM','07:55 PM',0,0,NULL),(38,'Robotics & Microcontroller','568','12/16/2015','12/16/2015 9:12:58 PM',NULL,NULL,NULL,NULL),(39,'Robotics & Microcontroller','11','12/16/2015','9:18 PM',NULL,NULL,NULL,NULL),(40,'Shokoler jonno podarthobiddya','11212','12/16/2015','9:15 PM','9:18 PM',0,0,NULL),(41,'Shokoler jonno podarthobiddya','656','12/16/2015','11:10 PM','11:18 PM',0,0,'008'),(42,'Shokoler jonno podarthobiddya','002','12/16/2015','11:59 PM',NULL,NULL,NULL,'001'),(43,'Shokoler jonno podarthobiddya','6546','12/17/2015','1:02 AM',NULL,NULL,NULL,'008'),(44,'Shokoler jonno podarthobiddya','546','12/18/2015','7:01 PM','7:01 PM',0,0,'008');
/*!40000 ALTER TABLE `barcode_results` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eid`
--

DROP TABLE IF EXISTS `eid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `eid` (
  `Sl` int(70) NOT NULL AUTO_INCREMENT,
  `Name` char(255) DEFAULT NULL,
  `ID` char(255) DEFAULT NULL,
  `Admin` char(255) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Sl`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eid`
--

LOCK TABLES `eid` WRITE;
/*!40000 ALTER TABLE `eid` DISABLE KEYS */;
INSERT INTO `eid` VALUES (1,'Admin','008','Y','1234'),(2,'Users','001','N','4321');
/*!40000 ALTER TABLE `eid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_infos`
--

DROP TABLE IF EXISTS `product_infos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_infos` (
  `Sl` int(11) NOT NULL AUTO_INCREMENT,
  `Product_Name` char(255) DEFAULT NULL,
  `Barcode_number` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sl`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_infos`
--

LOCK TABLES `product_infos` WRITE;
/*!40000 ALTER TABLE `product_infos` DISABLE KEYS */;
INSERT INTO `product_infos` VALUES (1,'Robotics & Microcontroller','9789848980927'),(2,'Shokoler jonno podarthobiddya','9789847840116'),(3,'tasty','123456789'),(4,'test2','9876543211234'),(5,'bangladeshi','123156484566');
/*!40000 ALTER TABLE `product_infos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'barcode_data'
--

--
-- Dumping routines for database 'barcode_data'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-12-18 19:09:34
