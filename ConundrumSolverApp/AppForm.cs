using ConundrumSolver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            wordFinder.SolveConundrum(txtBoxInput.Text);

            listSolvedWords.Items.Clear();

            foreach (var word in wordFinder.WordDictionary)
            {
                listSolvedWords.Items.Add(word.Key);
            }
        }
    }
}
