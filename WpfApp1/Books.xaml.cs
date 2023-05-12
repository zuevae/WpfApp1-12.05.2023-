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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Books.xaml
    /// </summary>
    public partial class Books : Page
    {
        public Frame frame1;
        List<Книги> auto = new List<Книги>();

        public Books(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            auto = Entities.GetContext().Книги.ToList();
            Autos.ItemsSource = auto;
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            var poisk = Entities.GetContext().Книги.ToList();
            poisk = poisk.Where(p => p.Название.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            Autos.ItemsSource = poisk;
        }

        private async void Autos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(100);
            object j = Autos.SelectedItem;
            //frame1.Navigate(new update(frame1, j));
        }
    }
}
