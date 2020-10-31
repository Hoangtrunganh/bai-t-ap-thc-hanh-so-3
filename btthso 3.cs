using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace BTH_3___4
{
    // bai 1- BTH3
    class PhanSo
    {
        private int ts, ms;
        public PhanSo()
        {
            ts = 0; ms = 1;
        }
        public PhanSo(int ts, int ms)
        {
            this.ts = ts;
            this.ms = ms;

        }
        public void Nhap()
        {
            Console.Write("Nhap tu so:");
            ts = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so:");
            ms = int.Parse(Console.ReadLine());
        }
        public void Hien()
        {
            if (ms == 1)
                Console.WriteLine("{0}", ts);
            else
                Console.WriteLine("{0}/{1}", ts, ms);
        }
        public int USCLN(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (x != y)
            {
                if (x > y) x = x - y;
                if (y > x) y = y - x;
            }
            return x;
        }
        public PhanSo Rutgon()
        {
            int uc = USCLN(this.ts, this.ms);
            this.ts = this.ts / uc;
            this.ms = this.ms / uc;
            return this;
        }
        public PhanSo Tong(PhanSo t2)
        {
            PhanSo t = new PhanSo();
            t.ts = this.ts * t2.ms + this.ms * t2.ts;
            t.ms = this.ms * t2.ms;
            return t.Rutgon();
        }
        public PhanSo Hieu(PhanSo t2)
        {
            PhanSo t = new PhanSo();
            t.ts = this.ts * t2.ms - t2.ts * this.ms;
            t.ms = this.ms * t2.ms;
            return t;
        }

        public static bool operator ==(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms == t2.ts * t1.ms;
        }
        public static bool operator !=(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms != t2.ts * t1.ms;
        }

        public static bool operator >(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms > t2.ts * t1.ms;
        }
        public static bool operator <(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms < t2.ts * t1.ms;
        }
    }
    class APP
    {
        static void Main2()
        {
            PhanSo t1 = new PhanSo(6, 8);
            PhanSo t2 = new PhanSo(7, 10);
            Console.Write(" Tong 2 phan so la: ");
            PhanSo t = t1.Tong(t2);
            t.Hien();
            Console.Write(" Hieu 2 phan so la: ");
            PhanSo t3 = t1.Hieu(t2);
            t3.Hien();
        }
    }
}
// bai 3 - BTH 3
class Time
{
    private int gio;
    private int phut;
    private int giay;
    public Time()
    {
        this.gio = 0;
        this.phut = 0;
        this.giay = 0;
    }
    public Time(int gio, int phut, int giay)
    {
        this.gio = gio;
        this.phut = phut;
        this.giay = giay;
    }
    public int Gio
    {
        get
        { return gio; }
        set
        { gio = value; }
    }
    public int Phut
    {
        get
        { return phut; }
        set
        { phut = value; }
    }
    public int Giay
    {
        get
        { return giay; }
        set
        { giay = value; }
    }
    public void normlize(int gio, int phut, int giay)
    {
        phut += giay % 60;
        giay = giay % 24;
        gio += phut / 60;
    }
    public Time advance(int gio, int phut, int giay)
    {
        Time t = new Time();
        t.gio = this.gio + gio;
        t.phut = this.phut + phut;
        t.giay = this.giay + giay;
        t.giay = t.giay % 60;
        t.phut = t.giay / 60;
        t.gio = t.phut / 60;
        t.phut = t.phut % 60;
        t.gio = t.gio % 24;
        return t;
    }
    public void Hien()
    {
        Console.WriteLine("Thoi gian hien hanh:{0}:{1}:{2},gio, phut, giay");
    }
}

//bai 4-BTH 3
class HocSinh
{
    private string s;
    private double dt, dl, dh;
    public void nhap()
    {
        Console.Write("Nhap ho ten:");
        s = Console.ReadLine();
        Console.Write("nhap diem toan:");
        dt = double.Parse(Console.ReadLine());
        Console.Write("Nhap diem Ly");
        dl = double.Parse(Console.ReadLine());
        Console.Write("Nhap diem Hoa:");
        dh = double.Parse(Console.ReadLine());
    }
    public void Hien()
    {
        Console.Write("Thong tin can hien thi:");
        Console.WriteLine("Ho ten:{0}", s);
        Console.WriteLine("Diem Ly:{0}", dl);
        Console.WriteLine("Diem Hoa:{0}", dh);
        Console.WriteLine("Diem Toan:{0}", dt);
    }
    public Double tdl
    {
        set
        { dl = value; }
        get
        { return dl; }
    }
    public Double tdh
    {
        set
        { dh = value; }
        get
        { return dh; }
    }
    public Double tdt
    {
        set
        { dt = value; }
        get
        { return dt; }
    }

}

