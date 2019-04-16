from random import randint


class BoardState:
    images = {}
    
    def __init__(self, boardSize, numberOfPlayers):
        # player variables
        self.player = 0
        self.numberOfPlayers = numberOfPlayers
        self.scores = [0] * self.numberOfPlayers
        
        # flipping cards variables
        self.flipped = None
        self.toBeFlippedBack = []
    
        # load images
        self.images = {}
        for i in range(1, 33):
            self.images[i] = loadImage("img/" + str(i) + ".png"); 
        
        # generates the board with the default numbers
        self.board = [[(x + y * boardSize) % (boardSize ** 2 / 2) + 1\
                       for x in range(boardSize)] \
                       for y in range(boardSize)]

        # randomly swaps (n^2)^2 times
        for _i in range((boardSize ** 2) ** 2):
            x1, y1 = randint(0, boardSize - 1), randint(0, boardSize - 1)
            x2, y2 = randint(0, boardSize - 1), randint(0, boardSize - 1)        
            self.board[x1][y1], self.board[x2][y2] = self.board[x2][y2], self.board[x1][y1]
    
    def drawBoard(self):
        background(255)
    
        tileWidth = width / len(self.board[0])
        tileHeight = height / len(self.board)
        
        textSize(120 / len(self.board))
        textAlign(CENTER, CENTER)
        
        for y in range(len(self.board)):
            for x in range(len(self.board[0])):
                line(0, y * tileHeight, width, y * tileHeight)
                line(x * tileWidth, 0, x * tileWidth, height)
                
                if self.board[y][x] < 0:            
                    image(self.images[-self.board[y][x]],\
                          x * tileWidth, y * tileHeight,\
                          tileWidth, tileHeight)
                    
        # set window title
        if not sum(self.scores) == len(self.board) ** 2 / 2:
            self.setWindowTitle()

    def setWindowTitle(self):
        """Sets the title of the window."""
        this.getSurface().setTitle("Player " + str(self.player + 1) + "      " + \
                                   "Scores: " + str(self.scores))

    def flip(self, x, y):
        """Attempts to flip a card."""
        if self.board[y][x] < 0:       # if it is already flipped, continue
            pass
        elif self.flipped == None:     # if it isn't flipped and it's the first to be
            self.flipped = (x, y)      # save its coordinate
            self.board[y][x] *= -1     # flip it
        else:                          # else if it isn't flipped and it's the second to be
            # flip it, even if it doesn't match
            self.board[y][x] *= -1

            # if it doesn't match, add both of the cards to the "toBeFlippedBack" list and move to next player         
            if self.board[self.flipped[1]][self.flipped[0]] != self.board[y][x]:
                self.toBeFlippedBack.append((self.flipped[1], self.flipped[0]))
                self.toBeFlippedBack.append((y, x))            
                self.player = (self.player + 1) % self.numberOfPlayers   
                
            # if it does match, add points to the player who scored it                         
            else:
                self.scores[self.player] += 1
            
            self.flipped = None

        # if all of the pairs have been turned, end the game
        if sum(self.scores) == len(self.board) ** 2 / 2:
            thread("endGame")


boardState = None

def setup():
    size(600, 600)
    fill(0)

        
def draw():
    global boardState

    # if the board has been initialized, draw it
    if boardState != None: 
        boardState.drawBoard()

        if len(boardState.toBeFlippedBack) != 0:
            thread("flipPointsBack")
            
            # the delay is for the thread to initialize
            delay(10)
    
    
def keyPressed():
    global boardState
    
    # if we pressed a keyboard number
    if type(key) == unicode and key.isdigit() and int(key) % 2 == 0 and int(key) != 0:
        boardState = BoardState(int(key), 2)


def flipPointsBack():
    """Flips the pair of cards that don't match back."""
    global boardState
    points = boardState.toBeFlippedBack
    boardState.toBeFlippedBack = []
    
    delay(1000)
        
    for p in points:
        boardState.board[p[0]][p[1]] *= -1


def endGame():
    """Prints the result of the game and ends it."""
    global boardState
    
    this.getSurface().setTitle("Game Over, player "\
        + str(boardState.scores.index(max(boardState.scores)) + 1)\
        + " won.")
            
    delay(1500)
    exit()    


def mousePressed():
    global boardState
    
    if boardState != None:    
        # get position of the tile that we pressed
        x = mouseX // (width / len(boardState.board[0]))
        y = mouseY // (height / len(boardState.board))
        
        boardState.flip(x, y)
        
