<%@ Page Title="" Language="C#" MasterPageFile="~/mdmif.master" AutoEventWireup="true" CodeFile="real_time_models.aspx.cs" Inherits="real_time_models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 312px;
        }
        .style8
        {
            width: 432px;
        }
        .style9
        {
            width: 434px;
        }
        .style10
        {
            width: 642px;
        }
        .style11
        {
            width: 311px;
        }
        .style12
        {
            width: 309px;
        }
        .style13
        {
            width: 162px;
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

    
    <fieldset style="width: 1028px;">


<table>
  <tr>
    <td class="style31" >
    
        <asp:Label ID="Label2" runat="server" 
            Text="Webservice  URL "></asp:Label>
    
    </td>
    <td class="style19" >
    
           &nbsp;</td>
    <td class="style10" >
    
        <asp:TextBox ID="txtUrl" runat="server" Width="618px" 
            style="margin-left: 8px"></asp:TextBox>
    
        <br />
    
        <asp:Label ID="Label3" runat="server" 
            Text="    e.g.http://www.w3schools.com/webservices/tempconvert.asmx?WSDL"></asp:Label>
    
        <br />
    
    </td>
    <td class="style13" >
    
       <asp:Button ID="cmdGet" runat="server" onclick="cmdGet_Click" 
            Text="Get Methods" />
    
    </td>  
  </tr>
  </table>

 

  <table style="width: 869px">
     <tr>
        <td class="style33">
        
            <asp:Label ID="Label6" runat="server" Text="Methods :"></asp:Label>
        
        </td>
         <td class="style37">
        
             <asp:Label ID="Label7" runat="server" Text="Variables :"></asp:Label>
        
        </td>
         <td class="style38">
        
             <asp:Label ID="Label12" runat="server" Text="Input :"></asp:Label>
        
        </td>
         <td>
        
             <asp:Label ID="Label10" runat="server" Text="Output :"></asp:Label>
        
        </td>
     </tr>
  
  </table>
  
  <table style="width: 1128px">
  <tr>
     <td class="style6" >
     
         <asp:TreeView ID="treMethods" runat="server" 
             onselectednodechanged="treMethods_SelectedNodeChanged" 
             BorderStyle="Outset" Height="164px" Width="314px">
         </asp:TreeView>
     
     </td>
     <td >
         &nbsp;</td>
     <td >
     
         <asp:TreeView ID="treParam" runat="server" BorderStyle="Outset" Width="316px" 
             Height="164px" onselectednodechanged="treParam_SelectedNodeChanged">
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
         <asp:ListBox ID="lstSet" runat="server" Height="98px" Width="172px"></asp:ListBox>
     
     </td>
     <td>
     
        <asp:Button ID="cmdInvoke" runat="server" Text="Invoke" 
             onclick="cmdInvoke_Click" />
    
         <br />
         <br />
         <asp:ListBox ID="lstOut" runat="server" Width="182px" Height="89px"></asp:ListBox>
    
     </td>
  </tr>
    
  </table>

<br />

</fieldset>

<table>
  <tr>
     <td >
     
         <asp:Label ID="Label4" runat="server" Text="Rabbit"></asp:Label>
     
     </td>
     <td >
     
         <asp:TextBox ID="txtRab" runat="server"></asp:TextBox>
     
     </td>
     <td >
     
         &nbsp;</td>
         <td class="style26">
         
             <asp:Label ID="Label5" runat="server" Text="Fox"></asp:Label>
         
         </td>
         <td >
         
             <asp:TextBox ID="txtFox" runat="server"></asp:TextBox>
         
         </td>
         <td>
         
         </td>
     <td >
     
         <asp:Button ID="cmdTest" runat="server" onclick="Button1_Click" Text="Test" />
     
     </td>
     <td >
     
         <asp:TextBox ID="txtpop" runat="server"></asp:TextBox>
     
     </td>
  </tr>

</table>

<br />
<table>
  <tr>
     <td class="style21">
     
     </td>
     <td class="style30">
     
         <asp:Button ID="cmdMethods" runat="server" onclick="cmdMethods_Click" 
             Text="List Methods" />
     
     </td>
     <td>
     
         <asp:ListBox ID="lst" runat="server" Width="419px" 
             onselectedindexchanged="lst_SelectedIndexChanged"></asp:ListBox>
     
     </td>
  
  </tr>
</table>

</asp:Content>

