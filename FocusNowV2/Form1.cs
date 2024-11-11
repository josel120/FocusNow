using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using NodaTime;
using NodaTime.Extensions;
using System.Reflection.Metadata;
using System.Timers;
using System.Windows.Forms;

namespace FocusNowV2
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer aTimer;
        private int contador;
        private int contadorRetro;
        private int minutos;
        private int minutosRetro;
        private string minutosLabel;
        private string minutosLabelRetro;

        public Form1()
        {
            contador = 0; 
            contadorRetro = 60;

            minutos = 0;
            minutosRetro = 24;

            minutosLabel = "0";
            minutosLabelRetro = "25";

            InitializeComponent();
            // Initialize the timer in the constructor.
            aTimer = new System.Timers.Timer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTimer();
        }

        private void SetTimer()
        {

            // Create a timer with a one-second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aTimer.Stop();
        }

        private void OnTimedEvent(Object? source, ElapsedEventArgs e)
        {
            // Ensure this method is called on the UI thread.
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {

                    label1.Text = minutos < 10 ? minutosLabel + minutos.ToString() : minutos.ToString();
                    label1.Text += ":" + (contador < 10 ? "0" : "") + contador.ToString();

                    label2.Text = minutosRetro < 10 ? minutosLabelRetro + minutosRetro.ToString() : minutosRetro.ToString();
                    label2.Text += ":" + (contadorRetro == 60 ? "00" :(contadorRetro < 10 ? "0": "") + contadorRetro.ToString());

                    contadorRetro--;
                    contador++;
                    
                    if (contador == 60) { contador = 0; minutos++; minutosLabel = "0"; }
                    if (contadorRetro == 0) { contadorRetro = 60; minutosRetro--; minutosLabelRetro = "00"; }

                }));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            aTimer.Stop();
            label1.Text = "00:00";
            contador = 0;
            minutos = 0;
        }

        
    }
}
