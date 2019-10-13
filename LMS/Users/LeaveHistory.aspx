<%@ Page Title="" Language="C#" MasterPageFile="~/Users/user.Master" AutoEventWireup="true" CodeBehind="LeaveHistory.aspx.cs" Inherits="LMS.Users.LeaveHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            margin-left: 0px;
            margin-top: 0px;
            margin-bottom: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblLeavesTaken" runat="server" style="" Text="Leaves Taken:"></asp:Label>
    <asp:Label ID="LeavesTakenValue" runat="server"></asp:Label>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LMSConnectionString %>" SelectCommand="SELECT LR.leaveID, LR.empID, ED.Name, 
CASE WHEN LR.leave_type = 1 THEN 'Full Day'
ELSE 'Half Day'
END AS LeaveType , 
CASE WHEN LR.DayPart = 0 THEN 'Pre-Lunch' 
WHEN LR.DayPart = 1 THEN 'Post-Lunch'
WHEN LR.DayPart = 2 THEN 'Full Day'
END AS DayPart, LR.Category, LR.Reason, LR.fromdate, LR.todate, LR.Status FROM leave_request AS LR INNER JOIN empDetails AS ED ON LR.empID = @empId AND ED.empID = @empId">
        <SelectParameters>
            <asp:Parameter Name="empId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="leaveID" DataSourceID="SqlDataSource1" Width="1111px" CssClass="auto-style4" Height="169px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="leaveID" HeaderText="leaveID" SortExpression="leaveID" Visible="False" ReadOnly="True" />
            <asp:BoundField DataField="empID" HeaderText="empID" SortExpression="empID" Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" SortExpression="LeaveType" ReadOnly="True" />
            <asp:BoundField DataField="DayPart" HeaderText="Day Part" SortExpression="DayPart" ReadOnly="True" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
            <asp:BoundField DataField="fromdate" HeaderText="From date" SortExpression="fromdate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="todate" HeaderText="To date" SortExpression="todate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="CancelLeave" runat="server" OnClick="CancelLeave_Click" Text="Cancel" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#FF9900" />
    </asp:GridView><br /><br />
</asp:Content>
