using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    public class Score : INotifyPropertyChanged
    {
        private int numWins = 0;
        private int numLoses = 0;
        private int numDraws = 0;
        private string winner = "none";
        public int NumWins { get { return numWins; } set { numWins = value; OnPropertyChanged("NumWins"); } }
        public int NumLoses { get { return numLoses; } set { numLoses = value; OnPropertyChanged("NumLoses"); } }
        public int NumDraws { get { return numDraws; } set { numDraws = value; OnPropertyChanged("NumDraws"); } }
        public string Winner { get { return winner; } set { winner = value; OnPropertyChanged("Winner"); } }
        
        public Score()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
