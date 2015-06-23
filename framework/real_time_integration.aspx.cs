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
using System.Data.OleDb;
using System.Data;



public partial class real_time_integration : System.Web.UI.Page 
{
 
    private static MethodInfo[] methodInfo_1;
    private static ParameterInfo[] param_1;
    private static Type service_1;
    private static Type[] paramTypes_1;
    private static Properties myProperty_1;
    private static string MethodName_1 = "";

    private static MethodInfo[] methodInfo_2;
    private static ParameterInfo[] param_2;
    private static Type service_2;
    private static Type[] paramTypes_2;
    private static Properties_2 myProperty_2;
    private static string MethodName_2 = "";
 

    protected void Page_Load(object sender, EventArgs e)
    {



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         


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


    protected void cmdGet_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        treMethods.Nodes.Clear();
        treParam.Nodes.Clear();
        lstSet.Items.Clear();
        lblVar.Text = "";
        txtValue.Text = "";


        DynamicInvocation(txtUrl.Text, treMethods);

        

    }

    private void DynamicInvocation(string wsUrl, TreeView tv)
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
            TreeNode n= new TreeNode(sdName);
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
                service_1 = assembly.GetType(sdName);
                

                methodInfo_1 = service_1.GetMethods();
                foreach (MethodInfo t in methodInfo_1)
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


    private void DynamicInvocation_2(string wsUrl, TreeView tv)
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
                service_2 = assembly.GetType(sdName);


                methodInfo_2 = service_2.GetMethods();
                foreach (MethodInfo t in methodInfo_2)
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

    

    protected  void treMethods_SelectedNodeChanged(object sender, EventArgs e)
    {
            lblMsg.Text = "";
            treParam.Nodes.Clear();
            lblVar.Text = "";
            txtValue.Text = "";
            lstSet.Items.Clear();
           

            if (treMethods.SelectedNode.Parent != null)
            {

                TreeNode n = new TreeNode(treMethods.SelectedValue.ToString());
                treParam.Nodes.Add(n);
                MethodName_1 = treMethods.SelectedValue.ToString();
                
                int j = 0; //find row id of selected node                
                foreach (TreeNode m in treMethods.Nodes[0].ChildNodes )
                {
                    
                    if (m.Text == MethodName_1)
                    {
                        break; 
                    }
                    else
                        j = j + 1;
                }
                param_1 = methodInfo_1[j].GetParameters();

                myProperty_1 = new Properties(param_1.Length);

                // Get the Parameters Type
                paramTypes_1 = new Type[param_1.Length];
                for (int i = 0; i < paramTypes_1.Length; i++)
                {
                    paramTypes_1[i] = param_1[i].ParameterType;
                }

                cmbVar1.Items.Add("");
                foreach (ParameterInfo temp in param_1)
                {

                    //treParam.Nodes[0].Nodes.Add(temp.ParameterType.Name + "  " + temp.Name);
                    TreeNode m = new TreeNode(temp.Name + "; " + temp.ParameterType.Name);
                    treParam.Nodes[0].ChildNodes.Add(m);

                    cmbVar2.Items.Add(service_1 + ":" + MethodName_1  + ":" + temp.Name);

                }

                treParam.ExpandAll();

                cmbVar1.Items.Add( service_1 + ":" + MethodName_1);

            }        
                
    }


    protected void cmdMethods_Click(object sender, EventArgs e)
    {
       
    }
    protected void lst_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    

    protected void treParam_SelectedNodeChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblVar.Text = "";
        txtValue.Text = "";

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

        for (int i = 0; i < param_1.Length; i++)
        {
            if (lblVar.Text == param_1[i].Name)
            {
                myProperty_1.Index = i;
                myProperty_1.Type = param_1[i].ParameterType;
                myProperty_1.MyValue[i] = txtValue.Text;
                myProperty_1.TypeParameter[i] = param_1[i].ParameterType;


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
       

    }


    protected void cmdGet2_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        treMethods2.Nodes.Clear();
        treParam2.Nodes.Clear();
        lstSet2.Items.Clear();
        lblVar2.Text = "";
        txtValue2.Text = "";


        DynamicInvocation_2(txtUrl2.Text, treMethods2);

        

    }
    protected void treMethods2_SelectedNodeChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        treParam2.Nodes.Clear();
        lblVar2.Text = "";
        txtValue2.Text = "";
        lstSet2.Items.Clear();

