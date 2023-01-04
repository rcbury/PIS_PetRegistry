﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIS_PetRegistry.Controllers;
using PIS_PetRegistry.DTO;

namespace PIS_PetRegistry.Forms
{
    public partial class VaccinationForm : Form
    {
        public VaccinationForm(int FKAnimal)
        {
            var vaccines = ParasiteTreatmentController.GetMedications();

            vaccinationDTO = new VaccinationDTO();
            vaccinationDTO.FkAnimal = FKAnimal;

            InitializeComponent();

            vaccineComboBox.DataSource = vaccines;
            vaccineComboBox.ValueMember = "Id";
            vaccineComboBox.DisplayMember = "Name";

            FillFields();
        }


        public VaccinationForm(VaccinationDTO vaccinationDTO)
        {
            var vaccines = ParasiteTreatmentController.GetMedications();

            this.vaccinationDTO = vaccinationDTO;

            InitializeComponent();

            vaccineComboBox.DataSource = vaccines;
            vaccineComboBox.ValueMember = "Id";
            vaccineComboBox.DisplayMember = "Name";

            FillFields();
        }

        private VaccinationDTO vaccinationDTO;

        public void FillFields()
        {
            vaccineComboBox.SelectedValue = vaccinationDTO.FkVaccine;
            if (vaccinationDTO.DateEnd.Year != 1)
                vaccinationDatePicker.Value = DateTime.Parse(vaccinationDTO.DateEnd.ToShortDateString());
        }

        private void ValidateFields()
        {
            if (vaccineComboBox.SelectedValue == null)
                throw new Exception("Не выбрана вакцина");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ValidateFields();

            if (vaccinationDTO.FkUser == null)
            {
                var tempVaccinationDTO = new VaccinationDTO()
                {
                    FkVaccine = int.Parse(vaccineComboBox.SelectedValue.ToString()),
                    DateEnd = DateOnly.Parse(vaccinationDatePicker.Value.ToShortDateString()),
                    FkAnimal = vaccinationDTO.FkAnimal,
                };

                var authorizedUser = AuthorizationController.GetAuthorizedUser();

                vaccinationDTO = VaccinationController.AddVaccination(tempVaccinationDTO, authorizedUser);
            }
            else
            {
                var tempVaccinationDTO = new VaccinationDTO()
                {
                    FkUser = vaccinationDTO.FkUser,
                    FkVaccine = int.Parse(vaccineComboBox.SelectedValue.ToString()),
                    DateEnd = DateOnly.Parse(vaccinationDatePicker.Value.ToShortDateString()),
                    FkAnimal = vaccinationDTO.FkAnimal,
                };

                var authorizedUser = AuthorizationController.GetAuthorizedUser();

                vaccinationDTO = VaccinationController.UpdateVaccination(tempVaccinationDTO, authorizedUser);
            }
        }
    }
}
