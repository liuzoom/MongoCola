﻿using MongoDB.Bson;
using ResourceLib.Method;
using System;
using System.Windows.Forms;

namespace FunctionForm.Operation
{
    public partial class frmCreateGeo : Form
    {
        /// <summary>
        /// Geo BsonArray
        /// </summary>
        public BsonArray mBsonArray;

        public frmCreateGeo()
        {
            InitializeComponent();
        }

        private void frmCreateGeo_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
                cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
                lblLongitude.Text = GuiConfig.GetText("Common_Longitude");
                lblLatitude.Text = GuiConfig.GetText("Common_Latitude");
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //Always list coordinates in longitude, latitude order.
            double longitude;
            if (!double.TryParse(txtLongitude.Text, out longitude))
            {
                MessageBox.Show("Longitude is not a double");
                return;
            }
            double latitude;
            if (!double.TryParse(txtLatitude.Text, out latitude))
            {
                MessageBox.Show("Latitude is not a double");
                return;
            }
            if (rad2dSphere.Checked)
            {
                //WGS48
                if (longitude > 180 || longitude < -180)
                {
                    MessageBox.Show("Longitude is not in range [-180,180]");
                    //经度
                    return;
                }
                if (latitude > 90 || latitude < -90)
                {
                    MessageBox.Show("Latitude is not in range [-90,90]");
                    //维度
                    return;
                }
            }
            mBsonArray = new BsonArray();
            mBsonArray.Add(longitude);
            mBsonArray.Add(latitude);
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
