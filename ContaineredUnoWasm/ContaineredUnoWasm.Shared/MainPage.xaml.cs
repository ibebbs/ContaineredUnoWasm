using ContaineredUnoWasm.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ContaineredUnoWasm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

        private Dictionary<string, string> _environmentVariables = new Dictionary<string, string>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Configuration = Platform.Services.LoadConfiguration();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Configuration)));

            _environmentVariables = Environment
                .GetEnvironmentVariables()
                .Cast<DictionaryEntry>()
                .ToDictionary(de => (string)de.Key, de => (string)de.Value);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Variables)));
        }

        public IEnumerable<KeyValuePair<string, string>> Variables => _environmentVariables;

        public Configuration Configuration { get; private set; }
    }
}
