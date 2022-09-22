using System;
using System.Collections.Generic;

namespace YPR_15
{
    struct Users
    {
        public string surname;
        public string name;
        public string patronymic;
        public string nomer;
        public string parol;
        public void show()
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3} {4}", surname, name, patronymic, nomer, parol);
        }

        public string concat()
        {
            string Familia = surname;
            string Name = name;
            int n = Name.Length;
            int k = n % 2;
            string Othesvo = patronymic;
            int m = Othesvo.Length;

            string Telefon = nomer;
            int t = Telefon.Length;
            string parol_zamen = Familia[0] + "" + Name[k + 1] + "" + Othesvo[m - 1] + "" + Telefon[t - 3] + "" + Telefon[t - 2] + "" + Telefon[t - 1];

            return surname + ";" + name + ";" + patronymic + ';' + nomer + ';' + parol_zamen;
        }
    }

    
    internal class Program
    {
        static void getData(string path, List<Users> L)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    L.Add(new Users()
                    {
                        surname = array[0],
                        name = array[1],
                        patronymic = array[2],
                        nomer = array[3],
                        parol = array[4]
                    });
                }
            }
        }
        static void printData(List<Users> L)
        {
            foreach (Users u in L)
            {
                u.show();
            }
        }
        static void inpData(string path, List<Users> L)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Users u in L)
                {
                    sw.WriteLine(u.surname);
                    sw.WriteLine(u.name);
                    sw.WriteLine(u.patronymic);
                    sw.WriteLine(u.nomer);

                    string Familia = u.surname;
                    string Name = u.name;
                    int n = Name.Length;
                    int k = n % 2;
                    string Othesvo = u.patronymic;
                    int m = Othesvo.Length;

                    string Telefon = u.nomer;
                    int t = Telefon.Length;
                    string parol_zamen = Familia[0] + "" + Name[k + 1] + "" + Othesvo[m - 1] + "" + Telefon[t - 3] + "" + Telefon[t - 2] + "" + Telefon[t - 1];

                    sw.WriteLine(parol_zamen);
                }
            }
        }

        static void inputData(string path, List<Users> L)
        {
            using(StreamWriter sw = new StreamWriter(path,true))
            {
                foreach (Users u in L)
                {
                    sw.WriteLine(u.concat());
                }
            }
        }

        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();
            getData("Книга1.csv", users);
            //printData(users);

            List<Users> Users_izmenenie = new List<Users>();
           
            //Users_izmenenie.AddRange(users);
            string paths = "Izmenenie.csv";
            //inputData(paths, Users_izmenenie);
            getData(paths, Users_izmenenie);
            printData(Users_izmenenie);

        }
    }
}