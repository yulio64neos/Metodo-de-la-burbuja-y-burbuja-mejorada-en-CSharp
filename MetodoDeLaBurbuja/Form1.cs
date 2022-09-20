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
        List<Datos> obj = new List<Datos>();

        
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
                burbuja_PWA_NADAQUEVER_string();
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
                var ArregloMejorado = BurbujaMejorado_NADAQUEVER_PWA_String();
                if (ArregloMejorado != null)
                {
                    if (listBox2.InvokeRequired)
                    {
                        listBox2.Invoke(new MethodInvoker(delegate
                        {
                            foreach (Datos item in ArregloMejorado)
                            {
                                listBox2.Items.Add(item.descripcion);
                            }
                            listBox2.Items.Add("Terminó el proceso 2 JUAS JUAS");
                        }));
                    }
                }
                else if(ArregloMejorado == null)
                {
                    listBox2.Items.Add("Anexa el XML Correspondiente");
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
                using(DataSet ds = new DataSet())
                {
                    ds.ReadXml(xmlFilePath);
                    dataGridView1.DataSource = ds.Tables[0];
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        obj.Add(new Datos
                        {
                            id = row[0].ToString(),
                            descripcion = row[1].ToString(),
                            simbolo = row[2].ToString()
                        });
                    }
                    MessageBox.Show(obj.Count + " Total de registros cargados.");
                }
            }
        }
        public void burbuja_PWA_NADAQUEVER_string()
        {
            string numTemp;
            Datos[] dts = obj.ToArray();
            for (int j = 0; j < dts.Length; j++)
            {
                for (int i = 0; i < dts.Length - 1; i++)
                {
                    if (dts[i].descripcion.CompareTo(dts[i + 1].descripcion) > 0)
                    {
                        numTemp = dts[i + 1].descripcion;
                        dts[i + 1].descripcion = dts[i].descripcion;
                        dts[i].descripcion = numTemp;
                    }
                }
            }

            if (listBox1.InvokeRequired)
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    foreach (Datos p in dts)
                        listBox1.Items.Add(p.descripcion.ToString());
                }));
        }

        public Datos[] BurbujaMejorado_NADAQUEVER_PWA_String()
        {
            Datos[] n = obj.ToArray();
            bool banderasJUASJUAS;
            Datos temp;
            int t, i;
            t = n.Length;
            banderasJUASJUAS = false;
            i = 0;
            while (!banderasJUASJUAS)
            {
                banderasJUASJUAS = true;
                {
                    for (int j = t - 1; j > i; j--)
                    {
                        if (n[j].descripcion.CompareTo(n[j - 1].descripcion) < 0)
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


        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            textBox1.Enabled = false;
        }
    }
}
