/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2019-01-19 18:38:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `jksj_monitor`
-- ----------------------------
DROP TABLE IF EXISTS `jksj_monitor`;
CREATE TABLE `jksj_monitor` (
  `ID` varchar(50) NOT NULL,
  `BEDID` varchar(100) DEFAULT NULL,
  `MATID` varchar(100) DEFAULT NULL,
  `CUSTOMID` varchar(100) DEFAULT NULL,
  `TIMEPLANID` varchar(100) DEFAULT NULL,
  `HEARTID` varchar(100) DEFAULT NULL,
  `BREATHID` varchar(100) DEFAULT NULL,
  `NURSEID` varchar(100) DEFAULT NULL,
  `CDATE` varchar(100) DEFAULT NULL,
  `UDATE` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jksj_monitor
-- ----------------------------
