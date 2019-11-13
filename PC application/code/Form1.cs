using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

using System.Diagnostics;
using System.Runtime.InteropServices;


namespace ir_pc_v1
{


    public partial class Form1 : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_MOVE = 0x0001;

        private int czuloscMyszy = 30;

        private BinaryWriter bw;
        private BinaryReader br;
        private string nazwa_pliku = "btn_conf.bin";


        private class Przycisk
        {
            public int kod { get; set; }
            public string nazwa { get; set; }

            public Przycisk(int p1, string p2)
            {
                kod = p1;
                nazwa = p2;
            }
        }

        public const int SLEEP = 0x5F;
        public const int MUTE = 0xAD;
        public const int VOLUME_DOWN = 0xAE;
        public const int VOLUME_UP = 0xAF;
        public const int NEXT_TRACK = 0xB0;
        public const int PREV_TRACK = 0xB1;
        public const int STOP = 0xB2;
        public const int PLAY_PAUSE = 0xB3;
        public const int EMPTY = 0x00;

        public const int MOUSE_UP = 0x100;
        public const int MOUSE_DOWN = 0x101;
        public const int MOUSE_RIGHT = 0x102;
        public const int MOUSE_LEFT = 0x103;
        public const int LMB = 0x104;
        public const int RMB = 0x105;
        public const int MMB = 0x106;
        public const int SENS_INC = 0x107;
        public const int SENS_DEC = 0x108;


        private const int liczba_przyciskow_IR = 21;
        private readonly int[] kody_przyciskow_IR = { 0x5D, 0x9D, 0x1D, 0xDD, 0xFD, 0x3D, 0x1F, 0x57, 0x6F, 0x97, 0x67, 0x4F, 0xCF, 0xE7, 0x85, 0xEF, 0xC7, 0xA5, 0xBD, 0xB5, 0xAD };
        private readonly Przycisk[] kody_przyciskow_PC = new[] {
                                                        new Przycisk(EMPTY, "BRAK"),
                                                        new Przycisk(PREV_TRACK, "Previous Track"),
                                                        new Przycisk(NEXT_TRACK, "Next Track"),
                                                        new Przycisk(PLAY_PAUSE, "Play/Pause"),
                                                        new Przycisk(VOLUME_DOWN, "Volume Down"),
                                                        new Przycisk(VOLUME_UP, "Volume Up"),
                                                        new Przycisk(MUTE, "Mute"),
                                                        new Przycisk(MOUSE_UP, "Mouse UP"),
                                                        new Przycisk(MOUSE_DOWN, "Mouse Down"),
                                                        new Przycisk(MOUSE_RIGHT, "Mouse Right"),
                                                        new Przycisk(MOUSE_LEFT, "Mouse Left"),
                                                        new Przycisk(LMB, "Left Mouse Button"),
                                                        new Przycisk(RMB, "Right Mouse Button"),
                                                        new Przycisk(MMB, "Middle Mouse Button"),
                                                        new Przycisk(SENS_INC, "++"),
                                                        new Przycisk(SENS_DEC, "--")
                                                        };


        private int[] przypisane_przyciski = {  0,  0,  0,
                                                1,  2,  3,
                                                4,  5,  6,
                                                0,  0,  0,
                                                13, 7,  12,
                                                10, 11, 9,
                                                14,  8, 15};

        delegate void dodajWiadomoscCallback(String wiadomosc);

        public Form1()
        {
            InitializeComponent();

            //ustawiane tutaj, ponieważ ustawienie tego w panelu elementu
            //powoduje, że uruchomiona aplikacja posiada dwie ikony na pasku zadań
            notifyIcon1.Visible = true;

            //sprawdź czy otwarty jest port szeregowy
            //i ustaw odpowiednio przyciski Połącz i Rozłącz
            if(serialPort1.IsOpen)
            {
                btnPolacz.Enabled = false; //dezaktywujemy przycisk Połącz
                btnRozlacz.Enabled = true; //aktywujemy przycisk Rozłącz
            }
            else
            {
                btnPolacz.Enabled = true;   //aktywujemy przycisk Połącz
                btnRozlacz.Enabled = false;  // deaktywujemy przycisk Rozłącz
            }

            szukajDostepnychPortow();

            //Dodaj dostępne predkości transmisji
            cmbBaudRate.Items.Add(2400);
            cmbBaudRate.Items.Add(9600);
            cmbBaudRate.Items.Add(19200);

            try
            {
                cmbCOM.SelectedIndex = 1;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                dodajWiadomosc("Nie znaleziono dostępnych portów");
            }

            try
            {
                cmbBaudRate.SelectedIndex = 2;
            }
            catch (ArgumentOutOfRangeException ex) 
            {
                dodajWiadomosc("Nie znaleziono dostępnych prędkości transmisji"); 
            }

            szukajDostepnychFunkcj();
        }

