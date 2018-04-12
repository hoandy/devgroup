Using System;
Using SwinGameSDK;

static class HighScoreController
{
    Private Const int NAME_WIDTH = 3;
    Private Const int SCORES_LEFT = 490;
    Private struct Score : IComparable
    {
        Public String Name;
        Public int Value;
        Public int CompareTo(Object obj)
        {
            If(obj Is Score)
            {
                Score other = (Score)obj;
                Return other.Value - this.Value;
            }
            Else
            {
                Return 0;
            }
        }
    }

    Private List<Score> _Scores = New List<Score>;
    Private void LoadScores()
    {
        String filename;
        filename = SwinGame.PathToResource("highscores.txt");
        StreamReader input;
        input = New StreamReader(filename);
        int numScores;
        numScores = Convert.ToInt32(input.ReadLine());
        _Scores.Clear();
        int i;
        For(i = 1; i <= numScores; i++)
        {
            Score s;
            String line;
            line = input.ReadLine();
            s.Name = line.Substring(0, NAME_WIDTH);
            s.Value = Convert.ToInt32(line.Substring(NAME_WIDTH));
            _Scores.Add(s);
        }

        input.Close();
    }

    Private void SaveScores()
    {
        String filename;
        filename = SwinGame.PathToResource("highscores.txt");
        StreamWriter output;
        output = New StreamWriter(filename);
        output.WriteLine(_Scores.Count);
        foreach (Score s in _Scores)
        {
            output.WriteLine(s.Name + s.Value);
        }

        output.Close();
    }

    Public void DrawHighScores()
    {
        Const int SCORES_HEADING = 40;
        Const int SCORES_TOP = 80;
        Const int SCORE_GAP = 30;
        If(_Scores.Count == 0)
            LoadScores();
        SwinGame.DrawText("   High Scores   ", Color.White, GameFont("Courier"), SCORES_LEFT, SCORES_HEADING);
        int i;
        For(i = 0; i <= _Scores.Count - 1; i++)
        {
            Score s;
            s = _Scores.Item(i);
            If(i < 9)
            {
                SwinGame.DrawText(" " + (i + 1) + ":   " + s.Name + "   " + s.Value, Color.White, GameFont("Courier"), SCORES_LEFT, SCORES_TOP + i * SCORE_GAP);
            }
            Else
            {
                SwinGame.DrawText(i + 1 + ":   " + s.Name + "   " + s.Value, Color.White, GameFont("Courier"), SCORES_LEFT, SCORES_TOP + i * SCORE_GAP);
            }
        }
    }

    Public void HandleHighScoreInput()
    {
        If(SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.VK_ESCAPE) || SwinGame.KeyTyped(KeyCode.VK_RETURN))
        {
            EndCurrentState();
        }
    }

    Public void ReadHighScore(int value)
    {
        Const int ENTRY_TOP = 500;
        If(_Scores.Count == 0)
            LoadScores();
        If(value > _Scores.Item(_Scores.Count - 1).Value)
        {
            Score s = New Score;
            s.Value = value;
            AddNewState(GameState.ViewingHighScores);
            int x;
            x = SCORES_LEFT + SwinGame.TextWidth(GameFont("Courier"), "Name: ");
            SwinGame.StartReadingText(Color.White, NAME_WIDTH, GameFont("Courier"), x, ENTRY_TOP);
            While(SwinGame.ReadingText())
            {
                SwinGame.ProcessEvents();
                DrawBackground();
                DrawHighScores();
                SwinGame.DrawText("Name: ", Color.White, GameFont("Courier"), SCORES_LEFT, ENTRY_TOP);
                SwinGame.RefreshScreen();
            }

            s.Name = SwinGame.TextReadAsASCII();
            If(s.Name.Length < 3)
            {
                s.Name = s.Name + New string((char)" ", 3 - s.Name.Length);
            }

            _Scores.RemoveAt(_Scores.Count - 1);
            _Scores.Add(s);
            _Scores.Sort();
            EndCurrentState();
        }
    }
}
