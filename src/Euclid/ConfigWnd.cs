/* Euclid# - Euclidean Geometry Constructions Simulator 
 * 
 * Copyright (c) 2006 Krzysztof Olczyk
 * 
 * Program written for Programming Project Course
 * at Technical University of Lodz, Fall 2006
 * 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Euclid
{
    public partial class ConfigWnd : Form
    {
        private Configuration config;
        private EuclidesConfigGeneral ecg;

        public ConfigWnd(Configuration AConfig, EuclidesConfigGeneral ECG)
        {
            config = AConfig;
            ecg = ECG;
            InitializeComponent();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = (sender as Button).BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = colorDialog.Color;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = (sender as Button).Font;
            fontDialog.Color = (sender as Button).ForeColor;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).Font = fontDialog.Font;
                (sender as Button).ForeColor = fontDialog.Color;
            }
        }

        private void ConfigWnd_Load(object sender, EventArgs e)
        {
            nupDelay.Value = ecg.AnimDelay;
            cbAnimated.Checked = ecg.Animated;
            btnPLFont.Font = ecg.LabelFont;
            btnPLFont.ForeColor = ecg.LabelColor;
            btnCCFont.Font = ecg.CommentFont;
            btnCCFont.ForeColor = ecg.CommentColor;
            btnLineColor.BackColor = ecg.LineColor;
            nupLineWidth.Value = ecg.LineWidth;
            btnArcColor.BackColor = ecg.ArcColor;
            nupArcWidth.Value = ecg.ArcWidth;
            btnPointsColor.BackColor = ecg.PointColor;
            nupPointsWidth.Value = ecg.PointWidth;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ecg.AnimDelay = (int)nupDelay.Value;
            ecg.Animated = cbAnimated.Checked;
            ecg.LabelFont = btnPLFont.Font;
            ecg.LabelColor = btnPLFont.ForeColor;
            ecg.CommentFont = btnCCFont.Font;
            ecg.CommentColor = btnCCFont.ForeColor;
            ecg.LineColor = btnLineColor.BackColor;
            ecg.LineWidth = (int)nupLineWidth.Value;
            ecg.ArcColor = btnArcColor.BackColor;
            ecg.ArcWidth = (int)nupArcWidth.Value;
            ecg.PointColor = btnPointsColor.BackColor;
            ecg.PointWidth = (int)nupPointsWidth.Value;

            ecg.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }
    }
}