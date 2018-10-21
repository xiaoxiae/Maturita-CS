from itertools import product
from random import randint
from time import sleep

possibleColors = "123456"
guessLength = 6

possibilities = list(product(possibleColors, repeat=guessLength))

def computerAsGuesser():
    """Plays Mastermind, with the computer being the guesser."""
    guessedPossibilities = [True] * len(possibilities)
    leftoverPossibilities = len(guessedPossibilities)

    humanInput = []

    while humanInput != [guessLength, 0]:
        guess = randint(0, len(possibilities))

        # if that guess is taken, get the next smaller one
        # note that if this reaches 0, it loops over (thanks, Python)
        while guessedPossibilities[guess] == False:
            guess -= 1
        guess = possibilities[guess]

        print("My guess is "+"".join(guess)+".")

        rawInput = input("Rank the score: ")
        convInput = tuple([int(num) for num in rawInput.split(" ")])

        while len(convInput) != 2 or convInput[0] + convInput[1] > guessLength:
                rawInput = input("Incorrect input. Try again: ").split(" ")
                convInput = tuple([int(num) for num in rawInput])

        if convInput == (guessLength, 0):
            print("Yey, I win!")
            quit()

        # Remove all guesses that don't match in the same way:
        for i in range(0, len(possibilities)):
            if guessedPossibilities[i]:
                if match(guess, possibilities[i]) != convInput:
                    guessedPossibilities[i] = False
                    leftoverPossibilities -= 1

        # If we ran out of possible numbers:
        if leftoverPossibilities == 0:
            print("You are cheating! I'm not playing.")
            input()
            quit()

def humanAsGuesser():
    """Plays Mastermind, with the human being the guesser."""
    hiddenColors = possibilities[randint(0, len(possibilities))]
    guess = ""

    while guess != hiddenColors:
        # Make the human guess until the guess is correct
        while not isInputValid(guess):
            print("Guess: ", end="")
            guess = input()

        # If the guess is correct, quit. If not, give him clues.
        if tuple(guess) == hiddenColors:
            print("Correct!")
            input()
            quit()
        else:
            blackAndWhite = match(guess, hiddenColors)
            print("Wrong! Blacks and whites: "+str(blackAndWhite))
            guess = ""

def isInputValid(input):
    """Checks the validity of the input (length, correctness of colors...)."""
    if len(input) != guessLength:
        return False

    for char in input:
        if char not in list(possibleColors):
            return False

    return True

def match(guess, answer):
    """Scores a guess with it's answer. Returns the score as [black, white]."""
    white, black = 0, 0

    usedGuesses = [False] * len(guess)
    usedAnswers = [False] * len(answer)

    # counts white and "crosses off" the selected indexes
    for i in range(len(guess)):
        if guess[i] == answer[i]:
            white += 1
            usedGuesses[i], usedAnswers[i] = True, True

    # goes through all the pairs. if they aren't used and match, increment black
    for i in range(len(guess)):
        if not usedGuessIndexes[i]:
            for j in range(len(answer)):
                if i != j and not usedAnswers[j] and guess[i] == answer[j]:
                    black += 1
                    break

    return (white, black)

computerAsGuesser()
