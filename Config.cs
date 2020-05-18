using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WindowsFormsApp1
{
    class Config
    {
        public XDocument arquivo { get; set; }
        public string caminhoArquivo { get; set; }


        public TreeNode Criar(string caminho)
        {
            XDocument newConfig = new XDocument(
                new XElement("Config", estruturaArm("Arm1"))
            );

            arquivo = newConfig;
            caminhoArquivo = caminho;

            newConfig.Save(caminhoArquivo);

            return CriarArvoreLateral("Arm1");
        }

        public TreeNode Abrir(string caminho)
        {
            XDocument openConfig = XDocument.Load(caminho);

            arquivo = openConfig;
            caminhoArquivo = caminho;

            return CriarArvoreLateral("Arm1");
        }

        public TreeNode CriarArvoreLateral(String nome)
        {
            return new TreeNode(nome,
                new TreeNode[] {
                    new TreeNode("General Purpose"),
                    new TreeNode("Flow Control"),
                    new TreeNode("Volume Accuracy")
                }
            );
        }
        
        public List<Parametros> BuscaParametros(string caminho)
        {
            var parametros = this.arquivo.XPathSelectElement("Config/" + caminho).Elements("Parameter");

            if (parametros.Count() > 0)
            {
                return parametros.Select(c => new Parametros
                {
                    id = c.Attribute("ID").Value,
                    descricao = c.Attribute("Description").Value,
                    valor = c.Attribute("Value").Value
                }).ToList();
            }
            else
            {
                return new List<Parametros>();
            }
        }

        public void alterarParametro(Parametros param, string valorParametro, string caminhoArvore)
        {
            var element = arquivo.XPathSelectElement("Config/" + caminhoArvore).Elements("Parameter")
            .Where(arg => arg.Attribute("ID").Value == param.id)
            .Single();

            element.Attribute("Value").SetValue(valorParametro);
            arquivo.Save(caminhoArquivo);
        }

        private XElement estruturaArm(String nome)
        {
            return new XElement(nome,
                        new XElement("GeneralPurpose",
                            new XAttribute("ID", "100"),
                                new XElement("Parameter",
                                    new XAttribute("ID", "101"),
                                    new XAttribute("Description", "Permissive Sense"),
                                    new XAttribute("Value", "NA")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "102"),
                                    new XAttribute("Description", "Permissive Message"),
                                    new XAttribute("Value", "")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "103"),
                                    new XAttribute("Description", "Permissive Restart"),
                                    new XAttribute("Value", "Manual")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "104"),
                                    new XAttribute("Description", "Load Arm ID"),
                                    new XAttribute("Value", "Arm 1")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "105"),
                                    new XAttribute("Description", "Ready Message"),
                                    new XAttribute("Value", "Zylix Ready")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "106"),
                                    new XAttribute("Description", "Bay Assignment"),
                                    new XAttribute("Value", "independent")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "107"),
                                    new XAttribute("Description", "Unlimited Preset"),
                                    new XAttribute("Value", "No")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "108"),
                                    new XAttribute("Description", "Transaction Reset Time"),
                                    new XAttribute("Value", "0")
                                )
                        ),
                        new XElement("FlowControl",
                            new XAttribute("id", "200"),
                                new XElement("Parameter",
                                    new XAttribute("ID", "201"),
                                    new XAttribute("Description", "Low Flow Start Rate"),
                                    new XAttribute("Value", "0.0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "202"),
                                    new XAttribute("Description", "High Flow Rate"),
                                    new XAttribute("Value", "0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "203"),
                                    new XAttribute("Description", "Start Stop Delay"),
                                    new XAttribute("Value", "0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "204"),
                                    new XAttribute("Description", "Valve Delay Open"),
                                    new XAttribute("Value", "0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "205"),
                                    new XAttribute("Description", "Pump Delay Off"),
                                    new XAttribute("Value", "NA")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "206"),
                                    new XAttribute("Description", "Clean Line Amount"),
                                    new XAttribute("Value", "0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "207"),
                                    new XAttribute("Description", "Ratio Factor Adjust"),
                                    new XAttribute("Value", "0.0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "208"),
                                    new XAttribute("Description", "Block Valve Position"),
                                    new XAttribute("Value", "Always Close")
                                )
                        ),
                        new XElement("VolumeAccuracy",
                            new XAttribute("id", "300"),
                                new XElement("Parameter",
                                    new XAttribute("ID", "301"),
                                    new XAttribute("Description", "Blend Tolerance (Pct)"),
                                    new XAttribute("Value", "0.0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "302"),
                                    new XAttribute("Description", "Blend Tolerance (Amt)"),
                                    new XAttribute("Value", "0.0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "303"),
                                    new XAttribute("Description", "Blend Correction"),
                                    new XAttribute("Value", "No Correction")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "304"),
                                    new XAttribute("Description", "Blend Alarm Timeout"),
                                    new XAttribute("Value", "0")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "305"),
                                    new XAttribute("Description", "Blend Error Reset"),
                                    new XAttribute("Value", "Batch Start")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "306"),
                                    new XAttribute("Description", "Blend Algorithm"),
                                    new XAttribute("Value", "Ratio Adj Factor")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "307"),
                                    new XAttribute("Description", "Ratio Product Minimum Flow"),
                                    new XAttribute("Value", "Maintain min rate")
                                ),
                                new XElement("Parameter",
                                    new XAttribute("ID", "308"),
                                    new XAttribute("Description", "Minimum Valve Close Time"),
                                    new XAttribute("Value", "0")
                                )
                        )
                    );
        }


    }
}
