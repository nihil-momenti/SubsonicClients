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

using SubsonicApi;

namespace SubsonicMusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            var baseUri = BaseUriBox.Text;
            var username = UserBox.Text;
            var password = PassBox.Text;

            Result.Text = "";
            try {
                SubsonicClient client = new SubsonicClient(baseUri, username, password, "lol");
                var result = await client.GetIndexes();
                Result.Text = "Music:\n" + await Task.Run(() => IndexListToString(result));
            } catch (SubsonicApiException ex) {
                Result.Text = ex.ToString();
            }
        }

        private string IndexListToString(IndexList result) {
            return string.Join("\n", result.Shortcuts.Select(ShortcutToString).Concat(result.Indexes.Select(IndexToString)).Concat(result.Children.Select(ChildrenToString)));
        }

        private string ChildrenToString(Child arg) {
            return "Child: " + arg.Path;
        }

        private string IndexToString(Index arg) {
            return "Index: " + arg.Name + "\n  " + string.Join("\n  ", arg.Select(artist => artist.Name));
        }

        private string ShortcutToString(Shortcut arg) {
            return "Shortcut: " + arg.Name;
        }

        private string NowPlayingToString(NowPlaying info) {
            return string.Format("  User {0} listening to {1} from {2} by {3}", info.UserName, info.Title, info.Album, info.Artist);
        }
    }
}
