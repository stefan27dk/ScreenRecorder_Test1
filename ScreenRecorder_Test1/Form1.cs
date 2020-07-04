using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenRecorder_Test1
{
    public partial class Form1 : Form
    {


        Stopwatch stopwatch = new Stopwatch(); 
        Thread record_Thread1;

        Thread record_Thread2;

        int current_FPS = 0;
        int stop = 0;


        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();



        // Recording Size
        Size CaptureSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            

        // Captured Frame
        Bitmap Frame_Bmp1;




        private void Timer_Settings()
        {
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Tick);
            timer1.Enabled = true;
           
        }




        void Tick(object sender, EventArgs e)
        {
            stop = 1;
        }

        

        public Form1()
        {
            InitializeComponent();
        }






        //LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer_Settings();


            record_Thread1 = new Thread(Update_FPS);
            record_Thread1.IsBackground = true;
            record_Thread1.Start();



            record_Thread2 = new Thread(Update_FPS);
            record_Thread2.IsBackground = true;
            record_Thread2.Start();

        }






        bool Is_First_Thread = false;

        bool Is_Thread_Working = false;   // FIRST THREAD
        bool Is_At_Middle = false;


        private void Update_FPS()
        {
           
            //TEST
            Invoke(new Action(() =>
            {
                timer1.Start();

            }));



             if(Is_First_Thread == true)
             {
                Thread.Sleep(10);
             }


              Is_First_Thread = true;






            while (stop!= 1) // TEST
            {


                if (Is_Thread_Working == true)
                {
                    while(Is_At_Middle != true)
                    {

                      Thread.Sleep(10);

                    }
                }



                Is_Thread_Working = true; // First Thread


                stopwatch.Start();   // TEST

                current_FPS++;




                // Image::::::START::::::::
                Frame_Bmp1 = new Bitmap(CaptureSize.Width, CaptureSize.Height); // BMP
                Graphics g = Graphics.FromImage(Frame_Bmp1); // Graphics

                Is_At_Middle = true;

                g.CopyFromScreen(Point.Empty, Point.Empty, CaptureSize); // Screen To BMP
                // Image::::::END::::::::



                //FPS
                Invoke(new Action(() =>
                {

                    fps_label.Text = current_FPS.ToString();
                }));



                // FPS
                Invoke(new Action(() =>
                {
                    stopwatch.Stop();
                    label1.Text = stopwatch.ElapsedMilliseconds.ToString();
                }));



                Is_At_Middle = false;
                Is_Thread_Working = false;

            }


            
        }



    }
}
