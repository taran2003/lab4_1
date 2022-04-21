using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_1
{
    public partial class lab4 : Form
    {
        HashSet<TreeNode> nodes = new HashSet<TreeNode>();
        List<HashSet<product>> products = new List<HashSet<product>>();
        List<string> propertis = new List<string>();
        Calories calories = new Calories();
        bool first=false, second = false, third = false,forth=false;
        public lab4()
        {
            string fileName = "FoodProducts.xml";
            Data data = new Data(fileName);
            InitializeComponent();
            createTree(data);
            for(int i=0;i<treeView2.Nodes.Count;i++)
            {
                products.Add(new HashSet<product>());
            }
        }

        void createTree(Data data)
        {
            TreeNode[] treeNodes = new TreeNode[data.name.Count];
            for (int i = 0; i < data.name.Count; i++)
            {
                TreeNode[] ChiledNodes = new TreeNode[data.product[i].Count];
                for (int j = 0; j < data.product[i].Count; j++)
                {
                    for (int z = 0; z < data.product[i][j].Count; z++)
                        ChiledNodes[j] = new TreeNode(data.product[i][j][0]);
                }
                treeNodes[i] = new TreeNode(data.name[i], ChiledNodes);
            }
            for (int i = 0; i < data.name.Count; i++)
            {
                treeNodes[i].Name = data.name[i];
                treeNodes[i].Text = data.name[i];
                treeNodes[i].ImageIndex = i;
                treeNodes[i].Tag = i;
            }
            for (int i = 0; i < data.name.Count; i++)
            {
                this.treeView1.Nodes.Add(treeNodes[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.treeView2.Nodes[0].Nodes.Clear();
            products[0].Clear();
            Data data = new Data("FoodProducts.xml");
            foreach (TreeNode treeNode in nodes)
            {
                this.treeView2.Nodes[0].Nodes.Add(treeNode.Text);
                foreach (List<List<string>> f in data.product)
                {
                    foreach (List<string> g in f)
                    {
                        if (g[0] == treeNode.Text)
                        {
                            products[0].Add(new product(g));
                        } 
                    }
                }
            }
        }

        private void treeView1_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                nodes.Add(e.Node);
            }
            if (e.Node.Checked == false)
            {
                nodes.Remove(e.Node);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.treeView2.Nodes[1].Nodes.Clear();
            products[1].Clear();
            Data data = new Data("FoodProducts.xml");
            foreach (TreeNode treeNode in nodes)
            {
                this.treeView2.Nodes[1].Nodes.Add(treeNode.Text);
                foreach (List<List<string>> f in data.product)
                {
                    foreach (List<string> g in f)
                    {
                        if (g[0] == treeNode.Text)
                        {
                            products[1].Add(new product(g));
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.treeView2.Nodes[2].Nodes.Clear();
            products[2].Clear();
            Data data = new Data("FoodProducts.xml");
            foreach (TreeNode treeNode in nodes)
            {
                this.treeView2.Nodes[2].Nodes.Add(treeNode.Text);
                foreach (List<List<string>> f in data.product)
                {
                    foreach (List<string> g in f)
                    {
                        if (g[0] == treeNode.Text)
                        {
                            products[2].Add(new product(g));
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Data data = new Data("FoodProducts.xml");
            string a = this.treeView1.SelectedNode.Text;
            foreach(List<List<string>> f in data.product)
            {
                foreach (List<string> g in f)
                {
                    if(g[0]==a)
                    {
                        propertis = g;
                    }
                }
            }
            if (propertis.Count != 0)
            {
                this.textBox1.Text = propertis[1];
                this.label6.Text = propertis[2];
                this.label7.Text = propertis[3];
                this.label8.Text = propertis[4];
                this.label9.Text = propertis[5];
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int r = 0;
            product buf=new product();
            try
            {
                for (int i = 0; i < products.Count; i++)
                {
                    foreach (product g in products[i])
                    {
                        if (products[i].Count != 0)
                        {
                            for (int j = 0; j < treeView2.Nodes[i].Nodes.Count; j++)
                            {
                                if (g.name == treeView2.SelectedNode.Text && treeView2.Nodes[r].Nodes[j].IsSelected)
                                {
                                    buf = g;
                                }
                            }
                        }
                    }
                    r++;
                }
            }catch(Exception)
            {

            }
            r = 0;
            if (buf!= null)
            {
                textBox1.Text = buf.gramms.ToString();
                this.label6.Text = buf.protein.ToString();
                this.label7.Text = buf.fats.ToString();
                this.label8.Text = buf.carbs.ToString();
                this.label9.Text = buf.calories.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                calories.arm = 1.2;
                first = true;
                checkBox4.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            if (checkBox1.Checked==false)
            {
                calories.arm = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                calories.arm = 1.375;
                first = true;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox3.Checked = false;
            }
            if (checkBox2.Checked == false)
            {
                calories.arm = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                calories.arm = 1.55;
                first = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
            if (checkBox1.Checked == false)
            {
                calories.arm = 0;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                calories.arm = 1.725;
                first = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            if (checkBox1.Checked == false)
            {
                calories.arm = 0;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(first&&second&&third&&forth)
            {
                calories.bmrCount();
                calories.dailyCaloriesCount();
                this.label13.Text ="/"+calories.dailyCalories.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<double> rez = new List<double>();
            foreach (TreeNode a in this.treeView2.Nodes)
            {
                foreach (TreeNode b in a.Nodes)
                {
                    foreach (HashSet<product> f in products)
                    {
                        foreach (product g in f)
                        {
                            if (g.name == b.Text)
                            {
                                rez.Add(g.calories);
                            }
                        }
                    }
                }
            }
            double cal = Calories.caloriesInMenu(rez);
            this.label14.Text = cal.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<string> rez = new List<string>();
            string buf = "";
            rez.Add("weight " + textBox2.Text + " height " + textBox3.Text + " age " + textBox4.Text);
            foreach(TreeNode tree in treeView2.Nodes)
            {
                buf = tree.Text+":";
                foreach(TreeNode tree1 in tree.Nodes)
                {
                    buf += "\n "+tree1.Text;
                }
                rez.Add(buf);
                buf = "";
            }
            rez.Add("Calories " + label14.Text + label13.Text);
            buf = "Daily activity: ";
            if ( checkBox1.Checked)
            {
                buf += checkBox1.Text;
            }
            else if (checkBox2.Checked)
            {
                buf += checkBox2.Text;
            }
            else if (checkBox3.Checked)
            {
                buf += checkBox3.Text;
            }
            else if (checkBox4.Checked)
            {
                buf += checkBox4.Text;
            }
            Card_info.Write("menu.txt",rez,false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int f = 0;
            for (int i = 0; i < products.Count; i++)
            {
                foreach (product a in products[i])
                {
                    for (int j = 0; j < treeView2.Nodes[i].Nodes.Count; j++) {
                        if (this.treeView2.SelectedNode.Text == a.name&&treeView2.Nodes[f].Nodes[j].IsSelected)
                        {
                            try
                            {
                                a.grammsChange(int.Parse(textBox1.Text));
                            }
                            catch (Exception) { }
                        }
                    }
                }
                f++;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 0)
            {
                try
                {
                    calories.age = int.Parse(textBox4.Text);
                    second = true;
                }
                catch(Exception)
                { }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 0)
            {
                try
                {
                    calories.height = double.Parse(textBox3.Text);
                    third = true;
                }catch(Exception)
                { }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0)
            {
                try
                {
                    calories.weight = double.Parse(textBox2.Text);
                    forth = true;
                }
                catch(Exception)
                {

                }
            }
        }
    }
}