def to_morse_code(line, outputFileName):
    """Converts a line of normal text to morse code and appends the result to a
    specified file."""

    # morse codes for a, b, c,..., respectively
    morse_codes = [".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.",
                   "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."]

    # specifies characters that convert to a slash
    sentence_terminators = [".", "?", "!", " "]

    # go through the file line by line
    with open(outputFileName, "a") as outputFile:
        for i in range(0, len(line) - 1):
            char = line[i]

            if char in sentence_terminators:
                outputFile.write("/")
            else:
                # if the characters are lower-case, convert them to upper-case
                if ord(char) < 97:
                    char = chr(ord(char) ^ 32)

                outputFile.write(morse_codes[ord(char) - 97] + "/")

        outputFile.write("\n")


def from_morse_code(line, output_file_name):
    """Converts a line of text from morse code to normal text and appends the
    result to a specified file."""

    # the tree used to decode the message (https://i.redd.it/hu3t1it7p3sz.jpg)
    decoding_tree = ["", "", "e", "t", "i", "a", "n", "m", "s", "u", "r", "w", "d", "k", "g", "o", "h", "v", "f", "",
                     "l", "", "p", "j", "b", "x", "c", "y", "z", "q"]

    # the current index of a character that is being selected in the tree
    char_position = 1

    # whether to write a capital letter or not
    write_capital_letter = True

    with open(output_file_name, "a") as output_file:
        # go char by char (excluding the last char - a newline)
        for i in range(0, len(line) - 1):
            char = line[i]

            # if there is an end character
            if char == "/":
                # if we just wrote a character, print some sort of a separator character; if not, write the character
                if char_position == 1:
                    # if there are two in a row, it has to be a dot; if not, it is only a space
                    if line[i:i + 2] == "//":
                        output_file.write(".")
                        write_capital_letter = True
                    else:
                        output_file.write(" ")
                else:
                    character = decoding_tree[char_position]

                    # if the letter needs to be capitalized
                    if write_capital_letter:
                        character = chr(ord(character) ^ 32)
                        write_capital_letter = False

                    output_file.write(character)
                    char_position = 1
            else:
                # move in the tree (. is to the left, - is to the right)
                if char == ".":
                    char_position *= 2
                else:
                    char_position = char_position * 2 + 1

        output_file.write("\n")


input_file_name = input("Input file name: ")
output_file_name = input("Output file name: ")
conversion_direction = input("(T)o morse code or (F)rom morse code: ")

# read the input file
with open(input_file_name, "r") as inputFile:
    # convert it according to the direction of the conversion
    for line in inputFile:
        if conversion_direction == "T":
            to_morse_code(line, output_file_name)
        elif conversion_direction == "F":
            from_morse_code(line, output_file_name)

input("Done!")
