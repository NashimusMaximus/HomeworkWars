using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_Wars_External_Tool
{
    public static class Prompt
    {
        public static string ShowDialog(string title, string text)
        {
            //Create the new form for the prompt
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            //Create 
            Label variableLabel = new Label() { Left = 5, Top = 20, Width = 395, Text = text };
            TextBox valueBox = new TextBox() { Left = 25, Top = 40, Width = 335 };
            Button setButton = new Button() { Text = "Set", Left = 150, Width = 85, Top = 70, DialogResult = DialogResult.OK };
            setButton.Click += (sender, e) => { prompt.Close(); };

            //Add the prompt controls so the form works properly
            prompt.Controls.Add(valueBox);
            prompt.Controls.Add(setButton);
            prompt.Controls.Add(variableLabel);
            prompt.AcceptButton = setButton;

            return prompt.ShowDialog() == DialogResult.OK ? valueBox.Text : "";
        }
    }
}
