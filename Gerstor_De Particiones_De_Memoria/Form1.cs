#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Gerstor_De_Particiones_De_Memoria.Models;
#endregion

namespace Gerstor_De_Particiones_De_Memoria
{
    public partial class Form1 : Form
    {
        int memoryTotalSpace = 16384;
        int memoryOS = 2048;
        int indexPartitionType = 0;
        int indexAlgorithmType = 0;
        String[] itemsProcessPending = { "Calculadora (128KB)", "Chrome (8192KB)", "Explorador (512KB)", "NotePad (2048KB)", "Paint (512KB)", "PowerPoint (2048KB)", "Recortes (256KB)", "Skype (4096KB)", "Teams (4096KB)", "Word (1024KB)" };
        String[] itemsMemoryModel = { "Particiones estaticas fijas", "Particiones estaticas variables", "Particiones dinamicas", "Segmentación", "Paginación" };
        String[] itemsAlgortihm = { "Primer ajuste", "Mejor ajuste", "Peor ajuste" };
        String[] itemsProcessActive = { };
        List<MemorySpace> memorySpaces = new List<MemorySpace>();
        MemorySpace[] partitions = { };

        private static Graphics gLienzo;  // La superficie de dibujo del control
        private static Graphics gImagen;  // La superficie del doble buffer que se implementa para evitar el parpadeo
        private Bitmap bitmap;  // Es el Doble Buffer


        public Form1()
        {
            InitializeComponent();

            

            listPending.DataSource = itemsProcessPending;
            comboMemoryModel.DataSource = itemsMemoryModel;
            comboAssignAlgortihm.DataSource = itemsAlgortihm;
            listProcessActive.DataSource = itemsProcessActive;

        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            itemsProcessActive = new List<string>().ToArray();
            listProcessActive.DataSource = itemsProcessActive;
            drawImage();
        }

        private void drawImage()
        {
            gLienzo = panelRam.CreateGraphics();
            bitmap = new Bitmap(1025, 220);
            gImagen = Graphics.FromImage(bitmap);
            gImagen.Clear(panelRam.BackColor);
            gImagen.FillRectangle(new SolidBrush(Color.GreenYellow), 0, 0, 1024, 200);
            gImagen.DrawRectangle(new Pen(Color.Black), 0, 0, 128, 200);
            gImagen.FillRectangle(new SolidBrush(Color.LightGoldenrodYellow), 0, 0, 128, 200);
            indexPartitionType = comboMemoryModel.SelectedIndex;
            indexAlgorithmType = comboAssignAlgortihm.SelectedIndex;
            memorySpaces = new List<MemorySpace>();
            switch (indexPartitionType)
            {
                case 0:
                    drawPartitionalFixed();
                    for (int i = 0; i < 7; i++)
                    {
                        memorySpaces.Add(new MemorySpace { TotalSpace = 2048});
                    }
                    break;
                case 1:
                    drawPartitionalVar();
                    break;
                case 2:
                    drawPartitionalDynamic();
                    memorySpaces.Add(new MemorySpace { TotalSpace = memoryTotalSpace - memoryOS });
                    break;
                case 3:
                    drawPartitionalSegment();
                    break;
                case 4:
                    drawPartitionalPages();
                    break;
            }

            gImagen.DrawRectangle(new Pen(Color.Black), 0, 0, 1025, 200);
            //Volcamos la imagen generada al panel 
            gLienzo.DrawImage(bitmap, new Point(0, 0));
            //gImagen.Dispose();
            //bitmap.Dispose();
        }

        private void drawPartitionalFixed()
        {
            for(int i = 0; i < 7; i++)
            {
                //gImagen.FillRectangle(new SolidBrush(Color.Red), 128 * i, 0, (128 * i) + 128, 200);
                gImagen.DrawRectangle(new Pen(Color.Black), 128 * i, 0, 128, 200);
            }
        }

        private void drawPartitionalVar()
        {

        }

        private void drawPartitionalDynamic()
        {
            gImagen.DrawRectangle(new Pen(Color.Black), 128, 0, 896, 200);
        }

        private void drawPartitionalSegment()
        {

        }

        private void drawPartitionalPages()
        {

        }

