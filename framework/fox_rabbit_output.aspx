<%@ Page Title="" Language="C#" MasterPageFile="~/mdmif.master" AutoEventWireup="true" CodeFile="fox_rabbit_output.aspx.cs" Inherits="fox_rabbit_output" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        width: 676px;
        height: 322px;
    }
    .style6
    {
        width: 613px;
        height: 322px;
    }
    .style7
    {
        width: 79px;
        height: 322px;
    }
        .style8
        {
            width: 731px;
        }
        .style9
        {
            width: 269px;
        }
        .style11
        {
            width: 609px;
        }
        .style12
        {
            width: 548px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <fieldset style="width: 900px; margin-left:70px;">
<br />
<table>
  <tr>
     <td class="style9">
     
     </td>
     <td class="style12">
     
     </td>
     <td class="style11">
     
         <asp:Button ID="cmdDisplay" runat="server" onclick="cmdDisplay_Click" 
             Text="Display" />
     
     </td>
     <td class="style8">
     
         <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
     
     </td>
  </tr>

</table>
<table>
  <tr>
    <td class="style7">
    
    </td>
    <td class="style6">
    
           <asp:Chart ID="Chart1" runat="server" Height="350px" Width="600px">
                 <series>
                     <asp:Series Name="Series1">
                     </asp:Series>
                     <asp:Series Name="Series2" Color="Red">
                     </asp:Series>
                 </series>
                 <chartareas>
                     <asp:ChartArea Name="ChartArea1">
                     </asp:ChartArea>
                 </chartareas>
             </asp:Chart>
    
    </td>
    <td class="style5">
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    </td>
  
  </tr>
</table>

<br />
</fieldset>

</asp:Content>

