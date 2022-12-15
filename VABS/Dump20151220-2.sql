CREATE DATABASE  IF NOT EXISTS `barcode_data` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `barcode_data`;
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
  `Sl` int(255) NOT NULL AUTO_INCREMENT,
  `Product_Name` char(255) DEFAULT NULL,
  `Batch_number` char(255) DEFAULT NULL,
  `Date` char(255) DEFAULT NULL,
  `Start_time` char(255) DEFAULT NULL,
  `End_time` char(255) DEFAULT NULL,
  `Total_inspected` int(70) DEFAULT NULL,
  `Total_rejected` int(70) DEFAULT NULL,
  `User` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `barcode_results`
--

LOCK TABLES `barcode_results` WRITE;
/*!40000 ALTER TABLE `barcode_results` DISABLE KEYS */;
/*!40000 ALTER TABLE `barcode_results` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eid`
--

DROP TABLE IF EXISTS `eid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `eid` (
  `Sl` int(255) NOT NULL AUTO_INCREMENT,
  `Name` char(255) DEFAULT NULL,
  `ID` char(255) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Admin` char(255) DEFAULT NULL,
  PRIMARY KEY (`Sl`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eid`
--

LOCK TABLES `eid` WRITE;
/*!40000 ALTER TABLE `eid` DISABLE KEYS */;
INSERT INTO `eid` VALUES (1,'Admin','008','1234','Y');
/*!40000 ALTER TABLE `eid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_infos`
--

DROP TABLE IF EXISTS `product_infos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_infos` (
  `Sl` int(255) NOT NULL AUTO_INCREMENT,
  `Product_Name` char(255) DEFAULT NULL,
  `Barcode_number` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_infos`
--

LOCK TABLES `product_infos` WRITE;
/*!40000 ALTER TABLE `product_infos` DISABLE KEYS */;
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

-- Dump completed on 2015-12-20 20:33:44
