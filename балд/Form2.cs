using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace балд
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Функция добавления в список слов введенного слова, а также подсчет очков.
        static void listadd(ref bool player, ListBox lst1, ListBox lst2, string rts, ref int q1, ref int q2)
        {
            if (player)
            {
                lst1.Items.Add(rts);
                player = false;
                q1 += rts.Length;
            }
            else
            {
                lst2.Items.Add(rts);
                player = true;
                q2 += rts.Length;
            }
        }
        static void pastedm(ref string[][] A, DataGridView dtg)//Присвоение А элементов datagridview
        {
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A[i].Length; j++)
                    A[i][j] = dtg.Rows[i].Cells[j].Value as string;
        }

        cellselectedcheck(dataGridView1, A, ref selectij, cc);//Проверка на адекватное выделение
            if (selectij)//Если правильно выделено...
            {
                if (startwinp)//Если буква использована
                {
                    if (cc > 0)//Если вообще что-то выделено
                        for (int i = 0; i < cc; i++)//строке str=значение выделеных ячеек
                            str += dataGridView1.SelectedCells[i].Value;
                    for (int i = str.Length - 1; i >= 0; i--)//Переопределяем str в rts
                        rts += str[i];
                    xx = x.Split(' ');//Разбиваем наш массив использованных слов по пробелам
                    maincheck(filename2, xx, ref x, rts);
                    inp = true;//Разрешаем ввод
                    bap(A, ref B);
                    //Вводим очки
                    textBox3.Text = Convert.ToString(q1);
                    textBox4.Text = Convert.ToString(q2);
                    bool winner = false;//Инциализируем переменную для конца игры
                    for (int i = 0; i < A.Length; i++)
                        for (int j = 0; j < A[i].Length; j++)
                            if (A[i][j] == " ")
                            {
                                winner = false;
                                break;
                            }
                    if (winner)//Если пустых мест нет
                    {
                        //Открываем файл с рекордами
                        StreamReader rr = new StreamReader(filename2);
                        if (q1 > q2)//Если у первого игрока больше баллов, чем у второго
                        {
                            MessageBox.Show("Победитель - 1" + label1.Text, "Конец");
                        }
                        else if (q1 < q2)
                        {
                            MessageBox.Show("Победитель - " + label2.Text, "Конец");
                        }
                        else
                        {
                            MessageBox.Show("Ничья", "Конец");
                        }
                        rr.Close();
                    }
                }
                else//если ошибка в использовании буквы
                {
                    MessageBox.Show("Вы пытаетесь ввести слово, не вписав букву, или не использовав ее?", "Ошибка");
                    for (int i = 0; i < A.Length; i++)
                        for (int j = 0; j < A[i].Length; j++)
                            if (A[i][j] != dataGridView1.Rows[i].Cells[j].Value as string)
                                dataGridView1.Rows[i].Cells[j].Value = " ";
                    inp = true;
                }
            }
            else//Если слово выделяли неправильно
            {
                MessageBox.Show("Вы выделяете буквы как попало", "Ошибка");
                for (int i = 0; i < A.Length; i++)
                    for (int j = 0; j < A[i].Length; j++)
                        if (A[i][j] != dataGridView1.Rows[i].Cells[j].Value as string)
                            dataGridView1.Rows[i].Cells[j].Value = " ";
                inp = true;
            }
        }
    }
}
