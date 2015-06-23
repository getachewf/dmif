<%@ Page Title="" Language="C#" MasterPageFile="~/mdmif.master" AutoEventWireup="true" CodeFile="real_time_integration.aspx.cs" Inherits="real_time_integration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style22
        {
            width: 159px;
        }
        .style24
        {
            width: 155px;
        }
        .style27
        {
            width: 872px;
        }
        .style32
        {
            width: 125px;
        }
        .style34
        {
            width: 15px;
        }
        .style39
        {
            width: 387px;
        }
        .style41
        {
            width: 255px;
        }
        .style43
        {
            width: 19px;
        }
        .style44
        {
            width: 23px;
        }
        .style45
        {
            width: 247px;
        }
        .style51
        {
            width: 99px;
        }
        .style52
        {
            width: 41px;
        }
        .style53
        {
            width: 210px;
        }
        .style54
        {
            width: 197px;
        }
        .style62
        {
            width: 104px;
        }
        .style64
        {
            width: 44px;
        }
        .style65
        {
            width: 133px;
        }
        .style66
        {
            width: 440px;
        }
        .style67
        {
            width: 120px;
        }
        .style68
        {
            width: 12px;
        }
        .style69
        {
            width: 219px;
        }
        .style70
        {
            width: 259px;
        }
        .style71
        {
            width: 218px;
        }
        .style72
        {
            width: 248px;
        }
        .style74
        {
            width: 8px;
        }
        .style75
        {
            width: 409px;
        }
        .style76
        {
            width: 224px;
        }
        .style77
        {
            width: 10px;
        }
        .style78
        {
            width: 102px;
        }
        .style80
        {
            width: 145px;
        }
        .style81
        {
            width: 203px;
        }
        .style82
        {
            width: 74px;
        }
        .style83
        {
            width: 79px;
        }
        .style84
        {
            width: 2px;
        }
        .style85
        {
            width: 84px;
        }
        .style86
        {
            width: 162px;
        }
        .style87
        {
            width: 82px;
        }
        .style88
        {
            width: 117px;
        }
        .style89
        {
            width: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  <table>
     <tr>
        <td class="style27">
        
            <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
        
        </td>
     
     </tr>
  
  </table>

  <fieldset style="width: 500px; height: 550px; float:right;">
    <table>
       <tr>
          <td class="style45">          
              <asp:Label ID="Label21" runat="server" Text="Linking variables"></asp:Label>          
          </td>       
       </tr>  
    
    </table>

    <table style="width: 331px">
     <tr>
       <td class="style65">
       
           <asp:Label ID="Label22" runat="server" Text="Ouput variable"></asp:Label>
       
       </td>
       <td class="style64" >
       
           &nbsp;</td>
       <td >
       
           <asp:Label ID="Label23" runat="server" Text="Input variable"></asp:Label>
       
       </td>
       <td>
       
       </td>
     
     </tr>

     </table>

     <table>

     <tr>
        <td class="style80">
        
            <asp:DropDownList ID="cmbVar1" runat="server" Height="22px" Width="175px" 
                onselectedindexchanged="cmbVar1_SelectedIndexChanged">
            </asp:DropDownList>
        
        </td>
          <td >
        
        </td>
         <td >        
        
             <asp:Label ID="Label29" runat="server" Text="=&gt;"></asp:Label>
        
        
        </td>
        <td >
        
        </td>
          <td >
        
              <asp:DropDownList ID="cmbVar2" runat="server" style="margin-left: 0px" 
                  Height="22px" Width="179px" 
                  onselectedindexchanged="cmbVar2_SelectedIndexChanged">
                  <asp:ListItem></asp:ListItem>
              </asp:DropDownList>
        
        </td>
        <td>
        
        </td>
       
        <td class="style78">
       
            <asp:Button ID="cmdLink" runat="server" Text="Link" onclick="Button1_Click1" 
                Width="51px" />
       
       </td>
        </tr>
    </table>

    <table>
        <tr>
           <td class="style66" >
           
               <asp:ListBox ID="lstLink" runat="server" Width="359px"></asp:ListBox>           
           </td>       
           <td class="style89">
           </td>
           <td  >
               <asp:Button ID="cmdGenerateLink" runat="server" onclick="cmdGenerateLink_Click" 
                   Text="Fetch Link" Width="118px" />
           <br />
               <asp:Button ID="cmdSaveLink" runat="server" Text="Save Link" Width="120px" 
                   onclick="cmdSaveLink_Click" />
           <br />
            <asp:Button ID="cmdRemove" runat="server" Text="Remove Link" 
                   onclick="cmdRemove_Click" Width="120px" />
           </td>
        
        </tr>
    
    </table>
    <table style="width: 282px">
       <tr>
         <td class="style83">
         
            <asp:Label ID="Label24" runat="server" Text="Excute for"></asp:Label>
        
         </td>
         <td class="style62">
         
            <asp:TextBox ID="txtYr" runat="server" Width="89px"></asp:TextBox>
        
         </td>
         <td class="style84">
         
         </td>
         <td>
         
            <asp:Label ID="Label25" runat="server" Text="unit"></asp:Label>
        
         </td>
       </tr>    
    </table>

    <table >
      <tr>
        <td class="style51" >
        
        </td>
        <td>
        
             <asp:Button ID="cmdRun" runat="server" onclick="cmdRun_Click" Text="Run" 
                 Width="63px" />
         
        </td>
        <td class="style82">
        
        </td>      
        <td class="style81" >
        
            <asp:Button ID="cmdSave" runat="server" Text="Save Output" />
        
        </td>  
      </tr>    
    </table>

    <table style="width: 269px">
      <tr>
        <td class="style52">
        
        </td>
        <td>        
            <asp:Label ID="Label26" runat="server" Text="Result"></asp:Label>        
        </td>
      </tr>
    </table>

    <table>
      <tr>
         <td>
         
         </td>
         <td class="style53">
         
              <asp:ListBox ID="lstOutput" runat="server" Height="125px" Width="329px" 
                  onselectedindexchanged="lst_SelectedIndexChanged"></asp:ListBox>
          
         </td>
         <td>
         
         </td>
      </tr>    
    
    </table>

    <table>
      <tr>
        <td>
        
        </td>
         <td class="style54">
        
           <asp:Chart ID="Chart1" runat="server" Height="178px" Width="418px" 
                   style="margin-left: 4px" BorderlineColor="Maroon" 
                   BorderlineDashStyle="Solid"  
                   >
                 <series>
                     <asp:Series Name="Model 1" ChartType="Line" Color="Navy" Legend="Legend1">
                     </asp:Series>
                     <asp:Series Name="Model 2" Color="Red" ChartType="Line" Legend="Legend1">
                     </asp:Series>
                 </series>
                 <chartareas>
                     <asp:ChartArea Name="ChartArea1">
                         <AxisY MaximumAutoSize="85">
                         </AxisY>
                         <AxisX MaximumAutoSize="85">
                         </AxisX>
                     </asp:ChartArea>
                 </chartareas>
                 <Legends>
                     <asp:Legend Name="Legend1">
                     </asp:Legend>
                 </Legends>
                 <BorderSkin BackImageWrapMode="Unscaled" />
             </asp:Chart>
        
        </td>
         <td>
        
        </td>
      </tr>
    
    </table>


  </fieldset>


    
 <fieldset style="width: 750px; float:left;">

   <table>
     <tr>
        <td class="style44">
        
        </td>
        <td class="style41">
        
            <asp:Label ID="Label14" runat="server" Text="Model 1" Font-Bold="True" 
                Font-Size="Large"></asp:Label>
        
        </td>
     </tr>  
  </table>

<table>
  <tr>
    <td class="style67" >
    
        <asp:Label ID="Label2" runat="server" 
            Text="Web service  URL "></asp:Label>
    
    </td>
    <td class="style68" >
    
           &nbsp;</td>
    <td class="style66" >
    
        <asp:TextBox ID="txtUrl" runat="server" Width="380px" 
            style="margin-left: 8px" ></asp:TextBox>
    
        <br />
    
        <asp:Label ID="Label3" runat="server" 
            Text="    e.g.http://www.w3schools.com/webservices/tempconvert.asmx?WSDL" 
            Font-Size="10pt"></asp:Label>
    
        <br />
    
    </td>
    <td class="style32" >
    
       <asp:Button ID="cmdGet" runat="server" onclick="cmdGet_Click" 
            Text="Get Methods" />
    
    </td>  
  </tr>
  </table>

 

  <table style="width: 716px">
     <tr>
        <td class="style69" >
        
            <asp:Label ID="Label6" runat="server" Text="Methods :"></asp:Label>
        
        </td>
         <td class="style70" >
        
             <asp:Label ID="Label7" runat="server" Text="Variables :"></asp:Label>
        
        </td>
         <td >
        
             <asp:Label ID="Label12" runat="server" Text="Input :"></asp:Label>
        
        </td>

     </tr>
  
  </table>
  
  <table style="width: 725px">
  <tr>
     <td class="style22">
     
         <asp:TreeView ID="treMethods" runat="server" 
             onselectednodechanged="treMethods_SelectedNodeChanged" 
             BorderStyle="Outset" Height="125px" Width="220px">
         </asp:TreeView>
     
     </td>
     <td >
         &nbsp;</td>
     <td class="style24">
     
         <asp:TreeView ID="treParam" runat="server" BorderStyle="Outset" Width="220px" 
             Height="125px" onselectednodechanged="treParam_SelectedNodeChanged">
         </asp:TreeView>
     
     </td>
     <td class="style34">
     
     </td>
     <td >
     
         <asp:Label ID="Label11" runat="server" Text="Name:"></asp:Label>
         <asp:Label ID="lblVar" runat="server" ForeColor="Blue"></asp:Label>
         <br />
     
         <asp:Label ID="Label9" runat="server" Text="Value"></asp:Label>
         <asp:TextBox ID="txtValue" runat="server" Width="94px"></asp:TextBox>
         <asp:Button ID="cmdSet" runat="server" Text="Set" onclick="cmdSet_Click" />
         <br />
         <br />
         <asp:ListBox ID="lstSet" runat="server" Height="72px" Width="172px"></asp:ListBox>
     
     </td>

  </tr>
    
  </table>
  <table>
     <tr>
        <td class="style88">
        
          <asp:Label ID="Label27" runat="server" Text="Temporal scale"></asp:Label>
      
        </td>
        <td>
        
        </td>
        <td class="style85">
        
          <asp:DropDownList ID="cmbM1Ts" runat="server" Height="18px" Width="69px">
              <asp:ListItem>1</asp:ListItem>
              <asp:ListItem>2</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
              <asp:ListItem>4</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
              <asp:ListItem>6</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
              <asp:ListItem>8</asp:ListItem>
              <asp:ListItem>9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
          </asp:DropDownList>
      
        </td>
        <td class="style86">
        
            <asp:Label ID="Label30" runat="server" Text="unit"></asp:Label>
        
        </td>
     </tr>
  </table>


</fieldset>




<fieldset style="width: 750px; float: left">

<table>
   <tr>
      <td class="style43">
   
      </td>
      <td class="style39">
      
          <asp:Label ID="Label13" runat="server" Text="Model 2" Font-Bold="True" 
              Font-Size="Large"></asp:Label>
      
      </td>
   </tr>

</table>

<table>
  <tr>
    <td class="style32" >
    
        <asp:Label ID="Label20" runat="server" 
            Text="Web service  URL "></asp:Label>
    
    </td>
    <td class="style74" >
    
           &nbsp;</td>
    <td class="style75" >
    
        <asp:TextBox ID="txtUrl2" runat="server" Width="380px" 
            style="margin-left: 8px"></asp:TextBox>
    

    
    </td>
    <td class="style32" >
    
       <asp:Button ID="cmdGet2" runat="server" Text="Get Methods" 
            onclick="cmdGet2_Click" />
    
    </td>  
  </tr>
  </table>

<table style="width: 722px">
     <tr>
        <td class="style71" >
        
            <asp:Label ID="Label1" runat="server" Text="Methods :"></asp:Label>
        
        </td>
         <td class="style72" >
        
             <asp:Label ID="Label8" runat="server" Text="Variables :"></asp:Label>
        
        </td>
         <td >
        
             <asp:Label ID="Label15" runat="server" Text="Input :"></asp:Label>
        
        </td>
  
     </tr>
  
  </table>


<table style="width: 719px">
  <tr>
     <td class="style76" >
     
         <asp:TreeView ID="treMethods2" runat="server"              
             BorderStyle="Outset" Height="133px" Width="220px" 
             onselectednodechanged="treMethods2_SelectedNodeChanged">
         </asp:TreeView>
     
     </td>
     <td >
         &nbsp;</td>
     <td class="style76" >
     
         <asp:TreeView ID="treParam2" runat="server" BorderStyle="Outset" Width="220px" 
             Height="136px" onselectednodechanged="treParam2_SelectedNodeChanged" >
         </asp:TreeView>
     
     </td>
     <td class="style77" >
     
     </td>
     <td >
     
         <asp:Label ID="Label17" runat="server" Text="Name:"></asp:Label>
         <asp:Label ID="lblVar2" runat="server" ForeColor="Blue"></asp:Label>
         <br />
     
         <asp:Label ID="Label19" runat="server" Text="Value"></asp:Label>
         <asp:TextBox ID="txtValue2" runat="server" Width="94px"></asp:TextBox>
         <asp:Button ID="cmdSet2" runat="server" Text="Set" onclick="cmdSet2_Click"  />
         <br />
         <br />
         <asp:ListBox ID="lstSet2" runat="server" Height="69px" Width="172px"></asp:ListBox>
     
     </td>

  </tr>
    
  </table>

  <table>
    <tr>
      <td class="style51">
      
            <asp:Label ID="Label5" runat="server" Text="Temporal scale"></asp:Label>
        
      </td>
      <td>
      
      </td>
      <td class="style87">
      
            <asp:DropDownList ID="cmbM2Ts" runat="server" Height="18px" 
                 Width="65px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
        
      </td>
      <td class="style22">
      
          <asp:Label ID="Label31" runat="server" Text="unit"></asp:Label>
      
      </td>
    </tr>
  </table>
  <br />

  
</fieldset>



<br />


    


</asp:Content>