        /*
         * Zapisz obecną konfigurację przycisków w pliku
         */
        private void zapiszKonfiguracje()
        {
            try
            {
                bw = new BinaryWriter(new FileStream(nazwa_pliku, FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            try
            {
                for(int i = 0; i < przypisane_przyciski.Length; i++)
                {
                    bw.Write(przypisane_przyciski[i]);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();
            dodajWiadomosc("Zapisano nowa konfiguracje");
        }

        /*
         * Wczytaj konfigurację przycisków z pliku
         */
        private void wczytajKonfiguracje()
        {
            try
            {
                br = new BinaryReader(new FileStream(nazwa_pliku, FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }

            try
            {
                for (int i = 0; i < przypisane_przyciski.Length; i++)
                {
                    przypisane_przyciski[i] = br.ReadInt32();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();
            dodajWiadomosc("Wczytano nowa konfiguracje");
        }

        /*
         * Wyszukuje dostępne porty (COM) i wyświetla je w odpowiednim boxie.
         */
        private void szukajDostepnychPortow()
        {
            // Szybkie odczytanie wszystkich dostepnych portów COM
            string[] ports = SerialPort.GetPortNames();
            cmbCOM.Items.Clear();
            // Dodajemy wszystkie Porty do COMBOBOXA
            foreach (string port in ports)
            {
                cmbCOM.Items.Add(port);
            }
        }

        /*
         * Dodawanie dostępnych funkcji przycisków do listy wyboru
         */
        private void szukajDostepnychFunkcj()
        {
            foreach (Przycisk przycisk in kody_przyciskow_PC)
            {
                cmbBtn1.Items.Add(przycisk.nazwa);
                cmbBtn2.Items.Add(przycisk.nazwa);
                cmbBtn3.Items.Add(przycisk.nazwa);
                cmbBtn4.Items.Add(przycisk.nazwa);
                cmbBtn5.Items.Add(przycisk.nazwa);
                cmbBtn6.Items.Add(przycisk.nazwa);
                cmbBtn7.Items.Add(przycisk.nazwa);
                cmbBtn8.Items.Add(przycisk.nazwa);
                cmbBtn9.Items.Add(przycisk.nazwa);
                cmbBtn10.Items.Add(przycisk.nazwa);
                cmbBtn11.Items.Add(przycisk.nazwa);
                cmbBtn12.Items.Add(przycisk.nazwa);
                cmbBtn13.Items.Add(przycisk.nazwa);
                cmbBtn14.Items.Add(przycisk.nazwa);
                cmbBtn15.Items.Add(przycisk.nazwa);
                cmbBtn16.Items.Add(przycisk.nazwa);
                cmbBtn17.Items.Add(przycisk.nazwa);
                cmbBtn18.Items.Add(przycisk.nazwa);
                cmbBtn19.Items.Add(przycisk.nazwa);
                cmbBtn20.Items.Add(przycisk.nazwa);
                cmbBtn21.Items.Add(przycisk.nazwa);
            }

            ustawObecneFunkcje();
        }

        /*
         * Wyświetlenie obecnie ustawionych funkcji przycisków
         */
        private void ustawObecneFunkcje()
        {
            cmbBtn1.SelectedIndex = przypisane_przyciski[0];
            cmbBtn2.SelectedIndex = przypisane_przyciski[1];
            cmbBtn3.SelectedIndex = przypisane_przyciski[2];
            cmbBtn4.SelectedIndex = przypisane_przyciski[3];
            cmbBtn5.SelectedIndex = przypisane_przyciski[4];
            cmbBtn6.SelectedIndex = przypisane_przyciski[5];
            cmbBtn7.SelectedIndex = przypisane_przyciski[6];
            cmbBtn8.SelectedIndex = przypisane_przyciski[7];
            cmbBtn9.SelectedIndex = przypisane_przyciski[8];
            cmbBtn10.SelectedIndex = przypisane_przyciski[9];
            cmbBtn11.SelectedIndex = przypisane_przyciski[10];
            cmbBtn12.SelectedIndex = przypisane_przyciski[11];
            cmbBtn13.SelectedIndex = przypisane_przyciski[12];
            cmbBtn14.SelectedIndex = przypisane_przyciski[13];
            cmbBtn15.SelectedIndex = przypisane_przyciski[14];
            cmbBtn16.SelectedIndex = przypisane_przyciski[15];
            cmbBtn17.SelectedIndex = przypisane_przyciski[16];
            cmbBtn18.SelectedIndex = przypisane_przyciski[17];
            cmbBtn19.SelectedIndex = przypisane_przyciski[18];
            cmbBtn20.SelectedIndex = przypisane_przyciski[19];
            cmbBtn21.SelectedIndex = przypisane_przyciski[20];
        }

        /*
         * Dodaj wiadomość w okienku informacyjnym
         */
        private void dodajWiadomosc(String wiadomosc)
        {
            DateTime thisDay = DateTime.Now;

            if (this.textInfo.InvokeRequired)
            {
                dodajWiadomoscCallback d = new dodajWiadomoscCallback(dodajWiadomosc);
                this.Invoke(d, new object[] { wiadomosc });
            }
            else
            {
                textInfo.AppendText(thisDay.ToString("HH:mm:ss") + ": " + wiadomosc);
                textInfo.AppendText(Environment.NewLine);
                //przewiń na dół, do ostatniego wpisu, położenia kursora
                textInfo.ScrollToCaret();
            }
        }

        /*
         * Symulacja naciśnięcia przycisku na klawiaturze
         */
        private void nacisnijPrzycisk(byte kodPrzycisku)
        {
            keybd_event(kodPrzycisku, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(kodPrzycisku, 0, KEYEVENTF_KEYUP, 0);
        }


        /*
         * Symulacja naciśnięcia przycisku myszy
         */
        private void nacisnijMB(uint down_code, uint up_code)
        {
            mouse_event(down_code | up_code, 0, 0, 0, 0);
        }


        /*
         * Symulacja ruchu myszą o wartość x i y. Wartość względem obecnej pozycji kursora.
         */
        private void ruszMysza(int x, int y)
        {
            mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
        }

        /*
         * Zmiana rozdzielczosc z jaką symulowany jest ruch myszy
         */
        private void zmienCzulosc(int x)
        {
            czuloscMyszy += x;
        }




        private void sprawdzDane(byte dane)
        {
            for(int i = 0; i < kody_przyciskow_IR.Length; i++)
            {
                if (dane == kody_przyciskow_IR[i])
                {
                    int kod = kody_przyciskow_PC[przypisane_przyciski[i]].kod;
                    switch (kod)
                    {
                        case MOUSE_UP:
                            ruszMysza(0, -czuloscMyszy);
                            break;
                        case MOUSE_DOWN:
                            ruszMysza(0, czuloscMyszy);
                            break;
                        case MOUSE_RIGHT:
                            ruszMysza(czuloscMyszy, 0);
                            break;
                        case MOUSE_LEFT:
                            ruszMysza(-czuloscMyszy, 0);
                            break;
                        case LMB:
                            nacisnijMB(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
                            break;
                        case RMB:
                            nacisnijMB(MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP);
                            break;
                        case MMB:
                            nacisnijMB(MOUSEEVENTF_MIDDLEDOWN, MOUSEEVENTF_MIDDLEUP);
                            break;
                        case SENS_INC:
                            zmienCzulosc(5);
                            break;
                        case SENS_DEC:
                            zmienCzulosc(-5);
                            break;
                        case EMPTY:
                            break;
                        default:
                            nacisnijPrzycisk(Convert.ToByte(kody_przyciskow_PC[przypisane_przyciski[i]].kod));
                            break;
                    }
                    dodajWiadomosc(kody_przyciskow_PC[przypisane_przyciski[i]].nazwa);
                        
                    break;
                }
            }
            //switch(dane)
            //{
            //    case SLEEP:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Sleep");
            //        break;

            //    case MUTE:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Mute");
            //        break;

            //    case VOLUME_DOWN:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Volume Down");
            //        break;

            //    case VOLUME_UP:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Volume Up");
            //        break;

            //    case NEXT_TRACK:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Next Track");
            //        break;

            //    case PREV_TRACK:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Previous Track");
            //        break;

            //    case STOP:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Stop");
            //        break;

            //    case PLAY_PAUSE:
            //        nacisnijPrzycisk(dane);
            //        dodajWiadomosc("Play / Pause");
            //        break;

            //    default:
            //        dodajWiadomosc("Nieznana komenda");
            //        break;
            //}
        }

        private void przycisk1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello World");

            keybd_event(MUTE, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(MUTE, 0, KEYEVENTF_KEYUP, 0);

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                Show();
                this.WindowState = FormWindowState.Normal;

                //notifyIcon1.Visible = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar   
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                Hide();
                //notifyIcon1.Visible = true;
            }   
        }

        private void btnPolacz_Click(object sender, EventArgs e)
        {
            //sprawdzenie, czy uzytkownik wybrał możliwe parametry transmisji
            if(cmbCOM.SelectedIndex == -1 || cmbBaudRate.SelectedIndex == -1)
            {
                dodajWiadomosc("Nie wybrano wszystkich paramterów transmisji!");
            }
            else
            {
                //sprawdzenie, czy nie istnieje aktualnie połączenie
                //teoretycznie nie powinno dość do takiej sytuacji
                if (serialPort1.IsOpen)
                {
                    dodajWiadomosc("Aktualnie istnieje połączenie. Zakończ je, aby rozpocząć nowe.");
                }
                //rozpocznij nowe połączenie, ustaw wybrane parametry
                else
                {
                    //ustaw nazwę portu
                    serialPort1.PortName = cmbCOM.Text;
                    //ustaw prędkość transmisji
                    int rate;
                    Int32.TryParse(cmbBaudRate.Text, out rate);
                    serialPort1.BaudRate = rate;

                    //połącz
                    try
                    {
                        serialPort1.Open();

                        dodajWiadomosc("Połączono z " + serialPort1.PortName);

                        btnPolacz.Enabled = false; //dezaktywujemy przycisk Połącz
                        btnRozlacz.Enabled = true; //aktywujemy przycisk Rozłącz
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Błąd: " + ex.ToString());
                        dodajWiadomosc("Błąd połączenia, spróbuj ponownie");
                    }
                }
            }
        }

        private void btnRozlacz_Click(object sender, EventArgs e)
        {
            serialPort1.Close();             //Zamykamy SerialPort

            btnPolacz.Enabled = true;   //aktywujemy przycisk Połącz
            btnRozlacz.Enabled = false;  // deaktywujemy przycisk Rozłącz

            dodajWiadomosc("Rozłączono z " + serialPort1.PortName);
        }

        private void btnOdswiez_Click(object sender, EventArgs e)
        {
            szukajDostepnychPortow();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bajt = 0;
            try
            {
                bajt = serialPort1.ReadByte();
                //Console.WriteLine(Convert.ToByte(bajt));

                //sprzwdź czy odebrane dane, są ważne
                sprawdzDane(Convert.ToByte(bajt));                
            }
            catch (Exception) { }

        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            zapiszKonfiguracje();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            wczytajKonfiguracje();
            ustawObecneFunkcje();
        }

        private void cmbBtn1_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[0] = cmbBtn1.SelectedIndex;
        }

        private void cmbBtn2_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[1] = cmbBtn2.SelectedIndex;
        }

        private void cmbBtn3_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[2] = cmbBtn3.SelectedIndex;
        }

        private void cmbBtn4_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[3] = cmbBtn4.SelectedIndex;
        }

        private void cmbBtn5_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[4] = cmbBtn5.SelectedIndex;
        }

        private void cmbBtn6_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[5] = cmbBtn6.SelectedIndex;
        }

        private void cmbBtn7_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[6] = cmbBtn7.SelectedIndex;
        }

        private void cmbBtn8_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[7] = cmbBtn8.SelectedIndex;
        }

        private void cmbBtn9_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[8] = cmbBtn9.SelectedIndex;
        }

        private void cmbBtn10_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[9] = cmbBtn10.SelectedIndex;
        }

        private void cmbBtn11_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[10] = cmbBtn11.SelectedIndex;
        }

        private void cmbBtn12_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[11] = cmbBtn12.SelectedIndex;
        }

        private void cmbBtn13_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[12] = cmbBtn13.SelectedIndex;
        }

        private void cmbBtn14_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[13] = cmbBtn14.SelectedIndex;
        }

        private void cmbBtn15_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[14] = cmbBtn15.SelectedIndex;
        }

        private void cmbBtn16_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[15] = cmbBtn16.SelectedIndex;
        }

        private void cmbBtn17_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[16] = cmbBtn17.SelectedIndex;
        }

        private void cmbBtn18_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[17] = cmbBtn18.SelectedIndex;
        }

        private void cmbBtn19_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[18] = cmbBtn19.SelectedIndex;
        }

        private void cmbBtn20_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[19] = cmbBtn20.SelectedIndex;
        }

        private void cmbBtn21_SelectedIndexChanged(object sender, EventArgs e)
        {
            przypisane_przyciski[20] = cmbBtn21.SelectedIndex;
        }
    }
}
