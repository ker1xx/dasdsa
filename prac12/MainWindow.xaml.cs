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

namespace prac12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICRUD
    {
        DateTime Currentdate_ = DateTime.Now;
        private List<Notes> Notes_list = y.deserialize<List<Notes>>("Notes.json");
        public MainWindow()
        {
            InitializeComponent();

        }
        private  void ListCurrentDate()
        {
            List<Notes> sortedZam = y.Notes_list.Where(x => x.date.Date == Dater.DisplayDate).ToList();

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Read();
        }
        public void Read()
        {
            try
            {
                List<Notes> sortedZam = y.Notes_list.Where(x => x.date.Date == Dater.DisplayDate).ToList();
                ListBox.ItemsSource = sortedZam;
            }
            catch(Exception e)
            {

            }
        }
        public void Update()
        {

        }
        public void Create()
        {
            string new_note_name = Name_Text.Text;
            string new_note_description = Description_Text.Text;
            DateTime new_note_date = Dater.DisplayDate;
            Notes new_note = new(new_note_name, new_note_description, new_note_date);
            y.Notes_list.Add(new_note);
            Read();
        }
        public void Delete()
        {

        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
