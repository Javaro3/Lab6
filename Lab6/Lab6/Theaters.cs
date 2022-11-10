using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Lab6
{
    public class Theaters
    {
        public List<string[]> Theater = new List<string[]> { };

        public void AddPerformance(string data, string kol, string genre, string name)
        {
            Theater.Add(new string[6] { data.Split('.')[0], data.Split('.')[1], data.Split('.')[2], kol, genre, name });
        }

        public bool CheckData(string data)
        {
            bool testString = Regex.IsMatch(Regex.Replace(data, " ", ""), @"\d\d.\d\d.\d\d") && data.Length == 8;
            if (testString)
            {
                bool testMonth = (Convert.ToInt32(data.Split('.')[1]) > 0 && Convert.ToInt32(data.Split('.')[1]) <= 12);
                bool testYear = (Convert.ToInt32(data.Split('.')[2]) >= 0 && Convert.ToInt32(data.Split('.')[2]) <= 22);
                bool testDay = ((new int[7] { 1, 3, 5, 7, 8, 10, 12 }).Contains(Convert.ToInt32(data.Split('.')[1])) && Convert.ToInt32(data.Split('.')[0]) <= 31)
                || (Convert.ToInt32(data.Split('.')[1]) == 2 && Convert.ToInt32(data.Split('.')[0]) <= 28) ||
                ((new int[4] { 4, 6, 9, 11 }).Contains(Convert.ToInt32(data.Split('.')[1])) && Convert.ToInt32(data.Split('.')[0]) <= 30);
                return testString && testMonth && testYear && testDay;  
            }
            return false;
        }

        public bool CheckKol(string kol)
        {
            return kol.All(char.IsDigit);
        }

        public bool CheckGenre(string genre)
        {
            return genre.All(char.IsLetter);
        }

        public bool CheckName(string name)
        {
            return !name.All(char.IsWhiteSpace);
        }

        public void GetDataByDate(string date, Label label)
        {
            string tmp = "";
            bool flag = false;
            for(int i = 0; i < Theater.Count; i++)
            {
                if(date == $"{Theater[i][0]}.{Theater[i][1]}.{Theater[i][2]}")
                {
                    tmp += $"{Theater[i][0]}.{Theater[i][1]}.{Theater[i][2]} {Theater[i][3]} {Theater[i][4]} {Theater[i][5]}";
                    tmp += "\n";
                    flag = true;
                }
            }
            if (flag)
            {
                label.Text = tmp;
            }
            else
            {
                label.Text = "В этот день ни чего не было";
            }
        }

        public void ShowAverageKolByGener(string leftDate, string rightDate, Label label)
        {
            string tmp = "";
            List<string> gener = new List<string> { };
            for(int i = 0; i < Theater.Count; i++)
            {
                if (!gener.Contains(Theater[i][4]) && CheckDateBetween(leftDate, rightDate, $"{Theater[i][0]}.{Theater[i][1]}.{Theater[i][2]}"))
                {
                    gener.Add(Theater[i][4]);
                }
            }
            if(gener.Count > 0)
            {
                for (int i = 0; i < gener.Count; i++)
                {
                    int kol = 0;
                    int sum = 0;
                    for (int j = 0; j < Theater.Count; j++)
                    {
                        if (gener[i] == Theater[j][4] && CheckDateBetween(leftDate, rightDate, $"{Theater[j][0]}.{Theater[j][1]}.{Theater[j][2]}"))
                        {
                            sum += Convert.ToInt32(Theater[j][3]);
                            kol++;
                        }
                    }
                    tmp += $"{gener[i]}: {sum / kol}\n";
                }
                label.Text = tmp;
            }
            else
            {
                label.Text = "В эти дни не было спектаклей";
            }
            
        }

        public void ShowMaxKolByGener(string leftDate, string rightDate, Label label)
        {
            List<string> gener = new List<string> { };
            for (int i = 0; i < Theater.Count; i++)
            {
                if (!gener.Contains(Theater[i][4]) && CheckDateBetween(leftDate, rightDate, $"{Theater[i][0]}.{Theater[i][1]}.{Theater[i][2]}"))
                {
                    gener.Add(Theater[i][4]);
                }
            }
            int[] sum = new int[gener.Count];
            if (gener.Count > 0)
            {
                for (int i = 0; i < gener.Count; i++)
                {
                    for (int j = 0; j < Theater.Count; j++)
                    {
                        if (gener[i] == Theater[j][4] && CheckDateBetween(leftDate, rightDate, $"{Theater[j][0]}.{Theater[j][1]}.{Theater[j][2]}"))
                        {
                            sum[i] += Convert.ToInt32(Theater[j][3]);
                        }
                    }
                }

                for (int i = 0; i < sum.Length; i++)
                {
                    for(int j = i + 1; j < sum.Length; j++)
                    {
                        if (sum[i] < sum[j])
                        {
                            var tmp1 = sum[i];
                            sum[i] = sum[j];
                            sum[j] = tmp1;
                            var tmp2 = gener[i];
                            gener[i] = gener[j];
                            gener[j] = tmp2;
                        }
                    }
                }
                label.Text = $"Жанр {gener[0]} самый популярный\nс количеством посещений {sum[0]}";
            }
            else
            {
                label.Text = "В эти дни не было спектаклей";
            }

        }

        public bool CheckDateBetween(string leftDate, string rightDate, string date)
        {
            var Ldate = new DateTime(Convert.ToInt32($"20{leftDate.Split('.')[2]}"), Convert.ToInt32(leftDate.Split('.')[1]), Convert.ToInt32(leftDate.Split('.')[0]));
            var Rdate = new DateTime(Convert.ToInt32($"20{rightDate.Split('.')[2]}"), Convert.ToInt32(rightDate.Split('.')[1]), Convert.ToInt32(rightDate.Split('.')[0]));
            var Ndate = new DateTime(Convert.ToInt32($"20{date.Split('.')[2]}"), Convert.ToInt32(date.Split('.')[1]), Convert.ToInt32(date.Split('.')[0]));       
            return Ndate >= Ldate && Ndate <= Rdate;
        }
    }
}
