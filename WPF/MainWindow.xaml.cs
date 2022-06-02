using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Models;
namespace WPF
{


    

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        #region Filds
        enum gameAction {none = 0, stone = 1, scissors = 2, paper = 3 }
        bool gameIsStarted = false;
        Score score;
        List<UIElement> BlockedElements;
        string[] imgs;
        List<UIElement> RoundBclockedElements;
        List<UIElement> BlockedAllElements;
        List<UIElement> BlockedReportElements;
        event Action<gameAction> PlayerChooseAction;
        Window mWindow;
         #endregion



        public MainWindow()
        {
            InitializeComponent();

            score = (Score)Resources["score"];
            PlayerChooseAction += PChooseActionHandler;
            BlockedElements = new List<UIElement>() { b_Again, b_RandomAction, b_Report, b_Paper, b_Scissors, b_Stone, PlayerActionImage, ComputerActionImage, actionText, actionText2 };
            RoundBclockedElements = new List<UIElement>() { b_Paper, b_Scissors, b_Stone, b_RandomAction };
            BlockedAllElements = new List<UIElement>() { b_Again, b_RandomAction, b_Start, b_Paper, b_Scissors, b_Stone, b_Report, numWins, numDraws, numLoses, winner, PlayerActionImage, ComputerActionImage, actionText, actionText2 };
            BlockedReportElements = new List<UIElement>() {ReportField, b_Back };
            imgs = new string[] { "stone.png", "scissors.png", "paper.png" };
            ElementsIsEnabled(false);
            ElementsIsEnabled(false, BlockedReportElements);
            
        }

