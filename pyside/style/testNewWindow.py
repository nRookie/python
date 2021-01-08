import sys
from PySide2.QtCore import Qt
from PySide2.QtWidgets import QApplication, QLabel, QWidget, QListWidget, QListWidgetItem, QHBoxLayout, QPushButton, QVBoxLayout, QMainWindow
from PySide2.QtCore import QThread, Signal
from gui_1ys import *
_placeholder = 'This is a place holder text'
class Widget(QMainWindow):
    def __init__(self, parent=None):
        super(Widget, self).__init__(parent)

        text_widget = QLabel(_placeholder)
        button = QPushButton("Something")
        button.clicked.connect(self.orderWindow)
        content_layout = QVBoxLayout()
        content_layout.addWidget(text_widget)
        content_layout.addWidget(button)
        self.main_widget = QWidget()
        self.main_widget.setLayout(content_layout)
        self.setCentralWidget(self.main_widget)
    def orderWindow(self):
        window = GUI_1YS(None,"Type1YS/1SS")
        print(id(self.window))
        window.show()
        self.hide()
if __name__ == "__main__":
    app = QApplication()
    w = Widget()
    w.show()

    with open("style.qss", "r") as f:
        _style = f.read()
        app.setStyleSheet(_style)

    sys.exit(app.exec_())