// bai 5 - BTH 3
class Vecto
{
    private int n;
    private int[] v;
    public Vecto()
    {
        n = 2;
        v = new int[2];
    }
    public Vecto(int n)
    {
        this.n = n;
        v = new int[n];
    }
    public void Nhap()
    {
        Console.WriteLine("Nhap thong tin cua vecto");
        for (int i = 0; i < n; ++i)
        {
            Console.Write("v[{0}]=", i);
            v[i] = int.Parse(Console.ReadLine());
        }
    }
    public void Hien()
    {
        Console.WriteLine("Thong tin cua vecto");
        for (int i = 0; i < n; ++i)
            Console.Write("{0},", i);
    }
    public Vecto Tong(Vecto t2)
    {
        if (this.n == t2.n)
        {
            Vecto t = new Vecto(this.n);
            for (int i = 0; i < n; ++i)
                t.v[i] = this.v[i] + t2.v[i];
            return t;
        }
        else return null;
    }
    public Vecto Hieu(Vecto t2)
    {
        if (this.n == t2.n)
        {
            Vecto t = new Vecto(this.n);
            for (int i = 0; i < n; ++i)
                t.v[i] = this.v[i] - t2.v[i];
            return t;
        }
        else return null;
    }
    public void Saochep(Vecto m)
    {
        n = m.n;
        for (int i = 0; i < n; i++)
        {
            this.v[i] = m.v[i];
        }
    }
    class App
    {
        static void Main()
        {
            Console.WriteLine("Nhap thong tin cho vecto thu nhat");
            Vecto t1 = new Vecto(9); t1.Nhap();
            Console.WriteLine("Nhap thong tin cho vecto thu nhat");
            Vecto t2 = new Vecto(9); t2.Nhap();
            Console.WriteLine("Tong hai vecto");
            Vecto t3 = t1.Tong(t2);
            if (t3 == null)
                Console.WriteLine("Khong tinh tong duc vi hai vecto co kich thuoc khong bang nhau");
            else
            {
                Console.WriteLine("Tong hai vecto");
                t3.Hien();
            }


        }
    }

 177  BTH 4.txt 
@@ -0,0 +1,177 @@
// bai 1- BTH 4
class MaTran
    {
        private int m, n;
        private int[,] a;
        public MaTran()
        {
            m = n = 2;
            a = new int[m, n];
        }
        public MaTran(int m, int n)
        {
            this.m = m;
            this.n = n;
            a = new int[m, n];
        }
        public MaTran(MaTran a1)
        {
            this.m = a1.m;
            this.n = a1.n;
            this.a = new int[m, n];
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    this.a[i, j] = a1.a[i, j];
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap thong tin cho cac phan tu cua ma tran");
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("a[{0},{1}]=", i, j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
        }
        public void hien()
        {
            Console.WriteLine("cac phan tu cua ma tran la:");
            for (int i = 0; i < m; ++i) ;
            {
                for (int j = 0; j < n; ++j)
                    Console.Write("{0}", a[i, j]);
                Console.WriteLine();
            }
        }
        public MaTran tong(MaTran a1)
        {
            if (this.m == a1.m && this.n == a1.n)
            {
                MaTran t = new MaTran(this.m, this.n);
                for (int i = 0; i < t.m; ++i)
                    for (int j = 0; j < t.n; ++j)
                        t.a[i, j] = this.a[i, j] + a1.a[i, j];
                return t;

            }
            else return null;
        }
    }
    class cuoi
    {
        static void Main()
        {
            Console.WriteLine("Nhap Thong tin cho ma tran thu nhat");
            MaTran t1 = new MaTran(4, 5);
            t1.Nhap();
            Console.WriteLine("Nhap thong tin cho ma tran thu 2");
            MaTran t2 = new MaTran(t1);
            MaTran t3 = t1.tong(t2);
            if (t3 == null)
                Console.WriteLine("Hai ma tran co kich thuoc khac nhau khong the tinh tong");
            else
            {
                Console.WriteLine("Thong tin cua ma tran tong");
                t3.hien();
            }
        }
    }

    //bai 2-BTH 4
    class NhanVien
    {
        private string hoten;
        private string quequan;
        private double hesoluong;
        private static int manv = 0;
        private static int luongcoban = 1050;
        public NhanVien()
        {
            manv++;
        }
        public static int Luongcoban
        {
            get { return luongcoban; }
            set
            {
                if (value > 1050) luongcoban = value;
            }
        }
        public string Hoten
        {
            get
            {
                int n = hoten.LastIndexOf(" ");
                return hoten.Substring(n + 1) + "" + hoten.Substring(0, n);
            }
        }
        public double Hesoluong
        {
            get { return hesoluong; }
        }
        public void nhap()
        {
            Console.Write("Ho ten");
            hoten = Console.ReadLine();
            Console.Write("Que quan");
            quequan = Console.ReadLine();
            Console.Write("He so luong");
            hesoluong = double.Parse(Console.ReadLine());
        }
        public void Hien()
        {
            Console.WriteLine("{0} {1} {2} {3}", manv, hoten, quequan, hesoluong);
        }
        public double Luong
        {
            get { return hesoluong * luongcoban; }
        }
    }
    class QLNV
    {
        private int snv;
        private NhanVien[] ds;
        public void Nhap()
        {
            Console.Write("nhap so nhan vien");
            snv = int.Parse(Console.ReadLine());
            ds = new NhanVien[snv];
        }
        public void Hien()
        {
            for (int i = 0; i < snv; ++i)
                ds[i].Hien();
        }
        public double MaxHSl()
        {
            double max = MaxHSl();
            for (int i = 0; i < snv; ++i)
                if (ds[i].Hesoluong == max)
                    ds[i].Hien();
        }
        public void Sapxep()
        {
            for (int i = 0; i < snv - 1; ++i)
                for (int j = i + 1; j < snv; ++j)
                    if (string.Compare(ds[i].Hoten, ds[j].Hoten) > 0)
                    {
                        NhanVien tg = ds[i];
                        ds[i] = ds[j];
                        ds[j] = tg;
                    }
        }
    }
    class ma
    {
        static void Main()
        {
            QLNV t = new QLNV();
            t.Nhap();
            t.Hien();
            Console.WriteLine("Nhan vien sau khi sap xep");
            t.Sapxep();
            t.Hien();
        }
    }