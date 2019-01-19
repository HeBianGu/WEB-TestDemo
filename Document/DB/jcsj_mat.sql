/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2019-01-19 18:38:25
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `jcsj_mat`
-- ----------------------------
DROP TABLE IF EXISTS `jcsj_mat`;
CREATE TABLE `jcsj_mat` (
  `ID` varchar(50) NOT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `CODE` varchar(100) DEFAULT NULL,
  `SUPPLIER` varchar(100) DEFAULT NULL,
  `CDATE` varchar(100) DEFAULT NULL,
  `UDATE` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jcsj_mat
-- ----------------------------
