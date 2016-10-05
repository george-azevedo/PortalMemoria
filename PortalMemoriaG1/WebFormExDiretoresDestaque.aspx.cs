using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PortalMemoriaG1
{
    public partial class WebFormExDiretoresDestaque : System.Web.UI.Page
    {
        List<String> ExDiretores;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeArquivoTexto();
            InitDiretor();
        }
		
		// teste 2 do github

        void LeArquivoTexto()
        {
            StreamReader sr;
            string Arquivo, Linha;

            // Cria Lista de Diretores
            ExDiretores = new List<String>();
            // Nome do Arquivo Texto
            Arquivo = Request.PhysicalApplicationPath + "ExDiretores\\" +
                      Request.QueryString["diretor"] + ".txt";
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


        void InitDiretor()
        {
            string strExDiretor = "";

            LabelDiretor.Text = Request.QueryString["diretornome"];
            ImageDiretor.ImageUrl = "~\\ExDiretores\\" +
                 Request.QueryString["diretor"] + "Destaque.jpg";

            LeArquivoTexto();
            // Carrega dados da lista em variavel string
            foreach (string strlinha in ExDiretores)
            {
                strExDiretor = strExDiretor + "<br />" + strlinha;
            }
            LabelDiretorDestaque.Text = strExDiretor;

        }

    }
}