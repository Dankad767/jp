namespace MauiApp1.zakladki
{
    public partial class KatakanaChars : ContentPage
    {
        private string[,] Katakana;

        public KatakanaChars()
        {
            InitializeComponent();
            KatakanaCharsArray(); // Assuming this method is already defined
            DisplayKatakana();
        }
        private void KatakanaCharsArray()
        {
            Katakana = new string[,]
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
        private void DisplayKatakana()
        {
            int numColumns = 5; 
            int numRows = Katakana.GetLength(0) / numColumns;

            for (int column = 0; column < numColumns; column++)
            {
                GridKatakanaChars.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < numRows; row++)
            {
                GridKatakanaChars.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto});
            }

            for (int i = 0; i < Katakana.GetLength(0); i++)
            {
                int row = i / numColumns;
                int column = i % numColumns;

                string katakanaValue = Katakana[i, 0];
                string romanValue = Katakana[i, 1];

                var katakanaLabel = new Label
                {
                    Text = katakanaValue,
                    FontSize = 24,
                    TextColor = Colors.White,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                var romanLabel = new Label
                {
                    Text = romanValue,
                    FontSize = 14,
                    TextColor = Colors.LightBlue,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
               

                var stackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    
                    Padding = new Thickness(5),
                    Children = { katakanaLabel, romanLabel }
                };
                var frame = new Frame
                {
                    Content = stackLayout,
                    BorderColor = Colors.BlueViolet,
                    CornerRadius = 5,
                    BackgroundColor = Colors.Black,
                    Padding = new Thickness(10),
                    Margin = new Thickness(5)
                };

              
                GridKatakanaChars.Children.Add(frame);
                Grid.SetColumn(frame, column);
                Grid.SetRow(frame, row);
            }
        }
    }
}
