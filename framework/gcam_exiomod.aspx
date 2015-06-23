<%@ Page Title="" Language="C#" MasterPageFile="~/mdmif.master" AutoEventWireup="true" CodeFile="gcam_exiomod.aspx.cs" Inherits="gcam_exiomod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        width: 395px;
    }
        .style6
        {
            width: 11px;
        }
        .style7
        {
            width: 13px;
        }
        .style8
        {
            width: 135px;
        }
        .style9
        {
            width: 15px;
        }
        .style10
        {
            width: 17px;
        }
        .style11
        {
            width: 85px;
        }
    .style12
    {
        width: 18px;
    }
    .style13
    {
        width: 91px;
    }
    .style14
    {
        width: 184px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset style="width: 1028px;">
      <table style="width: 872px">
        <tr>
          <td class="style5">
         
          </td>
           <td >
           
               <asp:Label ID="Label5" runat="server" Text="GCAM-Exiomod" Font-Bold="True"></asp:Label>
           
           </td>
           <td>
         
          </td>
        </tr>
    
      </table>

     <table>
     <tr>
        <td >
        
            <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
        
        </td>
     
     </tr>

  </table>
  <table>
     <tr>
        <td class="style8">
        
            <asp:Label ID="Label6" runat="server" Text="GCAM Beguin year:"></asp:Label>        
        
        </td>
        <td class="style11">
        
        
             <asp:Label ID="txtBeguinYear0" runat="server" Text="1990"></asp:Label>
        
        
        </td>
        <td>
        
        </td>

        <td class="style15">        
        
            <asp:Label ID="Label2" runat="server" Text="Exiomod Beguin year:"></asp:Label>        
        
        </td>
         <td class="style12">
        
        
             <asp:Label ID="txtBeguinYear" runat="server" Text="2008"></asp:Label>
        
        
        </td>
        <td class="style13">
        
        </td>
         <td class="style16">
        
        
             <asp:Label ID="Label4" runat="server" Text="End year:"></asp:Label>
        
        
        </td>
         <td class="style14">
        
        
           <asp:DropDownList ID="cmbEndYear" runat="server" Height="16px" Width="144px">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem>2010</asp:ListItem>
               <asp:ListItem>2015</asp:ListItem>
               <asp:ListItem>2020</asp:ListItem>
               <asp:ListItem>2025</asp:ListItem>
               <asp:ListItem>2030</asp:ListItem>
               <asp:ListItem>2035</asp:ListItem>
               <asp:ListItem>2040</asp:ListItem>
               <asp:ListItem>2045</asp:ListItem>
               <asp:ListItem>2050</asp:ListItem>
               <asp:ListItem>2055</asp:ListItem>
               <asp:ListItem>2060</asp:ListItem>
               <asp:ListItem>2065</asp:ListItem>
               <asp:ListItem>2070</asp:ListItem>
               <asp:ListItem>2075</asp:ListItem>
               <asp:ListItem>2080</asp:ListItem>
               <asp:ListItem>2085</asp:ListItem>
               <asp:ListItem>2090</asp:ListItem>
               <asp:ListItem>2095</asp:ListItem>
               <asp:ListItem>2100</asp:ListItem>
           </asp:DropDownList>
       
        
        </td>
     
     </tr>
  
  </table>


  <table>
     <tr>
        <td class="style17">
        
        </td>
        <td class="style6">
        
            <asp:Button ID="cmdRun" runat="server" onclick="cmdRun_Click" Text="Run" />
        
        </td>
        <td>
        
        </td>
        <td>
        
        </td>
     
     </tr>  
  
  </table>

    <table>
       <tr>
          <td class="style7">
          
          </td>
          <td class="style10">
          
              &nbsp;</td>
          <td class="style9">
          
              <asp:Chart ID="Chart1" runat="server" Width="878px" Height="463px" 
                  style="margin-left: 0px" EnableViewState="True">
                  <Series>
                      <asp:Series ChartType="Line" Name="Africa" Color="Red" LabelToolTip="Africa" 
                          LegendText="Africa">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="Cyan" 
                          Name="Australia_NZ">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="Lime" 
                          Name="Canada">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="Black" 
                          Name="China">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="MediumOrchid" 
                          Name="Eastern Europe">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="128, 128, 255" 
                          Name="Former Soviet Union">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="Teal" Name="India">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="Yellow" 
                          Name="Japan">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="128, 64, 64" 
                          MarkerStyle="Triangle" Name="Korea">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="255, 192, 192" 
                          MarkerStyle="Cross" Name="Latin America">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="192, 192, 255" 
                          MarkerStyle="Star4" Name="Middle East">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="192, 192, 0" 
                          MarkerStyle="Star5" Name="Southeast Asia">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="DarkOrange" 
                          MarkerStyle="Star6" Name="USA">
                      </asp:Series>
                      <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="0, 192, 0" 
                          MarkerStyle="Star10" Name="Western Europe">
                      </asp:Series>
                  </Series>
                  <ChartAreas>
                      <asp:ChartArea Name="ChartArea1">
                      </asp:ChartArea>
                  </ChartAreas>
              </asp:Chart>
          
          </td>
       
       </tr>
    
    </table>
    

</fieldset>
</asp:Content>

