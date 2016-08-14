using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace AUTOMATA_MC_LC2
{
    public partial class LexicalAnalyzer : Form
    {
        public LexicalAnalyzer()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Lexeme";
            dataGridView1.Columns[1].Name = "Token";
        }
        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generate_Click(sender, e);
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string Text = "";
            Text = textBox1.Text;
           // char[] SyntaxArray = Text.ToCharArray();

            string[] Syntax = Text.Split('\r', '\n');

            foreach(string items in Syntax) {
                char[] item = items.ToCharArray();
                if (items.Contains("abort")) {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "abort")
                            {
                                dataGridView1.Rows.Add(temp,"VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if(temp == " ") {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ")")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsDigit))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("PrimaryMission")) {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if(temp.All(char.IsLetter)) { 
                            if (temp == "PrimaryMission"){
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(") {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == " "){
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if(temp == ")") {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "{"){
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if(temp.All(char.IsDigit)) {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("post"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "post")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if(temp.Length > 10) {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == " ")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if(temp == "\"") 
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if(temp.Contains("\"")) {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("\"", "VALID");
                                temp = "";
                            }
                            else if (temp == ")")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsDigit))
                            {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("captured"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "captured")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == " ")
                            {
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp == "%")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "\"")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("\""))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                if (temp.Contains("d") || (temp.Contains("f")) || (temp.Contains("s"))) {
                                    dataGridView1.Rows.Add(special, "VALID");
                                }
                                else {
                                    dataGridView1.Rows.Add(special, "INVALID");
                                }
                                dataGridView1.Rows.Add("\"", "VALID");
                                temp = "";
                            }
                            else if (temp == ",")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains(")"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add(")", "VALID");
                                temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsDigit))
                            {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("unit")|| (items.Contains("digit")))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "unit")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == " ")
                            {
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if ((temp.Contains(" ")))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("="))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("=", "VALID");
                                temp = "";
                            }
                            else if (temp == "=")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsDigit))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains(";"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add(";", "VALID");
                                temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ".")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("company"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "company")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == " ")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if ((temp.Contains(" ")))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("="))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("=", "VALID");
                                temp = "";
                            }
                            else if (temp == "=")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "\"")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("\""))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("\"", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains(";"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add(";", "VALID");
                                temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("response"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();

                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "response")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if(temp.Length <=10) {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == " ")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if ((temp.Contains(" ")))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("="))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                if ((special == "true") || (special == "false"))
                                {
                                    dataGridView1.Rows.Add(special, "VALID");
                                    temp = "";
                                }
                                else {
                                    dataGridView1.Rows.Add(special, "INVALID");
                                    temp = "";
                                }
                                dataGridView1.Rows.Add("=", "VALID");
                                temp = "";
                            }
                            else if (temp == "=")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains(";"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                if ((special == "true") || (special == "false"))
                                {
                                    dataGridView1.Rows.Add(special, "VALID");
                                    temp = "";
                                }
                                else {
                                    dataGridView1.Rows.Add(special, "INVALID");
                                    temp = "";
                                }
                                    dataGridView1.Rows.Add(";", "VALID");
                                    temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("inorder"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();

                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "inorder")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == " ")
                            {
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp == "<")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ">")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "!")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("<"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("<", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains(">"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add(">", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("!"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("!", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("="))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("=", "VALID");
                                temp = "";
                            }
                            else if ((temp.Contains(" ")))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp == ")")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "{")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsDigit))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("otherorder"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "otherorder")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == " ")
                            {
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp == "<")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ">")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "!")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("<"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("<", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains(">"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add(">", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("!"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("!", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("="))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("=", "VALID");
                                temp = "";
                            }
                            else if ((temp.Contains(" ")))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp == ")")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "{")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsDigit))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if ((items == "order")||(items == "order{")||(items == "order {"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "order")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "{")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("go"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "go")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "{")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items.Contains("phase"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();
                         
                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "phase")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == " ")
                            {
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp == "<")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ">")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == "!")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("<"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("<", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains(">"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add(">", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("!"))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("!", "VALID");
                                temp = "";
                            }
                            else if (temp.Contains("="))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("=", "VALID");
                                temp = "";
                            }
                            else if ((temp.Contains(" ")))
                            {
                                string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                                dataGridView1.Rows.Add(special, "VALID");
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (temp == ")")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ";")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsDigit))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if(items == "}") {
                    dataGridView1.Rows.Add(items, "VALID");
                }
                else if (items == "hold")
                {
                    dataGridView1.Rows.Add(items, "VALID");
                }
                else if (items.Contains("campaign"))
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();

                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "campaign")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == "(")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp == ")")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsLetter)||(temp.Length < 10))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else if (items == "operation")
                {
                    string temp = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        temp += item[i].ToString();

                        if (temp.All(char.IsLetter))
                        {
                            if (temp == "operation")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                        }
                        else {
                            if (temp == ":")
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else if (temp.All(char.IsLetter) || (temp.Length < 10))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }
                            else {
                                dataGridView1.Rows.Add(temp, "INVALID");
                                temp = "";
                            }
                        }
                    }
                }
                else { 
                    if (items.All(char.IsLetter) && (items.Length < 11) && (!(items.Contains("unit"))))
                    {
                        dataGridView1.Rows.Add(items, "VALID");
                    }
                    else if (items.Contains(" "))
                    {
                        string temp = "";
                        for (int i = 0; i < item.Length; i++)
                        {
                            temp += item[i].ToString();
                            MessageBox.Show(temp);
                            if (temp.Contains(" "))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                dataGridView1.Rows.Add("space", "VALID");
                                temp = "";
                            }
                            else if (items.All(char.IsLetter))
                            {
                                dataGridView1.Rows.Add(temp, "VALID");
                                temp = "";
                            }

                        }
                        if (items.Contains("("))
                        {
                            string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                            dataGridView1.Rows.Add(special, "VALID");
                            dataGridView1.Rows.Add("(", "VALID");
                            temp = "";
                        }
                        else if(items == ")") {
                            dataGridView1.Rows.Add(")", "VALID");
                            temp = "";
                        }
                        else if(items.Contains("!")) {
                            string special = Regex.Replace(temp, "[^a-zA-Z]", "");
                            dataGridView1.Rows.Add(special, "VALID");
                            dataGridView1.Rows.Add("!", "VALID");
                            temp = "";
                        }
                        else {
                            dataGridView1.Rows.Add(temp, "INVALID");
                            temp = "";
                        }
                    }
                    else {
                        dataGridView1.Rows.Add(items, "INVALID");
                        
                    }
                }
            }
        }

        private void RESET_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Clear();
        }

        private void rESETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Clear();
        }

        private void bAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