        #region Event handlers 
        private void b_Action_Click(object sender, RoutedEventArgs e)
        {
            
            var b = sender as Button;
            if (b != null)
            {
                gameAction action = 0;
                switch (b.Name)
                {
                    case "b_Stone":
                        action = gameAction.stone;
                        break;
                    case "b_Scissors":
                        action = gameAction.scissors;
                        break;
                    case "b_Paper":
                        action = gameAction.paper;
                        break;
                }
                PlayerChooseAction(action);
            }
        }
        private void ButtomButtons_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                switch (button.Name)
                {
                    case "b_Start":
                        if (!gameIsStarted)
                            Start();
                        else
                            Finish();
                        break;
                    case "b_Again":
                        Again();
                        break;
                    case "b_Report":
                        Report();
                        break;
                    case "b_RandomAction":
                        RandomPlayerAction();
                        break;
                    default:
                        throw new Exception("unknown name of button");

                }
            }
            else
            {
                throw new Exception("button is null");
            }
        }
        private void PChooseActionHandler(gameAction pAction)
        {
            gameAction cAction = RandomAction();
            Round(pAction, cAction);
            
        }
        private void ReportTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {



                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("vitalcik.kovalenko2019@gmail.com", "Tom");
                // кому отправляем
                MailAddress to = new MailAddress("vitalcik.kovalenko2019@gmail.com");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Связь с разрабочиком";
                // текст письма
                m.Body = rFTextBox.Text;


                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("vitalcik.kovalenko2019@gmail.com", "dogmtjmmyvmrlsjs");
                smtp.EnableSsl = true;
                string TBMessage = "Ваше письмо было отправленно";
                try
                {
                    smtp.Send(m);
                }
                catch
                {
                    TBMessage = $"Нет подключения к сети";
                }

                InitializateRMWindow(TBMessage);
                mWindow = this.OwnedWindows[0];
                mWindow.Show();
                rFTextBox.Text = null;

            }
        }
        private void b_Back_Click(object sender, RoutedEventArgs e)
        {
            CloseMWinow();
        }
        #endregion

        #region Logic methods
        private void InitializateRMWindow(string message)
        {
            ReportMessageWindow window = new ReportMessageWindow(message);
            window.Owner = this;
        }
        private void Start()
        {
            ElementsIsEnabled(true);
            ChangeTextElement(textBlockStart, "Сброс");
            gameIsStarted = true;
        }
        private void Again()
        {
            ElementsIsEnabled(true, RoundBclockedElements);
            ShowImg(PlayerActionImage, null);
            ShowImg(ComputerActionImage, null);
        }
        private void RandomPlayerAction()
        {
            gameAction pAction = RandomAction();
            Thread.Sleep(15);
            gameAction cAtion = RandomAction();
            Round(pAction, cAtion);
        }
        private void Finish()
        {
            ElementsIsEnabled(false);
            ChangeTextElement(textBlockStart, "Старт");
            gameIsStarted = false;
            ShowImg(PlayerActionImage, null);
            ShowImg(ComputerActionImage, null);
            SetScoreNull();
        }
        private void Report()
        {
            ElementsIsEnabled(false, BlockedAllElements);
            ElementsIsEnabled(true, BlockedReportElements);
        }
        private void SetScoreNull()
        {
            score.NumDraws = 0;
            score.NumWins = 0;
            score.NumLoses = 0;
            score.Winner = "none";
        }
        private void ElementsIsEnabled(bool isEnabled, List<UIElement> BlockedElements = null)
        {
            if(BlockedElements == null)
            {
                BlockedElements = this.BlockedElements;
            }
            for (int i = 0; i < BlockedElements.Count; i++)
            {
                BlockedElements[i].IsEnabled = isEnabled;
                if(!isEnabled){
                    BlockedElements[i].Visibility = Visibility.Hidden;
                }
                else
                {
                    BlockedElements[i].Visibility = Visibility.Visible;
                }
            }
        }
        private void ChangeTextElement(TextBlock block, string text)
        {
            block.Text = text;
        }
        private int GetWinner(gameAction a1, gameAction a2)
        {
            if (a1 == gameAction.stone && a2 == gameAction.scissors || a1 == gameAction.scissors && a2 == gameAction.paper || a1 == gameAction.paper && a2 == gameAction.stone)
            {
                return 1;
            }
            else if (a2 == gameAction.stone && a1 == gameAction.scissors || a2 == gameAction.scissors && a1 == gameAction.paper || a2 == gameAction.paper && a1 == gameAction.stone)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        private gameAction RandomAction()
        {
            Random r = new Random();
            var n = r.Next(1, 4);
            gameAction action = (gameAction)n;
           

            return action;
        }
        private string GetActionImgs(gameAction action)
        {
            int imgIndex = ((int)action) - 1;
            string img = imgs[imgIndex];
            return img;
        }
        private void ShowImg(Image img, string path)
        {
            BitmapImage imgS = new BitmapImage();
            var uri = new Uri($"\\Imges\\{path}", UriKind.RelativeOrAbsolute);
            imgS.BeginInit();
            imgS.UriSource = uri;
            imgS.EndInit();
            img.Source = imgS;
            
        }
        private void Round(gameAction pAction, gameAction cAction)
        {
            string cActionPathImg = GetActionImgs(cAction);
            string pActionPathImg = GetActionImgs(pAction);
            ShowImg(ComputerActionImage, cActionPathImg);
            ShowImg(PlayerActionImage, pActionPathImg);
            
            var winner = GetWinner(cAction, pAction);


            switch (winner)
            {
                case 0:
                    IsDraw();
                    break;
                case 1:
                    IsLose();
                    break;
                case 2:
                    IsWin();
                    break;
                default:
                    throw new Exception($"winner = {winner}");

            }

            ElementsIsEnabled(false, RoundBclockedElements);
        } 
        private void IsWin()
        {
            score.NumWins++;
            score.Winner = "player";
        }
        private void IsLose()
        {
            score.NumLoses++;
            score.Winner = "computer";
        }
        private void IsDraw()
        {
            score.NumDraws++;
            score.Winner = "draw";
        }

        public void CloseMWinow()
        {
            ElementsIsEnabled(true, BlockedAllElements);
            ElementsIsEnabled(false, BlockedReportElements);

            
            mWindow?.Close();
        }



        #endregion

        
    }
}