        private int indexSelectAdjust(int spaceProcess = 128)
        {
            int indexAdjust = 0;
            switch (indexAlgorithmType)
            {
                case 0:
                    indexAdjust = memorySpaces.FindIndex(x => x.UsedSpace == false);
                    break;
                case 1:
                    int positionOpt = -1;
                    int weigthOpt = 0;
                    for(int i = 0; i < memorySpaces.Count; i++)
                    {
                        if(memorySpaces[i].UsedSpace == false && memorySpaces[i].TotalSpace > spaceProcess)
                        {
                            int differenceSpace = memorySpaces[i].TotalSpace - spaceProcess;
                            if(weigthOpt < differenceSpace)
                            {
                                weigthOpt = differenceSpace;
                                positionOpt = i;
                            }
                        }
                    }
                    indexAdjust = positionOpt;
                    break;
                case 2:
                    int maxSpace = memorySpaces.FindAll(x => x.UsedSpace == false).Max(x => x.TotalSpace);
                    indexAdjust = memorySpaces.FindIndex(x => x.UsedSpace == false && x.TotalSpace == maxSpace);
                    break;
                default:
                    indexAdjust = memorySpaces.FindIndex(x => x.UsedSpace == false);
                    break;
            }
            return indexAdjust;
        }

        private void buttonAddProcess_Click(object sender, EventArgs e)
        {
            int indexPending = listPending.SelectedIndex;
            List<string> listProcess = itemsProcessActive.ToList();
            int.TryParse(itemsProcessPending[indexPending].Split('(')[1].Split('K')[0], out int weigth);
            int indexMemory = indexSelectAdjust(weigth);
            int totalSpace = 0;
            switch (indexPartitionType)
            {
                case 0:
                    totalSpace = 2048;
                    break;
                case 1:
                    totalSpace = memorySpaces[indexMemory].TotalSpace;
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

            if (indexMemory < 0 || weigth > memorySpaces[indexMemory].TotalSpace)
            {
                MessageBox.Show("Memoria insuficiente");
                return;
            }

            MemorySpace newSpace = new MemorySpace { ProcessName = itemsProcessPending[indexPending], UsedSpace = true, TotalSpace = totalSpace };
            memorySpaces[indexMemory] = newSpace;
            switch (comboMemoryModel.SelectedIndex)
            {
                case 0:
                    drawPartitionalFixedItem(indexMemory + 1, weigth);
                    break;
                case 2:
                    drawPartitionalDynamicItem(indexMemory + 1, weigth);
                    break;
            }
            listProcess.Add(itemsProcessPending[indexPending]);
            itemsProcessActive = listProcess.ToArray();
            listProcessActive.DataSource = itemsProcessActive;
        }

        private void buttonQuitProcess_Click(object sender, EventArgs e)
        {
            int indexProcessToFinish = listProcessActive.SelectedIndex;
            if(indexProcessToFinish < 0) { return; }
            int indexMemoryDelete = memorySpaces.FindIndex(x => x.ProcessName == itemsProcessActive[indexProcessToFinish]);
            memorySpaces[indexMemoryDelete] = new MemorySpace { TotalSpace = memorySpaces[indexMemoryDelete].TotalSpace };
            List<string> listProcess = itemsProcessActive.ToList();
            deletePartitionalFixedItem(indexMemoryDelete + 1);
            listProcess.RemoveAt(indexProcessToFinish);
            itemsProcessActive = listProcess.ToArray();
            listProcessActive.DataSource = itemsProcessActive;
        }

        private void drawPartitionalFixedItem(int position, int weigth)
        {
            int weigthPartition = memoryTotalSpace / 8;
            int percentPartition = (weigth * 128) / weigthPartition;
            gImagen.FillRectangle(new SolidBrush(Color.Red), 128 * position, 0, percentPartition, 200);
            drawPartitionalFixed();
            gLienzo.DrawImage(bitmap, new Point(0, 0));
            return;
        }

        private void deletePartitionalFixedItem(int position)
        {
            gImagen.FillRectangle(new SolidBrush(Color.GreenYellow), 128 * position, 0, 128, 200);
            drawPartitionalFixed();
            gLienzo.DrawImage(bitmap, new Point(0, 0));
        }

        private void drawPartitionalDynamicItem(int position, int weigth)
        {
            int weigthPartition = memoryTotalSpace / 8;
            int percentPartition = (weigth * 128) / weigthPartition;
            gImagen.FillRectangle(new SolidBrush(Color.Red), 128 * position, 0, percentPartition, 200);
            drawPartitionalFixed();
            gLienzo.DrawImage(bitmap, new Point(0, 0));
            return;
        }

        private void deletePartitionalDynamicItem(int position)
        {
            gImagen.FillRectangle(new SolidBrush(Color.GreenYellow), 128 * position, 0, 128, 200);
            drawPartitionalFixed();
            gLienzo.DrawImage(bitmap, new Point(0, 0));
        } 
    }
}
