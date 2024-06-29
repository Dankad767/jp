using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Threading.Tasks;

namespace MauiApp1.zakladki
{
    public partial class NewPage1 : ContentPage
    {
        private string[,] HiraganaChars;
        private Random random;
        private string currentHiragana;
        private string currentRomaji;
        private PointsActions database;
        private User CurrentUser { get; set; }

        // Parameterless constructor
        public NewPage1()
        {
            InitializeComponent();
            InitializeHiraganaArray();
            random = new Random();
        }

        // Constructor with parameters
        public NewPage1(PointsActions pointsActions, User user) : this()
        {
            database = pointsActions;
            CurrentUser = user;
            DisplayRandomHiragana();
            correct_counter.Text = $"Correct: {CurrentUser.Correct}";
            incorrect_counter.Text = $"Incorrect: {CurrentUser.Incorrect}";
            CurrentUser.Name = "Hiragana";
        }

        private void InitializeHiraganaArray()
        {
            HiraganaChars = new string[,]
            {
               { "あ", "a" }, { "い", "i" }, { "う", "u" }, { "え", "e" }, { "お", "o" },
               { "か", "ka" }, { "き", "ki" }, { "く", "ku" }, { "け", "ke" }, { "こ", "ko" },
               { "さ", "sa" }, { "し", "shi" }, { "す", "su" }, { "せ", "se" }, { "そ", "so" },
               { "た", "ta" }, { "ち", "chi" }, { "つ", "tsu" }, { "て", "te" }, { "と", "to" },
               { "な", "na" }, { "に", "ni" }, { "ぬ", "nu" }, { "ね", "ne" }, { "の", "no" },
               { "は", "ha" }, { "ひ", "hi" }, { "ふ", "fu" }, { "へ", "he" }, { "ほ", "ho" },
               { "ま", "ma" }, { "み", "mi" }, { "む", "mu" }, { "め", "me" }, { "も", "mo" },
               { "や", "ya" }, { "ゆ", "yu" }, { "よ", "yo" },
               { "ら", "ra" }, { "り", "ri" }, { "る", "ru" }, { "れ", "re" }, { "ろ", "ro" },
               { "わ", "wa" }, { "を", "wo" }, { "ん", "n" },
               { "が", "ga" }, { "ぎ", "gi" }, { "ぐ", "gu" }, { "げ", "ge" }, { "ご", "go" },
               { "ざ", "za" }, { "じ", "ji" }, { "ず", "zu" }, { "ぜ", "ze" }, { "ぞ", "zo" },
               { "だ", "da" }, { "ぢ", "ji" }, { "づ", "zu" }, { "で", "de" }, { "ど", "do" },
               { "ば", "ba" }, { "び", "bi" }, { "ぶ", "bu" }, { "べ", "be" }, { "ぼ", "bo" },
               { "ぱ", "pa" }, { "ぴ", "pi" }, { "ぷ", "pu" }, { "ぺ", "pe" }, { "ぽ", "po" }
            };
        }

        private async Task RefreshUserData()
        {
            CurrentUser = await database.GetPointsAsync(CurrentUser.Id);
            correct_counter.Text = $"Correct: {CurrentUser.Correct}";
            incorrect_counter.Text = $"Incorrect: {CurrentUser.Incorrect}";
        }

        private void DisplayRandomHiragana()
        {
            int index = random.Next(HiraganaChars.GetLength(0));
            currentHiragana = HiraganaChars[index, 0];
            currentRomaji = HiraganaChars[index, 1];
            HiraganaLabel.Text = currentHiragana;
            answerEntry.Text = string.Empty;
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string userAnswer = answerEntry.Text.Trim().ToLower();
            if (userAnswer == currentRomaji)
            {
                resultLabel.TextColor = Colors.Green;
                resultLabel.Text = "Correct!";
                CurrentUser.Correct++;
                correct_counter.Text = $"Correct: {CurrentUser.Correct}";
            }
            else
            {
                resultLabel.TextColor = Colors.Red;
                resultLabel.Text = $"Incorrect. The correct answer is {currentRomaji}.";
                CurrentUser.Incorrect++;
                incorrect_counter.Text = $"Incorrect: {CurrentUser.Incorrect}";
            }

            await database.SaveItemAsync(CurrentUser);
            await RefreshUserData();
            DisplayRandomHiragana();
        }

        async void redirectKatakana(object sender, EventArgs args)
        {
            var pointsActions = new PointsActions();
            var user = new User();
            await Navigation.PushAsync(new NewPage2(pointsActions, user));
        }
    }
}
