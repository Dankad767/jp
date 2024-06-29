namespace MauiApp1.zakladki
{
    public partial class HiraganaChars : ContentPage
    {
        private string[,] Hiragana;

        public HiraganaChars()
        {
            InitializeComponent();
            HiraganaCharsArray(); // Assuming this method is already defined
            DisplayHiragana();
        }
        private void HiraganaCharsArray()
        {
            Hiragana = new string[,]
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
        private void DisplayHiragana()
        {
            int numColumns = 5;
            int numRows = Hiragana.GetLength(0) / numColumns;

            for (int column = 0; column < numColumns; column++)
            {
                GridHiraganaChars.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < numRows; row++)
            {
                GridHiraganaChars.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            for (int i = 0; i < Hiragana.GetLength(0); i++)
            {
                int row = i / numColumns;
                int column = i % numColumns;

                string HiraganaValue = Hiragana[i, 0];
                string romanValue = Hiragana[i, 1];

                var HiraganaLabel = new Label
                {
                    Text = HiraganaValue,
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
                    Children = { HiraganaLabel, romanLabel }
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


                GridHiraganaChars.Children.Add(frame);
                Grid.SetColumn(frame, column);
                Grid.SetRow(frame, row);
            }
        }
    }
}
