
import sys

from PySide2.QtWidgets import QApplication, QMainWindow
from PySide2.QtGui import QPixmap
from MainWindow1YS import *
# from widget_1ys_wrapper import *

class GUI_1YS(QMainWindow, Ui_MainWindow1YS):

    def __init__(self,parent=None,Module = ""):
        QMainWindow.__init__(self, parent)
        print("Current Module",Module)
        self.setupUi(self)
        if Module == "Type1YS/1SS":
            self.GUI_Reload_1YS()
        elif Module == "Type2AB":
            self.GUI_Reload_2AB()
        else:
            self.GUI_Reload_Default()

    def GUI_Reload_1YS(self):
        self.ModuleOperation.setTabText(self.ModuleOperation.indexOf(self.Read), QCoreApplication.translate("MainWindow1YS", u"Read", None))
        self.ModuleOperation.setCurrentIndex(self.ModuleOperation.indexOf(self.Info))

    def GUI_Reload_2AB(self):
        self.ModuleOperation.setTabText(self.ModuleOperation.indexOf(self.Read), QCoreApplication.translate("MainWindow1YS", u"Read", None))
        self.ModuleOperation.removeTab(self.ModuleOperation.indexOf(self.Read))
        self.ModuleOperation.setCurrentIndex(self.ModuleOperation.indexOf(self.Info))

    def GUI_Reload_Default(self):
        self.ModuleOperation.setTabText(self.ModuleOperation.indexOf(self.Read), QCoreApplication.translate("MainWindow1YS", u"Read", None))
        self.ModuleOperation.setCurrentIndex(self.ModuleOperation.indexOf(self.Info))