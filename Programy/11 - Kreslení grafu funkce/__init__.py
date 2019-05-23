import sys

from PyQt5.QtCore import QSize, Qt
from PyQt5.QtGui import QFont, QPainter, QPen, QBrush
from PyQt5.QtWidgets import QApplication, QWidget, QVBoxLayout, QFrame, QLineEdit

from evaluate_expression import evaluate_function_from_list


class Snake(QWidget):

    def __init__(self):
        """Initial game configuration."""
        super().__init__()

        # GLOBAL VARIABLES
        self.zoom = 1 / 50
        self.zoom_coefficient = 1.3

        self.origin_position = [300, 300]

        self.move_start_position = [0, 0]  # start of the move
        self.move_origin_position = [0, 0]  # origin position at the beginning of the move

        # WIDGET CREATION
        self.canvas = QFrame(self, minimumSize=QSize(600, 600))

        # WIDGET LAYOUT
        self.main_v_layout = QVBoxLayout(self, margin=0)

        self.equation_inputs_layout = QVBoxLayout(self, margin=10)

        # add 3 equation inputs
        for i in range(3):
            self.equation_inputs_layout.addWidget(QLineEdit(self, textChanged=self.update))

        self.main_v_layout.addWidget(self.canvas)
        self.main_v_layout.addLayout(self.equation_inputs_layout)

        self.setLayout(self.main_v_layout)

        # WINDOW SETTINGS
        self.setWindowTitle('Window Title')
        self.setFont(QFont("Fira Code", 16))
        self.show()

    def calculate_y_values(self, function: str, x_values: list):
        """Calculates function values from a list of x values."""
        return evaluate_function_from_list(function, x_values)

    def paintEvent(self, event):
        """Paints on the canvas."""
        painter = QPainter(self)

        painter.setPen(QPen(Qt.black, Qt.SolidLine))
        painter.setBrush(QBrush(Qt.white, Qt.SolidPattern))

        # draw background
        painter.drawRect(0, 0, self.canvas.width(), self.canvas.height())

        # draw axes
        painter.drawLine(0,
                         self.canvas.height() - self.origin_position[1],
                         self.canvas.width(),
                         self.canvas.height() - self.origin_position[1])

        painter.drawLine(self.origin_position[0],
                         0,
                         self.origin_position[0],
                         self.canvas.height())

        # colors of the graphs
        function_colors = [Qt.red, Qt.blue, Qt.green]

        for i in range(self.equation_inputs_layout.count()):
            # get the text of the function
            function = self.equation_inputs_layout.itemAt(i).widget().text()

            # set color
            painter.setPen(QPen(function_colors[i], Qt.SolidLine))

            x_values = []
            for j in range(self.canvas.width()):
                # calculate the position from canvas to the zoomed and translated coordinates
                x_values.append((j - self.origin_position[0]) * self.zoom)

            # calculate the y values of the function
            y_values = self.calculate_y_values(function, x_values)

            # adjust the y values for the zoom
            for j in range(len(y_values)):
                if y_values[j] is not None:
                    y_values[j] = (j, self.canvas.height() - (y_values[j] / self.zoom + self.origin_position[1]))

            # form the graph by connecting the points
            for j in range(len(y_values) - 1):
                # if both exist, simply connect them
                if y_values[j] is not None and y_values[j + 1] is not None:
                    # if they visually don't connect on the canvas, don't connect them
                    if abs(y_values[j][1] - y_values[j + 1][1]) < self.canvas.height():
                        painter.drawLine(y_values[j][0], y_values[j][1], y_values[j + 1][0], y_values[j + 1][1])

    def mouseMoveEvent(self, event):
        """Is called when the mouse is moved and has a button pressed. Moves the axes and updates the canvas."""
        self.origin_position = [
            self.move_origin_position[0] + (event.pos().x() - self.move_start_position[0]),
            self.move_origin_position[1] - (event.pos().y() - self.move_start_position[1])
        ]
        self.update()

    def mousePressEvent(self, event):
        """Is called when the mouse is pressed. Starts to move the axes."""
        self.move_start_position = [event.pos().x(),
                                    event.pos().y()]
        self.move_origin_position = list(self.origin_position)

    def wheelEvent(self, event):
        """Is called when the mouse wheel is moved. Adjusts zoom and updates the canvas."""
        if event.angleDelta().y() > 0:
            self.zoom /= self.zoom_coefficient
        else:
            self.zoom *= self.zoom_coefficient

        self.update()


app = QApplication(sys.argv)

ex = Snake()
sys.exit(app.exec_())
