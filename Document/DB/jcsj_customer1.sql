/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2019-01-19 17:42:35
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `jcsj_customer`
-- ----------------------------
DROP TABLE IF EXISTS `jcsj_customer`;
CREATE TABLE `jcsj_customer` (
  `ID` varchar(50) NOT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `Image` text CHARACTER DEFAULT NULL,
  `CARDID` varchar(20) DEFAULT NULL,
  `SEX` varchar(50) DEFAULT NULL,
  `AGE` varchar(50) DEFAULT NULL,
  `TEL` varchar(50) DEFAULT NULL,
  `INDATE` varchar(50) DEFAULT NULL,
  `OUTDATE` varchar(50) DEFAULT NULL,
  `CREATEDATE` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jcsj_customer
-- ----------------------------
