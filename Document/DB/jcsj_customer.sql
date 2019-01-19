/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2019-01-19 18:38:19
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `jcsj_customer`
-- ----------------------------
DROP TABLE IF EXISTS `jcsj_customer`;
CREATE TABLE `jcsj_customer` (
  `ID` varchar(50) NOT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `Image` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `CARDID` varchar(20) DEFAULT NULL,
  `SEX` varchar(50) DEFAULT NULL,
  `AGE` varchar(50) DEFAULT NULL,
  `TEL` varchar(50) DEFAULT NULL,
  `INDATE` varchar(50) DEFAULT NULL,
  `OUTDATE` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jcsj_customer
-- ----------------------------
INSERT INTO `jcsj_customer` VALUES ('1f292d61-0a02-439a-a56b-c3f2b5f98f28', '王力宏', null, '231085198702102222', '男', '77', '13516762676', '2018-12-12', null);
INSERT INTO `jcsj_customer` VALUES ('ec4e731c-80df-426a-a945-aaa307e394c2', '张贝贝', null, '231085198702102911', '男', '77', '13516762676', '2018-12-12', null);
