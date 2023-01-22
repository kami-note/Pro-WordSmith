using System;
using System.IO;
using System.Windows.Forms;

namespace Pro_WordSmith
{
    public partial class Form1 : Form
    {
        private Button createButton;
        private OpenFileDialog openFileDialog;
        private Button openButton;
        private Button saveButton;
        private TextBox textEditor;
        private Label statusCharCount;
        private Label statusCursorPosition;

        public Form1()
        {
            InitializeComponent();

            // Initialize components
            createButton = new Button();
            createButton.Text = "Criar";
            createButton.Click += new EventHandler(CreateButton_Click);

            openFileDialog = new OpenFileDialog();

            openButton = new Button();
            openButton.Text = "Abrir";
            openButton.Click += new EventHandler(OpenButton_Click);

            saveButton = new Button();
            saveButton.Text = "Salvar";
            saveButton.Click += new EventHandler(SaveButton_Click);

            textEditor = new TextBox();
            textEditor.Multiline = true;
            textEditor.KeyUp += new KeyEventHandler(TextEditor_KeyUp);
            textEditor.MouseUp += new MouseEventHandler(TextEditor_MouseUp);

            statusCharCount = new Label();
            statusCursorPosition = new Label();

            // Add controls to form
            Controls.Add(createButton);
            Controls.Add(openButton);
            Controls.Add(saveButton);
            Controls.Add(textEditor);
            Controls.Add(statusCharCount);
            Controls.Add(statusCursorPosition);

            // Load content from local storage
            textEditor.Text = Properties.Settings.Default.Content;
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            textEditor.Clear();
            Properties.Settings.Default.Content = "";
            Properties.Settings.Default.Save();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                {
                    textEditor.Text = reader.ReadToEnd();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    writer.Write(textEditor.Text);
                }
            }
        }

        private void TextEditor_KeyUp(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.Content = textEditor.Text;
            Properties.Settings.Default.Save();
            statusCharCount.Text = textEditor.Text.Length + " caracteres";
        }

        private void TextEditor_MouseUp(object sender, MouseEventArgs e)
        {
            int cursorPos = textEditor.SelectionStart;
            statusCursorPosition.Text = "posição do cursor: " + cursorPos;
        }
    }
}