<%@ Page Title="" Language="C#" MasterPageFile="~/Users/user.Master" AutoEventWireup="true" CodeBehind="apply_leave.aspx.cs" Inherits="LMS.Users.WebForm3" %>







<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>







<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style4 {
            width: 746px;
        }
        .auto-style5 {
            width: 367px;
            height: 736px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style5">
        <tr>
            <td>
                Remaining Leaves:
            </td>
            <td class="auto-style4">
                <asp:Label ID="remainingleaveslbl" runat="server" Text=""></asp:Label>
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Leave Type: "></asp:Label>
            </td>
             <td class="auto-style4">
                 <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"  DataTextField="DayPart" DataValueField="DayPart"
                     >
                      <asp:ListItem>Select type</asp:ListItem>
                     <asp:ListItem>Full-Day Leave</asp:ListItem>
                     <asp:ListItem>Half-Day Leave</asp:ListItem>
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownList1" ErrorMessage="Please select Leave Type!" ID="leavetypevalidator"/>

               
             </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Day-Part: "></asp:Label>
                </td>
             <td class="auto-style4">
                 <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Pre-Lunch" AutoPostBack="true" GroupName="rbt" />
                 &nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text="Post-Lunch" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" GroupName="rbt" />
                 &nbsp;
            </td>
             <tr>
                 <td>
                     <asp:Label ID="Label7" runat="server" Text="Category: "></asp:Label>

                 </td>
                 <td class="auto-style4">
                     <asp:RequiredFieldValidator runat="server" ControlToValidate="categorylist" ErrorMessage="Please select a Category!" ID="RequiredFieldValidator1"/>
                     <asp:DropDownList ID="categorylist" runat="server" DataSourceID="SqlDataSource1" DataTextField="Leave_Category" DataValueField="Leave_Category" AutoPostBack="True"></asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LMSConnectionString %>" SelectCommand="SELECT [Leave_Category] FROM [leave_Category]"></asp:SqlDataSource>
                 </td>
                 <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Reason:"></asp:Label>

                </td>
            
             <td class="auto-style4">
                <asp:TextBox ID="txtreason" runat="server" ></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtreason" ErrorMessage="Please provide a reason!" ID="RequiredFieldValidator2"/>
            </td>

        </tr>
         <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="From: "></asp:Label>
                </td>
             <td class="auto-style4">
                 <asp:Calendar OnDayRender="Calendar1_DayRender" ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                     <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                     <NextPrevStyle VerticalAlign="Bottom" />
                     <OtherMonthDayStyle ForeColor="#808080" />
                     <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                     <SelectorStyle BackColor="#CCCCCC" />
                     <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                     <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                     <WeekendDayStyle BackColor="#FFFFCC" />
                 </asp:Calendar>
              
                 </td>
             </tr>
        <tr>
                <td>

                <asp:Label ID="Label6" runat="server" Text="To: "></asp:Label>
             </td>
             <td class="auto-style4">
                 <asp:Calendar OnDayRender="Calendar2_DayRender" ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                     <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                     <NextPrevStyle VerticalAlign="Bottom" />
                     <OtherMonthDayStyle ForeColor="#808080" />
                     <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                     <SelectorStyle BackColor="#CCCCCC" />
                     <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                     <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                     <WeekendDayStyle BackColor="#FFFFCC" />
                 </asp:Calendar>
                

            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/>
                <asp:Label ID="lblsuccess" runat="server" Text="Employee Successfully Registered.." Visible="false"></asp:Label>
            </td>
        </tr>
       

    </table>













</asp:Content>
