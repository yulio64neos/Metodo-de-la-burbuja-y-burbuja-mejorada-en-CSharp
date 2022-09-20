using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace MetodoDeLaBurbuja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        //List<int> arrayNum = null;

        
        int[] lolo = { 0, 2, 1, 5, };
        private List<int> arrayNum = new List<int>();
        public void burbuja_PWA_NADAQUEVER()
        {
            int numTemp;
            for (int j = 0; j < arrayNum.Count; j++)
            {
                for (int i = 0; i < arrayNum.Count - 1; i++)
                {
                    if (arrayNum[i] > arrayNum[i + 1])
                    {
                        numTemp = arrayNum[i + 1];
                        arrayNum[i + 1] = arrayNum[i];
                        arrayNum[i] = numTemp;
                    }
                }
            }

            if (listBox1.InvokeRequired)
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    foreach (int p in arrayNum)
                        listBox1.Items.Add(p.ToString());
                }));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //arrayNum = Convert.ToInt32(textBox1.Text);
            
            listBox1.Items.Add(Convert.ToInt32(textBox1.Text));
            listBox2.Items.Add(Convert.ToInt32(textBox1.Text));
            arrayNum.Add(Convert.ToInt32(textBox1.Text));
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Thread miHilo = new Thread(delegate ()
            {
                burbuja_PWA_NADAQUEVER();
                if (listBox1.InvokeRequired)
                {
                    listBox1.Invoke(new MethodInvoker(delegate
                    {
                        listBox1.Items.Add("Terminó el proceso JUAS JUAS");
                    }));
                }
            });
            miHilo.Start();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public int[] BurbujaMejorado_NADAQUEVER_PWA(int[] n)
        {
            bool banderasJUASJUAS;
            int temp, t, i;
            t = n.Length;
            banderasJUASJUAS = false;
            i = 0;
            while (!banderasJUASJUAS)
            {
                banderasJUASJUAS = true;
                {
                    for (int j = t - 1; j > i; j--)
                    {
                        if (n[j] < n[j - 1])
                        {
                            temp = n[j];
                            n[j] = n[j - 1];
                            n[j - 1] = temp;
                            banderasJUASJUAS = false;
                        }
                    }
                }
                i++;
            }
            return n;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            //int[] ArregloMejorado;

            Thread miHilo = new Thread(delegate ()
            {
                var ArregloMejorado = BurbujaMejorado_NADAQUEVER_PWA(arrayNum.ToArray());
                if (listBox2.InvokeRequired)
                {
                    listBox2.Invoke(new MethodInvoker(delegate
                    {
                        foreach (int item in ArregloMejorado)
                        {
                            listBox2.Items.Add(item);
                        }
                        listBox2.Items.Add("Terminó el proceso 2 JUAS JUAS");
                    }));
                }
            });
            miHilo.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                string xmlFilePath = op.FileName;
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(xmlFilePath);
                    dataGridView1.DataSource = ds.Tables[0];
                    listBox1.DataSource = ds.Tables[0];
                    listBox1.DisplayMember = "descripcion";
                    listBox1.ValueMember = "descripcion";
                    listBox2.DataSource = ds.Tables[0];
                    listBox2.DisplayMember = "descripcion";
                    listBox2.ValueMember = "descripcion";
                    MessageBox.Show(ds.Tables[0].Rows.Count + " Total de registros cargados.");
                }
            }
        }

        private List<string> arrayString = new List<string>();
        public void burbuja_PWA_NADAQUEVER_string()
        {
            int numTemp;
            for (int j = 0; j < arrayNum.Count; j++)
            {
                for (int i = 0; i < arrayNum.Count - 1; i++)
                {
                    if (arrayNum[i] > arrayNum[i + 1])
                    {
                        numTemp = arrayNum[i + 1];
                        arrayNum[i + 1] = arrayNum[i];
                        arrayNum[i] = numTemp;
                    }
                }
            }

            if (listBox1.InvokeRequired)
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    foreach (int p in arrayNum)
                        listBox1.Items.Add(p.ToString());
                }));
        }
    }
}
