def toMorseCode(line, outputFileName):
    """Converts a line of normal text to morse code and appends the result to a
    specified file."""

    # Morse codes for a, b, c,..., respectively
    morseCodes = [".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....",
    "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.",
    "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."]

    # Specifies characters that convert to a slash
    sentenceEnders = [".", "?", "!", " "]

    # Go through the file line by line
    with open(outputFileName, "a") as outputFile:
        for i in range(0, len(line) - 1):
            char = line[i]

            if char in sentenceEnders:
                outputFile.write("/")
            else:
                # If the characters are lower-case, convert them to upper-case
                if ord(char) < 97:
                    char = chr(ord(char) ^ 32)

                outputFile.write(morseCodes[ord(char) - 97]+"/")

        outputFile.write("\n")

def fromMorseCode(line, outputFileName):
    """Converts a line of text from morse code to normal text and appends the
    result to a specified file."""

    # The tree used to decode the message (https://i.redd.it/hu3t1it7p3sz.jpg)
    decodingTree = ["","", "e", "t", "i", "a", "n", "m", "s", "u", "r", "w",
    "d", "k", "g", "o", "h", "v", "f", "", "l", "", "p", "j", "b", "x", "c",
    "y", "z", "q"]

    # The current index of a character that is being selected in the tree
    charPosition = 1

    # Whether to write a capital letter or not
    writeCapitalLetter = True

    with open(outputFileName, "a") as outputFile:
        # Go char by char (excluding the last char - a newline)
        for i in range(0, len(line) - 1):
            char = line[i]

            # If there is an end character
            if char == "/":
                # If we just wrote a character, print some sort of a separator
                # character. If not, write it.
                if charPosition == 1:
                    # If there are two in a row, this has to be a dot. If not,
                    # it is only a space
                    if line[i:i+2] == "//":
                        outputFile.write(".")
                        writeCapitalLetter = True
                    else:
                        outputFile.write(" ")
                else:
                    character = decodingTree[charPosition]

                    if (writeCapitalLetter):
                        character = chr(ord(character) ^ 32)
                        writeCapitalLetter = False

                    outputFile.write(character)
                    charPosition = 1
            else:
                # Move in the tree (. is to the left, - is to the right)
                if char == ".":
                    charPosition *= 2
                else:
                    charPosition = charPosition * 2 + 1

        outputFile.write("\n")

inputFileName = input("Input file name: ")
outputFileName = input("Output file name: ")
conversionDirection = input("(T)o morse code or (F)rom morse code: ")

# Read the input file
with open(inputFileName, "r") as inputFile:
    # Convert each line
    for line in inputFile:
        if conversionDirection == "T":
            toMorseCode(line, outputFileName)
        elif conversionDirection == "F":
            fromMorseCode(line, outputFileName)

input()
