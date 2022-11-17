/*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
 * Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
Написать программу, демонстрирующую все разработанные элементы класса.*/ 

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

namespace ДЗ_5
{
    
    class Drob//Описание класса Drob
    {   
        public double c = 0;//числитель
        public double z = 0;//знаменатель

        public Drob(int c, int z)
        {
            this.c = c;
            this.z = z;

        }

        public override string ToString()//cтроковое представление
        {
            return  c.ToString() + "/" + z.ToString();
        }
       
        // сокращению дроби
        public static Drob Form(Drob a)
        {

            double max = 0;

            //выбираем что больше числитель или знаменатель
            if (a.c > a.z)
                max = Math.Abs(a.z);
            else
                max = Math.Abs(a.c);
                                    //поиск от максимума до 2
            for (double i = max; i >= 2; i--)
            {
                //такого числа, поделив на которое бы делилось без
                //остатка и на числитель и на знаменатель
                if ((a.c % i == 0) & (a.z % i == 0))
                {
                    a.c = a.c / i;
                    a.z = a.z / i;
                }

            }
            //Определяемся со знаком
            //если в знаменателе минус, поднимаем его наверх
            if ((a.z < 0))
            {
                a.c = -1 * (a.c);
                a.z = Math.Abs(a.z);
            }
            return (a);//возращаем результат
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//умножение 
        {
            string st1 = TX1.Text;
            string[] str1 = st1.Split("/");
            Drob a = new Drob(Convert.ToInt32(str1[0]), Convert.ToInt32(str1[1]));
            string st2 = TX2.Text;
            string[] str2 = st2.Split("/");
            Drob b = new Drob(Convert.ToInt32(str2[0]), Convert.ToInt32(str2[1]));
            Drob t = new Drob(1, 1);//создание и инициализация новой дроби
            t.c = a.c * b.c;//числитель новой дроби
            t.z = a.z * b.z;//знаменатель новой дроби
            Drob.Form(t);//сокращаем дробь
            RES.Text = t.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//деление
        {
            string st1 = TX1.Text;
            string[] str1 = st1.Split("/");
            Drob a = new Drob(Convert.ToInt32(str1[0]), Convert.ToInt32(str1[1]));
            string st2 = TX2.Text;
            string[] str2 = st2.Split("/");
            Drob b = new Drob(Convert.ToInt32(str2[0]), Convert.ToInt32(str2[1]));
            Drob t = new Drob(1, 1);//создание и инициализация новой дроби
            t.c = a.c * b.z;//числитель новой дроби
            t.z = a.z * b.c;//знаменатель новой дроби
            Drob.Form(t);//сокращаем дробь
            RES.Text = t.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//сложение
        {
            string st1 = TX1.Text;
            string[] str1 = st1.Split("/");
            Drob a = new Drob(Convert.ToInt32(str1[0]), Convert.ToInt32(str1[1]));
            string st2 = TX2.Text;
            string[] str2 = st2.Split("/");
            Drob b = new Drob(Convert.ToInt32(str2[0]), Convert.ToInt32(str2[1]));
            Drob t = new Drob(1, 1);//создание и инициализация новой дроби
            t.c = (a.c * b.z) + (a.z * b.c);//числитель новой дроби
            t.z = a.z * b.z;//знаменатель новой дроби
            Drob.Form(t);//сокращаем дробь
            RES.Text = t.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//вычетание
        {
            string st1 = TX1.Text;
            string[] str1 = st1.Split("/");
            Drob a = new Drob(Convert.ToInt32(str1[0]), Convert.ToInt32(str1[1]));
            string st2 = TX2.Text;
            string[] str2 = st2.Split("/");
            Drob b = new Drob(Convert.ToInt32(str2[0]), Convert.ToInt32(str2[1]));
            Drob t = new Drob(1, 1);//создание и инициализация новой дроби
            t.c = (a.c * b.z) - (a.z * b.c);//числитель новой дроби
            t.z = a.z * b.z;//знаменатель новой дроби
            Drob.Form(t);//сокращаем дробь
            RES.Text = t.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            RES.Text = "";
            TX1.Text = "";
            TX2.Text = "";
        }
    }
}
