using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Services;
using System.Reflection;
using System.Xml;
using System.Web.Services.Description;
using System.Xml.Serialization;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

public partial class real_time_models : System.Web.UI.Page
{
    private static MethodInfo[] methodInfo;
    private static ParameterInfo[] param;
    private static Type service;
    private static Type[] paramTypes;
    private static Properties myProperty;
    private static string MethodName = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdGet_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        treMethods.Nodes.Clear();
        treParam.Nodes.Clear();
        lstSet.Items.Clear();
        lblVar.Text = "";
        txtValue.Text = "";
        lstOut.Items.Clear();

        DynamicInvocation(txtUrl.Text, treMethods, ref methodInfo);
    }
    protected void treMethods_SelectedNodeChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        treParam.Nodes.Clear();
        lblVar.Text = "";
        txtValue.Text = "";
        lstSet.Items.Clear();
        lstOut.Items.Clear();


        if (treMethods.SelectedNode.Parent != null)
        {

            TreeNode n = new TreeNode(treMethods.SelectedValue.ToString());
            treParam.Nodes.Add(n);
            MethodName = treMethods.SelectedValue.ToString();

            int j = 0; //find row id of selected node                
            foreach (TreeNode m in treMethods.Nodes[0].ChildNodes)
            {

                if (m.Text == MethodName)
                {
                    break;
                }
                else
                    j = j + 1;
            }
            param = methodInfo[j].GetParameters();

            myProperty = new Properties(param.Length);

            // Get the Parameters Type
            paramTypes = new Type[param.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                paramTypes[i] = param[i].ParameterType;
            }

            foreach (ParameterInfo temp in param)
            {

                //treParam.Nodes[0].Nodes.Add(temp.ParameterType.Name + "  " + temp.Name);
                TreeNode m = new TreeNode(temp.Name + "; " + temp.ParameterType.Name);
                treParam.Nodes[0].ChildNodes.Add(m);

            }


            treParam.ExpandAll();

        }      
    }
    protected void treParam_SelectedNodeChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblVar.Text = "";
        txtValue.Text = "";
        lstOut.Items.Clear();

        if (treParam.SelectedNode.Parent != null)
        {
            string s = treParam.SelectedValue.ToString();
            string tmp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i, 1) == ";")
                    break;
                tmp = tmp + s.Substring(i, 1);
            }

            lblVar.Text = tmp;
        }
    }
    protected void cmdSet_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lstOut.Items.Clear();

        if (lblVar.Text == "")
        {
            lblMsg.Text = "First select the variable";
            goto Wuta;
        }

        if (txtValue.Text == "")
        {
            lblMsg.Text = "Value can not be empty";
            goto Wuta;
        }


        lstSet.Items.Add(lblVar.Text + ":" + txtValue.Text);

        for (int i = 0; i < param.Length; i++)
        {
            if (lblVar.Text == param[i].Name)
            {
                myProperty.Index = i;
                myProperty.Type = param[i].ParameterType;
                myProperty.MyValue[i] = txtValue.Text;
                myProperty.TypeParameter[i] = param[i].ParameterType;
                break;
            }
        }


        //myProperty.MyValue[rid] = txtValue.Text;
    //myProperty.TypeParameter[rid] = typeof(Single);
    //rid = rid + 1;

        Wuta: ;
    }
    protected void cmdInvoke_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lstOut.Items.Clear();

        //validate if the input is properly set
        for (int i = 0; i < param.Length; i++)
        {
            if (myProperty.MyValue[i] == null || myProperty.TypeParameter[i] == null)
            {
                lblMsg.Text = "Value for " + param[i].Name + " is not set";
                goto Wuta;
            }
        }

        object[] ob = new object[param.Length];
        try
        {
            for (int i = 0; i < param.Length; i++)
            {
                ob[i] = Convert.ChangeType(myProperty.MyValue[i], myProperty.TypeParameter[i]);
            }

            foreach (MethodInfo t in methodInfo)
                if (t.Name == MethodName)
                {
                    //Invoke Method
                    Object obj = Activator.CreateInstance(service);
                    Object response = t.Invoke(obj, ob);

                    lstOut.Items.Add(t.Name);
                    lstOut.Items.Add("Result = " + response.ToString());
                    


                    break;
                }

            /*
            string _strXmlFromUrl = GetPageSource("http://localhost//rabws/rabws.asmx?WSDL"); // My TestUrl: http://www.webservicex.net/globalweather.asmx?WSDL
            XmlDocument xmlDoc = new XmlDocument();
            XmlNamespaceManager nmspManager = new XmlNamespaceManager(xmlDoc.NameTable);
            nmspManager.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
            xmlDoc.LoadXml(_strXmlFromUrl);
            XmlNodeList methodNodes = xmlDoc.SelectNodes("//wsdl:portType/wsdl:operation[@name]", nmspManager);
            List<string> lstMehtodNames = new List<string>();
            for (int i = 0; i < methodNodes.Count; i++)
            {
                lstMehtodNames.Add(String.Concat(methodNodes[i].ParentNode.Attributes["name"].Value, ": ", methodNodes[i].Attributes[0].Value));

                lst.Items.Add(String.Concat(methodNodes[i].Attributes[0].Value));
            }

            */
        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message;
        }

    Wuta: ;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Web_Service ExampleAPI = new Web_Service(txtUrl.Text);
        string r = txtRab.Text;
        string f = txtFox.Text;

        ExampleAPI.PreInvoke();

        ExampleAPI.AddParameter("rabpop", r);                    // Case Sensitive! To avoid typos, just copy the WebMethod's signature and paste it
        ExampleAPI.AddParameter("foxpop", f);     // all parameters are passed as strings
        try
        {
            ExampleAPI.Invoke("pop_inc");                // name of the WebMethod to call (Case Sentitive again!)
        }
        finally { ExampleAPI.PosInvoke(); }

        txtpop.Text = ExampleAPI.ResultString;   
    }
    protected void cmdMethods_Click(object sender, EventArgs e)
    {
        string _strXmlFromUrl = GetPageSource("http://localhost//rabws/rabws.asmx?WSDL"); // My TestUrl: http://www.webservicex.net/globalweather.asmx?WSDL
        XmlDocument xmlDoc = new XmlDocument();
        XmlNamespaceManager nmspManager = new XmlNamespaceManager(xmlDoc.NameTable);
        nmspManager.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
        xmlDoc.LoadXml(_strXmlFromUrl);
        XmlNodeList methodNodes = xmlDoc.SelectNodes("//wsdl:portType/wsdl:operation[@name]", nmspManager);
        List<string> lstMehtodNames = new List<string>();
        for (int i = 0; i < methodNodes.Count; i++)
        {
            lstMehtodNames.Add(String.Concat(methodNodes[i].ParentNode.Attributes["name"].Value, ": ", methodNodes[i].Attributes[0].Value));

            lst.Items.Add(String.Concat(methodNodes[i].Attributes[0].Value));
        }
    }

    private void DynamicInvocation(string wsUrl, TreeView tv, ref MethodInfo[] methodInfo)
    {
        try
        {

            Uri uri = new Uri(wsUrl); //txtUrl.Text);

            WebRequest webRequest = WebRequest.Create(uri);
            System.IO.Stream requestStream = webRequest.GetResponse().GetResponseStream();
            // Get a WSDL file describing a service
            ServiceDescription sd = ServiceDescription.Read(requestStream);
            string sdName = sd.Services[0].Name;
            // Add in tree view
            TreeNode n = new TreeNode(sdName);
            tv.Nodes.Add(n);
            //treMethods.Nodes.Add(n);

            // Initialize a service description servImport
            ServiceDescriptionImporter servImport = new ServiceDescriptionImporter();
            servImport.AddServiceDescription(sd, String.Empty, String.Empty);
            servImport.ProtocolName = "Soap";
            servImport.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;

            CodeNamespace nameSpace = new CodeNamespace();
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
            codeCompileUnit.Namespaces.Add(nameSpace);
            // Set Warnings
            ServiceDescriptionImportWarnings warnings = servImport.Import(nameSpace, codeCompileUnit);

            if (warnings == 0)
            {
                StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
                Microsoft.CSharp.CSharpCodeProvider prov = new Microsoft.CSharp.CSharpCodeProvider();
                prov.GenerateCodeFromNamespace(nameSpace, stringWriter, new CodeGeneratorOptions());

                // Compile the assembly with the appropriate references
                string[] assemblyReferences = new string[2] { "System.Web.Services.dll", "System.Xml.dll" };
                CompilerParameters par = new CompilerParameters(assemblyReferences);
                par.GenerateExecutable = false;
                par.GenerateInMemory = true;
                par.TreatWarningsAsErrors = false;
                par.WarningLevel = 4;

                CompilerResults results = new CompilerResults(new TempFileCollection());
                results = prov.CompileAssemblyFromDom(par, codeCompileUnit);
                Assembly assembly = results.CompiledAssembly;
                service = assembly.GetType(sdName);


                methodInfo = service.GetMethods();
                foreach (MethodInfo t in methodInfo)
                {

                    if (t.Name == "Discover")
                        break;

                    n = new TreeNode(t.Name);
                    tv.Nodes[0].ChildNodes.Add(n);

                }

                tv.Nodes[0].Expand();

            }
            else
                lblMsg.Text += warnings;
        }
        catch (Exception ex)
        {
            lblMsg.Text += "\r\n" + ex.Message + "\r\n\r\n" + ex.ToString(); ;

        }
    }


    private string GetPageSource(string url)
    {
        string htmlSource = string.Empty;
        try
        {
            WebProxy myProxy = new WebProxy("ProxyAdress", 8080);
            using (WebClient client = new WebClient())
            {
                client.Proxy = myProxy;
                //client.Proxy.Credentials = new NetworkCredential("Username", "Password");
                htmlSource = client.DownloadString(url);
            }
        }
        catch (WebException ex)
        {
            lblMsg.Text = ex.Message;
        }
        return htmlSource;
    }


    protected void lst_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}