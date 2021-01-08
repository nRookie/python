# -*- coding: utf-8 -*-

################################################################################
## Form generated from reading UI file 'MainWindow1YS.ui'
##
## Created by: Qt User Interface Compiler version 5.15.0
##
## WARNING! All changes made in this file will be lost when recompiling UI file!
################################################################################

from PySide2.QtCore import (QCoreApplication, QDate, QDateTime, QMetaObject,
    QObject, QPoint, QRect, QSize, QTime, QUrl, Qt)
from PySide2.QtGui import (QBrush, QColor, QConicalGradient, QCursor, QFont,
    QFontDatabase, QIcon, QKeySequence, QLinearGradient, QPalette, QPainter,
    QPixmap, QRadialGradient)
from PySide2.QtWidgets import *


class Ui_MainWindow1YS(object):
    def setupUi(self, MainWindow1YS):
        if not MainWindow1YS.objectName():
            MainWindow1YS.setObjectName(u"MainWindow1YS")
        MainWindow1YS.resize(1071, 613)
        self.actionAbout = QAction(MainWindow1YS)
        self.actionAbout.setObjectName(u"actionAbout")
        self.actionUpdate = QAction(MainWindow1YS)
        self.actionUpdate.setObjectName(u"actionUpdate")
        self.actionType1YS_1SS = QAction(MainWindow1YS)
        self.actionType1YS_1SS.setObjectName(u"actionType1YS_1SS")
        self.actionType2AB = QAction(MainWindow1YS)
        self.actionType2AB.setObjectName(u"actionType2AB")
        self.centralwidget = QWidget(MainWindow1YS)
        self.centralwidget.setObjectName(u"centralwidget")
        self.ModuleCfg = QGroupBox(self.centralwidget)
        self.ModuleCfg.setObjectName(u"ModuleCfg")
        self.ModuleCfg.setGeometry(QRect(0, -1, 1061, 81))
        self.interfase_select = QComboBox(self.ModuleCfg)
        self.interfase_select.addItem("")
        self.interfase_select.setObjectName(u"interfase_select")
        self.interfase_select.setGeometry(QRect(20, 40, 141, 22))
        self.label = QLabel(self.ModuleCfg)
        self.label.setObjectName(u"label")
        self.label.setGeometry(QRect(20, 20, 71, 16))
        font = QFont()
        font.setPointSize(8)
        self.label.setFont(font)
        self.ModuleLog = QGroupBox(self.centralwidget)
        self.ModuleLog.setObjectName(u"ModuleLog")
        self.ModuleLog.setGeometry(QRect(0, 420, 1061, 131))
        self.log_chk = QCheckBox(self.ModuleLog)
        self.log_chk.setObjectName(u"log_chk")
        self.log_chk.setGeometry(QRect(10, 20, 101, 20))
        self.log_chk.setFont(font)
        self.log_txt = QTextEdit(self.ModuleLog)
        self.log_txt.setObjectName(u"log_txt")
        self.log_txt.setGeometry(QRect(10, 40, 1041, 81))
        self.status_label = QLabel(self.centralwidget)
        self.status_label.setObjectName(u"status_label")
        self.status_label.setGeometry(QRect(10, 560, 35, 16))
        self.status_label.setFont(font)
        self.version_label = QLabel(self.centralwidget)
        self.version_label.setObjectName(u"version_label")
        self.version_label.setGeometry(QRect(70, 560, 81, 16))
        self.version_label.setFont(font)
        self.dw_progress = QProgressBar(self.centralwidget)
        self.dw_progress.setObjectName(u"dw_progress")
        self.dw_progress.setGeometry(QRect(170, 560, 771, 16))
        self.dw_progress.setFont(font)
        self.dw_progress.setValue(0)
        self.timecost_label = QLabel(self.centralwidget)
        self.timecost_label.setObjectName(u"timecost_label")
        self.timecost_label.setGeometry(QRect(960, 560, 81, 16))
        self.timecost_label.setFont(font)
        self.ModuleOperation = QTabWidget(self.centralwidget)
        self.ModuleOperation.setObjectName(u"ModuleOperation")
        self.ModuleOperation.setGeometry(QRect(0, 80, 1061, 341))
        font1 = QFont()
        font1.setPointSize(16)
        self.ModuleOperation.setFont(font1)
        self.Info = QWidget()
        self.Info.setObjectName(u"Info")
        self.info_txt = QTextEdit(self.Info)
        self.info_txt.setObjectName(u"info_txt")
        self.info_txt.setEnabled(False)
        self.info_txt.setGeometry(QRect(10, 10, 501, 281))
        self.info_label = QLabel(self.Info)
        self.info_label.setObjectName(u"info_label")
        self.info_label.setGeometry(QRect(540, 10, 501, 291))
        self.info_label.setPixmap(QPixmap(u"figures/type1ss_evb.jpg"))
        self.ModuleOperation.addTab(self.Info, "")
        self.Program = QWidget()
        self.Program.setObjectName(u"Program")
        self.ModuleOperation.addTab(self.Program, "")
        self.Erase = QWidget()
        self.Erase.setObjectName(u"Erase")
        self.Erase.setEnabled(False)
        self.ModuleOperation.addTab(self.Erase, "")
        self.Read = QWidget()
        self.Read.setObjectName(u"Read")
        self.ModuleOperation.addTab(self.Read, "")
        MainWindow1YS.setCentralWidget(self.centralwidget)
        self.menubar = QMenuBar(MainWindow1YS)
        self.menubar.setObjectName(u"menubar")
        self.menubar.setGeometry(QRect(0, 0, 1071, 26))
        self.menuSelect = QMenu(self.menubar)
        self.menuSelect.setObjectName(u"menuSelect")
        self.menuAbout = QMenu(self.menubar)
        self.menuAbout.setObjectName(u"menuAbout")
        MainWindow1YS.setMenuBar(self.menubar)

        self.menubar.addAction(self.menuSelect.menuAction())
        self.menubar.addAction(self.menuAbout.menuAction())
        self.menuSelect.addAction(self.actionType1YS_1SS)
        self.menuSelect.addAction(self.actionType2AB)
        self.menuAbout.addAction(self.actionAbout)
        self.menuAbout.addAction(self.actionUpdate)

        self.retranslateUi(MainWindow1YS)

        self.ModuleOperation.setCurrentIndex(3)


        QMetaObject.connectSlotsByName(MainWindow1YS)
    # setupUi

    def retranslateUi(self, MainWindow1YS):
        MainWindow1YS.setWindowTitle(QCoreApplication.translate("MainWindow1YS", u"Murata Image\\Firmware Download Tool", None))
        self.actionAbout.setText(QCoreApplication.translate("MainWindow1YS", u"About", None))
        self.actionUpdate.setText(QCoreApplication.translate("MainWindow1YS", u"Update", None))
        self.actionType1YS_1SS.setText(QCoreApplication.translate("MainWindow1YS", u"Type1YS/1SS", None))
        self.actionType2AB.setText(QCoreApplication.translate("MainWindow1YS", u"Type2AB", None))
        self.ModuleCfg.setTitle(QCoreApplication.translate("MainWindow1YS", u"Cfg", None))
        self.interfase_select.setItemText(0, QCoreApplication.translate("MainWindow1YS", u"COM1", None))

        self.label.setText(QCoreApplication.translate("MainWindow1YS", u"Interface", None))
        self.ModuleLog.setTitle(QCoreApplication.translate("MainWindow1YS", u"Log", None))
        self.log_chk.setText(QCoreApplication.translate("MainWindow1YS", u"Log Enable", None))
        self.status_label.setText(QCoreApplication.translate("MainWindow1YS", u"Ready", None))
        self.version_label.setText(QCoreApplication.translate("MainWindow1YS", u"Version: 0.0.1", None))
        self.timecost_label.setText(QCoreApplication.translate("MainWindow1YS", u"00:00:00", None))
        self.info_txt.setHtml(QCoreApplication.translate("MainWindow1YS", u"<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:'MS Shell Dlg 2'; font-size:16pt; font-weight:400; font-style:normal;\">\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\"><span style=\" font-size:8pt;\">The Type1YS/1SS EVK is an evaluation and application development kit for the Type1SS module. It includes 3 micro-USB ports, NBIoT board antenna, 1 micro SIM slot, 1 power button and 1 reset button, SMA connector for RF testing, Pads for accessing Type1SS IO pins<br /><br />Quick Start Guide: See Quick Start Guide<br /><br />Regarding more details, Please check Type 1SS Support Site on my Murata<br /><br />Download Type 1SS Support Site Access Guide<br /><br />*my Murata An exclusive website with rich contents <br />for regis"
                        "tered members only. Conditions apply. User Policy</span></p></body></html>", None))
        self.info_label.setText("")
        self.ModuleOperation.setTabText(self.ModuleOperation.indexOf(self.Info), QCoreApplication.translate("MainWindow1YS", u"Info", None))
        self.ModuleOperation.setTabText(self.ModuleOperation.indexOf(self.Program), QCoreApplication.translate("MainWindow1YS", u"Program", None))
        self.ModuleOperation.setTabText(self.ModuleOperation.indexOf(self.Erase), QCoreApplication.translate("MainWindow1YS", u"Erase", None))
        self.ModuleOperation.setTabText(self.ModuleOperation.indexOf(self.Read), QCoreApplication.translate("MainWindow1YS", u"Read", None))
        self.menuSelect.setTitle(QCoreApplication.translate("MainWindow1YS", u"Select", None))
        self.menuAbout.setTitle(QCoreApplication.translate("MainWindow1YS", u"Help", None))
    # retranslateUi

