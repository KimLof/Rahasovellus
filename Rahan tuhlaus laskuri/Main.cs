using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace Rahan_tuhlaus_laskuri
{
    public partial class Main : Form
    {
        private Dictionary<string, List<string>> categories;
        private Dictionary<string, decimal> categorySums;

        private string categoryFilePath = "categories.json";
        private CategoryConfig categoryConfig;
        public Main()
        {
            InitializeComponent();
            LoadCategoriesFromJson(); // Lataa kategoriat JSON-tiedostosta sovelluksen käynnistyessä
            categorySums = new Dictionary<string, decimal>();
            SetupDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void LoadCategoriesFromJson()
        {
            try
            {
                if (File.Exists(categoryFilePath))
                {
                    // Tämä lukee JSON-tiedoston sisällön tiedostopolusta
                    string json = File.ReadAllText(categoryFilePath);
                    // Tämä deserialisoi luettu JSON-tiedoston sisällön CategoryConfig-olioon
                    categoryConfig = JsonSerializer.Deserialize<CategoryConfig>(json);
                    categories = categoryConfig.Categories.ToDictionary(c => c.Name, c => c.Keywords);
                }
                else
                {
                    // Alustetaan tietokanta seuraavilla kategorioilla
                    categoryConfig = new CategoryConfig
                    {
                        Categories = new List<Category>
                        {
                            new Category { Name = "Matkakulut", Keywords = new List<string> {"HSL MOBIILI", "Hsl Mobiili"}},
                            new Category { Name = "Ruokakauppa", Keywords = new List<string> {"PRISMA", "K-CITYMARKET", "ALEPA", "K-Market", "K-supermarket", "K-SUPERMARKET", "k-market"}},
                            new Category { Name = "Ravintolat", Keywords = new List<string> {"Wolt"}},
                            new Category { Name = "Mobilepay", Keywords = new List<string> {"Mobilepay", "Mob.pay"}},
                            new Category { Name = "Vaatteet", Keywords = new List<string> {}},
                            new Category { Name = "Viihde", Keywords = new List<string> {}},
                            new Category { Name = "Kodintarvike", Keywords = new List<string> {}},
                            new Category { Name = "Elektroniikka", Keywords = new List<string> {}},
                            new Category { Name = "Kauneudenhoito", Keywords = new List<string> {}},
                            new Category { Name = "Elinkustannukset", Keywords = new List<string> {"ELISA", "HELEN", "Telia"}},
                            new Category { Name = "Palkka", Keywords = new List<string> {}},
                            new Category { Name = "Säästöt", Keywords = new List<string> {}},
                            new Category { Name = "Huoltoasemat", Keywords = new List<string> {"NESTE", "ST1", "Neste"}},
                            new Category { Name = "Edut", Keywords = new List<string> {"KANSANELÄKELAITOS"}},
                            new Category { Name = "Muut", Keywords = new List<string> {}}

                        }
                    };
                    categories = categoryConfig.Categories.ToDictionary(c => c.Name, c => c.Keywords);
                    // Tallenna luotu kategoriarakenne JSON-tiedostoon
                    SaveCategoriesToJson();
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JSON deserialisointivirhe: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yleinen virhe: {ex.Message}");
            }
        }




        private void SaveCategoriesToJson()
        {
            string json = JsonSerializer.Serialize(categoryConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(categoryFilePath, json);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            // Tyhjentää kategorioittain lasketut summat
            categorySums.Clear();
            listBox1.Items.Clear();

            // Asettaa tiedostonvalitsimen ominaisuuksia
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog1.Title = "Valitse tiliote CSV-muodossa";

            openFileDialog1.ShowDialog();
        }



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Hankkii valitun tiedoston polku
            string filePath = openFileDialog1.FileName;

            // Lue tiedoston sisältö
            try
            {
                var fileContent = System.IO.File.ReadAllLines(filePath);
                ProcessFileContent(fileContent);
                btnExpenses.Enabled = true;
                btnIncome.Enabled = true;
                btnReset.Enabled = true;
                dataGridView1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Virhe tiedoston lukemisessa: " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tarkistaa, onko ListBoxissa valittu jokin kohde
            if (listBox1.SelectedIndex != -1)
            {
                string selectedCategory = listBox1.SelectedItem.ToString().Split(':')[0].Trim();
                FilterDataGridViewByCategory(selectedCategory);
            }
        }

        private void FilterDataGridViewByCategory(string category)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var rowCategory = row.Cells["category"].Value?.ToString();
                    row.Visible = rowCategory == category;
                }
            }
        }


        private void ProcessFileContent(string[] fileContent)
        {
            // Käytetään suomalaista kulttuuria, koska CSV:ssä käytetään pilkkua desimaalierottimena.
            var finnishCulture = new CultureInfo("fi-FI");

            // Tarkistaa mikä pankki on kyseessä columnien määrän perusteella
            if (fileContent[0].Split(';').Length == 5)
            {
                // Handelsbanken

                foreach (var line in fileContent.Skip(1)) // Ohita otsikkorivi
                {
                    var columns = line.Split(';').Select(c => c.Trim('"')).ToArray();
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);

                    row.Cells[0].Value = columns[0];
                    row.Cells[1].Value = columns[1];
                    if (decimal.TryParse(columns[4], NumberStyles.Any, finnishCulture, out decimal amount))
                    {
                        row.Cells[2].Value = amount;
                    }
                    else
                    {
                        // Käsittelee virheellinen numeerinen arvo
                        row.Cells[2].Value = 0;
                        MessageBox.Show("Virheellinen numeerinen arvo rivillä: " + line);
                    }

                    dataGridView1.Rows.Add(row);
                    // Päivittää päivämääräväli
                    UpdateDateRangeLabel("Handelsbanken");
                }

            }
            else if (fileContent[0].Split(';').Length == 9)
            {
                // Nordea

                foreach (var line in fileContent.Skip(1)) // Ohittaa otsikkorivin
                {
                    var columns = line.Split(';').Select(c => c.Trim('"')).ToArray();
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);

                    row.Cells[0].Value = columns[0];
                    row.Cells[1].Value = columns[5];
                    if (decimal.TryParse(columns[1], NumberStyles.Any, finnishCulture, out decimal amount))
                    {
                        row.Cells[2].Value = amount;
                    }
                    else
                    {
                        // Käsittelee virheellinen numeerinen arvon
                        row.Cells[2].Value = 0;
                        MessageBox.Show("Virheellinen numeerinen arvo rivillä: " + line);
                    }

                    dataGridView1.Rows.Add(row);
                    // Päivittää päivämääräväli
                    UpdateDateRangeLabel("Nordea");
                }


            }
            else if (fileContent[0].Split(';').Length == 11) 
            {
                // S-Pankki

                foreach (var line in fileContent.Skip(1)) // Ohittaa otsikkorivin
                {
                    var columns = line.Split(';').Select(c => c.Trim('"')).ToArray();
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);

                    row.Cells[0].Value = columns[0];
                    row.Cells[1].Value = columns[5];
                    if (decimal.TryParse(columns[2], NumberStyles.Any, finnishCulture, out decimal amount))
                    {
                        row.Cells[2].Value = amount;
                    }
                    else
                    {
                        // Käsittelee virheellinen numeerinen arvon
                        row.Cells[2].Value = 0;
                        MessageBox.Show("Virheellinen numeerinen arvo rivillä: " + line);
                    }

                    dataGridView1.Rows.Add(row);
                    // Päivittää päivämäärävälin
                    UpdateDateRangeLabel("S-Pankki");
                }


            }
            else
            {
                MessageBox.Show("Tuntematon pankki.\nTällä hetkellä toimivat pankit ovat:\n Handelsbanken \n Nordea \n S-Pankki");
            }

            // Kategorisoi ja laskee summat kun kaikki rivit on lisätty
            CategorizeAndDisplayTransactions();
            CalculateAndDisplayCategorySums();
        }



        private void SetupDataGridView()
        {
            // Tyhjentää aiemmat sarakkeet
            dataGridView1.Columns.Clear();

            // Lisää sarakkeet
            dataGridView1.Columns.Add("paivamaara", "Päivämäärä");
            dataGridView1.Columns.Add("saajaMaksaja", "Saaja/Maksaja");
            dataGridView1.Columns.Add("maara", "Määrä");

            dataGridView1.Columns["paivamaara"].ReadOnly = true;
            dataGridView1.Columns["saajaMaksaja"].ReadOnly = true;
            dataGridView1.Columns["maara"].ReadOnly = true;

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12); 
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            // Viimeinen sarake dropdown menuksi
            DataGridViewComboBoxColumn categoryColumn = new DataGridViewComboBoxColumn();
            categoryColumn.Name = "category";
            categoryColumn.HeaderText = "Kategoria";
            categoryColumn.DataSource = categories.Keys.ToList();
            dataGridView1.Columns.Add(categoryColumn);

            dataGridView1.Columns["category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void CategorizeAndDisplayTransactions()
        {
            listBox1.Items.Clear(); // Tyhjentää ListBox ennen uusien arvojen lisäämistä
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string description = row.Cells["saajaMaksaja"].Value.ToString().Trim().ToLower();
                    string category = "Muut"; // Oletuskategoria, jos mikään ei täsmää

                    foreach (var entry in categories)
                    {
                        if (entry.Value.Any(keyword => description.Contains(keyword.ToLower())))
                        {
                            category = entry.Key;
                            break;
                        }
                    }

                    row.Cells["category"].Value = category;

                    // Lisää tai päivittää kategorian summan
                    if (!categorySums.ContainsKey(category))
                    {
                        categorySums[category] = 0;
                    }

                    categorySums[category] += Convert.ToDecimal(row.Cells["maara"].Value);
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Enabled == false)
            {
                return;
            }
            else
            {
                // Tarkistaa onko kyseessä kategoriasolu
                if (dataGridView1.CurrentCell.ColumnIndex == 3)
                {
                    changeKeyword();
                }
            }

        }

        private void changeKeyword()
        {
            //Muuttaa keywordin valitulle kategorialle
            string newKeyword= dataGridView1.CurrentRow.Cells["saajaMaksaja"].Value.ToString();
            string selectedCategory = dataGridView1.CurrentRow.Cells["category"].Value.ToString();

            // Poistaa vanha keyword jokaisesa kategoriassa
            foreach (var entry in categories)
            {
                if (entry.Value.Contains(newKeyword))
                {
                    entry.Value.Remove(newKeyword);
                }
            }

            if (selectedCategory != "Muut")
            {
                categories[selectedCategory].Add(newKeyword);
            }
            categoryConfig.Categories = categories.Select(c => new Category { Name = c.Key, Keywords = c.Value }).ToList();
            SaveCategoriesToJson();

            categorySums.Clear();
            listBox1.Items.Clear();

            CategorizeAndDisplayTransactions();
            CalculateAndDisplayCategorySums();
        }

        private void CalculateAndDisplayCategorySums()
        {
            listBox1.Items.Clear(); // Tyhjentää ListBox ennen uusien arvojen lisäämistä
            decimal totalIncome = 0m;
            decimal totalExpenses = 0m;

            foreach (var entry in categorySums)
            {
                listBox1.Items.Add($"{entry.Key}: {entry.Value.ToString("C2", CultureInfo.CurrentCulture)}");
                if (entry.Value > 0)
                    totalIncome += entry.Value;
                else
                    totalExpenses += entry.Value;
            }

            // Päivittää kuukauden tulos ja menetykset
            labelIncome.Text = $"Tulot: {totalIncome:C2}";
            labelExpenses.Text = $"Menot: {totalExpenses:C2}";
            labelTotal.Text = $"Tulos: {(totalIncome + totalExpenses):C2}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Näyttää kaikki rivit, joissa määrä on positiivinen (tulot)
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal amount = Convert.ToDecimal(row.Cells["maara"].Value);
                    row.Visible = amount > 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Näyttää kaikki rivit, joissa määrä on negatiivinen (menot)
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal amount = Convert.ToDecimal(row.Cells["maara"].Value);
                    row.Visible = amount < 0;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Poistaa kaikki suodattimet ja näyttää kaikki rivit
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Visible = true;
                }
            }
        }

        private void UpdateDateRangeLabel(string pankki)
        {
                // Päivittää päivämäärä dd.MM.yyyy muodosta
                var dates = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => r.Cells["paivamaara"].Value?.ToString())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s =>
                    {
                        DateTime date;
                        if (DateTime.TryParseExact(s, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                            return date;
                        else if (DateTime.TryParseExact(s, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                            return date;
                        else
                            return DateTime.MinValue;
                    })
                    .Where(date => date != DateTime.MinValue)
                    .ToList();

                if (dates.Count == 0)
                {
                    labelDate.Text = "Ei tapahtumia.";
                    return;
                }

                var minDate = dates.Min();
                var maxDate = dates.Max();

                // Päivittää labelDate näyttämään aikavälin
                labelDate.Text = $"Aikaväli: {minDate.ToShortDateString()} - {maxDate.ToShortDateString()}";
            
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            // Asettaa tiedostonvalitsimen ominaisuuksia
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog1.Title = "Valitse tiliote CSV-muodossa";

            // Näyttää tiedostonvalitsin
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Tyhjennä DataGridView ennen uuden tiedoston lataamista
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                // Tyhjennä kategorioittain lasketut summat
                categorySums.Clear();
                listBox1.Items.Clear();

                // Hanki valitun tiedoston polku
                string filePath = openFileDialog1.FileName;

                // Lue tiedoston sisältö
                try
                {
                    var fileContent = System.IO.File.ReadAllLines(filePath);
                    ProcessFileContent(fileContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Virhe tiedoston lukemisessa: " + ex.Message);
                }
            }
        }

        private void muokkaaKategToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Edit.cs form
            Edit edit = new Edit();
            this.Hide();
            edit.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tarkista ettei ole kategoriasolu
            if (dataGridView1.CurrentCell.ColumnIndex != 3)
            {
                string message = "";
                string filePath = openFileDialog1.FileName;
                var fileContent = System.IO.File.ReadAllLines(filePath);

                // Tarkista mikä pankki on kyseessä columnien määrän perusteella
                if (fileContent[0].Split(';').Length == 5)
                {
                    // Handelsbanken
                    foreach (var line in fileContent.Skip(1))
                    {
                        var columns = line.Split(';').Select(c => c.Trim('"')).ToArray();
                        if (columns[1] == dataGridView1.CurrentRow.Cells["saajaMaksaja"].Value.ToString() && columns[4] == dataGridView1.CurrentRow.Cells["maara"].Value.ToString())
                        {
                            message = "Päivämäärä: " + columns[0] + "\n" +
                                "Saaja/Maksaja: " + columns[1] + "\n" +
                                "Selite: " + columns[2] + "\n" +
                                "Määrä: " + columns[3] + "€";

                            dialog.Show(message);
                            return;
                        }
                    }
                }
                else if (fileContent[0].Split(';').Length == 9)
                {
                    // Nordea
                    foreach (var line in fileContent.Skip(1))
                    {
                        var columns = line.Split(';').Select(c => c.Trim('"')).ToArray();
                        if (columns[5] == dataGridView1.CurrentRow.Cells["saajaMaksaja"].Value.ToString() && columns[1] == dataGridView1.CurrentRow.Cells["maara"].Value.ToString())
                        {
                            message = "Kirjauspäivä: " + columns[0] + "\n" +
                                "Määrä: " + columns[1] + "\n" +
                                "Maksaja: " + columns[2] + "\n" +
                                "Maksunsaaja: " + columns[3] + "\n" +
                                "Nimi: " + columns[4] + "\n" +
                                "Otsikko: " + columns[5] + "\n" +
                                "Viitenumero: " + columns[6] + "\n" +
                                "Valuutta: " + columns[7];

                            dialog.Show(message);
                            return;
                        }
                    }
                }
                else if (fileContent[0].Split(';').Length == 11)
                {
                    // S-Pankki
                    foreach (var line in fileContent.Skip(1))
                    {
                        var columns = line.Split(';').Select(c => c.Trim('"')).ToArray();
                        if (columns[5] == dataGridView1.CurrentRow.Cells["saajaMaksaja"].Value.ToString() && (columns[2] == "+" + dataGridView1.CurrentRow.Cells["maara"].Value.ToString() || columns[2] == dataGridView1.CurrentRow.Cells["maara"].Value.ToString()))
                        {
                            message = "Kirjauspäivä: " + columns[0] + "\n" +
                                "Maksupäivä: " + columns[1] + "\n" +
                                "Summa: " + columns[2] + "\n" +
                                "Tapahtumalaji: " + columns[3] + "\n" +
                                "Maksaja: " + columns[4] + "\n" +
                                "Saajan nimi: " + columns[5] + "\n" +
                                "Saajan tilinumero: " + columns[6] + "\n" +
                                "Saajan BIC-tunnus: " + columns[7] + "\n" +
                                "Viitenumero: " + columns[8] + "\n" +
                                "Viesti: " + columns[9] + "\n" +
                                "Arkistotunnus: " + columns[10] + "€";

                            dialog.Show(message);
                            return;
                        }
                    }   

                    
                }
            }
        }
    }
}
