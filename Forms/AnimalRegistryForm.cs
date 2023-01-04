﻿using PIS_PetRegistry.Controllers;
using PIS_PetRegistry.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS_PetRegistry
{
    public partial class AnimalRegistryForm : Form
    {
        private List<AnimalCardDTO> _listAnimalCards;
        private List<AnimalCategoryDTO> _animalCategories;
        public AnimalRegistryForm(UserDTO user = null!)
        {
            InitializeComponent();
            _animalCategories = AnimalCardController.GetAnimalCategories();
            comboBox2.DataSource = _animalCategories;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PetOwnersForm form = new PetOwnersForm();
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FilterOption form = new FilterOption();
            //form.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AnimalCardForm form = new AnimalCardForm();
            form.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
