from re import sub


def generate_trie(file_name):
    """Generates a trie the words in a file as stores it a nested dictionary."""
    trie = {}

    # read lines of the file one by one
    with open(file_name, encoding="UTF-8") as file:
        for line in file:
            # clean up the words
            words = sub("[^a-z ]", "", line.lower().strip()).split(" ")

            for word in words:
                trieBranch = trie

                # go through all the characters
                for i in range(0, len(word)):
                    character = word[i]

                    # if this character is not in a trie, add it
                    if character not in trieBranch:
                        trieBranch[character] = [{}, 0]

                    # if we are at the end of the word, increment its frequency
                    if i == len(word) - 1:
                        trieBranch[character][1] += 1

                    # go further into the branch
                    trieBranch = trieBranch[character][0]
    return trie


def generate_trie_words(trie, word, words):
    """Generates words and its frequencies from a trie."""
    for key, value in trie.items():
        # if a word ends here, append it to the word array
        if value[1] != 0:
            words.append(["".join(word) + key, value[1]])

        # if not, recursively call itself
        if value[0] != {}:
            word.append(key)
            generate_trie_words(value[0], word, words)
            word.pop()


# word list that will save the word frequencies
words = []

# generate the list of the words from the trie and its frequencies
generate_trie_words(generate_trie("words.txt"), [], words)

# prints all of the words in a sorted order (from biggest to smallest)
for word in sorted(words, key=lambda x: -x[1]):
    print("%s: %s" % (word[0], str(word[1])))

input()
