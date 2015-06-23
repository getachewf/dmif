<%@ Page Title="" Language="C#" MasterPageFile="~/mdmif.master" AutoEventWireup="true" CodeFile="rab_fox.aspx.cs" Inherits="rab_fox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <style type="text/css">
        .style2
        {
            width: 992px;
        }
        .style7
    {
        width: 13px;
    }
    .style8
    {
        width: 16px;
    }
    .style11
    {
        width: 27px;
    }
    .style14
    {
        width: 36px;
    }
    .style17
    {
        width: 135px;
    }
    .style18
    {
        width: 122px;
    }
        .style21
        {
            width: 83px;
        }
        .style22
        {
            width: 25px;
        }
        .style24
        {
            width: 103px;
        }
        .style25
        {
            width: 11px;
        }
        .style26
        {
            width: 188px;
        }
        .style27
        {
            width: 32px;
        }
        .style29
        {
            width: 20px;
        }
        .style31
        {
            width: 21px;
        }
        .style32
        {
            width: 131px;
        }
        .style33
        {
            width: 7px;
        }
        .style34
        {
            width: 112px;
        }
        .style37
        {
            width: 12px;
        }
        .style38
        {
            width: 121px;
        }
        .style40
        {
            width: 510px;
        }
        .style41
        {
            width: 151px;
        }
        .style43
        {
            width: 65px;
        }
        .style44
        {
            width: 236px;
        }
        .style45
        {
            width: 87px;
        }
        .style46
        {
            width: 15px;
        }
        .style47
        {
            width: 9px;
        }
        .style48
        {
            width: 81px;
        }
        .style49
        {
            width: 139px;
        }
        .style50
        {
            width: 147px;
        }
        .style51
        {
            width: 136px;
        }
        .style56
        {
            width: 30px;
        }
        .style58
        {
            width: 396px;
        }
        .style60
        {
            width: 249px;
        }
        .style61
        {
            width: 118px;
        }
        .style63
        {
            width: 339px;
        }
        .style67
        {
            width: 10px;
        }
        .style68
        {
            width: 50px;
        }
        .style69
        {
            width: 107px;
        }
        .style70
        {
            width: 223px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset style="width: 1148px; margin-left:7px; height: 475px;">

<br />

    <table style="width: 878px">
     <tr>
       <td class="style51">
        
           <asp:Label ID="Label1" runat="server" Text="Rabbit Population"></asp:Label>
        
       </td>
       <td class="style31">
       
       </td>
       <td class="style2">
       
           <asp:TextBox ID="txtRab" runat="server"></asp:TextBox>
       
       </td>    
    <td class="style25">
    
    </td>
      <td class="style50">
      
          <asp:Label ID="Label6" runat="server" Text="Rabbit Time Step"></asp:Label>
      
      </td>
      <td class="style47">
      
      </td>
      <td class="style45">
      
          <asp:DropDownList ID="cmbTsRab" runat="server" Height="18px" Width="69px">
              <asp:ListItem>0.1</asp:ListItem>
              <asp:ListItem>0.01</asp:ListItem>
              <asp:ListItem>0.001</asp:ListItem>
              <asp:ListItem>0.2</asp:ListItem>
              <asp:ListItem>0.3</asp:ListItem>
              <asp:ListItem>0.4</asp:ListItem>
              <asp:ListItem>0.5</asp:ListItem>
              <asp:ListItem>0.6</asp:ListItem>
              <asp:ListItem>0.7</asp:ListItem>
              <asp:ListItem>0.8</asp:ListItem>
              <asp:ListItem>0.9</asp:ListItem>
              <asp:ListItem>1</asp:ListItem>
              <asp:ListItem>1.3</asp:ListItem>
              <asp:ListItem>1.5</asp:ListItem>
              <asp:ListItem>1.7</asp:ListItem>
              <asp:ListItem>2</asp:ListItem>
              <asp:ListItem>2.3</asp:ListItem>
              <asp:ListItem>2.5</asp:ListItem>
              <asp:ListItem>2.7</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
          </asp:DropDownList>
      
      </td>
    
      <td class="style46">
      
      </td>
      <td class="style32">
      
          <asp:Label ID="Label7" runat="server" Text="Integration Method"></asp:Label>
      
      </td>
      <td>
      
          <asp:DropDownList ID="cmbRabIntMethod" runat="server" Height="18px" 
              Width="128px">
              <asp:ListItem>Euler</asp:ListItem>
              <asp:ListItem>Runge-Kutta</asp:ListItem>
          </asp:DropDownList>
      
      </td>


    </tr>
    
    </table>



    <table style="width: 827px">
      <tr>
        <td class="style18"> 
      
          <asp:Label ID="Label2" runat="server" Text="Fox Population"></asp:Label>
      
          </td>
        <td class="style29"> </td>
        <td class="style32"> 
      
          <asp:TextBox ID="txtFox" runat="server"></asp:TextBox>
      
          </td>
          <td class="style33">
          
          </td>
          <td class="style34">
          
            <asp:Label ID="Label5" runat="server" Text="Fox Time step"></asp:Label>
        
          </td>
          <td class="style8">
          
          </td>
          <td class="style48">
          
            <asp:DropDownList ID="cmbTsFox" runat="server" Height="18px" 
                onselectedindexchanged="cmbTs_SelectedIndexChanged" Width="65px">
                <asp:ListItem>0.1</asp:ListItem>
                <asp:ListItem>0.01</asp:ListItem>
                <asp:ListItem>0.001</asp:ListItem>
                <asp:ListItem>0.2</asp:ListItem>
                <asp:ListItem>0.3</asp:ListItem>
                <asp:ListItem>0.4</asp:ListItem>
                <asp:ListItem>0.5</asp:ListItem>
                <asp:ListItem>0.6</asp:ListItem>
                <asp:ListItem>0.7</asp:ListItem>
                <asp:ListItem>0.8</asp:ListItem>
                <asp:ListItem>0.9</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>1.3</asp:ListItem>
                <asp:ListItem>1.5</asp:ListItem>
                <asp:ListItem>1.7</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>2.3</asp:ListItem>
                <asp:ListItem>2.5</asp:ListItem>
                <asp:ListItem>2.7</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
        
          </td>

          <td class="style33">
      
         </td>
         <td class="style49">
      
          <asp:Label ID="Label8" runat="server" Text="Integration Method"></asp:Label>
      
        </td>
        <td>
      
          <asp:DropDownList ID="cmbFoxIntMethod" runat="server" Height="18px" 
              Width="128px">
              <asp:ListItem>Euler</asp:ListItem>
              <asp:ListItem>Runge-Kutta</asp:ListItem>
          </asp:DropDownList>
      
        </td>
      </tr>
    </table>

    <table style="width: 846px">
      <tr>
        <td class="style69">
        
            <asp:Label ID="Label3" runat="server" Text="Excute for"></asp:Label>
        
        </td>
        
        <td class="style22">
        
        </td>
        <td class="style7">
        
            <asp:TextBox ID="txtYr" runat="server"></asp:TextBox>
        
        </td>
        <td>
        
            <asp:Label ID="Label9" runat="server" Text="unit"></asp:Label>
        
        </td>
        <td class="style70">
          
         </td>
         <td class="style50">
          
            <asp:Label ID="Label4" runat="server" Text="Type of Integration"></asp:Label>
        
          </td>
          <td class="style37">
          
          </td>
          <td>
          
            <asp:DropDownList ID="cmbType" runat="server" Font-Size="Medium" Height="20px" 
                Width="114px">
                <asp:ListItem>Horizontal</asp:ListItem>
                <asp:ListItem>Vertical</asp:ListItem>
            </asp:DropDownList>
        
          </td>
        
      </tr>
    </table>

   <table style="width: 685px">
     <tr>
        <td class="style17">
        
            &nbsp;</td>
        <td class="style14">
        
        </td>
        <td>
        
            &nbsp;</td>
        <td class="style27">
        
        </td>
        <td class="style24">
        
            &nbsp;</td>
        <td class="style25">
        
        </td>
        <td class="style26">
        
            &nbsp;</td>
     </tr>
   
   
   </table>


   <table>
      <tr>
         <td class="style44" >
         
         </td>
         <td>
         
             <asp:Button ID="cmdRun" runat="server" onclick="cmdRun_Click" Text="Run" 
                 Width="63px" />
         
         </td>
         <td class="style21">
         
         </td>
         <td class="style38">
         
             <asp:Button ID="cmdSave" runat="server" Text="Save Output" 
                 onclick="cmdSave_Click" />
         
         </td>
         <td class="style43">
         </td>
         <td class="style41">
         
             <asp:Button ID="cmdClear" runat="server" Text="Clear" onclick="Button1_Click" 
                 Width="82px" />
         
         </td>
         <td class="style40">
         
             <asp:Label ID="lblMsg" runat="server" Width="455px"></asp:Label>
         
         </td>
      </tr>
   </table>
    
    <table style="width: 1413px; height: 319px;">
       <tr>
          <td class="style67">
          
              &nbsp;</td>
          <td class="style56" >
          
           </td>
           <td class="style63">
           <asp:Chart ID="Chart1" runat="server" Height="316px" Width="608px" 
                   style="margin-left: 4px" BorderlineColor="Maroon" 
                   BorderlineDashStyle="Solid" onload="Chart1_Load" 
                   >
                 <series>
                     <asp:Series Name="Rabbit" ChartType="Line" Color="Navy" Legend="Legend1">
                     </asp:Series>
                     <asp:Series Name="Fox" Color="Red" ChartType="Line" Legend="Legend1">
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
           <td class="style68">
           
           </td>
           <td class="style11">
           
               <asp:Chart ID="Chart2" runat="server" Palette="Fire" Width="673px" 
                   style="margin-left: 0px" BorderlineColor="Maroon" 
                   BorderlineDashStyle="Solid">
                   <series>
                       <asp:Series Name="X-Y plot" ChartType="Line" Color="192, 0, 192" 
                           Legend="Legend1">
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
               </asp:Chart>
           
           </td>

        </tr>   
    </table>

    <table style="width: 1214px">
      <tr>
         <td class="style60">
         
              <asp:ListBox ID="lst" runat="server" Height="278px" Width="329px" 
                  onselectedindexchanged="lst_SelectedIndexChanged"></asp:ListBox>
          
         </td>
         <td class="style58">
         
             <asp:Chart ID="Chart3" runat="server" BorderlineColor="Maroon" 
                 BorderlineDashStyle="Solid" Width="482px">
                 <Series>
                     <asp:Series ChartType="Line" Color="Navy" Legend="Legend1" Name="Rabbit">
                     </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                     </asp:ChartArea>
                 </ChartAreas>
                 <Legends>
                     <asp:Legend Name="Legend1">
                     </asp:Legend>
                 </Legends>
             </asp:Chart>
         
         </td>
         <td class="style61">
         
         </td>
         <td>
         
             <asp:Chart ID="Chart4" runat="server" BorderlineColor="Maroon" 
                 BorderlineDashStyle="Solid" Palette="Chocolate" Width="537px">
                 <Series>
                     <asp:Series ChartType="Line" Color="Red" Legend="Legend1" Name="Fox">
                     </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                     </asp:ChartArea>
                 </ChartAreas>
                 <Legends>
                     <asp:Legend Name="Legend1">
                     </asp:Legend>
                 </Legends>
             </asp:Chart>
         
         </td>
         <td>
         
         </td>
      
      </tr>
    
    </table>

 </fieldset>   

</asp:Content>

