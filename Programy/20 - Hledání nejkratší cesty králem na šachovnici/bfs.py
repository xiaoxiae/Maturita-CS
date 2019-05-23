import sys

from PyQt5.QtCore import QSize, Qt
from PyQt5.QtGui import QPainter, QPen, QBrush
from PyQt5.QtWidgets import QApplication, QWidget, QFrame, QVBoxLayout


class P2(QWidget):
    def __init__(self):
        """Initial game configuration."""
        super().__init__()

        # GAME VARIABLES
        # valid moves for the king
        self.valid_moves = [(1, 0), (1, 1), (0, 1), (-1, 1), (-1, 0), (-1, -1), (0, -1), (1, -1)]

        # starting and ending tiles
        self.start = None
        self.end = None

        # a boolean array, where True values are obstacles/pieces
        self.obstacles = [[False] * 8 for _x in range(8)]

        # WIDGET LAYOUT
        self.canvas = QFrame(self, minimumSize=QSize(600, 600))

        self.main_v_layout = QVBoxLayout(self, margin=0)
        self.main_v_layout.addWidget(self.canvas)
        self.setLayout(self.main_v_layout)

        self.setWindowTitle('Graph Visualizer')
        self.show()

        self.setFixedSize(self.size())

    def are_coordinates_valid(self, x, y):
        """Returns True, if the coordinates are valid board coordinates and False if they are not."""
        return 0 <= x < len(self.obstacles) and 0 <= y < len(self.obstacles[0])

    def calculate_shortest_path(self):
        """Returns either the shortest possible path connecting (and including) the start and the end , or None if such
        path doesn't exist."""
        # don't calculate the path if either start or end are unknown
        if self.start is None or self.end is None:
            return None

        # squares to be explored (a linked list
        unexplored_squares = [self.start]

        # for tracking where we came from
        board = [[None] * len(self.obstacles[0]) for _x in range(len(self.obstacles))]
        board[self.start[0]][self.start[1]] = -1  # special value, so it isn't explored

        # explore, until there are tiles to explore
        while len(unexplored_squares) != 0:
            x, y = unexplored_squares.pop(0)

            # if we reached the end, back-track to start; if not, add unexplored tiles and repeat
            if x == self.end[0] and y == self.end[1]:
                path = [(x, y)]
                coordinate = (x, y)

                # add coordinates to the path list, until we reach the start
                while coordinate != self.start:
                    coordinate = board[coordinate[0]][coordinate[1]]
                    path.append(coordinate)

                return path
            else:
                for move in self.valid_moves:
                    new_x = x + move[0]
                    new_y = y + move[1]

                    # add the coordinate, only if it's valid, unexplored, and not an obstacle
                    if self.are_coordinates_valid(new_x, new_y):
                        unexplored = board[new_x][new_y] is None
                        no_obstacle = not self.obstacles[new_x][new_y]

                        if unexplored and no_obstacle:
                            unexplored_squares.append((new_x, new_y))
                            board[new_x][new_y] = (x, y)

    def mouseMoveEvent(self, event):
        """Is called when a mouse button is pressed; creates start, end and obstacles."""
        mouse_x, mouse_y = event.pos().x(), event.pos().y()

        x = int((mouse_x / self.canvas.width()) * len(self.obstacles))
        y = int((mouse_y / self.canvas.height()) * len(self.obstacles[0]))

        if self.are_coordinates_valid(x, y):
            if event.buttons() == Qt.LeftButton and not self.obstacles[x][y]:
                self.start = (x, y)
            if event.buttons() == Qt.RightButton and not self.obstacles[x][y]:
                self.end = (x, y)
            if event.buttons() == Qt.MiddleButton and (x, y) != self.start and (x, y) != self.end:
                self.obstacles[x][y] = True

        self.update()

    # make mouse press the same thing as mouse move
    mousePressEvent = mouseMoveEvent

    def paintEvent(self, event):
        """Paints the board."""
        painter = QPainter(self)

        painter.setRenderHint(QPainter.Antialiasing, True)

        painter.setPen(QPen(Qt.black, Qt.SolidLine))
        painter.setBrush(QBrush(Qt.white, Qt.SolidPattern))

        painter.drawRect(0, 0, self.canvas.width(), self.canvas.height())

        tile_width = self.canvas.width() / len(self.obstacles)
        tile_height = self.canvas.height() / len(self.obstacles[0])

        # draw obstacles
        for x in range(len(self.obstacles)):
            for y in range(len(self.obstacles[0])):
                if self.obstacles[x][y]:
                    painter.setBrush(QBrush(Qt.black, Qt.SolidPattern))
                else:
                    painter.setBrush(QBrush(Qt.white, Qt.SolidPattern))

                painter.drawRect(x * tile_width, y * tile_height, tile_width, tile_height)

        # draw path if it exists
        path = self.calculate_shortest_path()
        if path is not None:
            painter.setBrush(QBrush(Qt.green, Qt.SolidPattern))
            for p in path:
                painter.drawRect(p[0] * tile_width, p[1] * tile_height, tile_width, tile_height)

        # draw start if it exists
        if self.start is not None:
            painter.setBrush(QBrush(Qt.blue, Qt.SolidPattern))
            painter.drawRect(self.start[0] * tile_width, self.start[1] * tile_height, tile_width, tile_height)

        # draw end if it exists
        if self.end is not None:
            painter.setBrush(QBrush(Qt.red, Qt.SolidPattern))
            painter.drawRect(self.end[0] * tile_width, self.end[1] * tile_height, tile_width, tile_height)


app = QApplication(sys.argv)
ex = P2()
sys.exit(app.exec_())
