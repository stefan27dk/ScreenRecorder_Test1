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

        // TEST
        Stopwatch stopwatch = new Stopwatch(); 


        // Recorder - Thread 1
        Thread record_Thread1;


        //Recorder - Thread 2
        Thread record_Thread2;
        


        //Recorder - Thread 3
        Thread record_Thread3; 
        
        //Recorder - Thread 4
        Thread record_Thread4;  
        
        
        
        //Recorder - Thread 5
        Thread record_Thread5;
                      
        

        //Display Recording - Thread 
        Thread display_recording_Thread;
        bool ready_To_Display = false;



        // FPS
        int current_FPS = 0;
        int stop = 0; // TEST

         
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer(); // Test
        Bitmap LastImage; // Last image for disposing 
        Size CaptureSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Recording Size

            

        // Captured Frame
        Bitmap Frame_Bmp1;


        


        // TEST
        private void Timer_Settings()
        {
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Tick);
            timer1.Enabled = true;
           
        }



        // TEST
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
            Timer_Settings(); // TEST

            // Recording Thread 1
            record_Thread1 = new Thread(Update_FPS);
            record_Thread1.IsBackground = true;
            record_Thread1.Start();

            // Recording Thread 2
            record_Thread2 = new Thread(Update_FPS);
            record_Thread2.IsBackground = true;
            record_Thread2.Start();  
            
            
            // Recording Thread 3
            record_Thread3 = new Thread(Update_FPS);
            record_Thread3.IsBackground = true;
            record_Thread3.Start();


            // Recording Thread 4
            record_Thread4 = new Thread(Update_FPS);
            record_Thread4.IsBackground = true;
            record_Thread4.Start();     
            
            
            // Recording Thread 4
            record_Thread5 = new Thread(Update_FPS);
            record_Thread5.IsBackground = true;
            record_Thread5.Start();


            ////Display Recording Thread
            //display_recording_Thread = new Thread(Display_Recording);
            //display_recording_Thread.IsBackground = true;
            //display_recording_Thread.Start();




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



            if (Is_First_Thread == true)
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

                      Thread.Sleep(1);

                    }
                }



                Is_Thread_Working = true; // First Thread


                stopwatch.Start();   // TEST

                current_FPS++;



                ready_To_Display = false;
               // Image::::::START::::::::
               Frame_Bmp1 = new Bitmap(CaptureSize.Width, CaptureSize.Height); // BMP
                Graphics g = Graphics.FromImage(Frame_Bmp1); // Graphics
                Is_At_Middle = true;   
                g.CopyFromScreen(Point.Empty, Point.Empty, CaptureSize); // Screen To BMP
                                                                         // Image::::::END::::::::


                ready_To_Display = true;


                // Display::::::START:::::::
                Invoke(new Action(() =>
                {
                    Player_pictureBox.BackgroundImage = Frame_Bmp1;
                    Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                }));
                // Display::::::END:::::::







               // CLEAN:::::::START:::::::

                // Dispose Last Image
                if (Frame_Bmp1 != LastImage && LastImage != null)
                {
                    LastImage.Dispose();
                }

               // Assign Last Image
               LastImage = Frame_Bmp1;
                g.Dispose();

               // CLEAN:::::::END:::::::





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



        //private void Display_Recording()
        //{
        //    while(true)
        //    {
        //        Thread.Sleep(100);
        //        Invoke(new Action(() =>
        //        {
        //            Player_pictureBox.BackgroundImage = LastImage;
        //            Player_pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
        //            Player_pictureBox.Refresh();
        //        }));


        //        //CLEAN:::::::START:::::::

        //        // Dispose Last Image
        //        if (Frame_Bmp1 != LastImage && LastImage != null)
        //        {
        //            LastImage.Dispose();
        //        }

        //        // Assign Last Image 
        //        LastImage = Frame_Bmp1;
             
        //        //CLEAN:::::::END:::::::

        //    }


        //}




    }
}