        if (treMethods2.SelectedNode.Parent != null)
        {

            TreeNode n = new TreeNode(treMethods2.SelectedValue.ToString());
            treParam2.Nodes.Add(n);
            MethodName_2 = treMethods2.SelectedValue.ToString();

            int j = 0; //find row id of selected node                
            foreach (TreeNode m in treMethods2.Nodes[0].ChildNodes)
            {

                if (m.Text == MethodName_2)
                {
                    break;
                }
                else
                    j = j + 1;
            }
            param_2 = methodInfo_2[j].GetParameters();

            myProperty_2 = new Properties_2(param_2.Length);

            // Get the Parameters Type
            paramTypes_2 = new Type[param_2.Length];
            for (int i = 0; i < paramTypes_2.Length; i++)
            {
                paramTypes_2[i] = param_2[i].ParameterType;
            }


            
            foreach (ParameterInfo temp in param_2)
            {

                //treParam.Nodes[0].Nodes.Add(temp.ParameterType.Name + "  " + temp.Name);
                TreeNode m = new TreeNode(temp.Name + "; " + temp.ParameterType.Name);
                treParam2.Nodes[0].ChildNodes.Add(m);

                cmbVar2.Items.Add(service_2 + ":" + MethodName_2 + ":" + temp.Name);

            }

            treParam2.ExpandAll();

            cmbVar1.Items.Add(service_2 + ":" + MethodName_2);

        }     
    }
    protected void treParam2_SelectedNodeChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblVar2.Text = "";
        txtValue2.Text = "";

        if (treParam2.SelectedNode.Parent != null)
        {
            string s = treParam2.SelectedValue.ToString();
            string tmp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i, 1) == ";")
                    break;
                tmp = tmp + s.Substring(i, 1);
            }

            lblVar2.Text = tmp;
        }

    }
    protected void cmdSet2_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        if (lblVar2.Text == "")
        {
            lblMsg.Text = "First select the variable";
            goto Wuta;
        }

        if (txtValue2.Text == "")
        {
            lblMsg.Text = "Value can not be empty";
            goto Wuta;
        }


        lstSet2.Items.Add(lblVar2.Text + ":" + txtValue2.Text);

        for (int i = 0; i < param_2.Length; i++)
        {
            if (lblVar2.Text == param_2[i].Name)
            {
                myProperty_2.Index = i;
                myProperty_2.Type = param_2[i].ParameterType;
                myProperty_2.MyValue[i] = txtValue2.Text;
                myProperty_2.TypeParameter[i] = param_2[i].ParameterType;
                break;
            }
        }

        Wuta: ;
    }

    protected void cmdInvoke2_Click(object sender, EventArgs e)
    {
        
    }

    protected void cmdRun_Click(object sender, EventArgs e)
    {

        lblMsg.Text = "";
        lstOutput.Items.Clear();

        //validation of inputs
        //MethodName_1

        for (int i = 0; i < param_1.Length; i++)
        {
            if (myProperty_1.MyValue[i] == null || myProperty_1.TypeParameter[i] == null)
            {
                lblMsg.Text = "Value for " + param_1[i].Name + " is not set";
                goto Wuta;
            }
        }

        for (int i = 0; i < param_2.Length; i++)
        {
            if (myProperty_2.MyValue[i] == null || myProperty_2.TypeParameter[i] == null)
            {
                lblMsg.Text = "Value for " + param_2[i].Name + " is not set";
                goto Wuta;
            }
        }

        if (txtYr.Text == "")
        {
            lblMsg.Text = "Enter for how long the models will run";
            goto Wuta;
        }

        if (lstLink.Items.Count <= 0)
        {
            lblMsg.Text = "Define the data exchange between the models";
            goto Wuta;
        }

        //set the number of loops
        int noLoops = Convert.ToInt16(txtYr.Text);
        int m1ts = Convert.ToInt16(cmbM1Ts.Text); //time step for model 1
        int m2ts = Convert.ToInt16(cmbM2Ts.Text); //time step for model 2


        object[] ob1 = new object[param_1.Length]; //for model 1
        Object response1= null;
        object[] ob2 = new object[param_2.Length]; //for model 2
        Object response2= null;        

        double[] m1 = new double[noLoops + 1]; //output array from model 1
        double[] m2 = new double[noLoops + 1]; //output array from model 2
        //copy initial values into the output array
        m1[0]= Convert.ToDouble(myProperty_1.MyValue[0]);
        m2[0] = Convert.ToDouble(myProperty_2.MyValue[0]); 

        try
        {
            
            for (int j = 0; j <= noLoops; j++ )
            {
                    //check timesteps to run the models
                    int m1mod = j % m1ts; //m1mod for maintaining result of % operation for model 1
                    int m2mod = j % m2ts; //m2mod for maintaining result of % operation for model 2

                    //run model 1 if the timestep is appropriate
                    if (m1mod == 0)
                    {
                        for (int i = 0; i < param_1.Length; i++)
                        {
                            ob1[i] = Convert.ChangeType(myProperty_1.MyValue[i], myProperty_1.TypeParameter[i]);

                        }

                        foreach (MethodInfo t in methodInfo_1)
                            if (t.Name == MethodName_1)
                            {
                                Object obj1 = Activator.CreateInstance(service_1);
                                response1 = t.Invoke(obj1, ob1);

                                break;
                            }
                    }

                    //run model 2 if the timestep is appropriate
                    if (m2mod == 0)
                    {
                        for (int i = 0; i < param_2.Length; i++)
                        {
                            ob2[i] = Convert.ChangeType(myProperty_2.MyValue[i], myProperty_2.TypeParameter[i]);

                        }

                        foreach (MethodInfo t1 in methodInfo_2)
                            if (t1.Name == MethodName_2)
                            {
                                Object obj2 = Activator.CreateInstance(service_2);
                                response2 = t1.Invoke(obj2, ob2);

                                break;
                            }
                    }

                    //check the next timesteps to release data i.e just before the next model run
                    m1mod = (j + 1) % m1ts; //m1mod for maintaining result of % operation for model 1
                    m2mod = (j + 1) % m2ts; //m2mod for maintaining result of % operation for model 2

                    //update the lattest values for the next model run
                    int noRows = lstLink.Items.Count; //number of variable to be updated with the latest values
                   
                    if(noRows > 0)
                    {
                        for (int k = 0; k < noRows; k++)
                        {
                            string src_mdl = ""; //source model
                            string src_var = ""; //source variable from source model
                            string dest_mdl = ""; //destination model
                            string dest_var = ""; //destination variable from destination model

                            string s = lstLink.Items[k].Value.ToString();


                            //find the source model 
                            int i = 0;
                            // find m1 or m2 for source
                            for (i = 0; i < s.Length; i++)
                            {
                                if (s.Substring(i, 1) == ":")
                                    break;
                                src_mdl = src_mdl + s.Substring(i, 1);
                            }
                            //find the source variable names  
                            for (i = i + 1; i < s.Length; i++) // i = i + 1 is to skip ":"
                            {
                                if (s.Substring(i, 1) == "=" )
                                    break;
                                src_var = src_var + s.Substring(i, 1);
                            }


                            //find the destination model 
                            // find m1 or m2 for destination    
                            for (i = i + 2; i < s.Length; i++) // i = i + 2 is to skip the symbol =>
                            {
                                if (s.Substring(i, 1) == ":")
                                    break;
                                dest_mdl = dest_mdl + s.Substring(i, 1);
                            }
                            //skip the destination method name since we donot need it
                            string dest_method = "";
                            for (i = i + 1; i < s.Length; i++) // i = i + 1 is to skip two digits for ":" 
                            {
                                if (s.Substring(i, 1) == ":")
                                    break;
                                dest_method = dest_method + s.Substring(i, 1);
                            }
                            //find the destination variable names
                            for (i = i + 1; i < s.Length; i++) // i = i + 1 is to skip two digits for ":" 
                            {
                                dest_var = dest_var + s.Substring(i, 1);
                            }

                            if (m1mod == 0) //if model 1 is going to process in next timestep release the data now
                            {
                                if (src_mdl == service_1.ToString()) //"M1") //output from model 1 will update variable in model 1 or 2
                                {
                                    if (dest_mdl == service_1.ToString()) //"M1") //destination variable is from m1
                                    {
                                        for (int q = 0; q < param_1.Length; q++)
                                        {
                                            if (dest_var == param_1[q].Name) //find the value to be update from model 1
                                            {
                                                myProperty_1.Index = q;
                                                myProperty_1.Type = param_1[q].ParameterType;
                                                myProperty_1.MyValue[q] = response1.ToString(); //set the new value for model 1
                                                myProperty_1.TypeParameter[q] = param_1[q].ParameterType;
                                                break;
                                            }
                                        }

                                    }

                                    if (dest_mdl == service_2.ToString()) // "M2") //destination variable is from m2
                                    {
                                        for (int p = 0; p < param_2.Length; p++)
                                        {
                                            if (dest_var == param_2[p].Name) //find the value to be update from model 2
                                            {
                                                myProperty_2.Index = p;
                                                myProperty_2.Type = param_2[p].ParameterType;
                                                myProperty_2.MyValue[p] = response1.ToString(); //set the new value for model 2
                                                myProperty_2.TypeParameter[p] = param_2[p].ParameterType;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }


                            if (m2mod == 0) //if model 2 is going to process in next timestep release the data now
                            {
                                if (src_mdl == service_2.ToString()) // "M2") // output from model 2  will update variable in model 1 or 2
                                {
                                    if (dest_mdl == service_1.ToString()) // "M1") //destination variable is from m1
                                    {
                                        for (int q = 0; q < param_1.Length; q++)
                                        {
                                            if (dest_var == param_1[q].Name) //find the value to be update from model 1
                                            {
                                                myProperty_1.Index = q;
                                                myProperty_1.Type = param_1[q].ParameterType;
                                                myProperty_1.MyValue[q] = response2.ToString(); //set the new value for model 1
                                                myProperty_1.TypeParameter[q] = param_1[q].ParameterType;
                                                break;
                                            }
                                        }

                                    }

                                    if (dest_mdl == service_2.ToString()) // "M2") //destination variable is from m2
                                    {
                                        for (int p = 0; p < param_2.Length; p++)
                                        {
                                            if (dest_var == param_2[p].Name) //find the value to be update from model 2
                                            {
                                                myProperty_2.Index = p;
                                                myProperty_2.Type = param_2[p].ParameterType;
                                                myProperty_2.MyValue[p] = response2.ToString(); //set the new value for model 2
                                                myProperty_2.TypeParameter[p] = param_2[p].ParameterType;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                        }

                      }

                

                //copy output to array
                if (Convert.ToDouble(response1.ToString()) < 0 || Convert.ToDouble(response2.ToString()) < 0)
                {
                    
                }
                else
                {
                    m1[j] = Convert.ToDouble(response1.ToString());
                    m2[j] = Convert.ToDouble(response2.ToString());
                }

                ////display the result on the list box
                //lstOutput.Items.Add(j + " = " + m1[j] + "; " + m2[j]);

            }

            double[] x1 = new double[noLoops + 1]; //output array from model 1
            double[] y1 = new double[noLoops + 1]; //output array from model 2

            for (int i = 0; i < noLoops; i++)
            {

                //display the result on the list box
                lstOutput.Items.Add(i + " = " + m1[i] + "; " + m2[i]);

                if (Double.IsNaN(m1[i]) || Double.IsPositiveInfinity(m1[i]) || Double.IsNaN(m2[i]) || Double.IsPositiveInfinity(m2[i]))
                {
                    //if outptu value is NAN or infinity then skip it in the graph
                    break;
                }
                else
                {
                    
                    if (m1[i] < 0 && m2[i] < 0)
                    {
                        x1[i] = 0;
                        y1[i] = 0;
                        break;
                    }
                    else
                    {
                        x1[i] = m1[i];
                        y1[i] = m2[i];
                    }
                }


            }

            //display output on the graph
            Chart1.Series[0].Points.DataBindXY(x1, y1);
            Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message;
        }


        //clear data 
        lblMsg.Text = "";
        lstSet.Items.Clear();
        lblVar.Text = "";
        txtValue.Text = "";

        lstSet2.Items.Clear();
        lblVar2.Text = "";
        txtValue2.Text = "";

        for (int i = 0; i < param_1.Length; i++)
        {
            myProperty_1.MyValue[i] = null ;
            myProperty_1.TypeParameter[i] = null;            
        }

        for (int i = 0; i < param_2.Length; i++)
        {
            myProperty_2.MyValue[i] = null;
            myProperty_2.TypeParameter[i] = null;
        }

        Wuta:;



    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        if (cmbVar1.Text == "")
        {
            lblMsg.Text = "Select varaible from model 1";
            goto Wuta;
        }

        if (cmbVar2.Text == "")
        {
            lblMsg.Text = "Select varaible from model 2";
            goto Wuta;
        }
    

        lstLink.Items.Add(cmbVar1.Text  + "=>" + cmbVar2.Text);

    Wuta: ;
    }
    protected void cmdRemove_Click(object sender, EventArgs e)
    {
        if(lstLink.SelectedIndex < 0)
        {
            lblMsg.Text = "First select an item from the list";
            goto Wuta;
        }

        lstLink.Items.RemoveAt(lstLink.SelectedIndex);

    Wuta: ;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void cmdGenerateLink_Click(object sender, EventArgs e)
    {
        //lstLink.Items.Add("rabws:current_rab_pop=>rabws:current_rab_pop:rabpop");
        //lstLink.Items.Add("rabws:current_rab_pop=>foxws:current_fox_pop:r");
        //lstLink.Items.Add("foxws:current_fox_pop=>foxws:current_fox_pop:f");
        //lstLink.Items.Add("foxws:current_fox_pop=>rabws:current_rab_pop:foxpop");      
        

        if (service_1.ToString() == "")
        {
            lblMsg.Text = "Model 1 is not selected ";
           goto Wuta;
        }

        if (service_2.ToString() == "")
        {
            lblMsg.Text = "Model 2 is not selected ";
            goto Wuta;
        }

        string db = @"D:\prototype\framework\fmdb.accdb";
        string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + db;
        OleDbConnection c = new OleDbConnection(cs);

        try
        {
                c.Open();
                string s = "select mapping from tblSemanticMapping where (m1_name='" + service_1.ToString() + "' and m1_method_name='" + MethodName_1 + "' and m2_name='" + service_1.ToString() + "' and m2_method_name='" + MethodName_1 + "' )"; // m1.f1 & m1.f1
                s = s + " or (m1_name='" + service_1.ToString() + "' and m1_method_name='" + MethodName_1 + "' and m2_name='" + service_2.ToString() + "' and m2_method_name='" + MethodName_2 + "'  )  "; // m1.f1 & m2.f2
                s = s + " or (m1_name='" + service_2.ToString() + "' and m1_method_name='" + MethodName_2 + "' and m2_name='" + service_2.ToString() + "' and m2_method_name='" + MethodName_2 + "' )"; // m2.f2 & m2.f2
                s = s + " or (m1_name='" + service_2.ToString() + "' and m1_method_name='" + MethodName_2 + "' and m2_name='" + service_1.ToString() + "' and m2_method_name='" + MethodName_1 + "'  )  "; // m2.f2 & m1.f1
                
                lstLink.Items.Clear();

                using (OleDbCommand cmd = new OleDbCommand(s, c))
                {
                    OleDbDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstLink.Items.Add(reader["mapping"].ToString());
                    }
                    c.Close();
                }
            
        }

        catch (Exception)
        {
            throw;
        }
        finally
        {
            c.Close();
        }

         
    Wuta: ;

    }
    protected void cmbVar1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmbVar2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmdSaveLink_Click(object sender, EventArgs e)
    {
        
        string db = @"D:\prototype\framework\fmdb.accdb";
        string cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + db;
        OleDbConnection c = new OleDbConnection(cs);

        try
        {
            c.Open();
            string s = "insert into tblSemanticMapping (mapping, m1_name, m1_method_name, m2_name, m2_method_name, m2_var_name) values (@map, @m1_name, @m1_method_name, @m2_name, @m2_method_name, @m2_var_nam)";

            foreach (ListItem item in lstLink.Items) 
            {
                using (OleDbCommand cmd = new OleDbCommand(s, c))
                {
                       string str = item.ToString();
                        int l = str.Length;

                        string m1name = "", m1methodname = "", m2name = "", m2methodname = "", m2varname = "";

                        int i = 0;
                        //get m1name
                        for (i = 0; i < str.Length; i++)
                        {
                            if (str.Substring(i, 1) == ":")
                                break;
                            m1name = m1name + str.Substring(i, 1);
                        }

                        //get m1methodname
                        for (i = i + 1; i < str.Length; i++) //skip ":"
                        {
                            if (str.Substring(i, 1) == "=")
                                break;
                            m1methodname = m1methodname + str.Substring(i, 1);
                        }

                        //get m2name
                        for (i = i + 2; i < str.Length; i++) //skip =>
                        {
                            if (str.Substring(i, 1) == ":")
                                break;
                            m2name = m2name + str.Substring(i, 1);
                        }

                        //get m2methodname
                        for (i = i + 1; i < str.Length; i++) //skip ":"
                        {
                            if (str.Substring(i, 1) == ":")
                                break;
                            m2methodname = m2methodname + str.Substring(i, 1);
                        }

                        //get m2varname
                        for (i = i + 1; i < str.Length; i++) //skip ":"
                        {
                            m2varname = m2varname + str.Substring(i, 1);
                        }

                        cmd.Parameters.AddWithValue("@map", str);
                        cmd.Parameters.AddWithValue("@m1_name", m1name);
                        cmd.Parameters.AddWithValue("@m1_method_name", m1methodname);
                        cmd.Parameters.AddWithValue("@m2_name", m2name);
                        cmd.Parameters.AddWithValue("@m2_method_name", m2methodname);
                        cmd.Parameters.AddWithValue("@m2_var_name", m2varname);
                        cmd.ExecuteNonQuery();
                    }
              }
              
            lblMsg.Text = "Semantic Mapping Saved " ;
            }

        catch (Exception)
        {
            throw;
        }
        finally
        {
            c.Close();
        }

         
    }
}