using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

namespace Example_Novator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataGridTextColumn col1 = new DataGridTextColumn();
        DataGridTextColumn col2 = new DataGridTextColumn();
        DataGridTextColumn col3 = new DataGridTextColumn();
        

        public MainWindow()
        {
            InitializeComponent();

            col1.Binding = new Binding("Second_Name");
            col2.Binding = new Binding("First_Name");
            col3.Binding = new Binding("Patr_Name");

            EmpGrid.Columns.Add(col1);
            EmpGrid.Columns.Add(col2);
            EmpGrid.Columns.Add(col3);

            col1.Header = "Фамилия";
            col2.Header = "Имя";
            col3.Header = "Отчество";

            col1.Width = 200;
            col2.Width = 200;
            col3.Width = 200;

            col2.CanUserSort = false;
            col3.CanUserSort = false;

            LoadData();
        }

        public void LoadData()
        {

            List<Employee> empList = new List<Employee>();
            using (NOVATOREntities db = new NOVATOREntities())
            {    
                var Emp = db.Employees;
                foreach (Employee i in Emp)
                    EmpGrid.Items.Add(i);
                db.SaveChanges();
            }
        }


        private void onClickDel(object sender, RoutedEventArgs e)
        { 
            try
            {
                Employee emp = (Employee)EmpGrid.SelectedItem;  
                using (NOVATOREntities db = new NOVATOREntities())
                {
                    var Em = db.Employees;
                    Em.Attach(emp);
                    Em.Remove(emp);
                    db.SaveChanges();
                }
                MessageBox.Show("Сотрудник удален", "Удаление сотрудника");
                EmpGrid.Items.Clear();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Выделите сотрудника, которого хотите удалить", "Удаление сотрудника");
            }


        }

        private void onClickCreate(object sender, RoutedEventArgs e)
        {
            SecondWindow sc = new SecondWindow(this);
            sc.Show();
        }
    }
}
