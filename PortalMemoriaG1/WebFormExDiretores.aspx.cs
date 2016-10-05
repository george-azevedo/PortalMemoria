using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PortalMemoriaG1
{
    public partial class WebFormExDiretores : System.Web.UI.Page
    {
        List<String> ExDiretores;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeArquivoTexto();
            InitTable();
        }

        void LeArquivoTexto()
        {
            StreamReader sr;
            string Arquivo, Linha;
            // Teste do github
            // Cria Lista de Diretores
            ExDiretores = new List<String>();
            // Nome do Arquivo Texto
            Arquivo = Request.PhysicalApplicationPath +
        "ExDiretores\\ExDiretores.txt";
            // Le arquivo com nome de imagens
            if (System.IO.File.Exists(Arquivo))
            {
                sr = new StreamReader(System.IO.File.OpenRead(Arquivo));
                try
                {
                    while (sr.Peek() > -1)
                    {
                        Linha = sr.ReadLine(); // Le uma Linha
                        ExDiretores.Add(Linha);
                    }
                }
                finally
                {
                    sr.Close();
                }
            }
        }


 // Le Lista de Ex-Diretores e acrescenta componentes visuais de apresentação
        void InitTable()
        {
            TableRow tr;
            TableCell tc;
            ImageButton imagem;
            Label rotulo;
            string[] linha;
            int indicecoluna, qtdcoluna;

            // Le arquivo com nome de imagens
            if (ExDiretores.Count > 0)
            {
                indicecoluna = 0; qtdcoluna = 3;
                tr = new TableRow(); // Cria nova linha do componente table
                foreach(string strlinha in ExDiretores)
                {
                    // Separa os dados em cada linha
                    linha = strlinha.Split(';');
                // Configuração de uma celula da tabela
                // Cada celula da tabela tem 3 elementos: imagem do diretor, 
                //    nome do diretor e periodo de direção
                tc = new TableCell();
                // Configura Imagem do Diretor
                imagem = new ImageButton();
                imagem.ImageUrl = "~\\ExDiretores\\Diretor" + linha[0] +".jpg"; 
                    // linha[0] contem o ano inicial do diretor
                imagem.ToolTip = linha[1];
                imagem.PostBackUrl = "~\\WebFormExDiretoresDestaque.aspx?diretor=Diretor" + linha[0] + "&diretornome=" + linha[1];                   
                tc.Controls.Add(imagem); // Adiciona imagem na celula
                tc.Height = 100;
                tc.Width = 800 / qtdcoluna;
                tc.HorizontalAlign = HorizontalAlign.Center;
                // Configura Nome do diretor
                rotulo = new Label();
                rotulo.Text =  "<br />" + linha[1]; // linha[1] contem o nome do diretor
                tc.Controls.Add(rotulo); // Adiciona rotulo na celula
                rotulo.Font.Name = "verdana";
                rotulo.Font.Bold = true;
                rotulo.Font.Size = 8;
                // Configura Periodo de direção
                rotulo = new Label();
                rotulo.Text = "<br />" + linha[2]; // linha[1] contem o nome do diretor
                tc.Controls.Add(rotulo); // Adiciona rotulo na celula
                rotulo.Font.Name = "verdana";
                rotulo.Font.Size = 8;
                // Adiciona celula na linha
                tr.Cells.Add(tc); 
                // Contador de colunas
                indicecoluna++;
                if (indicecoluna==qtdcoluna)
                {
                    // Adiciona linha configurada na tabela
                    TableExDiretores.Rows.Add(tr);
                    // Cria nova linha do componente table
                    tr = new TableRow();
                    indicecoluna = 0;
                } 
                }

                if (indicecoluna != 0)
                    // Adiciona linha configurada na tabela
                    TableExDiretores.Rows.Add(tr);
            }
        }










    }
}