using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Rahan_tuhlaus_laskuri
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            Setup();
        }

        private string categoryFilePath = "categories.json";
        private CategoryConfig categoryConfig;

        private Dictionary<string, List<string>> categories;

        private string editName, editCategory, editKeyword;

        private void SaveCategoriesToJson()
        {
            string json = JsonSerializer.Serialize(categoryConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(categoryFilePath, json);
        }

        private void LoadCategoriesFromJson()
        {
            if (File.Exists(categoryFilePath))
            {
                string json = File.ReadAllText(categoryFilePath);
                categoryConfig = JsonSerializer.Deserialize<CategoryConfig>(json);
                categories = categoryConfig.Categories.ToDictionary(c => c.Name, c => c.Keywords);
            }
            else
            {
                categoryConfig = new CategoryConfig { Categories = new List<Category>() };
                SaveCategoriesToJson(); // Tallenna tyhjä konfiguraatio, jos tiedostoa ei ole olemassa
            }
        }

        public void PopulateComboBox1()
        {
            // Tyhjennä comboboxi
            comboBox1.Items.Clear();

            // Lisää kategoriat comboboxiin
            foreach (var category in categories)
            {
                comboBox1.Items.Add(category.Key);
            }

            // Valitse ensimmäinen kategoria
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        public void AddCategory(string name, List<string> keywords)
        {
            var newCategory = new Category { Name = name, Keywords = keywords };
            categoryConfig.Categories.Add(newCategory);
            SaveCategoriesToJson();
        }

        public void RemoveCategory(string name)
        {
            var categoryToRemove = categoryConfig.Categories.FirstOrDefault(c => c.Name == name);
            if (categoryToRemove != null)
            {
                categoryConfig.Categories.Remove(categoryToRemove);
                SaveCategoriesToJson();
            }
        }

        private void Setup()
        {
            // Tyhjennä listboxit
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            // Lataa kategoriat
            LoadCategoriesFromJson();

            // Lisää kategoriat listboxiin
            foreach (var category in categories)
            {
                listBox1.Items.Add(category.Key);
            }

            PopulateComboBox1();

        }

        private void KeyWordFiler(string category)
        {
            // Tyhjennä listboxi
            listBox2.Items.Clear();

            // Lisää avainsanat listboxiin
            foreach (var keyword in categories[category])
            {
                listBox2.Items.Add(keyword);
            }
        }


        // Kategorian muokkaus
        private void button1_Click(object sender, EventArgs e)
        {
            // Tarkista, onko kategoria valittu
            if (listBox1.SelectedIndex != -1)
            {
                label3.Text = "Muokkaa kategoriaa: " + listBox1.SelectedItem.ToString();
                textBox1.Text = listBox1.SelectedItem.ToString();
                editName = "Category";
                editCategory = listBox1.SelectedItem.ToString();
                listBox1.Enabled = false;
                listBox2.Enabled = false;
                button8.Visible = true;
                button3.Visible = true;
                textBox1.Visible = true;
                label3.Visible = true;
            }
            else
            {
                MessageBox.Show("Valitse kategoria!");
            }
        }


        // Avainsanan muokkaus
        private void button2_Click(object sender, EventArgs e)
        {
            // Tarkista, onko avainsana valittu
            if (listBox2.SelectedIndex != -1)
            {
                label3.Text = "Muokkaa avainsanaa: " + listBox2.SelectedItem.ToString();
                textBox1.Text = listBox2.SelectedItem.ToString();
                editName = "Keyword";
                editKeyword = listBox2.SelectedItem.ToString();
                listBox1.Enabled = false;
                listBox2.Enabled = false;
                button8.Visible = true;
                button3.Visible = true;
                textBox1.Visible = true;
                label3.Visible = true;
            }
            else
            {
                MessageBox.Show("Valitse avainsana!");
            }
        }

        //Muokkauksen tallennus
        private void button3_Click(object sender, EventArgs e)
        {
            // tarkista, onko muokattava kohde valittu
            if (editName != null)
            {
                // Tarkista, onko uusi nimi annettu
                if (textBox1.Text != "")
                {
                    // Tarkista, onko uusi nimi jo olemassa
                    if (editName == "Category")
                    {
                        if (!categories.ContainsKey(textBox1.Text))
                        {
                            // Muokkaa kategoriaa
                            categories.Add(textBox1.Text, categories[editCategory]);
                            categories.Remove(editCategory);
                            // Lisää uusi kateogria 
                            AddCategory(textBox1.Text, categories[textBox1.Text]);
                            // Poista vanha kategoria
                            RemoveCategory(editCategory);
                            SaveCategoriesToJson();
                            Setup();
                            textBox1.Text = "";
                            label3.Text = "Muokkaa";
                            editName = null;
                            listBox1.Enabled = true;
                            listBox2.Enabled = true;
                            button8.Visible = false;
                            button3.Visible = false;
                            textBox1.Visible = false;
                            label3.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Kategoria on jo olemassa!");
                        }
                    }
                    else if (editName == "Keyword")
                    {
                        if (!categories[listBox1.Text.ToString()].Contains(textBox1.Text))
                        {
                            // Muokkaa avainsanaa
                            categories[listBox1.Text.ToString()].Remove(editKeyword);
                            categories[listBox1.Text.ToString()].Add(textBox1.Text);
                            SaveCategoriesToJson();
                            Setup();
                            textBox1.Text = "";
                            label3.Text = "Muokkaa";
                            editName = null;
                            listBox1.Enabled = true;
                            listBox2.Enabled = true;
                            button8.Visible = false;
                            button3.Visible = false;
                            textBox1.Visible = false;
                            label3.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Avainsana on jo olemassa!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Uusi nimi ei voi olla tyhjä!");
                }
            }
            else
            {
                MessageBox.Show("Valitse muokattava kohde!");
            }

        }

        //Kategorian lisäyksen nappi
        private void button4_Click(object sender, EventArgs e)
        {
            // Tarkista, onko kategorian nimi annettu
            if (textBox2.Text != "")
            {
                // Tarkista, onko kategoria jo olemassa
                if (!categories.ContainsKey(textBox2.Text))
                {
                    // Lisää kategoria
                    AddCategory(textBox2.Text, new List<string>());
                    Setup();
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Kategoria on jo olemassa!");
                }
            }
            else
            {
                MessageBox.Show("Kategorian nimi ei voi olla tyhjä!");
            }

        }

        //Avainsanan poisto
        private void button5_Click(object sender, EventArgs e)
        {
            // Tarkista, onko avainsana valittu
            if (listBox2.SelectedIndex != -1)
            {
                // Poista avainsana

                // Varmista että käyttäjä haluaa poistaa avainsanan
                DialogResult dialogResult = MessageBox.Show("Haluatko varmasti poistaa avainsanan: " + listBox2.SelectedItem.ToString(), "Poista avainsana", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    categories[listBox1.SelectedItem.ToString()].Remove(listBox2.SelectedItem.ToString());
                    SaveCategoriesToJson();
                    Setup();
                }

            }
            else
            {
                MessageBox.Show("Valitse avainsana!");
            }   
        }

        //Kategorian poisto
        private void button6_Click(object sender, EventArgs e)
        {
            // Tarkista, onko kategoria valittu
            if (listBox1.SelectedIndex != -1)
            {
                // Poista kategoria

                // Varmista että käyttäjä haluaa poistaa kategorian
                DialogResult dialogResult = MessageBox.Show("Haluatko varmasti poistaa kategorian: " + listBox1.SelectedItem.ToString(), "Poista kategoria", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    RemoveCategory(listBox1.SelectedItem.ToString());
                    Setup();
                }

            }
            else
            {
                MessageBox.Show("Valitse kategoria!");
            }
        }

        //Avainsanan lisäys
        private void button7_Click(object sender, EventArgs e)
        {
            // Tarkista, onko kategoria valittu
            if (comboBox1.SelectedIndex != -1)
            {
                // Tarkista, onko avainsana annettu
                if (textBox3.Text != "")
                {
                    // Tarkista, onko avainsana jo olemassa
                    if (!categories[comboBox1.SelectedItem.ToString()].Contains(textBox3.Text))
                    {
                        // Lisää avainsana
                        categories[comboBox1.SelectedItem.ToString()].Add(textBox3.Text);
                        SaveCategoriesToJson();
                        Setup();
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Avainsana on jo olemassa!");
                    }
                }
                else
                {
                    MessageBox.Show("Avainsana ei voi olla tyhjä!");
                }
            }
            else
            {
                MessageBox.Show("Valitse kategoria!");
            }
        }

        //Muokkauksen peruutus
        private void button8_Click(object sender, EventArgs e)
        {
            editName = null;
            editCategory = null;
            editKeyword = null;
            label3.Text = "Muokkaa";
            textBox1.Text = "";
            listBox1.Enabled = true;
            listBox2.Enabled = true;
            button8.Visible = false;
            button3.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
        }

        //Kategorian valinta
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tarkista, onko ListBoxissa valittu jokin kohde
            if (listBox1.SelectedIndex != -1)
            {
                string selectedCategory = listBox1.SelectedItem.ToString().Split(':')[0].Trim();
                KeyWordFiler(selectedCategory);
            }
        }

        //Avainsanan valinta
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
