using System;
using System.IO;
using System.Text;

namespace baitapnhom
{
    class program
    {
        struct Info
        {
            /*public string name;
            public string age;
            public string CMND;
            public string phoneNumber;
            public string address;
            public string tinhtrang;
            public DateTime ngayvao;*/
            public string name;
            public string age;
            public string CMND;
            public string phonenumber;
            public string address;
            public string tinhtrang;
            public DateTime ngayvao;
        }
        static string path = @"D:\C#\data.txt";
        static void nhapthongtin(out Info TT)
        {
            string answer;
            Console.OutputEncoding = Encoding.UTF8;
            /* tạo file data.txt */
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            StreamWriter sw = new StreamWriter(fs);

            do
            {
                Console.WriteLine("Nhập tên bệnh nhân: ");
                Console.WriteLine("Nhập tuổi:");
                Console.WriteLine("Nhập CMND: ");
                Console.WriteLine("Nhập số điện thoại: ");
                Console.WriteLine("Nhập địa chỉ: ");
                Console.WriteLine("Nhập tình trạng bệnh nhân: ");
                Console.WriteLine("Nhập ngày vào cách ly(ngày / tháng / năm): ");
                Console.SetCursorPosition(20, 0);
                TT.name = Console.ReadLine();
                Console.SetCursorPosition(11, 1);
                TT.age = Console.ReadLine();
                Console.SetCursorPosition(11, 2);
                TT.CMND = Console.ReadLine();
                Console.SetCursorPosition(20, 3);
                TT.phonenumber = Console.ReadLine();
                Console.SetCursorPosition(14, 4);
                TT.address = Console.ReadLine();
                Console.SetCursorPosition(27, 5);
                TT.tinhtrang = Console.ReadLine();
                Console.SetCursorPosition(45, 6);
                TT.ngayvao = DateTime.Parse(Console.ReadLine());

                /* TT.ngayvao.ToString("dd/MM/yyyy"); */
                // ghi thông tin vào file data.txt 
                sw.WriteLine("****************************************************************");
                sw.WriteLine("Chứng minh nhân dân: {0}", TT.CMND.ToString());
                sw.WriteLine("Tên bệnh nhân: {0}", TT.name);
                sw.WriteLine("Tuổi: {0}", TT.age);
                sw.WriteLine("Số điện thoại: {0}", TT.phonenumber);
                sw.WriteLine("Địa chỉ: {0}", TT.address);
                sw.WriteLine("Tình trạng bệnh nhân: {0}", TT.tinhtrang);
                sw.WriteLine("Ngày vào khu cách ly {0} (ngày / tháng / năm):", TT.ngayvao);
                sw.WriteLine("***************************************************************");
                Console.Write("Bạn có muốn nhập tiếp không: \nCÓ(y)\nKHÔNG(n)\nChọn: ");
                answer = Console.ReadLine();
            } while (answer == "y");
            sw.Flush();
            sw.Close();
               
        }
        static void hienthif0()
        {
            StreamReader sr = new StreamReader(path);
            string[] list = File.ReadAllLines(path);
            string newList = sr.ReadToEnd();
            if (newList.IndexOf(" ") < 0)
                Console.WriteLine("Chưa có dữ liệu vui lòng nhập dữ liệu");
            else
            {
                if (newList.IndexOf("F0") < 0)
                    Console.WriteLine("Không có bệnh nhân F0");
                else
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        if (list[i].IndexOf("F0") > 0)
                        {
                            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", list[i - 5], list[i - 4], list[i - 3], list[i - 2], list[i - 1], list[i], list[i + 1]);
                        }
                    }
                }
            }
            sr.Close();
        }

        static void hienthif1()
        {
            StreamReader sr = new StreamReader(path);
            string[] list = File.ReadAllLines(path);
            string newList = sr.ReadToEnd();
            if (newList.IndexOf(" ") < 0)
                Console.WriteLine("Chưa có dữ liệu vui lòng nhập dữ liệu");
            else
            {
                if (newList.IndexOf("F1") < 0)
                    Console.WriteLine("Không có bệnh nhân F1");
                else
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        if (list[i].IndexOf("F1") > 0)
                        {
                            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", list[i - 5], list[i - 4], list[i - 3], list[i - 2], list[i - 1], list[i], list[i + 1]);
                        }
                    }
                }
                sr.Close();
            }
        }

        static void capnhat()
        {
            StreamReader sr = new StreamReader(path);
            string newList = sr.ReadToEnd();
            sr.Close();
            string[] list = File.ReadAllLines(path);
            DateTime dayvao;
            DateTime dayra;
            string catChuoi;
            string change;
            int count = 0;
            if (newList.IndexOf(" ") < 0)
                Console.WriteLine("Chưa có dữ liệu vui lòng nhập dũ liệu");
            else
            {
                for (int i = 6; i < list.Length; i = i + 8)
                {
                    if (list[i].IndexOf("khu") > 0)
                    {
                        if (list[i + 1].IndexOf("F1") > 0)
                            change = "F1";
                        else
                            change = "F0";
                        catChuoi = list[i+2].Substring(22, 10);
                        dayvao = DateTime.Parse(catChuoi);
                        dayra = DateTime.Now;
                        TimeSpan time = dayra - dayvao;
                        dayvao = DateTime.Parse(catChuoi).AddDays(14);
                        int Tongsongay = time.Days;
                        if (Tongsongay > 14)
                        {
                            if (list[i + 1].IndexOf(change) > 0)
                            {
                                count++;
                                Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\nĐược ra viện\n", list[i - 4], list[i - 3], list[i - 2], list[i - 1], list[i], list[i + 1], list[i+2]);
                                list[i - 1] = list[i - 1].Replace(change, "F");
                                if(list[i-5].IndexOf("----------------được ra viện")>0)
                                    { continue; }
                                list[i - 5] = list[i - 5] + " (----------------được ra viện !)";
                                File.WriteAllLines(path, list);
                            }
                        }
                    }
                }
                if (count == 0)
                    Console.WriteLine("Không có bệnh nhân được cập nhật");
            }
        }

        static void timthongtin(Info TT)
        {
            StreamReader sr = new StreamReader(path);
            string[] list = File.ReadAllLines(path);
            string newList = sr.ReadToEnd();
            if (newList.IndexOf(" ") < 0)
                Console.WriteLine("Chưa có dữ liệu. Vui lòng nhập dữ liệu");
            else
            {
                Console.Write("Nhập CMND: ");
                TT.CMND = Console.ReadLine();
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].IndexOf(TT.CMND) > 0)
                    {
                        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", list[i], list[i + 1], list[i + 2], list[i + 3], list[i + 4], list[i + 5], list[i + 6]);
                    }
                }
            }
            sr.Close();
        }

        static void showall()
        {
            StreamReader sr = new StreamReader(path);
            string show = sr.ReadToEnd();
            if (show.IndexOf(" ") < 0)
                Console.WriteLine("Chưa có dữ liệu vui lòng nhập dũ liệu");
            else
                Console.WriteLine(show);
            sr.Close();
        }

        static void menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("BẢNG MENU QUẢN LÝ BỆNH NHÂN KHU CÁCH LY");
            Console.WriteLine("===============================================");
            Console.WriteLine("1. Nhập thông tin người cách ly");
            Console.WriteLine("2. Hiển thị toàn bộ F0 có trong khu cách ly");
            Console.WriteLine("3. Hiển thị toàn bộ F1 có trong khu cách ly");
            Console.WriteLine("4. Cập nhật trạng thái của bệnh nhân");
            Console.WriteLine("5. Tìm thông tin người cách ly");
            Console.WriteLine("6. Hiện toàn bộ bệnh nhân có trong khu cách ly");
            Console.WriteLine("7. Thoát!!!");
            Console.WriteLine("===============================================");
            Console.Write("Chọn menu: ");
        }
        static void Main(string[] args)
        {

            Info TT1 = new Info();
            int chon;
            while (true)
            {
                menu();
                chon = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (chon)
                {
                    case 1:
                        nhapthongtin(out TT1);
                        Console.Clear();
                        break;
                    case 2:
                        hienthif0();
                        Console.WriteLine("Nhấn nút bất kì để về menu!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        hienthif1();
                        Console.WriteLine("Nhấn nút bất kì để về menu!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        capnhat();
                        Console.WriteLine("Nhấn nút bất kì để về menu!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        timthongtin(TT1);
                        Console.WriteLine("Nhấn nút bất kì để về menu!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        showall();
                        Console.WriteLine("Nhấn nút bất kì để về menu!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        Console.WriteLine("Bạn đã thoát!!!");
                        Console.WriteLine("Nhấn bất kì để thoát!");
                        break;
                    default:
                        Console.WriteLine("Nhập menu không hợp lệ!!!");
                        break;
                }
                if (chon == 7)
                    break;
            }
            Console.ReadKey();
        }
    }
}


