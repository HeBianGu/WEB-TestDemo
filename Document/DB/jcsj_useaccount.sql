/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-12-29 17:55:23
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `jcsj_useaccount`
-- ----------------------------
DROP TABLE IF EXISTS `jcsj_useaccount`;
CREATE TABLE `jcsj_useaccount` (
  `ID` varchar(50) NOT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `PASSWORD` varchar(100) DEFAULT NULL,
  `STATE` varchar(20) DEFAULT NULL,
  `TYPE` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jcsj_useaccount
-- ----------------------------
INSERT INTO `jcsj_useaccount` VALUES ('1', 'admin', '111111', '1', '1');
INSERT INTO `jcsj_useaccount` VALUES ('2', 'hebiangu', '111111', '0', '2');
INSERT INTO `jcsj_useaccount` VALUES ('86b110e3-9a9f-4fd4-a034-fec21c8babc1', 'test', '111111', '1', '2');
