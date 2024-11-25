using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Model;


namespace QuizApp.ViewModel
{
    public class QuizAppViewModel : INotifyPropertyChanged
    {
        private int _currentQuestionIndex;
        private string _currentQuestion;

        public ObservableCollection<QuizAppModel> Questions { get; set; }

        public string CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                OnPropertyChanged();
            }
        }

        public Command NextCommand { get; }
        public Command PreviousCommand { get; }

        public QuizAppViewModel()
        {
            // Inicializar preguntas
            Questions = new ObservableCollection<QuizAppModel>
            {
                new QuizAppModel { Text = "¿Nuestro sistema solar se encuentra en la galaxia Vía Láctea?", Answer = true },
                new QuizAppModel { Text = "¿El planeta Marte tiene más lunas que la Tierra?", Answer = true },
                new QuizAppModel { Text = "¿El agua hierve a 50 grados Celsius a nivel del mar?", Answer = false },
                new QuizAppModel { Text = "¿La Gran Muralla China es visible desde el espacio?", Answer = false }
            };

            _currentQuestionIndex = 0;
            CurrentQuestion = Questions[_currentQuestionIndex].Text;

            // Comandos
            NextCommand = new Command(NextQuestion);
            PreviousCommand = new Command(PreviousQuestion);
        }

        private void NextQuestion()
        {
            _currentQuestionIndex = (_currentQuestionIndex + 1) % Questions.Count;
            CurrentQuestion = Questions[_currentQuestionIndex].Text;
        }

        private void PreviousQuestion()
        {
            _currentQuestionIndex = (_currentQuestionIndex - 1 + Questions.Count) % Questions.Count;
            CurrentQuestion = Questions[_currentQuestionIndex].Text;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
