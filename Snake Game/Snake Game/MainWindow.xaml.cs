using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Snake_Game
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<GridValue, ImageSource> GridValToImage = new Dictionary<GridValue, ImageSource>()
        {
            {GridValue.Empty,Images.Empty },
            {GridValue.Snake,Images.Body },
            {GridValue.Food,Images.Food }
        };
        private readonly int rows = 20,cols = 20;
        private readonly Image[,] GridImages;
        private GameState gamestate;
        private bool GameRunning;

        public MainWindow()
        {
            InitializeComponent();
            GridImages = SetupGrid();
            gamestate = new GameState(rows,cols);
        }

        private async Task RunGame() 
        {
            Draw();
            await ShowCountDown();
            Overlay.Visibility = Visibility.Hidden;
            await GameLoop();
            await ShowGameOver();
            gamestate = new GameState(rows, cols);
        }
        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(Overlay.Visibility == Visibility.Visible)
            {
                e.Handled = true;
            }
            if (!GameRunning)
            {
                GameRunning = true;
                await RunGame();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(gamestate.IsGameOver)
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Left:
                    gamestate.ChangeDirection(Direction.Left); break;
                case Key.Right:
                    gamestate.ChangeDirection(Direction.Right); break;
                case Key.Up:
                    gamestate.ChangeDirection(Direction.Up);break;
                case Key.Down:
                    gamestate.ChangeDirection(Direction.Down);break;

            }
        }
        private async Task GameLoop()
        {
            while(!gamestate.IsGameOver)
            {
                await Task.Delay(100);
                gamestate.Move();
                Draw();
            }
        }

        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;
            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    Image image = new Image
                    {
                        Source = Images.Empty
                    };

                    images[r, c] = image;
                    GameGrid.Children.Add(image);
                }
            }
            return images;
        }
        private void Draw()
        {
            DrawGrid();
            ScoreText.Text = $"Score:{gamestate.Score}";
        }



        private void DrawGrid()
        {
            for(int r = 0;r < rows; r++)
            {
                for( int c = 0; c < cols; c++)
                {
                    GridValue gridval = gamestate.Grid[r, c];
                    GridImages[r, c].Source = GridValToImage[gridval];
                }
            }
        }
        private async Task ShowCountDown()
        {
            for(int i = 3; i >= 1; i--)
            {
                OverlayText.Text = i.ToString();
                await Task.Delay(500);
            }
        }
        private async Task ShowGameOver()
        {
            await Task.Delay(500);
            GameRunning = false;
            Overlay.Visibility = Visibility.Visible;
            OverlayText.Text = "Press Any Key To Start";
        }
    }
}
