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
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace Euclid
{
    public partial class MainWnd : Form, IEuclidSite
    {
        private EucasmParser.ParsedEucasmCode current_construction;
        private LinkedListNode<IElement> current_element;
        private Bitmap canvas;
        private Configuration config;
        private EuclidesConfigGeneral ecg;
        private int partlevel;
        private string[] fParameters;
        private int fRadius;
        private bool fCheat;
        private string fWndTitle;
        private string fTitle;
        
        public MainWnd(string[] Parameters)
        {
            fCheat = false;
            fParameters = Parameters;
            current_element = null;
            InitializeComponent();
            AboutBox ab = new AboutBox();
            Text = fWndTitle = ab.AssemblyProduct + " v. " + ab.AssemblyVersion;

            partlevel = 0;
            fRadius = (int)(0.1 * GeneralConfig.DimX);

            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            if (config.Sections["general"] == null)
            {
                ecg = new EuclidesConfigGeneral();
                config.Sections.Add("general", ecg);
            }
            else
            {
                ecg = config.Sections["general"] as EuclidesConfigGeneral;
            }
            tmAnimation.Interval = ecg.AnimDelay;
            txtOutput.Font = ecg.CommentFont;
            txtOutput.ForeColor = ecg.CommentColor;

            UpdateRecentFiles();

            /* checking if file type registered if not doing so */
            #region SettingRegistry
            
            RegistryKey ftr = Registry.ClassesRoot.CreateSubKey(".euc");
            ftr.SetValue("", "EuclidFile");
            RegistryKey efr = Registry.ClassesRoot.CreateSubKey("EuclidFile").CreateSubKey("shell");
            efr.CreateSubKey("open").CreateSubKey("command").SetValue("", String.Format("{0} %0", Application.ExecutablePath));
            efr.CreateSubKey("edit").CreateSubKey("command").SetValue("", "notepad.exe %0");
            
            #endregion
        }

        protected void UpdateRecentFiles()
        {
            string[] lastfiles = ecg.LastOpened.Split(';');
            int n = Math.Min(lastfiles.Length, 5);

            if (n > 0 && lastfiles[n - 1] == "")
                n--;

            mnuRecent.Visible = false;
            for (int i = 0; i < n; i++)
            {
                mnuRecent.Visible = true;
                mnuRecent.DropDownItems[i].Text = lastfiles[i];
                mnuRecent.DropDownItems[i].Visible = true;
            }
            for (int i = n; i < 5; i++)
                mnuRecent.DropDownItems[i].Visible = false;
        }

        protected void DoOneStepOfConstruction()
        {
            if (ecg.Animated)
                DoOneStepOfConstruction(false);
            else
                DoOneStepOfConstruction(true);
        }

        protected void DoOneStepOfConstruction(bool Whole)
        {
            try
            {
                if (current_element == null)
                {
                    btnPause.Enabled = false;
                    btnStep.Enabled = false;
                    tmAnimation.Enabled = false;
                }
                else if (Whole)
                {
                    partlevel = 100;
                    current_element.Value.Execute(this as IEuclidSite, ref partlevel);
                    current_element = current_element.Next;
                    pbOutput.Image = canvas;
                    if (current_element == null)
                    {
                        btnPause.Enabled = false;
                        btnStep.Enabled = false;
                    }
                    partlevel = 0;
                }
                else if ((partlevel += 5) > 100)
                {
                    current_element = current_element.Next;
                    tmAnimation.Interval = ecg.AnimDelay;
                    partlevel = 0;
                }
                else
                {
                    tmAnimation.Interval = 10;

                    current_element.Value.Execute(this as IEuclidSite, ref partlevel);

                    pbOutput.Image = canvas;
                }
            }
            catch (ERuntimeError re)
            {
                tmAnimation.Enabled = false;
                MessageBox.Show("Runtime error while execution of script:\r\n" + re.Description);
                btnPause_Click(null, null);
            }
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you are going to quit the application?", "Quiting Euclid#", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;

        }

        private void tmClock_Tick(object sender, EventArgs e)
        {
            cbClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            (new AboutBox()).ShowDialog();
        }

        private void PrepareCanvas()
        {
            canvas = new Bitmap(GeneralConfig.DimX, GeneralConfig.DimY);
            Graphics grp = Graphics.FromImage(canvas);
            grp.FillRectangle(Brushes.White, new Rectangle(0, 0, GeneralConfig.DimX, GeneralConfig.DimY));
            pbOutput.Image = canvas;
            txtOutput.Text = "";
        }

        private void LoadScript(string FileName)
        {
            if (!File.Exists(FileName))
            {
                MessageBox.Show("File does not exist!");
                return; 
            }

            pbOutput.Visible = true;
            PrepareCanvas();

            FileStream fs = new FileStream(FileName, FileMode.Open);
            StreamReader fsr = new StreamReader(fs);
            string code = "";

            while (!fsr.EndOfStream)
                code += fsr.ReadLine() + "\n";

            fs.Close();

            try
            {
                partlevel = 0;
                EucasmParser.ParsedEucasmCode constr = EucasmParser.Parse(code);
                current_construction = constr;
                current_element = constr.elements.First;
                foreach (ToolStripButton tb in ConstructionControlBox.Items)
                    tb.Enabled = true;
                btnPause.Enabled = false;
                UpdateSimulationMenuEnability();

                if (current_element != null && current_element.Value.Type == "Text")
                {
                    fTitle = current_element.Value.Comment.Replace("\r\n", " ").TrimEnd(' ', '\t');
                    Text = string.Format("{0} - {1}", fWndTitle, fTitle);
                }
                else
                {
                    string [] fnParts = FileName.Split(new char [] {'/', '\\', '.'});
                    fTitle = fnParts[fnParts.Length - 2];
                    Text = fWndTitle;
                }
            }
            catch (EucasmParser.EParseError pe)
            {
                pbOutput.Visible = false;
                MessageBox.Show(String.Format("Parse error on line {0:d}: {1}. \nConstruction abandoned.", pe.Line, pe.Description), "Eucasm parse error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mnuExport.Enabled = true;
            mnuHTMLraport.Enabled = true;

            if (ecg.LastOpened.Split(';')[0] != FileName)
                ecg.LastOpened = FileName + ';' + ecg.LastOpened;
            UpdateRecentFiles();
            ecg.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);

            ExportDialog.FileName = FileName.Remove(FileName.LastIndexOf('.')) + ".png";
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                LoadScript(OpenDialog.FileName);
            }
        }

        #region IEuclidSite implementation

        public Graphics GetGraphics()
        {
            return Graphics.FromImage(canvas);
        }

        public Pen GetPen(PenType type)
        {
            switch (type)
            {
                case PenType.ptPoint:
                    return new Pen(ecg.PointColor, ecg.PointWidth);
                case PenType.ptLabel:
                    return new Pen(ecg.LabelColor, 1);
                case PenType.ptLine:
                    return new Pen(ecg.LineColor, ecg.LineWidth);
                case PenType.ptCurve:
                    return new Pen(ecg.ArcColor, ecg.ArcWidth);
                default:
                    return new Pen(Color.Black, 2);
            }
        }

        public Font GetFont(FontType type)
        {
            return ecg.LabelFont;
        }

        public void OutputText(string Text)
        {
            #region Drawing emoticons
            foreach (string emotname in emoticons.Images.Keys)
            {
                if (Text == emotname)
                {
                    Bitmap bmp = new Bitmap(40, 40);
                    Graphics grp = Graphics.FromImage(bmp);
                    grp.FillRectangle(new SolidBrush(txtOutput.BackColor), new Rectangle(0, 0, 45, 45));
                    grp.DrawImage(emoticons.Images[emotname], 0, 0, 40, 40);
                    Clipboard.SetDataObject(bmp, false);
                    txtOutput.ReadOnly = false;
                    txtOutput.Paste();
                    txtOutput.ReadOnly = true;
                    txtOutput.AppendText("\r\n");
                    txtOutput.ScrollToCaret();
                    return;
                }
            }
            #endregion

            if (txtOutput.Text != "")
            {
                txtOutput.SelectionBackColor = Color.Transparent;
                txtOutput.SelectAll();
                txtOutput.SelectionFont = new Font(txtOutput.SelectionFont, FontStyle.Regular);
                txtOutput.DeselectAll();
            }
            txtOutput.AppendText(Text + "\r\n");
            txtOutput.ScrollToCaret();
        }

        public int Radius {
            get {
                return fRadius;
            }
            set {
                fRadius = value;
            }
        }

        public IElement GetLabeledElement(string Label)
        {
            if (current_construction.labels == null)
            {
                return null;
            }
            else
            {
                IElement res;
                if (current_construction.labels.TryGetValue(Label, out res))
                    return res;
                else
                    return null;
            }
        }

        #endregion

        private void UpdateSimulationMenuEnability()
        {
            mnuRewind.Enabled = btnRestart.Enabled;
            mnuPlay.Enabled = btnPlay.Enabled;
            mnuPause.Enabled = btnPause.Enabled;
            mnuStepForward.Enabled = btnStep.Enabled;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            btnPause.Enabled = true;
            btnStep.Enabled = false;
            UpdateSimulationMenuEnability();
            tmAnimation.Enabled = true;
            DoOneStepOfConstruction();
        }

        private void tmAnimation_Tick(object sender, EventArgs e)
        {
            DoOneStepOfConstruction();
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            DoOneStepOfConstruction(true);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            tmAnimation.Enabled = false;
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
            btnStep.Enabled = true;
            UpdateSimulationMenuEnability();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (current_element == null)
            {
                btnPlay.Enabled = true;
                btnStep.Enabled = true;
                UpdateSimulationMenuEnability();
            }
            current_element = current_construction.elements.First;
            partlevel = 0;
            PrepareCanvas();
        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            if (ExportDialog.ShowDialog() == DialogResult.OK)
            {
                ImageFormat format = ImageFormat.Png;

                switch (ExportDialog.FilterIndex)
                {
                    case 1:
                        format = ImageFormat.Jpeg;
                        break;
                    case 2:
                        format = ImageFormat.Png;
                        break;
                    case 3:
                        format = ImageFormat.Gif;
                        break;
                    case 4:
                        format = ImageFormat.Bmp;
                        break;
                    case 5:
                        format = ImageFormat.Tiff;
                        break;
                }

                pbOutput.Image.Save(ExportDialog.FileName, format);
            }
        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            if (fParameters.GetLength(0) >= 1)
                LoadScript(fParameters[0]);
        }

        private void MainWnd_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files[0].EndsWith(".euc"))
                    e.Effect = DragDropEffects.All;
            }
        }

        private void MainWnd_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string [] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                LoadScript(files[0]);
            }
        }

        private void mnuRecentFile0_Click(object sender, EventArgs e)
        {
            LoadScript((sender as ToolStripMenuItem).Text);
        }

        private void mnuClearRecent_Click(object sender, EventArgs e)
        {
            ecg.LastOpened = "";
            UpdateRecentFiles();
            ecg.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);
        }

        private void pbOutput_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void pbOutput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                fCheat = !fCheat;
            }
            
        }

        private void btnOpen_MouseUp(object sender, MouseEventArgs e)
        {
            if (fCheat && e.Button == MouseButtons.Right)
                pbOutput.Image = global::Euclid.Properties.Resources.matrix;
        }

        private void btnAbout_MouseUp(object sender, MouseEventArgs e)
        {
            if (fCheat && e.Button == MouseButtons.Right)
                pbOutput.Image = global::Euclid.Properties.Resources.norris2;
        }

        private void mnuHTMLraport_Click(object sender, EventArgs e)
        {
            ExportHTMLOptionsDialog od = new ExportHTMLOptionsDialog();
            od.txtTitle.Text = fTitle;
            if (ExportHTMLDialog.ShowDialog() == DialogResult.OK && od.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                HTMLexporter expor = new HTMLexporter(ExportHTMLDialog.FileName, od.txtTitle.Text, current_construction, ecg);
                expor.Go();
                Cursor = Cursors.Default;
                if (od.cbPreview.Checked)
                    System.Diagnostics.Process.Start(ExportHTMLDialog.FileName);
                else
                    MessageBox.Show("The HTML report successfully generated!");
            }
        }

        private void mnuConfiguration_Click(object sender, EventArgs e)
        {
            using (ConfigWnd confwnd = new ConfigWnd(config, ecg))
                confwnd.ShowDialog();
            txtOutput.Font = ecg.CommentFont;
            txtOutput.ForeColor = ecg.CommentColor;
        }

        private void mnuEucasmRef_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.AppStarting;
                System.Diagnostics.Process.Start("eucasm_documentation.pdf");
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Sorry. Cannot load the documentation.\r\nThe file may be missing\r\nor Adobe Acrobat Reader not installed.", "Error loading documentation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        
    }
}