<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="LeaveRequest.aspx.cs" Inherits="LMS.Admin.LeaveRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="leaveID" DataSourceID="SqlDataSource1" Width="1166px" >
        <Columns>
            <asp:BoundField DataField="empID" HeaderText="empID" SortExpression="empID" Visible="False" />
            <asp:BoundField DataField="leaveID" HeaderText="leaveID" ReadOnly="True" SortExpression="leaveID" Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="leave_type" HeaderText="Leave Type" SortExpression="leave_type" />
            <asp:BoundField DataField="DayPart" HeaderText="Day Part" SortExpression="DayPart" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
            <asp:BoundField DataField="fromdate" HeaderText="From" SortExpression="fromdate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="todate" HeaderText="To" SortExpression="todate" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="ApproveLink" runat="server" OnClick="ApproveLink_Click">Approve</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="RejectLink" runat="server" OnClick="RejectLink_Click">Reject</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#FF9900" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LMSConnectionString %>" SelectCommand="SELECT LR.empID, LR.leaveID, ED.Name, CASE WHEN leave_type = 1 THEN 'Full Day' WHEN leave_type = 2 THEN 'Half Day' END AS leave_type, CASE WHEN DayPart = 0 THEN 'Pre-Lunch' ELSE 'Post-Lunch' END AS DayPart, LR.Category, LR.Reason, LR.fromdate, LR.todate, LR.Status FROM leave_request AS LR LEFT OUTER JOIN empDetails AS ED ON LR.empID = ED.empID"></asp:SqlDataSource>
    

</asp:Content>

