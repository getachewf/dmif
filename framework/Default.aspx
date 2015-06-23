<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1 {
            width: 276px;
        }
        .style2
        {
            width: 352px;
        }
        .style3
        {
            width: 264px;
        }
        .style4
        {
            width: 155px;
        }
        .style6
        {
            width: 187px;
        }
        .style7
        {
            width: 233px;
        }
        .style8
        {
            width: 289px;
        }
        .style9
        {
            width: 502px;
            height: 181px;
        }
        .style10
        {
            width: 265px;
            height: 181px;
        }
        .style11
        {
            width: 390px;
        }
        .style12
        {
            width: 95px;
        }
        .style13
        {
            width: 164px;
        }
        .style14
        {
            width: 34px;
        }
        .style15
        {
            width: 312px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
    <table>
     <tr>
       <td class="style1">
        
           <asp:Label ID="Label1" runat="server" Text="Rabit Population"></asp:Label>
        
       </td>
       <td>
       
       </td>
       <td class="style2">
       
           <asp:TextBox ID="txtRab" runat="server"></asp:TextBox>
       
       </td>    
    </tr>

    <tr>
      <td>
      
          <asp:Label ID="Label2" runat="server" Text="Fox Population"></asp:Label>
      
      </td>
      <td>
      
      </td>
      <td class="style2">
      
          <asp:TextBox ID="txtFox" runat="server"></asp:TextBox>
      
      </td>
    
    </tr>
    
    </table>

    <table>
      <tr>
        <td class="style6">
        
            <asp:Label ID="Label3" runat="server" Text="Number of years"></asp:Label>
        
        </td>
        <td>
        
        </td>
        <td class="style7">
        
            <asp:TextBox ID="txtYr" runat="server"></asp:TextBox>
        
        </td>
      </tr>
    </table>

   <table style="width: 468px">
     <tr>
        <td class="style13">
        
            <asp:Label ID="Label4" runat="server" Text="Type of Integration"></asp:Label>
        
        </td>
        <td class="style14">
        
        </td>
        <td>
        
            <asp:DropDownList ID="cmbType" runat="server" Font-Size="Medium" Height="20px" 
                Width="183px">
                <asp:ListItem>Horizontal</asp:ListItem>
                <asp:ListItem>Vertical</asp:ListItem>
            </asp:DropDownList>
        
        </td>
     
     </tr>
   
   
   </table>


   <table>
      <tr>
         <td class="style3">
         
         </td>
         <td class="style4">
         
             <asp:Button ID="cmdRun" runat="server" onclick="cmdRun_Click" Text="Run" />
         
         </td>
      </tr>
   </table>
    
    <table style="width: 929px">
       <tr>
          <td class="style8">
          
              <asp:ListBox ID="lst" runat="server" Height="214px" Width="295px"></asp:ListBox>
          
          </td>
          <td>
          
           </td>
           <td class="style15">
           <asp:Chart ID="Chart1" runat="server" Height="400px" Width="600px">
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
           <td class="style12">
           
           </td>
           <td class="style11">
           
               <asp:Chart ID="Chart2" runat="server" Palette="Chocolate">
                   <series>
                       <asp:Series Name="Series1">
                       </asp:Series>
                   </series>
                   <chartareas>
                       <asp:ChartArea Name="ChartArea1">
                       </asp:ChartArea>
                   </chartareas>
               </asp:Chart>
           
           </td>

        </tr>   
    </table>

    <table>
      <tr>
         <td class="style10">
         
         </td>
         <td class="style9">
         
             
         
         </td>
      
      </tr>
    
    </table>

    

    </div>
    </form>
</body>
</html>
