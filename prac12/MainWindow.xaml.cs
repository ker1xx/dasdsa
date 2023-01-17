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
        public MainWindow()
        {
            InitializeComponent();
            Dater.Text = Convert.ToString(DateTime.Today);
        }

        private void Showinfo()
        {
            int selected_index = Display_Notes.SelectedIndex;
            try
            {
                List<Notes> SortedZam = y.Notes_list.Where(x => x.date.Date == Convert.ToDateTime(Dater.Text)).ToList();
                Name_Text.Text = SortedZam[selected_index].name;
                Description_Text.Text = SortedZam[selected_index].description;
            }
            catch (Exception e)
            {

            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            Read();
        }
        public void Read()
        {
            try
            {
                List<Notes> SortedZam = y.Notes_list.Where(x => x.date.Date == Convert.ToDateTime(Dater.Text)).ToList();
                Display_Notes.ItemsSource = SortedZam.Select(x => x.name);

            }
            catch (Exception e)
            {

            }
        }
        public void Update()
        {
            List<Notes> SortedZam = y.Notes_list.Where(x => x.date.Date == Convert.ToDateTime(Dater.Text)).ToList();
            int selected_index = Display_Notes.SelectedIndex;
            SortedZam[selected_index].name = Name_Text.Text;
            SortedZam[selected_index].description = Description_Text.Text;
            y.serialize(y.Notes_list, "Notes.json");
            Read();
        }
        public void Create()
        {
            string new_note_name = Name_Text.Text;
            string new_note_description = Description_Text.Text;
            DateTime new_note_date = Convert.ToDateTime(Dater.Text);
            Notes new_note = new(new_note_name, new_note_description, new_note_date);
            y.Notes_list.Add(new_note);
            y.serialize(y.Notes_list, "Notes.json");
            Read();
        }
        public void Delete()
        {
            string new_note_name = Name_Text.Text;
            string new_note_description = Description_Text.Text;
            DateTime new_note_date = Convert.ToDateTime(Dater.Text);
            Notes item = new(new_note_name, new_note_description, new_note_date);
            foreach (var note in y.Notes_list)
            {
                if (new_note_name == note.name)
                {
                    if (new_note_description == note.description)
                    {
                        if (new_note_date == note.date)
                        {
                            y.Notes_list.Remove(note);
                            y.serialize(y.Notes_list, "Notes.json");
                            return;
                        }
                    }
                }
            }

        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            y.serialize(y.Notes_list, "Notes.json");
            Update();
        }

        private void Dater_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Read();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();
        }

        private void Display_Notes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Showinfo();
        }
    }
}
