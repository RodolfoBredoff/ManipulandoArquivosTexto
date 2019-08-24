﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManipulandoArquivosTexto
{
    public partial class Form1 : Form
    {

        private string strPathFile = @"C:\temp\ArquivoExemplo.txt";

        private void Criar()
        {
            try
            {
                //Usarei a cláusula using como boas práticas de programação em todos os métodos
                //Instancio a classe FileStream, uso a classe File e o método Create para criar o
                //arquivo passando como parâmetro a variável strPathFile, que contém o arquivo
                using (FileStream fs = File.Create(strPathFile))
                {
                    //Crio outro using, dentro dele instancio o StreamWriter (classe para gravar os dados)
                    //que recebe como parâmetro a variável fs, referente ao FileStream criado anteriormente
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //Uso o método Write para escrever algo em nosso arquivo texto
                        sw.Write("Texto adicionado ao exemplo!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Se tudo ocorrer bem, exibo a mensagem ao usuário.
            MessageBox.Show("Arquivo criado com sucesso!!!");
        }

        private void Abrir()
        {
            try
            {
                //Verifico se o arquivo que desejo abrir existe e passo como parâmetro a respectiva variável
                if (File.Exists(strPathFile))
                {
                    //Se existir "starto" um processo do sistema para abrir o arquivo e, sem precisar
                    //passar ao processo o aplicativo a ser aberto, ele abre automaticamente o Notepad
                    System.Diagnostics.Process.Start(strPathFile);
                }
                else
                {
                    //Se não existir exibo a mensagem
                    MessageBox.Show("Arquivo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Concatenar()
        {
            try
            {
                // Verifico se o arquivo que desejo
                // abrir existe e passo como parâmetro a
                // respectiva variável
                if (File.Exists(strPathFile))
                {
                    // Crio um using, dentro dele instancio
                    // StreamWriter, uso a classe File e o
                    // método AppendText para concatenar o
                    // texto, passando como parâmetro a
                    // variável strPathFile
                    using (StreamWriter sw =
                 File.AppendText(strPathFile))
                    {
                        // Uso o método Write para escrever o arquivo
                        // que será adicionado no arquivo text
                        sw.Write("\r\nTexto adicionado ao final do arquivo");
                    }
                    // Exibo a mensagem que o arquivo foi atualizado
                 MessageBox.Show("Arquivo atualizado!");
                }
                else
                {
                    // Se não existir exibo a mensagem
                    MessageBox.Show("Arquivo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Alterar()
        {
            try
            {
                // Verifico se existe a pasta
                //arquivo passando como parâmetro a variável strPathFile, que contém o arquivo
                if (File.Exists(strPathFile))
                {

                    using (StreamWriter sw = new StreamWriter(strPathFile))
                    {
                        //Uso o método Write para sobescrever algo em nosso arquivo texto
                        sw.Write("OUTRO Texto atualizado ao exemplo!");
                    }
                }
                else
                {
                    // Se não existir exibo a mensagem
                    MessageBox.Show("Arquivo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Excluir()
        {
            try
            {
                // Verificando se existe arquivo na pasta
                if (File.Exists(strPathFile))
                {
                    // Excluindo arquivo caso ele exista
                    File.Delete(strPathFile);
                    
                }
                else
                {
                    // Se não existir exibo a mensagem
                    MessageBox.Show("Arquivo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCriar_Click(object sender, EventArgs e)
        {
            Criar();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void BtnConcatenar_Click(object sender, EventArgs e)
        {
            Concatenar();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }
    }
}
