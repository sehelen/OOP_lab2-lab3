using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace oop_laba_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        List<Animals> animals = new List<Animals>(0);
        public string SelectedAnimal = "";
        List<Birds> birds = new List<Birds>(0);
        public string SelectedBird = "";
        List<Mammals> mammals = new List<Mammals>(0);
        public string SelectedMammal = "";
        List<Cubs> cubs= new List<Cubs>(0);
        public string SelectedCub = "";
        List<Fish> fish = new List<Fish>(0);
        public string SelectedFish = "";



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    tbAnimalsName.Clear();
                    tbAnimalsCage.Clear();
                    lbAnimals.Items.Clear();
                    foreach (Animals i in animals)
                    {
                        lbAnimals.Items.Add(i.name);
                    }
                    break;
                case 1:
                    tbBirdsName.Clear();
                    tbBirdsCage.Clear();
                    tbBirdsEggs.Clear();
                    tbBirdsMigratory.Clear();
                    lbBirds.Items.Clear();
                    foreach (Birds i in birds)
                    {
                        lbBirds.Items.Add(i.name);
                    }
                    break;
                case 2:
                    tbMamName.Clear();
                    tbMamCage.Clear();
                    tbMamGender.Clear();
                    tbMamPredator.Clear();
                    lbMammals.Items.Clear();
                    foreach (Mammals i in mammals)
                    {
                        lbMammals.Items.Add(i.name);
                    }
                    break;
                case 3:
                    tbCubsAdult.Clear();
                    tbCubsCage.Clear();
                    tbCubsGender.Clear();
                    tbCubsName.Clear();
                    tbCubsPredator.Clear();
                    tbCubsFoodAmount.Clear();
                    tbCubsFoodName.Clear();
                    tbCubsFoodPrice.Clear();
                    lbCubs.Items.Clear();                    
                    foreach (Cubs i in cubs)
                    {
                        lbCubs.Items.Add(i.name);
                    }
                    break;
                case 4:
                    tbFishName.Clear();
                    tbFishCage.Clear();
                    tbFishSprawing.Clear();
                    tbFishFresh.Clear();
                    lbFish.Items.Clear();
                    foreach (Fish i in fish)
                    {
                        lbFish.Items.Add(i.name);
                    }
                    break;

            }
        }

        /// <summary>
        /// Animals
        /// </summary>

        private void btnAnimalsAdd_Click(object sender, EventArgs e)
        {
            if (tbAnimalsName.Text != "" &&
                   tbAnimalsCage.Text != "")
            {
                SelectedAnimal = "";
                lbAnimals.Items.Clear();

                animals.Capacity++;
                animals.Add(new Animals(tbAnimalsName.Text, tbAnimalsCage.Text));

                tbAnimalsName.Clear();
                tbAnimalsCage.Clear();
               

                foreach (Animals i in animals)
                {
                    lbAnimals.Items.Add(i.name);
                }
            }
            else { MessageBox.Show("Ошибка: Не все поля заполнены"); }

        }

        private void btnAnimalsSave_Click(object sender, EventArgs e)
        {
                if (tbAnimalsName.Text != "" &&
                   tbAnimalsCage.Text != "" && SelectedAnimal != "")
                {
                    lbAnimals.Items.Clear();
                    foreach (Animals i in animals)
                    {
                        if (i.name == SelectedAnimal)
                        {
                            i.name = tbAnimalsName.Text;
                            i.cage_number = tbAnimalsCage.Text;
                        }
                        lbAnimals.Items.Add(i.name);
                   
                    }
                    tbAnimalsName.Clear();
                    tbAnimalsCage.Clear();
                }

                else
                { MessageBox.Show("Ошибка: Не все поля заполнены или не выбран объект"); }
              
        }

        private void btnAnimalsDel_Click(object sender, EventArgs e)
        {
            if (SelectedAnimal != "")
            {
                lbAnimals.Items.Clear();
                foreach (Animals i in animals)
                {
                    if (i.name == SelectedAnimal)
                    {
                        animals.Remove(i);
                        break;
                    }
                }
                foreach (Animals i in animals)
                {
                    lbAnimals.Items.Add(i.name);
                }
                tbAnimalsName.Clear();
                tbAnimalsCage.Clear();

            }
            else { MessageBox.Show("Ошибка: не выбран объект"); }
        }

        private void lbAnimals_Click(object sender, EventArgs e)
        {
            SelectedAnimal = lbAnimals.SelectedItem.ToString();
            foreach (Animals i in animals)
            {
                if (i.name == SelectedAnimal)
                {
                    tbAnimalsCage.Text = i.cage_number;
                    tbAnimalsName.Text = i.name;
                }
            }
        }



        /// <summary>
        /// class Birds
        /// </summary>
  

        private void btnBirdsAdd_Click(object sender, EventArgs e)
        {
            if (tbBirdsName.Text != "" &&
                   tbBirdsCage.Text != "" &&
                   tbBirdsEggs.Text != "" &&
                   tbBirdsMigratory.Text != "")
            {
                SelectedBird = "";
                lbBirds.Items.Clear();

                birds.Capacity++;
                birds.Add(new Birds(tbBirdsName.Text, tbBirdsCage.Text, tbBirdsMigratory.Text, tbBirdsEggs.Text));
               
                tbBirdsName.Clear();
                tbBirdsCage.Clear();
                tbBirdsEggs.Clear();
                tbBirdsMigratory.Clear();

                foreach (Birds i in birds)
                {
                    lbBirds.Items.Add(i.name);
                }
            }
            else { MessageBox.Show("Ошибка: Не все поля заполнены"); }

        }

        private void btnBirdsSave_Click(object sender, EventArgs e)
        {
            if (tbBirdsName.Text != "" &&
                   tbBirdsCage.Text != "" &&
                   tbBirdsEggs.Text != "" &&
                   tbBirdsMigratory.Text != "" && SelectedBird != "")
            {
                lbBirds.Items.Clear();
                foreach (Birds i in birds)
                {
                    if (i.name == SelectedBird)
                    {
                        i.name = tbBirdsName.Text;
                        i.cage_number = tbBirdsCage.Text;
                        i.migratory = tbBirdsMigratory.Text;
                        i.eggsAmount = tbBirdsEggs.Text;
                    }
                    lbBirds.Items.Add(i.name);
                }

                tbBirdsName.Clear();
                tbBirdsCage.Clear();
                tbBirdsEggs.Clear();
                tbBirdsMigratory.Clear();
            }

            else
            { MessageBox.Show("Ошибка: Не все поля заполнены или не выбран объект"); }
        }

        private void btnBirdsDel_Click(object sender, EventArgs e)
        {
            if (SelectedBird != "")
            {
                lbBirds.Items.Clear();
                foreach (Birds i in birds)
                {
                    if (i.name == SelectedBird)
                    {
                        birds.Remove(i);
                        break;
                    }
                }
     
                foreach (Birds i in birds)
                {
                    lbBirds.Items.Add(i.name);
                }
                tbBirdsName.Clear();
                tbBirdsCage.Clear();
                tbBirdsEggs.Clear();
                tbBirdsMigratory.Clear();

            }
            else { MessageBox.Show("Ошибка: не выбран объект"); }
        }

        private void lbBirds_Click(object sender, EventArgs e)
        {
            SelectedBird = lbBirds.SelectedItem.ToString();
            foreach (Birds i in birds)
            {
                if (i.name == SelectedBird)
                {
                    tbBirdsCage.Text = i.cage_number;
                    tbBirdsName.Text = i.name;
                    tbBirdsEggs.Text = i.eggsAmount;
                    tbBirdsMigratory.Text = i.migratory;
                }
            }
        }


        /// <summary>
        /// class Mammals
        /// </summary>

        private void btnMamAdd_Click(object sender, EventArgs e)
        {
            if (tbMamName.Text != "" &&
                   tbMamCage.Text != "" &&
                   tbMamGender.Text != "" &&
                   tbMamPredator.Text != "")
            {
                SelectedMammal = "";
                lbMammals.Items.Clear();

                mammals.Capacity++;
                mammals.Add(new Mammals(tbMamName.Text, tbMamCage.Text, tbMamGender.Text, tbMamPredator.Text));

                tbMamName.Clear();
                tbMamCage.Clear();
                tbMamGender.Clear();
                tbMamPredator.Clear();

                foreach (Mammals i in mammals)
                {
                    lbMammals.Items.Add(i.name);
                }
            }
            else { MessageBox.Show("Ошибка: Не все поля заполнены"); }

        }

        private void btnMamSave_Click(object sender, EventArgs e)
        {
            if (tbMamName.Text != "" &&
                   tbMamCage.Text != "" &&
                   tbMamGender.Text != "" &&
                   tbMamPredator.Text != "" && SelectedMammal != "")
            {
                lbMammals.Items.Clear();
                foreach (Mammals i in mammals)
                {
                    if (i.name == SelectedMammal)
                    {
                        i.name = tbMamName.Text;
                        i.cage_number = tbMamCage.Text;
                        i.predator = tbMamPredator.Text;
                        i.gender = tbMamGender.Text;
                    }
                    lbMammals.Items.Add(i.name);
                }
              

                tbMamName.Clear();
                tbMamCage.Clear();
                tbMamGender.Clear();
                tbMamPredator.Clear();
            }

            else
            { MessageBox.Show("Ошибка: Не все поля заполнены или не выбран объект"); }
        }

        private void btnMamDel_Click(object sender, EventArgs e)
        {
            if (SelectedMammal != "")
            {
                lbMammals.Items.Clear();
                foreach (Mammals i in mammals)
                {
                    if (i.name == SelectedMammal)
                    {
                        mammals.Remove(i);
                        break;
                    }
                }
             
                foreach (Mammals i in mammals)
                {
                    lbMammals.Items.Add(i.name);
                }

                tbMamName.Clear();
                tbMamCage.Clear();
                tbMamGender.Clear();
                tbMamPredator.Clear();

            }
            else { MessageBox.Show("Ошибка: не выбран объект"); }
        }

        private void lbMammals_Click(object sender, EventArgs e)
        {
            SelectedMammal = lbMammals.SelectedItem.ToString();
            foreach (Mammals i in mammals)
            {
                if (i.name == SelectedMammal)
                {
                    tbMamName.Text = i.name;
                    tbMamCage.Text = i.cage_number;
                    tbMamPredator.Text = i.predator;
                    tbMamGender.Text = i.gender;
                }
            }
        }




        /// <summary>
        /// class Cubs
        /// </summary>
        /// 

        private void btnCubsAdd_Click(object sender, EventArgs e)
        {
            if (tbCubsName.Text != "" &&
                   tbCubsCage.Text!= "" &&
                   tbCubsGender.Text != "" &&
                   tbCubsPredator.Text != "" &&
                   tbCubsAdult.Text != "" &&
                   tbCubsFoodAmount.Text != "" &&
                   tbCubsFoodName.Text != "" &&
                   tbCubsFoodPrice.Text != "")
            {
                SelectedCub = "";
                lbCubs.Items.Clear();

                Food food = new Food(tbCubsFoodName.Text, tbCubsFoodAmount.Text, tbCubsFoodPrice.Text);
                cubs.Capacity++;
                cubs.Add(new Cubs(tbCubsName.Text, tbCubsCage.Text, tbCubsGender.Text, tbCubsPredator.Text, food, tbCubsAdult.Text));
                 
             
                tbCubsAdult.Clear();
                tbCubsCage.Clear();
                tbCubsGender.Clear();
                tbCubsName.Clear();
                tbCubsPredator.Clear();
                tbCubsFoodAmount.Clear();
                tbCubsFoodName.Clear();
                tbCubsFoodPrice.Clear();

                foreach (Cubs i in cubs)
                {
                    lbCubs.Items.Add(i.name);
                }
            }
            else { MessageBox.Show("Ошибка: Не все поля заполнены"); }
        }

        private void btnCubsSave_Click(object sender, EventArgs e)
        {
            if (tbCubsName.Text != "" &&
                   tbCubsCage.Text != "" &&
                   tbCubsGender.Text != "" &&
                   tbCubsPredator.Text != "" &&
                   tbCubsAdult.Text != "" &&
                   tbCubsFoodAmount.Text != "" &&
                   tbCubsFoodName.Text != "" &&
                   tbCubsFoodPrice.Text != "")
            {
                lbCubs.Items.Clear();
                foreach (Cubs i in cubs)
                {
                    if (i.name == SelectedCub)
                    {
                        i.name = tbCubsName.Text;
                        i.cage_number = tbCubsCage.Text;
                        i.gender = tbCubsGender.Text;
                        i.predator = tbCubsPredator.Text;
                        i.food.amount = tbCubsFoodAmount.Text;
                        i.food.name = tbCubsFoodName.Text;
                        i.food.price = tbCubsFoodPrice.Text;
                        i.timeToBecomeAdult = tbCubsAdult.Text;
                    }
                    lbCubs.Items.Add(i.name);
                }
             


                tbCubsAdult.Clear();
                tbCubsCage.Clear();
                tbCubsGender.Clear();
                tbCubsName.Clear();
                tbCubsPredator.Clear();
                tbCubsFoodAmount.Clear();
                tbCubsFoodName.Clear();
                tbCubsFoodPrice.Clear();
            }

            else
            { MessageBox.Show("Ошибка: Не все поля заполнены или не выбран объект"); }
        }

        private void btnCubsDel_Click(object sender, EventArgs e)
        {
            if (SelectedCub != "")
            {
                lbCubs.Items.Clear();
                foreach (Cubs i in cubs)
                {
                    if (i.name == SelectedCub)
                    {
                        cubs.Remove(i);
                        break;
                    }
                }
              
                foreach (Cubs i in cubs)
                {
                    lbCubs.Items.Add(i.name);
                }

                tbCubsAdult.Clear();
                tbCubsCage.Clear();
                tbCubsGender.Clear();
                tbCubsName.Clear();
                tbCubsPredator.Clear();
                tbCubsFoodAmount.Clear();
                tbCubsFoodName.Clear();
                tbCubsFoodPrice.Clear();

            }
            else { MessageBox.Show("Ошибка: не выбран объект"); }

        }

        private void lbCubs_Click(object sender, EventArgs e)
        {
            SelectedCub = lbCubs.SelectedItem.ToString();
            foreach (Cubs i in cubs)
            {
                if (i.name == SelectedCub)
                {
                    tbCubsName.Text = i.name;
                    tbCubsCage.Text = i.cage_number;
                    tbCubsGender.Text = i.gender;
                    tbCubsPredator.Text = i.predator;
                    tbCubsFoodAmount.Text = i.food.amount;
                    tbCubsFoodName.Text = i.food.name;
                    tbCubsFoodPrice.Text = i.food.price;
                    tbCubsAdult.Text = i.timeToBecomeAdult;
                }
            }
        }

        /// <summary>
        /// class Fish
        /// </summary>    

        private void btnFishAdd_Click(object sender, EventArgs e)
        {
            if (tbFishName.Text != "" &&
                   tbFishCage.Text != "" &&
                   tbFishFresh.Text != "" &&
                   tbFishSprawing.Text != "")
            {
                SelectedFish = "";
                lbFish.Items.Clear();

                fish.Capacity++;
                fish.Add(new Fish(tbFishName.Text, tbFishCage.Text, tbFishFresh.Text, tbFishSprawing.Text));

                tbFishName.Clear();
                tbFishCage.Clear();
                tbFishSprawing.Clear();
                tbFishFresh.Clear();

                foreach (Fish i in fish)
                {
                    lbFish.Items.Add(i.name);
                }
            }
            else { MessageBox.Show("Ошибка: Не все поля заполнены"); }

        }

        private void btnFishSave_Click(object sender, EventArgs e)
        {
            if (tbFishName.Text != "" &&
                   tbFishCage.Text != "" &&
                   tbFishFresh.Text != "" &&
                   tbFishSprawing.Text != "" && SelectedFish != "")
            {
                lbFish.Items.Clear();
                foreach (Fish i in fish)
                {
                    if (i.name == SelectedFish)
                    {
                        i.name = tbFishName.Text;
                        i.cage_number = tbFishCage.Text;
                        i.freshwater = tbFishFresh.Text;
                        i.sprawingTime = tbFishSprawing.Text;
                    }
                    lbFish.Items.Add(i.name);
                }

                tbFishName.Clear();
                tbFishCage.Clear();
                tbFishSprawing.Clear();
                tbFishFresh.Clear();
            }

            else
            { MessageBox.Show("Ошибка: Не все поля заполнены или не выбран объект"); }
        }

        private void btnFishDel_Click(object sender, EventArgs e)
        {
            if (SelectedFish != "")
            {
                lbFish.Items.Clear();
                foreach (Fish i in fish)
                {
                    if (i.name == SelectedFish)
                    {
                        fish.Remove(i);
                        break;
                    }
                }

                foreach (Fish i in fish)
                {
                    lbFish.Items.Add(i.name);
                }
                tbFishName.Clear();
                tbFishCage.Clear();
                tbFishSprawing.Clear();
                tbFishFresh.Clear();

            }
            else { MessageBox.Show("Ошибка: не выбран объект"); }
        }

        private void lbFish_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFish = lbFish.SelectedItem.ToString();
            foreach (Fish i in fish)
            {
                if (i.name == SelectedFish)
                {
                    tbFishName.Text = i.name;
                    tbFishCage.Text = i.cage_number;
                    tbFishFresh.Text = i.freshwater;
                    tbFishSprawing.Text = i.sprawingTime;
                }
            }
        }

        /// <summary>
        /// AnimalsFile
        /// </summary>


        private void btnFileAnimals_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;     
            string filename = saveFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();
           
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, animals);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Animals>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, animals);
                }
            }
            else if(rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string textout = "";
                foreach (Animals i in animals)
                {
                    textout = textout + i.name + Environment.NewLine + i.cage_number  + Environment.NewLine;
                }
                File.WriteAllText(f.FileName, textout);

            }
            else
            {MessageBox.Show("Ошибка: не выбран способ сериализации");}
        }

        private void btnAnimalsLoad_Click(object sender, EventArgs e)
        {
            lbAnimals.Items.Clear();
            animals.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;        
            string filename = openFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    animals = (List<Animals>)formatter.Deserialize(fs);
                }

                foreach (Animals i in animals)
                {
                    lbAnimals.Items.Add(i.name);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Animals>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    animals = (List<Animals>)jsonFormatter.ReadObject(fs);
                }

                foreach (Animals i in animals)
                {
                    lbAnimals.Items.Add(i.name);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string[] lines = File.ReadAllLines(f.FileName);
                for (int j=0; j<lines.Length-1; j+=2)
                {
                    animals.Capacity++;
                    animals.Add(new Animals(lines[j], lines[j+1]));
                }

                foreach (Animals i in animals)
                {
                    lbAnimals.Items.Add(i.name);
                }
            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }


        /// <summary>
        /// BirdsFile
        /// </summary>

        private void btnBirdsFile_Click(object sender, EventArgs e)
        {         
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, birds);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Birds>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, birds);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string textout = "";
                foreach (Birds i in birds)
                {
                    textout = textout + i.name + Environment.NewLine + i.cage_number + Environment.NewLine + i.migratory + Environment.NewLine + i.eggsAmount + Environment.NewLine;
                }
                File.WriteAllText(f.FileName, textout);

            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }

        private void btnBirdLoad_Click(object sender, EventArgs e)
        {
            lbBirds.Items.Clear();
            birds.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    birds = (List<Birds>)formatter.Deserialize(fs);
                }

                foreach (Birds i in birds)
                {
                    lbBirds.Items.Add(i.name);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Birds>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    birds = (List<Birds>)jsonFormatter.ReadObject(fs);
                }

                foreach (Birds i in birds)
                {
                    lbBirds.Items.Add(i.name);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string[] lines = File.ReadAllLines(f.FileName);
                for (int j = 0; j < lines.Length - 1; j += 4)
                {
                    birds.Capacity++;
                    birds.Add(new Birds(lines[j], lines[j + 1], lines[j + 2], lines[j + 3]));
                }

                foreach (Birds i in birds)
                {
                    lbBirds.Items.Add(i.name);
                }
            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }

        /// <summary>
        /// MammalsFile
        /// </summary>

        private void btnMamFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, mammals);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Mammals>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, mammals);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string textout = "";
                foreach (Mammals i in mammals)
                {
                    textout = textout + i.name + Environment.NewLine + i.cage_number + Environment.NewLine + i.gender + Environment.NewLine + i.predator + Environment.NewLine;
                }
                File.WriteAllText(f.FileName, textout);

            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }

        private void btnMamLoad_Click(object sender, EventArgs e)
        {
            lbMammals.Items.Clear();
            mammals.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    mammals = (List<Mammals>)formatter.Deserialize(fs);
                }

                foreach (Mammals i in mammals)
                {
                    lbBirds.Items.Add(i.name);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Mammals>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    mammals = (List<Mammals>)jsonFormatter.ReadObject(fs);
                }

                foreach (Mammals i in mammals)
                {
                    lbBirds.Items.Add(i.name);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string[] lines = File.ReadAllLines(f.FileName);
                for (int j = 0; j < lines.Length - 1; j += 4)
                {
                    mammals.Capacity++;
                    mammals.Add(new Mammals(lines[j], lines[j + 1], lines[j + 2], lines[j + 3]));
                }

                foreach (Mammals i in mammals)
                {
                    lbBirds.Items.Add(i.name);
                }
            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }

        }

        /// <summary>
        /// FishFile
        /// </summary>

        private void btnFishFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, fish);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Fish>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, fish);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string textout = "";
                foreach (Fish i in fish)
                {
                    textout = textout + i.name + Environment.NewLine + i.cage_number + Environment.NewLine + i.freshwater+ Environment.NewLine + i.sprawingTime + Environment.NewLine;
                }
                File.WriteAllText(f.FileName, textout);

            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }

        private void btnFishLoad_Click(object sender, EventArgs e)
        {
            lbFish.Items.Clear();
            fish.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                   fish = (List<Fish>)formatter.Deserialize(fs);
                }

                foreach (Fish i in fish)
                {
                    lbFish.Items.Add(i.name);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Fish>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    fish = (List<Fish>)jsonFormatter.ReadObject(fs);
                }

                foreach (Fish i in fish)
                {
                    lbFish.Items.Add(i.name);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string[] lines = File.ReadAllLines(f.FileName);
                for (int j = 0; j < lines.Length - 1; j += 4)
                {
                    fish.Capacity++;
                    fish.Add(new Fish(lines[j], lines[j + 1], lines[j + 2], lines[j + 3]));
                }

                foreach (Fish i in fish)
                {
                    lbFish.Items.Add(i.name);
                }
            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }


        /// <summary>
        /// CubsFile
        /// </summary>
   

        private void btnCubsFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, cubs);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Cubs>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, cubs);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string textout = "";
                foreach (Cubs i in cubs)
                {
                    textout = textout + i.name + Environment.NewLine + i.cage_number + Environment.NewLine + i.gender + Environment.NewLine + i.predator + Environment.NewLine + i.food.name + Environment.NewLine + i.food.amount + Environment.NewLine + i.food.price + Environment.NewLine + i.timeToBecomeAdult + Environment.NewLine;
                }
                File.WriteAllText(f.FileName, textout);

            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }

        private void btnCubsLoad_Click(object sender, EventArgs e)
        {
            lbCubs.Items.Clear();
            cubs.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            if (rbBinary.Checked)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    cubs = (List<Cubs>)formatter.Deserialize(fs);
                }

                foreach (Cubs i in cubs)
                {
                    lbCubs.Items.Add(i.name);
                }
            }
            else if (rbJson.Checked)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Cubs>));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    cubs = (List<Cubs>)jsonFormatter.ReadObject(fs);
                }

                foreach (Cubs i in cubs)
                {
                    lbCubs.Items.Add(i.name);
                }
            }
            else if (rbUser.Checked)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.FileName = filename;
                string[] lines = File.ReadAllLines(f.FileName);
                for (int j = 0; j < lines.Length - 1; j += 8)
                {
                    Food tempFood = new Food(lines[j + 4], lines[j + 5], lines[j + 6]);
                    cubs.Capacity++;
                    cubs.Add(new Cubs(lines[j], lines[j + 1], lines[j + 2], lines[j + 3], tempFood, lines[j+7]));
                }

                foreach (Cubs i in cubs)
                {
                    lbCubs.Items.Add(i.name);
                }
            }
            else
            { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
        }
    }
}
