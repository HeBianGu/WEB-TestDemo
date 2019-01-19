/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2019-01-19 18:38:10
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `jcsj_bed`
-- ----------------------------
DROP TABLE IF EXISTS `jcsj_bed`;
CREATE TABLE `jcsj_bed` (
  `ID` varchar(50) NOT NULL,
  `CODE` varchar(50) DEFAULT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `CDATE` varchar(100) DEFAULT NULL,
  `UDATE` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jcsj_bed
-- ----------------------------
INSERT INTO `jcsj_bed` VALUES ('0981ef4b-dc98-4470-bd19-60e7d3ef1e73', '1-03', '床位三', '2019-01-19', null);
INSERT INTO `jcsj_bed` VALUES ('30c985d5-9b9f-4e05-9e85-373e6b6afa21', '1-01', '床位一', '2019-01-19', null);
INSERT INTO `jcsj_bed` VALUES ('6df36b52-36a5-435e-8abd-115fbe8902a2', '1-02', '床位二', '2019-01-19', null);
INSERT INTO `jcsj_bed` VALUES ('d07c1aed-cf8c-4b39-a635-a5f0fb642669', '1-01', '床位一', '2019-01-19', null);
