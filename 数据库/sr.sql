/*
 Navicat MySQL Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 80022
 Source Host           : localhost:3306
 Source Schema         : sr

 Target Server Type    : MySQL
 Target Server Version : 80022
 File Encoding         : 65001

 Date: 27/06/2021 13:34:58
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sr_admin
-- ----------------------------
DROP TABLE IF EXISTS `sr_admin`;
CREATE TABLE `sr_admin`  (
  `Password` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `JobNumber` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '工号',
  `ID` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '身份证号',
  `College` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '学院',
  `Type` int NOT NULL COMMENT '0表示院级管理员，1表示全局管理员',
  `Phone` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系号码',
  PRIMARY KEY (`JobNumber`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_admin
-- ----------------------------
INSERT INTO `sr_admin` VALUES ('222', '单允怡', '111', '120105200008085725', '管理学院', 0, '17612296333');

-- ----------------------------
-- Table structure for sr_apply
-- ----------------------------
DROP TABLE IF EXISTS `sr_apply`;
CREATE TABLE `sr_apply`  (
  `Identity` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Type` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '申请类型',
  `Detial` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '具体情况',
  `Reason` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '申请原因'
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_apply
-- ----------------------------

-- ----------------------------
-- Table structure for sr_class
-- ----------------------------
DROP TABLE IF EXISTS `sr_class`;
CREATE TABLE `sr_class`  (
  `College` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `MajorClass` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MajorClass`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_class
-- ----------------------------
INSERT INTO `sr_class` VALUES ('管理学院', '信管1807');
INSERT INTO `sr_class` VALUES ('管理学院', '信管1808');
INSERT INTO `sr_class` VALUES ('管理学院', '营销1801');

-- ----------------------------
-- Table structure for sr_good
-- ----------------------------
DROP TABLE IF EXISTS `sr_good`;
CREATE TABLE `sr_good`  (
  `GID` int NOT NULL AUTO_INCREMENT,
  `UserID` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `State` int NOT NULL COMMENT '是否填写完成1/0',
  `A1sleepTime` double(5, 3) NULL DEFAULT NULL,
  `A2upTime` double(5, 3) NULL DEFAULT NULL,
  `A3noonNap` double(5, 3) NULL DEFAULT NULL,
  `A4averageTime` double(5, 3) NULL DEFAULT NULL,
  `A5sleepQuality` double(5, 3) NULL DEFAULT NULL,
  `A6snore` double(5, 3) NULL DEFAULT NULL,
  `B1fitCold` double(5, 3) NULL DEFAULT NULL,
  `B2fitHot` double(5, 3) NULL DEFAULT NULL,
  `B3airCon` double(5, 3) NULL DEFAULT NULL,
  `B4minTem` double(5, 3) NULL DEFAULT NULL,
  `B5maxTem` double(5, 3) NULL DEFAULT NULL,
  `C1shower` double(5, 3) NULL DEFAULT NULL,
  `C2cleanDesk` double(5, 3) NULL DEFAULT NULL,
  `C3cleanRubbish` double(5, 3) NULL DEFAULT NULL,
  `C4makeBed` double(5, 3) NULL DEFAULT NULL,
  `C5washCloth` double(5, 3) NULL DEFAULT NULL,
  `D1smoke` double(5, 3) NULL DEFAULT NULL,
  `D2game` double(5, 3) NULL DEFAULT NULL,
  `D3volume` double(5, 3) NULL DEFAULT NULL,
  `D4express` double(5, 3) NULL DEFAULT NULL,
  `D5coconsum` double(5, 3) NULL DEFAULT NULL,
  `D6elec` double(5, 3) NULL DEFAULT NULL,
  `D7con` double(5, 3) NULL DEFAULT NULL,
  `D8unCon` double(5, 3) NULL DEFAULT NULL,
  `D9coat` double(5, 3) NULL DEFAULT NULL,
  `D10uWear` double(5, 3) NULL DEFAULT NULL,
  `D11maq` double(5, 3) NULL DEFAULT NULL,
  `D12outSide` double(5, 3) NULL DEFAULT NULL,
  `E1income` double(5, 3) NULL DEFAULT NULL,
  `E2perConsum` double(5, 3) NULL DEFAULT NULL,
  `F1sing` double(5, 3) NULL DEFAULT NULL,
  `F2musIns` double(5, 3) NULL DEFAULT NULL,
  `F3dance` double(5, 3) NULL DEFAULT NULL,
  `F4draw` double(5, 3) NULL DEFAULT NULL,
  `F5white` double(5, 3) NULL DEFAULT NULL,
  `F6ball` double(5, 3) NULL DEFAULT NULL,
  `F7tennis` double(5, 3) NULL DEFAULT NULL,
  `F8run` double(5, 3) NULL DEFAULT NULL,
  `F9bodyBuild` double(5, 3) NULL DEFAULT NULL,
  `F10yoga` double(5, 3) NULL DEFAULT NULL,
  `F11swim` double(5, 3) NULL DEFAULT NULL,
  `F12movie` double(5, 3) NULL DEFAULT NULL,
  `F13live` double(5, 3) NULL DEFAULT NULL,
  `F14claMusic` double(5, 3) NULL DEFAULT NULL,
  `F15idol` double(5, 3) NULL DEFAULT NULL,
  `F16ktv` double(5, 3) NULL DEFAULT NULL,
  `G1sexOrient` double(5, 3) NULL DEFAULT NULL,
  `G2noSingle` double(5, 3) NULL DEFAULT NULL,
  `G3inDisea` double(5, 3) NULL DEFAULT NULL,
  `G4family` double(5, 3) NULL DEFAULT NULL,
  `G5parent` double(5, 3) NULL DEFAULT NULL,
  `G6interact` double(5, 3) NULL DEFAULT NULL,
  PRIMARY KEY (`GID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_good
-- ----------------------------
INSERT INTO `sr_good` VALUES (12, '410323199907213521', 1, 6.000, 3.000, 3.000, 5.000, 2.000, 2.000, 1.000, 4.000, 2.000, 4.000, 5.000, 2.000, 4.000, 2.000, 2.000, 2.000, 1.000, 1.000, 1.000, 1.000, 2.000, 1.000, 1.000, 1.000, 1.000, 5.000, 4.000, 1.000, 2.000, 3.000, 3.000, 3.000, 2.000, 4.000, 5.000, 5.000, 1.000, 3.000, 2.000, 2.000, 3.000, 5.000, 3.000, 1.000, 2.000, 3.000, 2.000, 2.000, 2.000, 2.000, 2.000, 2.000);
INSERT INTO `sr_good` VALUES (13, '410323199907213523', 1, 2.000, 3.000, 4.000, 3.000, 4.000, 6.000, 7.000, 3.000, 4.000, 4.000, 4.000, 5.000, 3.000, 3.000, 3.000, 3.000, 3.000, 3.000, 4.000, 3.000, 2.000, 1.000, 3.000, 2.000, 5.000, 4.000, 5.000, 4.000, 3.000, 2.000, 1.000, 3.000, 4.000, 5.000, 3.000, 1.000, 2.000, 3.000, 4.000, 2.000, 3.000, 3.000, 2.000, 4.000, 3.000, 2.000, 2.000, 3.000, 3.000, 2.000, 1.000, 3.000);
INSERT INTO `sr_good` VALUES (14, '410323199907213522', 1, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 2.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000);
INSERT INTO `sr_good` VALUES (15, '411303200010230109', 1, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 3.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000);
INSERT INTO `sr_good` VALUES (16, '410323199907213524', 1, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 2.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 2.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 4.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 2.000);
INSERT INTO `sr_good` VALUES (17, '410323199907213525', 1, 4.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 3.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000);
INSERT INTO `sr_good` VALUES (18, '410323199907213526', 1, 1.000, 3.000, 2.000, 1.000, 2.000, 3.000, 7.000, 3.000, 4.000, 4.000, 4.000, 5.000, 3.000, 3.000, 3.000, 3.000, 3.000, 3.000, 4.000, 3.000, 2.000, 1.000, 3.000, 2.000, 5.000, 4.000, 5.000, 4.000, 3.000, 2.000, 1.000, 3.000, 4.000, 5.000, 3.000, 1.000, 2.000, 3.000, 4.000, 2.000, 3.000, 3.000, 2.000, 4.000, 3.000, 2.000, 2.000, 3.000, 3.000, 2.000, 1.000, 3.000);
INSERT INTO `sr_good` VALUES (19, '410323199907213527', 1, 3.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 2.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000, 4.000, 5.000, 1.000, 2.000, 3.000);
INSERT INTO `sr_good` VALUES (20, '410323199907213528', 1, 4.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 3.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000, 2.000, 4.000, 2.000, 3.000, 2.000, 3.000);
INSERT INTO `sr_good` VALUES (21, '410323199907213529', 1, 2.000, 2.000, 1.000, 1.000, 2.000, 3.000, 2.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 2.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 4.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 2.000);
INSERT INTO `sr_good` VALUES (22, '410323199907213510', 1, 2.000, 4.000, 3.000, 2.000, 1.000, 1.000, 1.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 2.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 4.000, 2.000, 2.000, 1.000, 3.000, 2.000, 5.000, 5.000, 4.000, 3.000, 3.000, 2.000, 6.000, 4.000, 3.000, 2.000);
INSERT INTO `sr_good` VALUES (23, '410323199907213511', 0, 1.000, 1.000, 1.000, 1.000, 1.000, 1.000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sr_good` VALUES (24, '410323199907213512', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sr_good_copy
-- ----------------------------
DROP TABLE IF EXISTS `sr_good_copy`;
CREATE TABLE `sr_good_copy`  (
  `GID` int NOT NULL AUTO_INCREMENT,
  `UserID` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `State` int NOT NULL COMMENT '是否填写完成1/0',
  `A1sleepTime` double(5, 3) NULL DEFAULT NULL,
  `A2upTime` double(5, 3) NULL DEFAULT NULL,
  `A3noonNap` double(5, 3) NULL DEFAULT NULL,
  `A4averageTime` double(5, 3) NULL DEFAULT NULL,
  `A5sleepQuality` double(5, 3) NULL DEFAULT NULL,
  `A6snore` double(5, 3) NULL DEFAULT NULL,
  `B1fitCold` double(5, 3) NULL DEFAULT NULL,
  `B2fitHot` double(5, 3) NULL DEFAULT NULL,
  `B3airCon` double(5, 3) NULL DEFAULT NULL,
  `B4minTem` double(5, 3) NULL DEFAULT NULL,
  `B5maxTem` double(5, 3) NULL DEFAULT NULL,
  `C1shower` double(5, 3) NULL DEFAULT NULL,
  `C2cleanDesk` double(5, 3) NULL DEFAULT NULL,
  `C3cleanRubbish` double(5, 3) NULL DEFAULT NULL,
  `C4makeBed` double(5, 3) NULL DEFAULT NULL,
  `C5washCloth` double(5, 3) NULL DEFAULT NULL,
  `D1smoke` double(5, 3) NULL DEFAULT NULL,
  `D2game` double(5, 3) NULL DEFAULT NULL,
  `D3volume` double(5, 3) NULL DEFAULT NULL,
  `D4express` double(5, 3) NULL DEFAULT NULL,
  `D5coConsum` double(5, 3) NULL DEFAULT NULL,
  `D6elec` double(5, 3) NULL DEFAULT NULL,
  `D7con` double(5, 3) NULL DEFAULT NULL,
  `D8unCon` double(5, 3) NULL DEFAULT NULL,
  `D9coat` double(5, 3) NULL DEFAULT NULL,
  `D10uWear` double(5, 3) NULL DEFAULT NULL,
  `D11maq` double(5, 3) NULL DEFAULT NULL,
  `D12outSide` double(5, 3) NULL DEFAULT NULL,
  `E1income` double(5, 3) NULL DEFAULT NULL,
  `E2perConsum` double(5, 3) NULL DEFAULT NULL,
  `F1sing` double(5, 3) NULL DEFAULT NULL,
  `F2musIns` double(5, 3) NULL DEFAULT NULL,
  `F3dance` double(5, 3) NULL DEFAULT NULL,
  `F4draw` double(5, 3) NULL DEFAULT NULL,
  `F5white` double(5, 3) NULL DEFAULT NULL,
  `F6ball` double(5, 3) NULL DEFAULT NULL,
  `F7tennis` double(5, 3) NULL DEFAULT NULL,
  `F8run` double(5, 3) NULL DEFAULT NULL,
  `F9bodyBuild` double(5, 3) NULL DEFAULT NULL,
  `F10yoga` double(5, 3) NULL DEFAULT NULL,
  `F11swim` double(5, 3) NULL DEFAULT NULL,
  `F12movie` double(5, 3) NULL DEFAULT NULL,
  `F13live` double(5, 3) NULL DEFAULT NULL,
  `F14claMusic` double(5, 3) NULL DEFAULT NULL,
  `F15idol` double(5, 3) NULL DEFAULT NULL,
  `F16ktv` double(5, 3) NULL DEFAULT NULL,
  `G1sexOrient` double(5, 3) NULL DEFAULT NULL,
  `G2noSingle` double(5, 3) NULL DEFAULT NULL,
  `G3inDisea` double(5, 3) NULL DEFAULT NULL,
  `G4family` double(5, 3) NULL DEFAULT NULL,
  `G5parent` double(5, 3) NULL DEFAULT NULL,
  `G6interact` double(5, 3) NULL DEFAULT NULL,
  PRIMARY KEY (`GID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 101 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_good_copy
-- ----------------------------

-- ----------------------------
-- Table structure for sr_message
-- ----------------------------
DROP TABLE IF EXISTS `sr_message`;
CREATE TABLE `sr_message`  (
  `MID` int NOT NULL AUTO_INCREMENT,
  `Send` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Accept` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Read` int NULL DEFAULT NULL COMMENT '0表示未读1表示已读',
  `Content` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Time` datetime NULL DEFAULT NULL,
  `reContent` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Delect` int NULL DEFAULT NULL COMMENT '1表示显示，0表示表面删除',
  PRIMARY KEY (`MID`, `Accept`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 62 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_message
-- ----------------------------
INSERT INTO `sr_message` VALUES (1, '120105200008085725', '111', 1, '请尽快填写信息', '2021-06-06 11:24:01', '', NULL, 0);
INSERT INTO `sr_message` VALUES (2, '120105200008085725', '111', 1, '请尽快填写信息', '2021-06-06 22:27:32', '', NULL, 0);
INSERT INTO `sr_message` VALUES (3, '410323199907213521', '111', 1, '调换原因：1111  具体内容：1111', '2021-06-07 09:36:08', NULL, '床位调换', 0);
INSERT INTO `sr_message` VALUES (4, '120105200008085725', '111', 1, '请尽快填写信息', '2021-06-07 14:25:07', NULL, NULL, 0);
INSERT INTO `sr_message` VALUES (5, '120105200008085725', '111', 1, '请尽快填写信息', '2021-06-07 18:15:25', NULL, NULL, 0);
INSERT INTO `sr_message` VALUES (6, '120105200008085725', '111', 0, '请尽快填写信息', '2021-06-07 18:20:01', NULL, '1', 0);
INSERT INTO `sr_message` VALUES (7, '410323199907213522', '111', NULL, NULL, '2021-06-21 12:47:08', NULL, NULL, NULL);
INSERT INTO `sr_message` VALUES (40, '111', '410323199907213521', 1, '好的', '2021-06-14 08:41:06', '1', NULL, 0);
INSERT INTO `sr_message` VALUES (41, '410323199907213521', '111', 1, '知道了', '2021-06-14 08:41:06', '好的，知道了！', NULL, 0);
INSERT INTO `sr_message` VALUES (42, '111', '410323199907213521', 1, '收到', '2021-06-18 21:00:26', '', NULL, 1);
INSERT INTO `sr_message` VALUES (43, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便  具体内容：我想要调换到1楼', '2021-06-18 17:50:22', '好的，知道了！', '楼层调换', 0);
INSERT INTO `sr_message` VALUES (44, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便 具体内容：陈', '2021-06-18 18:13:28', NULL, '楼层调换', 0);
INSERT INTO `sr_message` VALUES (45, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便   具体内容：陈', '2021-06-18 18:13:30', '12121', '楼层调换', 1);
INSERT INTO `sr_message` VALUES (46, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便   具体内容：陈', '2021-06-18 18:13:30', '111', '楼层调换', 1);
INSERT INTO `sr_message` VALUES (47, '410323199907213521', '111', 1, '调换原因： 我的腿脚不方便     具体内容：陈', '2021-06-18 18:13:30', NULL, '楼层调换', 1);
INSERT INTO `sr_message` VALUES (48, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便 具体内容：希望调换到下铺', '2021-06-18 18:40:40', NULL, '床位调换', 1);
INSERT INTO `sr_message` VALUES (49, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便 具体内容：陈', '2021-06-18 18:44:22', NULL, '楼层调换', 1);
INSERT INTO `sr_message` VALUES (50, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便   具体内容：陈', '2021-06-18 18:49:34', NULL, '床位调换', 1);
INSERT INTO `sr_message` VALUES (51, '410323199907213521', '111', 1, '调换原因：我的腿脚不方便   具体内容：陈', '2021-06-18 18:54:01', NULL, '床位调换', 1);
INSERT INTO `sr_message` VALUES (52, '620521199901122685', '111', 0, '调换原因：我的腿脚不方便   具体内容：TTTT', '2021-06-18 22:15:09', NULL, '楼层调换', 0);
INSERT INTO `sr_message` VALUES (53, '411303200010230109', '111', 1, '调换原因：我的腿脚不方便    具体内容：q', '2021-06-19 06:52:58', '', '楼层调换', 1);
INSERT INTO `sr_message` VALUES (54, '411303200010230109', '111', 1, '调换原因：我的腿脚不方便  具体内容：1', '2021-06-19 06:56:53', NULL, '床位调换', 0);
INSERT INTO `sr_message` VALUES (55, '111', '410323199907213521', 0, NULL, '2021-06-21 12:47:16', NULL, NULL, NULL);
INSERT INTO `sr_message` VALUES (56, '111', '410323199907213521', 1, NULL, '2021-06-21 12:47:20', NULL, NULL, 0);
INSERT INTO `sr_message` VALUES (57, '111', '410323199907213521', 0, NULL, '2021-06-21 12:47:23', NULL, NULL, 0);
INSERT INTO `sr_message` VALUES (58, '111', '410323199907213521', 1, NULL, '2021-06-21 12:47:25', '626', NULL, 1);
INSERT INTO `sr_message` VALUES (59, '111', '410323199907213521', 1, NULL, '2021-06-21 12:47:27', NULL, NULL, 1);
INSERT INTO `sr_message` VALUES (60, '410323199907213521', '111', 1, '调换原因：腿脚不方便  具体内容：希望可以调换到一楼', '2021-06-21 13:05:29', NULL, '楼层调换', 1);
INSERT INTO `sr_message` VALUES (61, '111', '410323199907213511', 0, '请尽快填写信息', '2021-06-21 13:25:59', NULL, NULL, 0);
INSERT INTO `sr_message` VALUES (62, '111', '410323199907213511', 0, '请尽快填写信息', '2021-06-21 14:33:13', NULL, NULL, 0);

-- ----------------------------
-- Table structure for sr_resultboy
-- ----------------------------
DROP TABLE IF EXISTS `sr_resultboy`;
CREATE TABLE `sr_resultboy`  (
  `One` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Two` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Three` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Four` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Five` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Six` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `RID` int NOT NULL AUTO_INCREMENT,
  `Class` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `State` int NULL DEFAULT NULL COMMENT '0表示未发布，1表示发布',
  `Building` int NULL DEFAULT NULL COMMENT '所在楼宇',
  `Room` int NULL DEFAULT NULL COMMENT '寝室号',
  PRIMARY KEY (`RID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 40 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_resultboy
-- ----------------------------
INSERT INTO `sr_resultboy` VALUES ('410323199907213526', '410323199907213527', '410323199907213529', '410323199907213510', NULL, NULL, 39, '信管1808', 0, 0, 0);
INSERT INTO `sr_resultboy` VALUES ('410323199907213528', '无', '无', '无', NULL, NULL, 40, '信管1808', 0, 0, 0);

-- ----------------------------
-- Table structure for sr_resultgirl
-- ----------------------------
DROP TABLE IF EXISTS `sr_resultgirl`;
CREATE TABLE `sr_resultgirl`  (
  `One` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Two` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Three` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Four` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Five` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Six` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `RID` int NOT NULL AUTO_INCREMENT,
  `Class` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `State` int NULL DEFAULT NULL COMMENT '0表示未发布，1表示发布',
  `Building` int NULL DEFAULT NULL,
  `Room` int NULL DEFAULT NULL,
  PRIMARY KEY (`RID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 35 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_resultgirl
-- ----------------------------
INSERT INTO `sr_resultgirl` VALUES ('410323199907213521', '410323199907213525', '410323199907213524', '411303200010230109', NULL, NULL, 34, '信管1808', 0, 0, 0);
INSERT INTO `sr_resultgirl` VALUES ('410323199907213523', '410323199907213522', '无', '无', NULL, NULL, 35, '信管1808', 0, 0, 0);

-- ----------------------------
-- Table structure for sr_user
-- ----------------------------
DROP TABLE IF EXISTS `sr_user`;
CREATE TABLE `sr_user`  (
  `Identity` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '身份证号',
  `Email` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '此学生所绑定的邮箱',
  `Password` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '姓名',
  `StudentNumber` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '学号',
  `College` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '学院',
  `Major` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '专业及班级',
  `Class` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Sex` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '性别',
  `Phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系方式',
  PRIMARY KEY (`Identity`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sr_user
-- ----------------------------
INSERT INTO `sr_user` VALUES ('410323199907213510', '10@qq.com', NULL, 'Lay', NULL, '管理学院', '信管1808', '1808', '男', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213511', '11@qq.com', '111', 'Mi', '1830100006', '管理学院', '信管1807', NULL, '男', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213512', '12@qq.com', NULL, 'Mali', '1830100007', '管理学院', '信管1807', NULL, '男', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213521', '3510639310@qq.com', '222', '陈银迪', '1830130230', '管理学院', '信管1808', '1808', '女', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213522', '2@qq.com', NULL, 'Lydia', '1830130330', '管理学院', '信管1808', '1808', '女', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213523', '3@qq.com', NULL, 'Ming', '1830130003', '管理学院', '信管1808', '1808', '女', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213524', '4@qq.com', NULL, '郭苗苗', '1830130331', '管理学院', '信管1808', '1808', '女', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213525', '5@qq.com', NULL, 'Li', NULL, '管理学院', '信管1808', '1808', '女', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213526', '6@qq.com', NULL, 'Qiang', NULL, '管理学院', '信管1808', '1808', '男', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213527', '7@qq.com', NULL, 'Ke', NULL, '管理学院', '信管1808', '1808', '男', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213528', '8@qq.com', NULL, 'Wei', NULL, '管理学院', '信管1808', '1808', '男', NULL);
INSERT INTO `sr_user` VALUES ('410323199907213529', '9@qq.com', '', 'Lan', '', '管理学院', '信管1808', '1808', '男', '');
INSERT INTO `sr_user` VALUES ('411303200010230109', 'Icy0926@163.com', '111', '陈梦琪', '1830130329', '管理学院', '信管1808', '1808', '女', NULL);

SET FOREIGN_KEY_CHECKS = 1;
