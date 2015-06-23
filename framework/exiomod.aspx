<%@ Page Title="" Language="C#" MasterPageFile="~/mdmif.master" AutoEventWireup="true" CodeFile="exiomod.aspx.cs" Inherits="gcam_exiomod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 191px;
    }
        .style7
        {
            width: 58px;
        }
        .style9
        {
            width: 106px;
        }
        .style10
        {
            width: 526px;
        }
        .style12
        {
            width: 64px;
        }
        .style14
        {
            width: 128px;
        }
        .style15
        {
            width: 103px;
        }
        .style16
        {
            width: 68px;
        }
        .style17
        {
            width: 121px;
        }
        .style19
    {
        width: 388px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset style="width: 1028px;">
      <table style="width: 872px">
        <tr>
          <td class="style19">
         
          </td>
           <td >
           
               <asp:Label ID="Label5" runat="server" Text="EXIOMOD " Font-Bold="True"></asp:Label>
           
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
        <td class="style15">
        
        
            <asp:Label ID="Label2" runat="server" Text="Beguin year:"></asp:Label>
        
        
        </td>
         <td class="style12">
        
        
             <asp:Label ID="txtBeguinYear" runat="server" Text="2008"></asp:Label>
        
        
        </td>
         <td class="style16">
        
        
             <asp:Label ID="Label4" runat="server" Text="End year:"></asp:Label>
        
        
        </td>
         <td class="style14">
        
        
             <asp:TextBox ID="txtEndYear" runat="server"></asp:TextBox>
        
        
        </td>
     
     </tr>
  
  </table>


  <table>
     <tr>
        <td class="style17">
        
        </td>
        <td class="style6">
        
            <asp:Button ID="cmdRun" runat="server" onclick="cmdRun_Click" 
                Text="Run EXIOMOD" />
        
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
          
              <asp:ListBox ID="lstExio" runat="server" Height="435px" Width="322px">
              </asp:ListBox>
          
          </td>
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

