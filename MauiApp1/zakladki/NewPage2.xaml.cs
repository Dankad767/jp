using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiApp1.zakladki
{
    public partial class NewPage2 : ContentPage
    {
        private string[,] KatakanaChars;
        private Random random;
        private string currentKatakana;
        private string currentRomaji;
        private PointsActions database;
        private User CurrentUser { get; set; }

        // Parameterless constructor
        public NewPage2()
        {
            InitializeComponent();
            InitializeKatakanaArray();
            random = new Random();
        }

        // Constructor with parameters
        public NewPage2(PointsActions pointsActions, User user) : this()
        {
            database = pointsActions;
            CurrentUser = user;
            DisplayRandomKatakana();
            correct_counter.Text = $"Correct: {CurrentUser.Correct}";
            incorrect_counter.Text = $"Incorrect: {CurrentUser.Incorrect}";
            CurrentUser.Name = "Katakana";
        }

        private void InitializeKatakanaArray()
        {
            KatakanaChars = new string[,]
            {
                { "ア", "a" }, { "イ", "i" }, { "ウ", "u" }, { "エ", "e" }, { "オ", "o" },
                { "カ", "ka" }, { "キ", "ki" }, { "ク", "ku" }, { "ケ", "ke" }, { "コ", "ko" },
                { "サ", "sa" }, { "シ", "shi" }, { "ス", "su" }, { "セ", "se" }, { "ソ", "so" },
                { "タ", "ta" }, { "チ", "chi" }, { "ツ", "tsu" }, { "テ", "te" }, { "ト", "to" },
                { "ナ", "na" }, { "ニ", "ni" }, { "ヌ", "nu" }, { "ネ", "ne" }, { "ノ", "no" },
                { "ハ", "ha" }, { "ヒ", "hi" }, { "フ", "fu" }, { "ヘ", "he" }, { "ホ", "ho" },
                { "マ", "ma" }, { "ミ", "mi" }, { "ム", "mu" }, { "メ", "me" }, { "モ", "mo" },
                { "ヤ", "ya" }, { "ユ", "yu" }, { "ヨ", "yo" },
                { "ラ", "ra" }, { "リ", "ri" }, { "ル", "ru" }, { "レ", "re" }, { "ロ", "ro" },
                { "ワ", "wa" }, { "ヲ", "wo" }, { "ン", "n" },
                { "ガ", "ga" }, { "ギ", "gi" }, { "グ", "gu" }, { "ゲ", "ge" }, { "ゴ", "go" },
                { "ザ", "za" }, { "ジ", "ji" }, { "ズ", "zu" }, { "ゼ", "ze" }, { "ゾ", "zo" },
                { "ダ", "da" }, { "ヂ", "ji" }, { "ヅ", "zu" }, { "デ", "de" }, { "ド", "do" },
                { "バ", "ba" }, { "ビ", "bi" }, { "ブ", "bu" }, { "ベ", "be" }, { "ボ", "bo" },
                { "パ", "pa" }, { "ピ", "pi" }, { "プ", "pu" }, { "ペ", "pe" }, { "ポ", "po" }
            };
        }

        private async Task RefreshUserData()
        {
            CurrentUser = await database.GetPointsAsync(CurrentUser.Id);
            correct_counter.Text = $"Correct: {CurrentUser.Correct}";
            incorrect_counter.Text = $"Incorrect: {CurrentUser.Incorrect}";
        }

        private void DisplayRandomKatakana()
        {
            int index = random.Next(KatakanaChars.GetLength(0));
            currentKatakana = KatakanaChars[index, 0];
            currentRomaji = KatakanaChars[index, 1];
            KatakanaLabel.Text = currentKatakana;
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
            DisplayRandomKatakana();
        }

        async void redirectHiragana(object sender, EventArgs args)
        {
            var pointsActions = new PointsActions();
            var user = new User();
            await Navigation.PushAsync(new NewPage1(pointsActions, user));
        }
    }
}
