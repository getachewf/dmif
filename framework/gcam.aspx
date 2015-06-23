<%@ Page Title="" Language="C#" MasterPageFile="~/mdmif.master" AutoEventWireup="true" CodeFile="gcam.aspx.cs" Inherits="gcam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 102px;
        }
        .style9
        {
            width: 348px;
        }
        .style11
        {
            width: 1027px;
            height: 162px;
        }
        .style12
        {
            width: 11px;
            height: 162px;
        }
        .style13
        {
            width: 4px;
            height: 162px;
        }
        .style14
        {
            width: 92px;
        }
        .style16
        {
            width: 43px;
        }
    .style17
    {
        width: 89px;
    }
    .style18
    {
        width: 177px;
    }
        .style25
        {
            width: 75px;
        }
        .style26
        {
            width: 119px;
        }
        .style27
        {
            width: 101px;
        }
        .style29
        {
            width: 60px;
        }
        .style32
        {
            width: 152px;
        }
        .style37
        {
            width: 52px;
        }
        .style38
        {
            width: 486px;
        }
        .style39
        {
            width: 70px;
        }
        .style40
        {
            width: 81px;
        }
        .style41
        {
            width: 759px;
        }
        .style42
        {
            width: 174px;
        }
    .style43
    {
        width: 12px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
   <table style="width: 872px">
        <tr>
          <td class="style9">
         
          </td>
           <td >
           
               <asp:Label ID="Label5" runat="server" 
                   Text="GCAM - Global Change Assessment Model" Font-Bold="True" Font-Size="Large"></asp:Label>
           
           </td>
           <td>
         
          </td>
        </tr>
    
      </table>
     <table>
     <tr>
        <td class="style41" >
        
            <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
        
        </td>
     
     </tr>
     <tr>
        <td class="style41">
        
        
            <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Display Results"></asp:Label>
        
        
        </td>
     
     </tr>

  </table>


  <table>
    <tr>
       <td class="style25">
       
           <asp:Label ID="Label9" runat="server" Text="Region"></asp:Label>
       
       </td>
       <td class="style26">
       
           <asp:DropDownList ID="cmbRegion" runat="server" Height="16px" Width="166px">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem>Africa_Eastern</asp:ListItem>
               <asp:ListItem>Africa_Northern</asp:ListItem>
               <asp:ListItem>Africa_Southern</asp:ListItem>
               <asp:ListItem>Africa_Western</asp:ListItem>
               <asp:ListItem>Argentina</asp:ListItem>
               <asp:ListItem>Australia_NZ</asp:ListItem>
               <asp:ListItem>Brazil</asp:ListItem>
               <asp:ListItem>Canada</asp:ListItem>
               <asp:ListItem>Central America and Caribbean</asp:ListItem>
               <asp:ListItem>Central Asia</asp:ListItem>
               <asp:ListItem>China</asp:ListItem>
               <asp:ListItem>Colombia</asp:ListItem>
               <asp:ListItem>EU-12</asp:ListItem>
               <asp:ListItem>EU-15</asp:ListItem>
               <asp:ListItem>Europe_Eastern</asp:ListItem>
               <asp:ListItem>Europe_Non_EU</asp:ListItem>
               <asp:ListItem>European Free Trade Association</asp:ListItem>
               <asp:ListItem>global</asp:ListItem>
               <asp:ListItem>India</asp:ListItem>
               <asp:ListItem>Indonesia</asp:ListItem>
               <asp:ListItem>Japan</asp:ListItem>
               <asp:ListItem>Mexico</asp:ListItem>
               <asp:ListItem>Middle East</asp:ListItem>
               <asp:ListItem>Pakistan</asp:ListItem>
               <asp:ListItem>Russia</asp:ListItem>
               <asp:ListItem>South Africa</asp:ListItem>
               <asp:ListItem>South America_Northern</asp:ListItem>
               <asp:ListItem>South America_Southern</asp:ListItem>
               <asp:ListItem>South Asia</asp:ListItem>
               <asp:ListItem>South Asia</asp:ListItem>
               <asp:ListItem>Southeast Asia</asp:ListItem>
               <asp:ListItem>Taiwan</asp:ListItem>
               <asp:ListItem>USA</asp:ListItem>
           </asp:DropDownList>
       
       </td>
       <td class="style29">
       
           <asp:Label ID="Label10" runat="server" Text="Sector"></asp:Label>
       
       </td>
       <td class="style27">
       
           <asp:DropDownList ID="cmbSector" runat="server" Height="16px" Width="184px">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem>backup_electricity</asp:ListItem>
               <asp:ListItem>Beef</asp:ListItem>
               <asp:ListItem>biomass</asp:ListItem>
               <asp:ListItem>biomassOil</asp:ListItem>
               <asp:ListItem>carbon-storage</asp:ListItem>
               <asp:ListItem>cement</asp:ListItem>
               <asp:ListItem>coal</asp:ListItem>
               <asp:ListItem>comm cooling</asp:ListItem>
               <asp:ListItem>comm heating</asp:ListItem>
               <asp:ListItem>comm others</asp:ListItem>
               <asp:ListItem>Corn</asp:ListItem>
               <asp:ListItem>crude oil</asp:ListItem>
               <asp:ListItem>csp_backup</asp:ListItem>
               <asp:ListItem>Dairy</asp:ListItem>
               <asp:ListItem>Dairy</asp:ListItem>
               <asp:ListItem>delivered coal</asp:ListItem>
               <asp:ListItem>delivered gas</asp:ListItem>
               <asp:ListItem>distributed_solar</asp:ListItem>
               <asp:ListItem>district heat</asp:ListItem>
           </asp:DropDownList>
       
       </td>
       <td class="style43">
       
           &nbsp;</td>

       <td class="style14">
       
           <asp:Label ID="Label12" runat="server" Text="Technology"></asp:Label>
       
       </td>
       <td class="style32">
       
           <asp:DropDownList ID="cmbTechno" runat="server" Height="16px" Width="150px">
           </asp:DropDownList>
       
       </td>
       <td>

            <asp:Button ID="cmdDisplay" runat="server" Text="Display" 
                onclick="cmdDisplay_Click" />
       </td>
    
    </tr>
  
  </table>

  <table>
    <tr>
      <td>

      </td>
    </tr>
  </table>



  <table>
    <tr>
      <td class="style13">
      
      </td>
      <td class="style11">
      
          <asp:GridView ID="GridView1" runat="server" Height="217px" Width="981px" 
              AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" 
              PageSize="20" PageIndexChanging="GridView1_PageIndexChanging" >
              <AlternatingRowStyle BackColor="White" />
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" Height="20px" Width="30px" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <SortedAscendingCellStyle BackColor="#FDF5AC" />
              <SortedAscendingHeaderStyle BackColor="#4D0000" />
              <SortedDescendingCellStyle BackColor="#FCF6C0" />
              <SortedDescendingHeaderStyle BackColor="#820000" />
          </asp:GridView>
      
      </td>
      <td class="style12">
      
      </td>
    
    </tr>
  
  </table>

  <table>
    <tr>
       <td class="style42">
       
           <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Run Model"></asp:Label>
       
       </td>
    </tr>
  </table>
  <table style="width: 837px">
    <tr>
       <td class="style14">
       
           <asp:Label ID="Label6" runat="server" Text="Beguin year:"></asp:Label>
       
       </td>
       <td class="style37">
       
           <asp:Label ID="Label8" runat="server" Text="1990"></asp:Label>
       
       </td>
       <td class="style16">
       
       </td>
       <td class="style17">
       
           <asp:Label ID="Label7" runat="server" Text="End Year:"></asp:Label>
       
       </td>
       <td class="style18">
       
           <asp:DropDownList ID="cmbEndYear" runat="server" Height="16px" Width="144px">
               <asp:ListItem></asp:ListItem>
               <asp:ListItem>2005</asp:ListItem>
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
       <td>
       
       </td>
    
    </tr>
  
  </table>

     <table>
       <tr>
         <td class="style38">
         
             <asp:Label ID="lblWarn" runat="server" ForeColor="#FF3300"></asp:Label>
         
         </td>
          <td class="style6">
         
              <asp:Button ID="cmdRun" runat="server" Text="Run GCAM" Width="78px" 
                  onclick="cmdRun_Click" />
         
         </td>
          <td class="style40">
         
             <asp:Button ID="cmdNo" runat="server" Text="No" Visible="False" 
                  onclick="cmdNo_Click" />
         
         </td>
          <td class="style39">
         
              <asp:Button ID="cmdRun2" runat="server" BackColor="Red" onclick="cmdRun2_Click" 
                  Text="Run" Visible="False" Width="51px" />
         
         </td>
        
       </tr>
     
     </table>
   
   
   </fieldset>

</asp:Content>

