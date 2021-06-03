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
using System.Windows.Shapes;

namespace Example_Novator
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        MainWindow window;
        public SecondWindow(MainWindow window)
        {
            this.window = window;
            InitializeComponent();
        }
        private void onClickSave(object sender, RoutedEventArgs e)
        {
            
            Employee emp = new Employee();
            emp.First_Name = this.Name.Text;
            emp.Second_Name = this.Second_Name.Text;
            emp.Patr_Name = this.Patr_Name.Text;
            try
            {
                using (NOVATOREntities db = new NOVATOREntities())
                {
                    var Em = db.Employees;
                    int max = Em.Max(Employee => Employee.ID_Employee);
                    emp.ID_Employee = max + 1;
                    Em.Add(emp);
                    db.SaveChanges();
                }
                MessageBox.Show("Сотрудник добавлен", "Добавление сотрудника");
                window.EmpGrid.Items.Clear();
                window.LoadData();
            }

            catch
            {

            }
            this.Close();

        }
    }
}
