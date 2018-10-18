from re import sub

def generateTrie(fileName):
    """Generates a trie the words in a file as stores it a nested dictionary."""
    trie = {}

    # Read lines of the file one by one
    with open(fileName, encoding="UTF-8") as file:
        for line in file:
            # Clean up the words
            words = sub("[^a-z ]", "", line.lower().strip()).split(" ")

            for word in words:
                trieBranch = trie

                # Go through all the characters
                for i in range(0, len(word)):
                    character = word[i]

                    # If this character is not in a trie, add it
                    if character not in trieBranch:
                        trieBranch[character] = [{}, 0]

                    # If we are at the end of the word, increment its frequency
                    if i == len(word) - 1:
                        trieBranch[character][1] += 1

                    # Go further into the branch
                    trieBranch = trieBranch[character][0]
    return trie

def generateTrieWords(trie, word, words):
    """Generates words and its fequencies from a trie."""
    for key, value in trie.items():
        # If a word ends here, append it to the word array
        if value[1] != 0:
            words.append(["".join(word)+key, value[1]])

        # If we can go down further, we go down further
        if value[0] != {}:
            word.append(key)
            generateTrieWords(value[0], word, words)
            word.pop()

# Word list that will save the word frenquencies
words = []

# Generate the list of the words from the trie and its frequencies
generateTrieWords(generateTrie("words.txt"), [], words)

# Prints all of the words in a sorted order (from biggest to smallest)
for word in sorted(words, key=lambda x: -x[1]):
    print(word[0]+": "+str(word[1]))

input()
