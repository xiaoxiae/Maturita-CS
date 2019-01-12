using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logik
{
    public partial class Form1 : Form {
        // The generated solutions
        string[] solutions = new string[(int)Math.Pow(6, 5)];

        // Number of remaining possible solutions
        int solutions_remaining = 0;

        // How many of the colors did the user specify
        int user_specified_colors = 0;

        // Computer's current guess
        string guess = "";

        // Random number generator to generate guesses
        Random random = new Random();


        public Form1() {
            InitializeComponent();
        }


        /// <summary>
        /// Gets the back color from the drag-and-droppable palette.
        /// </summary>
        private void get_color(object sender, MouseEventArgs e) {
            DoDragDrop((sender as Label).BackColor, DragDropEffects.All);
        }


        /// <summary>
        /// Called when drag and drop enters the user input cells.
        /// </summary>
        private void color_drag_enter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(Color)))
                e.Effect = DragDropEffects.Move;
        }


        /// <summary>
        /// Called when the user drops the drag-and-drop into the input cell.
        /// </summary>
        private void color_drag_drop(object sender, DragEventArgs e) {
            // If there was no color previously, increment user_specified_colors
            if ((sender as Label).BackColor == Color.Silver)
                user_specified_colors++;

            // Set the background color to drop
            (sender as Label).BackColor = (Color)e.Data.GetData(typeof(Color));

            // Enable automatic evaluation if all colors have been specified
            if (user_specified_colors == 5  && guess != "")
                automatic_evaluate_button.Enabled = true;
        }


        /// <summary>
        /// Generates solutions, takes a guess, enables buttons.
        /// </summary>
        private void start_game_button_Click(object sender, EventArgs e) {
            // Enable user inputs and disable startgame
            manual_evaluation_button.Enabled = true;
            black_user_input.Enabled = true;
            white_user_input.Enabled = true;
            start_game_button.Enabled = false;
            if (user_specified_colors == 5)
                automatic_evaluate_button.Enabled = true;

            // Recursively generate all possible solutions
            generate_solutions(new int[5], 4);

            // Add columns to the DataGridView
            for(int i = 0; i < 5; i++) {
                DataGridViewImageColumn column = new DataGridViewImageColumn();
                move_history.Columns.Add(column);
            }

            // Make the first guess
            generate_guess();
        }


        /// <summary>
        /// Creates a row of the specified color sequence.
        /// </summary>
        /// <param name="color_sequence">The sequence of chars from 0 to 5 
        /// representing the colors.</param>
        private void add_to_history(string color_sequence) {
            move_history.Rows.Add();

            int column = move_history.RowCount - 1;

            for (int i = 0; i < 5; i++) {
                int row = i;

                // Create the image and add it to the last row
                Bitmap img = new Bitmap("img/" + color_sequence[i] + ".png");
                move_history.Rows[column].Cells[row].Value = img;
            }

            // Scroll down the DataGridView
            move_history.FirstDisplayedScrollingRowIndex = column;
        }


        /// <summary>
        /// A recursive function that generates all the possible combinations.
        /// </summary>
        private void generate_solutions(int[] solution, int depth) {
            if (depth < 0) {    // If we reached the bottom, add the solution
                solutions[solutions_remaining] = string.Join("", solution);
                solutions_remaining++;
            } else {            // Else recursively call all possible variations
                for (int i = 0; i < 6; i++) {
                    solution[depth] = i;
                    generate_solutions(solution, depth - 1);
                }
            }
        }


        /// <summary>
        /// Evaluates two color sequences and returns their score.
        /// </summary>
        /// <param name="color_sequence_1">The first color sequence.</param>
        /// <param name="color_sequence_2">The second color sequence.</param>
        /// <returns>int[2], first is black and second white </returns>
        private int[] compare_inputs(String color_sequence_1, String color_sequence_2) {
            int black = 0, white = 0;
            int[] color_frequency = new int[6];

            for(int i = 0; i < color_sequence_1.Length; i++) {
                // If it's a direct match, increment black
                // Else if there is an indirect match, increment white
                if (color_sequence_1[i] == color_sequence_2[i]) black++;
                else {
                    // The algorithm works in a way that 
                    color_frequency[color_sequence_1[i] - '0'] += 1;
                    if (color_frequency[color_sequence_1[i] - '0'] <= 0)
                        white += 1;

                    color_frequency[color_sequence_2[i] - '0'] -= 1;
                    if (color_frequency[color_sequence_2[i] - '0'] >= 0)
                        white += 1;
                }
            }

            return new int[] {black, white};
        }


        /// <summary>
        /// Calls evaluate() with the values from the appropriate updowns.
        /// </summary>
        private void manual_evaluation_button_Click(object sender, EventArgs e) {
            evaluate(new int[] {(int)black_user_input.Value,
                                (int)white_user_input.Value});
        }


        /// <summary>
        /// Calls evaluate() with automatically evaluated user input.
        /// </summary>
        private void automatic_evaluate_button_Click(object sender, EventArgs e) {
            evaluate(compare_inputs(get_user_input(), guess));
        }


        /// <summary>
        /// Converts user input into a string of digits representing colors.
        /// </summary>
        /// <returns>String of digits (0 to 5) representing the colors</returns>
        private string get_user_input() {
            // A dictionary to convert colors to strings
            Dictionary<Color, string> color_to_string = new Dictionary<Color, string>() {
                { color_label_1.BackColor, "0" },
                { color_label_2.BackColor, "1" },
                { color_label_3.BackColor, "2" },
                { color_label_4.BackColor, "3" },
                { color_label_5.BackColor, "4" },
                { color_label_6.BackColor, "5" }
            };

            // Return the colors converted to a string
            return color_to_string[guess_label_1.BackColor] +
                   color_to_string[guess_label_2.BackColor] +
                   color_to_string[guess_label_3.BackColor] +
                   color_to_string[guess_label_4.BackColor] +
                   color_to_string[guess_label_5.BackColor];
        }


        /// <summary>
        /// Evaluates user input.
        /// </summary>
        /// <param name="guess_score">The score of the guess.</param>
        private void evaluate(int[] guess_score) {
            // See if we won 
            if (guess_score.SequenceEqual(new int[]{5, 0})) {
                MessageBox.Show("I won! It took me " + move_history.RowCount.ToString() + " guesses.");
                Application.Exit();
            }

            // Remove incorrect solutions by swapping them with last remaining solution
            for (int i = 0; i < solutions_remaining;) {
                string solution = solutions[i];

                if (!compare_inputs(solution, guess).SequenceEqual(guess_score)) {
                    solutions[i] = solutions[solutions_remaining - 1];
                    solutions_remaining--;
                }
                else i++;
            }

            // Check if there are any guesses left (if the opponent isn't cheating)
            if (solutions_remaining == 0) {
                MessageBox.Show("You're cheating, I'm not playing!");
                Application.Exit();
            }

            // Makes a new guess
            generate_guess();
        }


        /// <summary>
        /// Generates a guess for the computer and adds it to the DataGridView
        /// </summary>
        private void generate_guess() {
            guess = solutions[random.Next(solutions_remaining)];
            add_to_history(guess);
        }


        /// <summary>
        /// Adjust maximum value for the white_user_input updown based on the black one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void black_user_input_ValueChanged(object sender, EventArgs e) {
            black_user_input.Maximum = 5;

            if (black_user_input.Value >= 4) white_user_input.Maximum = 0;
            else white_user_input.Maximum = 5 - black_user_input.Value;
        }
    }
}
