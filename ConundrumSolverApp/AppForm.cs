using ConundrumSolver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ApplicationForm
{
    public partial class AppForm : Form
    {
        private WordFinder wordFinder;
        public AppForm()
        {
            InitializeComponent();
            wordFinder = new WordFinder();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            var startTime = new DateTime();
            startTime = DateTime.Now;

            wordFinder.SolveConundrum(txtBoxInput.Text);
            listSolvedWords.Items.Clear();
            foreach (var word in wordFinder.WordDictionary)
            {
                listSolvedWords.Items.Add(word.Key);
            }

            var timeTaken = ((int)(DateTime.Now - startTime).TotalMilliseconds).ToString();
            lblTimer.Text = $"{wordFinder.WordDictionary.Count} words found in {timeTaken}ms.";
        }

        private void listSolvedWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDefinitions.Text = wordFinder.WordDictionary.FirstOrDefault(w => w.Key.ToLowerInvariant() == listSolvedWords.Text.ToLowerInvariant()).Value;
        }
    }
}
